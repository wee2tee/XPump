using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Dialog;

namespace CC
{
    public partial class XDatePicker : UserControl
    {
        private DateTime? selected_date;
        public DateTime? SelectedDate
        {
            get
            {
                return this.selected_date;
            }
            set
            {
                this.selected_date = value;
            }
        }

        public bool IsCalendarShown
        {
            get
            {
                return this.calendar != null ? true : false;
            }
        }

        public CalendarDialog calendar;

        public XDatePicker()
        {
            InitializeComponent();
        }

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            if(this.calendar == null)
            {
                Point pnt = this.btnShowCalendar.PointToScreen(Point.Empty);
                this.calendar = new CalendarDialog(this.selected_date);
                this.calendar.SetBounds(pnt.X, pnt.Y + this.btnShowCalendar.Height - 1, this.calendar.Width, this.calendar.Height);
                this.calendar.Disposed += delegate
                {
                    this.calendar = null;
                    this.txtDate.Focus();
                };
                this.calendar.Show();
            }

            Console.WriteLine(" .. >> is_calendar_shown = " + this.IsCalendarShown);
        }

        public void ShowCalendar()
        {
            this.btnShowCalendar.PerformClick();
        }

        private void XDatePicker_Load(object sender, EventArgs e)
        {
            this.txtDate.GotFocus += delegate
            {
                Console.WriteLine(" .. >> is_calendar_shown = " + this.IsCalendarShown);
            };
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            DateTime d;
            if(DateTime.TryParse("", out d))
            {
                selected_date = d;
            }
        }
    }
}
