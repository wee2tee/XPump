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
        private ArmasDbf curr_armas;
        private ArmasDbf tmp_armas;

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

        private void FormArmas_Shown(object sender, EventArgs e)
        {
            this.btnFirst.PerformClick();
        }

        private void FillForm(ArmasDbf data_to_fill)
        {
            ArmasDbf armas;
            if(data_to_fill == null)
            {
                armas = new ArmasDbf
                {
                    cuscod = string.Empty
                };
            }
            else
            {
                armas = data_to_fill;
            }

            this.cCuscod._Text = armas.cuscod;
            this.cCusnam._Text = armas.cusnam;
            this.cAddr01._Text = armas.addr01;
            this.cAddr02._Text = armas.addr02;
            this.cAddr03._Text = armas.addr03;
            this.cZipcod._Text = armas.zipcod;
            this.cTelnum._Text = armas.telnum;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, DbfTable.RECORD_FLAG.FIRST);
            this.FillForm(this.curr_armas);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false);
            int curr_index = cuscod_list.IndexOf(this.curr_armas.cuscod);
            if(curr_index > 0)
            {
                this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, cuscod_list[curr_index - 1]);
                this.FillForm(this.curr_armas);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false);
            int curr_index = cuscod_list.IndexOf(this.curr_armas.cuscod);
            if (curr_index < cuscod_list.Count - 1)
            {
                this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, cuscod_list[curr_index + 1]);
                this.FillForm(this.curr_armas);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, DbfTable.RECORD_FLAG.LAST);
            this.FillForm(this.curr_armas);
        }
    }
}