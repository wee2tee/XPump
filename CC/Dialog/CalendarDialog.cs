using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CC.Dialog
{
    public partial class CalendarDialog : Form
    {
        private DateTime? init_date;
        public DateTime? selected_date = null;

        public CalendarDialog(DateTime? init_date)
        {
            InitializeComponent();
            this.init_date = init_date;
        }

        private void CalendarDialog_Load(object sender, EventArgs e)
        {
            if (this.init_date != null)
            {
                this.calendar.SelectionStart = this.init_date.Value;
                this.calendar.SelectionEnd = this.init_date.Value;
            }
            else
            {
                this.calendar.SelectionStart = DateTime.Now;
                this.calendar.SelectionEnd = DateTime.Now;
            }
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.selected_date = e.Start;
        }

        private void CalendarDialog_Deactivate(object sender, EventArgs e)
        {
            this.Dispose();
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
