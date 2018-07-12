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
        private FormDailyClose form_dailyclose;
        private FORM_MODE form_mode;
        private daysttak daysttak;
        private daysttak tmp_daysttak;

        public DialogDayendItemEdit(MainForm main_form, FormDailyClose form_dailyclose, daysttak daysttak)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.form_dailyclose = form_dailyclose;
            this.daysttak = daysttak;
        }

        private void DialogDayendItemEdit_Load(object sender, EventArgs e)
        {
            this.daysttak = this.GetDaySttak(this.daysttak);
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ);
            //this.ActiveControl = this.numBegbal;
        }

        private daysttak GetDaySttak(daysttak daysttak)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
            {
                return db.daysttak.Include("dayend").Include("section").Where(d => d.id == daysttak.id).FirstOrDefault();
            }
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            string ac_edit = null;
            if (this.main_form.loged_in_status.is_secure)
            {
                if(this.form_dailyclose.scacclv != null)
                {
                    ac_edit = this.form_dailyclose.scacclv.edit;
                }
                else
                {
                    ac_edit = "N";
                }
            }

            this.numBegbal.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numRcvqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnSyncRcvqty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode, ac_edit);
            this.btnDother.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_edit);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode, ac_edit);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode, ac_edit);
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
            this.ResetFormSummary(daysttak);
        }

        private void ResetFormSummary(daysttak daysttak_to_fill = null)
        {
            daysttak daysttak = daysttak_to_fill != null ? daysttak_to_fill : this.daysttak;

            if (daysttak == null)
                return;

            daysttakVM vm = daysttak.ToViewModel(this.main_form.working_express_db);

            this.lblSalqty.Text = string.Format("{0:#,#0.00}", vm.salqty);
            this.lblDother.Text = string.Format("{0:#,#0.00}", vm.dother);
            this.lblAccbal.Text = string.Format("{0:#,#0.00}", vm.accbal);
        }

        private void btnSyncRcvqty_Click(object sender, EventArgs e)
        {
            if (this.tmp_daysttak == null)
                return;

            var rcv = this.daysttak.ToViewModel(this.main_form.working_express_db).GetRcvqty();

            if(this.tmp_daysttak.rcvqty != rcv)
            {
                if(XMessageBox.Show("ยอดรับสินค้าเปลี่ยนจาก " + string.Format("{0:#,#0.00}", this.tmp_daysttak.rcvqty) + " เป็น " + string.Format("{0:#,#0.00}", rcv) + " ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.tmp_daysttak.rcvqty = rcv;
                    this.FillForm(this.tmp_daysttak);
                }
            }

            this.numRcvqty.Focus();
        }

        private void btnDother_Click(object sender, EventArgs e)
        {
            DialogDother d = new DialogDother(this.main_form, this.form_dailyclose, this.daysttak.dayend, this.daysttak.section);
            Point p = this.btnDother.PointToScreen(Point.Empty);
            d.Location = new Point(p.X, p.Y + ((Button)sender).Height);

            d.ShowDialog();
            this.ResetFormSummary();
            this.btnClose.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.daysttak.dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() != true)
                return;

            this.tmp_daysttak = this.GetDaySttak(this.daysttak);
            if(this.tmp_daysttak.rcvqty < 0)
            {
                this.tmp_daysttak.rcvqty = this.tmp_daysttak.ToViewModel(this.main_form.working_express_db).GetRcvqty();
            }

            this.FillForm(this.tmp_daysttak);

            this.ResetControlState(FORM_MODE.EDIT);
            this.numBegbal.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.daysttak = this.GetDaySttak(this.daysttak);
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ);
            this.btnClose.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.daysttak.dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() != true)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
            {
                var daysttak_to_update = db.daysttak.Find(this.tmp_daysttak.id);

                if(daysttak_to_update != null)
                {
                    daysttak_to_update.begbal = this.tmp_daysttak.begbal;
                    daysttak_to_update.begdif = this.tmp_daysttak.begdif;
                    daysttak_to_update.rcvqty = this.tmp_daysttak.rcvqty;
                    daysttak_to_update.salqty = this.tmp_daysttak.salqty;
                    daysttak_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    daysttak_to_update.chgtime = DateTime.Now;

                    db.SaveChanges();

                    this.daysttak = this.GetDaySttak(daysttak_to_update);
                    this.FillForm();
                    this.ResetControlState(FORM_MODE.READ);
                    this.btnClose.Focus();
                }
                else
                {
                    XMessageBox.Show("ข้อมูลที่ท่านแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                }
            }
        }

        private void numBegbal__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_daysttak != null)
            {
                this.tmp_daysttak.begbal = ((XNumEdit)sender)._Value;
                this.ResetFormSummary(this.tmp_daysttak);
            }
        }

        private void numRcvqty__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_daysttak != null)
            {
                this.tmp_daysttak.rcvqty = ((XNumEdit)sender)._Value;
                this.ResetFormSummary(this.tmp_daysttak);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                if(this.form_mode == FORM_MODE.EDIT)
                {
                    this.btnStop.PerformClick();
                    return true;
                }
                if(this.form_mode == FORM_MODE.READ)
                {
                    this.btnClose.PerformClick();
                    return true;
                }
            }

            if(keyData == Keys.Enter)
            {
                if(this.btnSyncRcvqty.Focused || this.btnDother.Focused || this.btnEdit.Focused || this.btnStop.Focused || this.btnSave.Focused || this.btnClose.Focused)
                {
                    return false;
                }
                else
                {
                    if(this.form_mode == FORM_MODE.EDIT)
                    {
                        SendKeys.Send("{TAB}");
                        return true;
                    }
                }
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-2.3.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void numBegbal__DoubleClicked(object sender, EventArgs e)
        {
            if (this.daysttak.dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() != true)
                return;

            this.btnEdit.PerformClick();
            ((XNumEdit)sender).Focus();
        }

        private void numRcvqty__DoubleClicked(object sender, EventArgs e)
        {
            if (this.daysttak.dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() != true)
                return;

            this.btnEdit.PerformClick();
            ((XNumEdit)sender).Focus();
        }

        private void numRcvqty_Paint(object sender, PaintEventArgs e)
        {
            if(((XNumEdit)sender)._Value < 0)
            {
                ((XNumEdit)sender)._ForeColorReadOnlyState = Color.Red;
            }
            else
            {
                ((XNumEdit)sender)._ForeColorReadOnlyState = Color.Black;
            }
        }
    }
}
