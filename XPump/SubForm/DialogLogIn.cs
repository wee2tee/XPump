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
            if (!DbfTable.IsSecureFileExist("scuser.dbf"))
            {
                XMessageBox.Show("ค้นหาแฟ้ม Scuser.dbf ไม่พบ, อาจเป็นเพราะท่านติดตั้งโปรแกรมไว้ไม่ถูกที่ โปรแกรมนี้จะต้องถูกติดตั้งภายใต้โฟลเดอร์ของโปรแกรมเอ็กซ์เพรสเท่านั้น", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }

            LoginStatus login_result = ValidateUser(this.txtUserID.Text.Trim(), this.txtPassword.Text.Trim());

            if (login_result != null && login_result.result == true)
            {
                this.main_form.loged_in_status = login_result;
                this.main_form.islog.LoginSuccess(this.main_form.loged_in_status.loged_in_user_name).Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.main_form.islog.LoginFail(this.txtUserID.Text.Trim(), login_result.err_message).Save();
                XMessageBox.Show(login_result.err_message, "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.txtUserID.Focus();
                this.txtPassword.Text = string.Empty;
            }
        }

        // VALIDATE USER : Returning (bool is_valid_user, string err_message)
        public static LoginStatus ValidateUser(string user_name, string password)
        {
            // VALIDATE LOG-IN USER
            var enc_pass = string.Empty;
            for (int i = 0; i < password.Trim().Length; i++)
            {
                enc_pass += ((char)(password.ToCharArray()[i] ^ ((char)'a'))).ToString();
            }
            for (int i = enc_pass.Length; i < 8; i++)
            {
                enc_pass += "A";
            }

            var validating_user = DbfTable.Scuser().ToScuserList()
                                .Where(u => u.rectyp == "U")
                                .Where(u => u.reccod.Trim() == user_name)
                                .Where(u => u.userpwd.Trim() == enc_pass)
                                .FirstOrDefault();

            var scacclv = DbfTable.Scacclv().ToScacclvList().ToList();

            if(validating_user != null)
            {
                bool is_secure = validating_user.secure == "1" ? true : false;

                if(validating_user.status == "X")
                {
                    return new LoginStatus { result = false, loged_in_user_name = null, loged_in_user_group = null, is_secure = is_secure, err_message = "ถูกกำหนดสถานะห้ามใช้งาน", loged_in_user_level = 0, language = UILANGUAGE.THA };
                }
                else
                {
                    return new LoginStatus { result = true, loged_in_user_name = user_name, loged_in_user_group = validating_user.connectgrp, is_secure = is_secure, err_message = string.Empty, loged_in_user_level = Convert.ToInt32(validating_user.authlev), language = (validating_user.language != null && validating_user.language == "E" ? UILANGUAGE.ENG : UILANGUAGE.THA) };
                }
            }
            else
            {
                return new LoginStatus { result = false, loged_in_user_name = null, loged_in_user_group = null, is_secure = false, err_message = "รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้อง", loged_in_user_level = 0, language = UILANGUAGE.THA };
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (this.txtPassword.Focused)
                {
                    this.btnOK.PerformClick();
                    return true;
                }

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

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.1.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtUserID_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }
    }

    public class LoginStatus
    {
        public bool result { get; set; }
        public string loged_in_user_name { get; set; }
        public string loged_in_user_group { get; set; }
        public int loged_in_user_level { get; set; }
        public UILANGUAGE language { get; set; }
        public bool is_secure { get; set; }
        public string err_message { get; set; }
    }
}
