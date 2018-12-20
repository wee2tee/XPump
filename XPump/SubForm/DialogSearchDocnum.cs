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
    public partial class DialogSearchDocnum : Form
    {
        private string masked_text = string.Empty;
        public string keyword = string.Empty;

        public DialogSearchDocnum(string masked_text, string initial_keyword = "")
        {
            this.masked_text = masked_text;
            this.keyword = initial_keyword;
            InitializeComponent();
        }

        private void DialogSearchDocnum_Load(object sender, EventArgs e)
        {
            this.txtKeyword.Mask = this.masked_text;
            this.txtKeyword.Text = this.keyword;
        }

        private void DialogSearchDocnum_Shown(object sender, EventArgs e)
        {
            if(this.txtKeyword.Text.Trim().Length > 2)
            {
                this.txtKeyword.SelectionStart = 2;
                this.txtKeyword.SelectionLength = this.txtKeyword.Text.Length - 2;
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            this.keyword = ((MaskedTextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                this.btnGo.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
