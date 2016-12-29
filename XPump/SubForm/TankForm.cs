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

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_isactive)
        }
    }
}
