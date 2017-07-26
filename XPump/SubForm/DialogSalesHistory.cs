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
    public partial class DialogSalesHistory : Form
    {
        private MainForm main_form;
        private salessummary salessummary;
        private List<pricelist> price_list;
        private List<saleshistory> saleshistory;
        private saleshistory tmp_saleshistory; // stored temporary data of editing saleshistory 
        private BindingSource bs_sales;
        private BindingSource bs_price;
        private FORM_MODE form_mode;
        private FormShiftTransaction form_shifttransaction;

        public DialogSalesHistory(MainForm main_form, FormShiftTransaction form_shifttransaction)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.form_shifttransaction = form_shifttransaction;
        }

        public DialogSalesHistory(MainForm main_form, FormShiftTransaction form_shifttransaction, salessummary salessummary)
            : this(main_form, form_shifttransaction)
        {
            this.salessummary = salessummary;
        }

        private void DialogSalesHistory_Load(object sender, EventArgs e)
        {
            this.RemoveInlineForm();

            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.lblSaleDate.Text = this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.lblShiftName.Text = this.salessummary.ToViewModel(this.main_form.working_express_db).shift_name;
            this.lblStkdes.Text = this.salessummary.ToViewModel(this.main_form.working_express_db).stkcod + " / " + this.salessummary.ToViewModel(this.main_form.working_express_db).stkdes;

            this.salessummary = this.GetSalesSummary(this.salessummary.id);
            //this.salessummary.purvat = this.salessummary.GetPurVatFromExpress(this.main_form.working_express_db);
            this.saleshistory = this.salessummary.saleshistory.ToList();
            this.bs_sales = new BindingSource();
            this.dgvNozzle.DataSource = this.bs_sales;
            this.FillDgvSales();

            this.bs_price = new BindingSource();
            this.dgvPrice.DataSource = this.bs_price;
            this.FillDgvPrice();

            this.FillSummary();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode ==  FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if(XMessageBox.Show("ข้อมูลที่ท่านกำลังแก้ไขจะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        private List<pricelist> GetPriceList()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                int[] price_id_list = db.salessummary.Where(s => s.shiftsales_id == this.salessummary.shiftsales_id).Select(s => s.pricelist_id).ToArray();
                return db.pricelist.Where(p => price_id_list.Contains<int>(p.id)).ToList();
            }
        }

        private salessummary GetSalesSummary(int id)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.salessummary.Include("shiftsales").Include("saleshistory").Where(s => s.id == id).FirstOrDefault();
            }
        }

        private List<saleshistory> GetSalesHistory()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.saleshistory.Where(s => s.salessummary_id == this.salessummary.id).ToList();
            }
        }

        private saleshistory GetSalesHistoryById(int id)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.saleshistory.Find(id);
            }
        }

        private void ResetControlState()
        {
            this.dgvNozzle.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM/*, FORM_MODE.EDIT_ITEM*/ }, this.form_mode);
            this.numDtest.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnDother.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.numDdisc.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numPurvat.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnSyncPurvat.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnOK.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnCancel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);


            this.dgvNozzle.TabStop = this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;
            this.numDtest.TabStop = this.form_mode == FORM_MODE.EDIT ? true : false;
            this.numDdisc.TabStop = this.form_mode == FORM_MODE.EDIT ? true : false;
            this.numPurvat.TabStop = this.form_mode == FORM_MODE.EDIT ? true : false;
        }

        private void ShowInlineForm(int row_index)
        {
            this.tmp_saleshistory = this.GetSalesHistoryById((int)this.dgvNozzle.Rows[row_index].Cells[this.col_id.Name].Value);

            int col_index = this.dgvNozzle.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_mitbeg.DataPropertyName).First().Index;
            this.inline_mit_start.SetInlineControlPosition(this.dgvNozzle, this.dgvNozzle.CurrentCell.RowIndex, col_index);
            this.inline_mit_start._Value = this.tmp_saleshistory.mitbeg < 0 ? this.tmp_saleshistory.ToViewModel(this.main_form.working_express_db).SetMitBeg().mitbeg : this.tmp_saleshistory.mitbeg;

            col_index = this.dgvNozzle.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_mitend.DataPropertyName).First().Index;
            this.inline_mit_end.SetInlineControlPosition(this.dgvNozzle, this.dgvNozzle.CurrentCell.RowIndex, col_index);
            this.inline_mit_end._Value = this.tmp_saleshistory.mitend < 0 ? 0 : this.tmp_saleshistory.mitend;
        }

        private void RemoveInlineForm()
        {
            this.inline_mit_start.SetBounds(-9999, 0, 0, 0);
            this.inline_mit_end.SetBounds(-9999, 0, 0, 0);

            this.tmp_saleshistory = null;
        }

        private void SaveTmpSalesHistory()
        {
            if (this.tmp_saleshistory == null)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    saleshistory sh = db.saleshistory.Find(this.tmp_saleshistory.id);

                    if (sh == null)
                    {
                        XMessageBox.Show("ค้นหาข้อมูลเพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                    else
                    {
                        sh.mitbeg = this.tmp_saleshistory.mitbeg;
                        sh.mitend = this.tmp_saleshistory.mitend;
                        sh.salqty = this.tmp_saleshistory.salqty;
                        //sh.salval = this.tmp_saleshistory.salval;
                        sh.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        sh.chgtime = DateTime.Now;

                        salessummary sales_to_update = db.salessummary.Find(sh.salessummary_id);
                        sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        sales_to_update.chgtime = DateTime.Now;

                        shiftsales shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                        shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        shiftsales_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();

                        this.main_form.islog.EditData(this.form_shifttransaction.menu_id, "แก้ไขยอดขายของหัวจ่าย \"" + this.tmp_saleshistory.ToViewModel(this.main_form.working_express_db).nozzle_name + "\" ในบันทึกรายการประจำผลัด \"" + this.form_shifttransaction.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + "\" วันที่ " + this.form_shifttransaction.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.salessummary.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.form_shifttransaction.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "saleshistory", this.tmp_saleshistory.id).Save();

                        this.salessummary = this.GetSalesSummary(this.salessummary.id);

                        int edited_row_index = this.dgvNozzle.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_saleshistory.id).First().Index;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_mitbeg.Name].Value = this.tmp_saleshistory.mitbeg;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_mitend.Name].Value = this.tmp_saleshistory.mitend;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_salqty.Name].Value = this.tmp_saleshistory.salqty;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_salval.Name].Value = this.tmp_saleshistory.ToViewModel(this.main_form.working_express_db).salval;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).mitbeg = this.tmp_saleshistory.mitbeg;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).mitend = this.tmp_saleshistory.mitend;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).salqty = this.tmp_saleshistory.salqty;
                        //((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).salval = this.tmp_saleshistory.salval;

                        this.FillSummary();
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("ข้อมูลที่ท่านต้องการแก้ไข", "");
                }
            }
        }

        //public salessummary ReCalculateSalesSummary(salessummary latest_data_of_salessummary)
        //{
        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {
        //        salessummary sales_to_cal = db.salessummary.Include("saleshistory").Where(s => s.id == latest_data_of_salessummary.id).FirstOrDefault();
        //        if (sales_to_cal == null)
        //            return null;

        //        sales_to_cal.dtest = latest_data_of_salessummary.dtest;
        //        sales_to_cal.dother = latest_data_of_salessummary.dother;
        //        sales_to_cal.dothertxt = latest_data_of_salessummary.dothertxt;
        //        sales_to_cal.ddisc = latest_data_of_salessummary.ddisc;
        //        sales_to_cal.purvat = latest_data_of_salessummary.purvat;

        //        return sales_to_cal;
        //    }
        //}

        //public void UpdateSalesSummary(salessummary salessummary_to_update)
        //{
        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {
        //        try
        //        {
        //            salessummary sales_to_update = db.salessummary.Find(salessummary_to_update.id);
        //            if (sales_to_update == null)
        //                return;

        //            sales_to_update.dtest = salessummary_to_update.dtest;
        //            sales_to_update.dother = salessummary_to_update.dother;
        //            sales_to_update.dothertxt = salessummary_to_update.dothertxt;
        //            sales_to_update.ddisc = salessummary_to_update.ddisc;
        //            sales_to_update.purvat = salessummary_to_update.purvat;

        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.ShowMessage("", "");
        //        }
        //    }
        //}

        private void FillForm()
        {
            this.FillDgvSales();
            this.FillSummary();
            this.ActiveControl = this.dgvNozzle;
        }

        private void FillDgvSales()
        {
            this.saleshistory = this.salessummary.saleshistory.ToList();
            this.bs_sales.ResetBindings(true);
            var sh_list = this.saleshistory.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.tank_name).ThenBy(s => s.section_name).ThenBy(s => s.nozzle_name).ToList();
            this.bs_sales.DataSource = sh_list;
        }

        private void FillDgvPrice()
        {
            this.price_list = this.GetPriceList();
            this.bs_price.ResetBindings(true);
            this.bs_price.DataSource = this.price_list.ToViewModel(this.main_form.working_express_db);
        }

        private void FillSummary()
        {
            this.lblTotal.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).total);
            this.lblDother.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).dother);
            this.lblTotqty.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).totqty);
            this.lblTotval.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).totval);
            this.lblNetqty.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).totqty);
            this.lblNetval.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).netval);
            this.lblSalvat.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel(this.main_form.working_express_db).salvat);

            this.numPurvat._Value = this.salessummary.ToViewModel(this.main_form.working_express_db).purvat;
            this.numDtest._Value = this.salessummary.dtest;
            this.numDdisc._Value = this.salessummary.ddisc;
        }

        private void numDtest__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.dtest = ((XNumEdit)sender)._Value;
        }

        private void numDdisc__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.ddisc = ((XNumEdit)sender)._Value;
        }

        private void numPurvat__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.purvat = ((XNumEdit)sender)._Value;
        }

        private void inline_mit_start__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_saleshistory != null)
            {
                this.tmp_saleshistory.mitbeg = ((XNumEdit)sender)._Value;
                this.tmp_saleshistory.salqty = this.tmp_saleshistory.mitend - this.tmp_saleshistory.mitbeg;
                //this.tmp_saleshistory.salval = this.tmp_saleshistory.salqty * this.salessummary.ToViewModel(this.main_form.working_express_db).unitpr;
            }
        }

        private void inline_mit_end__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_saleshistory != null)
            {
                this.tmp_saleshistory.mitend = ((XNumEdit)sender)._Value;
                this.tmp_saleshistory.salqty = this.tmp_saleshistory.mitend - this.tmp_saleshistory.mitbeg;
                //this.tmp_saleshistory.salval = this.tmp_saleshistory.salqty * this.salessummary.ToViewModel(this.main_form.working_express_db).unitpr;
            }
        }

        private void PerformEditSummary(object sender, EventArgs e)
        {
            if (this.form_mode == FORM_MODE.EDIT)
                return;

            if (this.form_mode == FORM_MODE.EDIT_ITEM)
                this.btnOK.PerformClick();

            if (this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
                return;

            if (this.main_form.loged_in_status.is_secure && (this.form_shifttransaction.scacclv == null || (this.form_shifttransaction.scacclv != null && this.form_shifttransaction.scacclv.edit == "N")))
                return;

            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();

            ((Control)sender).Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
                return;

            if (this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.SaveTmpSalesHistory();
                this.RemoveInlineForm();
                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();
                return;
            }

            if(this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    salessummary sales_to_update = db.salessummary.Find(this.salessummary.id);
                    if (sales_to_update == null)
                    {
                        XMessageBox.Show("ค้นหาข้อมูลที่ต้องการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }

                    sales_to_update.dtest = this.salessummary.dtest;
                    sales_to_update.ddisc = this.salessummary.ddisc;
                    sales_to_update.purvat = this.salessummary.purvat;
                    sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    sales_to_update.chgtime = DateTime.Now;

                    shiftsales shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                    shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    shiftsales_to_update.chgtime = DateTime.Now;

                    db.SaveChanges();
                    this.main_form.islog.EditData(this.form_shifttransaction.menu_id, "แก้ไขรายละเอียดการขายสินค้ารหัส \"" + this.salessummary.stkcod + "\" ในบันทึกรายการประจำผลัด \"" + this.form_shifttransaction.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + "\" วันที่ " + this.form_shifttransaction.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.salessummary.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.form_shifttransaction.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "salessummary", this.salessummary.id).Save();
                }

                this.salessummary = this.GetSalesSummary(this.salessummary.id);
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.FillForm();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.salessummary = this.GetSalesSummary(this.salessummary.id);
            this.FillForm();
        }

        private void dgvNozzle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
                return;

            /* disable editing depend on scacclv */
            if (this.main_form.loged_in_status.is_secure && (this.form_shifttransaction.scacclv == null || (this.form_shifttransaction.scacclv != null && this.form_shifttransaction.scacclv.edit == "N")))
                return;

            if (e.RowIndex > -1 && ((XDatagrid)sender).CurrentCell != null)
            {
                if (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(e.RowIndex);
                    this.inline_mit_start.Focus();
                    return;
                }
                if(this.form_mode == FORM_MODE.EDIT_ITEM && this.inline_mit_start.Visible)
                {
                    this.inline_mit_start.Focus();
                }
            }
            
        }

        private void dgvNozzle_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.form_mode != FORM_MODE.EDIT_ITEM)
                return;

            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if (this.tmp_saleshistory == null)
            {
                this.form_mode = FORM_MODE.EDIT_ITEM;
                this.ResetControlState();
                this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);
            }
            else
            {
                if ((int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_id.Name].Value == this.tmp_saleshistory.id)
                {
                    if (this.inline_mit_start.Visible)
                    {
                        this.inline_mit_start.Focus();
                    }
                    return;
                }
                else
                {
                    this.SaveTmpSalesHistory();
                    this.RemoveInlineForm();
                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);
                }
            }

            if (((XDatagrid)sender).CurrentCell.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_mitbeg.DataPropertyName).First().Index)
            {
                this.inline_mit_start.Focus();
                return;
            }

            if (((XDatagrid)sender).CurrentCell.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_mitend.DataPropertyName).First().Index)
            {
                this.inline_mit_end.Focus();
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.E))
            {
                if(this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
                {
                    if (this.dgvNozzle.Rows.Count > 0 && this.dgvNozzle.CurrentCell != null)
                    {
                        if (this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
                            return true;

                        this.dgvNozzle.Rows[0].Cells[this.col_mitbeg.Name].Selected = true;
                        this.form_mode = FORM_MODE.EDIT_ITEM;
                        this.ResetControlState();
                        this.ShowInlineForm(this.dgvNozzle.CurrentCell.RowIndex);
                        this.inline_mit_start.Focus();
                    }
                    return true;
                }
            }

            if(keyData == Keys.Enter)
            {
                if(this.inline_mit_start._Focused)
                {
                    this.inline_mit_end.Focus();
                    return true;
                }

                if (this.inline_mit_end._Focused)
                {
                    if(this.dgvNozzle.CurrentCell.RowIndex < this.dgvNozzle.Rows.Count - 1)
                    {
                        this.dgvNozzle.Rows[this.dgvNozzle.CurrentCell.RowIndex + 1].Cells[this.col_nozzle_name.Name].Selected = true;
                        this.ShowInlineForm(this.dgvNozzle.CurrentCell.RowIndex);
                        this.inline_mit_start.Focus();
                        return true;
                    }
                    else
                    {
                        this.SaveTmpSalesHistory();
                        this.RemoveInlineForm();
                        this.form_mode = FORM_MODE.EDIT;
                        this.ResetControlState();
                        this.numDtest.textBox1.Focus();
                        return true;
                    }
                }

                if(this.form_mode == FORM_MODE.EDIT)
                {
                    if (this.numPurvat._Focused)
                    {
                        this.btnOK.PerformClick();
                        return true;
                    }

                    SendKeys.Send("{TAB}");
                    return true;
                }
            }
            
            if(keyData == Keys.Escape)
            {
                if(this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    this.btnCancel.PerformClick();
                    return true;
                }

                if(this.form_mode == FORM_MODE.READ)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                if(this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
                {
                    if (this.dgvNozzle.CurrentCell == null)
                        return false;

                    saleshistory s = (saleshistory)this.dgvNozzle.Rows[this.dgvNozzle.CurrentCell.RowIndex].Cells[this.col_saleshistory.Name].Value;

                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var total_recs = db.saleshistory.AsEnumerable().Count();
                        var data_info = db.saleshistory.Find(s.id);

                        if (data_info == null)
                            return false;

                        DialogDataInfo info = new DialogDataInfo("Saleshistory", data_info.id, total_recs, data_info.creby, data_info.cretime, data_info.chgby, data_info.chgtime);
                        info.ShowDialog();
                        return true;
                    }
                }
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-2.1.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvPrice_Paint(object sender, PaintEventArgs e)
        {
            foreach (DataGridViewRow row in ((XDatagrid)sender).Rows)
            {
                if ((int)row.Cells[this.col_price_id.Name].Value == this.salessummary.pricelist_id)
                {
                    row.DefaultCellStyle.Font = new Font("tahoma", 8f, FontStyle.Bold);
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                    ((XDatagrid)sender).Rows[row.Index].Cells[this.col_price_stkcod.Name].Selected = true;
                }
            }
        }

        private void inline_mit_start__GotFocus(object sender, EventArgs e)
        {
            ((XNumEdit)sender)._SelectionStart = ((XNumEdit)sender)._Text.Contains(".") ? ((XNumEdit)sender)._Text.IndexOf(".") : 0;
        }

        private void btnDother_Click(object sender, EventArgs e)
        {
            DialogDother d = new DialogDother(this.main_form, this.form_shifttransaction, this.salessummary);
            Point p = ((Button)sender).PointToScreen(Point.Empty);
            //d.SetBounds(((Button)sender).PointToScreen(Point.Empty).X + ((Button)sender).Width, ((Button)sender).PointToScreen(Point.Empty).Y, d.Width, d.Height);
            d.Location = new Point(p.X, p.Y + ((Button)sender).Height);
            d.ShowDialog();
            this.FillSummary();
        }

        private void btnSyncPurvat_Click(object sender, EventArgs e)
        {
            var exp_purvat = this.salessummary.GetPurVatFromExpress(this.main_form.working_express_db);

            if(this.salessummary.purvat != exp_purvat)
            {
                if(XMessageBox.Show("ภาษีซื้อของน้ำมันเชื้อเพลิง เปลี่ยนจาก " + string.Format("{0:#,#0.00}", this.salessummary.purvat) + " เป็น " + string.Format("{0:#,#0.00}", exp_purvat) + " ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.numPurvat._Value = exp_purvat;
                }
            }
            this.numPurvat.Focus();
        }

        private void dgvNozzle_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (!(this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM))
                    return;

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt + E>");
                mnu_edit.Click += delegate
                {
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_nozzle_name.Name].Selected = true;
                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(row_index);
                    this.inline_mit_start.Focus();
                };
                mnu_edit.Enabled = (!this.main_form.loged_in_status.is_secure || (this.form_shifttransaction.scacclv != null && this.form_shifttransaction.scacclv.edit == "Y")) ? true : false;
                cm.MenuItems.Add(mnu_edit);
                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }
        }
    }
}
