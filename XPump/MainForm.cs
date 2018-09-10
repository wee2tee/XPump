using System;
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
        //public DbConnectionConfig db_conn_config = null;

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
            this.SetMenuBehavior(this.menuStrip1.Items);
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

            // Uncomment this to apply multi language menu
            this.SetUILanguage();
            this.Controls.RemoveByKey("menuStrip1");
            this.Controls.RemoveByKey("statusStrip1");
            this.InitializeComponent();
            this.SetMenuBehavior(this.menuStrip1.Items);
            this.SetStatusLabelText(null, null, this.loged_in_status.loged_in_user_name);

            this.mnuChangeCompany.PerformClick();

            // CREATE SETTINGS FOR THIS COMPANY IF NOT EXIST
            if(this.working_express_db != null && this.working_express_db.db_conn_config != null)
            {
                var test_connection = this.working_express_db.db_conn_config.TestMysqlDbConnection(this);

                if (!test_connection.is_connected)
                {
                    MessageBox.Show("ไม่สามารถติดต่อกับฐานข้อมูล " + this.working_express_db.db_conn_config.dbname + " ได้, กรุณาตรวจสอบการตั้งค่าการเชื่อมต่อฐานข้อมูล");
                    //this.mnuBranch.PerformClick();
                    DialogDbConfig db_conn = new DialogDbConfig(this, this.working_express_db.db_conn_config);
                    if(db_conn.ShowDialog() == DialogResult.OK)
                    {
                        this.working_express_db.db_conn_config = db_conn.curr_config;
                    }
                    else
                    {
                        //XMessageBox.Show("โปรแกรมจะปิดการทำงาน");
                        this.Close();
                        return;
                    }
                }
                DialogSettings.CreateSettingsProfile(this.working_express_db);
                /* Getting Department */
                //var x = DbfTable.Istab(this.working_express_db).ToIstabList().Where(t => t.tabtyp == "50").ToList();
                //Console.WriteLine(x.Count());
            }
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

        private void mnuSellRecord_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSellRecord)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSellRecord)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSellRecord)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }

            var sfac = this.GetSubFormAccessControl(FormSellRecord.modcod);
            FormSellRecord sell = new FormSellRecord(this, sfac);
            sell.MdiParent = this;
            sell.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            sell.Show();
            this.opened_child_form.Add(new ChildFormDetail { form = sell, docPrefix = string.Empty });
        }

        private void MnuShift_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
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
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankConfig)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
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
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
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

        private void mnuBranch_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormBranch)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormBranch)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormBranch)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }

            var scacclv = this.GetSubFormAccessControl(FormBranch.modcod);

            FormBranch br = new FormBranch(this);
            br.MdiParent = this;
            br.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = br, docPrefix = string.Empty });
        }

        private void mnuDailyClose_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormDailyClose)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormDailyClose)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormDailyClose)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }

            var scacclv = this.GetSubFormAccessControl(FormDailyClose.modcod);

            FormDailyClose daily = new FormDailyClose(this, scacclv);
            daily.MdiParent = this;
            daily.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            daily.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = daily, docPrefix = string.Empty });
        }

        private void mnuArmas_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormArmas)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormArmas)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormArmas)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }


            FormArmas fa = new FormArmas(this);
            fa.MdiParent = this;
            fa.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            fa.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = fa, docPrefix = string.Empty });
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

        private void mnuUsersFile_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSecure)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSecure)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormSecure)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }

            FormSecure sec = new FormSecure(this);
            sec.MdiParent = this;
            sec.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            sec.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = sec, docPrefix = string.Empty });
        }

        private void mnuEventLog_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormIslog)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormIslog)).First().form.Activate();
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormIslog)).First().form.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                return;
            }

            scacclvVM scacclv = this.GetSubFormAccessControl(FormIslog.modcod);

            FormIslog islog = new FormIslog(this, scacclv);
            islog.MdiParent = this;
            islog.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            islog.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = islog, docPrefix = string.Empty });
        }

        private void mnuYearEnd_Click(object sender, EventArgs e)
        {
            DialogYearEnd yearend = new DialogYearEnd(this);
            yearend.ShowDialog();
        }

        private void mnuChangeCompany_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Count > 0)
            {
                if (XMessageBox.Show(this.GetMessage("0999"), "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
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

            var previous_working_express_db = this.working_express_db;

            DialogSccompSelection sel = new DialogSccompSelection(this, sccomp, string.Empty);
            if (sel.ShowDialog() == DialogResult.OK)
            {
                if (this.working_express_db == null) // select company first entry
                {
                    this.working_express_db = sel.selected_sccomp;
                    this.working_express_db.db_conn_config = this.ShowBranchSelection();
                    if(this.working_express_db.db_conn_config == null)
                    {
                        this.Close();
                    }


                    this.islog.SelectCompany(this.working_express_db.abs_path, this.working_express_db.compnam).Save();

                }
                else // change company
                {
                    this.working_express_db = sel.selected_sccomp;
                    var db_config = this.ShowBranchSelection();
                    if(db_config != null)
                    {
                        this.working_express_db.db_conn_config = db_config;
                    }
                    else // select comp but not select branch
                    {
                        //this.Close();
                        this.working_express_db = previous_working_express_db;
                    }

                    this.islog.ChangeCompany(this.working_express_db.abs_path, this.working_express_db.compnam).Save();
                }

                this.SetStatusLabelText(this.working_express_db.abs_path.TrimEnd('\\'), this.working_express_db.db_conn_config, this.loged_in_status.loged_in_user_name);
                this.scacclv_list = this.GetScacclv(this.loged_in_status.loged_in_user_name);
                var x = this.menuStrip1.Items;
                this.SetMenuAccessible(this.menuStrip1.Items);
            }
            else
            {
                if (this.working_express_db == null)
                {
                    this.Close();
                }

                return;
            }
            this.SetStatusLabelText(this.working_express_db.abs_path.TrimEnd('\\'), null, null);

            //LocalDbConfig local_db = new LocalDbConfig(this.working_express_db);
            //if(local_db.ConfigValue == null)
            //{
            //    return;
            //}

            //if (local_db.ConfigValue.servername.Trim().Length == 0)
            //{
            //    DialogDbConfig config = new DialogDbConfig(this);
            //    if (config.ShowDialog() != DialogResult.OK)
            //    {
            //        this.Close();
            //        return;
            //    }
            //}
            //else
            //{
            //    MySqlConnectionResult test_connect = local_db.ConfigValue.TestMysqlDbConnection(this);

            //    if (test_connect.is_connected)
            //    {
            //        this.islog.ConnectMysqlSuccess(local_db.ConfigValue.servername, local_db.ConfigValue.dbname).Save();
            //    }
            //    else
            //    {
            //        this.islog.ConnectMysqlFail(local_db.ConfigValue.servername, local_db.ConfigValue.dbname, test_connect.err_message).Save();
            //        XMessageBox.Show(test_connect.err_message + ", กรุณาตรวจสอบการกำหนดการเชื่อมต่อ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);

            //        DialogDbConfig config = new DialogDbConfig(this);
            //        if (config.ShowDialog() != DialogResult.OK)
            //        {
            //            this.Close();
            //            return;
            //        }
            //    }

            //}
            //this.SetStatusLabelText(null, local_db.ConfigValue.dbname, null);
        }

        public DbConnectionConfig ShowBranchSelection()
        {
            var branch_list = new LocalDbConfig(this.working_express_db).BranchList;
            if (branch_list.Count == 0)
            {
                if (XMessageBox.Show("ยังไม่ได้สร้างรายชื่อสาขา, \n\t - คลิก \"ตกลง\" เพื่อสร้างรายชื่อสาขา \n\t - คลิก \"ยกเลิก\" เพื่อออกจากโปรแกรม", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DialogDbConfig c = new DialogDbConfig(this, null);
                    if (c.ShowDialog() == DialogResult.OK)
                    {
                        return c.curr_config;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            else if (branch_list.Count == 1)
            {
                return branch_list[0];
            }
            else // branch > 1
            {
                //MessageBox.Show("There's " + branch_list.Count.ToString() + " branch, Show branch selection dialog now");
                DialogBranchSelection br = new DialogBranchSelection(this);
                if (br.ShowDialog() == DialogResult.OK)
                {
                    return br.curr_conn_config;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetStatusLabelText(string express_db_path, DbConnectionConfig db_conn, string user_name)
        {
            this.lblExpressDataPath.Text = express_db_path != null ? express_db_path : this.lblExpressDataPath.Text;
            this.lblMysqlDbName.Text = db_conn != null ? db_conn.dbname : this.lblMysqlDbName.Text;
            this.lblUserID.Text = user_name != null ? user_name : this.lblUserID.Text;
        }

        public string GetCurrentDbName()
        {
            if (this.working_express_db == null)
                return string.Empty;

            LocalDbConfig loc = new LocalDbConfig(this.working_express_db);
            return loc.ConfigValue != null ? loc.ConfigValue.servername + "." + loc.ConfigValue.db_prefix + "_" + loc.ConfigValue.dbname : string.Empty;
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
                var all_menu_access = this.scacclv_list.Where(s => s.modcod == "ALLMENU").FirstOrDefault();

                foreach (ToolStripMenuItem mnu in menus.Cast<ToolStripItem>().Where(m => m.GetType() == typeof(ToolStripMenuItem)))
                {
                    if (mnu.OwnerItem != null && mnu.OwnerItem.GetType() == typeof(ToolStripMenuItem)) // is sub menu
                    {
                        mnu.Enabled = ((ToolStripMenuItem)mnu.OwnerItem).Enabled;
                    }
                    else // is top level menu
                    {
                        mnu.Enabled = all_menu_access != null ? (all_menu_access.read == "Y" ? true : false) : false;
                    }

                    if (mnu.Tag != null) // have tag (ToolStripMenuItem)
                    {
                        var curr_mnu_acc_lev = this.scacclv_list.Where(s => s.modcod == mnu.Tag.ToString().Trim()).FirstOrDefault();
                        if (curr_mnu_acc_lev != null) // have current menu config
                        {
                            mnu.Enabled = curr_mnu_acc_lev.read == "Y" ? true : false;
                        }
                        else // don't have current menu config
                        {
                            if (mnu.OwnerItem != null && mnu.OwnerItem.GetType() == typeof(ToolStripMenuItem)) // sub menu
                            {
                                if(((ToolStripMenuItem)mnu.OwnerItem).Tag != null)
                                {
                                    scmodul parent_mod = scmoduls.Where(s => s.modcod == mnu.OwnerItem.Tag.ToString().Trim()).FirstOrDefault();
                                    if (parent_mod == null)
                                        mnu.Enabled = false; //all_menu_access != null ? (all_menu_access.read == "Y" ? true : false) : false;

                                    scacclvVM parent_ac = this.scacclv_list.Where(s => s.modcod == parent_mod.modcod).FirstOrDefault();
                                    if (parent_ac != null)
                                    {
                                        mnu.Enabled = parent_ac.read == "Y" ? true : false;
                                    }
                                    else
                                    {
                                        mnu.Enabled = all_menu_access != null ? (all_menu_access.read == "Y" ? true : false) : false;
                                    }
                                }
                                else
                                {
                                    mnu.Enabled = all_menu_access != null ? (all_menu_access.read == "Y" ? true : false) : false;
                                }
                            }
                            else // top menu
                            {
                                mnu.Enabled = all_menu_access != null ? (all_menu_access.read == "Y" ? true : false) : false;
                            }
                        }
                    }
                    else // don't have tag (ToolStripSeparator)
                    {
                        continue;
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
                if(XMessageBox.Show(this.GetMessage("0999"), "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
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

    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
