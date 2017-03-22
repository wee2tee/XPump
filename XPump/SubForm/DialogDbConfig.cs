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

namespace XPump.SubForm
{
    public partial class DialogDbConfig : Form
    {
        //private LocalConfig localConfig;
        private MainForm main_form;
        private LocalDb localDb;
        private LocalConfig curr_config;
        private LocalConfig tmp_config;
        private bool FormFreeze
        {
            get
            {
                return this.txtServerName.Enabled;
            }
            set
            {
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

        public DialogDbConfig(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogDbConfig_Load(object sender, EventArgs e)
        {
            this.FormFreeze = false;
            //this.DialogResult = DialogResult.Cancel;
            this.curr_config = this.LoadConfig();
            this.FillForm();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if(MessageBox.Show("ข้อมูลที่ท่านกำลังแก้ไขจะไม่ถูกบันทึก, ยืนยันทำต่อ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        private LocalConfig LoadConfig()
        {
            return new LocalDb(this.main_form.working_express_db).LocalConfig;
        }

        private void FillForm(LocalConfig config_to_fill = null)
        {
            LocalConfig config = config_to_fill != null ? config_to_fill : this.curr_config;

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
            LoadingForm loading = new LoadingForm();
            loading.ShowCenterParent(this);

            if (this.txtPwd.Text != this.txtConfPwd.Text)
            {
                loading.Close();
                MessageBox.Show("กรุณายืนยันรหัสผ่าน(Confirm Password)ให้ถูกต้อง", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.FormFreeze = false;
                this.txtConfPwd.Focus();
                return;
            }

            //bool isConnected = false;
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                conn_result = this.curr_config.TestMysqlConnection();
            };
            worker.RunWorkerCompleted += delegate
            {
                loading.Close();
                if (conn_result.is_connected)
                {
                    if (this.curr_config.Save(this.main_form.working_express_db) == true)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    if(conn_result.connection_code == MYSQL_CONNECTION.UNKNOW_DATABASE)
                    {
                        if(MessageBox.Show(conn_result.err_message + " ต้องการสร้างฐานข้อมูลดังกล่าวขึ้นมาใหม่หรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            var conn_info = "Server=" + this.curr_config.servername + ";Port=" + this.curr_config.port.ToString() + ";Uid=" + this.curr_config.uid + ";Pwd=" + this.curr_config.passwordhash.Decrypted();

                            try
                            {
                                using (MySqlConnection conn = new MySqlConnection())
                                {
                                    conn.ConnectionString = conn_info;
                                    conn.Open();
                                    conn_result.is_connected = true;
                                    conn_result.connection_code = MYSQL_CONNECTION.CONNECTED;
                                }
                            }
                            catch(MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(conn_result.err_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    this.FormFreeze = false;
                    this.txtServerName.Focus();
                }
            };
            worker.RunWorkerAsync();
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
