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

namespace XPump.SubForm
{
    public partial class DialogNozzleSalesHistory : Form
    {
        private MainForm main_form;
        private List<saleshistory> sales_history;
        private DateTime saldat;
        private int nozzle_id;
        private Point position_to_display;
        private int window_width;
        private BindingSource bs;

        public DialogNozzleSalesHistory(MainForm main_form, DateTime saldat, int nozzle_id, Point position_to_display, int window_width = 720)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.saldat = saldat;
            this.nozzle_id = nozzle_id;
            this.position_to_display = position_to_display;
            this.window_width = window_width;
        }

        private void DialogNozzleSalesHistory_Load(object sender, EventArgs e)
        {
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;
            
            using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
            {
                //this.sales_history = db.saleshistory.Include("shift").Where(s => s.saldat == this.saldat && s.nozzle_id == this.nozzle_id).OrderBy(s => s.shift.name).ToList();
                this.bs.DataSource = this.sales_history.ToViewModel(this.main_form.working_express_db);
            }
            var x = this.position_to_display.X - this.window_width;
            
            var height = this.dgv.ColumnHeadersHeight + (this.dgv.RowTemplate.Height * this.sales_history.Count) + 10;
            this.SetBounds(x, this.position_to_display.Y, this.window_width, height);
        }

        private void DialogNozzleSalesHistory_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogNozzleSalesHistory_Shown(object sender, EventArgs e)
        {
            int hscroll_height = this.dgv.Controls.OfType<HScrollBar>().Count() > 0 && this.dgv.Controls.OfType<HScrollBar>().First().Visible ? SystemInformation.HorizontalScrollBarHeight : 0;

            this.Height += hscroll_height;
        }
    }
}
