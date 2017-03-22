using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using CC;

namespace XPump.SubForm
{
    public partial class DialogStmasChangeCode : Form
    {
        private MainForm main_form;
        private stmas stmas;
        private string new_name;

        public DialogStmasChangeCode(MainForm main_form, stmas stmas)
        {
            InitializeComponent();

            this.main_form = main_form;
            this.stmas = stmas;
        }

        private void DialogStmasChangeCode_Load(object sender, EventArgs e)
        {
            this.txtOld.Text = this.stmas.name;
        }

        private void txtNew__TextChanged(object sender, EventArgs e)
        {
            this.new_name = ((XTextEdit)sender)._Text;

            if(this.new_name == this.stmas.name || this.new_name.Trim().Length == 0)
            {
                this.btnOK.Enabled = false;
            }
            else
            {
                this.btnOK.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    stmas stmas_to_edit = db.stmas.Find(this.stmas.id);

                    if(stmas_to_edit == null)
                    {
                        MessageBox.Show("ข้อมูลสินค้าที่ท่านแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    stmas_to_edit.name = this.new_name;
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("รหัส", this.new_name);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (this.txtNew._Focused)
                {
                    this.btnOK.PerformClick();
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
