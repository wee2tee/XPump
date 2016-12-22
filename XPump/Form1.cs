using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

namespace XPump
{
    public partial class Form1 : Form
    {
        private BindingSource bs;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;


            using (xpumpEntities db = /*DBX.DataSet("localhost", "root", "12345", "xpump")*/new xpumpEntities())
            {
                this.bs.ResetBindings(true);
                this.bs.DataSource = db.shift.Include("saleshistory").Include("salessummary").ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}
