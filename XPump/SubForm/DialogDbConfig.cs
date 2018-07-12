using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using CC;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace XPump.SubForm
{
    public partial class DialogDbConfig : Form
    {
        private FORM_MODE form_mode;
        private MainForm main_form;
        private LocalDbConfig localDb;
        public DbConnectionConfig curr_config;
        private DbConnectionConfig tmp_config;
        private bool FormFreeze
        {
            get
            {
                return !this.txtServerName.Enabled;
            }
            set
            {
                this.txtBranch.Enabled = !value;
                this.cbDepcod.Enabled = !value;
                this.txtServerName.Enabled = !value;
                this.txtDbName.Enabled = !value;
                this.numPort.Enabled = !value;
                this.txtUserId.Enabled = !value;
                this.txtPwd.Enabled = !value;
                this.txtConfPwd.Enabled = !value;
                this.btnSave.Enabled = !value;
                this.btnCancel.Enabled = !value;
            }
        }

        public DialogDbConfig(MainForm main_form, DbConnectionConfig curr_config = null)
        {
            this.curr_config = curr_config != null ? curr_config : new DbConnectionConfig { id = -1, branch = string.Empty, dbname = string.Empty, db_prefix = SecureDbHelper.GetDbPrefix(), depcod = string.Empty, passwordhash = string.Empty, port = 3306, servername = string.Empty, uid = string.Empty };
            
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            //this.SetUILanguage();
            InitializeComponent();
        }

        private void DialogDbConfig_Load(object sender, EventArgs e)
        {
            this.FormFreeze = false;
            this.LoadDepcodCombobox();
            this.lblPrefix.Text = SecureDbHelper.GetDbPrefix() + "_";
            //this.curr_config = this.LoadConfig();
            this.FillForm(this.curr_config);
        }

        //public void SetUILanguage()
        //{
        //    if (this.main_form.loged_in_status.language == UILANGUAGE.ENG)
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        //    }
        //    else
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("th-TH");
        //    }
        //}

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (XMessageBox.Show(this.main_form.GetMessage("0001"), "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question, this.main_form.c_info) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        private void LoadDepcodCombobox()
        {
            this.cbDepcod.Items.Add(new XDropdownListItem { Text = string.Empty, Value = string.Empty });
            foreach (var item in DbfTable.Istab(this.main_form.working_express_db).ToIstabList().Where(i => i.tabtyp == "50").ToList())
            {
                this.cbDepcod.Items.Add(new XComboBoxItem { Text = item.typcod, Value = item.typcod });
            }
        }

        private DbConnectionConfig LoadConfig()
        {
            return new LocalDbConfig(this.main_form.working_express_db).ConfigValue;
        }

        private void FillForm(DbConnectionConfig config_to_fill = null)
        {
            DbConnectionConfig config = config_to_fill != null ? config_to_fill : this.curr_config;

            this.txtBranch.Text = config.branch;
            this.cbDepcod.Text = config.depcod;
            this.txtServerName.Text = config.servername;
            this.txtDbName.Text = config.dbname;
            this.numPort.Text = config.port.ToString();
            this.txtUserId.Text = config.uid;
            this.txtPwd.Text = config.passwordhash.Decrypted();
            this.txtConfPwd.Text = config.passwordhash.Decrypted();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.FormFreeze = true;
            this.curr_config.db_prefix = LocalDbHelper.GetDbPrefix(this.main_form.working_express_db);
            LoadingForm loading = new LoadingForm();
            var context = this;
            loading.ShowCenterParent(context);

            if (this.txtPwd.Text != this.txtConfPwd.Text)
            {
                loading.Close();
                XMessageBox.Show(this.main_form.GetMessage("0002"), "", MessageBoxButtons.OK, XMessageBoxIcon.Stop, this.main_form.c_info);
                this.FormFreeze = false;
                this.txtConfPwd.Focus();
                return;
            }

            //bool isConnected = false;
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                conn_result = this.curr_config.TestMysqlDbConnection(this.main_form);
            };
            worker.RunWorkerCompleted += delegate
            {
                if (conn_result.is_connected)
                {
                    if (this.curr_config.Save(this.main_form.working_express_db) == true)
                    {
                        this.main_form.islog.ConfigMysqlConnection(this.curr_config.servername, this.curr_config.dbname).Save();
                        loading.Close();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    loading.Close();
                }
                else
                {
                    if(conn_result.connection_code == MYSQL_CONNECTION.UNKNOW_DATABASE)
                    {
                        loading.ShowCenterParent(context);
                        if(XMessageBox.Show(conn_result.err_message, "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                        {
                            MySqlCreateResult create_result = new MySqlCreateResult { is_success = false, err_message = string.Empty };
                            BackgroundWorker wk = new BackgroundWorker();
                            wk.DoWork += delegate
                            {
                                create_result = this.CreateNewMysqlDB(this.curr_config);
                            };
                            wk.RunWorkerCompleted += delegate
                            {
                                if (create_result.is_success)
                                {
                                    // Create new MySQL DB success.
                                    this.main_form.islog.CreateMysqlDb(this.curr_config.servername, this.curr_config.dbname).Save();

                                    loading.Close();
                                    if (this.curr_config.Save(this.main_form.working_express_db) == true)
                                    {
                                        this.main_form.islog.ConfigMysqlConnection(this.curr_config.servername, this.curr_config.dbname).Save();
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    loading.Close();
                                    XMessageBox.Show(create_result.err_message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                                }
                            };
                            wk.RunWorkerAsync();
                        }
                        else
                        {
                            loading.Close();
                        }
                    }
                    else
                    {
                        if (loading.Visible)
                        {
                            loading.Close();
                        }
                        XMessageBox.Show(conn_result.err_message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    }
                    
                    this.FormFreeze = false;
                    this.txtServerName.Focus();
                }
            };
            worker.RunWorkerAsync();
        }

        private MySqlCreateResult CreateNewMysqlDB(DbConnectionConfig local_config)
        {
            MySqlCreateResult create_result = new MySqlCreateResult { is_success = false, err_message = string.Empty };

            var conn_info = "Server=" + local_config.servername + ";Port=" + local_config.port.ToString() + ";Uid=" + local_config.uid + ";Pwd=" + local_config.passwordhash.Decrypted() + ";Character Set=utf8";

            MySqlConnection conn = new MySqlConnection(conn_info);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "` DEFAULT CHARACTER SET utf8", conn);
                cmd.ExecuteNonQuery();

                // DBVer Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`dbver` ";
                cmd.CommandText += "(`id` INT(7) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`version` VARCHAR(15) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Settings Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`settings` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`orgname` VARCHAR(60) NOT NULL DEFAULT '',";
                cmd.CommandText += "`prdstart` DATE NULL,";
                cmd.CommandText += "`prdend` DATE NULL,";
                cmd.CommandText += "`shiftprintmet` VARCHAR(1) NOT NULL DEFAULT '0' COMMENT '0 = not stricted, 1 = printed before authorize, 2 = authorized before print',";
                cmd.CommandText += "`shiftauthlev` INT(1) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`dayprintmet` VARCHAR(1) NOT NULL DEFAULT '0' COMMENT '0 = not stricted, 1 = printed before authorize, 2 = authorized before print',";
                cmd.CommandText += "`dayauthlev` INT(1) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,";
                cmd.CommandText += "PRIMARY KEY (`id`)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Istab Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`istab` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`tabtyp` VARCHAR(2) NOT NULL DEFAULT '' COMMENT '01 = deduct cause',";
                cmd.CommandText += "`typcod` VARCHAR(4) NOT NULL DEFAULT '',";
                cmd.CommandText += "`shortnam` VARCHAR(15) NULL,";
                cmd.CommandText += "`shortnam2` VARCHAR(15) NULL,";
                cmd.CommandText += "`typdes` VARCHAR(50) NULL,";
                cmd.CommandText += "`typdes2` VARCHAR(50) NULL,";
                cmd.CommandText += "`is_shiftsales` TINYINT(1) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`is_dayend` TINYINT(1) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-istab` (`tabtyp` ASC, `typcod` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Shift Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`shift` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`seq` INT(3) NOT NULL,";
                cmd.CommandText += "`name` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "`description` VARCHAR(50) NULL,";
                cmd.CommandText += "`starttime` TIME NOT NULL,";
                cmd.CommandText += "`endtime` TIME NOT NULL,";
                cmd.CommandText += "`remark` VARCHAR(50) NULL,";
                cmd.CommandText += "`saiprefix` VARCHAR(2) NOT NULL DEFAULT '',";
                cmd.CommandText += "`shsprefix` VARCHAR(2) NOT NULL DEFAULT '',";
                cmd.CommandText += "`sivprefix` VARCHAR(2) NOT NULL DEFAULT '',";
                cmd.CommandText += "`paeprefix` VARCHAR(2) NOT NULL DEFAULT '',";
                cmd.CommandText += "`phpprefix` VARCHAR(2) NOT NULL DEFAULT '',";
                cmd.CommandText += "`prrprefix` VARCHAR(2) NOT NULL DEFAULT '',";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-shift-name` (`name` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Tanksetup Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`tanksetup` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`startdate` DATE NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY(`id`)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Tank Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`tank` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`name` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "`description` VARCHAR(50) NULL,";
                cmd.CommandText += "`remark` VARCHAR(50) NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "`tanksetup_id` INT(11) NOT NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-tank-name` (`tanksetup_id` ASC, `name` ASC),";
                cmd.CommandText += "INDEX `ndx-tank-tanksetup_id` (`tanksetup_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk-tank-tanksetup_id` FOREIGN KEY (`tanksetup_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`tanksetup` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Stmas Table
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.dbname + "`.`stmas` ";
                //cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                //cmd.CommandText += "`name` VARCHAR(20) NOT NULL,";
                //cmd.CommandText += "`description` VARCHAR(50) NULL,";
                //cmd.CommandText += "`remark` VARCHAR(50) NULL,";
                //cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                //cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                //cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                //cmd.CommandText += "`chgtime` DATETIME NULL,";
                //cmd.CommandText += "PRIMARY KEY (`id`),";
                //cmd.CommandText += "UNIQUE INDEX `unq - stmas - name` (`name` ASC)) ";
                //cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                //cmd.ExecuteNonQuery();

                // Shiftsales Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`shiftsales` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`saldat` DATE NOT NULL,";
                cmd.CommandText += "`closed` TINYINT(1) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`shift_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "`apprby` VARCHAR(20) NULL,";
                cmd.CommandText += "`apprtime` DATETIME NULL,";
                cmd.CommandText += "`prnby` VARCHAR(20) NULL,";
                cmd.CommandText += "`prntime` DATETIME NULL,";
                cmd.CommandText += "`prncnt` INT(7) NOT NULL DEFAULT 0,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "INDEX `ndx-shiftsales-shift_id` (`shift_id` ASC),";
                cmd.CommandText += "UNIQUE INDEX `unq-shiftsales` (`saldat` ASC, `shift_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk-shiftsales-shift_id` FOREIGN KEY (`shift_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`shift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Section Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`section` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`name` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "`loccod` VARCHAR(4) NOT NULL DEFAULT '',";
                cmd.CommandText += "`stkcod` VARCHAR(40) NOT NULL DEFAULT '',";
                cmd.CommandText += "`stkdes` VARCHAR(100) NOT NULL DEFAULT '',";
                cmd.CommandText += "`capacity` DECIMAL(14,2) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`begacc` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`begtak` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`begdif` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`tank_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "INDEX `ndx-section-tank_id` (`tank_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk-section-tank_id` FOREIGN KEY (`tank_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`tank` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Pricelist Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`pricelist` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`date` DATE NOT NULL,";
                cmd.CommandText += "`stkcod` VARCHAR(40) NOT NULL DEFAULT '',";
                cmd.CommandText += "`unitpr` DECIMAL(9, 2) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Nozzle Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`nozzle` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`name` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "`description` VARCHAR(50) NULL,";
                cmd.CommandText += "`remark` VARCHAR(50) NULL,";
                cmd.CommandText += "`isactive` TINYINT(1) NOT NULL DEFAULT 1,";
                cmd.CommandText += "`section_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-nozzle-name` (`name` ASC, `section_id` ASC),";
                cmd.CommandText += "INDEX `ndx-nozzle-section_id` (`section_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk-nozzle-section_id` FOREIGN KEY (`section_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Shiftsttak Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`shiftsttak` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`takdat` DATE NOT NULL,";
                cmd.CommandText += "`qty` DECIMAL(15, 2) NOT NULL DEFAULT - 1,";
                cmd.CommandText += "`shiftsales_id` INT(11) NOT NULL,";
                cmd.CommandText += "`section_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "INDEX `ndx-sttak-section_id` (`section_id` ASC),";
                cmd.CommandText += "INDEX `ndx-sttak-shiftsales_id` (`shiftsales_id` ASC),";
                cmd.CommandText += "UNIQUE INDEX `unq-sttak` (`shiftsales_id` ASC, `section_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk-sttak-section_id` FOREIGN KEY (`section_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk-sttak-shiftsales_id` FOREIGN KEY (`shiftsales_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`shiftsales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Salessummary Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`salessummary` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`saldat` DATE NOT NULL,";
                cmd.CommandText += "`stkcod` VARCHAR(40) NOT NULL DEFAULT '',";
                cmd.CommandText += "`dtest` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`ddisc` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`purvat` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`pricelist_id` INT(11) NOT NULL,";
                cmd.CommandText += "`shiftsales_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-salessummary` (`shiftsales_id` ASC, `stkcod` ASC),";
                cmd.CommandText += "INDEX `ndx-salessummary-pricelist_id` (`pricelist_id` ASC),";
                cmd.CommandText += "INDEX `ndx-salessummary-shiftsales_id` (`shiftsales_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk-salessummary-pricelist_id` FOREIGN KEY (`pricelist_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`pricelist` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk-salessummary-shiftsales_id` FOREIGN KEY (`shiftsales_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`shiftsales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Saleshistory Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`saleshistory` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`saldat` DATE NOT NULL,";
                cmd.CommandText += "`mitbeg` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`mitend` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`salqty` DECIMAL(14, 2) NOT NULL,";
                //cmd.CommandText += "`salval` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`nozzle_id` INT(11) NOT NULL,";
                cmd.CommandText += "`salessummary_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-saleshistory` (`salessummary_id` ASC, `nozzle_id` ASC),";
                cmd.CommandText += "INDEX `ndx-saleshistory-nozzle_id` (`nozzle_id` ASC),";
                cmd.CommandText += "INDEX `ndx - saleshistory - salessummary_id` (`salessummary_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk - saleshistory - nozzle_id` FOREIGN KEY (`nozzle_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`nozzle` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk - saleshistory - salessummary_id` FOREIGN KEY (`salessummary_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`salessummary` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Dayend Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`dayend` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`saldat` DATE NOT NULL,";
                cmd.CommandText += "`stkcod` VARCHAR(40) NOT NULL DEFAULT '',";
                //cmd.CommandText += "`begbal` DECIMAL(14, 2) NOT NULL,";
                //cmd.CommandText += "`begdif` DECIMAL(14, 2) NOT NULL,";
                //cmd.CommandText += "`rcvqty` DECIMAL(14, 2) NOT NULL,";
                //cmd.CommandText += "`salqty` DECIMAL(14, 2) NOT NULL,";
                //cmd.CommandText += "`difqty` DECIMAL(14, 2) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "`apprby` VARCHAR(20) NULL,";
                cmd.CommandText += "`apprtime` DATETIME NULL,";
                cmd.CommandText += "`prnby` VARCHAR(20) NULL,";
                cmd.CommandText += "`prntime` DATETIME NULL,";
                cmd.CommandText += "`prncnt` INT(7) NOT NULL DEFAULT 0,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "UNIQUE INDEX `unq-dayend-saldat` (`saldat` ASC, `stkcod` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Daysttak Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`daysttak` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`takqty` DECIMAL(15, 2) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`begbal` DECIMAL(15, 2) NOT NULL DEFAULT 0,"; // From previous daysttak.takqty
                cmd.CommandText += "`begdif` DECIMAL(15, 2) NOT NULL DEFAULT 0,"; // From previous daysttak [ begdif + (begbal + rcvqty - salqty)]
                cmd.CommandText += "`rcvqty` DECIMAL(15, 2) NOT NULL DEFAULT 0,"; // Retrieve sum of stcrd.xtrnqty from express in current date
                cmd.CommandText += "`salqty` DECIMAL(15, 2) NOT NULL DEFAULT 0,"; // Sum of saleshistory.salqty in current date
                // difqty in current date calculate from  [ takqty - (begbal + rcvqty - salqty) ]
                // accbal in current date calculate from  [ section.begacc + ((all previous daysttak.rcvqty) + rcvqty) - ((all previous daysttak.salqty) + salqty) ]
                cmd.CommandText += "`dayend_id` INT(11) NOT NULL,";
                cmd.CommandText += "`section_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "INDEX `ndx - daysttak - section_id` (`section_id` ASC),";
                cmd.CommandText += "INDEX `ndx - daysttak - dayend_id` (`dayend_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk - daysttak - section_id` FOREIGN KEY (`section_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk - daysttak - dayend_id` FOREIGN KEY (`dayend_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`dayend` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Dayaccbal Table
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.dbname + "`.`dayaccbal` ";
                //cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                //cmd.CommandText += "`rcvqty` DECIMAL(15, 2) NOT NULL DEFAULT 0,";
                //cmd.CommandText += "`accqty` DECIMAL(15, 2) NOT NULL DEFAULT 0,";
                //cmd.CommandText += "`difqty` DECIMAL(15, 2) NOT NULL DEFAULT 0,";
                //cmd.CommandText += "`dayend_id` INT(11) NOT NULL,";
                //cmd.CommandText += "`section_id` INT(11) NOT NULL,";
                //cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                //cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                //cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                //cmd.CommandText += "`chgtime` DATETIME NULL,";
                //cmd.CommandText += "PRIMARY KEY (`id`),";
                //cmd.CommandText += "INDEX `ndx - daysttak - section_id` (`section_id` ASC),";
                //cmd.CommandText += "INDEX `ndx - daysttak - dayend_id` (`dayend_id` ASC),";
                //cmd.CommandText += "CONSTRAINT `fk - daysttak - section_id` FOREIGN KEY (`section_id`) REFERENCES `" + local_config.dbname + "`.`section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                //cmd.CommandText += "CONSTRAINT `fk - daysttak - dayend_id` FOREIGN KEY (`dayend_id`) REFERENCES `" + local_config.dbname + "`.`dayend` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                //cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                //cmd.ExecuteNonQuery();

                // Dother Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + local_config.db_prefix + "_" + local_config.dbname + "`.`dother` ";
                cmd.CommandText += "(`id` INT(11) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`qty` DECIMAL(14,2) NOT NULL DEFAULT 0,";
                cmd.CommandText += "`istab_id` INT(11) NOT NULL,";
                cmd.CommandText += "`salessummary_id` INT(11) NULL,";
                cmd.CommandText += "`dayend_id` INT(11) NULL,";
                cmd.CommandText += "`nozzle_id` INT(11) NULL,";
                cmd.CommandText += "`section_id` INT(11) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL DEFAULT '',";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY (`id`),";
                cmd.CommandText += "INDEX `fk_dother_istab1_idx` (`istab_id` ASC),";
                cmd.CommandText += "INDEX `fk_dother_salessummary1_idx` (`salessummary_id` ASC),";
                cmd.CommandText += "INDEX `fk_dother_dayend1_idx` (`dayend_id` ASC),";
                cmd.CommandText += "INDEX `fk_dother_nozzle_id` (`nozzle_id` ASC),";
                cmd.CommandText += "INDEX `fk_dother_section_id` (`section_id` ASC),";
                cmd.CommandText += "CONSTRAINT `fk_dother_istab1` FOREIGN KEY (`istab_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`istab` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk_dother_salessummary1` FOREIGN KEY (`salessummary_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`salessummary` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk_dother_dayend1` FOREIGN KEY (`dayend_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`dayend` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk_dother_nozzle` FOREIGN KEY (`nozzle_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`nozzle` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,";
                cmd.CommandText += "CONSTRAINT `fk_dother_section` FOREIGN KEY (`section_id`) REFERENCES `" + local_config.db_prefix + "_" + local_config.dbname + "`.`section` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO `" + local_config.db_prefix + "_" + local_config.dbname + "`.`dbver` (`version`) VALUES ('1.0.0.0')";
                cmd.ExecuteNonQuery();

                IsprdDbf isprd = DbfTable.Isprd(this.main_form.working_express_db).ToIsprd();
                DateTime start_date = isprd.beg1.HasValue ? isprd.beg1.Value : DateTime.Parse(DateTime.Now.ToString("yyyy", CultureInfo.GetCultureInfo("en-US")) + "-01-01", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None);
                DateTime end_date = isprd.end12.HasValue ? isprd.end12.Value : DateTime.Parse(DateTime.Now.ToString("yyyy", CultureInfo.GetCultureInfo("en-US")) + "-01-01", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None).AddMonths(11).AddDays(30);

                cmd.CommandText = "INSERT INTO `" + local_config.db_prefix + "_" + local_config.dbname + "`.`settings` (`orgname`,`prdstart`,`prdend`,`shiftprintmet`,`shiftauthlev`,`dayprintmet`,`dayauthlev`,`chgby`,`chgtime`) VALUES ('','" + start_date.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) + "','" + end_date.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-US")) + "','0',0,'0',0,NULL,NULL)";
                cmd.ExecuteNonQuery();

                create_result.is_success = true;

                // ** Upgrade DB Version here ** //

            }
            catch (MySqlException ex)
            {
                create_result.is_success = false;
                create_result.err_message = ex.Message;
            }
            catch (Exception ex)
            {
                create_result.is_success = false;
                create_result.err_message = ex.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }

            return create_result;
        }

        private void txtServerName_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.servername = ((TextBox)sender).Text.Trim();
        }

        private void txtDbName_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.dbname = ((TextBox)sender).Text.Trim();
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            this.curr_config.port = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.uid = ((TextBox)sender).Text.Trim();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.passwordhash = ((TextBox)sender).Text.Trim().Encrypted();
        }

        private void txtBranch_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.branch = ((TextBox)sender).Text.Trim();
        }

        private void cbDepcod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.curr_config.depcod = ((ComboBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (!(this.btnSave.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.1.html#db-config");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDefaultPort_Click(object sender, EventArgs e)
        {
            this.numPort.Value = 3306;
        }
    }
}
