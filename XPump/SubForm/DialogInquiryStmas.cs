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
        private stmas initial_stmas;
        private List<stmasVM> stmas_list;
        private BindingSource bs;
        public int selected_id = -1;

        public DialogInquiryStmas()
        {
            InitializeComponent();
        }

        public DialogInquiryStmas(/*INQUIRY inquiry_mode*/ stmas initial_stmas)
            : this()
        {
            //this.inquiry_mode = inquiry_mode;
            this.initial_stmas = initial_stmas;
        }

        private void DialogInquiryStmas_Load(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                this.stmas_list = db.stmas.ToList().ToViewModel();
                this.bs = new BindingSource();
                this.bs.DataSource = this.stmas_list;
                this.dgv.DataSource = this.bs;
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
            if(this.initial_stmas != null)
            {
                DataGridViewRow selected_row = ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells["col_id"].Value == this.initial_stmas.id).FirstOrDefault();

                Console.WriteLine(" .. >> selected_row index : " + selected_row.Index);
                if(selected_row != null)
                {
                    ((XDatagrid)sender).Rows[selected_row.Index].Cells[1].Selected = true;
                    //((XDatagrid)sender).Refresh();
                }
            }
        }
    }
}
