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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogSalesHistory : Form
    {
        private salessummary salessummary;
        private List<saleshistory> saleshistory;
        private BindingSource bs;

        public DialogSalesHistory()
        {
            InitializeComponent();
        }

        public DialogSalesHistory(salessummary salessummary)
            : this()
        {
            this.salessummary = salessummary;
        }

        private void DialogSalesHistory_Load(object sender, EventArgs e)
        {
            this.lblSaleDate.Text = this.salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.lblShiftName.Text = this.salessummary.ToViewModel().shift_name;
            this.lblStkdes.Text = this.salessummary.ToViewModel().stkcod + " / " + this.salessummary.ToViewModel().stkdes;
            this.lblUnitpr.Text = string.Format("{0:#,#0.00}", this.salessummary.ToViewModel().unitpr);

            this.saleshistory = this.GetSalesHistory();
            this.bs = new BindingSource();
            this.bs.DataSource = this.saleshistory;
            this.dgvNozzle.DataSource = this.bs;
        }

        private List<saleshistory> GetSalesHistory()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.saleshistory.Where(s => s.salessummary_id == this.salessummary.id).ToList();
            }
        }
    }
}
