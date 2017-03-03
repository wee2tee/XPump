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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogPrintSetupC : Form
    {
        public PRINT_OUTPUT output;
        private DateTime? initial_date;
        public DateTime? first_date_of_month;
        public DateTime? last_date_of_month;

        public DialogPrintSetupC(DateTime? initial_date = null)
        {
            InitializeComponent();
            this.initial_date = initial_date;
        }

        private void DialogPrintSetupC_Load(object sender, EventArgs e)
        {
            this.rdScreen.Select();

            if (this.initial_date.HasValue)
            {
                this.mskMonth.Text = this.initial_date.Value.ToString("MM", CultureInfo.CurrentCulture) + "/" + this.initial_date.Value.ToString("yyyy", CultureInfo.CurrentCulture);
            }
            else
            {
                this.mskMonth.Text = DateTime.Now.ToString("MM", CultureInfo.CurrentCulture) + "/" + DateTime.Now.ToString("yyyy", CultureInfo.CurrentCulture);
            }

            this.ActiveControl = this.mskMonth;
            this.mskMonth.SelectionStart = 0;
            this.mskMonth.SelectionLength = this.mskMonth.Text.Length;
        }

        private void dtMonth_TextChanged(object sender, EventArgs e)
        {
            var m = ((XMaskedTextEdit)sender).Text.Split('/')[0];
            var y = ((XMaskedTextEdit)sender).Text.Split('/')[1];

            if (y.Length < 4)
            {
                first_date_of_month = null;
                last_date_of_month = null;
                this.btnOK.Enabled = false;
            }

            DateTime test_parse;
            if(DateTime.TryParse(y + "-" + m + "-01", CultureInfo.CurrentCulture, DateTimeStyles.None, out test_parse))
            {
                this.first_date_of_month = new DateTime(test_parse.Year, test_parse.Month, 1);
                this.last_date_of_month = first_date_of_month.Value.AddMonths(1).AddDays(-1);
                this.btnOK.Enabled = true;
            }
            else
            {
                first_date_of_month = null;
                last_date_of_month = null;
                this.btnOK.Enabled = false;
            }
        }

        private void rdScreen_CheckedChanged(object sender, EventArgs e)
        {
            this.output = PRINT_OUTPUT.SCREEN;
        }

        private void rdPrinter_CheckedChanged(object sender, EventArgs e)
        {
            this.output = PRINT_OUTPUT.PRINTER;
        }

        private void rdFile_CheckedChanged(object sender, EventArgs e)
        {
            this.output = PRINT_OUTPUT.FILE;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (this.mskMonth.Focused)
                {
                    this.btnOK.PerformClick();
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
