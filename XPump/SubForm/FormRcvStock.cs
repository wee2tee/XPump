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
        private BindingSource bs_stcrd;
        private FORM_MODE form_mode;

        public FormRcvStock(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormRcvStock_Load(object sender, EventArgs e)
        {
            this.bs_stcrd = new BindingSource();
            this.dgv.DataSource = this.bs_stcrd;
            this.FillForm();
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.brShift.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.brSupcod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtRcvdat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtVatdat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtVatnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);

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

                this.brShift._Text = aptrn.ToViewModel().shift_name;
                this.lblShift.Text = aptrn.ToViewModel().shift_desc;
                this.brSupcod._Text = aptrn.ToViewModel().supcod;
                this.lblSupnam.Text = aptrn.ToViewModel().supnam;
                this.txtVatnum._Text = aptrn.vatnum;
                this.dtRcvdat._SelectedDate = aptrn.id == -1 ? null : (DateTime?)aptrn.rcvdat;
                this.dtVatdat._SelectedDate = aptrn.id == -1 ? null : (DateTime?)aptrn.vatdat;

                this.bs_stcrd.ResetBindings(true);
                this.bs_stcrd.DataSource = aptrn.stcrd.ToViewModel();
            }
        }
    }
}
