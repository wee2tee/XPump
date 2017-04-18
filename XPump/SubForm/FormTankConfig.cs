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
        private MainForm main_form;
        private FORM_MODE form_mode;
        private tanksetup tanksetup;
        private List<tankVM> list_tankVM = new List<tankVM>();
        private BindingList<sectionVM> list_sectionVM = new BindingList<sectionVM>();
        private tanksetup tmp_tanksetup;
        private tankVM tmp_tankVM;
        private sectionVM tmp_sectionVM;
        private BindingSource bs_tank;
        //private BindingSource bs_section;
        private tank selected_tank;
        private section selected_section;

        public FormTankConfig(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormTankConfig_Load(object sender, EventArgs e)
        {
            this.bs_tank = new BindingSource();
            this.bs_tank.DataSource = this.list_tankVM;
            this.dgvTank.DataSource = this.bs_tank;

            //this.bs_section = new BindingSource();
            //this.bs_section.DataSource = this.list_sectionVM;
            this.dgvSection.DataSource = this.list_sectionVM;

            this.btnLast.PerformClick();

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        public void ResetControlState()
        {
            /** Toolstrip item **/
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /** Form control **/
            this.btnAddTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnAddSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.dtStartDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dgvTank.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.dgvSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
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
                this.btnRefresh.Enabled = false;
                return;
            }

            this.dtStartDate.SetDate((DateTime?)tanksetup.startdate);

            this.list_tankVM = tanksetup.tank.OrderBy(t => t.name).ToViewModel(this.main_form.working_express_db);
            this.bs_tank.ResetBindings(true);
            this.bs_tank.DataSource = this.list_tankVM;

            if (this.selected_tank != null)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    int tank_id = this.selected_tank.id;
                    
                    this.list_sectionVM = new BindingList<sectionVM>(db.section.Where(s => s.tank_id == tank_id).OrderBy(s => s.name).ToViewModel(this.main_form.working_express_db));
                }
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

            int col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_name.DataPropertyName).First().Index;

            this.inlineSectionName.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineSectionName._Text = this.tmp_sectionVM.name;
            this.inlineSectionName.Visible = true;
            this.inlineSectionName.Focus();

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sect_stkcod.DataPropertyName).First().Index;
            this.inlineStkcod.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inlineStkcod._Text = this.tmp_sectionVM.stkcod;
            this.inlineStkcod.Visible = true;
            
        }

        private void RemoveInlineTankForm()
        {
            if (this.inline_tankname.Visible)
            {
                this.inline_tankname.Visible = false;
                this.tmp_tankVM = null;
            }
        }

        private void RemoveInlineSectionForm()
        {

        }

        private void dgvTank_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvSection_CurrentCellChanged(object sender, EventArgs e)
        {

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
            this.tmp_tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
            this.FillForm();

            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.dtStartDate.txtDate.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.tmp_tanksetup = null;
                return;
            }

            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.RemoveInlineTankForm();
                this.RemoveInlineSectionForm();

                this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                this.FillForm();

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
                        MessageBox.Show("วันที่เริ่มใช้ต้องเป็นวันที่หลังจากรายการขายครั้งสุดท้าย, รายการขายครั้งสุดท้ายวันที่ \"" + last_sale.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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

                            this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tmp_tanksetup.id);
                            this.FillForm();
                            loading.Close();

                            this.form_mode = FORM_MODE.READ_ITEM;
                            this.ResetControlState();
                            this.btnAddTank.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            loading.Close();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                tanksetup_to_update.startdate = this.tmp_tanksetup.startdate;
                                tanksetup_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                tanksetup_to_update.chgtime = DateTime.Now;

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
                                MessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        catch (Exception ex)
                        {
                            loading.Close();
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if(this.form_mode == FORM_MODE.ADD_ITEM && this.inline_tankname.Visible)
                {
                    if(this.tmp_tankVM != null)
                    {
                        try
                        {
                            if (db.tank.Where(t => t.tanksetup_id == this.tmp_tankVM.tanksetup_id && t.name == this.tmp_tankVM.name).FirstOrDefault() != null)
                            {
                                MessageBox.Show("รหัสแท๊งค์ \"" + this.tmp_tankVM.name + "\" นี้มีอยู่แล้ว ควรเปลี่ยนใหม่", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            this.tmp_tankVM.cretime = DateTime.Now;
                            db.tank.Add(new tank
                            {
                                name = this.tmp_tankVM.name,
                                startdate = this.tmp_tankVM.startdate,
                                enddate = this.tmp_tankVM.enddate,
                                description = this.tmp_tankVM.description,
                                remark = this.tmp_tankVM.remark,
                                isactive = this.tmp_tankVM.isactive,
                                creby = this.tmp_tankVM.creby,
                                cretime = this.tmp_tankVM.cretime,
                                tanksetup_id = this.tmp_tankVM.tanksetup_id
                            });
                            db.SaveChanges();

                            this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                            this.FillForm();

                            this.form_mode = FORM_MODE.READ_ITEM;
                            this.ResetControlState();
                            this.btnAddTank.PerformClick();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        return;
                    }
                }

                if(this.form_mode == FORM_MODE.EDIT_ITEM && this.inline_tankname.Visible)
                {
                    if(this.tmp_tankVM != null)
                    {
                        try
                        {
                            if(db.tank.Where(t => t.tanksetup_id == this.tmp_tankVM.tanksetup_id && t.name == this.tmp_tankVM.name && t.id != this.tmp_tankVM.id).FirstOrDefault() != null)
                            {
                                MessageBox.Show("รหัสแท๊งค์ \"" + this.tmp_tankVM.name + "\" นี้มีอยู่แล้ว ควรเปลี่ยนใหม่", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            var tank_to_update = db.tank.Find(this.tmp_tankVM.id);

                            if(tank_to_update != null)
                            {
                                tank_to_update.name = this.tmp_tankVM.name;
                                tank_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                                tank_to_update.chgtime = DateTime.Now;

                                db.SaveChanges();

                                this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                                this.FillForm();
                                this.RemoveInlineTankForm();
                            }
                            else
                            {
                                MessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        return;
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tanksetup = db.tanksetup.Include("tank").OrderByDescending(t => t.startdate).FirstOrDefault();

                if(tanksetup != null)
                {
                    this.tanksetup = tanksetup;
                    this.FillForm();
                }
            }
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

        private void btnTank_Click(object sender, EventArgs e)
        {

        }

        private void btnSection_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTank_Click(object sender, EventArgs e)
        {
            this.list_tankVM.Add(new tank
            {
                name = string.Empty,
                description = string.Empty,
                startdate = this.tanksetup.startdate,
                enddate = null,
                remark = string.Empty,
                isactive = true,
                tanksetup_id = this.tanksetup.id,
                creby = this.main_form.loged_in_status.loged_in_user_name,
            }.ToViewModel(this.main_form.working_express_db));

            this.form_mode = FORM_MODE.ADD_ITEM;
            this.ResetControlState();
            this.dgvTank.Enabled = true;
            this.dgvSection.Enabled = false;

            this.bs_tank.ResetBindings(true);
            this.bs_tank.DataSource = this.list_tankVM;
            this.dgvTank.Rows[this.list_tankVM.Count - 1].Cells[this.col_tank_name.Name].Selected = true;
            this.ShowInlineTankForm();
        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {
            if (this.dgvTank.CurrentCell == null)
                return;

            if (this.dgvTank.CurrentCell.RowIndex == -1)
                return;

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

            if (MessageBox.Show("ลบรหัสแท๊งค์ \"" + (string)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_name.Name].Value + "\"", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    int deleting_id = (int)this.dgvTank.Rows[this.dgvTank.CurrentCell.RowIndex].Cells[this.col_tank_id.Name].Value;

                    db.tank.Remove(db.tank.Find(deleting_id));
                    db.SaveChanges();

                    this.tanksetup = GetTankSetup(this.main_form.working_express_db, this.tanksetup.id);
                    this.FillForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnAddSection_Click(object sender, EventArgs e)
        {
            this.tmp_sectionVM = new section
            {
                name = string.Empty,
                loccod = string.Empty,
                capacity = 0m,
                begacc = 0m,
                begtak = 0m,
                begdif = 0m,
                tank_id = -1,
                stmas_id = -1,
                creby = this.main_form.loged_in_status.loged_in_user_name
            }.ToViewModel(this.main_form.working_express_db);

            this.list_sectionVM.Add(this.tmp_sectionVM);
            //this.list_sectionVM.Add(new section
            //{
            //    name = string.Empty,
            //    loccod = string.Empty,
            //    capacity = 0m,
            //    begacc = 0m,
            //    begtak = 0m,
            //    begdif = 0m,
            //    tank_id = -1,
            //    stmas_id = -1,
            //    creby = this.main_form.loged_in_status.loged_in_user_name
            //}.ToViewModel(this.main_form.working_express_db));

            this.form_mode = FORM_MODE.ADD_ITEM;
            this.ResetControlState();
            this.dgvSection.Enabled = true;
            this.dgvTank.Enabled = false;

            this.dgvSection.Rows[this.list_sectionVM.Count - 1].Cells[this.col_sect_name.Name].Selected = true;
            this.ShowInlineSectionForm();
        }

        private void btnEditSection_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSection_Click(object sender, EventArgs e)
        {

        }

        private void dtStartDate__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_tanksetup != null && ((XDatePicker)sender)._SelectedDate.HasValue)
                this.tmp_tanksetup.startdate = ((XDatePicker)sender)._SelectedDate.Value;
        }

        private void inline_tankname__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_tankVM != null)
                this.tmp_tankVM.name = ((XTextEdit)sender)._Text;
        }

        private void dgvTank_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            this.btnEditTank.PerformClick();
        }

        private void dgvTank_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_tank_name.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม");
                mnu_add.Click += delegate
                {
                    this.btnAddTank.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข");
                mnu_edit.Click += delegate
                {
                    this.btnEditTank.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ");
                mnu_delete.Click += delegate
                {
                    this.btnDeleteTank.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void dgvSection_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_sect_name.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม");
                mnu_add.Click += delegate
                {
                    this.btnAddSection.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข");
                mnu_edit.Click += delegate
                {
                    this.btnEditSection.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ");
                mnu_delete.Click += delegate
                {
                    this.btnDeleteSection.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void inlineSectionName__ButtonClick(object sender, EventArgs e)
        {
            DialogLoccodSelection loc = new DialogLoccodSelection(this.main_form);
            if(loc.ShowDialog() == DialogResult.OK)
            {
                if (this.tmp_sectionVM != null)
                {
                    this.tmp_sectionVM.name = loc.selected_stloc.typdes.Trim();
                    this.list_sectionVM.ResetItem(this.dgvSection.CurrentCell.RowIndex);
                }

                ((XBrowseBox)sender)._Text = loc.selected_stloc.typdes.Trim();
            }
        }

        private void inlineStkcod__ButtonClick(object sender, EventArgs e)
        {
            var stmas = DbfTable.Stmas(this.main_form.working_express_db).ToStmasList().Where(s => s.stktyp == "0").Select(s => new { stkcod = s.stkcod.Trim(), stkdes = s.stkdes.Trim()}).ToList<dynamic>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn { Name = "รหัสสินค้า", DataPropertyName = "stkcod", HeaderText = "col_stkcod", MinimumWidth = 180, Width = 180 },
                new DataGridViewTextBoxColumn { Name = "ชื่อสินค้า/รายละเอียด", DataPropertyName = "stkdes", HeaderText = "col_stkdes" , MinimumWidth = 80, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
            };

            DialogInquiry st = new DialogInquiry(stmas, cols, cols[0]);
            if(st.ShowDialog() == DialogResult.OK)
            {
                if(this.tmp_sectionVM != null)
                {
                    MessageBox.Show(st.selected_row.Cells[0].Value.ToString());
                }
            }
            
            //DialogInquiryStmas s = new DialogInquiryStmas(this.main_form, null);
            //if(s.ShowDialog() == DialogResult.OK)
            //{

            //}
        }
    }
}
