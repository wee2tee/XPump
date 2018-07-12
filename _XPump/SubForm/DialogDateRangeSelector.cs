using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;

namespace XPump.SubForm
{
    public partial class DialogDateRangeSelector : Form
    {
        public DateTime? FromDate;
        public DateTime? ToDate;
        private MainForm main_form;
        private bool allow_null_fromdate;
        private bool allow_null_todate;
        private DateTime? initial_fromdate;
        private DateTime? initial_todate;

        public DialogDateRangeSelector(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        public DialogDateRangeSelector(MainForm main_form, bool allow_null_fromdate, bool allow_null_todate)
            : this(main_form)
        {
            this.allow_null_fromdate = allow_null_fromdate;
            this.allow_null_todate = allow_null_todate;
        }

        public DialogDateRangeSelector(MainForm main_form, bool allow_null_fromdate, bool allow_null_todate, DateTime init_fromdate, DateTime init_todate)
            : this(main_form, allow_null_fromdate, allow_null_todate)
        {
            this.initial_fromdate = init_fromdate;
            this.initial_todate = init_todate;
        }

        private void DialogDateRangeSelector_Load(object sender, EventArgs e)
        {
            if (!this.allow_null_fromdate)
            {
                if (this.initial_fromdate.HasValue)
                {
                    this.dtFromDate._SelectedDate = this.initial_fromdate.Value;
                }
                else
                {
                    string d2s = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH"));
                    DateTime first_date = DateTime.Now;
                    DateTime.TryParse(d2s.Substring(0, 8) + "01", CultureInfo.GetCultureInfo("th-TH"), DateTimeStyles.None, out first_date);

                    this.dtFromDate._SelectedDate = first_date;
                }
            }

            if (!this.allow_null_todate)
            {
                if (this.initial_todate.HasValue)
                {
                    this.dtToDate._SelectedDate = this.initial_todate.Value;
                }
                else
                {
                    string d2s = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH"));
                    DateTime last_date = DateTime.Now;
                    if(DateTime.TryParse(d2s.Substring(0,8) + "01", CultureInfo.GetCultureInfo("th-TH"), DateTimeStyles.None, out last_date) == true)
                    {
                        last_date = last_date.AddDays(-1);
                    }

                    this.dtToDate._SelectedDate = last_date;
                }
            }
        }

        private void dtFromDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.FromDate = ((XDatePicker)sender)._SelectedDate;
            this.ResetBtnOKState();
        }

        private void dtToDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.ToDate = ((XDatePicker)sender)._SelectedDate;
            this.ResetBtnOKState();
        }

        private void ResetBtnOKState()
        {
            if (!this.allow_null_fromdate && !this.allow_null_todate)
            {
                this.btnOK.Enabled = this.FromDate.HasValue && this.ToDate.HasValue ? true : false;
                return;
            }

            if (!this.allow_null_fromdate && this.allow_null_todate)
            {
                this.btnOK.Enabled = this.FromDate.HasValue ? true : false;
                return;
            }

            if(this.allow_null_fromdate && !this.allow_null_todate)
            {
                this.btnOK.Enabled = this.ToDate.HasValue ? true : false;
                return;
            }

            if(this.allow_null_fromdate && this.allow_null_todate)
            {
                this.btnOK.Enabled = true;
                return;
            }
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

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
