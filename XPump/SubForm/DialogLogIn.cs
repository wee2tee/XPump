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
            var x = DbfTable.Scuser().ToScuserList();

            this.main_form.logedin_user_name = "BIT90";
            this.DialogResult = DialogResult.OK;
            this.Close();
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
