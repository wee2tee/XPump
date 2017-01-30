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

            //Console.WriteLine(" .. >>>>>> 321.456 {0:#,##0.00}" + string.Format("{0:#,##0.00} ", 321.456));
            //Console.WriteLine(" .. >>>>>> 654321.456 {0:#,##0.00}" + string.Format("{0:#,##0.00} ", 654321.456));
            //Console.WriteLine(" .. >>>>>> 7654321.456 {0:#,##0.00}" + string.Format("{0:#,##0.00} ", 7654321.456));
            //Console.WriteLine(" .. -----------------------------..");
            //Console.WriteLine(" .. >>>>>> 9987654321.456 {0:#,#0.00}" + string.Format(CultureInfo.CurrentCulture,"{0:#,#0} ", 9987654321.656));
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
            //if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTank)).FirstOrDefault() != null)
            //{
            //    this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTank)).First().form.Activate();
            //    return;
            //}

            //FormTank tank = new FormTank(this);
            //tank.MdiParent = this;
            //tank.Show();
            //this.opened_child_form.Add(new ChildFormDetail() { form = tank, docPrefix = string.Empty });
            if (this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankSetup)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormTankSetup)).First().form.Activate();
                return;
            }

            FormTankSetup tank = new FormTankSetup(this);
            tank.MdiParent = this;
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
            stmas.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = stmas, docPrefix = string.Empty });
        }

        private void รายชอผคานำมนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormApmas)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormApmas)).First().form.Activate();
                return;
            }

            FormApmas apmas = new FormApmas(this);
            apmas.MdiParent = this;
            apmas.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = apmas, docPrefix = string.Empty });
        }

        private void MnuPrice_Click(object sender, EventArgs e)
        {
            
        }

        private void MnuShiftTransaction_Click(object sender, EventArgs e)
        {
            //DialogPrice price = new DialogPrice(this);
            //if(price.ShowDialog() == DialogResult.OK)
            //{
            //    //string str = string.Empty;

            //    //foreach (pricelist item in price.price_list)
            //    //{
            //    //    str += "id : " + item.id + ", date : " + item.date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + ", stmas_id : " + item.stmas_id + "\n";
            //    //}

            //    //MessageBox.Show(str);

            //    _FormShiftTransaction s = new _FormShiftTransaction(this, price.price_list);
            //    s.ShowDialog();
            //}
            if(this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).FirstOrDefault() != null)
            {
                this.opened_child_form.Where(f => f.form.GetType() == typeof(FormShiftTransaction)).First().form.Activate();
                return;
            }

            FormShiftTransaction trans = new FormShiftTransaction(this);
            trans.MdiParent = this;
            trans.Show();
            this.opened_child_form.Add(new ChildFormDetail() { form = trans, docPrefix = string.Empty });
        }
    }

    public class ChildFormDetail
    {
        public Form form { get; set; }
        public string docPrefix { get; set; }
    }
}
