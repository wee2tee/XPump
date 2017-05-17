using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;
using System.Data.Entity.Infrastructure;

namespace XPump.SubForm
{
    public partial class FormIstab : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private string tabtyp;
        private BindingList<istabVM> bl_istab;
        private istab tmp_istab;
        private string menu_id;

        public FormIstab(MainForm main_form, string tabtyp, string window_title = "")
        {
            InitializeComponent();
            this.main_form = main_form;
            this.tabtyp = tabtyp;
            this.Text = this.Text + " [" + window_title + "]";
        }

        private void FormIstab_Load(object sender, EventArgs e)
        {
            this.menu_id = this.GetType().Name;
            this.inline_isdayend._Items.Add(new XDropdownListItem { Text = "Y", Value = true });
            this.inline_isdayend._Items.Add(new XDropdownListItem { Text = "N", Value = false });
            this.inline_isshiftsales._Items.Add(new XDropdownListItem { Text = "Y", Value = true });
            this.inline_isshiftsales._Items.Add(new XDropdownListItem { Text = "N", Value = false });
            this.RemoveInlineForm();

            this.FillForm();
            this.ResetControlState(FORM_MODE.READ_ITEM);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

            if(this.bl_istab.Count == 0)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        public static List<istab> GetIstab(string tabtyp, SccompDbf working_express_db)
        {
            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                return db.istab.Where(i => i.tabtyp == tabtyp.Trim()).OrderBy(i => i.typcod).ToList();
            }
        }

        private void FillForm()
        {
            this.bl_istab = null;
            this.bl_istab = new BindingList<istabVM>(GetIstab(this.tabtyp, this.main_form.working_express_db).ToViewModel(this.main_form.working_express_db));
            this.dgv.DataSource = this.bl_istab;
            this.ActiveControl = this.dgv;
        }

