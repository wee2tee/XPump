using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.SubForm;

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
            using(xpumpEntities db = DBX.DataSet())
            {
                db.stmas.ToList();
            }
        }

        private void MnuShift_Click(object sender, EventArgs e)
        {
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(ShiftForm)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(ShiftForm)).First().form.Activate();
                return;
            }

            ShiftForm shift = new ShiftForm(this);
            shift.MdiParent = this;
            shift.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = shift, docPrefix = string.Empty });
        }

        private void MnuTank_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(TankForm)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(TankForm)).First().form.Activate();
                return;
            }

            TankForm tank = new TankForm(this);
            tank.MdiParent = this;
            tank.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = tank, docPrefix = string.Empty });
        }

        private void MnuNozzle_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(NozzleForm)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(NozzleForm)).First().form.Activate();
                return;
            }

            NozzleForm nozzle = new NozzleForm(this);
            nozzle.MdiParent = this;
            nozzle.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = nozzle, docPrefix = string.Empty });
        }

        private void MnuStmas_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(StmasForm)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(StmasForm)).First().form.Activate();
                return;
            }

            StmasForm stmas = new StmasForm(this);
            stmas.MdiParent = this;
            stmas.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = stmas, docPrefix = string.Empty });
        }
    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
