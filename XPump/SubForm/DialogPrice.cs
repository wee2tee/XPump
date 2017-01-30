﻿using System;
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
    public partial class DialogPrice : Form
    {
        private MainForm main_form;
        private List<stmasPriceVM> stmas_list;
        private BindingSource bs;
        private FORM_MODE form_mode;
        public List<pricelist> price_list = new List<pricelist>();

        public DialogPrice(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogPrice_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.bs = new BindingSource();
            this.stmas_list = this.GetStmasList();

            this.FillForm();

            this.inline_unitpr._GotFocus += delegate
            {
                if(this.inline_unitpr._Text != null && this.inline_unitpr._Text.Contains("."))
                    this.inline_unitpr._SelectionStart = this.inline_unitpr._Text.IndexOf(".");
            };

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ_ITEM)
            {
                if(MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnClosing(e);
        }

        private List<stmasPriceVM> GetStmasList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.stmas.OrderBy(s => s.name).ToList().ToViewModel().ToPriceViewModel();
            }
        }

        private void ResetControlState()
        {
            this.btnOK.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnCancel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);

            this.btnOK.SetControlVisibility(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlVisibility(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSave.SetControlVisibility(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnCancel.SetControlVisibility(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
        }

        private void FillForm(List<stmasPriceVM> list_to_fill = null)
        {
            List<stmasPriceVM> list = list_to_fill != null ? list_to_fill : this.stmas_list;

            this.bs.ResetBindings(true);
            this.bs.DataSource = list;
            this.dgv.DataSource = this.bs;
        }

        private void ShowInlineForm(int row_index)
        {
            /* UNCOMMENT THIS TO ALLOWED EDITING PRICE DATE */
            //int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_date.DataPropertyName).First().Index;
            //this.inline_date.SetInlineControlPosition(this.dgv, row_index, col_index);
            //this.inline_date._SelectedDate = (DateTime?)this.dgv.Rows[row_index].Cells["col_date"].Value;
            //this.inline_date.Visible = true;

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index;
            this.inline_unitpr.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.inline_unitpr._Value = (decimal)this.dgv.Rows[row_index].Cells["col_unitpr"].Value;
            this.inline_unitpr.Visible = true;
        }

        private void RemoveInlineForm()
        {
            this.inline_date.Visible = false;
            this.inline_date._SelectedDate = null;
            this.inline_unitpr.Visible = false;
            this.inline_unitpr._Value = 0m;
        }

        private void SubmitNewPrice()
        {
            this.price_list.Clear();

            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    foreach (var item in this.stmas_list)
                    {
                        pricelist p = new pricelist
                        {
                            date = item.price_date.HasValue ? item.price_date.Value : DateTime.Now,
                            stmas_id = item.stmas_id,
                            unitpr = item.unitpr
                        };
                        this.price_list.Add(p);
                        db.pricelist.Add(p);
                    }

                    db.SaveChanges();
                    this.form_mode = FORM_MODE.READ_ITEM;
                    this.ResetControlState();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("", "");
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SubmitNewPrice();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count == 0)
                return;

            foreach (var item in this.stmas_list)
            {
                //item.unitpr = 0m;
                item.price_date = DateTime.Now;
            }
            this.FillForm();

            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.dgv.Rows[0].Cells["col_date"].Selected = true;
            this.inline_unitpr.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SubmitNewPrice();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.stmas_list = this.GetStmasList();
            this.FillForm();
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if (this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);

                if (((XDatagrid)sender).CurrentCell.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_date.DataPropertyName).First().Index)
                {
                    this.inline_date.Focus();
                }
                else
                {
                    this.inline_unitpr.Focus();
                }

                return;
            }
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            this.RemoveInlineForm();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.inline_unitpr.Visible)
                this.inline_unitpr.Focus();
        }

        private void inline_date__SelectedDateChanged(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.inline_date.Visible)
            {
                this.stmas_list.Where(l => l.stmas_id == (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_stmas_id"].Value).First().price_date = ((XDatePicker)sender)._SelectedDate;
                this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_date"].Value = ((XDatePicker)sender)._SelectedDate;
            }
        }

        private void inline_unitpr__ValueChanged(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.inline_unitpr.Visible)
            {
                this.stmas_list.Where(l => l.stmas_id == (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_stmas_id"].Value).First().unitpr = ((XNumEdit)sender)._Value;
                this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_unitpr"].Value = ((XNumEdit)sender)._Value;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.Tab && this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if (this.inline_date.Visible && this.inline_date._Focused)
                {
                    if (this.inline_unitpr.Visible)
                        this.inline_unitpr.Focus();
                    return true;
                }

                if (this.inline_unitpr.Visible && this.inline_unitpr._Focused)
                {
                    if (this.dgv.CurrentCell.RowIndex < this.dgv.Rows.Count - 1)
                    {
                        this.dgv.Rows[this.dgv.CurrentCell.RowIndex + 1].Cells["col_stkcod"].Selected = true;
                        return true;
                    }
                    else
                    {
                        this.dgv.Rows[0].Cells["col_stkcod"].Selected = true;
                        return true;
                    }
                }
            }

            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == Keys.F5)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
