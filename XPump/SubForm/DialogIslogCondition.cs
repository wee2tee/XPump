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
    public partial class DialogIslogCondition : Form
    {
        private MainForm main_form;
        public DateTime? logDateFrom = null;
        public DateTime? logDateTo = null;
        public string logCode = string.Empty;
        public string logData = string.Empty;
        public string logModule = string.Empty;
        public string logUserName = string.Empty;
        public PRINT_OUTPUT printOutput = PRINT_OUTPUT.SCREEN;
        private bool isPrint;
        private bool isFullCondition;

        public DialogIslogCondition(MainForm main_form, DateTime? ini_logdatefrom = null, DateTime? ini_logdateto = null, string ini_logcode = "", string ini_logdata = "", string ini_logmodul = "", string ini_loguser = "", bool is_print_purpose = false, bool is_full_condition = true)
        {
            this.main_form = main_form;
            this.logDateFrom = ini_logdatefrom;
            this.logDateTo = ini_logdateto;
            this.logCode = ini_logcode;
            this.logData = ini_logdata;
            this.logModule = ini_logmodul;
            this.logUserName = ini_loguser;
            this.isPrint = is_print_purpose;
            this.isFullCondition = is_full_condition;
            InitializeComponent();
        }

        private void DialogIslogCondition_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.chkAllDate;

            if (this.logDateFrom.HasValue)
            {
                this.chkAllDate.Checked = false;
                this.dtLogDateFrom._SelectedDate = this.logDateFrom;
                this.ActiveControl = this.dtLogDateFrom;
            }

            if (this.logDateTo.HasValue)
            {
                this.chkAllDate.Checked = false;
                this.dtLogDateTo._SelectedDate = this.logDateTo;
            }

            if (this.isFullCondition)
            {
                if (this.logCode.Trim().Length > 0)
                {
                    this.chkAllCode.Checked = false;
                    this.txtLogCode._Text = this.logCode;
                }

                if (this.logData.Trim().Length > 0)
                {
                    this.chkAllData.Checked = false;
                    this.txtLogData._Text = this.logData;
                }

                if (this.logModule.Trim().Length > 0)
                {
                    this.chkAllModule.Checked = false;
                    this.txtLogModule._Text = this.logModule;
                }

                if (this.logUserName.Trim().Length > 0)
                {
                    this.chkAllUser.Checked = false;
                    this.txtLogUser._Text = this.logUserName;
                }
            }
            else
            {
                this.chkAllCode.Enabled = false;
                this.chkAllModule.Enabled = false;
                this.chkAllData.Enabled = false;
                this.chkAllUser.Enabled = false;

                this.txtLogCode._Text = string.Empty;
                this.txtLogData._Text = string.Empty;
                this.txtLogModule._Text = string.Empty;
                this.txtLogUser._Text = string.Empty;
            }

            if (this.isPrint)
            {
                this.Text += "ในการพิมพ์รายงาน";
                this.panelPrintOutput.Visible = true;
                this.radPrinter.Enabled = true;
                this.radScreen.Enabled = true;
                this.radScreen.Checked = this.printOutput == PRINT_OUTPUT.SCREEN ? true : false;
            }

            if (!this.isPrint)
            {
                this.Height -= 50;
            }

        }

        private void dtLogDateFrom__SelectedDateChanged(object sender, EventArgs e)
        {
            this.logDateFrom = ((XDatePicker)sender)._SelectedDate;
        }

        private void dtLogDateTo__SelectedDateChanged(object sender, EventArgs e)
        {
            this.logDateTo = ((XDatePicker)sender)._SelectedDate;
        }

        private void txtLogCode__TextChanged(object sender, EventArgs e)
        {
            this.logCode = ((XTextEdit)sender)._Text;
        }

        private void txtLogData__TextChanged(object sender, EventArgs e)
        {
            this.logData = ((XTextEdit)sender)._Text;
        }

        private void txtLogModule__TextChanged(object sender, EventArgs e)
        {
            this.logModule = ((XTextEdit)sender)._Text;
        }

        private void txtLogUser__TextChanged(object sender, EventArgs e)
        {
            this.logUserName = ((XTextEdit)sender)._Text;
        }

        private void chkAllDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtLogDateFrom._SelectedDate = ((CheckBox)sender).Checked ? null : this.dtLogDateFrom._SelectedDate;
            this.dtLogDateFrom._ReadOnly = ((CheckBox)sender).Checked ? true : false;

            this.dtLogDateTo._SelectedDate = ((CheckBox)sender).Checked ? null : this.dtLogDateTo._SelectedDate;
            this.dtLogDateTo._ReadOnly = ((CheckBox)sender).Checked ? true : false;

            if (!((CheckBox)sender).Checked)
                this.dtLogDateFrom.Focus();
        }

        private void chkAllLog_CheckedChanged(object sender, EventArgs e)
        {
            this.txtLogCode._Text = ((CheckBox)sender).Checked ? string.Empty : this.txtLogCode._Text;
            this.txtLogCode._ReadOnly = ((CheckBox)sender).Checked ? true : false;

            if (!((CheckBox)sender).Checked)
                this.txtLogCode.Focus();
        }

        private void chkAllData_CheckedChanged(object sender, EventArgs e)
        {
            this.txtLogData._Text = ((CheckBox)sender).Checked ? string.Empty : this.txtLogData._Text;
            this.txtLogData._ReadOnly = ((CheckBox)sender).Checked ? true : false;

            if (!((CheckBox)sender).Checked)
                this.txtLogData.Focus();
        }

        private void chkAllModule_CheckedChanged(object sender, EventArgs e)
        {
            this.txtLogModule._Text = ((CheckBox)sender).Checked ? string.Empty : this.txtLogModule._Text;
            this.txtLogModule._ReadOnly = ((CheckBox)sender).Checked ? true : false;

            if (!((CheckBox)sender).Checked)
                this.txtLogModule.Focus();
        }

        private void chkAllUser_CheckedChanged(object sender, EventArgs e)
        {
            this.txtLogUser._Text = ((CheckBox)sender).Checked ? string.Empty : this.txtLogUser._Text;
            this.txtLogUser._ReadOnly = ((CheckBox)sender).Checked ? true : false;

            if (!((CheckBox)sender).Checked)
                this.txtLogUser.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.chkAllDate.Checked && (!this.logDateFrom.HasValue || !this.logDateTo.HasValue))
            {
                XMessageBox.Show(this.main_form.GetMessage("0025"), "", MessageBoxButtons.OK, XMessageBoxIcon.Stop, this.main_form.c_info);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void radScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                this.printOutput = PRINT_OUTPUT.SCREEN;
        }

        private void radPrinter_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                this.printOutput = PRINT_OUTPUT.PRINTER;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(!(this.btnOK.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    Console.WriteLine(" ==> active control is : " + this.ActiveControl.Name);
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F5 || keyData == (Keys.Alt | Keys.P))
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
