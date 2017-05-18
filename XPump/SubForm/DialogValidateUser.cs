using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class DialogValidateUser : Form
    {
        private MainForm main_form;
        private int target_level;
        public LoginStatus validated_status;

        public DialogValidateUser(MainForm main_form, int target_level)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.target_level = target_level;
        }

        private void DialogValidateUser_Load(object sender, EventArgs e)
        {
            this.Text += " " + this.target_level.ToString();
            this.ActiveControl = this.txtUser;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.validated_status = DialogLogIn.ValidateUser(this.txtUser.Text, this.txtPwd.Text);
            if(this.validated_status.result == true)
            {
                if(this.validated_status.loged_in_user_level >= this.target_level)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ระดับอนุมัติของท่านไม่สามารถรับรองรายการได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtPwd.Text = string.Empty;
                    this.txtUser.Focus();
                }
            }
            else
            {
                MessageBox.Show(this.validated_status.err_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtPwd.Text = string.Empty;
                this.txtUser.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (txtUser.Focused)
                {
                    this.txtPwd.Focus();
                    return true;
                }

                if (txtPwd.Focused)
                {
                    this.btnOK.PerformClick();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }
    }
}
