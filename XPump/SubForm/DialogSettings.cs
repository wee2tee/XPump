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

namespace XPump.SubForm
{
    public partial class DialogSettings : Form
    {
        private MainForm main_form;
        private LocalConfig localconfig;
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
                this.btnEdit.Enabled = !value;
                this.btnEditMysqlConnection.Enabled = !value;
            }
        }

        public DialogSettings(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

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
            dropdown._Items.Add(new XDropdownListItem { Text = "0 : อะไรก่อนก็ได้", Value = "0" });
            dropdown._Items.Add(new XDropdownListItem { Text = "1 : พิมพ์ก่อนรับรอง", Value = "1" });
            dropdown._Items.Add(new XDropdownListItem { Text = "2 : รับรองก่อนพิมพ์", Value = "2" });
        }

        private void BindConfigData2Control()
        {
            this.FormFreeze = true;
            this.localconfig = new LocalDb().LocalConfig;

            this.loading_form = new LoadingForm();
            this.loading_form.ShowCenterParent(this);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                this.is_mysql_connected = this.localconfig.TestMysqlConnection();
            };
            worker.RunWorkerCompleted += delegate
            {
                if (this.is_mysql_connected == true)
                {
                    BackgroundWorker w = new BackgroundWorker();
                    w.DoWork += delegate
                    {
                        using (xpumpEntities db = DBX.DataSet())
                        {
                            if (db.settings.ToList().Count() == 0)
                            {
                                db.settings.Add(new settings
                                {
                                    express_data_path = string.Empty,
                                    orgname = string.Empty
                                });
                                db.SaveChanges();
                            }
                        }

                        this.settings = GetSettings();
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
            /* Toolstrip button */
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);

            /* Form control */
            this.btnEditMysqlConnection.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnBrowseExpressData.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.txtOrgname.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
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
                settings = new settings
                {
                    id = -1,
                    express_data_path = string.Empty,
                    orgname = string.Empty,
                    shiftauthlev = string.Empty,
                    shiftprintmet = "0",
                    dayauthlev = string.Empty,
                    dayprintmet = "0"
                };
            }

            this.lblConnected.Visible = this.is_mysql_connected ? true : false;
            this.lblNotConnect.Visible = this.is_mysql_connected ? false : true;
            this.txtExpressData._Text = settings.express_data_path;
            this.txtOrgname._Text = settings.orgname;
            this.numShiftAuthLevel._Text = settings.shiftauthlev;
            this.drShiftPrintMethod._SelectedItem = this.drShiftPrintMethod._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == settings.shiftprintmet).First();
            this.numDayAuthLevel._Text = settings.dayauthlev;
            this.drDayPrintMethod._SelectedItem = this.drDayPrintMethod._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == settings.dayprintmet).First();
        }

        public static settings GetSettings()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.settings.First();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.is_mysql_connected)
            {
                this.tmp_settings = GetSettings();
                this.FillForm(this.tmp_settings);

                this.form_mode = FORM_MODE.EDIT;
                this.ResetControlState();
                ((ToolStripButton)sender).GetCurrentParent().Focus();
                this.txtOrgname.textBox1.Focus();
            }
            else
            {
                MessageBox.Show("กรุณากำหนดค่าการเชื่อมต่อฐานข้อมูล MySql ให้เรียบร้อยก่อน", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    settings setting_to_update = db.settings.First();
                    setting_to_update.express_data_path = this.tmp_settings.express_data_path;
                    setting_to_update.orgname = this.tmp_settings.orgname;

                    db.SaveChanges();
                    this.settings = GetSettings();
                    this.FillForm();

                    this.form_mode = FORM_MODE.READ;
                    this.ResetControlState();
                    this.tmp_settings = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            this.settings = GetSettings();
            this.FillForm();

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.tmp_settings = null;
        }

        private void btnBrowseExpressData_Click(object sender, EventArgs e)
        {
            DataTable dt = DbfTable.Sccomp();
            if (dt == null)
                return;

            List<SccompDbf> sccomp = dt.ToSccompList().OrderBy(s => s.compnam.Trim()).ToList(); //ToList<SccompDbf>();

            DialogSccompSelection sel = new DialogSccompSelection(this.main_form, sccomp, this.txtExpressData._Text.Trim());
            if (sel.ShowDialog() == DialogResult.OK)
            {
                this.txtExpressData._Text = sel.selected_sccomp.path;
            }
        }

        private void txtExpressData__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_settings != null)
                this.tmp_settings.express_data_path = ((XTextEdit)sender)._Text.Trim();
        }

        private void txtExpressData__DoubleClicked(object sender, EventArgs e)
        {
            this.PerformEdit(sender, e);
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtOrgname__TextChanged(object sender, EventArgs e)
        {
            if(this.tmp_settings != null)
                this.tmp_settings.orgname = ((XTextEdit)sender)._Text.Trim();
        }

        private void btnEditMysqlConnection_Click(object sender, EventArgs e)
        {
            DialogDbConfig db_config = new DialogDbConfig();
            if(db_config.ShowDialog() == DialogResult.OK)
            {
                this.BindConfigData2Control();
            }
        }
    }
}
