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
        public DateTime? selected_date = null;
        private XDatePicker xdate_picker;
        
        public CalendarDialog()
        {
            InitializeComponent();
        }

        public CalendarDialog(XDatePicker xdate_picker)
            : this()
        {
            this.xdate_picker = xdate_picker;
            this.calendar.SelectionStart = xdate_picker._SelectedDate != null ? xdate_picker._SelectedDate.Value : DateTime.Now;
        }

        private void CalendarDialog_Load(object sender, EventArgs e)
        {
            
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.xdate_picker._SelectedDate = this.selected_date;
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
