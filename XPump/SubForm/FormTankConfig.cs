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
    public partial class FormTankConfig : Form
    {
        public const string modcod = "22";
        public scacclvVM scacclv; 
        private MainForm main_form;
        private FORM_MODE form_mode;
        public tanksetup tanksetup;
        private BindingList<tankVM> list_tankVM = new BindingList<tankVM>();
        private BindingList<sectionVM> list_sectionVM = new BindingList<sectionVM>();
        private tanksetup tmp_tanksetup;
        private tankVM tmp_tankVM;
        private sectionVM tmp_sectionVM;
        private tank selected_tank;
        private section selected_section;
        private ITEM_TAB item_tab = ITEM_TAB.NONE;
        private enum ITEM_TAB
        {
            NONE,
            F7,
            F8
        }
        //private HelpProvider help;

        public FormTankConfig(MainForm main_form, scacclvVM scacclv)
        {
            InitializeComponent();
            //this.menu_id = this.GetType().Name;
            this.main_form = main_form;
            this.scacclv = scacclv;
            //this.help = new HelpProvider();
        }

        private void FormTankConfig_Load(object sender, EventArgs e)
        {
            //this.bs_tank = new BindingSource();
            //this.bs_tank.DataSource = this.list_tankVM;
            this.dgvTank.DataSource = this.list_tankVM;
            this.dgvSection.DataSource = this.list_sectionVM;

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.btnLast.PerformClick();
            this.ActiveControl = this.toolStrip1;

            //this.help.SetShowHelp(this.dtStartDate, true);
            //this.help.SetHelpString(this.dtStartDate, "this is a help..");

            //this.help.HelpNamespace = "xphelp.chm";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        public void ResetControlState()
        {
            string ac_add = null;
            string ac_edit = null;
            string ac_delete = null;

            if (this.main_form.loged_in_status.is_secure)
            {
                if(this.scacclv != null)
                {
                    ac_add = this.scacclv.add;
                    ac_edit = this.scacclv.edit;
                    ac_delete = this.scacclv.delete;
                }
                else
                {
                    ac_add = "N";
                    ac_edit = "N";
                    ac_delete = "N";
                }
            }

            /** Toolstrip item **/
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_add);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_edit);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_delete);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /** Form control **/
            this.btnAddTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnEditTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnDeleteTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnAddSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnEditSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnDeleteSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.dtStartDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dgvTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.dgvSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);

            if (this.form_mode == FORM_MODE.READ ||
                this.form_mode == FORM_MODE.ADD ||
                this.form_mode == FORM_MODE.EDIT)
            {
                this.lblTank.BackColor = Color.Transparent;
                this.lblSection.BackColor = Color.Transparent;
            }
        }

        public static tanksetup GetTankSetup(SccompDbf working_express_db, int tanksetup_id)
        {
            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                return db.tanksetup.Include("tank").Where(t => t.id == tanksetup_id).FirstOrDefault();
            }
        }

        private void FillForm(tanksetup data_to_fill = null)
        {
            tanksetup tanksetup = data_to_fill != null ? data_to_fill : this.tanksetup;

            if (tanksetup == null)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnStop.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnSearch.Enabled = false;
                this.btnInquiryAll.Enabled = false;
                this.btnInquiryRest.Enabled = false;
                this.btnItem.Enabled = false;
                this.btnTank.Enabled = false;
                this.btnSection.Enabled = false;
                //this.btnRefresh.Enabled = false;

                this.dtStartDate.SetDate(null);

                //this.list_tankVM = new List<tankVM>();
                //this.bs_tank.ResetBindings(true);
                //this.bs_tank.DataSource = this.list_tankVM;

                this.list_tankVM = new BindingList<tankVM>();
                this.dgvTank.DataSource = this.list_tankVM;
                this.list_sectionVM = new BindingList<sectionVM>();
                this.dgvSection.DataSource = this.list_sectionVM;

                return;
            }

            this.dtStartDate.SetDate((DateTime?)tanksetup.startdate);

            this.list_tankVM = new BindingList<tankVM>(tanksetup.tank.OrderBy(t => t.name).ToViewModel(this.main_form.working_express_db));
            this.dgvTank.DataSource = this.list_tankVM;

            if (this.dgvTank.CurrentCell != null)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    int tank_id = (int)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value;

                    this.list_sectionVM = new BindingList<sectionVM>(db.section.Where(s => s.tank_id == tank_id).OrderBy(s => s.name).ToViewModel(this.main_form.working_express_db));
                    this.dgvSection.DataSource = this.list_sectionVM;
                }
            }
            else
            {
                this.list_sectionVM = new BindingList<sectionVM>();
                this.dgvSection.DataSource = this.list_sectionVM;
            }
        }

        private void ShowInlineTankForm()
        {
            if (this.dgvTank.CurrentCell == null)
                return;

            int row_index = this.dgvTank.CurrentCell.RowIndex;

            this.tmp_tankVM = ((tank)this.dgvTank.Rows[row_index].Cells[this.col_tank_tank.Name].Value).ToViewModel(this.main_form.working_express_db);

            int col_index = this.dgvTank.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_tank_name.DataPropertyName).First().Index;

            this.inline_tankname.SetInlineControlPosition(this.dgvTank, row_index, col_index);
            this.inline_tankname._Text = this.tmp_tankVM.name;
            this.inline_tankname.Visible = true;
            this.inline_tankname.Focus();
        }

        private void ShowInlineSectionForm()
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            int row_index = this.dgvSection.CurrentCell.RowIndex;

            this.tmp_sectionVM = this.list_sectionVM[row_index];

            int col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_name.DataPropertyName).First().Index;

            this.inlineSectionName.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineSectionName._Text = this.tmp_sectionVM.name;
            this.inlineSectionName.Visible = this.form_mode == FORM_MODE.ADD_ITEM ? true : false;
            this.inlineSectionName.Focus();

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_stkcod.DataPropertyName).First().Index;
            this.inlineStkcod.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineStkcod._Text = this.tmp_sectionVM.stkcod;
            this.inlineStkcod.Visible = true;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_capacity.DataPropertyName).First().Index;
            this.inlineCapacity.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineCapacity._Value = this.tmp_sectionVM.capacity;
            this.inlineCapacity.Visible = true;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_begtak.DataPropertyName).First().Index;
            this.inlineBegtak.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineBegtak._Value = this.tmp_sectionVM.begtak;
            this.inlineBegtak.Visible = true;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_begacc.DataPropertyName).First().Index;
            this.inlineBegacc.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineBegacc._Value = this.tmp_sectionVM.begacc;
            this.inlineBegacc.Visible = true;

            this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzle_btn.DataPropertyName).First().DefaultCellStyle.Padding = new Padding(0, 0, 0, 50);
            

            if (this.form_mode == FORM_MODE.ADD_ITEM)
                this.inlineSectionName.Focus();

            if (this.form_mode == FORM_MODE.EDIT_ITEM)
                this.inlineStkcod.Focus();
        }

        private void RemoveInlineTankForm()
        {
            this.inline_tankname.Visible = false;

            this.tmp_tankVM = null;
        }

        private void RemoveInlineSectionForm()
        {
            this.inlineSectionName.Visible = false;
            this.inlineStkcod.Visible = false;
            this.inlineCapacity.Visible = false;
            this.inlineBegtak.Visible = false;
            this.inlineBegacc.Visible = false;

            this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzle_btn.DataPropertyName).First().DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            this.tmp_sectionVM = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tmp_tanksetup = new tanksetup
            {
                startdate = DateTime.Now,
                creby = this.main_form.loged_in_status.loged_in_user_name,
                tank = new List<tank>()
            };
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();

            this.FillForm(this.tmp_tanksetup);
            this.dtStartDate.txtDate.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                return;

            this.tmp_tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
            this.FillForm();

            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.dtStartDate.txtDate.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(XMessageBox.Show("ลบการตั้งค่าแท๊งค์เก็บน้ำมัน ของวันที่ \"" + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + "\", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var tank_ids = db.tank.Where(t => t.tanksetup_id == this.tanksetup.id).Select(s => s.id).ToArray();
                    var section_ids = db.section.Where(s => tank_ids.Contains(s.tank_id)).Select(s => s.id).ToArray();
                    var nozzle_ids = db.nozzle.Where(n => section_ids.Contains(n.section_id)).Select(s => s.id).ToArray();
                    
                    if(db.saleshistory.Where(s => nozzle_ids.Contains(s.nozzle_id)).FirstOrDefault() != null)
                    {
                        XMessageBox.Show("การตั้งค่าแท็งค์เก็บน้ำมันนี้มีการนำไปใช้งานแล้ว ไม่สามารถลบทิ้งได้", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                    else
                    {
                        try
                        {
                            //** delete nozzle **//
                            foreach (var n_id in nozzle_ids)
                            {
                                db.nozzle.Remove(db.nozzle.Find(n_id));
                            }
                            //** delete section **//
                            foreach (var s_id in section_ids)
                            {
                                db.section.Remove(db.section.Find(s_id));
                            }
                            //** delete tank **//
                            foreach (var t_id in tank_ids)
                            {
                                db.tank.Remove(db.tank.Find(t_id));
                            }
                            //** delete tanksetup **//
                            db.tanksetup.Remove(db.tanksetup.Find(this.tanksetup.id));

                            db.SaveChanges();
                            this.main_form.islog.DeleteData(modcod, "ลบการตั้งค่าแท๊งค์น้ำมันวันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), "tanksetup", this.tanksetup.id).Save();
                            this.btnPrevious.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.item_tab = ITEM_TAB.NONE;
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                //this.dgvTank.Enabled = true;
                //this.dgvSection.Enabled = true;
                this.tmp_tanksetup = null;
                this.tmp_tankVM = null;
                this.tmp_sectionVM = null;
                this.btnRefresh.PerformClick();
                return;
            }

            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.RemoveInlineTankForm();
                this.RemoveInlineSectionForm();

                if(this.form_mode == FORM_MODE.ADD_ITEM)
                {
                    this.list_tankVM.Remove(this.list_tankVM.Where(t => t.id == -1).FirstOrDefault());
                    this.list_sectionVM.Remove(this.list_sectionVM.Where(s => s.id == -1).FirstOrDefault());
                }
                else if(this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if(this.dgvTank.CurrentCell != null)
                        this.list_tankVM.ResetItem(this.dgvTank.CurrentCell.RowIndex);
                    if (this.dgvSection.CurrentCell != null)
                        this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
                }

                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
                {
                    if (this.tmp_tanksetup == null)
                        return;

                    var last_sale = db.salessummary.OrderByDescending(s => s.saldat).FirstOrDefault();
                    if (last_sale != null && last_sale.saldat.CompareTo(this.tmp_tanksetup.startdate) >= 0)
                    {
                        XMessageBox.Show("วันที่เริ่มใช้ต้องเป็นวันที่หลังจากรายการขายครั้งสุดท้าย, รายการขายครั้งสุดท้ายวันที่ \"" + last_sale.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + "\"", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }

                    if (this.form_mode == FORM_MODE.ADD)
                    {
                        LoadingForm loading = new LoadingForm();
                        loading.ShowCenterParent(this);

                        try
                        {
                            this.tmp_tanksetup.cretime = DateTime.Now;
                            db.tanksetup.Add(this.tmp_tanksetup);
                            db.SaveChanges();

                            // kept log
                            this.main_form.islog.AddData(modcod, "เพิ่มการตั้งค่าแท๊งค์เก็บน้ำมันวันที่ " + this.tmp_tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), "tanksetup", this.tmp_tanksetup.id).Save();
                           

                            this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tmp_tanksetup.id);
                            this.FillForm();
                            loading.Close();

                            this.form_mode = FORM_MODE.READ;
                            this.ResetControlState();
                            this.btnTank.PerformClick();
                            this.btnAddTank.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            loading.Close();
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }

                        return;
                    }

                    if (this.form_mode == FORM_MODE.EDIT)
                    {
                        LoadingForm loading = new LoadingForm();
                        loading.ShowCenterParent(this);

                        try
                        {
                            tanksetup tanksetup_to_update = db.tanksetup.Find(this.tmp_tanksetup.id);
                            if(tanksetup_to_update != null)
                            {
                                var old_date = tanksetup_to_update.startdate;
                                tanksetup_to_update.startdate = this.tmp_tanksetup.startdate;
                                tanksetup_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                tanksetup_to_update.chgtime = DateTime.Now;

                                // kept log
                                this.main_form.islog.EditData(modcod, "แก้ไขการตั้งค่าแท๊งค์เก็บน้ำมัน, เปลี่ยนวันที่ " + old_date.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " => " + this.tmp_tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), "tanksetup", this.tmp_tanksetup.id).Save();

                                db.SaveChanges();
                                this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tmp_tanksetup.id);
                                this.FillForm();
                                loading.Close();

                                this.form_mode = FORM_MODE.READ;
                                this.ResetControlState();
                            }
                            else
                            {
                                loading.Close();
                                XMessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            }
                        }
                        catch (Exception ex)
                        {
                            loading.Close();
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }
                    }
                }

                #region add/edit tank
                if (this.form_mode == FORM_MODE.ADD_ITEM && this.item_tab == ITEM_TAB.F8)
                {
                    if(this.tmp_tankVM != null)
                    {
                        if(this.tmp_tankVM.name.Trim().Length == 0)
                        {
                            return;
                        }

                        try
                        {
                            if (db.tank.Where(t => t.tanksetup_id == this.tmp_tankVM.tanksetup_id && t.name == this.tmp_tankVM.name).FirstOrDefault() != null)
                            {
                                XMessageBox.Show("รหัสแท๊งค์ \"" + this.tmp_tankVM.name + "\" นี้มีอยู่แล้ว ควรเปลี่ยนใหม่", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                this.inline_tankname.Focus();
                                return;
                            }

                            this.tmp_tankVM.tank.cretime = DateTime.Now;
                            db.tank.Add(this.tmp_tankVM.tank);
                            db.SaveChanges();
                            this.main_form.islog.AddData(modcod, "เพิ่มรหัสแท๊งค์ \"" + this.tmp_tankVM.name + "\", ในการตั้งค่าแท๊งค์วันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_tankVM.tank.name, "tank", this.tmp_tankVM.tank.id).Save();
                            this.RemoveInlineTankForm();
                            this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                            this.FillForm();

                            this.form_mode = FORM_MODE.READ_ITEM;
                            this.ResetControlState();
                            this.btnAddTank.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }

                        return;
                    }
                }

                if(this.form_mode == FORM_MODE.EDIT_ITEM && this.item_tab == ITEM_TAB.F8)
                {
                    if(this.tmp_tankVM != null)
                    {
                        if (this.tmp_tankVM.name.Trim().Length == 0)
                        {
                            return;
                        }

                        try
                        {
                            if(db.tank.Where(t => t.tanksetup_id == this.tmp_tankVM.tanksetup_id && t.name == this.tmp_tankVM.name && t.id != this.tmp_tankVM.id).FirstOrDefault() != null)
                            {
                                XMessageBox.Show("รหัสแท๊งค์ \"" + this.tmp_tankVM.name + "\" นี้มีอยู่แล้ว ควรเปลี่ยนใหม่", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                this.inline_tankname.Focus();
                                return;
                            }

                            var tank_to_update = db.tank.Find(this.tmp_tankVM.id);

                            if(tank_to_update != null)
                            {
                                var old_name = tank_to_update.name;
                                tank_to_update.name = this.tmp_tankVM.name;
                                tank_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                tank_to_update.chgtime = DateTime.Now;

                                db.SaveChanges();
                                this.main_form.islog.EditData(modcod, "แก้ไขรหัสแท๊งค์ \"" + old_name + "\" => \"" + this.tmp_tankVM.name + "\", ในการตั้งค่าแท๊งค์วันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_tankVM.name, "tank", this.tmp_tankVM.id).Save();

                                this.RemoveInlineTankForm();
                                this.form_mode = FORM_MODE.READ_ITEM;
                                this.ResetControlState();
                            }
                            else
                            {
                                XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }

                        return;
                    }
                }
                #endregion add/edit tank

                #region add/edit section
                if (this.form_mode == FORM_MODE.ADD_ITEM && this.item_tab == ITEM_TAB.F7)
                {
                    if(this.tmp_sectionVM != null)
                    {
                        if(this.tmp_sectionVM.name.Trim().Length == 0)
                        {
                            XMessageBox.Show("กรุณาระบุเลขที่ถัง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            this.inlineSectionName.Focus();
                            return;
                        }
                        if(this.tmp_sectionVM.stkcod.Trim().Length == 0)
                        {
                            XMessageBox.Show("กรุณาระบุชนิดน้ำมัน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            this.inlineStkcod.Focus();
                            return;
                        }

                        try
                        {
                            var sect = db.section.Include("tank").Where(s => s.tank.tanksetup_id == this.tanksetup.id && s.name == this.tmp_sectionVM.name).FirstOrDefault();
                            if (sect != null)
                            {
                                XMessageBox.Show("เลขที่ถัง \"" + this.tmp_sectionVM.name + "\" ถูกกำหนดไว้แล้วในแท๊งค์ \"" + sect.tank.name + "\"", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                this.inlineSectionName.Focus();
                                return;
                            }
                            else
                            {
                                this.tmp_sectionVM.section.begdif = this.tmp_sectionVM.begdif;
                                this.tmp_sectionVM.section.cretime = DateTime.Now;
                                db.section.Add(this.tmp_sectionVM.section);
                                db.SaveChanges();
                                this.main_form.islog.AddData(modcod, "เพิ่มเลขที่ถังน้ำมัน \"" + this.tmp_sectionVM.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_sectionVM.name, "section", this.tmp_sectionVM.id).Save();
                                this.RemoveInlineSectionForm();
                                this.form_mode = FORM_MODE.READ_ITEM;
                                this.ResetControlState();
                                this.btnAddSection.PerformClick();
                            }
                        }
                        catch (Exception ex)
                        {
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }
                    }
                    return;
                }
                if(this.form_mode == FORM_MODE.EDIT_ITEM && this.item_tab == ITEM_TAB.F7)
                {
                    if(this.tmp_sectionVM != null)
                    {
                        if (this.tmp_sectionVM.name.Trim().Length == 0)
                        {
                            XMessageBox.Show("กรุณาระบุเลขที่ถัง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            this.inlineSectionName.Focus();
                            return;
                        }
                        if (this.tmp_sectionVM.stkcod.Trim().Length == 0)
                        {
                            XMessageBox.Show("กรุณาระบุชนิดน้ำมัน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            this.inlineStkcod.Focus();
                            return;
                        }

                        try
                        {
                            var sect_to_update = db.section.Find(this.tmp_sectionVM.id);
                            if (sect_to_update != null)
                            {
                                sect_to_update.stkcod = this.tmp_sectionVM.stkcod;
                                sect_to_update.stkdes = this.tmp_sectionVM.stkdes;
                                sect_to_update.capacity = this.tmp_sectionVM.capacity;
                                sect_to_update.begtak = this.tmp_sectionVM.begtak;
                                sect_to_update.begacc = this.tmp_sectionVM.begacc;
                                sect_to_update.begdif = this.tmp_sectionVM.begdif;
                                sect_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                sect_to_update.chgtime = DateTime.Now;

                                db.SaveChanges();
                                this.main_form.islog.AddData(modcod, "แก้ไขรายละเอียดถังน้ำมัน \"" + this.tmp_sectionVM.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_sectionVM.name, "section", this.tmp_sectionVM.id).Save();
                                this.RemoveInlineSectionForm();
                                this.form_mode = FORM_MODE.READ_ITEM;
                                this.ResetControlState();
                            }
                            else
                            {
                                XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        }
                    }
                    return;
                }
                #endregion add/edit section
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tanksetup = db.tanksetup.Include("tank").OrderBy(t => t.startdate).FirstOrDefault();

                this.tanksetup = tanksetup;
                this.FillForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tanksetup tanksetup;
                if(this.tanksetup != null)
                {
                    tanksetup = db.tanksetup.Include("tank").OrderByDescending(t => t.startdate).Where(t => t.startdate.CompareTo(this.tanksetup.startdate) < 0).FirstOrDefault();
                    
                    if(tanksetup != null)
                    {
                        this.tanksetup = tanksetup;
                        this.FillForm();
                    }
                    else
                    {
                        this.btnFirst.PerformClick();
                    }    
                }
                else
                {
                    this.btnFirst.PerformClick();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tanksetup tanksetup;
                if (this.tanksetup != null)
                {
                    tanksetup = db.tanksetup.Include("tank").OrderBy(t => t.startdate).Where(t => t.startdate.CompareTo(this.tanksetup.startdate) > 0).FirstOrDefault();

                    if(tanksetup != null)
                    {
                        this.tanksetup = tanksetup;
                        this.FillForm();
                    }
                    else
                    {
                        this.btnLast.PerformClick();
                    }
                }
                else
                {
                    this.btnLast.PerformClick();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tanksetup = db.tanksetup.Include("tank").OrderByDescending(t => t.startdate).FirstOrDefault();

                this.tanksetup = tanksetup;
                this.FillForm();
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            DialogDateSelector sel = new DialogDateSelector("สำหรับวันที่", DateTime.Now);
            if(sel.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    tanksetup tanksetup = db.tanksetup.Include("tank").OrderByDescending(t => t.startdate).Where(t => t.startdate.CompareTo(sel.selected_date) <= 0).FirstOrDefault();

                    if(tanksetup != null)
                    {
                        this.tanksetup = tanksetup;
                        this.FillForm();
                    }
                    else
                    {
                        XMessageBox.Show("ไม่พบการตั้งค่าแท๊งค์น้ำมันสำหรับวันที่ \"" + sel.selected_date.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + "\"", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn { Name = "col_id", DataPropertyName = "id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "col_startdate", DataPropertyName = "startdate", HeaderText = "วันที่เริ่มใช้", MinimumWidth = 180, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            };
            cols[1].DefaultCellStyle.Format = "dd/MM/yyyy";

            List<dynamic> setup_list;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                setup_list = db.tanksetup.OrderBy(t => t.startdate).Select(t => new { id = t.id, startdate = t.startdate }).ToList<dynamic>();
            }

            DialogInquiry inq = new DialogInquiry(setup_list, cols, cols.Where(c => c.DataPropertyName == "startdate").First(), null, false);
            if(inq.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    int selected_id = (int)inq.selected_row.Cells["col_id"].Value;
                    tanksetup tanksetup = db.tanksetup.Include("tank").Where(t => t.id == selected_id).FirstOrDefault();

                    if(tanksetup != null)
                    {
                        this.tanksetup = tanksetup;
                        this.FillForm();
                    }
                    else
                    {
                        XMessageBox.Show("ข้อมูลที่ท่านเลือกไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn { Name = "col_id", DataPropertyName = "id", HeaderText = "ID", Visible = false },
                new DataGridViewTextBoxColumn { Name = "col_startdate", DataPropertyName = "startdate", HeaderText = "วันที่เริ่มใช้", MinimumWidth = 180, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            };
            cols[1].DefaultCellStyle.Format = "dd/MM/yyyy";

            List<dynamic> setup_list;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                setup_list = db.tanksetup.OrderBy(t => t.startdate).Select(t => new { id = t.id, startdate = t.startdate }).ToList<dynamic>();
            }

            DateTime? current_date = this.tanksetup != null ? (DateTime?)this.tanksetup.startdate : null;
            DialogInquiry inq = new DialogInquiry(setup_list, cols, cols.Where(c => c.DataPropertyName == "startdate").First(), current_date, false);
            if (inq.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    int selected_id = (int)inq.selected_row.Cells["col_id"].Value;
                    tanksetup tanksetup = db.tanksetup.Include("tank").Where(t => t.id == selected_id).FirstOrDefault();

                    if (tanksetup != null)
                    {
                        this.tanksetup = tanksetup;
                        this.FillForm();
                    }
                    else
                    {
                        XMessageBox.Show("ข้อมูลที่ท่านเลือกไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void btnTank_Click(object sender, EventArgs e)
        {
            this.item_tab = ITEM_TAB.F8;
            this.lblTank.BackColor = Color.FromKnownColor(KnownColor.Tan);
            this.lblSection.BackColor = Color.Transparent;
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.ActiveControl = this.dgvTank;
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            this.item_tab = ITEM_TAB.F7;
            this.lblTank.BackColor = Color.Transparent;
            this.lblSection.BackColor = Color.FromKnownColor(KnownColor.Tan);
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.ActiveControl = this.dgvSection;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(this.tanksetup != null)
            {
                this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
            }
            else
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var tanksetup = db.tanksetup.Include("tank").OrderByDescending(t => t.startdate).FirstOrDefault();

                    this.tanksetup = tanksetup;
                }
            }

            this.FillForm();
        }

        private void btnAddTank_Click(object sender, EventArgs e)
        {
            if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                return;

            this.list_tankVM.Add(new tank
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                remark = string.Empty,
                tanksetup_id = this.tanksetup.id,
                creby = this.main_form.loged_in_status.loged_in_user_name,
            }.ToViewModel(this.main_form.working_express_db));

            this.form_mode = FORM_MODE.ADD_ITEM;
            this.ResetControlState();
            this.dgvTank.Enabled = true;
            this.dgvSection.Enabled = false;

            this.dgvTank.Rows[this.list_tankVM.Count - 1].Cells[this.col_tank_name.Name].Selected = true;
            this.ShowInlineTankForm();
        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {
            if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                return;

            if (this.dgvTank.CurrentCell == null)
                return;

            if (this.dgvTank.CurrentCell.RowIndex == -1)
                return;

            this.btnTank.PerformClick();

            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.dgvTank.Enabled = true;
            this.dgvSection.Enabled = false;

            this.ShowInlineTankForm();
        }

        private void btnDeleteTank_Click(object sender, EventArgs e)
        {
            if (this.dgvTank.CurrentCell == null)
                return;

            if (XMessageBox.Show("ลบรหัสแท๊งค์ \"" + (string)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_name.Name].Value + "\" และ ถังน้ำมันในแท๊งค์นี้ทั้งหมด, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                        return;

                    int tank_id = (int)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value;

                    var nozzle_ids = db.nozzle.Include("section").Where(n => n.section.tank_id == tank_id).Select(n => n.id).ToArray<int>();
                    //if(db.saleshistory.Where(s => nozzle_ids.Contains(s.nozzle_id)).Count() > 0)
                    //{
                    //    XMessageBox.Show("รหัสแท๊งค์ \"" + (string)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_name.Name].Value + "\" มีการเดินรายการแล้ว, ไม่สามารถลบได้", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    //    return;
                    //}

                    if(db.tank.Find(tank_id) != null)
                    {
                        foreach (int noz_id in nozzle_ids)
                        {
                            db.nozzle.Remove(db.nozzle.Find(noz_id));
                        }

                        foreach (int sec_id in db.section.Where(s => s.tank_id == tank_id).Select(s => s.id).ToArray<int>())
                        {
                            db.section.Remove(db.section.Find(sec_id));
                        }
                        var tank_to_delete = db.tank.Find(tank_id);
                        db.tank.Remove(tank_to_delete);
                        db.SaveChanges();

                        this.main_form.islog.DeleteData(modcod, "ลบรหัสแท๊งค์ \"" + tank_to_delete.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), tank_to_delete.name, "tank", tank_to_delete.id).Save();
                        this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                        this.FillForm();
                    }
                    else
                    {
                        XMessageBox.Show("ข้อมูลที่ต้องการลบไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                }
            }
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                return;

            this.list_sectionVM.Add(new section
            {
                id = -1,
                name = string.Empty,
                loccod = string.Empty,
                stkcod = string.Empty,
                capacity = 0m,
                begacc = 0m,
                begtak = 0m,
                begdif = 0m,
                tank_id = (int)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value,
                creby = this.main_form.loged_in_status.loged_in_user_name
            }.ToViewModel(this.main_form.working_express_db));

            this.form_mode = FORM_MODE.ADD_ITEM;
            this.ResetControlState();
            this.dgvSection.Enabled = true;
            this.dgvSection.DataSource = this.list_sectionVM;
            this.dgvTank.Enabled = false;

            this.dgvSection.Rows[this.list_sectionVM.Count - 1].Cells[this.col_sect_name.Name].Selected = true;
            this.ShowInlineSectionForm();
        }

        private void btnEditSection_Click(object sender, EventArgs e)
        {
            if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                return;

            this.btnSection.PerformClick();

            if (this.dgvSection.CurrentCell == null)
                return;

            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.dgvSection.Enabled = true;
            this.dgvTank.Enabled = false;

            this.ShowInlineSectionForm();
        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            if(XMessageBox.Show("ลบถังน้ำมันเลขที่ \"" + (string)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells[this.col_sect_name.Name].Value + "\", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                if (this.tanksetup.ToViewModel(this.main_form.working_express_db).IsEditableTankSetup() != true)
                    return;



                try
                {
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        int deleting_id = (int)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells[this.col_sect_id.Name].Value;

                        if(db.nozzle.Where(n => n.section_id == deleting_id).ToList().Count() > 0 ||
                           db.shiftsttak.Where(n => n.section_id == deleting_id).ToList().Count() > 0 ||
                           db.daysttak.Where(n => n.section_id == deleting_id).ToList().Count() > 0)
                        {
                            XMessageBox.Show("ข้อมูลที่ต้องการลบมีการนำไปใช้เดินรายการแล้ว ไม่สามารถลบได้", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            return;
                        }

                        if (db.section.Find(deleting_id) != null)
                        {
                            var section_to_delete = db.section.Find(deleting_id);
                            db.section.Remove(section_to_delete);
                            db.SaveChanges();

                            this.main_form.islog.DeleteData(modcod, "ลบถังน้ำมันเลขที่ \"" + section_to_delete.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), section_to_delete.name, "section", section_to_delete.id).Save();
                            this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                            this.FillForm();
                        }
                        else
                        {
                            XMessageBox.Show("ข้อมูลที่ต้องการลบไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        }
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void dtStartDate__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_tanksetup != null && ((XDatePicker)sender)._SelectedDate.HasValue)
                this.tmp_tanksetup.startdate = ((XDatePicker)sender)._SelectedDate.Value;
        }

        private void inline_tankname__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_tankVM != null)
                this.tmp_tankVM.tank.name = ((XTextEdit)sender)._Text;
        }

        private void dgvTank_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            this.btnEditTank.PerformClick();
        }

        private void dgvSection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if (this.inlineSectionName.Visible)
                {
                    this.inlineSectionName.Focus();
                    return;
                }
                if (this.inlineStkcod.Visible)
                {
                    this.inlineStkcod.Focus();
                    return;
                }
            }
        }

        private void dgvSection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if (this.inlineSectionName.Visible)
                {
                    this.inlineSectionName.Focus();
                    return;
                }
                if (this.inlineStkcod.Visible)
                {
                    this.inlineStkcod.Focus();
                    return;
                }
            }

            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            this.btnEditSection.PerformClick();
        }

        private void dgvTank_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tanksetup == null)
                return;

            if(this.form_mode == FORM_MODE.READ_ITEM)
                this.btnTank.PerformClick();

            if (e.Button == MouseButtons.Right && (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM))
            {
                this.btnTank.PerformClick();

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                {
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_tank_name.Name].Selected = true;
                    this.dgvTank_SelectionChanged(sender, e);
                }

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม");
                mnu_add.Click += delegate
                {
                    this.btnAddTank.PerformClick();
                };
                mnu_add.Enabled = this.btnAddTank.Enabled;
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข");
                mnu_edit.Click += delegate
                {
                    this.btnEditTank.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : this.btnEditTank.Enabled;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ");
                mnu_delete.Click += delegate
                {
                    this.btnDeleteTank.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : this.btnDeleteTank.Enabled;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void dgvSection_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tanksetup == null)
                return;

            if(this.form_mode == FORM_MODE.READ_ITEM)
                this.btnSection.PerformClick();

            if (e.Button == MouseButtons.Right && (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM))
            {
                this.btnSection.PerformClick();

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_sect_name.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม");
                mnu_add.Click += delegate
                {
                    this.btnAddSection.PerformClick();
                };
                mnu_add.Enabled = this.btnAddSection.Enabled;
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข");
                mnu_edit.Click += delegate
                {
                    this.btnEditSection.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : this.btnEditSection.Enabled;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ");
                mnu_delete.Click += delegate
                {
                    this.btnDeleteSection.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : this.btnDeleteSection.Enabled;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void inlineSectionName__Leave(object sender, EventArgs e)
        {
            if (this.tmp_sectionVM == null)
                return;

            if(((XBrowseBox)sender)._Text.Trim().Length == 0)
            {
                this.tmp_sectionVM.section.loccod = string.Empty;
                this.tmp_sectionVM.section.name = string.Empty;
                ((XBrowseBox)sender).Focus();
                SendKeys.Send("{F6}");
                return;
            }
            else
            {
                string main_loc = DbfTable.Isinfo(this.main_form.working_express_db).ToList<IsinfoDbf>().First().mainloc.Trim();
                var locs = DbfTable.Istab(this.main_form.working_express_db).ToIstabList().Where(s => s.tabtyp.Trim() == "21" && s.typcod.Trim() != main_loc).Select(s => new { typdes = s.typdes.TrimEnd(), loccod = s.typcod.TrimEnd() }).ToList();

                var loc_selected = locs.Where(l => l.typdes == ((XBrowseBox)sender)._Text).FirstOrDefault();

                if (loc_selected != null)
                {
                    this.tmp_sectionVM.section.loccod = loc_selected.loccod;
                    this.tmp_sectionVM.section.name = loc_selected.typdes;
                    return;
                }
                else
                {
                    this.tmp_sectionVM.section.loccod = string.Empty;
                    this.tmp_sectionVM.section.name = string.Empty;
                    ((XBrowseBox)sender).Focus();
                    SendKeys.Send("{F6}");
                    return;
                }
            }
        }

        private void inlineStkcod__Leave(object sender, EventArgs e)
        {
            if (this.tmp_sectionVM == null)
                return;

            if(((XBrowseBox)sender)._Text.Trim().Length == 0)
            {
                this.tmp_sectionVM.section.stkcod = string.Empty;
                this.tmp_sectionVM.section.stkdes = string.Empty;
                ((XBrowseBox)sender).Focus();
                SendKeys.Send("{F6}");
                return;
            }
            else
            {
                var stmas = DbfTable.Stmas(this.main_form.working_express_db).ToStmasList()
                            .Where(s => s.stktyp == "0")
                            .Select(s => new { stkcod = s.stkcod.Trim(), stkdes = s.stkdes.Trim() })
                            .OrderBy(s => s.stkcod)
                            .ToList();
                var stmas_selected = stmas.Where(s => s.stkcod == ((XBrowseBox)sender)._Text).FirstOrDefault();

                if(stmas_selected != null)
                {
                    this.tmp_sectionVM.section.stkcod = stmas_selected.stkcod;
                    this.tmp_sectionVM.section.stkdes = stmas_selected.stkdes;
                    return;
                }
                else
                {
                    this.tmp_sectionVM.section.stkcod = string.Empty;
                    this.tmp_sectionVM.section.stkdes = string.Empty;
                    ((XBrowseBox)sender).Focus();
                    SendKeys.Send("{F6}");
                    return;
                }

            }
        }


        private void inlineSectionName__ButtonClick(object sender, EventArgs e)
        {
            string main_loc = DbfTable.Isinfo(this.main_form.working_express_db).ToList<IsinfoDbf>().First().mainloc.Trim();
            var loc = DbfTable.Istab(this.main_form.working_express_db).ToIstabList().Where(s => s.tabtyp.Trim() == "21" && s.typcod.Trim() != main_loc).Select(s => new { typdes = s.typdes.TrimEnd(), loccod = s.typcod.TrimEnd() }).ToList<dynamic>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn { Name = "col_typdes", DataPropertyName = "typdes", HeaderText = "เลขที่ถัง", MinimumWidth = 180, Width = 180, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { Name = "col_loccod", DataPropertyName = "loccod", HeaderText = "รหัสคลัง", MinimumWidth = 100, Width = 100 }
            };

            var init_loc = loc.Where(l => l.typdes == this.tmp_sectionVM.name).Select(s => s.typdes).FirstOrDefault();

            DialogInquiry st = new DialogInquiry(loc, cols, cols[0], init_loc, true);
            Point dest_point = new Point(((XBrowseBox)sender).PointToScreen(Point.Empty).X + ((XBrowseBox)sender).Width, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y);
            st.StartPosition = FormStartPosition.Manual;
            st.Location = dest_point;
            //st.SetBounds(dest_point.X, dest_point.Y, st.Width, st.Height);

            if (st.ShowDialog() == DialogResult.OK)
            {
                if (this.tmp_sectionVM != null)
                {
                    this.tmp_sectionVM.section.name = st.selected_row.Cells[0].Value.ToString();
                    this.tmp_sectionVM.section.loccod = st.selected_row.Cells[1].Value.ToString();
                    this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
                }
                ((XBrowseBox)sender)._Text = st.selected_row.Cells[0].Value.ToString();
            }
        }

        private void inlineStkcod__ButtonClick(object sender, EventArgs e)
        {
            var stmas = DbfTable.Stmas(this.main_form.working_express_db).ToStmasList().Where(s => s.stktyp == "0").Select(s => new { stkcod = s.stkcod.TrimEnd(), stkdes = s.stkdes.TrimEnd()}).ToList<dynamic>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn { Name = "col_stkcod", DataPropertyName = "stkcod", HeaderText = "รหัสสินค้า", MinimumWidth = 180, Width = 180 },
                new DataGridViewTextBoxColumn { Name = "col_stkdes", DataPropertyName = "stkdes", HeaderText = "ชื่อสินค้า/รายละเอียด" , MinimumWidth = 200, Width = 200, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
            };

            var init_st = stmas.Where(s => s.stkcod == this.tmp_sectionVM.stkcod).Select(s => s.stkcod).FirstOrDefault();

            DialogInquiry st = new DialogInquiry(stmas, cols, cols[0], init_st, true);
            Point dest_point = new Point(((XBrowseBox)sender).PointToScreen(Point.Empty).X + ((XBrowseBox)sender).Width, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y);
            st.StartPosition = FormStartPosition.Manual;
            st.Location = dest_point;
            if (st.ShowDialog() == DialogResult.OK)
            {
                if(this.tmp_sectionVM != null)
                {
                    this.tmp_sectionVM.section.stkcod = st.selected_row.Cells["col_stkcod"].Value.ToString();
                    this.tmp_sectionVM.section.stkdes = st.selected_row.Cells["col_stkdes"].Value.ToString();
                    this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
                }
                ((XBrowseBox)sender)._Text = st.selected_row.Cells[0].Value.ToString();
            }
        }

        private void inlineCapacity__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_sectionVM != null)
            {
                this.tmp_sectionVM.section.capacity = ((XNumEdit)sender)._Value;
                this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
            }
        }

        private void inlineBegtak__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_sectionVM != null)
            {
                this.tmp_sectionVM.section.begtak = ((XNumEdit)sender)._Value;
                this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
            }
        }

        private void inlineBegacc__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_sectionVM != null)
            {
                this.tmp_sectionVM.section.begacc = ((XNumEdit)sender)._Value;
                this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
            }
        }

        private void dgvTank_Resize(object sender, EventArgs e)
        {
            if((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) && this.inline_tankname.Visible)
            {
                if (((XDatagrid)sender).CurrentCell == null)
                    return;

                int col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_tank_name.DataPropertyName).First().Index;
                this.inline_tankname.SetInlineControlPosition(((XDatagrid)sender), ((XDatagrid)sender).CurrentCell.RowIndex, col_index);
            }
        }

        private void dgvSection_Resize(object sender, EventArgs e)
        {
            if((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) && this.inlineBegtak.Visible)
            {
                if (((XDatagrid)sender).CurrentCell == null)
                    return;

                int col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_name.DataPropertyName).First().Index;
                this.inlineSectionName.SetInlineControlPosition(((XDatagrid)sender), ((XDatagrid)sender).CurrentCell.RowIndex, col_index);

                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_stkcod.DataPropertyName).First().Index;
                this.inlineStkcod.SetInlineControlPosition(((XDatagrid)sender), ((XDatagrid)sender).CurrentCell.RowIndex, col_index);

                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_capacity.DataPropertyName).First().Index;
                this.inlineCapacity.SetInlineControlPosition(((XDatagrid)sender), ((XDatagrid)sender).CurrentCell.RowIndex, col_index);

                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_begtak.DataPropertyName).First().Index;
                this.inlineBegtak.SetInlineControlPosition(((XDatagrid)sender), ((XDatagrid)sender).CurrentCell.RowIndex, col_index);

                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_begacc.DataPropertyName).First().Index;
                this.inlineBegacc.SetInlineControlPosition(((XDatagrid)sender), ((XDatagrid)sender).CurrentCell.RowIndex, col_index);
            }
        }

        private void dgvTank_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if ((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) &&
                this.tmp_tankVM != null &&
                this.tmp_tankVM.id != (int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value)
            {
                if(this.tmp_tankVM.name.Trim().Length == 0)
                {
                    ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_tank_id.Name].Value == this.tmp_tankVM.id).First().Cells[this.col_tank_name.Name].Selected = true;
                    this.inline_tankname.Focus();
                    return;
                }

                this.btnSave.PerformClick();
            }

            var tank_id = (int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.list_sectionVM = new BindingList<sectionVM>(db.section.Where(s => s.tank_id == tank_id).OrderBy(s => s.name).ToViewModel(this.main_form.working_express_db));
                this.dgvSection.DataSource = this.list_sectionVM;
            }
        }

        private void dgvSection_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if ((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) &&
                this.tmp_sectionVM != null &&
                this.tmp_sectionVM.id != (int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_sect_id.Name].Value)
            {
                ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_sect_id.Name].Value == this.tmp_sectionVM.id).First().Cells[this.col_sect_name.Name].Selected = true;

                this.inlineSectionName.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if ((this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT) && this.dtStartDate._Focused ||
                   ((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) && this.inline_tankname._Focused) ||
                   ((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) && this.inlineBegacc._Focused))
                {
                    this.btnSave.PerformClick();
                    return true;
                }
                else if (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if (keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

            //if (keyData == Keys.F7)
            //{
            //    this.btnSection.PerformClick();
            //    return true;
            //}

            //if (keyData == Keys.F8)
            //{
            //    this.btnTank.PerformClick();
            //    return true;
            //}

            if (keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.A))
            {
                if (this.form_mode == FORM_MODE.READ)
                    this.btnAdd.PerformClick();

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F8)
                    this.btnAddTank.PerformClick();

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F7)
                    this.btnAddSection.PerformClick();

                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                if (this.form_mode == FORM_MODE.READ)
                    this.btnEdit.PerformClick();

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F8)
                    this.btnEditTank.PerformClick();

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F7)
                    this.btnEditSection.PerformClick();

                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                if (this.form_mode == FORM_MODE.READ)
                    this.btnDelete.PerformClick();

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F8)
                    this.btnDeleteTank.PerformClick();

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F7)
                    this.btnDeleteSection.PerformClick();

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

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformButtonClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.Space))
            {
                if(this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F7)
                {
                    if (this.dgvSection.CurrentCell == null)
                        return false;

                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var id = (int)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells[this.col_sect_id.Name].Value;
                        var sect = db.section.Find(id);

                        if(sect != null)
                        {
                            DialogNozzle noz = new DialogNozzle(this.main_form, this, sect);
                            noz.ShowDialog();
                            return true;
                        }
                    }
                }
            }

            if(keyData == Keys.Tab)
            {
                if(this.form_mode == FORM_MODE.READ)
                {
                    if(this.tanksetup != null)
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var tmp = db.tanksetup.Find(this.tanksetup.id);
                            var total_row = db.tanksetup.AsEnumerable().Count();
                            if(tmp != null)
                            {
                                DialogDataInfo info = new DialogDataInfo("Tanksetup", tmp.id, total_row, tmp.creby, tmp.cretime, tmp.chgby, tmp.chgtime);
                                info.ShowDialog();
                                return true;
                            }
                        }
                    }
                }

                if(this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F8)
                {
                    if (this.dgvTank.CurrentCell == null)
                        return false;

                    int tank_id = (int)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var tmp = db.tank.Find(tank_id);
                        var total_rec = db.tank.AsEnumerable().Count();
                        if(tmp != null)
                        {
                            DialogDataInfo info = new DialogDataInfo("Tank", tmp.id, total_rec, tmp.creby, tmp.cretime, tmp.chgby, tmp.chgtime);
                            info.ShowDialog();
                            return true;
                        }
                    }
                }

                if (this.form_mode == FORM_MODE.READ_ITEM && this.item_tab == ITEM_TAB.F7)
                {
                    if (this.dgvSection.CurrentCell == null)
                        return false;

                    int sect_id = (int)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells[this.col_sect_id.Name].Value;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var tmp = db.section.Find(sect_id);
                        var total_rec = db.section.AsEnumerable().Count();
                        if (tmp != null)
                        {
                            DialogDataInfo info = new DialogDataInfo("Section", tmp.id, total_rec, tmp.creby, tmp.cretime, tmp.chgby, tmp.chgtime);
                            info.ShowDialog();
                            return true;
                        }
                    }
                }
            }

            if(keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.3.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvSection_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzlecount.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    e.Handled = true;
                    return;
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzle_btn.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var bg_clr = ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor;
                    using (SolidBrush brush = new SolidBrush(bg_clr))
                    {
                        e.Graphics.FillRectangle(brush, new RectangleF(e.CellBounds.X - 4, e.CellBounds.Y + 2, 8, e.CellBounds.Height - 3));
                    }

                    TextRenderer.DrawText(e.Graphics, "จำนวนหัวจ่าย", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, new Rectangle(e.CellBounds.X - 55, e.CellBounds.Y, e.CellBounds.Width + 15, e.CellBounds.Height), ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor, TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter);

                    e.Handled = true;
                    return;
                }
            }

            if(e.RowIndex > -1)
            {
                if ((this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM) && this.item_tab == ITEM_TAB.F7)
                    return;

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzle_btn.DataPropertyName).First().Index)
                {
                    var img_w = XPump.Properties.Resources.nozzle2_16.Width;
                    var img_h = XPump.Properties.Resources.nozzle2_16.Height;
                    var padding_x = Convert.ToInt32(Math.Floor((decimal)(e.CellBounds.Width - img_w) / 2));
                    var padding_y = Convert.ToInt32(Math.Floor((decimal)(e.CellBounds.Height - img_h) / 2));

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Graphics.DrawImage(new Bitmap(XPump.Properties.Resources.nozzle2_16), new Rectangle(e.CellBounds.X + padding_x, e.CellBounds.Y + padding_y, img_w, img_h));
                    e.Handled = true;
                    return;
                }
            }
        }

        private void dgvSection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzle_btn.DataPropertyName).First().Index)
            {
                DialogNozzle noz = new DialogNozzle(this.main_form, this, (section)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_sect_section.Name].Value);
                noz.ShowDialog();
            }
        }

        private void dgvSection_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if(e.RowIndex > -1 && e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_nozzle_btn.DataPropertyName).First().Index)
            {
                e.ToolTipText = "จัดการหัวจ่ายน้ำมัน <Ctrl + Space>";
            }
            else
            {
                e.ToolTipText = string.Empty;
            }
        }
    }
}
