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

        private string list_dialog_title;
        private Object list_object;
        public string FieldNameTextBoxShow;

        public event EventHandler ButtonClick;

        public XBrowseBox()
        {
            InitializeComponent();
            this.list_object = new object();
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
            this.FieldNameTextBoxShow = field_name_textbox_show;
        }

        private void XBrowseBox_Load(object sender, EventArgs e)
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

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this._textBox.Focus();
        }

        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            this._text = ((TextBox)sender).Text;
        }

        private void _textBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            this._readonly = ((TextBox)sender).ReadOnly;
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
