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

            if (MessageBox.Show("ข้อมูลที่ท่านกำลังแก้ไขจะไม่ถูกบันทึก, ยืนยันทำต่อ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
            var test_connect = this.curr_config.TestMysqlConnection();

            if (test_connect.is_connected)
            {
                if (this.curr_config.Save())
                {
                    //MessageBox.Show("save secure success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(test_connect.err_message);
            }
        }
    }
}
