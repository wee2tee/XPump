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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class FormSttak : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        //private DateTime selected_date;
        private List<shiftsttak> sttak;
        private shiftsttak tmp_sttak;
        private BindingSource bs;

        public FormSttak(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
        //    {
        //        if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }

        //    this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
        //    base.OnFormClosing(e);
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void FormSttak_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.btnLast.PerformClick();
        }

        private List<shiftsttak> GetSttak(DateTime takdat)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.shiftsttak.Where(s => s.takdat == takdat).ToList();
            }
        }

        private void FillForm(List<shiftsttak> sttak_to_fill = null)
        {
            List<shiftsttak> sttak = sttak_to_fill != null ? sttak_to_fill : this.sttak;

            if(sttak == null)
            {
                sttak = new List<shiftsttak>();
            }

            this.dtTakDat._SelectedDate = sttak == null || sttak.Count == 0 ? null : (DateTime?)sttak.First().takdat;
            this.bs.ResetBindings(true);
            this.bs.DataSource = sttak.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.stkcod).ThenBy(s => s.tank_name).ThenBy(s => s.section_name).ToList();
        }

        private void ResetControlState()
        {
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

        }

        private void ShowInlineForm(int row_index)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_sttak = (shiftsttak)this.dgv.Rows[row_index].Cells[this.col_sttak.Name].Value;
            this.inline_qty._Value = this.tmp_sttak.qty;

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_qty.DataPropertyName).First().Index;
            
            this.inline_qty.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.inline_qty.Visible = true;
            this.inline_qty.Focus();
        }

        private void RemoveInlineForm()
        {
            this.inline_qty.Visible = false;
            this.tmp_sttak = null;
        }

        private void inline_qty__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_sttak != null)
            {
                this.tmp_sttak.qty = ((XNumEdit)sender)._Value;
                this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_qty.Name].Value = ((XNumEdit)sender)._Value;
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.tmp_sttak != null)
            {
                if((int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_id.Name].Value == this.tmp_sttak.id) // same row
                {
                    this.inline_qty.Focus();
                }
                else // new row
                {
                    this.SaveSttak();
                    this.RemoveInlineForm();
                    this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);
                }
            }
        }

        private void SaveSttak()
        {
            if (this.tmp_sttak == null)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    shiftsttak sttak_to_update = db.shiftsttak.Find(this.tmp_sttak.id);
                    if (sttak_to_update == null)
                    {
                        MessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        sttak_to_update.qty = this.tmp_sttak.qty;
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDateSelector ds = new DialogDateSelector("วันที่ตรวจนับ", DateTime.Now);
            if(ds.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    if(db.shiftsttak.Where(s => s.takdat == ds.selected_date).Count() > 0) // is exist
                    {
                        if(MessageBox.Show("ข้อมูลตรวจนับของวันที่ " + ds.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + " มีอยู่แล้ว, ต้องการเรียกดูข้อมูลดังกล่าวหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.sttak = this.GetSttak(ds.selected_date);
                            this.FillForm();
                        }
                    }
                    else // not exist
                    {
                        try
                        {
                            var sections = db.section.Include("tank")
                                        .Where(s => s.tank.startdate.CompareTo(ds.selected_date) <= 0)
                                        .Where(s => s.tank.isactive)
                                        .Where(s => !s.tank.enddate.HasValue || s.tank.enddate.Value.CompareTo(ds.selected_date) >= 0).ToList();

                            foreach (section sec in sections)
                            {
                                shiftsttak s = new shiftsttak
                                {
                                    section_id = sec.id,
                                    takdat = ds.selected_date,
                                    qty = -1
                                };
                                db.shiftsttak.Add(s);
                            }

                            db.SaveChanges();

                            this.sttak = this.GetSttak(ds.selected_date);
                            this.FillForm();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.ShowInlineForm(this.dgv.CurrentCell.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if(MessageBox.Show("ลบข้อมูลตรวจนับของวันที่ " + this.sttak.First().takdat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + " ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        DateTime takdat = this.sttak.First().takdat;
                        int[] deleting_ids = db.shiftsttak.Where(s => s.takdat == takdat).Select(s => s.id).ToArray();
                        for (int i = 0; i < deleting_ids.Count(); i++)
                        {
                            db.shiftsttak.Remove(db.shiftsttak.Find(deleting_ids[i]));
                        }
                        db.SaveChanges();

                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รายการตรวจนับวันที่ ", this.sttak.First().takdat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            this.RemoveInlineForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveSttak();
            this.RemoveInlineForm();
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                shiftsttak tmp = db.shiftsttak.OrderByDescending(s => s.takdat).FirstOrDefault();

                if(tmp == null)
                {
                    this.sttak = null;
                }
                else
                {
                    this.sttak = this.GetSttak(tmp.takdat);
                }

                this.FillForm();
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {

        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {

        }
    }
}
