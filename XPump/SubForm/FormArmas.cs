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
            //Console.WriteLine("Start at " + DateTime.Now.ToString());
            //this.armas = DbfTable.ArmasList(this.main_form.working_express_db);
            //Console.WriteLine("Finish at ==> " + DateTime.Now.ToString());
            this.ApplyDropdownSelection();
        }

        private void FormArmas_Shown(object sender, EventArgs e)
        {
            this.btnFirst.PerformClick();
        }

        private void ApplyDropdownSelection()
        {
            this.cStatus._Items.Add(new XDropdownListItem { Text = "Active", Value = "A" });
            this.cStatus._Items.Add(new XDropdownListItem { Text = "Inactive", Value = "I" });
            this.cStatus._Items.Add(new XDropdownListItem { Text = "ไม่ได้ระบุ(Active)", Value = "" });

            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายล่าสุด", Value = "0" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 1", Value = "1" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 2", Value = "2" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 3", Value = "3" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 4", Value = "4" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 5", Value = "5" });
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

            var status = this.cStatus._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == armas.status).FirstOrDefault();
            var tabpr = this.cTabpr._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == armas.tabpr).FirstOrDefault();

            this.cCuscod._Text = armas.cuscod;
            this.cCusnam._Text = armas.cusnam;
            this.cAddr01._Text = armas.addr01;
            this.cAddr02._Text = armas.addr02;
            this.cAddr03._Text = armas.addr03;
            this.cZipcod._Text = armas.zipcod;
            this.cTelnum._Text = armas.telnum;
            this.cContact._Text = armas.contact;
            this.cRemark._Text = armas.remark;
            this.cStatus._SelectedItem = status != null ? status : this.cStatus._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == "").First();
            this.cTaxid._Text = armas.taxid;
            this.cOrgnum._Value = Convert.ToDecimal(armas.orgnum);
            this.cCustyp._Text = armas.custyp;
            this.cCustypDesc.Text = armas._custypdesc;
            this.cAccnum._Text = armas.accnum;
            this.cAccnam.Text = armas._accnam;
            this.cSlmcod._Text = armas.slmcod;
            this.cSlmnam.Text = armas._slmnam;
            this.cAreacod._Text = armas.areacod;
            this.cAreaDesc.Text = armas._areadesc;
            this.cDlvby._Text = armas.dlvby;
            this.cDlvbyDesc.Text = armas._dlvbydesc;
            this.cPaytrm._Value = Convert.ToDecimal(armas.paytrm);
            this.cPaycond._Text = armas.paycond;
            this.cTabpr._SelectedItem = tabpr != null ? tabpr : this.cTabpr._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == "0").First();
            this.cDisc._Text = armas.disc;
            this.cCrline._Value = Convert.ToDecimal(armas.crline);
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