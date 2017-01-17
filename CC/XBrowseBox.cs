using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Dialog;
using System.Reflection;

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

        public HorizontalAlignment _TextAlign
        {
            get
            {
                return this._textBox.TextAlign;
            }
            set
            {
                this._textBox.TextAlign = value;
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

        private string list_dialog_title;
        private Object list_object;
        public string FieldNameTextBoxShow;

        public event EventHandler ButtonClick;

        public XBrowseBox()
        {
            InitializeComponent();
        }

        /** Create browse box with list selection dialog
         *param name="list_dialog_title" Windows title for list dialog
         * param name="list_object" Object list to show in list dialog
         * param name="column_collection" Gridview column collection to show in list dialog
         * param name="field_name_textbox_show" Field name of object to show in textbox after selected **/
        public XBrowseBox(string list_dialog_title, object list_object, string field_name_textbox_show)
            : this()
        {
            this.list_dialog_title = list_dialog_title;
            this.list_object = list_object;
            //this.list_object = new object();
            this.FieldNameTextBoxShow = field_name_textbox_show;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Height = 23;

            this.TabStop = true;
            this._textBox.GotFocus += delegate
            {
                if (this._ReadOnly)
                {
                    this.BackColor = Color.White;
                    this._textBox.BackColor = Color.White;
                    this.focused = false;
                }
                else
                {
                    this.BackColor = AppResource.EditableControlBackColor;
                    this._textBox.BackColor = AppResource.EditableControlBackColor;
                    this.focused = true;
                }
            };
            this._textBox.Leave += delegate
            {
                this.BackColor = Color.White;
                this._textBox.BackColor = Color.White;
                this.focused = false;
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this._ReadOnly)
            {
                TextFormatFlags flag;
                if (this._TextAlign == HorizontalAlignment.Right)
                {
                    flag = TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.NoClipping;
                }
                else if (this._TextAlign == HorizontalAlignment.Center)
                {
                    flag = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.NoClipping;
                }
                else
                {
                    flag = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoClipping;
                }

                TextRenderer.DrawText(e.Graphics, this._Text, this._textBox.Font, e.ClipRectangle, this._textBox.ForeColor, flag);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!this._ReadOnly)
            {
                this._textBox.Focus();
            }
        }

        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            this._text = ((TextBox)sender).Text;

            if (this._ReadOnly)
            {
                this.Refresh();
            }
        }

        private void _textBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            this._readonly = ((TextBox)sender).ReadOnly;
            this.TabStop = this._ReadOnly ? false : true;
            ((TextBox)sender).Visible = ((TextBox)sender).ReadOnly ? false : true;

            if (this._ReadOnly)
            {
                this.BackColor = Color.White;
                this._textBox.BackColor = Color.White;
            }

            this.Refresh();
        }

        protected void _btnBrowse_Click(object sender, EventArgs e)
        {
            if(this.ButtonClick != null)
            {
                this.ButtonClick(this, e);
            }
            else
            {
                if (this.list_object != null)
                {
                    ListDialog ld = new ListDialog(this.ParentForm, this, this.list_dialog_title, this.list_object);
                    if (ld.ShowDialog() == DialogResult.OK)
                    {
                        var shown_text = ld.selected_row.Cells[this.FieldNameTextBoxShow].Value;
                        this._textBox.Text = shown_text.ToString();
                        this._textBox.SelectionStart = this._textBox.Text.Length;
                    }

                    this._textBox.Focus();
                }
            }
        }

        private void _btnBrowse_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this._textBox.BackColor = Color.White;
        }

        public void SetListObject(Object list_object)
        {
            this.list_object = list_object;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F6)
            {
                this._btnBrowse.Focus();
                this._btnBrowse.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
