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
    public partial class DialogLoccodSelection : Form
    {
        private MainForm main_form;
        public StlocDbfVM selected_stloc;
        private BindingList<StlocDbfVM> stloc;

        public DialogLoccodSelection(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        public DialogLoccodSelection(MainForm main_form, List<StlocDbfVM> stloc_list)
            : this(main_form)
        {
            this.stloc = new BindingList<StlocDbfVM>(stloc_list);
        }

        private void DialogLoccodSelection_Load(object sender, EventArgs e)
        {
            if(this.stloc == null)
            {
                string main_loc = DbfTable.Isinfo(this.main_form.working_express_db).ToList<IsinfoDbf>().First().mainloc.Trim();

                var stloc = DbfTable.Stloc(this.main_form.working_express_db).ToStlocList().Where(s => s.loccod.Trim() != main_loc).GroupBy(s => s.loccod.Trim()).Select(s => s.First()).ToViewModel(this.main_form.working_express_db);

                this.stloc = new BindingList<StlocDbfVM>(stloc);
            }

            this.dgv.DataSource = this.stloc;
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell != null)
            {
                this.selected_stloc = this.stloc[((XDatagrid)sender).CurrentCell.RowIndex];
                this.btnOK.Enabled = true;
            }
            else
            {
                this.selected_stloc = null;
                this.btnOK.Enabled = false;
            }
        }
    }
}
