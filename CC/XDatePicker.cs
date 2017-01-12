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
                if (this.selected_date.HasValue)
                    this.txtDate.Text = this.selected_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture.DateTimeFormat);

                this._SelectedDate_Changed(this, new EventArgs());

                if (this.is_read_only)
                {
                    this.Refresh();
                }
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
                string str_date = this.selected_date.HasValue ? this.selected_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture.DateTimeFormat) : "  /  /    ";
                this.txtDate.Text = str_date;
                this.is_read_only = value;
                this.btnShowCalendar.Enabled = !value;
                this.txtDate.Visible = !value;

                this.Refresh();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.is_read_only)
            {
                this.BackColor = Color.White;
                this.txtDate.BackColor = Color.White;
            }

            base.OnPaint(e);
            if (this.is_read_only)
            {
                string str_date = this.selected_date.HasValue ? this.selected_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture.DateTimeFormat) : "  /  /    ";

                TextRenderer.DrawText(e.Graphics, str_date, this.txtDate.Font, new Point(0, 2), this.txtDate.ForeColor);
            }
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
                this._SelectedDate = d;
            }
            else
            {
                this._SelectedDate = null;
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

        public event EventHandler _SelectedDateChanged;
        protected void _SelectedDate_Changed(object sender, EventArgs e)
        {
            if (this._SelectedDateChanged != null)
                this._SelectedDateChanged(this, e);
        }
    }
}
