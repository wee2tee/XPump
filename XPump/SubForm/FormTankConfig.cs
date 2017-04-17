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
    public partial class FormTankConfig : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private tanksetup tanksetup;
        private BindingSource bs_tank;
        private BindingSource bs_section;
        private tank selected_tank;
        private section selected_section;

        public FormTankConfig(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormTankConfig_Load(object sender, EventArgs e)
        {
            this.bs_tank = new BindingSource();
            this.bs_section = new BindingSource();

            this.btnLast.PerformClick();

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
        }

        public void ResetControlState()
        {
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);


            this.btnAddTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnAddSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
        }

        public static tanksetup GetTankSetup(SccompDbf working_express_db, int tanksetup_id)
        {
            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                return db.tanksetup.Find(tanksetup_id);
            }
        }

        private void FillForm(tanksetup data_to_fill = null)
        {
            tanksetup tanksetup = data_to_fill != null ? data_to_fill : this.tanksetup;

            if (tanksetup == null)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                return;
            }
            
            this.bs_tank.DataSource = tanksetup.tank.ToViewModel(this.main_form.working_express_db);
            if(this.selected_tank != null)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    int tank_id = this.selected_tank.id;
                    this.bs_section.DataSource = db.section.Where(s => s.tank_id == tank_id).ToViewModel(this.main_form.working_express_db);
                }
            }
            
        }

        private void dgvTank_CurrentCellChanged(object sender, EventArgs e)
        {
            this.selected_tank = ((XDatagrid)sender).CurrentCell != null ? (tank)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[000].Value : null;
        }

        private void dgvSection_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.tanksetup = db.tanksetup.Include("tank").OrderByDescending(t => t.startdate).First();

                this.FillForm();
            }
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

        private void btnTank_Click(object sender, EventArgs e)
        {

        }

        private void btnSection_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTank_Click(object sender, EventArgs e)
        {

        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteTank_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {

        }

        private void btnEditSection_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {

        }
    }
}
