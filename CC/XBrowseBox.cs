using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Dialog;

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

        private Object list_object;
        //public Object _ListObject
        //{
        //    get
        //    {
        //        return this.list_object;
        //    }
        //}

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

        private void _btnBrowse_Click(object sender, EventArgs e)
        {
            ListDialog ld = new ListDialog(this.ParentForm, this.list_object);
            ld.ShowDialog();
            
            //this._textBox.Focus();
        }

        private void _btnBrowse_Enter(object sender, EventArgs e)
        {
            //if (this._readonly)
            //{
                this.BackColor = Color.White;
                this._textBox.BackColor = Color.White;
            //}
            //else
            //{
            //    this.BackColor = AppResource.EditableControlBackColor;
            //    this._textBox.BackColor = AppResource.EditableControlBackColor;
            //}
        }

        public void SetListObject(Object list_object)
        {
            this.list_object = list_object;
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
    }
}