        private void ShowInlineForm()
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_istab = (istab)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_istab.Name].Value;

            int col_index;
            if (this.form_mode == FORM_MODE.ADD_ITEM)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typcod.DataPropertyName).First().Index;
                this.inline_typcod.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
                this.inline_typcod._ReadOnly = false;
            }
            else if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.inline_typcod.SetBounds(-9999, 0, 0, 0);
                this.inline_typcod._ReadOnly = true;
            }
            this.inline_typcod._Text = this.tmp_istab.typcod;

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shortnam.DataPropertyName).First().Index;
            this.inline_shortnam.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_shortnam._Text = this.tmp_istab.shortnam;

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shortnam2.DataPropertyName).First().Index;
            this.inline_shortnam2.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_shortnam2._Text = this.tmp_istab.shortnam2;

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes.DataPropertyName).First().Index;
            this.inline_typdes.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_typdes._Text = this.tmp_istab.typdes;

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes2.DataPropertyName).First().Index;
            this.inline_typdes2.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_typdes2._Text = this.tmp_istab.typdes2;

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_is_shiftsales.DataPropertyName).First().Index;
            this.inline_isshiftsales.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_isshiftsales._SelectedItem = this.inline_isshiftsales._Items.Cast<XDropdownListItem>().Where(i => (bool)i.Value == this.tmp_istab.is_shiftsales).First();

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_is_dayend.DataPropertyName).First().Index;
            this.inline_isdayend.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_isdayend._SelectedItem = this.inline_isdayend._Items.Cast<XDropdownListItem>().Where(i => (bool)i.Value == this.tmp_istab.is_dayend).First();
        }

        private void RemoveInlineForm()
        {
            this.inline_typcod.SetBounds(-9999, 0, 0, 0);
            this.inline_shortnam.SetBounds(-9999, 0, 0, 0);
            this.inline_shortnam2.SetBounds(-9999, 0, 0, 0);
            this.inline_typdes.SetBounds(-9999, 0, 0, 0);
            this.inline_typdes2.SetBounds(-9999, 0, 0, 0);
            this.inline_isshiftsales.SetBounds(-9999, 0, 0, 0);
            this.inline_isdayend.SetBounds(-9999, 0, 0, 0);

            this.tmp_istab = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.bl_istab.Add(new istab
            {
                id = -1,
                tabtyp = this.tabtyp,
                typcod = string.Empty,
                shortnam = string.Empty,
                shortnam2 = string.Empty,
                typdes = string.Empty,
                typdes2 = string.Empty,
                creby = this.main_form.loged_in_status.loged_in_user_name,
            }.ToViewModel(this.main_form.working_express_db));

            this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typcod.Name].Selected = true;
            this.ResetControlState(FORM_MODE.ADD_ITEM);

            this.ShowInlineForm();
            this.inline_typcod.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.tmp_istab = db.istab.Find((int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value);

                if (this.tmp_istab == null)
                {
                    MessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                this.ResetControlState(FORM_MODE.EDIT_ITEM);

                this.ShowInlineForm();
                this.inline_shortnam.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if(this.form_mode == FORM_MODE.ADD_ITEM)
                {
                    if(this.tmp_istab.typcod.Trim().Length == 0)
                    {
                        MessageBox.Show("กรุณาป้อนรหัส", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.inline_typcod.Focus();
                        return;
                    }

                    try
                    {
                        this.tmp_istab.cretime = DateTime.Now;
                        db.istab.Add(this.tmp_istab);
                        db.SaveChanges();

                        this.main_form.islog.AddData(this.menu_id, "เพิ่มตารางข้อมูล(" + this.tmp_istab.tabtyp + ") รหัส \"" + this.tmp_istab.typcod + "\"", this.tmp_istab.tabtyp + "|" + this.tmp_istab.typcod, "istab", this.tmp_istab.id).Save();

                        this.RemoveInlineForm();
                        this.ResetControlState(FORM_MODE.READ_ITEM);
                        this.btnAdd.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        if(ex.InnerException.InnerException.Message.ToLower().Contains("duplicate entry"))
                        {
                            MessageBox.Show("รหัสซ้ำ \"" + this.tmp_istab.typcod + "\" กรุณาเปลี่ยนใหม่", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return;
                }

                if(this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    try
                    {
                        var istab_to_update = db.istab.Find(this.tmp_istab.id);

                        if(istab_to_update == null)
                        {
                            MessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if(this.tmp_istab.tabtyp == ISTAB_TABTYP.DOTHER)
                        {
                            if (this.tmp_istab.is_shiftsales == false && db.dother.Where(d => d.salessummary_id != null && d.istab_id == this.tmp_istab.id).Count() > 0)
                            {
                                MessageBox.Show("มีการนำไปใช้บันทึกยอดขายประจำผลัดแล้วไม่สามารถแก้ไขช่อง \"แสดงในสรุปผลัด\" เป็น \"N\" ได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.inline_isshiftsales.Focus();
                                SendKeys.Send("{F6}");
                                return;
                            }

                            if (this.tmp_istab.is_dayend == false && db.dother.Where(d => d.dayend_id != null && d.istab_id == this.tmp_istab.id).Count() > 0)
                            {
                                MessageBox.Show("มีการนำไปใช้บันทึกปิดขายประจำวันแล้วไม่สามารถแก้ไขช่อง \"แสดงในสรุปวัน\" เป็น \"N\" ได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.inline_isdayend.Focus();
                                SendKeys.Send("{F6}");
                                return;
                            }
                        }

                        istab_to_update.shortnam = this.tmp_istab.shortnam;
                        istab_to_update.shortnam2 = this.tmp_istab.shortnam2;
                        istab_to_update.typdes = this.tmp_istab.typdes;
                        istab_to_update.typdes2 = this.tmp_istab.typdes2;
                        istab_to_update.is_shiftsales = this.tmp_istab.is_shiftsales;
                        istab_to_update.is_dayend = this.tmp_istab.is_dayend;
                        istab_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        istab_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();

                        this.main_form.islog.EditData(this.menu_id, "แก้ไขตารางข้อมูล(" + this.tmp_istab.tabtyp + ") รหัส \"" + this.tmp_istab.typcod + "\"", this.tmp_istab.tabtyp + "|" + this.tmp_istab.typcod, "istab", this.tmp_istab.id).Save();

                        this.RemoveInlineForm();
                        this.ResetControlState(FORM_MODE.READ_ITEM);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var istab = (istab)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_istab.Name].Value;

            if(MessageBox.Show("ลบรหัส \"" + istab.typcod + "\", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        var istab_to_delete = db.istab.Find(istab.id);

                        if(istab_to_delete == null)
                        {
                            MessageBox.Show("ข้อมูลที่ต้องการลบไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if(db.dother.Where(d => d.istab_id == istab_to_delete.id).Count() > 0)
                        {
                            MessageBox.Show("มีการนำไปใช้งานแล้ว, ไม่สามารถลบได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        db.istab.Remove(istab_to_delete);
                        db.SaveChanges();

                        this.main_form.islog.DeleteData(this.menu_id, "ลบตารางข้อมูล(" + istab_to_delete.tabtyp + ") รหัส \"" + istab_to_delete.typcod + "\"", istab_to_delete.tabtyp + "|" + istab_to_delete.typcod, "istab", istab_to_delete.id).Save();

                        this.bl_istab.Remove(this.bl_istab.Where(i => i.id == istab_to_delete.id).First());
                        this.ResetControlState(FORM_MODE.READ_ITEM);
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
            int focused_id = this.tmp_istab.id;
            this.RemoveInlineForm();
            this.ResetControlState(FORM_MODE.READ_ITEM);
            this.btnRefresh.PerformClick();

            if (this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == focused_id).FirstOrDefault() != null)
            {
                this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == focused_id).First().Cells[this.col_typcod.Name].Selected = true;
            }
            else
            {
                if (this.dgv.Rows.Count > 0)
                    this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typcod.Name].Selected = true;
            }

            this.ResetControlState(FORM_MODE.READ_ITEM);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //this.bl_istab = null;
            this.FillForm();
            //this.bl_istab = new BindingList<istabVM>(GetIstab(this.tabtyp, this.main_form.working_express_db).ToViewModel(this.main_form.working_express_db));
            //this.dgv.DataSource = this.bl_istab;
        }

        private void inline_typcod__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.typcod = ((XTextEdit)sender)._Text;
        }

        private void inline_shortnam__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.shortnam = ((XTextEdit)sender)._Text;
        }

        private void inline_shortnam2__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.shortnam2 = ((XTextEdit)sender)._Text;
        }

        private void inline_typdes__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.typdes = ((XTextEdit)sender)._Text;
        }

        private void inline_typdes2__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.typdes2 = ((XTextEdit)sender)._Text;
        }

        private void inline_isshiftsales__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.is_shiftsales = (bool)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void inline_isdayend__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_istab != null)
                this.tmp_istab.is_dayend = (bool)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if (this.inline_isdayend._Focused)
                    {
                        this.btnSave.PerformClick();
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                    return true;
                }
            }

            if (keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

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

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
                if(row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_typcod.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม <Alt+A>");
                mnu_add.Click += delegate
                {
                    this.btnAdd.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ <Alt+D>");
                mnu_delete.Click += delegate
                {
                    this.btnDelete.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.btnEdit.PerformClick();
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                int col_index;
                if (this.form_mode == FORM_MODE.ADD_ITEM)
                {
                    col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typcod.DataPropertyName).First().Index;
                    this.inline_typcod.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
                }
                else if (this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    this.inline_typcod.SetBounds(-9999, 0, 0, 0);
                }

                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shortnam.DataPropertyName).First().Index;
                this.inline_shortnam.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shortnam2.DataPropertyName).First().Index;
                this.inline_shortnam2.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes.DataPropertyName).First().Index;
                this.inline_typdes.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes2.DataPropertyName).First().Index;
                this.inline_typdes2.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_is_shiftsales.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);

                    var rect = new Rectangle(e.CellBounds.X, e.CellBounds.Y + (e.CellBounds.Height / 2), e.CellBounds.Width, e.CellBounds.Height / 2);

                    TextRenderer.DrawText(e.Graphics, "สรุปผลัด", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    e.Handled = true;
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_is_dayend.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);

                    var rect = new Rectangle(e.CellBounds.X, e.CellBounds.Y + (e.CellBounds.Height / 2), e.CellBounds.Width, e.CellBounds.Height / 2);

                    TextRenderer.DrawText(e.Graphics, "สรุปวัน", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    using (SolidBrush brush = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(brush, new Rectangle(e.CellBounds.X - 3, e.CellBounds.Y + 2, 6, (int)Math.Floor((decimal)e.CellBounds.Height / 2) - 2));
                    };

                    rect = new Rectangle(e.CellBounds.X - e.CellBounds.Width, e.CellBounds.Y, e.CellBounds.Width * 2, (int)Math.Floor((decimal)e.CellBounds.Height / 2));
                    TextRenderer.DrawText(e.Graphics, "แสดงใน", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    using (Pen pen = new Pen(Color.DarkGray))
                    {
                        e.Graphics.DrawLine(pen, new Point(e.CellBounds.X - e.CellBounds.Width, e.CellBounds.Y + (int)Math.Floor((decimal)e.CellBounds.Height / 2)), new Point(e.CellBounds.X + e.CellBounds.Width, e.CellBounds.Y + (int)Math.Floor((decimal)e.CellBounds.Height / 2)));
                    }
                    e.Handled = true;
                }
            }
        }
    }

    public static class ISTAB_TABTYP
    {
        public const String DOTHER = "01";
    }
}
