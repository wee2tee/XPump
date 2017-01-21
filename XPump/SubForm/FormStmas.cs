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
using System.Data.Entity.Infrastructure;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class FormStmas : Form
    {
        private MainForm main_form;
        private BindingSource bs_section;
        private BindingSource bs_nozzle;
        private BindingSource bs_price;
        private stmas curr_stmas; // current displayed stmas
        private stmas temp_stmas;
        private FORM_MODE form_mode;
        //private bool curr_tank_only, curr_nozzle_only, curr_price_only;
        private bool current_only = true;

        public FormStmas()
        {
            InitializeComponent();
        }

        public FormStmas(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void StmasForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.chkCurrentOnly.Checked = this.current_only;

            this.bs_section = new BindingSource();
            this.bs_nozzle = new BindingSource();
            this.bs_price = new BindingSource();
            this.dgvTank.DataSource = this.bs_section;
            this.dgvNozzle.DataSource = this.bs_nozzle;
            this.dgvPrice.DataSource = this.bs_price;

            this.BindingCustomControlEventHandler();

            this.btnLast.PerformClick();
        }

        private void BindingCustomControlEventHandler()
        {
            this.txtName.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_stmas != null)
                    this.temp_stmas.name = ((TextBox)sender).Text;
            };

            this.txtDescription.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_stmas != null)
                    this.temp_stmas.description = ((TextBox)sender).Text;
            };

            this.txtRemark.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_stmas != null)
                    this.temp_stmas.remark = ((TextBox)sender).Text;
            };
        }

        private void ResetControlState()
        {
            /*Toolstrip menu*/
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /*Form control*/
            this.txtName.SetControlState(new FORM_MODE[] { FORM_MODE.ADD }, this.form_mode);
            this.txtDescription.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtRemark.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            //this.chkCurrTankOnly.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            //this.chkCurrNozzleOnly.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            //this.chkCurrPriceOnly.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ)
            {
                if (MessageBox.Show(StringResource.Msg("0001"), "Message # 0001", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        public stmas GetStmas(int stmas_id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    return db.stmas.Include("pricelist").Include("saleshistory").Include("salessummary").Include("section").Where(s => s.id == stmas_id).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<nozzle> GetNozzleBySectionList(IEnumerable<section> section_list)
        {
            if (section_list == null)
                return new List<nozzle>();

            using (xpumpEntities db = DBX.DataSet())
            {
                try
                {
                    var sec = section_list.ToViewModel().Where(s => !s.end_date.HasValue || s.end_date.Value.ToString("yyyyMMdd", CultureInfo.CurrentCulture).CompareTo(DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture)) >= 0).Select(s => s.id).ToArray<int>();
                    var nozzle = db.nozzle.Where(n => sec.Contains(n.section_id)).ToList();
                    return nozzle;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private void FillForm(stmas stmas_to_fill = null)
        {
            stmas stmas = stmas_to_fill != null ? stmas_to_fill : this.curr_stmas;

            if (stmas == null)
                return;

            this.txtName._Text = stmas.name;
            this.txtDescription._Text = stmas.description;
            this.txtRemark._Text = stmas.remark;

            this.bs_section.ResetBindings(true);
            this.bs_section.DataSource = stmas.section.ToViewModel().Where(s => !s.end_date.HasValue || s.end_date.Value.ToString("yyyyMMdd", CultureInfo.CurrentCulture).CompareTo(DateTime.Now.ToString("yyyyMMdd", CultureInfo.CurrentCulture)) >= 0).ToList();

            this.bs_nozzle.ResetBindings(true);
            this.bs_nozzle.DataSource = this.GetNozzleBySectionList(stmas.section).ToViewModel();

            //this.btnEdit.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnDelete.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnFirst.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnPrevious.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnNext.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnLast.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnRefresh.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
            //this.btnSearch.Enabled = this.form_mode == FORM_MODE.READ && this.curr_stmas.id > 0 ? true : false;
        }

        private void dgvTank_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((XDatagrid)sender).Columns[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_tank_name.DataPropertyName).First().Index].DisplayIndex = 0;
            ((XDatagrid)sender).Columns[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_name.DataPropertyName).First().Index].DisplayIndex = 1;
            ((XDatagrid)sender).Columns[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_capacity.DataPropertyName).First().Index].DisplayIndex = 2;
            ((XDatagrid)sender).Columns[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_start.DataPropertyName).First().Index].DisplayIndex = 3;
            ((XDatagrid)sender).Columns[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_end.DataPropertyName).First().Index].DisplayIndex = 4;

            ((XDatagrid)sender).Columns[((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_capacity.DataPropertyName).First().Index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_stmas = new stmas()
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                remark = string.Empty,
            };

            this.txtRemark.Focus();
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.txtName.Focus();

            this.FillForm(this.temp_stmas);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_stmas == null)
                return;

            using (xpumpEntities db = DBX.DataSet())
            {
                stmas tmp = this.GetStmas(this.curr_stmas.id);

                if(tmp == null)
                {
                    MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.temp_stmas = tmp;
                this.form_mode = FORM_MODE.EDIT;
                this.ResetControlState();
                this.FillForm(this.temp_stmas);
                this.txtDescription.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(StringResource.Msg("0003"), "Message # 0003", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        stmas stmas_to_delete = db.stmas.Find(this.curr_stmas.id);
                        if(stmas_to_delete == null)
                        {
                            MessageBox.Show(StringResource.Msg("0004"), "Message # 0004", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        db.stmas.Remove(stmas_to_delete);
                        db.SaveChanges();
                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.FillForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.temp_stmas == null)
                return;

            if(this.form_mode == FORM_MODE.ADD)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.stmas.Add(this.temp_stmas);
                        db.SaveChanges();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.curr_stmas = this.GetStmas(this.temp_stmas.id);
                        this.FillForm();
                        this.btnAdd.PerformClick();
                    }
                    catch (DbUpdateException ex)
                    {
                        if (ex.InnerException.Message.ToLower().Contains("duplicate entry") || ex.InnerException.InnerException.Message.ToLower().Contains("duplicate entry"))
                        {
                            MessageBox.Show("รหัส \"" + this.temp_stmas.name + "\" มีอยู่แล้วในระบบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.txtName.Focus();
                        }
                    }
                }

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        stmas stmas = db.stmas.Find(this.temp_stmas.id);
                        if(stmas == null)
                        {
                            MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        stmas.name = this.temp_stmas.name;
                        stmas.description = this.temp_stmas.description;
                        stmas.remark = this.temp_stmas.remark;
                        db.SaveChanges();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                this.curr_stmas = db.stmas.Include("pricelist").Include("saleshistory").Include("salessummary").Include("section").OrderBy(s => s.name).FirstOrDefault();
                this.FillForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                stmas tmp = db.stmas.Include("pricelist").Include("saleshistory").Include("salessummary").Include("section").Where(s => s.name.CompareTo(this.curr_stmas.name) < 0).OrderByDescending(s => s.name).FirstOrDefault();

                if (tmp == null)
                    return;

                this.curr_stmas = tmp;
                this.FillForm();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                stmas tmp = db.stmas.Include("pricelist").Include("saleshistory").Include("salessummary").Include("section").Where(s => s.name.CompareTo(this.curr_stmas.name) > 0).OrderBy(s => s.name).FirstOrDefault();

                if (tmp == null)
                    return;

                this.curr_stmas = tmp;
                this.FillForm();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                stmas tmp = db.stmas.Include("pricelist").Include("saleshistory").Include("salessummary").Include("section").OrderByDescending(s => s.name).FirstOrDefault();

                if(tmp != null)
                {
                    this.curr_stmas = tmp;
                }
                else
                {
                    this.curr_stmas = new stmas()
                    {
                        id = -1,
                        name = string.Empty,
                        description = string.Empty,
                        remark = string.Empty
                    };
                }

                this.FillForm();
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            DialogSimpleSearch search = new DialogSimpleSearch("รหัสสินค้า", string.Empty);
            if(search.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    stmas tmp = db.stmas.Include("pricelist").Include("saleshistory").Include("salessummary").Include("section").Where(s => s.name.CompareTo(search.keyword) > -1).OrderBy(s => s.name).FirstOrDefault();

                    if(tmp == null)
                    {
                        MessageBox.Show(StringResource.Msg("0005"), "Message # 0005", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        this.curr_stmas = tmp;
                        this.FillForm();
                    }
                }
            }
        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            DialogInquiryStmas dlg = new DialogInquiryStmas();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if(dlg.selected_id > 0)
                {
                    this.curr_stmas = this.GetStmas(dlg.selected_id);
                    this.FillForm();
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            DialogInquiryStmas dlg = new DialogInquiryStmas(this.curr_stmas);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.selected_id > 0)
                {
                    this.curr_stmas = this.GetStmas(dlg.selected_id);
                    this.FillForm();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (this.curr_stmas == null || db.stmas.Count() == 0)
                {
                    this.curr_stmas = new stmas
                    {
                        id = -1,
                        name = string.Empty,
                        description = string.Empty,
                        remark = string.Empty
                    };
                    this.FillForm();
                    return;
                }

                if(db.stmas.Find(this.curr_stmas.id) != null) // if curr_stmas is exist in DB
                {
                    this.curr_stmas = this.GetStmas(this.curr_stmas.id);
                    this.FillForm();
                    return;
                }
                else // if curr_stmas is not exist in DB
                {
                    if (db.stmas.Where(s => s.name.CompareTo(this.curr_stmas.name) > 0).FirstOrDefault() != null) // if has next
                    {
                        this.btnNext.PerformClick();
                        return;
                    }
                    else
                    {
                        this.btnLast.PerformClick();
                        return;
                    }
                }

            }
            
        }

        //private void chkCurrTank_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.curr_tank_only = ((CheckBox)sender).Checked;
        //}

        //private void chkCurrNozzle_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.curr_nozzle_only = ((CheckBox)sender).Checked;
        //}

        //private void chkCurrPrice_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.curr_price_only = ((CheckBox)sender).Checked;
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.A))
            {
                this.btnAdd.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformButtonClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.L))
            {
                this.btnInquiryAll.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.L))
            {
                this.btnInquiryRest.PerformClick();
                return true;
            }

            if(keyData == Keys.PageUp)
            {
                this.btnPrevious.PerformClick();
                return true;
            }

            if(keyData == Keys.PageDown)
            {
                this.btnNext.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if (this.txtRemark.textBox1.Focused)
                {
                    this.btnSave.PerformClick();
                    return true;
                }

                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
