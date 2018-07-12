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
    public partial class DialogImportStmasConfirmReplace : Form
    {
        public enum CONFIRM_RESULT : int
        {
            SKIP_ONE = 1,
            SKIP_ALL = 2,
            REPLACE_ONE = 3,
            REPLACE_ALL = 4
        }

        public CONFIRM_RESULT confirm_result;
        private MainForm main_form;

        public DialogImportStmasConfirmReplace(MainForm main_form, string message = "")
        {
            InitializeComponent();
            this.lblMessage.Text = message;
            this.DialogResult = DialogResult.Cancel;
            this.main_form = main_form;
            //this.Parent = this.main_form;
        }

        private void DialogImportStmasConfirmReplace_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSkipOne_Click(object sender, EventArgs e)
        {
            this.confirm_result = CONFIRM_RESULT.SKIP_ONE;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSkipAll_Click(object sender, EventArgs e)
        {
            this.confirm_result = CONFIRM_RESULT.SKIP_ALL;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReplaceOne_Click(object sender, EventArgs e)
        {
            this.confirm_result = CONFIRM_RESULT.REPLACE_ONE;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            this.confirm_result = CONFIRM_RESULT.REPLACE_ALL;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
