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
    public partial class XTextEdit : UserControl
    {
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

        private string text;
        public string _Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }

        public int _MaxLength
        {
            get
            {
                return this.textBox1.MaxLength;
            }
            set
            {
                this.textBox1.MaxLength = value;
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

        public XTextEdit()
        {
            InitializeComponent();
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
                TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Point(0, 3), this.textBox1.ForeColor);
            }
        }

        private void XTextEdit_Load(object sender, EventArgs e)
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

        private void textBox1_ReadOnlyChanged(object sender, EventArgs e)
        {
            this.read_only = ((TextBox)sender).ReadOnly;
            this.TabStop = this.read_only ? false : true;
            this.textBox1.Visible = this.read_only ? false : true;

            if (this.read_only)
            {
                this.BackColor = Color.White;
                this.textBox1.BackColor = Color.White;
                this.Refresh();
            }

            if (!this.read_only)
            {
                this.textBox1.SelectionStart = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.text = ((TextBox)sender).Text;
            if (this.read_only)
            {
                this.Refresh();
            }
        }
    }
}
