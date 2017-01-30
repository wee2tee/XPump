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
    public partial class _FormShiftTransaction : Form
    {
        MainForm main_form;
        List<pricelist> price_list;
        List<stmasPriceVM> stmas_list;
        List<nozzleVM> nozzle_list;
        BindingSource bs_stmas;
        BindingSource bs_nozzle;
        FORM_MODE form_mode;

        public _FormShiftTransaction(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        public _FormShiftTransaction(MainForm main_form, List<pricelist> price_list)
            : this(main_form)
        {
            this.price_list = price_list;
        }

        private void FormShiftTransaction_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.EDIT_ITEM;

            this.bs_stmas = new BindingSource();

            this.stmas_list = this.GetStmasPriceVMList();
            this.dgvStmas.DataSource = this.bs_stmas;
            this.bs_stmas.ResetBindings(true);
            this.bs_stmas.DataSource = this.stmas_list;

        }

        private List<stmasPriceVM> GetStmasPriceVMList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                var s = db.stmas.ToList().ToViewModel().ToPriceViewModel();

                foreach (var item in s)
                {
                    item.price_date = this.price_list.Where(p => p.stmas_id == item.stmas_id).FirstOrDefault() != null ? (DateTime?)this.price_list.Where(p => p.stmas_id == item.stmas_id).First().date : null;

                    item.price_id = this.price_list.Where(p => p.stmas_id == item.stmas_id).FirstOrDefault() != null ? this.price_list.Where(p => p.stmas_id == item.stmas_id).First().id : -1;

                    item.unitpr = this.price_list.Where(p => p.stmas_id == item.stmas_id).FirstOrDefault() != null ? this.price_list.Where(p => p.stmas_id == item.stmas_id).First().unitpr : 0m;
                }

                return s;
            }
        }

        private void dgvStmas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewColumn col = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_stmas_unitpr.DataPropertyName).First();

            col.HeaderCell.Style.Padding = new Padding(0, 0, 0, 0);
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
