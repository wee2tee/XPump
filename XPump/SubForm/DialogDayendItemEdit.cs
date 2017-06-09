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
    public partial class DialogDayendItemEdit : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private daysttak daysttak;
        private daysttak tmp_daysttak;

        public DialogDayendItemEdit(MainForm main_form, daysttak daysttak)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.daysttak = daysttak;
        }

        private void DialogDayendItemEdit_Load(object sender, EventArgs e)
        {
            this.daysttak = this.GetDaySttak(this.daysttak);
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ);
        }

        private daysttak GetDaySttak(daysttak daysttak)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.daysttak.Where(d => d.id == daysttak.id).FirstOrDefault();
            }
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.numBegbal.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numRcvqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnSyncRcvqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnDother.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnClose.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
        }

        private void FillForm(daysttak daysttak_to_fill = null)
        {
            daysttak daysttak = daysttak_to_fill != null ? daysttak_to_fill : this.daysttak;

            if(daysttak == null)
            {
                this.numBegbal._Value = 0m;
                this.numRcvqty._Value = 0m;
                this.lblAccbal.Text = "0.00";
                this.lblDother.Text = "0.00";
                this.lblSalqty.Text = "0.00";
                return;
            }

            daysttakVM vm = daysttak.ToViewModel(this.main_form.working_express_db);

            this.numBegbal._Value = daysttak.begbal;
            this.numRcvqty._Value = daysttak.rcvqty;
            this.lblSalqty.Text = string.Format("{0:#,#0.00}", vm.salqty);
            this.lblDother.Text = string.Format("{0:#,#0.00}", vm.dother);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnClose.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
