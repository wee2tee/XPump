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
    public partial class DialogInlineSearch : Form
    {
        public string keyword = string.Empty;
        private string initial_keyword;

        public DialogInlineSearch()
        {
            InitializeComponent();
        }

        public DialogInlineSearch(string initial_keyword)
            : this()
        {
            this.initial_keyword = initial_keyword;
        }

        private void DialogInlineSearch_Load(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.initial_keyword;
            this.txtKeyword.SelectionStart = this.txtKeyword.Text.Length;
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            this.keyword = ((TextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                this.btnOK.PerformClick();
                return true;
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
