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
    public partial class DialogPrice : Form
    {
        private MainForm main_form;
        //public pricetag pricetag;
        public List<pricelistVM> pricelist;
        private List<stmas> stmas_list;
        private BindingSource bs;
        private FORM_MODE form_mode;
        private XNumEdit inline_unitpr;

        public DialogPrice(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogPrice_Load(object sender, EventArgs e)
        {
            this.stmas_list = this.GetStmasList();

            //pricetag tmp = this.GetLastPrice();
            //if(tmp != null)
            //{
            //    this.pricetag = tmp;
            //}
            //else
            //{
            //    this.pricetag = new pricetag
            //    {
            //        id = -1,
            //        date = DateTime.Now,
            //        starttime = TimeSpan.Parse("0:0:0")
            //    };
            //}

            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;
            this.FillForm();
        }

        //private pricetag GetLastPrice()
        //{
        //    using (xpumpEntities db = DBX.DataSet())
        //    {
        //        var t = db.pricetag.Include("pricelist").Where(p => DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture).CompareTo(p.date.ToString("yyyyMMdd", CultureInfo.CurrentCulture)) <= 0).OrderByDescending(p => p.date).ThenByDescending(p => p.id).ToList().FirstOrDefault();

        //        return t;
        //    }
        //}

        private List<stmas> GetStmasList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.stmas.OrderBy(s => s.name).ToList();
            }
        }
        
        private void FillForm()
        {
            //pricetag pricetag = pricetag_to_fill != null ? pricetag_to_fill : this.pricetag;

            //this.dtDate._SelectedDate = pricetag.date;
            
            this.pricelist = new List<pricelistVM>();
            for (int i = 0; i < this.stmas_list.Count; i++)
            {
                var price = new pricelistVM
                {
                    id = -1,
                    stmas_id = this.stmas_list[i].id,
                    unitpr = 0m/*pricetag.pricelist.Where(p => p.stmas_id == this.stmas_list[i].id).FirstOrDefault() != null ? pricetag.pricelist.Where(p => p.stmas_id == this.stmas_list[i].id).First().unitpr : 0m*/
                };
                this.pricelist.Add(price);
            }
            this.bs.DataSource = this.pricelist;
        }
    }
}
