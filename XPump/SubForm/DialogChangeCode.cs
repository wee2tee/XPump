using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

namespace XPump.SubForm
{
    public partial class DialogChangeCode : Form
    {
        private MainForm main_form;
        private shift curr_shift;
        public string old_code;
        public string new_code;

        public DialogChangeCode(MainForm main_form, shift curr_shift)
        {
            this.main_form = main_form;
            this.curr_shift = curr_shift;
            InitializeComponent();
        }

        private void txtOldCode_TextChanged(object sender, EventArgs e)
        {
            this.old_code = ((TextBox)sender).Text;
        }

        private void txtNewCode_TextChanged(object sender, EventArgs e)
        {
            this.new_code = ((TextBox)sender).Text;

            this.btnOK.Enabled = this.new_code.Trim().Length > 0 ? true : false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if (this.btnOK.Focused || this.btnCancel.Focused)
                    return false;

                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    if (db.shift.Where(s => s.name.Trim() == this.new_code.Trim() && s.id != this.curr_shift.id).FirstOrDefault() != null) // duplicate name
                    {
                        XMessageBox.Show("ชื่อผลัด '" + this.new_code.Trim() + "' นี้มีอยู่แล้ว, กรุณาเปลี่ยนใหม่", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }

                    var shift = db.shift.Where(s => s.id == this.curr_shift.id).FirstOrDefault();
                    if (shift != null)
                    {
                        shift.name = this.new_code;
                        db.SaveChanges();

                        this.main_form.islog.EditData(FormShift.modcod, "เปลี่ยนชื่อผลัดพนักงานจาก \"" + this.old_code + "\" เป็น \""+ this.new_code +"\"", this.new_code, "shift", this.curr_shift.id).Save();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XMessageBox.Show("ค้นหาข้อมูลที่ต้องการแก้ไขไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
