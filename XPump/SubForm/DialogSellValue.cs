using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using XPump.Model;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogSellValue : Form
    {
        private MainForm main_form;
        public stcrd stcrd;
        public nozzle selected_nozzle = null;

        public DialogSellValue(MainForm main_form, stcrd stcrd)
        {
            this.main_form = main_form;
            this.stcrd = stcrd;
            InitializeComponent();
        }

        private void DialogSellValue_Load(object sender, EventArgs e)
        {
            this.lblSellDate.Text = this.stcrd.docdat.ToString("dd/MM/yy", CultureInfo.GetCultureInfo("th-TH"));
            this.lblStkdes.Text = this.stcrd.stkcod.TrimEnd() + " : " + this.stcrd.stkdes.TrimEnd();

            var nozz = GetNozzleList(this.main_form.working_express_db, this.stcrd);
            foreach (var noz in GetNozzleList(this.main_form.working_express_db, this.stcrd))
            {
                this.cNozzle._Items.Add(new XDropdownListItem { Text = noz.name + " : " + noz.description, Value = noz });
            }
        }

        /*
         *  Get nozzle list relate to stkcod and docdat
         */
        public static List<nozzle> GetNozzleList(SccompDbf working_express_db, stcrd stcrd)
        {
            List<nozzle> nozzles = new List<Model.nozzle>();

            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                var tanksetup = db.tanksetup.Where(t => t.startdate.CompareTo(stcrd.docdat) <= 0).OrderByDescending(t => t.startdate).FirstOrDefault();
                if(tanksetup != null)
                {
                    nozzles = db.nozzle.Include("section.tank.tanksetup").Where(n => n.isactive && n.section.stkcod == stcrd.stkcod && n.section.tank.tanksetup.id == tanksetup.id).ToList();
                }
                return nozzles;
            }
        }

        private void cNozzle__SelectedItemChanged(object sender, EventArgs e)
        {
            this.selected_nozzle = (nozzle)((XDropdownList)sender)._SelectedItem.Value;

            this.btnOK.Enabled = this.selected_nozzle != null && this.stcrd.trnval > 0 ? true : false;
        }

        private void cAmount__ValueChanged(object sender, EventArgs e)
        {
            this.stcrd.trnval = ((XNumEdit)sender)._Value;
            this.stcrd.trnqty = this.stcrd.trnval / this.stcrd.unitpr;

            this.btnOK.Enabled = this.selected_nozzle != null && this.stcrd.trnval > 0 ? true : false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F5)
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
    }
}
