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
    public partial class DialogLogIn : Form
    {
        private MainForm main_form;

        public DialogLogIn(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogLogIn_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtUserID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoginStatus login_result = ValidateUser(this.txtUserID.Text.Trim(), this.txtPassword.Text.Trim());

            if (login_result.result == true)
            {
                this.main_form.loged_in_status = login_result;
                this.main_form.islog.LoginSuccess(this.main_form.loged_in_status.loged_in_user_name).Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.main_form.islog.LoginFail(this.txtUserID.Text.Trim(), login_result.err_message).Save();
                MessageBox.Show(login_result.err_message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtUserID.Focus();
            }
        }

        // VALIDATE USER : Returning (bool is_valid_user, string err_message)
        public static LoginStatus ValidateUser(string user_name, string password)
        {
            // VALIDATE LOG-IN USER
            var validating_user = DbfTable.Scuser().ToScuserList().Where(u => u.rectyp == "U").Where(u => u.reccod == user_name).FirstOrDefault();

            var scacclv = DbfTable.Scacclv().ToScacclvList().ToList();

            if(validating_user != null)
            {
                bool is_secure = validating_user.secure == "1" ? true : false;

                if(validating_user.status == "X")
                {
                    return new LoginStatus { result = false, loged_in_user_name = null, loged_in_user_group = null, is_secure = is_secure, err_message = "ถูกกำหนดสถานะห้ามใช้งาน" };
                }
                else
                {
                    return new LoginStatus { result = true, loged_in_user_name = user_name, loged_in_user_group = validating_user.connectgrp, is_secure = is_secure, err_message = string.Empty };
                }
            }
            else
            {
                //return new LoginStatus { result = false, loged_in_user_name = null, loged_in_user_group = null, is_secure = false, err_message = "รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้อง" };
                return null;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(!(this.btnOK.Focused || this.btnCancel.Focused))
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

    public class LoginStatus
    {
        public bool result { get; set; }
        public string loged_in_user_name { get; set; }
        public string loged_in_user_group { get; set; }
        public bool is_secure { get; set; }
        public string err_message { get; set; }
    }
}
