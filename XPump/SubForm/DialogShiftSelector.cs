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
    public partial class DialogShiftSelector : Form
    {
        public shift selected_shift;
        private BindingSource bs;
        private List<shiftVM> shift_list;
        private shift initial_selected_shift;

        public DialogShiftSelector()
        {
            InitializeComponent();
        }

        public DialogShiftSelector(int initial_selected_shift_id)
            : this()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                this.initial_selected_shift = db.shift.Find(initial_selected_shift_id);
            }
        }

        private void DialogShiftSelector_Load(object sender, EventArgs e)
        {
            using(xpumpEntities db = DBX.DataSet())
            {
                this.shift_list = db.shift.ToList().ToViewModel();
                this.bs = new BindingSource();
                this.bs.DataSource = this.shift_list;
                this.dgv.DataSource = this.bs;
            }

            if(this.initial_selected_shift != null)
            {
                this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells["col_id"].Value == this.initial_selected_shift.id).First().Cells["col_name"].Selected = true;
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.selected_shift = (shift)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells["col_shift"].Value;
            this.btnOK.Enabled = true;
        }
    }
}
