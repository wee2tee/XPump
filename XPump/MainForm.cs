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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Local"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Local");
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LocalDb db = new LocalDb();
            if (db.LocalConfig.servername.Trim().Length == 0)
            {
                DialogDbConfig config = new DialogDbConfig();
                if (config.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (db.LocalConfig.TestMysqlConnection() == false)
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูล MySql ได้, กรุณาตรวจสอบการกำหนดการเชื่อมต่อ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogDbConfig config = new DialogDbConfig();
                if (config.ShowDialog() != DialogResult.OK)
                {
                    this.Close();
                }
            }
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
    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
