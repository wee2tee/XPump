using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using XPump.Model;
using XPump.Misc;
using CC;

namespace XPump.SubForm
{
    public partial class DialogDateSelector : Form
    {
        public DateTime selected_date
        {
            get
            {
                var x = DateTime.Parse(this.dtDate._SelectedDate.Value.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture));
                return x;
            }
        }
        private DateTime? initial_date;
        private string lbl_date_title;

        public DialogDateSelector(string lbl_date_title, DateTime? initial_date)
        {
            InitializeComponent();
            this.lbl_date_title = lbl_date_title;
            this.initial_date = initial_date;
        }

        private void DialogDateSelector_Load(object sender, EventArgs e)
        {
            this.lblDateTitle.Text = this.lbl_date_title;
            this.dtDate.SetDate(this.initial_date);
        }

        private void dtDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = ((XDatePicker)sender)._SelectedDate.HasValue ? true : false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (this.dtDate._Focused)
                {
                    this.btnOK.PerformClick();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
