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
    public partial class DialogSccompSelection : Form
    {
        private MainForm main_form;
        private List<SccompDbf> sccomp_list;
        private BindingSource bs;
        public SccompDbf selected_sccomp;

        public DialogSccompSelection(MainForm main_form, List<SccompDbf> sccomp_list)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.sccomp_list = sccomp_list;
        }

        private void DialogSccompSelection_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.bs.DataSource = this.sccomp_list;
            this.dgv.DataSource = this.bs;
        }

        private void xDatagrid1_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell != null)
                this.selected_sccomp = this.sccomp_list[((XDatagrid)sender).CurrentCell.RowIndex];
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
                if (this.dgv.Focused)
                {
                    this.btnCancel.PerformClick();
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                if (this.dgv.Focused)
                {
                    this.btnCancel.PerformClick();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
