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
    public partial class DialogBranch : Form
    {
        public const string modcod = "21";
        private MainForm main_form;
        //private scacclvVM scacclv;
        private BindingList<dbconnVM> conn_list;
        public DbConnectionConfig curr_conn_config;
        private DbConnectionConfig temp_conn_config;
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

        private void LoadBranchListToDataGrid()
        {
            this.conn_list = new BindingList<dbconnVM>(new LocalDbConfig(this.main_form.working_express_db).BranchList.ToDbconnVM(this.main_form.working_express_db));
            this.dgv.DataSource = this.conn_list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDbConfig s = new DialogDbConfig(this.main_form, null);
            if(s.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.curr_conn_config = (DbConnectionConfig)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_db_connection_config.Name].Value;
        }
    }
}
