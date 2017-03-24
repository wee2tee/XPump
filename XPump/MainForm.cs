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

                    //MessageBox.Show("user : \"" + user_name + "\"");
                    //MessageBox.Show("pass : \"" + password + "\"");

                    this.loged_in_status = DialogLogIn.ValidateUser(user_name, password);
                    //if (login.result == true)
                    //{
                    //    this.logedin_user_name = login.loged_in_user_name;
                    //}
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
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = string.Format("XPump V.{0}", version);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // LOG-IN
            if(this.loged_in_status == null)
            {
                DialogLogIn login = new DialogLogIn(this);
                if(login.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            this.SetStatusLabelText(null, null, this.loged_in_status.loged_in_user_name);

            // SELECT COMPANY
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
                this.working_express_db = sel.selected_sccomp;
            }
            else
            {
                this.Close();
                return;
            }
            this.SetStatusLabelText(this.working_express_db.abs_path.TrimEnd('\\'), null, null);

            LocalDb local_db = new LocalDb(this.working_express_db);
            if (local_db.LocalConfig.servername.Trim().Length == 0)
            {
                DialogDbConfig config = new DialogDbConfig(this);
                if (config.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            else if (local_db.LocalConfig.TestMysqlDbConnection().is_connected == false)
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูล MySql ได้, กรุณาตรวจสอบการกำหนดการเชื่อมต่อ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogDbConfig config = new DialogDbConfig(this);
                if (config.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            this.SetStatusLabelText(null, local_db.LocalConfig.dbname, null);

            //MySqlConnectionResult
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
    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
