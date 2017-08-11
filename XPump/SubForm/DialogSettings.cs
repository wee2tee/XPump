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
using System.Data.OleDb;
using System.IO;
using System.Globalization;
using System.Threading;

namespace XPump.SubForm
{
    public enum PRINT_METHOD : int
    {
        NOT_ASSIGN = 0,
        PRINT_BEFORE_APPROVED = 1,
        APPROVED_BEFORE_PRINT = 2
    }

    public partial class DialogSettings : Form
    {
        public const string modcod = "21";
        private MainForm main_form;
        public scacclvVM scacclv;
        private DbConnectionConfig localconfig;
        private bool is_mysql_connected;
        private settings settings;
        private settings tmp_settings;
        private FORM_MODE form_mode;
        private LoadingForm loading_form;
        private bool FormFreeze
        {
            get
            {
                return !this.btnEditMysqlConnection.Enabled;
            }
            set
            {
                if (this.main_form.loged_in_status.is_secure)
                {
                    if (this.scacclv != null)
                    {
                        this.btnEdit.Enabled = this.scacclv.edit == "Y" ? true : false;
                        return;
                    }
                    else
                    {
                        this.btnEdit.Enabled = false;
                        return;
                    }
                }

                this.btnEdit.Enabled = !value;
                this.btnEditMysqlConnection.Enabled = !value;
            }
        }

        public DialogSettings(MainForm main_form, scacclvVM scacclv)
        {
            this.main_form = main_form;
            Thread.CurrentThread.CurrentUICulture = this.main_form.c_info;
            InitializeComponent();
            this.scacclv = scacclv;
        }

        //public void SetUILanguage()
        //{
        //    if(this.main_form.loged_in_status.language == UILANGUAGE.ENG)
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        //    }
        //    else
        //    {
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("th-TH");
        //    }
        //}

        private void DialogSettings_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.AddSelectorItems(this.drShiftPrintMethod);
            this.AddSelectorItems(this.drDayPrintMethod);
        }

        private void DialogSettings_Shown(object sender, EventArgs e)
        {
            this.BindConfigData2Control();
        }

        private void AddSelectorItems(XDropdownList dropdown)
        {
            if(this.main_form.loged_in_status.language == UILANGUAGE.THA)
            {
                dropdown._Items.Add(new XDropdownListItem { Text = "0 : อะไรก่อนก็ได้", Value = "0" });
                dropdown._Items.Add(new XDropdownListItem { Text = "1 : พิมพ์ก่อนรับรอง", Value = "1" });
                dropdown._Items.Add(new XDropdownListItem { Text = "2 : รับรองก่อนพิมพ์", Value = "2" });
            }
            else
            {
                dropdown._Items.Add(new XDropdownListItem { Text = "0 : Not strict", Value = "0" });
                dropdown._Items.Add(new XDropdownListItem { Text = "1 : Print before approve", Value = "1" });
                dropdown._Items.Add(new XDropdownListItem { Text = "2 : Approve before print", Value = "2" });
            }
        }

