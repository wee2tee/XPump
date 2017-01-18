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
        private bool read_only = false;
        public bool _ReadOnly
        {
            get
            {
                return this.read_only;
            }
            set
            {
                this.textBox1.ReadOnly = value;
                this.Refresh();
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

        private HorizontalAlignment text_align = HorizontalAlignment.Left;
        public HorizontalAlignment _TextAlign
        {
            get
            {
                return this.textBox1.TextAlign;
            }
            set
            {
                this.textBox1.TextAlign = value;
            }
        }

        public BorderStyle _BorderStyle
        {
            get
            {
                return this.BorderStyle;
            }
            set
            {
                this.BorderStyle = value;

                //if (value == BorderStyle.Fixed3D)
                //{

                //}
                //else if (value == BorderStyle.FixedSingle)
                //{

                //}
                //else if (value == BorderStyle.None)
                //{

                //}

                this.Refresh();
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

        public event EventHandler _TextChanged;

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

            if(this._TextAlign == HorizontalAlignment.Right)
            {
                if (this._BorderStyle == BorderStyle.Fixed3D)
                {
                    this.textBox1.Location = new Point(5, 2);
                }
                else if (this._BorderStyle == BorderStyle.FixedSingle)
                {
                    this.textBox1.Location = new Point(4, 3);
                }
                else if (this._BorderStyle == BorderStyle.None)
                {
                    this.textBox1.Location = new Point(3, 4);
                }
            }
            else
            {
                if (this._BorderStyle == BorderStyle.Fixed3D)
                {
                    this.textBox1.Location = new Point(1, 2);
                }
                else if (this._BorderStyle == BorderStyle.FixedSingle)
                {
                    this.textBox1.Location = new Point(2, 3);
                }
                else if (this._BorderStyle == BorderStyle.None)
                {
                    this.textBox1.Location = new Point(3, 4);
                }
            }

            if (this.read_only)
            {
                TextFormatFlags flag;
                if (this._TextAlign == HorizontalAlignment.Right)
                {
                    flag = TextFormatFlags.Top | TextFormatFlags.Right | TextFormatFlags.NoClipping | TextFormatFlags.SingleLine;
                }
                else if (this._TextAlign == HorizontalAlignment.Center)
                {
                    flag = TextFormatFlags.Top | TextFormatFlags.HorizontalCenter | TextFormatFlags.NoClipping | TextFormatFlags.SingleLine;
                }
                else
                {
                    flag = TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.NoClipping | TextFormatFlags.SingleLine;
                }

                if(this._TextAlign == HorizontalAlignment.Right)
                {
                    if (this._BorderStyle == BorderStyle.Fixed3D)
                    {
                        TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Rectangle(e.ClipRectangle.X + 2, e.ClipRectangle.Y + 2, e.ClipRectangle.Width, e.ClipRectangle.Height), this.textBox1.ForeColor, flag);
                    }
                    else if (this._BorderStyle == BorderStyle.FixedSingle)
                    {
                        TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 3, e.ClipRectangle.Width, e.ClipRectangle.Height), this.textBox1.ForeColor, flag);
                    }
                    else if (this._BorderStyle == BorderStyle.None)
                    {
                        TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + 4, e.ClipRectangle.Width, e.ClipRectangle.Height), this.textBox1.ForeColor, flag);
                    }
                }
                else
                {
                    if (this._BorderStyle == BorderStyle.Fixed3D)
                    {
                        TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Rectangle(e.ClipRectangle.X - 2, e.ClipRectangle.Y + 2, e.ClipRectangle.Width, e.ClipRectangle.Height), this.textBox1.ForeColor, flag);
                    }
                    else if (this._BorderStyle == BorderStyle.FixedSingle)
                    {
                        TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Rectangle(e.ClipRectangle.X - 1, e.ClipRectangle.Y + 3, e.ClipRectangle.Width, e.ClipRectangle.Height), this.textBox1.ForeColor, flag);
                    }
                    else if (this._BorderStyle == BorderStyle.None)
                    {
                        TextRenderer.DrawText(e.Graphics, this.text, this.textBox1.Font, new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + 4, e.ClipRectangle.Width, e.ClipRectangle.Height), this.textBox1.ForeColor, flag);
                    }
                }

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
            this.TabStop = this._ReadOnly ? false : true;
            ((TextBox)sender).TabStop = this._ReadOnly ? false : true;
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
            if(this._TextChanged != null)
            {
                this._TextChanged(this, e);
            }
        }

        private void XTextEdit_Resize(object sender, EventArgs e)
        {
            if (this._ReadOnly)
            {
                this.Refresh();
            }
        }
    }
}
