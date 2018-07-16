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
            this.db_conn_list = new BindingList<dbconnVM>(new LocalDbConfig(this.main_form.working_express_db).BranchList.ToDbconnVM(this.main_form.working_express_db).OrderBy(dbc => dbc.depcod).ToList());
            this.dgv.DataSource = this.db_conn_list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDbConfig dc = new DialogDbConfig(this.main_form, null);
            if (dc.ShowDialog() == DialogResult.OK)
                this.btnRefresh.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogDbConfig db = new DialogDbConfig(this.main_form, this.curr_conn);
            if (db.ShowDialog() == DialogResult.OK)
                this.btnRefresh.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.curr_conn == null)
                return;

            if(XMessageBox.Show("ลบสาขา " + this.curr_conn.branch + ", ทำต่อหรือไม่?", "",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var ldc = new LocalDbConfig(this.main_form.working_express_db);
                var delete_result = ldc.DeleteBranch(this.curr_conn.id);
                if (delete_result.success == true)
                {
                    this.btnRefresh.PerformClick();
                }
                else
                {
                    XMessageBox.Show(delete_result.error_message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadConnToDatagrid();
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.curr_conn = (DbConnectionConfig)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_db_connection_config.Name].Value;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEdit.PerformClick();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_branch.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม <Alt+A>");
                mnu_add.Click += delegate
                {
                    this.btnAdd.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                mnu_edit.Enabled = row_index > -1 ? true : false;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ <Alt+D>");
                mnu_delete.Click += delegate
                {
                    this.btnDelete.PerformClick();
                };
                mnu_delete.Enabled = row_index > -1 ? true : false;
                cm.MenuItems.Add(mnu_delete);

                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.A))
            {
                this.btnAdd.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
