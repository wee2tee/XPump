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
    public partial class StmasForm : Form
    {
        private MainForm main_form;
        private BindingSource bs_tank;
        private BindingSource bs_nozzle;
        private BindingSource bs_price;
        private stmas stmas;
        private stmas temp_stmas;
        private FORM_MODE form_mode;
        private bool curr_tank_only, curr_nozzle_only, curr_price_only;

        public StmasForm()
        {
            InitializeComponent();
        }

        public StmasForm(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void StmasForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs_tank = new BindingSource();
            this.bs_nozzle = new BindingSource();
            this.bs_price = new BindingSource();
            this.dgvTank.DataSource = this.bs_tank;
            this.dgvNozzle.DataSource = this.bs_nozzle;
            this.dgvPrice.DataSource = this.bs_price;
        }

        private void ResetControlState()
        {
            this.txtName.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtDescription.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtRemark.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ)
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

        private void FillForm(stmas stmas_to_fill = null)
        {
            stmas stmas = stmas_to_fill != null ? stmas_to_fill : this.stmas;

            if (stmas == null)
                return;

            this.txtName._Text = stmas.name;
            this.txtDescription._Text = stmas.description;
            this.txtRemark._Text = stmas.remark;

            this.bs_tank.ResetBindings(true);
            this.bs_tank.DataSource = stmas.tanksetup;
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_stmas = new stmas()
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                remark = string.Empty,
            };

            this.FillForm(this.temp_stmas);

            this.txtRemark.Focus();
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.txtName.Focus();
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

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void chkCurrTank_CheckedChanged(object sender, EventArgs e)
        {
            this.curr_tank_only = ((CheckBox)sender).Checked;
        }

        private void chkCurrNozzle_CheckedChanged(object sender, EventArgs e)
        {
            this.curr_nozzle_only = ((CheckBox)sender).Checked;
        }

        private void chkCurrPrice_CheckedChanged(object sender, EventArgs e)
        {
            this.curr_price_only = ((CheckBox)sender).Checked;
        }
    }
}
