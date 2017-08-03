using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class DialogSimpleSearch : Form
    {
        public string keyword = string.Empty;
        private CultureInfo c_info = CultureInfo.GetCultureInfo("th-TH");

        public DialogSimpleSearch(CultureInfo c_info = null)
        {
            if(c_info != null)
            {
                this.c_info = c_info;
            }
            Thread.CurrentThread.CurrentUICulture = this.c_info;
            InitializeComponent();
        }

        public DialogSimpleSearch(string search_label, string initial_keyword, CultureInfo c_info = null)
            : this(c_info)
        {
            this.lblSearchLabel.Text = search_label;
            this.txtKeyword.Text = initial_keyword;
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            this.keyword = ((TextBox)sender).Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter && this.txtKeyword.Focused)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
