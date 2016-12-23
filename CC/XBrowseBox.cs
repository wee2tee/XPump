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
    public partial class XBrowseBox : UserControl
    {
        private string _text;
        public string _Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._textBox.Text = value;
            }
        }

        private bool _readonly;
        public bool _ReadOnly
        {
            get
            {
                return this._readonly;
            }
            set
            {
                this._textBox.ReadOnly = value;
                this._btnBrowse.Enabled = !value;
            }
        }

        public XBrowseBox()
        {
            InitializeComponent();
        }

        private void CustomBrowseField_Load(object sender, EventArgs e)
        {
            this.TabStop = true;
            
        }

        protected override void OnCreateControl()
        {
            //base.OnCreateControl();
            //this.BackColor = Color.White;
            //this.btn_width = this._btnBrowse.ClientSize.Width - 2;
            //this.HideButton();

            this._textBox.GotFocus += delegate
            {
                if (this._readonly)
                {
                    this.BackColor = Color.White;
                    this._textBox.BackColor = Color.White;
                }
                else
                {
                    this.BackColor = AppResource.EditableControlBackColor;
                    this._textBox.BackColor = AppResource.EditableControlBackColor;
                }
            };
            this._textBox.Leave += delegate
            {
                this.BackColor = Color.White;
                this._textBox.BackColor = Color.White;
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //if (this.is_read_only)
            //{
            //    this.DrawText();
            //}

            //if(!this._readonly && this.Focused)
            //{
            //    this.BackColor = AppResource.EditableControlBackColor;
            //}
            //else
            //{
            //    this.BackColor = Color.White;
            //}
        }



        //private void DrawText()
        //{
        //    using (Font font = new Font("tahoma", 9.75f))
        //    {
        //        using (SolidBrush brush = new SolidBrush(Color.Black))
        //        {
        //            this.CreateGraphics().DrawString(this._text, font, brush, this.ClientRectangle, str_format_left);
        //        }
        //    }
        //}

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this._textBox.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F6)
            {
                this._btnBrowse.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            this._text = ((TextBox)sender).Text;
        }

        private void _textBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            this._readonly = ((TextBox)sender).ReadOnly;
        }

        private void _btnBrowse_Click(object sender, EventArgs e)
        {
            this._textBox.Focus();

            MessageBox.Show("clicked");
        }

        private void _btnBrowse_Enter(object sender, EventArgs e)
        {
            if (this._readonly)
            {
                this.BackColor = Color.White;
                this._textBox.BackColor = Color.White;
            }
            else
            {
                this.BackColor = AppResource.EditableControlBackColor;
                this._textBox.BackColor = AppResource.EditableControlBackColor;
            }
        }
    }
}
