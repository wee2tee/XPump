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
    public partial class FormRcvStock : Form
    {
        private MainForm main_form;
        private aptrn curr_aptrn;
        private aptrn tmp_aptrn;
        private stcrd curr_stcrd;
        private stcrd tmp_stcrd;

        public FormRcvStock(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormRcvStock_Load(object sender, EventArgs e)
        {

            this.FillForm();
        }

        private void FillForm(aptrn aptrn_to_fill = null)
        {
            aptrn aptrn = aptrn_to_fill != null ? aptrn_to_fill : this.curr_aptrn;

            if(aptrn == null)
            {
                aptrn = new aptrn
                {
                    id = -1,
                    apmas_id = -1,
                    rcvdat = DateTime.Now,
                    vatdat = DateTime.Now,
                    vatnum = string.Empty
                };

                this.brSupcod._Text = aptrn.ToViewModel().supcod;
                this.lblSupnam.Text = aptrn.ToViewModel().supnam;
                this.txtVatnum._Text = aptrn.vatnum;
                this.dtRcvdat._SelectedDate = aptrn.id == -1 ? null : (DateTime?)aptrn.rcvdat;
                this.dtVatdat._SelectedDate = aptrn.id == -1 ? null : (DateTime?)aptrn.vatdat;
            }
        }
    }
}
