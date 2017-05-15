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

namespace XPump.SubForm
{
    public partial class DialogDother : Form
    {
        private MainForm main_form;
        private salessummary salessummary;
        private FORM_MODE form_mode;
        private BindingList<dotherVM> bl_dother;
        private dother tmp_dother;

        public DialogDother(MainForm main_form, salessummary salessummary)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.salessummary = salessummary;
        }

        private void DialogDother_Load(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.FillForm();
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);

            if(this.bl_dother.Count == 0)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private List<dother> GetDother()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.dother.Where(d => d.salessummary_id == this.salessummary.id).ToList();
            }
        }

        private void FillForm()
        {
            this.bl_dother = null;
            this.bl_dother = new BindingList<dotherVM>(this.GetDother().ToViewModel(this.main_form.working_express_db));
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
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes.DataPropertyName).First().Index;
                this.inline_dother.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
                this.inline_dother._ReadOnly = false;
            }
            else
            {
                this.inline_dother.SetBounds(-9999, 0, 0, 0);
                this.inline_dother._ReadOnly = true;
            }
            //this.inline_dother._SelectedItem = this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.istab_id).FirstOrDefault()

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_qty.DataPropertyName).First().Index;
            this.inline_qty.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_qty._Value = this.tmp_dother.qty;
        }

        private void RemoveInlineForm()
        {
            this.inline_dother.SetBounds(-9999, 0, 0, 0);
            this.inline_qty.SetBounds(-9999, 0, 0, 0);
            this.tmp_dother = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.bl_dother.Add(new dother
            {
                id = -1,
                salessummary_id = this.salessummary.id,
                istab_id = -1,
                qty = 0m,
                creby = this.main_form.loged_in_status.loged_in_user_name
            }.ToViewModel(this.main_form.working_express_db));

            this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typdes.Name].Selected = true;
            this.ResetControlState(FORM_MODE.ADD_ITEM);
            this.ShowInlineForm();
        }

        private void DialogDother_Deactivate(object sender, EventArgs e)
        {
            this.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                //this.DialogResult = DialogResult.Cancel;
                //this.Close();
                //return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
