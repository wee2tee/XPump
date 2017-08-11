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
using System.Globalization;
using System.Threading;

namespace XPump.SubForm
{
    public partial class DialogSccompSelection : Form
    {
        private MainForm main_form;
        public const string modcod = "34";
        private List<SccompDbf> sccomp_list;
        private string initial_data_path;
        private BindingSource bs;
        public SccompDbf selected_sccomp;

        public DialogSccompSelection(MainForm main_form, List<SccompDbf> sccomp_list, string initial_data_path)
        {
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            InitializeComponent();
            this.sccomp_list = sccomp_list;
            this.initial_data_path = initial_data_path;
        }

        private void DialogSccompSelection_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.bs.DataSource = this.sccomp_list;
            this.dgv.DataSource = this.bs;

            var initial_selected_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_path.Name].Value).Trim() == this.initial_data_path).FirstOrDefault();

            if (initial_selected_row != null)
                initial_selected_row.Cells[this.col_compnam.Name].Selected = true;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //if (((XDatagrid)sender).CurrentCell != null)
            //    this.selected_sccomp = this.sccomp_list[((XDatagrid)sender).CurrentCell.RowIndex];
        }

        private void xDatagrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                this.btnOK.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                //if (this.dgv.Focused)
                //{
                //    this.btnCancel.PerformClick();
                //    return true;
                //}
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                //if (this.dgv.Focused)
                //{
                //    this.btnCancel.PerformClick();
                //    return true;
                //}
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell != null)
            {
                this.selected_sccomp = this.sccomp_list[((XDatagrid)sender).CurrentCell.RowIndex];
                this.btnOK.Enabled = true;
            }
        }
    }
}
