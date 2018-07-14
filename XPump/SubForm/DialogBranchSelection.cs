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
    public partial class DialogBranchSelection : Form
    {
        //public const string modcod = "21";
        private MainForm main_form;
        //private scacclvVM scacclv;
        private BindingList<dbconnVM> conn_list;
        public DbConnectionConfig curr_conn_config;
        private DbConnectionConfig temp_conn_config;
        //private List<shiftVM> shift_list;
        //private shift curr_shift; // current focused row
        //private shiftVM temp_shift; // model for add/edit shift

        public DialogBranchSelection(MainForm main_form)
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

            foreach (var conn in conn_list)
            {
                this.cbBranch.Items.Add(new XDropdownListItem { Text = conn.depcod + " : " + conn.branch, Value = conn });
            }
        }


        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //if (((XDatagrid)sender).CurrentCell == null)
            //    return;

            //this.curr_conn_config = (DbConnectionConfig)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_db_connection_config.Name].Value;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnOK.PerformClick();
        }

        private void cbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.curr_conn_config = ((dbconnVM)((XDropdownListItem)((ComboBox)sender).SelectedItem).Value).db_connection_config;
            this.btnOK.Enabled = this.curr_conn_config != null ? true : false;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(this.ActiveControl == this.cbBranch && this.cbBranch.DroppedDown)
                {
                    this.cbBranch.DroppedDown = false;
                    this.btnOK.Focus();
                    return true;
                }
                else
                {
                    this.btnOK.PerformClick();
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F6)
            {
                if(this.ActiveControl == this.cbBranch)
                {
                    this.cbBranch.DroppedDown = true;
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
