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
    public partial class DialogDother : Form
    {
        private MainForm main_form;
        
        /** in case of salessummary deduct **/
        private salessummary salessummary;
        /** in case of dayend deduct **/
        private dayend dayend;
        private section section;
        /******************************/

        private FORM_MODE form_mode;
        private BindingList<dotherVM> bl_dother;
        private dother tmp_dother;
        private string menu_id;
        private enum DOTHER
        {
            SHIFTSALES,
            DAYEND
        }

        private DOTHER dother_type;

        public DialogDother(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        public DialogDother(MainForm main_form,FormShiftTransaction form_shifttransaction, salessummary salessummary)
            : this(main_form)
        {
            this.menu_id = form_shifttransaction.menu_id;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.dother_type = DOTHER.SHIFTSALES;
                this.salessummary = db.salessummary.Include("shiftsales").Include("shiftsales.shiftsttak").Where(s => s.id == salessummary.id).FirstOrDefault();
                if(this.salessummary == null)
                {
                    XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        //public DialogDother(MainForm main_form, FormDailyClose form_dailyclose, dayend dayend)
        //    : this(main_form)
        //{
        //    this.menu_id = form_dailyclose.menu_id;
        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {
        //        this.dother_type = DOTHER.DAYEND;
        //        this.dayend = db.dayend.Include("daysttak").Where(d => d.id == dayend.id).FirstOrDefault();
        //        if (this.dayend == null)
        //        {
        //            XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
        //            this.DialogResult = DialogResult.Abort;
        //            this.Close();
        //        }
        //    }
        //}

        public DialogDother(MainForm main_form, FormDailyClose form_dailyclose, dayend dayend, section section)
            : this(main_form)
        {
            this.menu_id = form_dailyclose.menu_id;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.dother_type = DOTHER.DAYEND;
                this.dayend = db.dayend.Include("daysttak").Where(d => d.id == dayend.id).FirstOrDefault();
                if (this.dayend == null)
                {
                    XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                this.section = db.section.Find(section.id);
            }
        }

        private void DialogDother_Load(object sender, EventArgs e)
        {
            var available_dother = this.GetAvailableDother(this.dother_type);

            this.inline_dother._Items.Add(new XDropdownListItem { Text = string.Empty, Value = -1 });
            foreach (var d in available_dother)
            {
                this.inline_dother._Items.Add(new XDropdownListItem { Text = "[" + d.typcod + "]" + d.typdes, Value = d.id });
            }

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                List<int> section_ids = null;
                string stkcod = string.Empty;

                if(this.dother_type == DOTHER.DAYEND)
                {
                    section_ids = this.dayend.daysttak.Select(d => d.section_id).ToList();
                    stkcod = this.dayend.stkcod;
                }
                if(this.dother_type == DOTHER.SHIFTSALES)
                {
                    section_ids = this.salessummary.shiftsales.shiftsttak.Select(s => s.section_id).ToList();
                    stkcod = this.salessummary.stkcod;
                }

                this.inline_section._Items.Add(new XDropdownListItem { Text = string.Empty, Value = -1 });
                var sections = db.section
                    .Where(s => section_ids.Contains(s.id))
                    .Where(s => s.stkcod == stkcod)
                    .OrderBy(s => s.name).ToList();

                foreach (var s in sections)
                {
                    this.inline_section._Items.Add(new XDropdownListItem { Text = s.name, Value = s.id });
                }
            }

            this.RemoveInlineForm();
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ_ITEM);
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnClose.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

            if(this.bl_dother.Count == 0)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private List<istab> GetAvailableDother(DOTHER dother_type)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                switch (dother_type)
                {
                    case DOTHER.SHIFTSALES:
                        return db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.DOTHER && i.is_shiftsales).ToList();
                    case DOTHER.DAYEND:
                        return db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.DOTHER && i.is_dayend).ToList();
                    default:
                        return null;
                }
                
            }
        }

        private List<dother> GetDother(DOTHER dother_type)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                switch (dother_type)
                {
                    case DOTHER.SHIFTSALES:
                        return db.dother.Where(d => d.salessummary_id == this.salessummary.id).ToList();
                    case DOTHER.DAYEND:
                        return db.dother.Where(d => d.dayend_id == this.dayend.id && d.section_id == this.section.id).ToList();
                    default:
                        return null;
                }
            }
        }

        private void FillForm()
        {
            this.bl_dother = null;
            this.bl_dother = new BindingList<dotherVM>(this.GetDother(this.dother_type).ToViewModel(this.main_form.working_express_db).OrderBy(d => d.section_name).ThenBy(d => d.typdes).ToList());
            this.dgv.DataSource = this.bl_dother;
        }

        private void ShowInlineForm()
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_dother = (dother)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_dother.Name].Value;

            int col_index;
            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_section_name.Name).First().Index;
                this.inline_section.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
                if(this.section != null)
                {
                    this.tmp_dother.section_id = this.section.id;
                    this.inline_section._ReadOnly = true;
                    var selected_section = this.inline_section._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.section.id).FirstOrDefault();
                    this.inline_section._SelectedItem = selected_section != null ? selected_section : this.inline_section._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == -1).First();
                }
                else
                {
                    this.inline_section._ReadOnly = false;
                    var selected_section = this.inline_section._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.section_id).FirstOrDefault();
                    this.inline_section._SelectedItem = selected_section != null ? selected_section : this.inline_section._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == -1).First();
                }

                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes.DataPropertyName).First().Index;
                this.inline_dother.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
                this.inline_dother._ReadOnly = false;
                var selected_dother = this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.istab_id).FirstOrDefault();
                this.inline_dother._SelectedItem = selected_dother != null ? selected_dother : this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == -1).First();
            }
            else
            {
                this.inline_section.SetBounds(-9999, 0, 0, 0);
                this.inline_section._ReadOnly = true;

                this.inline_dother.SetBounds(-9999, 0, 0, 0);
                this.inline_dother._ReadOnly = true;
            }
            //this.inline_dother._SelectedItem = this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.istab_id).FirstOrDefault() != null ? this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.istab_id).First() : this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == -1).First();

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_qty.DataPropertyName).First().Index;
            this.inline_qty.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_qty._Value = this.tmp_dother.qty;
        }

        private void RemoveInlineForm()
        {
            this.inline_section.SetBounds(-9999, 0, 0, 0);
            this.inline_dother.SetBounds(-9999, 0, 0, 0);
            this.inline_qty.SetBounds(-9999, 0, 0, 0);
            this.tmp_dother = null;
        }

        //private bool? IsApproved()
        //{
        //    switch (this.dother_type)
        //    {
        //        case DOTHER.SHIFTSALES:
        //            return this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsApproved();
        //        case DOTHER.DAYEND:
        //            return this.dayend.ToViewModel(this.main_form.working_express_db).IsApproved();
        //        default:
        //            return null;
        //    }
        //}

        private bool IsEditable()
        {
            switch (this.dother_type)
            {
                case DOTHER.SHIFTSALES:
                    return this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales();
                case DOTHER.DAYEND:
                    return this.dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend();
                default:
                    return false;
            }
        }

        private void inline_dother__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_dother != null)
                this.tmp_dother.istab_id = (int)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void inline_section__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_dother != null)
                this.tmp_dother.section_id = (int)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void inline_qty__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_dother != null)
                this.tmp_dother.qty = ((XNumEdit)sender)._Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.IsEditable() == false)
                return;

            this.bl_dother.Add(new dother
            {
                id = -1,
                salessummary_id = this.salessummary != null ? (int?)this.salessummary.id : null,
                dayend_id = this.dayend != null ? (int?)this.dayend.id : null,
                istab_id = -1,
                qty = 0m,
                creby = this.main_form.loged_in_status.loged_in_user_name
            }.ToViewModel(this.main_form.working_express_db));

            this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typdes.Name].Selected = true;
            this.ResetControlState(FORM_MODE.ADD_ITEM);
            this.ShowInlineForm();
            switch (this.dother_type)
            {
                case DOTHER.SHIFTSALES:
                    this.inline_section.Focus();
                    break;
                case DOTHER.DAYEND:
                    this.inline_dother.Focus();
                    break;
                default:
                    this.inline_section.Focus();
                    break;
            }
            SendKeys.Send("{F6}");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.IsEditable() == false)
                return;

            this.ResetControlState(FORM_MODE.EDIT_ITEM);
            this.ShowInlineForm();
            this.inline_qty.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            int focused_id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value;

            this.RemoveInlineForm();
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ_ITEM);

            if(this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == focused_id).FirstOrDefault() != null)
            {
                this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == focused_id).First().Cells[this.col_typdes.Name].Selected = true;
            }
            else
            {
                if(this.dgv.Rows.Count > 0)
                {
                    this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typdes.Name].Selected = true;
                }
            }

            this.ActiveControl = this.dgv;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsEditable() == false)
                return;

            if(this.tmp_dother.section_id == -1)
            {
                XMessageBox.Show("กรุณาระบุเลขที่ถัง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.inline_section.Focus();
                SendKeys.Send("{F6}");
                return;
            }
            if (this.tmp_dother.istab_id == -1)
            {
                XMessageBox.Show("กรุณาระบุรายละเอียดการหักฯ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.inline_dother.Focus();
                SendKeys.Send("{F6}");
                return;
            }
            if(this.tmp_dother.qty <= 0)
            {
                XMessageBox.Show("ปริมาณต้องมากกว่า 0", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                this.inline_qty.Focus();
                return;
            }
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    if (this.form_mode == FORM_MODE.ADD_ITEM)
                    {
                        this.tmp_dother.cretime = DateTime.Now;
                        db.dother.Add(this.tmp_dother);

                        if (this.dother_type == DOTHER.SHIFTSALES)
                        {
                            var sales_to_update = db.salessummary.Find(this.salessummary.id);
                            sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            sales_to_update.chgtime = DateTime.Now;

                            var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                            shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            shiftsales_to_update.chgtime = DateTime.Now;
                        }
                        else if (this.dother_type == DOTHER.DAYEND)
                        {
                            var dayend_to_update = db.dayend.Find(this.dayend.id);
                            dayend_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            dayend_to_update.chgtime = DateTime.Now;
                        }

                        db.SaveChanges();
                        this.SaveAddLog(this.tmp_dother);
                        this.RemoveInlineForm();
                        this.ResetControlState(FORM_MODE.READ_ITEM);
                        this.btnAdd.PerformClick();

                        return;
                    }

                    if (this.form_mode == FORM_MODE.EDIT_ITEM)
                    {
                        var dother_to_update = db.dother.Find(this.tmp_dother.id);

                        if (dother_to_update == null)
                        {
                            XMessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            return;
                        }

                        dother_to_update.istab_id = this.tmp_dother.istab_id;
                        dother_to_update.qty = this.tmp_dother.qty;
                        dother_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        dother_to_update.chgtime = DateTime.Now;

                        if (this.dother_type == DOTHER.SHIFTSALES)
                        {
                            var sales_to_update = db.salessummary.Find(this.salessummary.id);
                            sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            sales_to_update.chgtime = DateTime.Now;

                            var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                            shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            shiftsales_to_update.chgtime = DateTime.Now;
                        }
                        else
                        {
                            var dayend_to_update = db.dayend.Find(this.dayend.id);
                            dayend_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            dayend_to_update.chgtime = DateTime.Now;
                        }

                        db.SaveChanges();
                        this.SaveEditLog(this.tmp_dother);
                        this.RemoveInlineForm();
                        this.ResetControlState(FORM_MODE.READ_ITEM);

                        return;
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void SaveAddLog(dother dother)
        {
            if (this.dother_type == DOTHER.SHIFTSALES)
            {
                this.main_form.islog.AddData(this.menu_id, "เพิ่มรายการหักอื่น ๆ ในบันทึกรายการประจำผลัด \"" + this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name + "\", วันที่ " + this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + this.salessummary.stkcod + "\"" , this.salessummary.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name + "|" + this.salessummary.stkcod, "dother", dother.id).Save();
                return;
            }

            if (this.dother_type == DOTHER.DAYEND)
            {
                this.main_form.islog.AddData(this.menu_id, "เพิ่มรายการหักอื่น ๆ ในบันทึกปิดยอดขายประจำวันที่ " + this.dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + this.dayend.stkcod + "\"", this.dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.dayend.stkcod, "dother", dother.id).Save();
                return;
            }
        }

        private void SaveEditLog(dother dother)
        {
            if(this.dother_type == DOTHER.SHIFTSALES)
            {
                this.main_form.islog.EditData(this.menu_id, "แก้ไขรายการหักอื่น ๆ ในบันทึกรายการประจำผลัด \"" + this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name + "\", วันที่ " + this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + this.salessummary.stkcod + "\"", this.salessummary.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name + "|" + this.salessummary.stkcod, "dother", dother.id).Save();
                return;
            }

            if(this.dother_type == DOTHER.DAYEND)
            {
                this.main_form.islog.EditData(this.menu_id, "แก้ไขรายการหักอื่น ๆ ในบันทึกปิดยอดขายประจำวันที่ " + this.dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + this.dayend.stkcod + "\"", this.dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.dayend.stkcod, "dother", dother.id).Save();
                return;
            }
        }

        private void SaveDeleteLog(dother dother)
        {
            if (this.dother_type == DOTHER.SHIFTSALES)
            {
                this.main_form.islog.DeleteData(this.menu_id, "ลบรายการหักอื่น ๆ ในบันทึกรายการประจำผลัด \"" + this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name + "\", วันที่ " + this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + this.salessummary.stkcod + "\"", this.salessummary.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name + "|" + this.salessummary.stkcod, "dother", dother.id).Save();
                return;
            }

            if (this.dother_type == DOTHER.DAYEND)
            {
                this.main_form.islog.DeleteData(this.menu_id, "ลบรายการหักอื่น ๆ ในบันทึกปิดยอดขายประจำวันที่ " + this.dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + this.dayend.stkcod + "\"", this.dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.dayend.stkcod, "dother", dother.id).Save();
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if (this.IsEditable() == false)
                return;

            var dother = (dother)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_dother.Name].Value;

            if(XMessageBox.Show("ลบ \"" + dother.ToViewModel(this.main_form.working_express_db).typdes + "\" : " + dother.qty + " ลิตร, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        var dother_to_delete = db.dother.Find(dother.id);
                        if(dother_to_delete == null)
                        {
                            XMessageBox.Show("ข้อมูลที่ต้องการลบไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            db.dother.Remove(dother_to_delete);

                            if(this.dother_type == DOTHER.SHIFTSALES)
                            {
                                var sales_to_update = db.salessummary.Find(this.salessummary.id);
                                sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                sales_to_update.chgtime = DateTime.Now;

                                var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                                shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                shiftsales_to_update.chgtime = DateTime.Now;
                            }
                            else if(this.dother_type == DOTHER.DAYEND)
                            {
                                var dayend_to_update = db.dayend.Find(this.dayend.id);
                                dayend_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                dayend_to_update.chgtime = DateTime.Now;
                            }

                            db.SaveChanges();
                            this.SaveDeleteLog(dother_to_delete);

                            this.bl_dother.Remove(this.bl_dother.Where(d => d.id == dother_to_delete.id).First());
                            this.FillForm();
                            this.ResetControlState(FORM_MODE.READ_ITEM);
                        }
                    }
                    catch (Exception ex)
                    {
                        XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_typdes.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม <Alt+A>");
                mnu_add.Click += delegate
                {
                    this.btnAdd.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ <Alt+D>");
                mnu_delete.Click += delegate
                {
                    this.btnDelete.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void DialogDother_Deactivate(object sender, EventArgs e)
        {
            //this.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return true;
                }
                else
                {
                    this.btnStop.PerformClick();
                    return true;
                }
            }

            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if (this.inline_qty._Focused)
                    {
                        this.btnSave.PerformClick();
                        return true;
                    }
                    if (this.inline_section._Focused)
                    {
                        SendKeys.Send("{TAB}");
                        SendKeys.Send("{F6}");
                    }
                    if (this.inline_dother._Focused)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    return true;
                }
            }

            if (keyData == (Keys.Alt | Keys.A))
            {
                this.btnAdd.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                if(this.form_mode == FORM_MODE.READ_ITEM)
                {
                    if (this.dgv.CurrentCell == null)
                        return false;

                    dother dother = (dother)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_dother.Name].Value;

                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var total_recs = db.dother.AsEnumerable().Count();
                        var data_info = db.dother.Find(dother.id);

                        if(data_info == null)
                        {
                            return false;
                        }

                        DialogDataInfo info = new DialogDataInfo("Dother", dother.id, total_recs, dother.creby, dother.cretime, dother.chgby, dother.chgtime);
                        info.ShowDialog();
                        return true;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.btnEdit.PerformClick();
        }
    }
}
