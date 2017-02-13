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
using System.Data.OleDb;

namespace XPump.SubForm
{
    public partial class DialogStmasImportSelection : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<StmasDbfVM> stmasdbfvm_list;
        //private DateTime xtime;

        public List<StmasDbfVM> selected_list
        {
            get
            {
                return this.stmasdbfvm_list.Where(s => s.selected == true).ToList();
            }
        }

        public DialogStmasImportSelection(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogStmasImport_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            DataTable dt = DbfTable.Stmas();
            if (dt == null)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            this.stmasdbfvm_list = dt.ToStmasList().Where(s => s.stktyp == "0").OrderBy(s => s.stkcod).ToViewModel();
            this.bs.DataSource = this.stmasdbfvm_list;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_selected.DataPropertyName).First().Index)
            {
                bool value = !((bool)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_selected.Name].Value);

                ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_selected.Name].Value = value;
                this.stmasdbfvm_list[e.RowIndex].selected = value;
            }
        }

        private void dgv_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                Color back_color = (bool)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_selected.Name].Value ? Color.Beige : Color.White;

                ((XDatagrid)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = back_color;
                ((XDatagrid)sender).Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = back_color;
            }
        }

        private void ckSelectAll_Click(object sender, EventArgs e)
        {
            if(((CheckBox)sender).CheckState == CheckState.Unchecked)
            {
                foreach (var item in this.stmasdbfvm_list)
                {
                    item.selected = false;
                }
                ((CheckBox)sender).ThreeState = false;
                this.bs.ResetBindings(true);

                return;
            }

            if(((CheckBox)sender).CheckState == CheckState.Checked || ((CheckBox)sender).CheckState == CheckState.Indeterminate)
            {
                foreach (var item in this.stmasdbfvm_list)
                {
                    item.selected = true;
                }
                ((CheckBox)sender).ThreeState = false;
                this.bs.ResetBindings(true);

                return;
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_selected.DataPropertyName).First().Index)
            {
                int selected = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (bool)r.Cells[this.col_selected.Name].Value).Count();

                this.btnOK.Enabled = selected == 0 ? false : true;

                if (selected == 0)
                {
                    this.ckSelectAll.ThreeState = false;
                    this.ckSelectAll.CheckState = CheckState.Unchecked;
                    return;
                }

                if(selected > 0 && selected < ((XDatagrid)sender).Rows.Count)
                {
                    this.ckSelectAll.ThreeState = true;
                    this.ckSelectAll.CheckState = CheckState.Indeterminate;
                    return;
                }

                if(selected == ((XDatagrid)sender).Rows.Count)
                {
                    this.ckSelectAll.ThreeState = false;
                    this.ckSelectAll.CheckState = CheckState.Checked;
                    return;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                bool value = !((bool)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_selected.Name].Value);

                this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_selected.Name].Value = value;
                this.stmasdbfvm_list[this.dgv.CurrentCell.RowIndex].selected = value;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogStmasImportProgress progress = new DialogStmasImportProgress(this.main_form, this.selected_list);
            progress.ShowDialog();
        }
    }
}
