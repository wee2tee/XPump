using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XPump.SubForm
{
    public partial class DialogBrowseBoxSelector : Form
    {
        //private MainForm main_form;
        private DataGridViewColumn[] cols = null;
        private object datasource = null;
        private string column_name_to_search = null;
        private string curr_row_string = null;
        public DataGridViewRow selected_row;

        public DialogBrowseBoxSelector(/*MainForm main_form, */DataGridViewColumn[] cols, object datasource)
        {
            //this.main_form = main_form;
            this.cols = cols;
            this.datasource = datasource;

            InitializeComponent();
        }

        public DialogBrowseBoxSelector(/*MainForm main_form, */DataGridViewColumn[] cols, object datasource, string column_name_to_search = null, string curr_row_string = null)
            //: this(main_form, cols, datasource)
        {
            //this.main_form = main_form;
            this.cols = cols;
            this.datasource = datasource;
            this.column_name_to_search = column_name_to_search;
            this.curr_row_string = curr_row_string;

            InitializeComponent();
        }

        private void DialogBrowseBoxSelector_Load(object sender, EventArgs e)
        {
            if (this.column_name_to_search != null)
                this.btnSearch.Visible = true;

            this.dgv.Columns.AddRange(this.cols);
            this.dgv.DataSource = this.datasource;
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(this.curr_row_string != null)
            {
                var selected_row = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => r.Cells[this.column_name_to_search].Value.ToString() == this.curr_row_string).FirstOrDefault();
                if (selected_row != null)
                {
                    selected_row.Cells[this.column_name_to_search].Selected = true;
                }
                else
                {
                    selected_row = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => r.Cells[this.column_name_to_search].Value.ToString().StartsWith(this.curr_row_string.TrimEnd())).FirstOrDefault();
                    if (selected_row != null)
                        selected_row.Cells[this.column_name_to_search].Selected = true;
                }
            }

            this.btnOK.Enabled = ((XDatagrid)sender).Rows.Count > 0 ? true : false;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                ((XDatagrid)sender).Rows[e.RowIndex].Cells[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).First().Index].Selected = true;
                this.btnOK.PerformClick();
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if(((XDatagrid)sender).CurrentCell == null)
            {
                this.selected_row = null;
                return;
            }
            else
            {
                this.selected_row = ((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex];
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ShowInlineSearch();
        }

        private void ShowInlineSearch(string init_keyword = "")
        {
            DialogInlineSearch s = new DialogInlineSearch(init_keyword);
            s.SetBounds(this.btnOK.PointToScreen(Point.Empty).X - 8, this.btnOK.PointToScreen(Point.Empty).Y - 10, s.Width, s.Height);

            if(s.ShowDialog() == DialogResult.OK)
            {
                var selected_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => ((string)r.Cells[this.column_name_to_search].Value).TrimEnd().StartsWith(s.keyword.TrimEnd())).FirstOrDefault();
                if(selected_row != null)
                {
                    selected_row.Cells[this.column_name_to_search].Selected = true;
                }
            }
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            this.ShowInlineSearch(e.KeyChar.ToString());
        }
    }
}
