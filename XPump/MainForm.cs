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

namespace XPump
{
    public partial class MainForm : Form
    {
        public List<ChildFormDetail> opened_child_form = new List<ChildFormDetail>();
        public LoginStatus loged_in_status;
        public SccompDbf working_express_db;
        public SecureDbConnectionConfig secure_db_config;
        public Log islog;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            //if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Local"))
            //{
            //    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Local");
            //}
            this.islog = new Log(this);
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = string.Format("XPump V.{0}", version);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // CREATE MYSQL DB FOR STORING ISLOG
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
            this.SetStatusLabelText(null, null, this.loged_in_status.loged_in_user_name);

            this.mnuChangeCompany.PerformClick();
            // SELECT COMPANY
            //List<SccompDbf> sccomp = DbfTable.Sccomp().ToSccompList().OrderBy(s => s.compnam).ToList();
            
            //if (this.loged_in_status.is_secure)
            //{
            //    List<string> comp_codes = DbfTable.Scacclv().ToScacclvList()
            //                        .Where(s => s.compcod.Trim().Length > 0)
            //                        .Where(s => s.accessid.Trim() == this.loged_in_status.loged_in_user_name || s.accessid.Trim() == this.loged_in_status.loged_in_user_group)
            //                        .Where(s => s.isread == "Y")
            //                        .Select(s => s.compcod).Distinct<string>().ToList();

            //    sccomp = sccomp.Where(s => comp_codes.Contains(s.compcod)).ToList();
            //}
            
            //DialogSccompSelection sel = new DialogSccompSelection(this, sccomp, string.Empty);
            //if (sel.ShowDialog() == DialogResult.OK)
            //{
            //    this.working_express_db = sel.selected_sccomp;
            //    this.islog.SelectCompany(this.working_express_db.abs_path, this.working_express_db.compnam).Save();
            //}
            //else
            //{
            //    this.Close();
            //    return;
            //}
            //this.SetStatusLabelText(this.working_express_db.abs_path.TrimEnd('\\'), null, null);

            //LocalDbConfig local_db = new LocalDbConfig(this.working_express_db);
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
            //    MySqlConnectionResult test_connect = local_db.ConfigValue.TestMysqlDbConnection();

            //    if (test_connect.is_connected)
            //    {
            //        this.islog.ConnectMysqlSuccess(local_db.ConfigValue.servername, local_db.ConfigValue.dbname).Save();
            //    }
            //    else
            //    {
            //        this.islog.ConnectMysqlFail(local_db.ConfigValue.servername, local_db.ConfigValue.dbname, test_connect.err_message).Save();
            //        MessageBox.Show(test_connect.err_message + ", กรุณาตรวจสอบการกำหนดการเชื่อมต่อ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void MnuShift_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).First().form.Activate();
                return;
            }

            FormShift shift = new FormShift(this);
            shift.MdiParent = this;
            shift.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            shift.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = shift, docPrefix = string.Empty });
        }

        private void MnuTank_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankSetup)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankSetup)).First().form.Activate();
                return;
            }

            FormTankSetup tank = new FormTankSetup(this);
            tank.MdiParent = this;
            tank.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            tank.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = tank, docPrefix = string.Empty });
        }

        private void MnuStmas_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormStmas)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormStmas)).First().form.Activate();
                return;
            }

            FormStmas stmas = new FormStmas(this);
            stmas.MdiParent = this;
            stmas.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            stmas.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = stmas, docPrefix = string.Empty });
        }

        private void MnuShiftTransaction_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).First().form.Activate();
                return;
            }

            FormShiftTransaction trans = new FormShiftTransaction(this);
            trans.MdiParent = this;
            trans.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            trans.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = trans, docPrefix = string.Empty });
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            DialogSettings setting = new DialogSettings(this);
            setting.ShowDialog();
        }

        private void mnuChangeCompany_Click(object sender, EventArgs e)
        {
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
                
            }
            else
            {
                this.Close();
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
                MySqlConnectionResult test_connect = local_db.ConfigValue.TestMysqlDbConnection();

                if (test_connect.is_connected)
                {
                    this.islog.ConnectMysqlSuccess(local_db.ConfigValue.servername, local_db.ConfigValue.dbname).Save();
                }
                else
                {
                    this.islog.ConnectMysqlFail(local_db.ConfigValue.servername, local_db.ConfigValue.dbname, test_connect.err_message).Save();
                    MessageBox.Show(test_connect.err_message + ", กรุณาตรวจสอบการกำหนดการเชื่อมต่อ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            FormDailyClose daily = new FormDailyClose(this);
            daily.MdiParent = this;
            daily.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            daily.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = daily, docPrefix = string.Empty });
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
            return loc != null ? loc.ConfigValue.servername + "." + loc.ConfigValue.dbname : string.Empty;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.opened_child_form.Count > 0)
            {
                if(MessageBox.Show("โปรแกรมจะปิดงานที่เปิดค้างอยู่ทั้งหมดให้ก่อน", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
