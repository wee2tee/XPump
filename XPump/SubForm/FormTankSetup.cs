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

namespace XPump.SubForm
{
    public partial class FormTankSetup : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private tank curr_tank;
        private tank temp_tank;
        private sectionVM temp_section;
        //private List<StlocDbfVM> stloc_list;
        private BindingSource bs_section;

        public FormTankSetup()
        {
            InitializeComponent();
        }

        public FormTankSetup(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void FormTank_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            //this.stloc_list = DbfTable.Stloc().ToStlocList().ToViewModel();

            this.col_section_begacc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.ddIsactive._Items.Add(new XDropdownListItem { Text = "ใช้งาน", Value = true });
            this.ddIsactive._Items.Add(new XDropdownListItem { Text = "ไม่ใช้งาน", Value = false });

            this.bs_section = new BindingSource();
            this.dgvSection.DataSource = this.bs_section;

            this.BindingCustomControlEventHandler();

            this.btnLast.PerformClick();
        }

        private void BindingCustomControlEventHandler()
        {
            this.txtName.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.name = ((TextBox)sender).Text;
            };

            this.dtStartDate._SelectedDateChanged += delegate(object sender, EventArgs e)
            {
                if (!((XDatePicker)sender)._SelectedDate.HasValue)
                    ((XDatePicker)sender)._SelectedDate = DateTime.Now;

                if (this.temp_tank != null)
                    this.temp_tank.startdate = ((XDatePicker)sender)._SelectedDate.Value;
            };

