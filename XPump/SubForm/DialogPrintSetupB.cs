using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using CC;

namespace XPump.SubForm
{
    public partial class DialogPrintSetupB : Form
    {
        public PRINT_OUTPUT output;
        public DateTime selected_date;

        public DialogPrintSetupB()
        {
            InitializeComponent();
        }

        private void DialogPrintSetupB_Load(object sender, EventArgs e)
        {
            this.rdScreen.Checked = true;
            this.dtDate._SelectedDate = DateTime.Now;
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

        private void dtDate__SelectedDateChanged(object sender, EventArgs e)
        {
            if (((XDatePicker)sender)._SelectedDate.HasValue)
                this.selected_date = ((XDatePicker)sender)._SelectedDate.Value;
        }

        private void dtDate__Leave(object sender, EventArgs e)
        {
            if (!((XDatePicker)sender)._SelectedDate.HasValue)
            {
                ((XDatePicker)sender).SetDate(DateTime.Now);
            }
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
