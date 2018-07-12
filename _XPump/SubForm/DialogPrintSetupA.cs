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
    public partial class DialogPrintSetupA : Form
    {
        public PRINT_OUTPUT output;

        public DialogPrintSetupA()
        {
            InitializeComponent();
        }

        private void DialogPrintSetupA_Load(object sender, EventArgs e)
        {
            this.rdScreen.Checked = true;
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
