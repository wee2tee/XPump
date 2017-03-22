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
    public partial class DialogInquiryStmas : Form
    {
        //private INQUIRY inquiry_mode;
        private MainForm main_form;
        private stmas initial_stmas;
        private List<stmasVM> stmas_list;
        private BindingSource bs;
        public int selected_id = -1;

        public DialogInquiryStmas()
        {
            InitializeComponent();
        }

        public DialogInquiryStmas(MainForm main_form, stmas initial_stmas)
            : this()
        {
            this.main_form = main_form;
            this.initial_stmas = initial_stmas;
        }

        private void DialogInquiryStmas_Load(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.stmas_list = db.stmas.ToList().ToViewModel(this.main_form.working_express_db);
                this.bs = new BindingSource();
                this.bs.DataSource = this.stmas_list;
                this.dgv.DataSource = this.bs;
            }

            if (this.dgv.AllowSortByColumnHeaderClicked)
            {
                this.dgv.SortByColumn<stmasVM>(this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.selected_id = (int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells["col_id"].Value;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.stmas_list.Count > 0)
                this.btnOK.Enabled = true;

            if(this.initial_stmas != null)
            {
                DataGridViewRow selected_row = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells["col_id"].Value == this.initial_stmas.id).FirstOrDefault();

                if(selected_row != null)
                {
                    ((XDatagrid)sender).Rows[selected_row.Index].Cells[1].Selected = true;
                }
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1 && e.Button == MouseButtons.Left)
            {
                ((XDatagrid)sender).SortByColumn<stmasVM>(e.ColumnIndex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogInlineSearch dis = new DialogInlineSearch();
            dis.SetBounds(this.PointToScreen(Point.Empty).X, this.PointToScreen(Point.Empty).Y + this.ClientRectangle.Height - dis.Height, dis.Width, dis.Height);
            if (dis.ShowDialog() == DialogResult.OK)
            {
                int sort_col_index = this.dgv.SortColumn;

                DataGridViewRow searched_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[sort_col_index].Value).CompareTo(dis.keyword) > -1).OrderBy(r => (string)r.Cells[sort_col_index].Value).FirstOrDefault();


                if (searched_row == null)
                {
                    return;
                }

                this.dgv.Rows[searched_row.Index].Cells[sort_col_index].Selected = true;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter && this.selected_id > -1)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            DialogInlineSearch dis = new DialogInlineSearch(e.KeyChar.ToString());
            dis.SetBounds(this.PointToScreen(Point.Empty).X, this.PointToScreen(Point.Empty).Y + this.ClientRectangle.Height - dis.Height, dis.Width, dis.Height);
            if (dis.ShowDialog() == DialogResult.OK)
            {
                int sort_col_index = ((XDatagrid)sender).SortColumn;

                DataGridViewRow searched_row = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[sort_col_index].Value).CompareTo(dis.keyword) > -1).OrderBy(r => (string)r.Cells[sort_col_index].Value).FirstOrDefault();

                if (searched_row == null)
                {
                    return;
                }

                ((XDatagrid)sender).Rows[searched_row.Index].Cells[sort_col_index].Selected = true;
            }
        }
    }
}
