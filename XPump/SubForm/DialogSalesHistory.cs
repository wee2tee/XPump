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
            this.form_mode = FORM_MODE.EDIT_ITEM;

            this.lblSaleDate.Text = this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.lblShiftName.Text = this.salessummary.ToViewModel().shift_name;
            this.lblStkdes.Text = this.salessummary.ToViewModel().stkcod + " / " + this.salessummary.ToViewModel().stkdes;

            this.salessummary = this.GetSalesSummary(this.salessummary.id);
            this.saleshistory = this.salessummary.saleshistory.ToList();
            this.bs = new BindingSource();
            this.bs.DataSource = this.saleshistory.ToViewModel();
            this.dgvNozzle.DataSource = this.bs;
            this.FillSummary();
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

        private void ResetControlState()
        {

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

                        salessummary ss = db.salessummary.Include("saleshistory").Where(s => s.id == sh.salessummary_id).First();
                        ss.total = ss.saleshistory.Sum(s => s.salqty);
                        ss.totqty = ss.total - ss.dtest - ss.dother;
                        ss.totval = ss.totqty * ss.ToViewModel().unitpr;
                        ss.netval = ss.totval - ss.ddisc;
                        ss.salvat = (ss.netval * 7) / 107;

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

        private void FillSummary()
        {
            this.lblTotal.Text = string.Format("{0:#,#0.00}", this.salessummary.total);
            this.lblTotqty.Text = string.Format("{0:#,#0.00}", this.salessummary.totqty);
            this.lblTotval.Text = string.Format("{0:#,#0.00}", this.salessummary.totval);
            this.lblNetqty.Text = string.Format("{0:#,#0.00}", this.salessummary.totqty);
            this.lblNetval.Text = string.Format("{0:#,#0.00}", this.salessummary.netval);
            this.lblSalvat.Text = string.Format("{0:#,#0.00}", this.salessummary.salvat);
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

        private void dgvNozzle_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.tmp_saleshistory != null)

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
                    this.inline_mit_start.Focus();
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
    }
}
