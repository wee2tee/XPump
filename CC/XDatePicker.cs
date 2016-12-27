using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Dialog;
using System.Globalization;

namespace CC
{
    public partial class XDatePicker : UserControl
    {
        private DateTime? selected_date;
        public DateTime? _SelectedDate
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

        public bool _IsCalendarShown
        {
            get
            {
                return this.calendar != null ? true : false;
            }
        }

        private bool is_read_only;
        public bool _ReadOnly
        {
            get
            {
                return this.is_read_only;
            }
            set
            {
                this.is_read_only = value;
            }
        }

        public CalendarDialog calendar;

        public XDatePicker()
        {
            InitializeComponent();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.BackColor = Color.White;
        }

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            if(this.calendar == null)
            {
                Point pnt = this.btnShowCalendar.PointToScreen(Point.Empty);
                this.calendar = new CalendarDialog(this);
                this.calendar.SetBounds(pnt.X, pnt.Y + this.btnShowCalendar.Height - 1, this.calendar.Width, this.calendar.Height);
                this.calendar.Disposed += delegate
                {
                    this.txtDate.Text = this.selected_date != null ? this.selected_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) : "";
                    this.calendar = null;
                    this.txtDate.Focus();
                };
                this.calendar.Show();
            }

            Console.WriteLine(" .. >> is_calendar_shown = " + this._IsCalendarShown);
        }

        public void ShowCalendar()
        {
            this.btnShowCalendar.PerformClick();
        }

        private void XDatePicker_Load(object sender, EventArgs e)
        {
            this.txtDate.GotFocus += delegate
            {
                if(!this.is_read_only && this.txtDate.Focused)
                {
                    this.txtDate.BackColor = AppResource.EditableControlBackColor;
                    this.BackColor = AppResource.EditableControlBackColor;
                }
                else
                {
                    this.txtDate.BackColor = Color.White;
                    this.BackColor = Color.White;
                }
            };

            this.txtDate.LostFocus += delegate
            {
                this.txtDate.BackColor = Color.White;
                this.BackColor = Color.White;
                if(this.selected_date == null)
                {
                    this.txtDate.Text = "";
                }
            };
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            DateTime d;
            if(DateTime.TryParse(this.txtDate.Text, CultureInfo.CurrentCulture, DateTimeStyles.None, out d))
            {
                this.selected_date = d;
            }
            else
            {
                this.selected_date = null;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F6)
            {
                this.btnShowCalendar.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
