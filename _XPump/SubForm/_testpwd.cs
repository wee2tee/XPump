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
    public partial class _testpwd : Form
    {
        public _testpwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.txtUid.Text.Trim().Length == 0 || this.txtPwd.Text.Trim().Length == 0)
            {
                XMessageBox.Show("Please fill user name/password");
                return;
            }


            var usr = DbfTable.Scuser().ToScuserList().Where(s => s.reccod.Trim() == this.txtUid.Text.Trim()).FirstOrDefault();
            if (usr != null)
            {
                var pass = this.txtPwd.Text.Trim();

                var enc_pass = string.Empty;
                for (int i = 0; i < pass.Length; i++)
                {
                    enc_pass += ((char)(pass.ToCharArray()[i] ^ ((char)'a'))).ToString();
                }
                for (int i = enc_pass.Length; i < 8; i++)
                {
                    enc_pass += "A";
                }

                this.lblEncPwd.Text = enc_pass;
            }
            else
            {
                XMessageBox.Show("User name not found!");
            }

        }
    }
}
