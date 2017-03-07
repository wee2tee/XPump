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
    public partial class DialogInquiry : Form
    {
        public DataGridViewRow selected_row;
        private List<DataGridViewColumn> columns;
        private DataGridViewColumn col_search_key;
        private object initial_selected_key;
        private bool show_search_btn;
        private List<dynamic> list_to_show;
        private BindingSource bs;

        public DialogInquiry(List<dynamic> list_to_show)
        {
            InitializeComponent();
            this.list_to_show = list_to_show;
        }

        public DialogInquiry(List<dynamic> list_to_show, List<DataGridViewColumn> columns, DataGridViewColumn column_search_key, object initial_selected_key = null, bool show_search_btn = true)
            : this(list_to_show)
        {
            this.columns = columns;
            this.col_search_key = column_search_key;
            this.initial_selected_key = initial_selected_key;
            this.show_search_btn = show_search_btn;

            if (this.columns != null)
            {
                for (int i = 0; i < this.columns.Count; i++)
                {
                    this.dgv.Columns.Add(this.columns[i]);
                }
            }
        }

        private void DialogInquiry_Load(object sender, EventArgs e)
        {
            this.btnSearch.Visible = this.show_search_btn;
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;
            bs.ResetBindings(true);
            bs.DataSource = this.list_to_show;

            if(this.initial_selected_key != null)
            {
                var initial_selected_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (r.Cells[this.col_search_key.Name].Value).ToString() == this.initial_selected_key.ToString()).FirstOrDefault();

                if(initial_selected_row != null)
                {
                    //initial_selected_row.Cells[this.col_search_key.Name].Selected = true;
                    initial_selected_row.Cells[this.columns.Where(c => c.Visible).First().Name].Selected = true;
                }
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.selected_row = ((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex];
            this.btnOK.Enabled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if (!(this.btnCancel.Focused || this.btnSearch.Focused))
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!this.show_search_btn)
                return;

            if (e.KeyChar == (char)Keys.Back)
                return;

            DialogInlineSearch dis = new DialogInlineSearch(e.KeyChar.ToString());
            dis.SetBounds(this.PointToScreen(Point.Empty).X, this.PointToScreen(Point.Empty).Y + this.ClientRectangle.Height - dis.Height, dis.Width, dis.Height);
            if (dis.ShowDialog() == DialogResult.OK)
            {
                //int sort_col_index = this.dgv.SortColumn;

                DataGridViewRow searched_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_search_key.Name].Value).CompareTo(dis.keyword) > -1).OrderBy(r => (string)r.Cells[this.col_search_key.Name].Value).FirstOrDefault();

                if (searched_row == null)
                {
                    return;
                }

                this.dgv.Rows[searched_row.Index].Cells[this.col_search_key.Name].Selected = true;
                this.dgv.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogInlineSearch dis = new DialogInlineSearch();
            dis.SetBounds(this.PointToScreen(Point.Empty).X, this.PointToScreen(Point.Empty).Y + this.ClientRectangle.Height - dis.Height, dis.Width, dis.Height);
            if (dis.ShowDialog() == DialogResult.OK)
            {
                //int sort_col_index = this.dgv.SortColumn;

                DataGridViewRow searched_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.col_search_key.Name].Value).CompareTo(dis.keyword) > -1).OrderBy(r => (string)r.Cells[this.col_search_key.Name].Value).FirstOrDefault();

                if (searched_row == null)
                {
                    return;
                }

                this.dgv.Rows[searched_row.Index].Cells[this.col_search_key.Name].Selected = true;
                this.dgv.Focus();
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.btnOK.PerformClick();
        }
    }
}
