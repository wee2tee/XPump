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
    public partial class TankForm : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<tankVM> tank_list;
        private FORM_MODE_LIST form_mode;
        private tankVM temp_tank; // model for add/edit tank
        private XTextBox inline_name; // inline control for name
        private XTextBox inline_desc; // inline control for description
        private XComboBox inline_isactive; // inline control for isactive

        public TankForm()
        {
            InitializeComponent();
        }

        public TankForm(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void TankForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE_LIST.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.bs.DataSource = this.tank_list;
            this.dgv.DataSource = this.bs;

            this.tank_list = this.GetTankList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.tank_list;
        }

        private List<tank> GetTankList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.tank.Include("nozzle").ToList();
            }
        }

        private void ResetControlState()
        {
            this.btnAdd.SetControlState(new FORM_MODE_LIST[] { FORM_MODE_LIST.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE_LIST[] { FORM_MODE_LIST.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE_LIST[] { FORM_MODE_LIST.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE_LIST[] { FORM_MODE_LIST.ADD, FORM_MODE_LIST.EDIT }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE_LIST[] { FORM_MODE_LIST.ADD, FORM_MODE_LIST.EDIT }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE_LIST[] { FORM_MODE_LIST.READ }, this.form_mode);
        }

        private void ShowInlineControl(int row_index)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if (this.temp_tank == null)
                return;

            int col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index;
            this.inline_name = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_tank.tank, "name");
            this.inline_name.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_isactive.DataPropertyName).First().Index;
            this.inline_isactive = this.dgv.Rows[row_index].Cells[col_ndx].CreateXComboBoxTrueFalseEdit(this.temp_tank, "isactive");
            this.inline_isactive.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            if (this.form_mode == FORM_MODE_LIST.ADD)
                this.dgv.Parent.Controls.Add(this.inline_name);
            this.dgv.Parent.Controls.Add(this.inline_isactive);
            this.inline_name.BringToFront();
            this.inline_isactive.BringToFront();
            if(this.form_mode == FORM_MODE_LIST.ADD)
            {
                this.inline_name.Focus();
            }
            else
            {
                this.inline_isactive.Focus();
            }
        }

        private void RemoveInlineControl()
        {
            if(this.inline_name != null)
            {
                this.inline_name.Dispose();
                this.inline_name = null;
            }

            if(this.inline_desc != null)
            {
                this.inline_desc.Dispose();
                this.inline_desc = null;
            }

            if (this.inline_isactive != null)
            {
                this.inline_isactive.Dispose();
                this.inline_isactive = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE_LIST.READ)
            {
                if (MessageBox.Show(StringResource.Msg("0001"), "Message # 0001", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_tank = new tank()
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                isactive = true,
                remark = string.Empty,
                stmas_id = null
            }.ToViewModel();

            this.tank_list.Add(this.temp_tank);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.tank_list;

            this.dgv.CurrentCell = this.dgv.Rows[this.tank_list.Count - 1].Cells["col_name"];
            this.form_mode = FORM_MODE_LIST.ADD;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }
    }
}
