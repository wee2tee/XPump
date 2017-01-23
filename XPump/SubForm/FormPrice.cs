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
    public partial class FormPrice : Form
    {
        private MainForm main_form;
        private pricetag curr_pricetag;
        private pricetag temp_pricetag;
        private pricelist temp_pricelist;
        private BindingSource bs;
        private XBrowseBox inline_stkcod;
        private XTextEdit inline_stkdes;
        private XNumEdit inline_unitpr;
        private FORM_MODE form_mode;

        public FormPrice(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
            {
                if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        private void FormPrice_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();

            this.btnLast.PerformClick();

            this.dtDate._SelectedDateChanged += delegate
            {
                if (this.dtDate._SelectedDate.HasValue)
                {
                    if (this.temp_pricetag != null)
                        this.temp_pricetag.date = this.dtDate._SelectedDate.Value;
                }
                else
                {
                    this.dtDate._SelectedDate = DateTime.Now;
                }
            };
        }

        private pricetag GetPriceTag(int id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.pricetag.Include("pricelist").Where(p => p.id == id).FirstOrDefault();
            }
        }

        private void ShowInlineForm(int row_index)
        {

        }

        private void RemoveInlineForm()
        {
            if(this.inline_stkcod != null)
            {
                this.inline_stkcod.Dispose();
                this.inline_stkcod = null;
            }

            if(this.inline_stkdes != null)
            {
                this.inline_stkdes.Dispose();
                this.inline_stkdes = null;
            }

            if(this.inline_unitpr != null)
            {
                this.inline_unitpr.Dispose();
                this.inline_unitpr = null;
            }
        }

        private pricetag GetFirst()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.pricetag.Include("pricelist").OrderBy(p => p.date).FirstOrDefault();
            }
        }

        private pricetag GetLast()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.pricetag.Include("pricelist").OrderByDescending(p => p.date).FirstOrDefault();
            }
        }

        private pricetag GetPrevious()
        {
            if (this.curr_pricetag == null)
                return this.GetFirst();

            using (xpumpEntities db = DBX.DataSet())
            {
                return db.pricetag.Include("pricelist").OrderByDescending(p => p.date).Where(p => this.curr_pricetag.date.CompareTo(p.date) > 0).FirstOrDefault();
            }
        }

        private pricetag GetNext()
        {
            if (this.curr_pricetag == null)
                return this.GetLast();

            using (xpumpEntities db = DBX.DataSet())
            {
                return db.pricetag.Include("pricelist").OrderBy(p => p.date).Where(p => this.curr_pricetag.date.CompareTo(p.date) < 0).FirstOrDefault();
            }
        }

        private void FillForm(pricetag pricetag = null)
        {
            pricetag price = pricetag != null ? pricetag : this.curr_pricetag;

            if (price == null)
                return;

            this.dtDate._SelectedDate = price.date;
            this.bs.ResetBindings(true);
            this.bs.DataSource = price.pricelist.ToList().ToViewModel();
        }

        private void ResetControlState()
        {
            /* toolstrip button */
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* form control */
            this.dtDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD }, this.form_mode);
            this.btnAddItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSaveItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnStopItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.dgvPrice.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_pricetag = new pricetag
            {
                id = -1,
                date = DateTime.Now,
                starttime = TimeSpan.Parse("0:0:0"),
            };

            this.toolStrip1.Focus();
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.FillForm(this.temp_pricetag);
            this.dtDate.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.temp_pricetag = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.temp_pricetag == null)
                return;

            if(this.form_mode == FORM_MODE.ADD)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.pricetag.Add(this.temp_pricetag);
                        db.SaveChanges();
                        this.curr_pricetag = this.GetPriceTag(this.temp_pricetag.id);
                        this.FillForm();
                        this.btnStop.PerformClick();
                        this.btnAdd.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("วันที่", this.temp_pricetag.date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
                    }
                }

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet())
                {

                }

                return;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.curr_pricetag = this.GetFirst();
            this.FillForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.curr_pricetag = this.GetPrevious();
            this.FillForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.curr_pricetag = this.GetNext();
            this.FillForm();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.curr_pricetag = this.GetLast();
            this.FillForm();
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {

        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter && (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM))
            {
                if (this.dtDate._Focused)
                {
                    this.btnSave.PerformClick();
                    return true;
                }

                if(this.inline_unitpr != null && this.inline_unitpr._Focused)
                {
                    this.btnSaveItem.PerformClick();
                    return true;
                }

                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
