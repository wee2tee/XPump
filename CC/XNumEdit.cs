using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CC
{
    public partial class XNumEdit : XTextEdit
    {
        private decimal maximum_value = 999999999.9999m;
        public decimal _MaximumValue
        {
            get
            {
                return this.maximum_value;
            }
            set
            {
                this.maximum_value = value;
            }
        }

        private int decimal_digit = 2;
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

        private bool use_thoundsand_separate = true;
        public bool _UseThoundsandSeparate
        {
            get
            {
                return this.use_thoundsand_separate;
            }
            set
            {
                this.use_thoundsand_separate = value;
            }
        }

        public new int _MaxLength
        {
            get
            {
                return base._MaxLength;
            }
            set
            {
                return;
            }
        }
        //public new int _MaxLength
        //{
        //    get
        //    {
        //        return this.total_digit;
        //    }
        //}

        //public new string _Text
        //{
        //    get
        //    {
        //        return string.Format(CultureInfo.CurrentCulture, "{0:#,#0.00}", this.edit_value);
        //    }
        //}

        private string num_format;

        private decimal edit_value = 0m;
        public decimal _Value
        {
            get
            {
                return this.edit_value;
            }
            set
            {
                this.edit_value = value;
                this.Refresh();
            }
        }

        private int last_caret_position_from_right = 0;
        private int last_char_count = 0;
        private int addition_digit = 0; // addition digit when delete with delete button
        private bool decimal_decrease_by_del = false;
        private bool decimal_decrease_by_back = false;

        public XNumEdit()
        {
            InitializeComponent();
            base._MaxLength = 30;
            this.num_format = this._UseThoundsandSeparate ? "{0:#,#0}" : "{0:0}";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.num_format = this._UseThoundsandSeparate ? "{0:#,#0" : "{0:0";
            if (this.decimal_digit > 0)
            {
                this.num_format += ".";
                for (int i = 0; i < this.decimal_digit; i++)
                {
                    this.num_format += "0";
                }
                this.num_format += "}";
            }
            else
            {
                this.num_format += "}";
            }

            this.textBox1.Text = string.Format(CultureInfo.CurrentCulture, this.num_format, this.edit_value);

            base.OnPaint(pe);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textbox_str = ((TextBox)sender).Text;
            if (this.decimal_digit > 0) // validate decimal digit
            {
                if (textbox_str.Contains("."))
                {
                    if (textbox_str.Split('.')[1].Length > this.decimal_digit)
                    {
                        textbox_str = textbox_str.Split('.')[0] + "." + textbox_str.Split('.')[1].Substring(0, this.decimal_digit);
                    }
                }
            }

            decimal result;
            if (decimal.TryParse(textbox_str.Replace(",", ""), out result))
            {
                this.edit_value = result;
            }
            else
            {
                this.edit_value = 0m;
            }

            ((TextBox)sender).Text = string.Format(CultureInfo.CurrentCulture, this.num_format, this.edit_value);

            bool is_decrease_char_count = ((TextBox)sender).Text.Length < this.last_char_count ? true : false;

            // move the caret to target position
            if (this.decimal_digit > 0 && this.last_caret_position_from_right <= this.decimal_digit) // if decimal digit is used && last caret position after decimal
            {
                
                    if (((TextBox)sender).Text.Length > ((TextBox)sender).Text.Length - this.last_caret_position_from_right)
                    {
                        ((TextBox)sender).SelectionStart = (((TextBox)sender).Text.Length - this.last_caret_position_from_right) + 1;
                    }
                    else
                    {
                        ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                    }
                
            }
            else
            {
                if (is_decrease_char_count) // char count decreased
                {
                    try
                    {
                        ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length - this.last_caret_position_from_right + this.addition_digit;
                    }
                    catch
                    {
                        ((TextBox)sender).SelectionStart = 0;
                    }
                }
                else
                {
                    ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length - this.last_caret_position_from_right;
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.last_caret_position_from_right = ((TextBox)sender).Text.Length - ((TextBox)sender).SelectionStart;
            this.last_char_count = ((TextBox)sender).Text.Length;

            List<Keys> allow_keys;

            if (this.decimal_digit == 0)
            {
                allow_keys = new List<Keys>
                {
                    Keys.D0,
                    Keys.D1,
                    Keys.D2,
                    Keys.D3,
                    Keys.D4,
                    Keys.D5,
                    Keys.D6,
                    Keys.D7,
                    Keys.D8,
                    Keys.D9,
                    Keys.NumPad0,
                    Keys.NumPad1,
                    Keys.NumPad2,
                    Keys.NumPad3,
                    Keys.NumPad4,
                    Keys.NumPad5,
                    Keys.NumPad6,
                    Keys.NumPad7,
                    Keys.NumPad8,
                    Keys.NumPad9,
                    Keys.NumLock,
                    Keys.Left,
                    Keys.Right,
                    Keys.Up,
                    Keys.Down,
                    Keys.Shift,
                    Keys.Control,
                    Keys.Insert,
                    Keys.Delete,
                    Keys.Enter,
                    Keys.Back,
                    Keys.Home,
                    Keys.End,
                    (Keys.Shift | Keys.Left),
                    (Keys.Shift | Keys.Right),
                    (Keys.Shift | Keys.Home),
                    (Keys.Shift | Keys.End),
                    (Keys.Control | Keys.C),
                    (Keys.Control | Keys.V),
                    (Keys.Control | Keys.X)
                };
            }
            else
            {
                allow_keys = new List<Keys>
                {
                    Keys.D0,
                    Keys.D1,
                    Keys.D2,
                    Keys.D3,
                    Keys.D4,
                    Keys.D5,
                    Keys.D6,
                    Keys.D7,
                    Keys.D8,
                    Keys.D9,
                    Keys.NumPad0,
                    Keys.NumPad1,
                    Keys.NumPad2,
                    Keys.NumPad3,
                    Keys.NumPad4,
                    Keys.NumPad5,
                    Keys.NumPad6,
                    Keys.NumPad7,
                    Keys.NumPad8,
                    Keys.NumPad9,
                    Keys.Decimal,
                    Keys.NumLock,
                    Keys.Left,
                    Keys.Right,
                    Keys.Up,
                    Keys.Down,
                    Keys.Shift,
                    Keys.Control,
                    Keys.Insert,
                    Keys.Delete,
                    Keys.Enter,
                    Keys.Back,
                    Keys.Home,
                    Keys.End,
                    (Keys.Shift | Keys.Left),
                    (Keys.Shift | Keys.Right),
                    (Keys.Shift | Keys.Home),
                    (Keys.Shift | Keys.End),
                    (Keys.Control | Keys.C),
                    (Keys.Control | Keys.V),
                    (Keys.Control | Keys.X)
                };
            }

            if (allow_keys.Where(k => k == e.KeyData).Count() == 0)
            {
                e.SuppressKeyPress = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Decimal)
            {
                if (this.decimal_digit > 0) // if this instance allow to put a decimal digit
                {
                    if (this.textBox1.Text.Contains("."))
                    {
                        this.textBox1.SelectionStart = this.textBox1.Text.IndexOf(".") + 1;
                        //this.textBox1.SelectionLength = 0;
                    }
                    else
                    {
                        this.textBox1.Text.Insert(this.textBox1.Text.Length, ".");
                        this.textBox1.SelectionStart = this.textBox1.Text.Length;
                    }
                }

                return true;
            }

            if (keyData == Keys.Delete && this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart == this.textBox1.Text.IndexOf("."))
            {
                SendKeys.Send("{RIGHT}");
                return true;
            }

            if (keyData == Keys.Delete && this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart > this.textBox1.Text.IndexOf("."))
            {
                this.decimal_decrease_by_del = true;
                return true;
            }

            if (keyData == Keys.Back && this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart > this.textBox1.Text.IndexOf(".") + 1)
            {
                this.decimal_decrease_by_del = true;
                return true;
            }

            if (keyData == Keys.Back && this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart == this.textBox1.Text.IndexOf(".") + 1)
            {
                SendKeys.Send("{LEFT}");
                return true;
            }

            if(keyData == Keys.Delete && this.textBox1.Text.Contains(",") && this.textBox1.Text.Substring(this.textBox1.SelectionStart, 1) == ",")
            {
                SendKeys.Send("{RIGHT}");
                //SendKeys.Send("{DELETE}");
                return true;
            }

            if(keyData == Keys.Back && this.textBox1.Text.Contains(",") && this.textBox1.SelectionStart > 0 && this.textBox1.Text.Substring(this.textBox1.SelectionStart - 1, 1) == ",")
            {
                SendKeys.Send("{LEFT}");
                //SendKeys.Send("{BACKSPACE}");
                return true;
            }

            if(keyData == (Keys.Control | Keys.C) || keyData == (Keys.Control | Keys.V) || keyData == (Keys.Control | Keys.X))
            {
                return false;
            }

            if (keyData == Keys.Delete && !(this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart == this.textBox1.Text.IndexOf(".") || this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart == this.textBox1.Text.IndexOf(",")))
            {
                this.addition_digit = 1;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.addition_digit = 0;
            this.decimal_decrease_by_back = false;
            this.decimal_decrease_by_del = false;
        }
        
    }
}
