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
    public partial class FormShiftTransaction : Form
    {
        private MainForm main_form;
        private shiftsales curr_shiftsales;
        private shiftsales tmp_shiftsales;
        private List<salessummaryVM> sales_list;
        private BindingSource bs;
        private FORM_MODE form_mode;

        public FormShiftTransaction(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormShiftTransaction_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.brShift.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtSaldat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
            {
                if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        public shiftsales GetShiftSales(int id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shiftsales.Include("salessummary").Where(s => s.id == id).FirstOrDefault();
            }
        }

        private shiftsales GetFirst()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shiftsales.Include("salessummary").OrderBy(s => s.saldat).ThenBy(s => s.id).FirstOrDefault();
            }
        }

        private shiftsales GetPrevious()
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return this.GetFirst();

            using (xpumpEntities db = DBX.DataSet())
            {
                var id_list = db.salessummary.OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).Select(s => s.id).ToList<int>();

                if (id_list.IndexOf(this.curr_shiftsales.id) == -1)
                {
                    shiftsales tmp = db.shiftsales.OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).Where(s => this.curr_shiftsales.saldat.CompareTo(s.saldat) == 0 || this.curr_shiftsales.saldat.CompareTo(s.saldat) > 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        return tmp;
                    }
                    else
                    {
                        return this.GetFirst();
                    }
                }

                if (id_list.IndexOf(this.curr_shiftsales.id) == 0)
                {
                    return this.GetShiftSales(this.curr_shiftsales.id);
                }

                if (id_list.IndexOf(this.curr_shiftsales.id) > 0)
                {
                    int target_index = id_list.IndexOf(this.curr_shiftsales.id) - 1;
                    return this.GetShiftSales(id_list[target_index]);
                }

                return null;
            }
        }

        private shiftsales GetNext()
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return this.GetLast();

            using (xpumpEntities db = DBX.DataSet())
            {
                var id_list = db.salessummary.OrderBy(s => s.saldat).ThenBy(s => s.id).Select(s => s.id).ToList<int>();

                if (id_list.IndexOf(this.curr_shiftsales.id) == -1)
                {
                    shiftsales tmp = db.shiftsales.Include("salessummary").OrderBy(s => s.saldat).ThenBy(s => s.id).Where(s => this.curr_shiftsales.saldat.CompareTo(s.saldat) == 0 || this.curr_shiftsales.saldat.CompareTo(s.saldat) < 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        return tmp;
                    }
                    else
                    {
                        return this.GetLast();
                    }
                }
                
                if (id_list.IndexOf(this.curr_shiftsales.id) == 0)
                {
                    return this.GetShiftSales(this.curr_shiftsales.id);
                }

                if (id_list.IndexOf(this.curr_shiftsales.id) > 0)
                {
                    int target_index = id_list.IndexOf(this.curr_shiftsales.id) - 1;
                    return this.GetShiftSales(id_list[target_index]);
                }
            }

            return null;
        }

        private shiftsales GetLast()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shiftsales.Include("salessummary").OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).FirstOrDefault();
            }
        }

        private void FillForm(shiftsales shift_sales = null)
        {
            shiftsales sales = shift_sales != null ? shift_sales : this.curr_shiftsales;

            if(sales == null)
            {
                this.brShift._Text = string.Empty;
                this.dtSaldat._SelectedDate = null;
                this.dgv.Rows.Clear();
                return;
            }

            using (xpumpEntities db = DBX.DataSet())
            {
                this.brShift._Text = db.shift.Find(sales.shift_id) != null ? db.shift.Find(sales.shift_id).name : string.Empty;
            }
            this.dtSaldat._SelectedDate = sales.saldat;
            this.sales_list = sales.salessummary.ToList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.sales_list;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_stkcod.DataPropertyName).First().DisplayIndex = 0;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_stkdes.DataPropertyName).First().DisplayIndex = 1;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_totqty.DataPropertyName).First().DisplayIndex = 2;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().DisplayIndex = 3;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_totval.DataPropertyName).First().DisplayIndex = 4;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_ddisc.DataPropertyName).First().DisplayIndex = 5;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_netval.DataPropertyName).First().DisplayIndex = 6;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tmp_shiftsales = new shiftsales
            {
                id = -1,
                saldat = DateTime.Now,
                shift_id = -1
            };

            this.FillForm(this.tmp_shiftsales);

            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.toolStrip1.Focus();
            this.brShift.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            this.tmp_shiftsales = this.GetShiftSales(this.curr_shiftsales.id);
            this.FillForm(this.tmp_shiftsales);

            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.toolStrip1.Focus();
            this.brShift.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.FillForm();
            this.tmp_shiftsales = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT)
            {

                return;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetFirst();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetPrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetLast();
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

        private void btnItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void dtSaldat__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_shiftsales != null)
                this.tmp_shiftsales.saldat = ((XDatePicker)sender)._SelectedDate.HasValue ? ((XDatePicker)sender)._SelectedDate.Value : DateTime.Now;
        }

        private void dtSaldat__Leave(object sender, EventArgs e)
        {
            if (!((XDatePicker)sender)._SelectedDate.HasValue)
            {
                ((XDatePicker)sender)._SelectedDate = DateTime.Now;
            }
        }

        private void brShift__ButtonClick(object sender, EventArgs e)
        {
            if (this.tmp_shiftsales != null)
            {
                DialogShiftSelector sel = new DialogShiftSelector(this.tmp_shiftsales.shift_id);
                if (sel.ShowDialog() == DialogResult.OK)
                {
                    ((XBrowseBox)sender)._Text = sel.selected_shift.name;
                    this.tmp_shiftsales.shift_id = sel.selected_shift.id;
                    ((XBrowseBox)sender).Focus();
                }
            }
        }

        private void brShift__Leave(object sender, EventArgs e)
        {
            if(this.tmp_shiftsales != null && this.tmp_shiftsales.shift_id < 0)
            {
                ((XBrowseBox)sender).Focus();
                //((XBrowseBox)sender).PerformButtonClick();
            }
        }
    }
}
