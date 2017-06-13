﻿using System;
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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogYearEnd : Form
    {
        private MainForm main_form;
        private settings settings;

        public DialogYearEnd(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogYearEnd_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.lblWarning.BackColor = MiscResource.IMPORTANT_MSG_BG;
            this.settings = DialogSettings.GetSettings(this.main_form.working_express_db);

            this.lblOldYearFrom.Text = this.settings.prdstart.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH"));
            this.lblOldYearTo.Text = this.settings.prdend.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH"));
            this.lblNewYearFrom.Text = this.settings.prdstart.Value.AddYears(1).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH"));
            this.lblNewYearTo.Text = this.settings.prdend.Value.AddYears(1).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH"));
            this.ActiveControl = this.txtYes;
        }

        private void txtYes__TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = ((XTextEdit)sender)._Text.Trim() == "YES" ? true : false;
        }

        private void txtYes__Leave(object sender, EventArgs e)
        {
            if (((XTextEdit)sender)._Text.Trim() != "YES")
            {
                ((XTextEdit)sender).Focus();
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            /** Check if last shiftsales not dayend yet **/
            dayend last_dayend = null;
            List<dayend> dayend_in_last_day = null;
            List<dayend> dayend_to_process = null;
            List<shiftsales> shiftsales_to_process = null;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var last_shiftsales = db.shiftsales
                                    .Where(s => s.saldat.CompareTo(this.settings.prdstart.Value) >= 0)
                                    .Where(s => s.saldat.CompareTo(this.settings.prdend.Value) <= 0)
                                    .OrderByDescending(s => s.saldat)
                                    .FirstOrDefault();

                last_dayend = db.dayend
                                    .Where(d => d.saldat.CompareTo(this.settings.prdstart.Value) >= 0)
                                    .Where(d => d.saldat.CompareTo(this.settings.prdend.Value) <= 0)
                                    .OrderByDescending(d => d.saldat)
                                    .FirstOrDefault();
                if (last_shiftsales != null && last_dayend != null)
                {
                    if (last_shiftsales.saldat.CompareTo(last_dayend.saldat) > 0)
                    {
                        XMessageBox.Show("ยังไม่สามารถปิดประมวลผลสิ้นปีได้ เนื่องจากรายการขายของวันที่ " + last_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ยังไม่ได้บันทึกปิดยอดขายประจำวัน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);

                        last_shiftsales = null;
                        return;
                    }
                }
            }

            /** Get list of dayend (in last day of year) **/
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if(last_dayend != null)
                {
                    dayend_in_last_day = db.dayend.Include("daysttak").Include("daysttak.section")
                                    .Where(d => d.saldat.CompareTo(last_dayend.saldat) == 0)
                                    .ToList();

                    // Collect section begacc begtak begdif
                    foreach (var d in dayend_in_last_day)
                    {
                        var daysttakvm = d.daysttak.ToViewModel(this.main_form.working_express_db).OrderBy(dvm => dvm.section_name);
                        foreach (var sttak in daysttakvm)
                        {
                            var section = db.section.Find(sttak.section_id);
                            if (section == null)
                                continue;

                            section.begacc = sttak.GetAccbal(this.settings.prdstart.Value);
                            section.begtak = sttak.qty;
                            section.begdif = section.begtak - section.begacc;
                        }
                    }
                    
                    // Change account period
                    settings st = db.settings.First();
                    st.prdstart = this.settings.prdstart.Value.AddYears(1);
                    st.prdend = this.settings.prdend.Value.AddYears(1);
                }

                dayend_to_process = db.dayend.Include("daysttak").Include("dother")
                                    .Where(d => d.saldat.CompareTo(settings.prdstart.Value) >= 0)
                                    .Where(d => d.saldat.CompareTo(settings.prdend.Value) <= 0)
                                    .ToList();

                shiftsales_to_process = db.shiftsales.Include("shiftsttak").Include("salessummary").Include("salessummary.pricelist")
                                        .Include("salessummary.saleshistory").Include("salessummary.dother")
                                        .Where(s => s.saldat.CompareTo(settings.prdstart.Value) >= 0)
                                        .Where(s => s.saldat.CompareTo(settings.prdend.Value) <= 0)
                                        .ToList();

                // Delete old data
                foreach (var dayend in dayend_to_process)
                {
                    foreach (var dother in dayend.dother)
                    {
                        db.dother.Remove(db.dother.Find(dother.id));
                    }

                    foreach (var daysttak in dayend.daysttak)
                    {
                        db.daysttak.Remove(db.daysttak.Find(daysttak.id));
                    }

                    db.dayend.Remove(db.dayend.Find(dayend.id));
                }

                foreach (var shiftsales in shiftsales_to_process)
                {
                    foreach (var salessummary in shiftsales.salessummary)
                    {
                        foreach (var dother in salessummary.dother)
                        {
                            db.dother.Remove(db.dother.Find(dother.id));
                        }

                        foreach (var saleshistory in salessummary.saleshistory)
                        {
                            db.saleshistory.Remove(db.saleshistory.Find(saleshistory.id));
                        }

                        db.pricelist.Remove(db.pricelist.Find(salessummary.pricelist_id));
                        db.salessummary.Remove(db.salessummary.Find(salessummary.id));
                    }

                    foreach (var shiftsttak in shiftsales.shiftsttak)
                    {
                        db.shiftsttak.Remove(db.shiftsttak.Find(shiftsttak.id));
                    }

                    db.shiftsales.Remove(db.shiftsales.Find(shiftsales.id));
                }

                db.SaveChanges();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(!(this.btnOK.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                }
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