        private void BindConfigData2Control()
        {
            this.FormFreeze = true;
            this.localconfig = new LocalDbConfig(this.main_form.working_express_db).ConfigValue;

            this.loading_form = new LoadingForm();
            this.loading_form.ShowCenterParent(this);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                this.is_mysql_connected = this.localconfig.TestMysqlDbConnection(this.main_form).is_connected;
            };
            worker.RunWorkerCompleted += delegate
            {
                if (this.is_mysql_connected == true)
                {
                    BackgroundWorker w = new BackgroundWorker();
                    w.DoWork += delegate
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            if (db.settings.ToList().Count() == 0)
                            {
                                db.settings.Add(new settings
                                {
                                    //express_data_path = string.Empty,
                                    orgname = string.Empty
                                });
                                db.SaveChanges();
                            }
                        }

                        this.settings = GetSettings(this.main_form.working_express_db);
                    };
                    w.RunWorkerCompleted += delegate
                    {
                        this.FillForm();
                        this.loading_form.Close();
                        this.FormFreeze = false;
                    };
                    w.RunWorkerAsync();
                }
                else
                {
                    this.loading_form.Close();
                    this.FormFreeze = false;
                }
            };
            worker.RunWorkerAsync();
        }

        private void ResetControlState()
        {
            string ac_edit = null;
            if (this.main_form.loged_in_status.is_secure)
            {
                if(this.scacclv != null)
                {
                    ac_edit = this.scacclv.edit;
                }
                else
                {
                    ac_edit = "N";
                }
            }

            /* Toolstrip button */
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_edit);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode, ac_edit);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode, ac_edit);

            /* Form control */
            this.btnEditMysqlConnection.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_edit);
            //this.btnBrowseExpressData.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtOrgname.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.dtPeriodFrom.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.dtPeriodTo.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.drShiftPrintMethod.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.drDayPrintMethod.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numShiftAuthLevel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.numDayAuthLevel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
        }

        private void FillForm(settings settings_value_to_fill = null)
        {
            settings settings = settings_value_to_fill != null ? settings_value_to_fill : this.settings;

            if(settings == null)
            {
                IsprdDbf isprd = DbfTable.Isprd(this.main_form.working_express_db).ToIsprd();

                settings = new settings
                {
                    id = -1,
                    //express_data_path = string.Empty,
                    orgname = string.Empty,
                    prdstart = isprd.beg1.HasValue ? isprd.beg1.Value : DateTime.Parse(DateTime.Now.ToString("yyyy", CultureInfo.GetCultureInfo("en-US")) + "-01-01", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None),
                    prdend = isprd.end12.HasValue ? isprd.end12.Value : DateTime.Parse(DateTime.Now.ToString("yyyy", CultureInfo.GetCultureInfo("en-US")) + "-01-01", CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None).AddMonths(11).AddDays(30),
                shiftauthlev = 0,
                    shiftprintmet = "0",
                    dayauthlev = 0,
                    dayprintmet = "0"
                };
            }

            this.lblConnected.Visible = this.is_mysql_connected ? true : false;
            this.lblNotConnect.Visible = this.is_mysql_connected ? false : true;
            this.txtOrgname._Text = settings.orgname;
            this.dtPeriodFrom._SelectedDate = settings.prdstart;
            this.dtPeriodTo._SelectedDate = settings.prdend;
            this.numShiftAuthLevel._Text = settings.shiftauthlev.ToString();
            this.drShiftPrintMethod._SelectedItem = this.drShiftPrintMethod._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == settings.shiftprintmet).First();
            this.numDayAuthLevel._Text = settings.dayauthlev.ToString();
            this.drDayPrintMethod._SelectedItem = this.drDayPrintMethod._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == settings.dayprintmet).First();
        }

        public static settings GetSettings(SccompDbf working_express_db)
        {
            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                return db.settings.First();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.is_mysql_connected)
            {
                this.tmp_settings = GetSettings(this.main_form.working_express_db);
                this.FillForm(this.tmp_settings);

                this.form_mode = FORM_MODE.EDIT;
                this.ResetControlState();
                ((ToolStripButton)sender).GetCurrentParent().Focus();
                this.txtOrgname.textBox1.Focus();
            }
            else
            {
                XMessageBox.Show(this.main_form.GetMessage("0007"), "", MessageBoxButtons.OK, XMessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.tmp_settings.prdstart.HasValue || !this.tmp_settings.prdend.HasValue)
            {
                XMessageBox.Show(this.main_form.GetMessage("0008"), "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return;
            }
            //if (!this.tmp_settings.prdend.HasValue)
            //{
            //    XMessageBox.Show("กรุณาระบุวันที่สิ้นสุดรอบบัญชี", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
            //    return;
            //}

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    settings setting_to_update = db.settings.First();

                    // Warning if accounting period is changed
                    if(setting_to_update.prdstart.HasValue && setting_to_update.prdend.HasValue && (setting_to_update.prdstart != this.tmp_settings.prdstart || setting_to_update.prdend != this.tmp_settings.prdend))
                    {
                        if (XMessageBox.Show(this.main_form.GetMessage("0009"), "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                        return;
                    }
                    
                    setting_to_update.orgname = this.tmp_settings.orgname;
                    setting_to_update.prdstart = this.tmp_settings.prdstart;
                    setting_to_update.prdend = this.tmp_settings.prdend;
                    setting_to_update.shiftprintmet = this.tmp_settings.shiftprintmet;
                    setting_to_update.shiftauthlev = this.tmp_settings.shiftauthlev;
                    setting_to_update.dayprintmet = this.tmp_settings.dayprintmet;
                    setting_to_update.dayauthlev = this.tmp_settings.dayauthlev;
                    setting_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    setting_to_update.chgtime = DateTime.Now;

                    db.SaveChanges();
                    this.main_form.islog.ChangeSettings().Save();
                    this.settings = GetSettings(this.main_form.working_express_db);
                    this.FillForm();

                    this.form_mode = FORM_MODE.READ;
                    this.ResetControlState();
                    this.tmp_settings = null;
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            this.settings = GetSettings(this.main_form.working_express_db);
            this.FillForm();

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.tmp_settings = null;
        }

        //private void btnBrowseExpressData_Click(object sender, EventArgs e)
        //{
        //    //DataTable dt = DbfTable.Sccomp();
        //    //if (dt == null)
        //    //    return;

        //    //List<SccompDbf> sccomp = dt.ToSccompList().OrderBy(s => s.compnam.Trim()).ToList(); //ToList<SccompDbf>();

        //    //DialogSccompSelection sel = new DialogSccompSelection(this.main_form, sccomp, this.txtExpressData._Text.Trim());
        //    //if (sel.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    this.txtExpressData._Text = sel.selected_sccomp.path;
        //    //}
        //}

        //private void txtExpressData__TextChanged(object sender, EventArgs e)
        //{
        //    //if (this.tmp_settings != null)
        //    //    this.tmp_settings.express_data_path = ((XTextEdit)sender)._Text.Trim();
        //}

        //private void txtExpressData__DoubleClicked(object sender, EventArgs e)
        //{
        //    //this.PerformEdit(sender, e);
        //}

        private void btnEditMysqlConnection_Click(object sender, EventArgs e)
        {
            DialogDbConfig db_config = new DialogDbConfig(this.main_form);
            if (db_config.ShowDialog() == DialogResult.OK)
            {
                this.BindConfigData2Control();
            }
        }

        private void txtOrgname__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.orgname = ((XTextEdit)sender)._Text.Trim();
        }

        private void numShiftAuthLevel__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
            {
                int out_lev;
                if(Int32.TryParse(((XNumTextEdit)sender)._Text, out out_lev))
                {
                    this.tmp_settings.shiftauthlev = out_lev;
                }
                else
                {
                    this.tmp_settings.shiftauthlev = 0;
                }
            }
        }

        private void numDayAuthLevel__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
            {
                int out_lev;
                if (Int32.TryParse(((XNumTextEdit)sender)._Text, out out_lev))
                {
                    this.tmp_settings.dayauthlev = out_lev;
                }
                else
                {
                    this.tmp_settings.dayauthlev = 0;
                }
            }
        }

        private void drShiftPrintMethod__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.shiftprintmet = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void drDayPrintMethod__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.dayprintmet = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void dtPeriodFrom__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.prdstart = ((XDatePicker)sender)._SelectedDate;
        }

        private void dtPeriodTo__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.prdend = ((XDatePicker)sender)._SelectedDate;
        }

        private void PerformEdit(object sender, EventArgs e)
        {
            this.btnEdit.PerformClick();

            ((Control)sender).Focus();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.loading_form != null)
            {
                this.loading_form.Dispose();
                this.loading_form = null;
            }

            base.OnClosing(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if(this.form_mode == FORM_MODE.EDIT)
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if(keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                if(this.form_mode == FORM_MODE.READ)
                {
                    DialogDataInfo info = new DialogDataInfo("Settings", this.settings.id, 1, "%System%", null, this.settings.chgby, this.settings.chgtime);
                    info.ShowDialog();
                    return true;
                }
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.2.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
