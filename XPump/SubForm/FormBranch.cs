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
    public partial class FormBranch : Form
    {
        public const string modcod = "21";
        private MainForm main_form;
        private BindingList<dbconnVM> db_conn_list;
        public DbConnectionConfig curr_conn;

        public FormBranch(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void FormBranch_Load(object sender, EventArgs e)
        {
            this.LoadConnToDatagrid();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void LoadConnToDatagrid()
        {
            this.db_conn_list = new BindingList<dbconnVM>(new LocalDbConfig(this.main_form.working_express_db).BranchList.ToDbconnVM(this.main_form.working_express_db));
            this.dgv.DataSource = this.db_conn_list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDbConfig dc = new DialogDbConfig(this.main_form, null);
            dc.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogDbConfig db = new DialogDbConfig(this.main_form, this.curr_conn);
            db.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadConnToDatagrid();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.curr_conn = (DbConnectionConfig)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_db_connection_config.Name].Value;
        }
    }
}
