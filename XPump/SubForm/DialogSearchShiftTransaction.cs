using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;

namespace XPump.SubForm
{
    public partial class DialogSearchShiftTransaction : Form
    {
        public DateTime? selected_date = null;
        public int? selected_shift_id = null;

        public DialogSearchShiftTransaction()
        {
            InitializeComponent();
        }

        private void DialogSearchShiftTransaction_Load(object sender, EventArgs e)
        {
            
        }

        private void dtDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.selected_date = ((XDatePicker)sender)._SelectedDate;
            this.ValidateScope();
        }

        private void brShift__TextChanged(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                var shift = db.shift.Where(s => s.name.Trim() == ((XBrowseBox)sender)._Text.Trim()).FirstOrDefault();
                if(shift != null)
                {
                    this.selected_shift_id = shift.id;
                }
                else
                {
                    this.selected_shift_id = null;
                }

                this.ValidateScope();
            }
        }

        private void brShift__ButtonClick(object sender, EventArgs e)
        {
            int initial_shift_id = this.selected_shift_id.HasValue ? this.selected_shift_id.Value : -1;

            DialogShiftSelector sel = new DialogShiftSelector(initial_shift_id);
            sel.StartPosition = FormStartPosition.CenterParent;
            if(sel.ShowDialog() == DialogResult.OK)
            {
                ((XBrowseBox)sender)._Text = sel.selected_shift.name;
                this.ValidateScope();
            }
        }

        private void ValidateScope()
        {
            if(this.selected_date.HasValue && this.selected_shift_id.HasValue)
            {
                this.btnOK.Enabled = true;
            }
            else
            {
                this.btnOK.Enabled = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (!this.btnOK.Focused)
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
