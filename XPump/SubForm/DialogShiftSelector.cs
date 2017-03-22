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
        private MainForm main_form;
        public shift selected_shift;
        private BindingSource bs;
        private List<shiftVM> shift_list;
        private shift initial_selected_shift;

        public DialogShiftSelector(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        public DialogShiftSelector(MainForm main_form, int initial_selected_shift_id)
            : this(main_form)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.initial_selected_shift = db.shift.Find(initial_selected_shift_id);
            }
        }

        public DialogShiftSelector(MainForm main_form, int initial_selected_shift_id, Point displayed_position)
            : this(main_form, initial_selected_shift_id)
        {
            this.SetBounds(displayed_position.X, displayed_position.Y, this.Width, this.Height);
        }

        private void DialogShiftSelector_Load(object sender, EventArgs e)
        {
            this.shift_list = GetShiftList().ToViewModel(this.main_form.working_express_db);
            this.bs = new BindingSource();
            this.bs.DataSource = this.shift_list;
            this.dgv.DataSource = this.bs;

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

        public List<shift> GetShiftList()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.shift.ToList();
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.btnOK.PerformClick();
                return;
            }
        }
    }
}
