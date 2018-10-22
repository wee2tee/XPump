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
        private artrn artrn;
        public stcrd stcrd;
        public nozzle selected_nozzle = null;

        public DialogSellValue(MainForm main_form, artrn artrn, stcrd stcrd, nozzle nozzle = null)
        {
            this.main_form = main_form;
            this.artrn = artrn;
            this.stcrd = stcrd;
            this.selected_nozzle = nozzle;
            InitializeComponent();
        }

        private void DialogSellValue_Load(object sender, EventArgs e)
        {
            this.lblSellDate.Text = this.stcrd.docdat.ToString("dd/MM/yy", CultureInfo.GetCultureInfo("th-TH"));
            this.lblStkdes.Text = this.stcrd.stkcod.TrimEnd() + " : " + this.stcrd.stkdes.TrimEnd();
            this.cAmount._Value = this.stcrd.trnval;

            var nozz = GetNozzleList(this.main_form.working_express_db, this.stcrd);
            foreach (var noz in GetNozzleList(this.main_form.working_express_db, this.stcrd))
            {
                this.cNozzle._Items.Add(new XDropdownListItem { Text = noz.name + " : " + noz.description, Value = noz });
            }

            if(this.selected_nozzle != null)
            {
                var noz = this.cNozzle._Items.Cast<XDropdownListItem>().Where(n => ((nozzle)n.Value).id == this.selected_nozzle.id).FirstOrDefault();

                if (noz != null)
                    this.cNozzle._SelectedItem = noz;
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
            this.stcrd.trnqty = Math.Round(this.stcrd.trnval / this.stcrd.unitpr, 4);
            this.stcrd.xsalval = this.artrn.flgvat == "1" ? Convert.ToDecimal(Math.Round(Convert.ToDouble(this.stcrd.trnval * (100 / (100 + this.artrn.vatrat))), 2)) : Convert.ToDecimal(this.stcrd.trnval);
            this.stcrd.netval = this.artrn.flgvat == "1" ? Convert.ToDecimal(Math.Round(Convert.ToDouble(this.stcrd.trnval * (100 / (100 + this.artrn.vatrat))), 2)) : Convert.ToDecimal(this.stcrd.trnval);

            this.btnOK.Enabled = this.selected_nozzle != null && this.stcrd.trnval > 0 ? true : false;
        }

        private void DialogSellValue_Shown(object sender, EventArgs e)
        {
            this.cAmount._SelectionStart = 0;
            this.cAmount._SelectionLength = this.cAmount._Text.Length;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (!(this.btnOK.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if (keyData == Keys.F9)
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
