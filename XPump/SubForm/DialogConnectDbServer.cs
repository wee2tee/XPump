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

            this.curr_config.db_prefix = SecureDbHelper.GetDbPrefix();

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
                            this.AddScmodulData();
                            
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
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `" + config.db_prefix + "_xpumpsecure`", conn);
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

                // Scmodule Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + config.db_prefix + "_xpumpsecure`.`scmodul` ";
                cmd.CommandText += "(`id` INT(15) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`modcod` VARCHAR(50) NOT NULL,";
                cmd.CommandText += "`description` VARCHAR(100) NOT NULL DEFAULT '',";
                cmd.CommandText += "`description_en` VARCHAR(100) NOT NULL DEFAULT '',";
                cmd.CommandText += "`p_modcod` VARCHAR(50) NOT NULL DEFAULT 'ALLMENU',";
                cmd.CommandText += "PRIMARY KEY(`id`),";
                cmd.CommandText += "INDEX `ndx-scmodul-module_code` (`modcod` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Scacclv Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + config.db_prefix + "_xpumpsecure`.`scacclv` ";
                cmd.CommandText += "(`id` INT(15) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`username` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "`datacod` VARCHAR(50) NOT NULL,";
                cmd.CommandText += "`scmodul_id` INT(15) NOT NULL,";
                cmd.CommandText += "`read` VARCHAR(1) NOT NULL,";
                cmd.CommandText += "`add` VARCHAR(1) NOT NULL,";
                cmd.CommandText += "`edit` VARCHAR(1) NOT NULL,";
                cmd.CommandText += "`delete` VARCHAR(1) NOT NULL,";
                cmd.CommandText += "`print` VARCHAR(1) NOT NULL,";
                cmd.CommandText += "`approve` VARCHAR(1) NOT NULL,";
                cmd.CommandText += "`creby` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`chgby` VARCHAR(20) NULL,";
                cmd.CommandText += "`chgtime` DATETIME NULL,";
                cmd.CommandText += "PRIMARY KEY(`id`),";
                cmd.CommandText += "CONSTRAINT `fk-scacclv-scmodul_id` FOREIGN KEY (`scmodul_id`) REFERENCES `" + config.db_prefix + "_xpumpsecure`.`scmodul` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION, ";
                cmd.CommandText += "INDEX `ndx-scacclv-username` (`username` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Islog Table
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + config.db_prefix + "_xpumpsecure`.`islog` ";
                cmd.CommandText += "(`id` INT(15) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`logcode` VARCHAR(10) NOT NULL,";
                cmd.CommandText += "`expressdata` VARCHAR(50) NULL,";
                cmd.CommandText += "`xpumpdata` VARCHAR(50) NULL,";
                cmd.CommandText += "`xpumpuser` VARCHAR(50) NULL,";
                cmd.CommandText += "`modcod` VARCHAR(50) NULL,";
                //cmd.CommandText += "`afftable` VARCHAR(30) NULL,";
                //cmd.CommandText += "`affid` VARCHAR(255) NULL,";
                cmd.CommandText += "`docnum` VARCHAR(50) NULL,";
                cmd.CommandText += "`description` VARCHAR(200) NULL,";
                cmd.CommandText += "`cretime` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,";
                cmd.CommandText += "`username` VARCHAR(20) NOT NULL,";
                cmd.CommandText += "PRIMARY KEY(`id`),";
                cmd.CommandText += "INDEX `ndx-islog-logcode` (`logcode` ASC),";
                cmd.CommandText += "INDEX `ndx-islog-module_code` (`modcod` ASC),";
                //cmd.CommandText += "INDEX `ndx-islog-afftable` (`afftable` ASC),";
                cmd.CommandText += "INDEX `ndx-islog-username` (`username` ASC)) ";
                cmd.CommandText += "ENGINE = InnoDB DEFAULT CHARACTER SET = utf8";
                cmd.ExecuteNonQuery();

                // Affdata
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + config.db_prefix + "_xpumpsecure`.`affdata` ";
                cmd.CommandText += "(`id` INT(15) NOT NULL AUTO_INCREMENT,";
                cmd.CommandText += "`islog_id` INT(15) NOT NULL,";
                cmd.CommandText += "`afftable` VARCHAR(30) NOT NULL,";
                cmd.CommandText += "`affid` INT(7) NOT NULL,";
                cmd.CommandText += "PRIMARY KEY(`id`),";
                cmd.CommandText += "CONSTRAINT `fk-affdata-islog_id` FOREIGN KEY (`islog_id`) REFERENCES `" + config.db_prefix + "_xpumpsecure`.`islog` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION) ";
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

        private void AddScmodulData()
        {
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                try
                {
                    sec.scmodul.Add(new scmodul { modcod = "ALLMENU", p_modcod = "", description = "ทุกระบบ", description_en = "All Menu" });
                    sec.scmodul.Add(new scmodul { modcod = "1", p_modcod = "ALLMENU", description = "รายการประจำวัน", description_en = "Daily Transaction" });
                    sec.scmodul.Add(new scmodul { modcod = "11", p_modcod = "1", description = "บันทึกรายการประจำผลัด", description_en = "Shift Transaction" });
                    sec.scmodul.Add(new scmodul { modcod = "12", p_modcod = "1", description = "ปิดยอดขายประจำวัน", description_en = "Daily Summary" });
                    sec.scmodul.Add(new scmodul { modcod = "2", p_modcod = "ALLMENU", description = "เริ่มระบบ", description_en = "Setup" });
                    sec.scmodul.Add(new scmodul { modcod = "21", p_modcod = "2", description = "กำหนดสาขาสถานีบริการ", description_en = "Branch File" });
                    sec.scmodul.Add(new scmodul { modcod = "22", p_modcod = "2", description = "ตั้งค่าระบบ", description_en = "Main Configuration" });
                    sec.scmodul.Add(new scmodul { modcod = "23", p_modcod = "2", description = "กำหนดแท๊งค์เก็บน้ำมัน", description_en = "Tank Setup" });
                    sec.scmodul.Add(new scmodul { modcod = "24", p_modcod = "2", description = "กำหนดผลัดพนักงาน", description_en = "Shift File" });
                    sec.scmodul.Add(new scmodul { modcod = "25", p_modcod = "2", description = "ตารางข้อมูล", description_en = "Category Table" });
                    sec.scmodul.Add(new scmodul { modcod = "3", p_modcod = "ALLMENU", description = "อื่น ๆ", description_en = "Others" });
                    sec.scmodul.Add(new scmodul { modcod = "31", p_modcod = "3", description = "จัดการฐานข้อมูล", description_en = "Database Management" });
                    sec.scmodul.Add(new scmodul { modcod = "311", p_modcod = "31", description = "สำรองข้อมูล", description_en = "Backup Data" });
                    sec.scmodul.Add(new scmodul { modcod = "312", p_modcod = "31", description = "นำข้อมูลสำรองมาใช้", description_en = "Restore Data" });
                    sec.scmodul.Add(new scmodul { modcod = "32", p_modcod = "3", description = "ระบบความปลอดภัย", description_en = "Security Setup" });
                    sec.scmodul.Add(new scmodul { modcod = "321", p_modcod = "32", description = "กำหนดสิทธิ์ผู้ใช้งาน", description_en = "User Access Control" });
                    sec.scmodul.Add(new scmodul { modcod = "322", p_modcod = "32", description = "แฟ้มบันทึกเหตุการณ์ทำงาน", description_en = "Event Logging File" });
                    sec.scmodul.Add(new scmodul { modcod = "33", p_modcod = "3", description = "การประมวลผลสิ้นปี", description_en = "Year-End Processing" });
                    sec.scmodul.Add(new scmodul { modcod = "34", p_modcod = "3", description = "เปลี่ยนบริษัท", description_en = "Change Company" });
                    sec.SaveChanges();
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
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

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.1.html#db-server-config");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDefaultPort_Click(object sender, EventArgs e)
        {
            this.numPort.Value = 3306m;
        }
    }
}