            this.dtEndDate._SelectedDateChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.enddate = ((XDatePicker)sender)._SelectedDate;
            };

            this.txtDesc.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.description = ((TextBox)sender).Text;
            };

            this.txtRemark.textBox1.TextChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.remark = ((TextBox)sender).Text;
            };

            this.ddIsactive._SelectedItemChanged += delegate (object sender, EventArgs e)
            {
                if (this.temp_tank != null)
                    this.temp_tank.isactive = (bool)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            };
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
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
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.txtName.SetControlState(new FORM_MODE[] { FORM_MODE.ADD }, this.form_mode);
            this.dtStartDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtEndDate.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtDesc.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.txtRemark.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.ddIsactive.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnAddItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSaveItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnStopItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.dgvSection.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.inline_nozzlecount.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);

        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if(this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
        //    {
        //        if(MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }

        //    this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
        //    base.OnFormClosing(e);
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        public tank GetTank(int tank_id)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    return db.tank.Include("section").Where(t => t.id == tank_id).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private tank GetFirstTank()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tank tank = db.tank.Include("section").OrderBy(t => t.name).FirstOrDefault();

                if (tank != null)
                {
                    return tank;
                }
                else
                {
                    return null;
                }
            }
        }

        private tank GetPreviousTank()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tank tank = db.tank.Include("section").Where(t => t.name.CompareTo(this.curr_tank.name) < 0).OrderByDescending(t => t.name).FirstOrDefault();

                if (tank != null)
                {
                    return tank;
                }
                else
                {
                    return null;
                }
            }
        }

        private tank GetNextTank()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tank tank = db.tank.Include("section").Where(t => t.name.CompareTo(this.curr_tank.name) > 0).OrderBy(t => t.name).FirstOrDefault();

                if (tank != null)
                {
                    return tank;
                }
                else
                {
                    return null;
                }
            }
        }

        private tank GetLastTank()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tank tmp = db.tank.Include("section").OrderByDescending(t => t.name).FirstOrDefault();

                if (tmp != null)
                {
                    return tmp;
                }
                else
                {
                    return null;
                }
            }
        }

        private void FillForm(tank tank_to_fill = null)
        {
            tank tank = tank_to_fill != null ? tank_to_fill : this.curr_tank;

            if (tank == null)
                return;

            this.txtName._Text = tank.name;
            this.dtStartDate._SelectedDate = tank.startdate;
            this.dtEndDate._SelectedDate = tank.enddate;
            this.txtDesc._Text = tank.description;
            this.txtRemark._Text = tank.remark;
            this.ddIsactive._SelectedItem = this.ddIsactive._Items.Cast<XDropdownListItem>().Where(i => (bool)i.Value == tank.isactive).First();

            this.bs_section.ResetBindings(true);
            var sections = tank.section.ToList().ToViewModel(this.main_form.working_express_db).OrderBy(s => s.state).ThenBy(s => s.id).ToList();

            this.bs_section.DataSource = sections;
            this.dgvSection.Focus();

            if(this.form_mode == FORM_MODE.READ)
            {
                this.btnEdit.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnDelete.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnFirst.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnPrevious.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnNext.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnLast.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnSearch.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnInquiryAll.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnInquiryRest.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnItem.Enabled = tank == null || tank.id == -1 ? false : true;
                this.btnRefresh.Enabled = tank == null || tank.id == -1 ? false : true;
            }
        }

        private void ShowInlineForm(int row_index)
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            int col_index;

            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_stkcod.DataPropertyName).First().Index;
                this.inline_stkcod.SetInlineControlPosition(this.dgvSection, row_index, col_index);
                this.inline_stkcod._Text = this.temp_section.stkcod;
                this.inline_stkcod.Visible = true;
            }

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_name.DataPropertyName).First().Index;
            this.inline_name.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inline_name._Text = this.temp_section.name;
            this.inline_name.Visible = true;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_capacity.DataPropertyName).First().Index;
            this.inline_capacity.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inline_capacity._Value = this.temp_section.capacity;
            this.inline_capacity.Visible = true;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begtak.DataPropertyName).First().Index;
            this.inline_begtak.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inline_begtak._Value = this.temp_section.begtak;
            this.inline_begtak.Visible = true;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begacc.DataPropertyName).First().Index;
            this.inline_begacc.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.inline_begacc._Value = this.temp_section.begacc;
            this.inline_begacc.Visible = true;
        }

        private void RemoveInlineForm()
        {
            this.inline_name.Visible = false;
            this.inline_stkcod.Visible = false;
            this.inline_capacity.Visible = false;
            this.inline_begacc.Visible = false;
            this.inline_begtak.Visible = false;
            this.temp_section = null;
        }

        private void PerformEdit(object sender, EventArgs e)
        {
            this.toolStrip1.Focus();
            this.btnEdit.PerformClick();
            if(sender == this.txtName)
            {
                this.txtDesc.Focus();
                return;
            }

            ((Control)sender).Focus();
        }

        private void dgvSection_Resize(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            int row_index = ((XDatagrid)sender).CurrentCell.RowIndex;
            int col_index;

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_name.DataPropertyName).First().Index;
            this.inline_name.SetInlineControlPosition(this.dgvSection, row_index, col_index);

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_stkcod.DataPropertyName).First().Index;
            this.inline_stkcod.SetInlineControlPosition(this.dgvSection, row_index, col_index);

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_capacity.DataPropertyName).First().Index;
            this.inline_capacity.SetInlineControlPosition(this.dgvSection, row_index, col_index);

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begtak.DataPropertyName).First().Index;
            this.inline_begtak.SetInlineControlPosition(this.dgvSection, row_index, col_index);

            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begacc.DataPropertyName).First().Index;
            this.inline_begacc.SetInlineControlPosition(this.dgvSection, row_index, col_index);

            if (this.inline_nozzlecount.Visible)
            {
                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().Index;
                Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(col_index, ((XDatagrid)sender).CurrentCell.RowIndex, true);
                this.inline_nozzlecount.SetBounds(rect.X, rect.Y + 1, 25, rect.Height - 3);
            }
        }

        public bool DeleteNozzle(nozzle nozzle_to_delete)
        {
            if (nozzle_to_delete == null)
                return false;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    db.nozzle.Remove(db.nozzle.Find(nozzle_to_delete.id));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("รหัสหัวจ่าย", nozzle_to_delete.name);
                    return false;
                }
            }
        }

        public bool DeleteSection(section section_to_delete)
        {
            if (section_to_delete == null)
                return false;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                foreach (nozzle noz in db.nozzle.Where(n => n.section_id == section_to_delete.id).ToList())
                {
                    if (!DeleteNozzle(noz))
                    {
                        return false;
                    }
                }
            }

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    db.section.Remove(db.section.Find(section_to_delete.id));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("รหัสช่องเก็บน้ำมัน", section_to_delete.name);
                    return false;
                }
            }
        }

        public bool DeleteTank(tank tank_to_delete)
        {
            if (tank_to_delete == null)
                return false;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                foreach (section sec in db.section.Where(s => s.tank_id == tank_to_delete.id).ToList())
                {
                    if (!DeleteSection(sec))
                    {
                        return false;
                    }
                }
            }

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    db.tank.Remove(db.tank.Find(tank_to_delete.id));
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.ShowMessage("รหัสแท๊งค์", tank_to_delete.name);
                    return false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_tank = new tank
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                startdate = DateTime.Now,
                enddate = null,
                remark = string.Empty,
                isactive = true
            };

            this.toolStrip1.Focus();
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.txtName.Focus();

            this.FillForm(this.temp_tank);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_tank == null || this.curr_tank.id == -1)
                return;

            this.inline_nozzlecount.Enabled = false;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                tank tmp = this.GetTank(this.curr_tank.id);
                
                if(tmp == null)
                {
                    MessageBox.Show("ค้นหารหัสแท๊งค์ \"" + this.curr_tank.name + "\" ไม่พบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.btnRefresh.PerformClick();
                    return;
                }

                this.temp_tank = tmp;
                this.form_mode = FORM_MODE.EDIT;
                this.ResetControlState();
                this.FillForm(this.temp_tank);
                this.txtDesc.Focus();
                this.txtName.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.curr_tank == null || this.curr_tank.id == -1)
                return;

            if (MessageBox.Show("ลบรหัสแท๊งค์ \"" + this.curr_tank.name + "\" และช่องเก็บฯ/หัวจ่ายฯ ที่เกี่ยวข้อง, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            DeleteTank(this.curr_tank);
            this.btnRefresh.PerformClick();

            //using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            //{
            //    try
            //    {
            //        db.tank.Remove(db.tank.Find(this.curr_tank.id));
            //        db.SaveChanges();
            //        this.btnRefresh.PerformClick();
            //    }
            //    catch (Exception ex)
            //    {
            //        ex.ShowMessage("รหัส", this.curr_tank.name);
            //        this.btnRefresh.PerformClick();
            //    }
            //}
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.btnStopItem.PerformClick();
                return;
            }

            if(this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.toolStrip1.Focus();
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.btnRefresh.PerformClick();

                return;
            }

            if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
            {
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.temp_tank = null;
                this.FillForm();
                this.txtName.Enabled = true;
                this.inline_nozzlecount.Enabled = true;
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                if(this.temp_tank != null && this.temp_tank.name.Trim().Length == 0)
                {
                    this.txtName.Focus();
                    return;
                }

                using(xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        this.temp_tank.creby = this.main_form.loged_in_status.loged_in_user_name;
                        this.temp_tank.cretime = DateTime.Now;
                        db.tank.Add(this.temp_tank);
                        db.SaveChanges();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.curr_tank = this.GetTank(this.temp_tank.id);
                        this.FillForm();
                        this.temp_tank = null;
                        //this.dgvSection.Focus();
                        this.btnItem.PerformClick();
                        this.btnAddItem.PerformClick();
                    }
                    catch(Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_tank.name);
                    }
                }
                return;
            }

            if(this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        tank tank_to_update = db.tank.Find(this.temp_tank.id);
                        if(tank_to_update == null)
                        {
                            MessageBox.Show("ค้นหารหัส \"" + this.temp_tank.name + "\" เพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        tank_to_update.name = this.temp_tank.name;
                        tank_to_update.description = this.temp_tank.description;
                        tank_to_update.startdate = this.temp_tank.startdate;
                        tank_to_update.enddate = this.temp_tank.enddate;
                        tank_to_update.remark = this.temp_tank.remark;
                        tank_to_update.isactive = this.temp_tank.isactive;
                        tank_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        tank_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                        this.temp_tank = null;
                        this.txtName.Enabled = true;
                        this.inline_nozzlecount.Enabled = true;
                        this.dgvSection.Focus();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_tank.name);
                    }
                }
                return;
            }

            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.btnSaveItem.PerformClick();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            tank tmp = this.GetFirstTank();
            if(tmp != null)
            {
                this.curr_tank = tmp;
            }
            else
            {
                this.curr_tank = new tank
                {
                    id = -1,
                    name = string.Empty,
                    description = string.Empty,
                    remark = string.Empty,
                    isactive = false
                };
            }

            this.FillForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tank tmp = this.GetPreviousTank();
            if(tmp != null)
            {
                this.curr_tank = tmp;
                this.FillForm();
            }
            else
            {
                this.btnFirst.PerformClick();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tank tmp = this.GetNextTank();
            if(tmp != null)
            {
                this.curr_tank = tmp;
                this.FillForm();
            }
            else
            {
                this.btnLast.PerformClick();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tank tmp = this.GetLastTank();
            if(tmp != null)
            {
                this.curr_tank = tmp;
            }
            else
            {
                this.curr_tank = new tank
                {
                    id = -1,
                    name = string.Empty,
                    description = string.Empty,
                    startdate = DateTime.Now,
                    enddate = null,
                    remark = string.Empty,
                    isactive = false
                };
            }

            this.FillForm();
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            DialogSimpleSearch dlg = new DialogSimpleSearch("รหัสแท๊งค์", "");
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    tank tmp = db.tank.Where(t => t.name.CompareTo(dlg.keyword) > -1).OrderBy(t => t.name).FirstOrDefault();

                    if(tmp != null)
                    {
                        if(tmp.name != dlg.keyword)
                        {
                            if (MessageBox.Show("ค้นหาข้อมูลไม่พบ, ต้องการข้อมูลถัดไปหรือไม่", "", MessageBoxButtons.OKCancel, MessageBoxIcon.None) != DialogResult.OK)
                                return;
                        }

                        this.curr_tank = tmp;
                        this.FillForm();
                    }
                    else
                    {
                        MessageBox.Show("ค้นหาข้อมูลไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private List<DataGridViewColumn> GetInquiryDgvColumns()
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            DataGridViewColumn col_id = new DataGridViewTextBoxColumn();
            col_id.Name = "col_id";
            col_id.HeaderText = "ID";
            col_id.DataPropertyName = "id";
            col_id.Visible = false;
            cols.Add(col_id);

            DataGridViewColumn col_name = new DataGridViewTextBoxColumn();
            col_name.HeaderText = "รหัสแท๊งค์";
            col_name.Name = "col_name";
            col_name.DataPropertyName = "name";
            col_name.MinimumWidth = 140;
            col_name.Width = 140;
            cols.Add(col_name);

            DataGridViewColumn col_desc = new DataGridViewTextBoxColumn();
            col_desc.HeaderText = "รายละเอียด";
            col_desc.DataPropertyName = "description";
            col_desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_desc.FillWeight = 100;
            col_desc.MinimumWidth = 80;
            cols.Add(col_desc);

            DataGridViewColumn col_start = new DataGridViewTextBoxColumn();
            col_start.HeaderText = "เริ่มใช้วันที่";
            col_start.DataPropertyName = "startdate";
            col_start.DefaultCellStyle.Format = "dd/MM/yyyy";
            col_start.MinimumWidth = 80;
            col_start.Width = 80;
            cols.Add(col_start);

            DataGridViewColumn col_end = new DataGridViewTextBoxColumn();
            col_end.HeaderText = "ถึงวันที่";
            col_end.DataPropertyName = "enddate";
            col_end.DefaultCellStyle.Format = "dd/MM/yyyy";
            col_end.MinimumWidth = 80;
            col_end.Width = 80;
            cols.Add(col_end);

            DataGridViewColumn col_remark = new DataGridViewTextBoxColumn();
            col_remark.HeaderText = "หมายเหตุ";
            col_remark.DataPropertyName = "remark";
            //col_remark.Visible = false;
            col_remark.MinimumWidth = 80;
            col_remark.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_remark.FillWeight = 60;
            cols.Add(col_remark);

            DataGridViewColumn col_isactive = new DataGridViewCheckBoxColumn();
            col_isactive.HeaderText = "isactive";
            col_isactive.DataPropertyName = "isactive";
            col_isactive.Visible = false;
            cols.Add(col_isactive);

            DataGridViewColumn col_tank = new DataGridViewTextBoxColumn();
            col_tank.HeaderText = "Tank";
            col_tank.DataPropertyName = "tank";
            col_tank.Visible = false;
            cols.Add(col_tank);

            DataGridViewColumn col__isactive = new DataGridViewTextBoxColumn();
            col__isactive.HeaderText = "สถานะ";
            col__isactive.DataPropertyName = "_isactive";
            col__isactive.MinimumWidth = 60;
            col__isactive.Width = 60;
            col__isactive.Visible = false;
            cols.Add(col__isactive);

            DataGridViewColumn col_working_express_db = new DataGridViewTextBoxColumn();
            col_working_express_db.DataPropertyName = "working_express_db";
            col_working_express_db.Visible = false;
            cols.Add(col_working_express_db);

            return cols;
        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            var cols = this.GetInquiryDgvColumns();

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tanks = db.tank.ToViewModel(this.main_form.working_express_db).ToList<dynamic>();
                var col_search_key = cols.Where(c => c.Name == "col_name").FirstOrDefault();
                DialogInquiry inq = new DialogInquiry(tanks, cols, col_search_key);

                if(inq.ShowDialog() == DialogResult.OK)
                {
                    var id = (int)inq.selected_row.Cells["col_id"].Value;
                    this.curr_tank = this.GetTank(id);
                    this.FillForm();
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            var cols = this.GetInquiryDgvColumns();

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tanks = db.tank.ToViewModel(this.main_form.working_express_db).ToList<dynamic>();
                var col_search_key = cols.Where(c => c.Name == "col_name").FirstOrDefault();
                DialogInquiry inq = new DialogInquiry(tanks, cols, col_search_key, this.curr_tank.name);

                if (inq.ShowDialog() == DialogResult.OK)
                {
                    var id = (int)inq.selected_row.Cells["col_id"].Value;
                    this.curr_tank = this.GetTank(id);
                    this.FillForm();
                }
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.dgvSection.Focus();
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.curr_tank == null)
                return;

            tank tmp = this.GetTank(this.curr_tank.id);

            if(tmp != null)
            {
                this.curr_tank = tmp;
                this.FillForm();
            }
            else
            {
                this.btnNext.PerformClick();
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //this.temp_section = new section
            //{
            //    id = -1,
            //    name = string.Empty,
            //    loccod = string.Empty,
            //    begacc = 0m,
            //    begtak = 0m,
            //    begdif = 0m,
            //    stmas_id = -1,
            //    tank_id = this.curr_tank.id,
            //}.ToViewModel(this.main_form.working_express_db);
            //this.curr_tank.section.Add(this.temp_section.section);
            //this.FillForm();
            //this.dgvSection.Rows[this.curr_tank.section.Count - 1].Cells["col_section_name"].Selected = true;
            //this.form_mode = FORM_MODE.ADD_ITEM;
            //this.ResetControlState();
            //this.ShowInlineForm(this.curr_tank.section.Count - 1);
            //this.inline_stkcod.Focus();

            DialogLoccodSelection loc = new DialogLoccodSelection(this.main_form);
            if(loc.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            this.temp_section = ((section)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells["col_section_section"].Value).ToViewModel(this.main_form.working_express_db);
            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.ShowInlineForm(this.dgvSection.CurrentCell.RowIndex);
            this.inline_stkcod.Focus();
        }

        //private void btnDeleteItem_Click(object sender, EventArgs e)
        //{
        //    if (this.dgvSection.CurrentCell == null)
        //        return;

        //    section tmp = (section)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells["col_section_section"].Value;

        //    if (MessageBox.Show("ลบรหัสช่องเก็บน้ำมัน \"" + tmp.name + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
        //        return;

        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {
        //        try
        //        {
        //            db.section.Remove(db.section.Find(tmp.id));
        //            db.SaveChanges();
        //            this.curr_tank = this.GetTank(this.curr_tank.id);
        //            this.FillForm();

        //        }
        //        catch (Exception ex)
        //        {
        //            ex.ShowMessage("รหัส", tmp.name, "รหัสแท๊งค์", this.curr_tank.name);
        //        }
        //    }
        //}

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            section section_to_delete = (section)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells["col_section_section"].Value;

            if (MessageBox.Show("ลบรหัสช่องเก็บน้ำมัน \"" + section_to_delete.name + "\" และหัวจ่ายฯ ที่เกี่ยวข้อง, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            DeleteSection(section_to_delete);
            this.curr_tank = this.GetTank(this.curr_tank.id);
            this.FillForm();

            //using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            //{
            //    try
            //    {
            //        db.section.Remove(db.section.Find(tmp.id));
            //        db.SaveChanges();
            //        this.curr_tank = this.GetTank(this.curr_tank.id);
            //        this.FillForm();

            //    }
            //    catch (Exception ex)
            //    {
            //        ex.ShowMessage("รหัส", tmp.name, "รหัสแท๊งค์", this.curr_tank.name);
            //    }
            //}
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            if (this.temp_section == null)
                return;

            if(this.temp_section.section.name.Trim().Length == 0 && this.inline_name.Visible)
            {
                this.inline_name.Focus();
                return;
            }

            if(this.temp_section.section.stmas_id == -1 && this.inline_stkcod.Visible)
            {
                this.inline_stkcod.Focus();
                return;
            }

            this.temp_section.section.begdif = this.temp_section.section.begtak - this.temp_section.section.begacc;

            if (this.form_mode == FORM_MODE.ADD_ITEM)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        db.section.Add(this.temp_section.section);
                        db.SaveChanges();
                        this.curr_tank = this.GetTank(this.curr_tank.id);
                        this.FillForm();
                        this.btnStopItem.PerformClick();
                        this.btnAddItem.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_section.name, "รหัสแท๊งค์", this.curr_tank.name);
                    }
                }

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        section section_to_update = db.section.Find(this.temp_section.id);

                        if (section_to_update == null)
                        {
                            MessageBox.Show("ค้นหารหัส \"" + this.temp_section.name + "\" เพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //this.inline_capacity.Focus();
                            return;
                        }

                        section_to_update.name = this.temp_section.section.name;
                        section_to_update.stmas_id = this.temp_section.section.stmas_id;
                        section_to_update.begtak = this.temp_section.section.begtak;
                        section_to_update.begacc = this.temp_section.section.begacc;
                        section_to_update.begdif = this.temp_section.section.begdif;
                        //section_to_update.tank_id = this.temp_section.section.tank_id;
                        //section_to_update.begbal = this.temp_section.section.begbal;

                        db.SaveChanges();
                        this.curr_tank = this.GetTank(this.curr_tank.id);
                        this.FillForm();
                        this.btnStopItem.PerformClick();
                        this.dgvSection.Focus();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_section.name, "รหัสแท๊งค์", this.curr_tank.name);
                    }
                }

                return;
            }
        }

        private void btnStopItem_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.RemoveInlineForm();
            this.temp_section = null;

            tank tmp = this.GetTank(this.curr_tank.id);
            if (tmp != null)
            {
                this.curr_tank = tmp;
                this.FillForm();
                this.dgvSection.Focus();
                return;
            }

            tmp = this.GetNextTank();
            if (tmp != null)
            {
                this.curr_tank = tmp;
                this.FillForm();
                this.dgvSection.Focus();
                return;
            }

            tmp = this.GetLastTank();
            if(tmp != null)
            {
                this.curr_tank = tmp;
                this.FillForm();
                this.dgvSection.Focus();
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM))
            {
                if (this.txtRemark._Focused)
                {
                    this.btnSave.PerformClick();
                    return true;
                }

                if (this.inline_begacc.Visible && this.inline_begacc._Focused)
                {
                    this.btnSaveItem.PerformClick();
                    return true;
                }

                SendKeys.Send("{TAB}");
                return true;
            }

            if (keyData == Keys.Enter && (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM) && this.dgvSection.Focused)
            {
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                this.btnStopItem.PerformClick();

                this.dgvSection.Focus();

                return true;
            }

            if (keyData == Keys.F8)
            {
                this.btnItem.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.A))
            {
                this.btnAddItem.PerformClick();
                this.btnAdd.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                this.btnEditItem.PerformClick();
                this.btnEdit.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                if(this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.btnDeleteItem.PerformClick();
                    return true;
                }
                if(this.form_mode == FORM_MODE.READ)
                {
                    this.btnDelete.PerformClick();
                    return true;
                }
            }

            if (keyData == Keys.PageUp)
            {
                this.btnPrevious.PerformClick();
                return true;
            }

            if (keyData == Keys.PageDown)
            {
                this.btnNext.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformButtonClick();
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

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == (Keys.Shift | Keys.F4))
            {
                this.Close();
                return true;
            }

            if(keyData == (Keys.Control | Keys.Space) && (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM) && this.inline_nozzlecount.Visible)
            {
                this.inline_nozzlecount.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvSection_SelectionChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).Rows.Count == 0)
            {
                this.inline_nozzlecount.Visible = false;
                return;
            }

            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if ((int)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells["col_section_id"].Value == -1)
            {
                this.inline_nozzlecount.Visible = false;
                return;
            }

            if (this.inline_nozzlecount != null)
            {
                int col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().Index;
                Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(col_index, ((XDatagrid)sender).CurrentCell.RowIndex, true);
                this.inline_nozzlecount.SetBounds(rect.X, rect.Y + 1, 25, rect.Height - 3);
                this.inline_nozzlecount.Visible = true;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                if(this.temp_tank.name.Trim().Length == 0)
                {
                    ((XTextEdit)sender).Focus();
                }
            }
        }

        public void RefreshDgvSection()
        {
            this.dgvSection.Refresh();
        }

        private void dgvSection_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.btnItem.PerformClick();
                this.btnEditItem.PerformClick();

                if(((XDatagrid)sender).Columns[e.ColumnIndex].DataPropertyName == this.col_section_begacc.DataPropertyName)
                {
                    this.inline_stkcod.Focus();
                    return;
                }
            }
        }

        private void dgvSection_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begacc.DataPropertyName).First().HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begacc.DataPropertyName).First().HeaderCell.Style.Padding = new Padding(0, 0, 3, 0);
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_totbal.DataPropertyName).First().HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_totbal.DataPropertyName).First().HeaderCell.Style.Padding = new Padding(0, 0, 3, 0);
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().HeaderCell.Style.Padding = new Padding(0, 0, 3, 0);
        }

        private void dgvSection_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

            if (e.Button == MouseButtons.Right)
            {
                this.btnItem.PerformClick();

                if(row_index > -1)
                {
                    ((XDatagrid)sender).Rows[row_index].Cells["col_section_name"].Selected = true;
                    this.dgvSection_SelectionChanged(sender, new EventArgs());
                }

                ContextMenu cm = new ContextMenu();

                MenuItem mnu_add = new MenuItem();
                mnu_add.Text = "เพิ่ม <Alt+A>";
                mnu_add.Click += delegate
                {
                    this.btnAddItem.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem();
                mnu_edit.Text = "แก้ไข <Alt+E>";
                mnu_edit.Enabled = row_index == -1 ? false : true;
                mnu_edit.Click += delegate
                {
                    this.btnEditItem.PerformClick();
                };
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem();
                mnu_delete.Text = "ลบ <Alt+D>";
                mnu_delete.Enabled = row_index == -1 ? false : true;
                mnu_delete.Click += delegate
                {
                    this.btnDeleteItem.PerformClick();
                };
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void inline_nozzlecount_Click(object sender, EventArgs e)
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            section section = (section)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells["col_section_section"].Value;
            DialogNozzle noz = new DialogNozzle(this.main_form, this, section);
            if (noz.ShowDialog() == DialogResult.OK)
            {
                this.dgvSection.Refresh();
            }
        }

        private void inline_stkcod__ButtonClick(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                DialogInquiryStmas dlg = new DialogInquiryStmas(this.main_form, db.stmas.Where(s => s.name.Trim() == ((XBrowseBox)sender)._Text).FirstOrDefault());
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    ((XBrowseBox)sender)._Text = db.stmas.Find(dlg.selected_id).name;
                    this.temp_section.section.stmas_id = dlg.selected_id;
                    this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells[this.col_section_stkdes.Name].Value = db.stmas.Find(dlg.selected_id).name;
                }
            }
        }

        private void inline_stkcod__Leave(object sender, EventArgs e)
        {
            string txt = ((XBrowseBox)sender)._Text;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                stmas tmp = db.stmas.Where(s => s.name.Trim() == txt.Trim()).FirstOrDefault();

                if (txt.Trim().Length > 0 && tmp != null)
                {
                    ((XBrowseBox)sender)._Text = tmp.name;
                    this.temp_section.section.stmas_id = tmp.id;
                    this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells[this.col_section_stkdes.Name].Value = tmp.name;
                }
                else
                {
                    ((XBrowseBox)sender).Focus();
                    SendKeys.Send("{F6}");
                }
            }
        }

        private void inline_name__ButtonClick(object sender, EventArgs e)
        {

        }

        private void inline_name__Leave(object sender, EventArgs e)
        {

        }

        private void inline_name__TextChanged(object sender, EventArgs e)
        {
            //this.temp_section.section.name = ((XTextEdit)sender)._Text;
        }

        private void inline_begtak__ValueChanged(object sender, EventArgs e)
        {
            this.temp_section.section.begtak = ((XNumEdit)sender)._Value;
        }

        private void inline_begacc__ValueChanged(object sender, EventArgs e)
        {
            this.temp_section.section.begacc = ((XNumEdit)sender)._Value;
        }
        
    }
}
