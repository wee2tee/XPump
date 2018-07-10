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

namespace XPump.SubForm
{
    public partial class DialogBranch : Form
    {
        public const string modcod = "21";
        private MainForm main_form;
        //private scacclvVM scacclv;
        private BindingList<DbConnectionConfig> conn_list;
        private DbConnectionConfig curr_conn;
        private DbConnectionConfig temp_conn;
        private FORM_MODE form_mode;
        //private List<shiftVM> shift_list;
        //private shift curr_shift; // current focused row
        //private shiftVM temp_shift; // model for add/edit shift

        public DialogBranch(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void DialogBranch_Load(object sender, EventArgs e)
        {
            this.LoadBranchListToDataGrid();
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, form_mode);
        }

        private void LoadBranchListToDataGrid()
        {
            this.conn_list = new BindingList<DbConnectionConfig>(new LocalDbConfig(this.main_form.working_express_db).BranchList);
            this.xDatagrid1.DataSource = this.conn_list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogSettings s = new DialogSettings(this.main_form, new scacclvVM());
            s.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadBranchListToDataGrid();
        }
    }
}
