using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CC
{
    public partial class XNumEdit_Old : UserControl
    {
        private int total_digit;
        public int _TotalDigit
        {
            get
            {
                return this.total_digit;
            }
            set
            {
                this.total_digit = value;
            }
        }

        private int decimal_digit;
        public int _DecimalDigit
        {
            get
            {
                return this.decimal_digit;
            }
            set
            {
                this.decimal_digit = value;
            }
        }

        private bool read_only;
        public bool _ReadOnly
        {
            get
            {
                return this.read_only;
            }
            set
            {
                this.textBox1.ReadOnly = value;
            }
        }

        private bool focused;
        public bool _Focused
        {
            get
            {
                return this.focused;
            }
        }

        private decimal edit_value;
        public decimal EditValue
        {
            get
            {
                return this.edit_value;
            }
            set
            {
                this.edit_value = value;
            }
        }
        

        public XNumEdit_Old()
        {
            InitializeComponent();
        }

        public XNumEdit_Old(int total_digit, int decimal_digit)
            : this()
        {
            this.total_digit = total_digit;
            this.decimal_digit = decimal_digit;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.TabStop = true;
            this.BackColor = Color.White;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!this.read_only)
            {
                this.textBox1.Focus();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.read_only)
            {
                TextRenderer.DrawText(e.Graphics, this.edit_value.ToString(""), this.textBox1.Font, new Point(0, 2), this.textBox1.ForeColor);
            }
        }

        private void XNumEdit_Load(object sender, EventArgs e)
        {
            this.textBox1.GotFocus += delegate
            {
                if (this.read_only)
                {
                    this.BackColor = Color.White;
                    this.textBox1.BackColor = Color.White;
                    this.focused = false;
                }
                else
                {
                    this.BackColor = AppResource.EditableControlBackColor;
                    this.textBox1.BackColor = AppResource.EditableControlBackColor;
                    this.focused = true;
                }
            };

            this.textBox1.Leave += delegate
            {
                this.BackColor = Color.White;
                this.textBox1.BackColor = Color.White;
                this.focused = false;
            };
        }
    }
}
