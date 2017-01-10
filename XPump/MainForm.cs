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
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShift)).First().form.Activate();
                return;
            }

            FormShift shift = new FormShift(this);
            shift.MdiParent = this;
            shift.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = shift, docPrefix = string.Empty });
        }

        private void MnuTank_Click(object sender, EventArgs e)
        {
            //if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTank_Old)).FirstOrDefault() != null)
            //{
            //    this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTank_Old)).First().form.Activate();
            //    return;
            //}

            //FormTank_Old tank = new FormTank_Old(this);
            //tank.MdiParent = this;
            //tank.Show();
            //this.opened_child_form.Add(new ChildFormDetail() { form = tank, docPrefix = string.Empty });
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTank)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTank)).First().form.Activate();
                return;
            }

            FormTank tank = new FormTank(this);
            tank.MdiParent = this;
            tank.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = tank, docPrefix = string.Empty });
        }

        private void MnuNozzle_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormNozzle)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormNozzle)).First().form.Activate();
                return;
            }

            FormNozzle nozzle = new FormNozzle(this);
            nozzle.MdiParent = this;
            nozzle.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = nozzle, docPrefix = string.Empty });
        }

        private void mnuTankSetup_Click(object sender, EventArgs e)
        {

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
