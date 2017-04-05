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

        public DialogLoccodSelection(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogLoccodSelection_Load(object sender, EventArgs e)
        {
            string main_loc = DbfTable.Isinfo(this.main_form.working_express_db).ToList<IsinfoDbf>().First().mainloc.Trim();

            this.dgv.DataSource = DbfTable.Stloc(this.main_form.working_express_db).ToStlocList().Where(s => s.loccod.Trim() != main_loc).GroupBy(s => s.loccod.Trim()).Select(s => s.First()).ToViewModel(this.main_form.working_express_db);
        }
    }
}
