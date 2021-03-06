﻿using System;
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
        private artrn artrn;
        public stcrd stcrd;

        public DialogSellQty(MainForm main_form, artrn artrn, stcrd stcrd)
        {
            this.main_form = main_form;
            this.artrn = artrn;
            this.stcrd = stcrd;
            InitializeComponent();
        }

        private void DialogSellQty_Load(object sender, EventArgs e)
        {
            this.lblStkdes.Text = this.stcrd.stkcod.TrimEnd() + " : " + this.stcrd.stkdes.TrimEnd();
            this.cQty._Value = this.stcrd.trnqty;
        }

        private void DialogSellQty_Shown(object sender, EventArgs e)
        {
            //this.cQty.textBox1.SelectionStart = 0;
            //this.cQty.textBox1.SelectionLength = this.cQty.textBox1.Text.Length;
            this.cQty._SelectionStart = 0;
            this.cQty._SelectionLength = this.cQty._Text.Length;
        }

        private void cQty__ValueChanged(object sender, EventArgs e)
        {
            this.stcrd.trnqty = ((XNumEdit)sender)._Value;
            this.stcrd.trnval = ((XNumEdit)sender)._Value * this.stcrd.unitpr;
            this.stcrd.xsalval = this.artrn.flgvat == "1" ? Convert.ToDecimal(Math.Round(Convert.ToDouble(this.stcrd.trnval * (100 / (100 + this.artrn.vatrat))), 2)) : Convert.ToDecimal(this.stcrd.trnval);
            this.stcrd.netval = this.artrn.flgvat == "1" ? Convert.ToDecimal(Math.Round(Convert.ToDouble(this.stcrd.trnval * (100 / (100 + this.artrn.vatrat))), 2)) : Convert.ToDecimal(this.stcrd.trnval);

            this.btnOK.Enabled = this.stcrd.trnqty > 0 ? true : false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(!(this.btnOK.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
