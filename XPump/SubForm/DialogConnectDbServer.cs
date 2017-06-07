using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;
using MySql.Data.MySqlClient;

namespace XPump.SubForm
{
    public partial class DialogConnectDbServer : Form
    {
        private MainForm main_form;
        private LocalSecureDbConfig localSecureDb;
        private SecureDbConnectionConfig curr_config;
        private SecureDbConnectionConfig tmp_config;
        private bool FormFreeze
        {
            get
            {
                return !this.txtServerName.Enabled;
            }
            set
            {
                this.txtServerName.Enabled = !value;
                this.numPort.Enabled = !value;
                this.btnDefaultPort.Enabled = !value;
                this.txtUserId.Enabled = !value;
                this.txtPwd.Enabled = !value;
                this.txtConfPwd.Enabled = !value;
                this.btnSave.Enabled = !value;
                this.btnCancel.Enabled = !value;
            }
        }

        public DialogConnectDbServer(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogConnectDbServer_Load(object sender, EventArgs e)
        {
            this.FormFreeze = true;
            this.curr_config = this.LoadConfig();
            this.FillForm();
            this.FormFreeze = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (XMessageBox.Show("ข้อมูลที่ท่านกำลังแก้ไขจะไม่ถูกบันทึก, ยืนยันทำต่อ?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        private void FillForm(SecureDbConnectionConfig config_to_fill = null)
        {
            SecureDbConnectionConfig config = config_to_fill != null ? config_to_fill : this.curr_config;

            this.txtServerName.Text = config.servername;
            this.numPort.Value = Convert.ToDecimal(config.port);
            this.txtUserId.Text = config.uid;
            this.txtPwd.Text = config.passwordhash.Decrypted();
            this.txtConfPwd.Text = config.passwordhash.Decrypted();
        }

        private SecureDbConnectionConfig LoadConfig()
        {
            return new LocalSecureDbConfig().ConfigValue;
        }

        private void txtServerName_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.servername = ((TextBox)sender).Text.Trim();
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            this.curr_config.port = Convert.ToInt32(((NumericUpDown)sender).Value);
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.uid = ((TextBox)sender).Text;
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            this.curr_config.passwordhash = ((TextBox)sender).Text.Encrypted();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.curr_config.servername.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาป้อนชื่อเซิร์ฟเวอร์ MySQL", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.txtServerName.Focus();
                return;
            }
            if(this.curr_config.uid.Trim().Length == 0)
            {
                XMessageBox.Show("กรุณาป้อนรหัสผู้ใช้", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.txtUserId.Focus();
                return;
            }
            if(this.txtPwd.Text != this.txtConfPwd.Text)
            {
                XMessageBox.Show("กรุณายืนยันรหัสผ่านให้ถูกต้อง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.txtConfPwd.Focus();
                this.txtConfPwd.SelectionStart = 0;
                this.txtConfPwd.SelectionLength = this.txtConfPwd.Text.Length;
                return;
            }

            this.FormFreeze = true;
            LoadingForm loading = new LoadingForm();
            loading.ShowCenterParent(this);
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                conn_result = this.curr_config.TestMysqlConnection();
            };
            worker.RunWorkerCompleted += delegate
            {
                if (conn_result.is_connected)
                {
                    var create_secure_db_result = this.CreateNewMysqlSecureDB(this.curr_config);
                    if (create_secure_db_result.is_success)
                    {
                        loading.Close();
                        if (this.curr_config.Save())
                        {
                            this.FormFreeze = false;
                            this.main_form.secure_db_config = this.curr_config;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            this.FormFreeze = false;
                        }
                    }
                    else
                    {
                        loading.Close();
                        this.FormFreeze = false;
                        XMessageBox.Show(create_secure_db_result.err_message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    }
                }
                else
                {
                    loading.Close();
                    this.FormFreeze = false;
                    XMessageBox.Show(conn_result.err_message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            };
            worker.RunWorkerAsync();
        }

        private MySqlCreateResult CreateNewMysqlSecureDB(SecureDbConnectionConfig config)
        {
            MySqlCreateResult create_result = new MySqlCreateResult { is_success = false, err_message = string.Empty };

            var conn_info = "Server=" + config.servername + ";Port=" + config.port.ToString() + ";Uid=" + config.uid + ";Pwd=" + config.passwordhash.Decrypted();

            MySqlConnection conn = new MySqlConnection(conn_info);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS xpumpsecure", conn);
                cmd.ExecuteNonQuery();

                //// DBVer Table
                //cmd.CommandText = "CREATE TABLE IF NOT EXISTS `XPumpSecure`.`dbver` ";
                //cmd.CommandText += "(`id` INT(7) NOT NULL AUTO_INCREMENT,";
                //cmd.CommandText += "`version` VARCHAR(15) NOT NULL DEFAULT '',";
                //cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                //cmd.CommandText += "`chgtime` TIMESTAMP NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,";
                //cmd.CommandText += "PRIMARY KEY (`id`)) ";
                //cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                //cmd.ExecuteNonQuery();

                // Islog Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `xpumpsecure`.`islog` ";
                cmd.CommandText += "(`id` INT(15) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`logcode` VARCHAR(10) NOT NULL,";
                cmd.CommandText += "`expressdata` VARCHAR(50) NULL,";
                cmd.CommandText += "`xpumpdata` VARCHAR(50) NULL,";
                cmd.CommandText += "`xpumpuser` VARCHAR(50) NULL,";
                cmd.CommandText += "`module` VARCHAR(30) NULL,";
                //cmd.CommandText += "`afftable` VARCHAR(30) NULL,";
                //cmd.CommandText += "`affid` VARCHAR(255) NULL,";
                cmd.CommandText += "`docnum` VARCHAR(50) NULL,";
                cmd.CommandText += "`description` VARCHAR(200) NULL,";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`username` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "PRIMARY KEY(`id`),";
                cmd.CommandText += "INDEX `ndx-islog-logcode` (`logcode` ASC),";
                cmd.CommandText += "INDEX `ndx-islog-module` (`module` ASC),";
                //cmd.CommandText += "INDEX `ndx-islog-afftable` (`afftable` ASC),";
                cmd.CommandText += "INDEX `ndx-islog-username` (`username` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Affdata
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `xpumpsecure`.`affdata` ";
                cmd.CommandText += "(`id` INT(15) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`islog_id` INT(15) NOT NULL,";
                cmd.CommandText += "`afftable` VARCHAR(30) NOT NULL,";
                cmd.CommandText += "`affid` INT(7) NOT NULL,";
                cmd.CommandText += "PRIMARY KEY(`id`),";
                cmd.CommandText += "CONSTRAINT `fk-affdata-islog_id` FOREIGN KEY (`islog_id`) REFERENCES `xpumpsecure`.`islog` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }

            return create_result;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (!this.FormFreeze && !(this.btnSave.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDefaultPort_Click(object sender, EventArgs e)
        {
            this.numPort.Value = 3306m;
        }
    }
}
