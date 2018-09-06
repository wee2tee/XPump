using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;

namespace XPump.SubForm
{
    public partial class FormArmas : Form
    {
        private MainForm main_form;
        private List<ArmasList> armas;

        public FormArmas(MainForm main_form)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.main_form = main_form;
            InitializeComponent();
        }

        private void FormArmas_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Start at " + DateTime.Now.ToString());
            this.armas = DbfTable.ArmasList(this.main_form.working_express_db);
            Console.WriteLine("Finish at ==> " + DateTime.Now.ToString());
        }
    }
}
