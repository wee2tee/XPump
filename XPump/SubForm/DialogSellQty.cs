using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using CC;

namespace XPump.SubForm
{
    public partial class DialogSellQty : Form
    {
        private MainForm main_form;
        public stcrd stcrd;

        public DialogSellQty(MainForm main_form, stcrd stcrd)
        {
            this.main_form = main_form;
            this.stcrd = stcrd;
            InitializeComponent();
        }

        private void DialogSellQty_Load(object sender, EventArgs e)
        {
            this.lblStkdes.Text = this.stcrd.stkcod.TrimEnd() + " : " + this.stcrd.stkdes.TrimEnd();
        }

        private void cQty__ValueChanged(object sender, EventArgs e)
        {
            this.stcrd.trnqty = ((XNumEdit)sender)._Value;
            this.stcrd.trnval = ((XNumEdit)sender)._Value * this.stcrd.unitpr;

            this.btnOK.Enabled = this.stcrd.trnqty > 0 ? true : false;
        }
    }
}
