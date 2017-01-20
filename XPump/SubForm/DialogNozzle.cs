﻿using System;
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
    public partial class DialogNozzle : Form
    {
        private MainForm main_form;
        private FormTankSetup form_tanksetup;
        private tank tank;
        private section section;
        private nozzle temp_nozzle;
        private FORM_MODE form_mode;

        private XTextEdit inline_name;
        private XTextEdit inline_desc;
        private XDropdownList inline_isactive;

        private BindingSource bs;
        private List<nozzle> list_nozzle;

        //public DialogNozzle()
        //{
        //    InitializeComponent();
        //}

        public DialogNozzle(MainForm main_form, FormTankSetup form_tanksetup, section section_object)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.section = section_object;
            this.form_tanksetup = form_tanksetup;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ_ITEM)
            {
                if(MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            base.OnClosing(e);
        }

        private void DialogNozzle_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            using (xpumpEntities db = DBX.DataSet())
            {
                this.section = db.section.Find(this.section.id);
                if (this.section == null)
                {
                    MessageBox.Show("ไม่สามารถค้นหาช่องเก็บน้ำมันที่ต้องการแก้ไข, อาจมีผู้ใช้รายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                this.lblSection.Text = this.section.name;

                this.tank = db.tank.Find(this.section.tank_id);
                if(this.tank == null)
                {
                    MessageBox.Show("ไม่สามารถค้นหาแท๊งค์ที่ต้องการแก้ไข, อาจมีผู้ใช้รายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                this.lblTank.Text = this.tank.name + " / " + this.tank.description;

                this.list_nozzle = this.GetNozzleList();

                this.bs = new BindingSource();
                this.bs.DataSource = this.list_nozzle.ToViewModel();
                this.dgv.DataSource = this.bs;
            }
        }

        public List<nozzle> GetNozzleList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.nozzle.Where(n => n.section_id == this.section.id).ToList();
            }
        }

        private void ResetControlState()
        {
            this.btnAddItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSaveItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnStopItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
        }

        private void ShowInlineForm(int row_index)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if (this.temp_nozzle == null)
                return;

            int col_index;

            /* inline_name */
            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index;
                this.inline_name = new XTextEdit();
                this.inline_name._BorderStyle = BorderStyle.None;
                this.inline_name._Text = this.temp_nozzle.name;
                this.inline_name._TextChanged += delegate
                {
                    if (this.temp_nozzle != null)
                        this.temp_nozzle.name = this.inline_name._Text;
                };
                this.inline_name.SetInlineControlPosition(this.dgv, row_index, col_index);
                this.dgv.Parent.Controls.Add(this.inline_name);
            }

            /* inline_desc */
            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index;
            this.inline_desc = new XTextEdit();
            this.inline_desc._BorderStyle = BorderStyle.None;
            this.inline_desc._Text = this.temp_nozzle.description;
            this.inline_desc._TextChanged += delegate
            {
                if (this.temp_nozzle != null)
                    this.temp_nozzle.description = this.inline_desc._Text;
            };
            this.inline_desc._GotFocus += delegate
            {
                this.ValidateNozzleModel();
            };
            this.inline_desc.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.dgv.Parent.Controls.Add(this.inline_desc);

            /* inline_isactive */
            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col__isactive.DataPropertyName).First().Index;
            this.inline_isactive = new XDropdownList();
            this.inline_isactive._Items.Add(new XDropdownListItem { Text = "ใช้งาน", Value = true });
            this.inline_isactive._Items.Add(new XDropdownListItem { Text = "ไม่ใช้งาน", Value = false });
            this.inline_isactive._SelectedItem = this.inline_isactive._Items.Cast<XDropdownListItem>().Where(i => (bool)i.Value == this.temp_nozzle.isactive).First();
            this.inline_isactive._SelectedItemChanged += delegate
            {
                if (this.temp_nozzle != null)
                    this.temp_nozzle.isactive = (bool)((XDropdownListItem)this.inline_isactive._SelectedItem).Value;
            };
            this.inline_isactive._GotFocus += delegate
            {
                this.ValidateNozzleModel();
            };
            this.inline_isactive.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.dgv.Parent.Controls.Add(this.inline_isactive);

            this.dgv.SendToBack();
        }

        private void RemoveInlineForm()
        {
            if(this.inline_name != null)
            {
                this.inline_name.Dispose();
                this.inline_name = null;
            }

            if(this.inline_desc != null)
            {
                this.inline_desc.Dispose();
                this.inline_desc = null;
            }
            
            if(this.inline_isactive != null)
            {
                this.inline_isactive.Dispose();
                this.inline_isactive = null;
            }
        }

        private void ValidateNozzleModel()
        {
            if (this.temp_nozzle == null)
                return;

            if(this.temp_nozzle.name.Trim().Length == 0 && !this.inline_name._Focused)
            {
                this.inline_name.Focus();
                return;
            }
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            int row_index = ((XDatagrid)sender).CurrentCell.RowIndex;
            int col_index;

            if(this.inline_name != null)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index;
                this.inline_name.SetInlineControlPosition(this.dgv, row_index, col_index);
            }

            if(this.inline_desc != null)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index;
                this.inline_desc.SetInlineControlPosition(this.dgv, row_index, col_index);
            }

            if(this.inline_isactive != null)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col__isactive.DataPropertyName).First().Index;
                this.inline_isactive.SetInlineControlPosition(this.dgv, row_index, col_index);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            this.temp_nozzle = new nozzle
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                isactive = true,
                remark = string.Empty,
                section_id = this.section.id
            };
            this.list_nozzle.Add(this.temp_nozzle);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.list_nozzle.ToViewModel();

            this.dgv.Rows[this.list_nozzle.Count - 1].Cells["col_name"].Selected = true;
            this.form_mode = FORM_MODE.ADD_ITEM;
            this.ResetControlState();
            this.ShowInlineForm(this.dgv.CurrentCell.RowIndex);
            this.inline_name.Focus();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.temp_nozzle = (nozzle)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_nozzle"].Value;
            this.form_mode = FORM_MODE.EDIT_ITEM;
            this.ResetControlState();
            this.ShowInlineForm(this.dgv.CurrentCell.RowIndex);
            this.inline_desc.Focus();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            nozzle tmp = (nozzle)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_nozzle"].Value;

            if (MessageBox.Show("ลบรหัสหัวจ่าย \"" + tmp.name + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    db.nozzle.Remove(db.nozzle.Find(tmp.id));
                    db.SaveChanges();

                    this.list_nozzle = this.GetNozzleList();
                    this.bs.ResetBindings(true);
                    this.bs.DataSource = this.list_nozzle.ToViewModel();
                    if (this.form_tanksetup != null)
                        this.form_tanksetup.RefreshDgvSection();
                }
            }
            catch (Exception ex)
            {
                ex.ShowMessage("รหัส", tmp.name, "รหัสช่องเก็บน้ำมัน", this.section.name);
            }
        }

        private void btnStopItem_Click(object sender, EventArgs e)
        {
            this.list_nozzle = this.GetNozzleList();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.list_nozzle.ToViewModel();
            this.RemoveInlineForm();
            this.temp_nozzle = null;
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.dgv.Focus();
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            if (this.temp_nozzle == null)
                return;

            if(this.temp_nozzle.name.Trim().Length == 0 && this.inline_name != null)
            {
                this.inline_name.Focus();
                return;
            }

            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.nozzle.Add(this.temp_nozzle);
                        db.SaveChanges();

                        this.list_nozzle = this.GetNozzleList();
                        this.bs.ResetBindings(true);
                        this.bs.DataSource = this.list_nozzle.ToViewModel();
                        if (this.form_tanksetup != null)
                            this.form_tanksetup.RefreshDgvSection();

                        this.btnStopItem.PerformClick();
                        this.btnAddItem.PerformClick();
                    }
                    catch(Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_nozzle.name, "รหัสช่องเก็บน้ำมัน", this.section.name);
                    }
                    //catch (DbUpdateException ex)
                    //{
                    //    if (ex.InnerException.Message.ToLower().Contains("duplicate entry") || ex.InnerException.InnerException.Message.ToLower().Contains("duplicate entry"))
                    //    {
                    //        MessageBox.Show("รหัส \"" + this.temp_nozzle.name + "\" มีอยู่แล้วในระบบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //        this.inline_name.Focus();
                    //    }
                    //}
                }

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        nozzle nozzle_to_update = db.nozzle.Find(this.temp_nozzle.id);

                        if (nozzle_to_update == null)
                        {
                            MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        nozzle_to_update.name = this.temp_nozzle.name;
                        nozzle_to_update.description = this.temp_nozzle.description;
                        nozzle_to_update.isactive = this.temp_nozzle.isactive;
                        nozzle_to_update.remark = this.temp_nozzle.remark;

                        db.SaveChanges();

                        this.list_nozzle = this.GetNozzleList();
                        this.bs.ResetBindings(true);
                        this.bs.DataSource = this.list_nozzle.ToViewModel();

                        this.btnStopItem.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_nozzle.name, "รหัสช่องเก็บน้ำมัน", this.section.name);
                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter && (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM))
            {
                if (this.inline_isactive._Focused)
                {
                    this.btnSaveItem.PerformClick();
                    return true;
                }

                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.Enter && this.form_mode == FORM_MODE.READ_ITEM && this.dgv.Focused)
            {
                return true;
            }

            if(keyData == Keys.Escape)
            {
                if (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    this.btnStopItem.PerformClick();
                    return true;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSaveItem.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.A))
            {
                this.btnAddItem.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEditItem.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.D))
            {
                this.btnDeleteItem.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

            if(e.Button == MouseButtons.Right && row_index > -1)
            {
                ((XDatagrid)sender).Rows[row_index].Cells["col_name"].Selected = true;
                
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.btnEditItem.PerformClick();

                if(((XDatagrid)sender).Columns[e.ColumnIndex].DataPropertyName == this.col__isactive.DataPropertyName)
                {
                    this.inline_isactive.Focus();
                    return;
                }
            }
        }
    }
}
