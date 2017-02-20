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

        private XTextEdit inline_name;
        private XBrowseBox inline_stkcod;
        private XTextEdit inline_stkdes;
        private XDropdownList inline_loccod;
        private XNumEdit inline_capacity;
        //private XBrowseBox inline_nozzle;
        private Button inline_nozzlecount;


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
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            //this.stloc_list = DbfTable.Stloc().ToStlocList().ToViewModel();

            this.col_section_begbal.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.ddIsactive._Items.Add(new XDropdownListItem { Text = "ใช้งาน", Value = true });
            this.ddIsactive._Items.Add(new XDropdownListItem { Text = "ไม่ใช้งาน", Value = false });

            this.bs_section = new BindingSource();
            this.dgvSection.DataSource = this.bs_section;

            this.BindingCustomControlEventHandler();

            this.btnLast.PerformClick();

            this.inline_nozzlecount = new Button();
            this.inline_nozzlecount.Text = "";
            this.inline_nozzlecount.Image = XPump.Properties.Resources.nozzle2_16;
            this.inline_nozzlecount.ImageAlign = ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(this.inline_nozzlecount, "แก้ไขจำนวนหัวจ่ายน้ำมัน <Ctrl + Space>");
            this.inline_nozzlecount.Visible = false;
            this.inline_nozzlecount.Click += delegate
            {
                if (this.dgvSection.CurrentCell == null)
                    return;

                section section = (section)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells["col_section_section"].Value;
                DialogNozzle noz = new DialogNozzle(this.main_form, this, section);
                if(noz.ShowDialog() == DialogResult.OK)
                {
                    this.dgvSection.Refresh();
                }
            };
            this.dgvSection.Parent.Controls.Add(this.inline_nozzlecount);
            this.inline_nozzlecount.BringToFront();
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

            //this.txtName.Enabled = this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;
            //this.txtDesc.Enabled = this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;
            //this.txtRemark.Enabled = this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;
            //this.dtStartDate.Enabled = this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;
            //this.dtEndDate.Enabled = this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
            {
                if(MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosing(e);
        }

        public tank GetTank(int tank_id)
        {
            using (xpumpEntities db = DBX.DataSet())
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
            using (xpumpEntities db = DBX.DataSet())
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
            using (xpumpEntities db = DBX.DataSet())
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
            using (xpumpEntities db = DBX.DataSet())
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
            using (xpumpEntities db = DBX.DataSet())
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
            var sections = tank.section.ToList().ToViewModel().OrderBy(s => s.state).ThenBy(s => s.id).ToList();

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
            Rectangle row_rect = this.dgvSection.GetRowDisplayRectangle(row_index, true);
            using (Graphics g = this.dgvSection.CreateGraphics())
            {
                using (Pen p = new Pen(Color.Red))
                {
                    g.DrawLine(p, row_rect.X, row_rect.Y, row_rect.X + row_rect.Width, row_rect.Y);
                }
            }

            int col_index;

            /* inline name */
            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_name.DataPropertyName).First().Index;
                this.inline_name = new XTextEdit();
                this.inline_name.BorderStyle = BorderStyle.None;
                this.inline_name._TextChanged += delegate
                {
                    if (this.temp_section != null)
                    {
                        //this.temp_section.name = this.inline_name._Text;
                        this.temp_section.section.name = this.inline_name._Text;
                    }

                };
                this.inline_name.SetInlineControlPosition(this.dgvSection, row_index, col_index);
                this.dgvSection.Parent.Controls.Add(this.inline_name);
            }

            /* inline stkcod */
            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_stkcod.DataPropertyName).First().Index;
            this.inline_stkcod = new XBrowseBox();
            this.inline_stkcod._Text = this.temp_section.stkcod;
            this.inline_stkcod.BorderStyle = BorderStyle.None;
            this.inline_stkcod._ButtonClick += delegate
            {
                DialogInquiryStmas dlg = new DialogInquiryStmas();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if(this.temp_section != null)
                    {
                        using (xpumpEntities db = DBX.DataSet())
                        {
                            this.temp_section.section.stmas_id = dlg.selected_id;
                            this.inline_stkcod._Text = db.stmas.Find(dlg.selected_id).name;
                            this.inline_stkdes._Text = db.stmas.Find(dlg.selected_id).description;
                        }
                    }
                }
                this.inline_stkcod._textBox.Focus();
            };
            this.inline_stkcod._GotFocus += delegate
            {
                this.ValidateAddEditSection();
            };
            this.inline_stkcod._Leave += delegate
            {
                if (this.temp_section != null)
                {
                    using (xpumpEntities db = DBX.DataSet())
                    {
                        stmas tmp_stmas = db.stmas.Where(s => s.name == this.inline_stkcod._Text).FirstOrDefault();

                        if (tmp_stmas == null)
                        {
                            this.temp_section.section.stmas_id = -1;
                            this.inline_stkcod._Text = string.Empty;
                            this.inline_stkdes._Text = string.Empty;
                        }
                        else
                        {
                            this.temp_section.section.stmas_id = tmp_stmas.id;
                            this.inline_stkcod._Text = tmp_stmas.name;
                            this.inline_stkdes._Text = tmp_stmas.description;
                        }
                    }
                }
            };
            this.inline_stkcod.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.dgvSection.Parent.Controls.Add(this.inline_stkcod);

            /* inline loccod */


            /* inline stkdes */
            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_stkdes.DataPropertyName).First().Index;
            this.inline_stkdes = new XTextEdit();
            this.inline_stkdes._Text = this.temp_section.stkdes;
            this.inline_stkdes.BorderStyle = BorderStyle.None;
            this.inline_stkdes._ReadOnly = true;
            this.inline_stkdes.Enabled = false;
            this.inline_stkdes.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.dgvSection.Parent.Controls.Add(this.inline_stkdes);

            /* inline capacity */
            col_index = this.dgvSection.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begbal.DataPropertyName).First().Index;
            this.inline_capacity = new XNumEdit(2, true, 999999.99m, HorizontalAlignment.Right);
            this.inline_capacity._Value = this.temp_section.begbal;
            this.inline_capacity.BorderStyle = BorderStyle.None;
            this.inline_capacity._ValueChanged += delegate
            {
                if(this.temp_section != null)
                {
                    this.temp_section.section.begbal = this.inline_capacity._Value;
                }
            };
            this.inline_capacity._GotFocus += delegate
            {
                this.ValidateAddEditSection();
            };
            this.inline_capacity.SetInlineControlPosition(this.dgvSection, row_index, col_index);
            this.dgvSection.Parent.Controls.Add(this.inline_capacity);

            this.inline_nozzlecount.Visible = false;

            this.dgvSection.SendToBack();
        }

        private void RemoveInlineForm()
        {
            if(this.inline_name != null)
            {
                this.inline_name.Dispose();
                this.inline_name = null;
            }

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

            if(this.inline_capacity != null)
            {
                this.inline_capacity.Dispose();
                this.inline_capacity = null;
            }
        }

        private void ValidateAddEditSection()
        {
            if (this.temp_section == null)
                return;

            if(this.temp_section.section.name.Trim().Length == 0 && this.inline_name != null && !this.inline_name._Focused)
            {
                this.inline_name.Focus();
                return;
            }

            if(this.temp_section.section.stmas_id == -1 && this.inline_stkcod != null && !this.inline_stkcod._Focused)
            {
                this.inline_stkcod.Focus();
                this.inline_stkcod.PerformButtonClick();
                return;
            }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (this.form_mode == FORM_MODE.READ_ITEM || this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                using (Pen p0 = new Pen(Color.LimeGreen))
                {
                    using (Pen p = new Pen(Color.PaleGreen))
                    {
                        e.Graphics.DrawRectangle(p0, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                        e.Graphics.DrawRectangle(p, e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 3, e.ClipRectangle.Height - 3);
                    }
                }
            }
        }

        private void dgvSection_Resize(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            int row_index = ((XDatagrid)sender).CurrentCell.RowIndex;
            int col_index;

            if (this.inline_name != null)
            {
                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_name.DataPropertyName).First().Index;
                this.inline_name.SetInlineControlPosition((XDatagrid)sender, row_index, col_index);
            }

            if (this.inline_stkcod != null)
            {
                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_stkcod.DataPropertyName).First().Index;
                this.inline_stkcod.SetInlineControlPosition((XDatagrid)sender, row_index, col_index);
            }

            if(this.inline_stkdes != null)
            {
                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_stkdes.DataPropertyName).First().Index;
                this.inline_stkdes.SetInlineControlPosition((XDatagrid)sender, row_index, col_index);
            }

            if (this.inline_capacity != null)
            {
                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begbal.DataPropertyName).First().Index;
                this.inline_capacity.SetInlineControlPosition((XDatagrid)sender, row_index, col_index);
            }

            if(this.inline_nozzlecount.Visible)
            {
                col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().Index;
                Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(col_index, ((XDatagrid)sender).CurrentCell.RowIndex, true);
                this.inline_nozzlecount.SetBounds(rect.X, rect.Y + 1, 25, rect.Height - 3);
            }
        }

        public static bool DeleteNozzle(nozzle nozzle_to_delete)
        {
            if (nozzle_to_delete == null)
                return false;

            using (xpumpEntities db = DBX.DataSet())
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

        public static bool DeleteSection(section section_to_delete)
        {
            if (section_to_delete == null)
                return false;

            using (xpumpEntities db = DBX.DataSet())
            {
                foreach (nozzle noz in db.nozzle.Where(n => n.section_id == section_to_delete.id).ToList())
                {
                    if (!DeleteNozzle(noz))
                    {
                        return false;
                    }
                }
            }

            using (xpumpEntities db = DBX.DataSet())
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

        public static bool DeleteTank(tank tank_to_delete)
        {
            if (tank_to_delete == null)
                return false;

            using (xpumpEntities db = DBX.DataSet())
            {
                foreach (section sec in db.section.Where(s => s.tank_id == tank_to_delete.id).ToList())
                {
                    if (!DeleteSection(sec))
                    {
                        return false;
                    }
                }
            }

            using (xpumpEntities db = DBX.DataSet())
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

            using (xpumpEntities db = DBX.DataSet())
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

            //using (xpumpEntities db = DBX.DataSet())
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
                return;
            }

            if(this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.toolStrip1.Focus();
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.btnRefresh.PerformClick();

                this.panel2.Refresh();
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

                using(xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
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
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {

        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.dgvSection.Focus();
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            this.panel2.Refresh();
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
            this.temp_section = new section
            {
                id = -1,
                name = string.Empty,
                begbal = 0m,
                stmas_id = -1,
                tank_id = this.curr_tank.id,
            }.ToViewModel();
            this.curr_tank.section.Add(this.temp_section.section);
            this.FillForm();
            this.dgvSection.Rows[this.curr_tank.section.Count - 1].Cells["col_section_name"].Selected = true;
            this.form_mode = FORM_MODE.ADD_ITEM;
            this.ResetControlState();
            this.ShowInlineForm(this.curr_tank.section.Count - 1);
            this.inline_name.Focus();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgvSection.CurrentCell == null)
                return;

            this.temp_section = ((section)this.dgvSection.Rows[this.dgvSection.CurrentCell.RowIndex].Cells["col_section_section"].Value).ToViewModel();
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

        //    using (xpumpEntities db = DBX.DataSet())
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

            //using (xpumpEntities db = DBX.DataSet())
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

            if(this.temp_section.section.name.Trim().Length == 0 && this.inline_name != null)
            {
                this.inline_name.Focus();
                return;
            }

            if(this.temp_section.section.stmas_id == -1 && this.inline_stkcod != null)
            {
                this.inline_stkcod.Focus();
                return;
            }

            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        section section_to_update = db.section.Find(this.temp_section.id);

                        if (section_to_update == null)
                        {
                            MessageBox.Show("ค้นหารหัส \"" + this.temp_section.name + "\" เพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.inline_capacity.Focus();
                            return;
                        }

                        section_to_update.name = this.temp_section.section.name;
                        section_to_update.stmas_id = this.temp_section.section.stmas_id;
                        section_to_update.tank_id = this.temp_section.section.tank_id;
                        section_to_update.begbal = this.temp_section.section.begbal;

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
                if (this.txtRemark._Focused /*this.ddIsactive._Focused*/)
                {
                    this.btnSave.PerformClick();
                    return true;
                }

                if (this.inline_capacity != null && this.inline_capacity._Focused)
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
                this.btnDeleteItem.PerformClick();
                this.btnDelete.PerformClick();
                return true;
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

                if(((XDatagrid)sender).Columns[e.ColumnIndex].DataPropertyName == this.col_section_begbal.DataPropertyName)
                {
                    this.inline_capacity.Focus();
                    return;
                }
            }
        }

        private void dgvSection_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begbal.DataPropertyName).First().HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_begbal.DataPropertyName).First().HeaderCell.Style.Padding = new Padding(0, 0, 3, 0);
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_totbal.DataPropertyName).First().HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_totbal.DataPropertyName).First().HeaderCell.Style.Padding = new Padding(0, 0, 3, 0);
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_section_nozzlecount.DataPropertyName).First().HeaderCell.Style.Padding = new Padding(0, 0, 3, 0);
        }

        private void dgvSection_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

            if (e.Button == MouseButtons.Right && row_index > -1)
            {
                this.btnItem.PerformClick();

                ((XDatagrid)sender).Rows[row_index].Cells["col_section_name"].Selected = true;
                this.dgvSection_SelectionChanged(sender, new EventArgs());

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
                mnu_edit.Click += delegate
                {
                    this.btnEditItem.PerformClick();
                };
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem();
                mnu_delete.Text = "ลบ <Alt+D>";
                mnu_delete.Click += delegate
                {
                    this.btnDeleteItem.PerformClick();
                };
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }
    }
}
