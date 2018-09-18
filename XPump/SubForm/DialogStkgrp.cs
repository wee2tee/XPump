using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using XPump.Misc;
using XPump.Model;

namespace XPump.SubForm
{
    public partial class DialogStkgrp : Form
    {
        private MainForm main_form;
        private BindingList<StkgrpBillMethodList> stkgrp_list;
        private StkgrpBillMethodList tmp_stkgrp;
        private FORM_MODE form_mode;
        private string search_keyword = string.Empty;
        //private string curr_typcod = null;

        public DialogStkgrp(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void DialogStkgrp_Load(object sender, EventArgs e)
        {
            this.ResetFormState(FORM_MODE.READ_ITEM);
            this.btnRefresh.PerformClick();
            this.HideInlineForm();
            this.ApplyDropdownlistSelection();
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
        }

        private void ApplyDropdownlistSelection()
        {
            this.inlineStkgrp._Items.Add(new XDropdownListItem { Text = STKGRP.FUEL.ToStringDescription(), Value = STKGRP.FUEL });
            this.inlineStkgrp._Items.Add(new XDropdownListItem { Text = STKGRP.OTHER.ToStringDescription(), Value = STKGRP.OTHER });
            this.inlineStkgrp._Items.Add(new XDropdownListItem { Text = STKGRP.NA_O.ToStringDescription(), Value = STKGRP.NA_O });

            this.inlineBillMethod._Items.Add(new XDropdownListItem { Text = BILL_METHOD.VAL.ToStringDescription(), Value = BILL_METHOD.VAL });
            this.inlineBillMethod._Items.Add(new XDropdownListItem { Text = BILL_METHOD.QTY.ToStringDescription(), Value = BILL_METHOD.QTY });
            this.inlineBillMethod._Items.Add(new XDropdownListItem { Text = BILL_METHOD.NA_Q.ToStringDescription(), Value = BILL_METHOD.NA_Q });
        }

        private void SetInlineFormPosition()
        {
            if (this.dgv.CurrentCell == null)
                return;

            var cell_stktyp = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_stktyp.Name];
            this.inlineStkgrp.SetInlineControlPosition(this.dgv, cell_stktyp.RowIndex, cell_stktyp.ColumnIndex);
            this.inlineStkgrp._SelectedItem = this.inlineStkgrp._Items.Cast<XDropdownListItem>().Where(i => ((STKGRP)i.Value).ToStringDescription() == cell_stktyp.Value.ToString()).First();

            var cell_bill_method = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_bill_method.Name];
            this.inlineBillMethod.SetInlineControlPosition(this.dgv, cell_bill_method.RowIndex, cell_bill_method.ColumnIndex);
            this.inlineBillMethod._SelectedItem = this.inlineBillMethod._Items.Cast<XDropdownListItem>().Where(i => ((BILL_METHOD)i.Value).ToStringDescription() == cell_bill_method.Value.ToString()).First();
        }

        private void ShowInlineForm()
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_stkgrp = new StkgrpBillMethodList
            {
                bill_method = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_bill_method.Name].Value.ToString(),
                shortnam = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_shortnam.Name].Value.ToString(),
                stktyp = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_stktyp.Name].Value.ToString(),
                typcod = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_typcod.Name].Value.ToString(),
                typdes = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_typdes.Name].Value.ToString()
            };

            this.SetInlineFormPosition();
        }

        private void HideInlineForm()
        {
            this.inlineStkgrp.SetBounds(-99999, this.inlineStkgrp.Location.Y, 0, 0);
            this.inlineBillMethod.SetBounds(-99999, this.inlineBillMethod.Location.Y, 0, 0);
            this.tmp_stkgrp = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.ResetFormState(FORM_MODE.EDIT_ITEM);
            this.ShowInlineForm();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.HideInlineForm();
            this.ResetFormState(FORM_MODE.READ_ITEM);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.tmp_stkgrp != null)
            {
                Console.WriteLine(this.tmp_stkgrp.typcod);
                Console.WriteLine(this.tmp_stkgrp.stktyp);
                Console.WriteLine(this.tmp_stkgrp.bill_method);
                Console.WriteLine(" -------------------------- ");
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
                    {
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            string stkgrp = ((STKGRP)this.inlineStkgrp._Items.Cast<XDropdownListItem>().Where(i => i.Text == this.tmp_stkgrp.stktyp).First().Value).ToString();
                            string bill_method = ((BILL_METHOD)this.inlineBillMethod._Items.Cast<XDropdownListItem>().Where(i => i.Text == this.tmp_stkgrp.bill_method).First().Value).ToString();
                            cmd.CommandText = "Update istab Set shortnam2='" + stkgrp + ":" + bill_method + "' Where tabtyp=? and typcod=?";
                            cmd.Parameters.AddWithValue("@tabtyp", "22");
                            cmd.Parameters.AddWithValue("@typcod", this.tmp_stkgrp.typcod);

                            conn.Open();
                            if(cmd.ExecuteNonQuery() > 0)
                            {
                                this.HideInlineForm();
                                this.ResetFormState(FORM_MODE.READ_ITEM);
                                string curr_typcod = this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_typcod.Name].Value.ToString();
                                this.btnRefresh.PerformClick();

                                var selected_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[this.col_typcod.Name].Value.ToString() == curr_typcod).FirstOrDefault();
                                if (selected_row != null)
                                    selected_row.Cells[this.col_typcod.Name].Selected = true;
                            }

                            conn.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogSimpleSearch ds = new DialogSimpleSearch("รหัสหมวดสินค้า", this.search_keyword);
            if(ds.ShowDialog() == DialogResult.OK)
            {
                this.search_keyword = ds.keyword;

                var selected_row = this.dgv.Rows.Cast<DataGridViewRow>().OrderBy(r => r.Cells[this.col_typcod.Name].Value.ToString()).Where(r => r.Cells[this.col_typcod.Name].Value.ToString().CompareTo(this.search_keyword) >= 0).FirstOrDefault();
                if(selected_row != null)
                {
                    selected_row.Cells[this.col_typcod.Name].Selected = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.stkgrp_list = new BindingList<StkgrpBillMethodList>(DbfTable.StkgrpBillMethodList(this.main_form.working_express_db));
            this.dgv.DataSource = this.stkgrp_list;
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.SetInlineFormPosition();
            }
        }

        private void inlineStkgrp__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_stkgrp != null)
                this.tmp_stkgrp.stktyp = ((STKGRP)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value).ToStringDescription();
        }

        private void inlineBillMethod__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_stkgrp != null)
                this.tmp_stkgrp.bill_method = ((BILL_METHOD)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value).ToStringDescription();
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.tmp_stkgrp != null)
            {
                //this.btnSave.PerformClick();

                //this.btnEdit.PerformClick();
            }
        }
    }
}
