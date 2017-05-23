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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogShiftSttak : Form
    {
        private MainForm main_form;
        private FormShiftTransaction form_shifttransaction;
        private shiftsales shiftsales;
        private BindingList<shiftsttakVM> sttak;
        private shiftsttakVM editing_sttak;
        private FORM_MODE form_mode;

        public DialogShiftSttak(MainForm main_form, FormShiftTransaction form_shifttransaction, shiftsales shiftsales)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.form_shifttransaction = form_shifttransaction;
            this.shiftsales = shiftsales;
        }

        private void DialogShiftSttak_Load(object sender, EventArgs e)
        {
            if (this.shiftsales == null)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }

            this.inline_qty.SetBounds(-9999, 0, 0, 0);

            this.FillForm();
            this.ActiveControl = this.dgv;

            if (this.dgv.Rows.Count > 0)
                this.dgv.Rows[0].Cells[this.col_sttak_qty.Name].Selected = true;

            this.form_mode = FORM_MODE.READ_ITEM;
        }

        private void DialogShiftSttak_Shown(object sender, EventArgs e)
        {
            if(this.shiftsales.ToViewModel(this.main_form.working_express_db).ValidateEditableShiftSales(false) == true)
            {
                this.btnEdit.PerformClick();
            }
        }

        private void FillForm()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.sttak = new BindingList<shiftsttakVM>(db.shiftsttak.Where(s => s.shiftsales_id == this.shiftsales.id).ToViewModel(this.main_form.working_express_db).OrderBy(s => s.tank_name).ThenBy(s => s.section_name).ToList());
                this.dgv.DataSource = this.sttak;
            }
        }

        private void ShowInlineForm()
        {
            if (this.dgv.CurrentCell == null)
                return;

            int row_index = this.dgv.CurrentCell.RowIndex;
            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sttak_qty.DataPropertyName).First().Index;

            this.editing_sttak = this.sttak[row_index];

            this.inline_qty.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.inline_qty._Value = (decimal)this.dgv.Rows[row_index].Cells[col_index].Value;
        }

        private void RemoveInlineForm()
        {
            this.editing_sttak = null;
            this.inline_qty.SetBounds(-9999, 0, 0, 0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if (this.shiftsales.ToViewModel(this.main_form.working_express_db).ValidateEditableShiftSales() == false)
                return;

            if (this.form_mode == FORM_MODE.EDIT_ITEM)
                return;

            this.ShowInlineForm();
            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.btnSave.Enabled = true;
            this.inline_qty.Focus();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.btnEdit.PerformClick();
            }
            else
            {
                this.inline_qty.Focus();
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (this.form_mode != FORM_MODE.READ_ITEM)
                    return;

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_sttak_qty.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt + E>");
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                cm.MenuItems.Add(mnu_edit);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.inline_qty.Focus();
            }
        }

        private void inline_qty__GotFocus(object sender, EventArgs e)
        {
            ((XNumEdit)sender)._SelectionStart = ((XNumEdit)sender)._Text.Contains(".") ? ((XNumEdit)sender)._Text.IndexOf(".") : 0;
        }

        private void inline_qty__ValueChanged(object sender, EventArgs e)
        {
            this.sttak[this.dgv.CurrentCell.RowIndex].shiftsttak.qty = ((XNumEdit)sender)._Value;
            this.sttak.ResetItem(this.dgv.CurrentCell.RowIndex);
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if (this.form_mode == FORM_MODE.READ_ITEM)
                return;

            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if (((XDatagrid)sender).CurrentCell.RowIndex != this.sttak.IndexOf(this.editing_sttak))
                {
                    this.RemoveInlineForm();
                    this.ShowInlineForm();
                    this.inline_qty.Focus();
                }
                else
                {
                    this.inline_qty.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.shiftsales.ToViewModel(this.main_form.working_express_db).ValidateEditableShiftSales() == false)
                return;

            if(this.sttak.Where(s => s.qty < 0).Count() > 0)
            {
                MessageBox.Show("กรุณาป้อนปริมาณน้ำมันที่วัดได้ให้ครบทุกรายการ(ห้ามติดลบ)", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.dgv.Rows[this.sttak.IndexOf(this.sttak.Where(s => s.qty < 0).First())].Cells[this.col_sttak_qty.Name].Selected = true;
                this.ShowInlineForm();
                this.inline_qty.Focus();
                return;
            }

            try
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    foreach (var s in this.sttak)
                    {
                        var sttak_to_update = db.shiftsttak.Find(s.id);
                        sttak_to_update.qty = s.qty;
                        sttak_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        sttak_to_update.chgtime = DateTime.Now;

                        var shiftsales_to_update = db.shiftsales.Find(this.shiftsales.id);
                        shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        shiftsales_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();

                        this.main_form.islog.EditData(this.form_shifttransaction.menu_id, "บันทึกปริมาณน้ำมันที่ตรวจวัดได้ รหัส \"" + sttak_to_update.ToViewModel(this.main_form.working_express_db).stkcod + "\" ในบันทึกรายการประจำผลัด \"" + this.form_shifttransaction.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + "\" วันที่ " + this.form_shifttransaction.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.form_shifttransaction.curr_shiftsales.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.form_shifttransaction.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsttak", sttak_to_update.id).Save();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if (this.dgv.CurrentCell == null)
                        return false;

                    if(this.dgv.CurrentCell.RowIndex < this.sttak.Count - 1)
                    {
                        this.dgv.Rows[this.dgv.CurrentCell.RowIndex + 1].Cells[this.col_sttak_qty.Name].Selected = true;
                        return true;
                    }
                    else
                    {
                        this.dgv.Rows[0].Cells[this.col_sttak_qty.Name].Selected = true;
                        return true;
                    }
                }
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                if(this.form_mode == FORM_MODE.READ_ITEM)
                {
                    if (this.dgv.CurrentCell == null)
                        return false;

                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var sttak = (shiftsttak)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_sttak_sttak.Name].Value;

                        var total_recs = db.shiftsttak.AsEnumerable().Count();
                        var data_info = db.shiftsttak.Find(sttak.id);

                        if (data_info == null)
                            return false;

                        DialogDataInfo info = new DialogDataInfo("Shiftsttak", data_info.id, total_recs, data_info.creby, data_info.cretime, data_info.chgby, data_info.chgtime);
                        info.ShowDialog();
                        return true;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
