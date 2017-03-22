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
    public partial class DialogEditPrice : Form
    {
        public decimal Value;
        private int pricelist_id;
        private MainForm main_form;
        //public DialogEditPrice()
        //{
        //    InitializeComponent();
        //}

        //public DialogEditPrice(decimal value = 0m)
        //{
        //    InitializeComponent();
        //    this.Value = value;
        //    this.StartPosition = FormStartPosition.CenterParent;
        //}

        public DialogEditPrice(MainForm main_form, int pricelist_id, Size dialog_size, Point dialog_location, decimal unitpr = 0m)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.StartPosition = FormStartPosition.Manual;
            this.Width = dialog_size.Width >= this.MinimumSize.Width ? dialog_size.Width : this.MinimumSize.Width;
            this.Height = dialog_size.Height >= this.MinimumSize.Height ? dialog_size.Height : this.MinimumSize.Height;
            this.Location = dialog_location;
            this.Value = unitpr;
            this.pricelist_id = pricelist_id;
            this.num1._Value = this.Value;
        }

        private void DialogEditPrice_Load(object sender, EventArgs e)
        {
            this.num1.textBox1.SelectionStart = 0;
            this.num1.textBox1.SelectionLength = this.num1._Text.Length;

        }

        private void num1__ValueChanged(object sender, EventArgs e)
        {
            this.Value = ((XNumEdit)sender)._Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    pricelist pricelist_to_update = db.pricelist.Find(this.pricelist_id);

                    if (pricelist_to_update == null)
                    {
                        MessageBox.Show("ค้นหาข้อมูลเพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    pricelist_to_update.unitpr = this.Value;
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("ข้อมูลราคานี้", "");
                    return;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter && this.num1._Focused)
            {
                this.btnOK.PerformClick();
                return true;
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
