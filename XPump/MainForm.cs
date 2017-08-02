﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.Misc;
using XPump.SubForm;
using System.Data.SQLite;
using System.IO;
using CC;
using System.Threading;
using Newtonsoft.Json;

namespace XPump
{
    public partial class MainForm : Form
    {
        public List<ChildFormDetail> opened_child_form = new List<ChildFormDetail>();
        public LoginStatus loged_in_status;
        public SccompDbf working_express_db;
        public SecureDbConnectionConfig secure_db_config;
        public List<scacclvVM> scacclv_list;
        public Log islog;
        public const string helpfile = "Help.chm";
        public CultureInfo c_info = CultureInfo.GetCultureInfo("th-TH");
        public List<MsgTemplate> msg_template = new List<MsgTemplate>();

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string[] args)
            : this()
        {
            if (args.Count() > 0)
            {
                try
                {
                    string cmd_line = Environment.CommandLine;
                    string user_name = string.Empty;
                    string password = string.Empty;
                    foreach (var item in args)
                    {
                        if (item.Trim().ToUpper().Substring(0, 2) == "-U")
                        {
                            user_name = item.Trim().Substring(2, item.Trim().Length - 2);
                            continue;
                        }

                        if (item.Trim().ToUpper().Substring(0, 2) == "-P")
                        {
                            password = item.Trim().Substring(2, item.Trim().Length - 2);
                        }
                    }

                    this.loged_in_status = DialogLogIn.ValidateUser(user_name, password);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public void SetUILanguage()
        {
            if (this.loged_in_status != null && this.loged_in_status.language == UILANGUAGE.ENG)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("th-TH");
            }

            this.c_info = this.loged_in_status.language.GetCulture();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load message templat to memory
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\msg.json"))
            {
                using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\msg.json"))
                {
                    try
                    {
                        this.msg_template = JsonConvert.DeserializeObject<List<MsgTemplate>>(r.ReadToEnd());
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            this.islog = new Log(this);
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = string.Format("XPump V.{0}", version);
            this.SetMenuBehavior(menuStrip1.Items);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // CREATE MYSQL DB FOR STORING SECURE DATA
            LocalSecureDbConfig loc_sec = new LocalSecureDbConfig();
            if (!loc_sec.ConfigValue.TestMysqlSecureDbExist().is_connected) //!loc_sec.ConfigValue.TestMysqlConnection().is_connected)
            {
                DialogConnectDbServer conn_server = new DialogConnectDbServer(this);
                if (conn_server.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            this.secure_db_config = new LocalSecureDbConfig().ConfigValue;

            // LOG-IN
            if (this.loged_in_status == null)
            {
                DialogLogIn login = new DialogLogIn(this);
                if(login.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            else
            {
                this.islog.LoginSuccess(this.loged_in_status.loged_in_user_name).Save();
            }
            this.SetUILanguage();
            this.Controls.RemoveByKey("menuStrip1");
            this.Controls.RemoveByKey("statusStrip1");
            this.InitializeComponent();

            this.SetStatusLabelText(null, null, this.loged_in_status.loged_in_user_name);

            this.mnuChangeCompany.PerformClick();

            //this.scacclv_list = this.GetScacclv(this.loged_in_status.loged_in_user_name);
            //this.SetMenuAccessible(menuStrip1.Items);
        }

        private List<scacclvVM> GetScacclv(string user_name)
        {
            ScuserDbf user = DbfTable.Scuser().ToScuserList().Where(s => s.reccod.Trim() == user_name).FirstOrDefault();
            if (user == null)
                return new List<scacclvVM>();

            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                var reccod = user.reccod.Trim();
                var connectgrp = user.connectgrp.Trim();
                var compcod = this.working_express_db.compcod.Trim();

                //var sx = sec.scacclv.Where(s => (s.username == reccod || s.username == connectgrp) && s.datacod == compcod);
                var scacclv = sec.scacclv.Where(s => (s.username == user.reccod.Trim() || s.username == user.connectgrp.Trim()) && s.datacod == this.working_express_db.compcod.Trim()).ToViewModel();
                var sca_user = scacclv.Where(s => s.username == user.reccod.Trim()).ToList();
                var sca_group = scacclv.Where(s => s.username == user.connectgrp.Trim()).ToList();
                foreach (var sc in sca_group)
                {
                    if(sca_user.Where(s => s.datacod == sc.datacod && s.scmodul_id == sc.scmodul_id).FirstOrDefault() != null)
                    {
                        continue;
                    }
                    sca_user.Add(sc);
                }
                return sca_user;
            }
        }

        private void MnuShift_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).First().form.Activate();
                return;
            }
            var sfac = this.GetSubFormAccessControl(FormShift.modcod);
            FormShift shift = new FormShift(this, sfac);
            shift.MdiParent = this;
            shift.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            shift.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = shift, docPrefix = string.Empty });
        }

        private void MnuTankSetup_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankConfig)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankConfig)).First().form.Activate();
                return;
            }

            var scacclv = this.GetSubFormAccessControl(FormTankConfig.modcod);

            FormTankConfig tank = new FormTankConfig(this, scacclv);
            tank.MdiParent = this;
            tank.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            tank.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = tank, docPrefix = string.Empty });
        }

        private void mnuDotherMessage_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormIstab)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormIstab)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormIstab)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }

            var scacclv = this.GetSubFormAccessControl(FormIstab.modcod);

            FormIstab i = new FormIstab(this, scacclv, ISTAB_TABTYP.DOTHER, ((ToolStripMenuItem)sender).Text);
            i.MdiParent = this;
            i.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            i.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = i, docPrefix = string.Empty });
        }

        private void MnuShiftTransaction_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).First().form.Activate();
                return;
            }

            var scacclv = this.GetSubFormAccessControl(FormShiftTransaction.modcod);

            FormShiftTransaction trans = new FormShiftTransaction(this, scacclv);
            trans.MdiParent = this;
            trans.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            trans.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = trans, docPrefix = string.Empty });
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            var scacclv = this.GetSubFormAccessControl(DialogSettings.modcod);

            DialogSettings setting = new DialogSettings(this, scacclv);
            setting.ShowDialog();
        }

        private void mnuChangeCompany_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Count > 0)
            {
                if (XMessageBox.Show("โปรแกรมจะปิดหน้าต่างงานที่เปิดอยู่ทั้งหมดให้ก่อน, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                    return;

                for (int i = this.opened_child_form.Count - 1; i > -1; i--)
                {
                    this.opened_child_form[i].form.Close();
                }
            }

            List<SccompDbf> sccomp = DbfTable.Sccomp().ToSccompList().OrderBy(s => s.compnam).ToList();

            if (this.loged_in_status.is_secure)
            {
                List<string> comp_codes = DbfTable.Scacclv().ToScacclvList()
                                    .Where(s => s.compcod.Trim().Length > 0)
                                    .Where(s => s.accessid.Trim() == this.loged_in_status.loged_in_user_name || s.accessid.Trim() == this.loged_in_status.loged_in_user_group)
                                    .Where(s => s.isread == "Y")
                                    .Select(s => s.compcod).Distinct<string>().ToList();

                sccomp = sccomp.Where(s => comp_codes.Contains(s.compcod)).ToList();
            }

            DialogSccompSelection sel = new DialogSccompSelection(this, sccomp, string.Empty);
            if (sel.ShowDialog() == DialogResult.OK)
            {
                if(this.working_express_db == null)
                {
                    this.working_express_db = sel.selected_sccomp;
                    this.islog.SelectCompany(this.working_express_db.abs_path, this.working_express_db.compnam).Save();
                }
                else
                {
                    this.working_express_db = sel.selected_sccomp;
                    this.islog.ChangeCompany(this.working_express_db.abs_path, this.working_express_db.compnam).Save();
                }

                this.scacclv_list = this.GetScacclv(this.loged_in_status.loged_in_user_name);
                this.SetMenuAccessible(this.menuStrip1.Items);
            }
            else
            {
                if(this.working_express_db == null)
                {
                    this.Close();
                }

                return;
            }
            this.SetStatusLabelText(this.working_express_db.abs_path.TrimEnd('\\'), null, null);

            LocalDbConfig local_db = new LocalDbConfig(this.working_express_db);
            if (local_db.ConfigValue.servername.Trim().Length == 0)
            {
                DialogDbConfig config = new DialogDbConfig(this);
                if (config.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            else
            {
                MySqlConnectionResult test_connect = local_db.ConfigValue.TestMysqlDbConnection(this);

                if (test_connect.is_connected)
                {
                    this.islog.ConnectMysqlSuccess(local_db.ConfigValue.servername, local_db.ConfigValue.dbname).Save();
                }
                else
                {
                    this.islog.ConnectMysqlFail(local_db.ConfigValue.servername, local_db.ConfigValue.dbname, test_connect.err_message).Save();
                    XMessageBox.Show(test_connect.err_message + ", กรุณาตรวจสอบการกำหนดการเชื่อมต่อ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);

                    DialogDbConfig config = new DialogDbConfig(this);
                    if (config.ShowDialog() != DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                }

            }
            this.SetStatusLabelText(null, local_db.ConfigValue.dbname, null);
        }

        private void mnuDailyClose_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormDailyClose)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormDailyClose)).First().form.Activate();
                return;
            }

            var scacclv = this.GetSubFormAccessControl(FormDailyClose.modcod);

            FormDailyClose daily = new FormDailyClose(this, scacclv);
            daily.MdiParent = this;
            daily.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            daily.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = daily, docPrefix = string.Empty });
        }

        private void mnuSecure_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            XMessageBox.Show(this.GetMessage("0010"), "", MessageBoxButtons.OK, XMessageBoxIcon.Information);

            DialogBackupData bck = new DialogBackupData(this);
            bck.ShowDialog();

        }

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            DialogRestoreData restore = new DialogRestoreData(this);
            restore.ShowDialog();
        }

        private void mnuYearEnd_Click(object sender, EventArgs e)
        {
            DialogYearEnd yearend = new DialogYearEnd(this);
            yearend.ShowDialog();
        }

        public void SetStatusLabelText(string express_db_path, string mysql_db_name, string user_name)
        {
            this.lblExpressDataPath.Text = express_db_path != null ? express_db_path : this.lblExpressDataPath.Text;
            this.lblMysqlDbName.Text = mysql_db_name != null ? mysql_db_name : this.lblMysqlDbName.Text;
            this.lblUserID.Text = user_name != null ? user_name : this.lblUserID.Text;
        }

        public string GetCurrentDbName()
        {
            if (this.working_express_db == null)
                return string.Empty;

            LocalDbConfig loc = new LocalDbConfig(this.working_express_db);
            return loc != null ? loc.ConfigValue.servername + "." + loc.ConfigValue.db_prefix + "_" + loc.ConfigValue.dbname : string.Empty;
        }

        /* Set menu behavior for on EnableChanged */
        private void SetMenuBehavior(ToolStripItemCollection menus)
        {
            foreach (ToolStripMenuItem mnu in menus.Cast<ToolStripItem>().Where(m => m.GetType() == typeof(ToolStripMenuItem)))
            {
                mnu.EnabledChanged += new EventHandler(this.MenuItemEnableChanged);
                if (mnu.HasDropDownItems)
                {
                    this.SetMenuBehavior(mnu.DropDownItems);
                }
            }
        }

        private void MenuItemEnableChanged(object sender, EventArgs e)
        {
            var m = ((ToolStripMenuItem)sender);
            if(m.OwnerItem != null && m.OwnerItem.GetType() == typeof(ToolStripMenuItem))
            {
                if (m.Enabled)
                {
                    m.OwnerItem.Enabled = true;
                }
            }
        }

        /* Set menu accessible depend on scacclv */
        private void SetMenuAccessible(ToolStripItemCollection menus)
        {
            if (!this.loged_in_status.is_secure)
                return;

            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                var scmoduls = sec.scmodul.ToList();

                foreach (ToolStripMenuItem mnu in menus.Cast<ToolStripItem>().Where(m => m.GetType() == typeof(ToolStripMenuItem)))
                {
                    if (mnu.OwnerItem != null && mnu.OwnerItem.GetType() == typeof(ToolStripMenuItem)) // is sub menu
                    {
                        mnu.Enabled = ((ToolStripMenuItem)mnu.OwnerItem).Enabled;
                    }
                    else // is top level menu
                    {
                        mnu.Enabled = this.scacclv_list.Where(s => s.modcod == "ALLMENU").FirstOrDefault() != null ? true : false;
                    }

                    if (mnu.Tag != null)
                    {
                        var mod = this.scacclv_list.Where(s => s.modcod == mnu.Tag.ToString().Trim()).FirstOrDefault();
                        if (mod != null)
                        {
                            mnu.Enabled = mod.read == "Y" ? true : false;
                        }
                        else
                        {
                            if (mnu.OwnerItem != null && mnu.OwnerItem.GetType() == typeof(ToolStripMenuItem))
                            {
                                if(((ToolStripMenuItem)mnu.OwnerItem).Tag != null)
                                {
                                    scmodul parent_mod = scmoduls.Where(s => s.modcod == mnu.OwnerItem.Tag.ToString().Trim()).FirstOrDefault();
                                    if (parent_mod == null)
                                        mnu.Enabled = false;

                                    scacclvVM parent_ac = this.scacclv_list.Where(s => s.modcod == parent_mod.modcod).FirstOrDefault();
                                    if (parent_ac == null)
                                    {
                                        mnu.Enabled = false;
                                    }
                                    else
                                    {
                                        mnu.Enabled = parent_ac.read == "Y" ? true : false;
                                    }
                                }
                                else
                                {
                                    mnu.Enabled = true;
                                }
                            }
                            else
                            {
                                mnu.Enabled = false;
                            }
                        }
                    }

                    if (mnu.HasDropDownItems)
                    {
                        this.SetMenuAccessible(mnu.DropDownItems);
                    }
                }
            }
        }

        /* Get SubForm Access Control */
        private scacclvVM GetSubFormAccessControl(string modcod)
        {
            var sc = this.scacclv_list.Where(s => s.modcod == modcod).FirstOrDefault();
            if(sc != null)
            {
                return sc;
            }
            else
            {
                using (xpumpsecureEntities sec = DBX.DataSecureSet())
                {
                    var mod = sec.scmodul.Where(s => s.modcod == modcod).FirstOrDefault();
                    if (mod == null)
                        return null;

                    return this.GetSubFormAccessControl(mod.p_modcod);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.opened_child_form.Count > 0)
            {
                if(XMessageBox.Show("โปรแกรมจะปิดงานที่เปิดค้างอยู่ทั้งหมดให้ก่อน", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if(this.loged_in_status != null)
            {
                this.islog.Logout(this.loged_in_status.loged_in_user_name).Save();
            }
            
            base.OnFormClosing(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.1.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void mnuUsersFile_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSecure)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSecure)).First().form.Activate();
                return;
            }

            FormSecure sec = new FormSecure(this);
            sec.MdiParent = this;
            sec.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            sec.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = sec, docPrefix = string.Empty });
        }
    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
