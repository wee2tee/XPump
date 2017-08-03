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
using System.Globalization;
using System.Threading;

namespace XPump.SubForm
{
    public partial class DialogYearEnd : Form
    {
        private MainForm main_form;
        private settings settings;
        private LocalDbConfig dbConfig;
        public string menu_id
        {
            get
            {
                return MenuIdClass.YearEnd;
            }
        }

        public DialogYearEnd(MainForm main_form)
        {
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            InitializeComponent();
            this.dbConfig = new LocalDbConfig(this.main_form.working_express_db);
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
            LoadingForm loading = new LoadingForm();
            loading.ShowCenterParent(this);

            bool result = false;
            string err_message = string.Empty;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
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
                            err_message = string.Format(this.main_form.GetMessage("0023"), last_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")));
                            result = false;

                            last_shiftsales = null;
                            return;
                        }
                    }
                }

                /** Get list of dayend (in last day of year) **/
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        if (last_dayend != null)
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

                        dayend_to_process = db.dayend
                                            //.Include("daysttak").Include("dother")
                                            .Where(d => d.saldat.CompareTo(settings.prdstart.Value) >= 0)
                                            .Where(d => d.saldat.CompareTo(settings.prdend.Value) <= 0)
                                            .ToList();

                        shiftsales_to_process = db.shiftsales
                                                //.Include("shiftsttak").Include("salessummary").Include("salessummary.pricelist")
                                                //.Include("salessummary.saleshistory").Include("salessummary.dother")
                                                .Where(s => s.saldat.CompareTo(settings.prdstart.Value) >= 0)
                                                .Where(s => s.saldat.CompareTo(settings.prdend.Value) <= 0)
                                                .ToList();

                        // Delete old data
                        for (int d = dayend_to_process.Count - 1; d >= 0; d--)
                        {
                            var dayend_id = dayend_to_process[d].id;
                            var dother = db.dother.Where(dd => dd.dayend_id.HasValue && dd.dayend_id.Value == dayend_id).ToList();
                            for (int i = dother.Count - 1; i >= 0; i--)
                            {
                                db.dother.Remove(db.dother.Find(dother[i].id));
                            }

                            var daysttak = db.daysttak.Where(ds => ds.dayend_id == dayend_id).ToList();
                            for (int i = daysttak.Count - 1; i >= 0; i--)
                            {
                                db.daysttak.Remove(db.daysttak.Find(daysttak[i].id));
                            }

                            db.dayend.Remove(db.dayend.Find(dayend_id));
                        }

                        for (int s = shiftsales_to_process.Count - 1; s >= 0; s--)
                        {
                            var shiftsales_id = shiftsales_to_process[s].id;

                            var dother = db.dother.Include("salessummary").Where(dd => dd.salessummary.shiftsales_id == shiftsales_id).ToList();
                            for (int i = dother.Count - 1; i >= 0; i--)
                            {
                                db.dother.Remove(db.dother.Find(dother[i].id));
                            }

                            var saleshistory = db.saleshistory.Include("salessummary").Where(sh => sh.salessummary.shiftsales_id == shiftsales_id).ToList();
                            for (int i = saleshistory.Count - 1; i >= 0; i--)
                            {
                                db.saleshistory.Remove(db.saleshistory.Find(saleshistory[i].id));
                            }

                            var salessummary = db.salessummary.Where(ss => ss.shiftsales_id == shiftsales_id).ToList();
                            for (int i = salessummary.Count - 1; i >= 0; i--)
                            {
                                var pricelist_id = salessummary[i].pricelist_id;

                                db.salessummary.Remove(db.salessummary.Find(salessummary[i].id));

                                db.pricelist.Remove(db.pricelist.Find(pricelist_id));
                            }

                            var shiftsttak = db.shiftsttak.Where(st => st.shiftsales_id == shiftsales_id).ToList();
                            for (int i = shiftsttak.Count - 1; i >= 0; i--)
                            {
                                db.shiftsttak.Remove(db.shiftsttak.Find(shiftsttak[i].id));
                            }

                            db.shiftsales.Remove(db.shiftsales.Find(shiftsales_to_process[s].id));
                        }
                        result = true;
                        db.SaveChanges();

                        this.main_form.islog.YearEnd(dbConfig.ConfigValue.dbname, this.settings.prdstart.Value, this.settings.prdend.Value).Save();
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        err_message = ex.Message;
                    }
                }
            };
            worker.RunWorkerCompleted += delegate
            {
                loading.Close();
                if(result == true)
                {
                    XMessageBox.Show(this.main_form.GetMessage("0024"));
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XMessageBox.Show(err_message, "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                }
            };
            worker.RunWorkerAsync();
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

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-3.2.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
