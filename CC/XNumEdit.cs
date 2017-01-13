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

        private bool use_thoundsand_separate;
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
            }
        }

        //private int last_caret_position_from_right = 0;
        private int last_caret_position = 0;

        public XNumEdit()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.textBox1.Text = string.Format(CultureInfo.CurrentCulture, "{0:#0.00}", this.edit_value);

            base.OnPaint(pe);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            decimal result;

            if(decimal.TryParse(((TextBox)sender).Text.Replace(",", ""), out result))
            {
                this.edit_value = result;
            }
            else
            {
                this.edit_value = 0m;
            }
            
            ((TextBox)sender).Text = string.Format(CultureInfo.CurrentCulture, "{0:#0.00}", this.edit_value);

            
            //int pos_count = 0;
            //for (int i = 0; i < ((TextBox)sender).Text.ToCharArray().Count(); i++)
            //{
            //    if(((TextBox)sender).Text.ToCharArray()[i].ToString() == ",")
            //    {
            //        continue;
            //    }
            //    pos_count++;
            //    if(pos_count == this.last_caret_position)
            //    {
            //        ((TextBox)sender).SelectionStart = i + 1;
            //        return;
            //    }
            //}
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //this.last_caret_position = ((TextBox)sender).Text.Substring(0, ((TextBox)sender).SelectionStart).Replace(",", "").ToCharArray().Count();

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
                    Keys.Insert,
                    Keys.Delete,
                    Keys.Enter,
                    Keys.Back,
                    Keys.Home,
                    Keys.End
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
                    Keys.Insert,
                    Keys.Delete,
                    Keys.Enter,
                    Keys.Back,
                    Keys.Home,
                    Keys.End
                };
            }

            if (allow_keys.Where(k => k == e.KeyData).Count() == 0)
            {
                e.SuppressKeyPress = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Decimal)
            {
                if(this.decimal_digit > 0) // if this instance allow to put a decimal digit
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

            if(keyData == Keys.Delete && this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart == this.textBox1.Text.IndexOf("."))
            {
                //MessageBox.Show("before decimal");
                return true;
            }

            if(keyData == Keys.Back && this.textBox1.Text.Contains(".") && this.textBox1.SelectionStart == this.textBox1.Text.IndexOf(".") + 1)
            {
                //MessageBox.Show("after decimal");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine(".. >>> KeyUp");



            //decimal result = this.edit_value;
            //decimal.TryParse(((TextBox)sender).Text.Replace(",", ""), out result);

            //((TextBox)sender).Text = string.Format(CultureInfo.CurrentCulture, "{0:#,##0.00}", result);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(".. >>> KeyPress");
            Console.WriteLine(".. >>> textbox text : " + ((TextBox)sender).Text);
        }
    }
}
