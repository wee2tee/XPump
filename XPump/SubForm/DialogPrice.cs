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
    public partial class DialogPrice : Form
    {
        private MainForm main_form;
        public List<stmasPriceVM> stmas_list;
        private List<stmasPriceVM> temp_list;
        private BindingSource bs;
        private FORM_MODE form_mode;
        private XNumEdit inline_unitpr;
        private XDatePicker inline_date;
        private int selected_row = -1;

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

            //this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
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
            this.RemoveInlineForm();

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_date.DataPropertyName).First().Index;

            this.inline_date = new XDatePicker();
            this.inline_date._SelectedDate = (DateTime)this.dgv.Rows[row_index].Cells["col_date"].Value;
            this.inline_date._SelectedDateChanged += delegate
            {
                if(this.temp_list != null)
                {
                    this.temp_list.Where(l => l.stmas_id == (int)this.dgv.Rows[row_index].Cells["col_stmas_id"].Value).First().date = this.inline_date._SelectedDate;
                    this.dgv.Rows[row_index].Cells["col_date"].Value = this.inline_date._SelectedDate;
                }
            };
            this.inline_date.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.dgv.Parent.Controls.Add(this.inline_date);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index;

            this.inline_unitpr = new XNumEdit(2, true, 999999.99m, HorizontalAlignment.Right);
            this.inline_unitpr._Value = (decimal)this.dgv.Rows[row_index].Cells["col_unitpr"].Value;
            this.inline_unitpr._ValueChanged += delegate
            {
                if (this.temp_list != null)
                {
                    this.temp_list.Where(l => l.stmas_id == (int)this.dgv.Rows[row_index].Cells["col_stmas_id"].Value).First().unitpr = this.inline_unitpr._Value;
                    this.dgv.Rows[row_index].Cells["col_unitpr"].Value = this.inline_unitpr._Value;
                }
            };
            this.inline_unitpr.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.dgv.Parent.Controls.Add(this.inline_unitpr);

            this.dgv.SendToBack();
        }

        private void RemoveInlineForm()
        {
            if(this.inline_date != null)
            {
                this.inline_date.Dispose();
                this.inline_date = null;
            }

            if(this.inline_unitpr != null)
            {
                this.inline_unitpr.Dispose();
                this.inline_unitpr = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.Rows.Count == 0)
                return;

            this.temp_list = this.stmas_list.ConvertAll(s => s);
            foreach (var item in this.temp_list)
            {
                item.date = DateTime.Now;
            }
            this.FillForm(this.temp_list);

            this.dgv.Rows[0].Cells["col_date"].Selected = true;
            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.ShowInlineForm(this.dgv.CurrentCell.RowIndex);
            this.inline_unitpr.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.stmas_list = this.GetStmasList();
            this.FillForm();
            this.temp_list = null;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //this.RemoveInlineForm();
            //if (((XDatagrid)sender).CurrentCell != null && this.form_mode == FORM_MODE.EDIT_ITEM)
            //{
            //    this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);

            //    if (((XDatagrid)sender).CurrentCell.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_date.DataPropertyName).First().Index)
            //    {
            //        this.inline_date.Focus();
            //    }
            //    else
            //    {
            //        this.inline_unitpr.Focus();
            //    }

            //    return;
            //}
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            //this.RemoveInlineForm();
            if (((XDatagrid)sender).CurrentCell != null && this.form_mode == FORM_MODE.EDIT_ITEM)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if (this.inline_date != null && this.inline_date._Focused)
                    {
                        if (this.inline_unitpr != null)
                            this.inline_unitpr.Focus();
                        return true;
                    }

                    if(this.inline_unitpr != null && this.inline_unitpr._Focused)
                    {
                        if (this.dgv.CurrentCell.RowIndex < this.dgv.Rows.Count - 1)
                        {
                            this.dgv.Rows[this.dgv.CurrentCell.RowIndex + 1].Cells["col_unitpr"].Selected = true;
                            return true;
                        }
                        else
                        {
                            this.dgv.Rows[0].Cells["col_unitpr"].Selected = true;
                            return true;
                        }
                            
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex > -1 && this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.RemoveInlineForm();
                this.ShowInlineForm(e.RowIndex);
                this.inline_unitpr.Focus();
            }
        }
    }
}
