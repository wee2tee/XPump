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
        private salessummary salessummary;
        private List<saleshistory> saleshistory;
        private saleshistory tmp_saleshistory; // stored temporary data of editing saleshistory 
        private BindingSource bs;
        private FORM_MODE form_mode;

        public DialogSalesHistory()
        {
            InitializeComponent();
        }

        public DialogSalesHistory(salessummary salessummary)
            : this()
        {
            this.salessummary = salessummary;
        }

        private void DialogSalesHistory_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.lblSaleDate.Text = this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.lblShiftName.Text = this.salessummary.ToViewModel().shift_name;
            this.lblStkdes.Text = this.salessummary.ToViewModel().stkcod + " / " + this.salessummary.ToViewModel().stkdes;

            this.salessummary = this.GetSalesSummary(this.salessummary.id);
            this.saleshistory = this.salessummary.saleshistory.ToList();
            this.bs = new BindingSource();
            this.dgvNozzle.DataSource = this.bs;
            this.FillDgv();
            this.FillSummary();

            this.dgvNozzle.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode ==  FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if(MessageBox.Show("ข้อมูลที่ท่านกำลังแก้ไขจะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        private salessummary GetSalesSummary(int id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.salessummary.Include("saleshistory").Where(s => s.id == id).FirstOrDefault();
            }
        }

        private List<saleshistory> GetSalesHistory()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.saleshistory.Where(s => s.salessummary_id == this.salessummary.id).ToList();
            }
        }

        private saleshistory GetSalesHistoryById(int id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.saleshistory.Find(id);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.form_mode == FORM_MODE.EDIT)
            {
                using (Pen p0 = new Pen(Color.LimeGreen))
                {
                    using (Pen p = new Pen(Color.PaleGreen))
                    {
                        e.Graphics.DrawRectangle(p0, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                        e.Graphics.DrawRectangle(p, e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 3, e.ClipRectangle.Height - 3);
                    }
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (this.form_mode == FORM_MODE.READ_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                using (Pen p0 = new Pen(Color.LimeGreen))
                {
                    using (Pen p = new Pen(Color.PaleGreen))
                    {
                        e.Graphics.DrawRectangle(p0, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                        e.Graphics.DrawRectangle(p, e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 3, e.ClipRectangle.Height - 3);
                    }
                }
            }
        }

        private void ResetControlState()
        {
            this.dgvNozzle.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.numDtest.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numDother.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numDdisc.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numPurvat.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtDother.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnOK.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnCancel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);

            this.panel1.Refresh();
            this.panel3.Refresh();
        }

        private void ShowInlineForm(int row_index)
        {
            this.tmp_saleshistory = this.GetSalesHistoryById((int)this.dgvNozzle.Rows[row_index].Cells[this.col_id.Name].Value);

            int col_index = this.dgvNozzle.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_mitbeg.DataPropertyName).First().Index;
            Rectangle rect = this.dgvNozzle.GetCellDisplayRectangle(col_index, row_index, false);
            this.inline_mit_start.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 3);
            this.inline_mit_start._Value = this.tmp_saleshistory.mitbeg;
            this.inline_mit_start.Visible = true;

            col_index = this.dgvNozzle.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_mitend.DataPropertyName).First().Index;
            rect = this.dgvNozzle.GetCellDisplayRectangle(col_index, row_index, false);
            this.inline_mit_end.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 3);
            this.inline_mit_end._Value = this.tmp_saleshistory.mitend;
            this.inline_mit_end.Visible = true;

            this.inline_mit_start.Focus();
        }

        private void RemoveInlineForm()
        {
            if(this.inline_mit_start.Visible)
            {
                this.inline_mit_start.Visible = false;
            }

            if (this.inline_mit_end.Visible)
            {
                this.inline_mit_end.Visible = false;
            }

            this.tmp_saleshistory = null;
        }

        private void SaveTmpSalesHistory()
        {
            if (this.tmp_saleshistory == null)
                return;

            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    saleshistory sh = db.saleshistory.Find(this.tmp_saleshistory.id);

                    if (sh == null)
                    {
                        MessageBox.Show("ค้นหาข้อมูลเพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        sh.mitbeg = this.tmp_saleshistory.mitbeg;
                        sh.mitend = this.tmp_saleshistory.mitend;
                        sh.salqty = this.tmp_saleshistory.salqty;
                        sh.salval = this.tmp_saleshistory.salval;

                        db.SaveChanges();

                        this.salessummary = this.GetSalesSummary(this.salessummary.id);

                        int edited_row_index = this.dgvNozzle.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_saleshistory.id).First().Index;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_mitbeg.Name].Value = this.tmp_saleshistory.mitbeg;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_mitend.Name].Value = this.tmp_saleshistory.mitend;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_salqty.Name].Value = this.tmp_saleshistory.salqty;
                        this.dgvNozzle.Rows[edited_row_index].Cells[this.col_salval.Name].Value = this.tmp_saleshistory.salval;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).mitbeg = this.tmp_saleshistory.mitbeg;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).mitend = this.tmp_saleshistory.mitend;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).salqty = this.tmp_saleshistory.salqty;
                        ((saleshistory)this.dgvNozzle.Rows[edited_row_index].Cells[this.col_saleshistory.Name].Value).salval = this.tmp_saleshistory.salval;

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
        //    using (xpumpEntities db = DBX.DataSet())
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
        //    using (xpumpEntities db = DBX.DataSet())
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
            this.FillDgv();
            this.FillSummary();
        }

        private void FillDgv()
        {
            this.saleshistory = this.salessummary.saleshistory.ToList();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.saleshistory.ToViewModel();
        }

        private void FillSummary()
        {
            this.lblTotal.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().total);
            this.lblTotqty.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().totqty);
            this.lblTotval.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().totval);
            this.lblNetqty.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().totqty);
            this.lblNetval.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().netval);
            this.lblSalvat.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().salvat);

            this.numDtest._Value = this.salessummary.dtest;
            this.numDother._Value = this.salessummary.dother;
            this.txtDother._Text = this.salessummary.dothertxt;
            this.numDdisc._Value = this.salessummary.ddisc;
            this.numPurvat._Value = this.salessummary.purvat;
        }

        private void numDtest__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.dtest = ((XNumEdit)sender)._Value;
        }

        private void numDother__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.dother = ((XNumEdit)sender)._Value;
        }

        private void numDdisc__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.ddisc = ((XNumEdit)sender)._Value;
        }

        private void numPurvat__ValueChanged(object sender, EventArgs e)
        {
            this.salessummary.purvat = ((XNumEdit)sender)._Value;
        }

        private void txtDother__TextChanged(object sender, EventArgs e)
        {
            this.salessummary.dothertxt = ((XTextEdit)sender)._Text;
        }

        private void inline_mit_start__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_saleshistory != null)
            {
                this.tmp_saleshistory.mitbeg = ((XNumEdit)sender)._Value;
                this.tmp_saleshistory.salqty = this.tmp_saleshistory.mitend - this.tmp_saleshistory.mitbeg;
                this.tmp_saleshistory.salval = this.tmp_saleshistory.salqty * this.salessummary.ToViewModel().unitpr;
            }
        }

        private void inline_mit_end__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_saleshistory != null)
            {
                this.tmp_saleshistory.mitend = ((XNumEdit)sender)._Value;
                this.tmp_saleshistory.salqty = this.tmp_saleshistory.mitend - this.tmp_saleshistory.mitbeg;
                this.tmp_saleshistory.salval = this.tmp_saleshistory.salqty * this.salessummary.ToViewModel().unitpr;
            }
        }

        private void PerformEditSummary(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.btnCancel.Focus();

            ((Control)sender).Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                salessummary sales_to_update = db.salessummary.Find(this.salessummary.id);
                if (sales_to_update == null)
                {
                    MessageBox.Show("ค้นหาข้อมูลที่ต้องการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                sales_to_update.dtest = this.salessummary.dtest;
                sales_to_update.dother = this.salessummary.dother;
                sales_to_update.dothertxt = this.salessummary.dothertxt;
                sales_to_update.ddisc = this.salessummary.ddisc;
                sales_to_update.purvat = this.salessummary.purvat;

                db.SaveChanges();
            }

            this.salessummary = this.GetSalesSummary(this.salessummary.id);
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.FillForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.salessummary = this.GetSalesSummary(this.salessummary.id);
            this.FillForm();
        }

        private void dgvNozzle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && ((XDatagrid)sender).CurrentCell != null)
            {
                if (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(e.RowIndex);
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
            if(keyData == Keys.F8)
            {
                if(this.form_mode == FORM_MODE.READ)
                {
                    this.form_mode = FORM_MODE.READ_ITEM;
                    this.ResetControlState();
                    return true;
                }
            }

            if(keyData == (Keys.Alt | Keys.E))
            {
                if(this.form_mode == FORM_MODE.READ)
                {
                    this.form_mode = FORM_MODE.EDIT;
                    this.ResetControlState();
                    this.numDtest.Focus();
                    return true;
                }

                if(this.form_mode == FORM_MODE.READ_ITEM)
                {
                    if (this.dgvNozzle.Rows.Count > 0 && this.dgvNozzle.CurrentCell != null)
                    {
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
                if(this.inline_mit_start.Visible && this.inline_mit_end.Visible && this.inline_mit_start._Focused)
                {
                    this.inline_mit_end.Focus();
                    return true;
                }

                if (this.inline_mit_start.Visible && this.inline_mit_end.Visible && this.inline_mit_end._Focused)
                {
                    if(this.dgvNozzle.CurrentCell.RowIndex < this.dgvNozzle.Rows.Count - 1)
                    {
                        this.dgvNozzle.Rows[this.dgvNozzle.CurrentCell.RowIndex + 1].Cells[this.col_nozzle_name.Name].Selected = true;
                        return true;
                    }
                    else
                    {
                        this.SaveTmpSalesHistory();
                        this.RemoveInlineForm();
                        this.form_mode = FORM_MODE.EDIT;
                        this.ResetControlState();
                        this.numDtest.Focus();
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
                if (this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    this.form_mode = FORM_MODE.READ_ITEM;
                    this.ResetControlState();
                    this.RemoveInlineForm();

                    this.FillDgv();
                    return true;
                }

                if(this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.form_mode = FORM_MODE.READ;
                    this.ResetControlState();
                    return true;
                }

                if(this.form_mode == FORM_MODE.EDIT)
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
