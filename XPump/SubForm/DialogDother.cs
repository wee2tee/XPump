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

namespace XPump.SubForm
{
    public partial class DialogDother : Form
    {
        private MainForm main_form;
        private salessummary salessummary;
        private FORM_MODE form_mode;
        private BindingList<dotherVM> bl_dother;
        private dother tmp_dother;

        public DialogDother(MainForm main_form, salessummary salessummary)
        {
            InitializeComponent();
            this.main_form = main_form;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.salessummary = db.salessummary.Include("shiftsales").Where(s => s.id == salessummary.id).FirstOrDefault();
                if(this.salessummary == null)
                {
                    MessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void DialogDother_Load(object sender, EventArgs e)
        {
            foreach (var d in this.GetAvailableDother())
            {
                this.inline_dother._Items.Add(new XDropdownListItem { Text = "[" + d.typcod + "]" + d.typdes, Value = d.id });
            }

            this.RemoveInlineForm();
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ_ITEM);
        }

        private void ResetControlState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

            if(this.bl_dother.Count == 0)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private List<istab> GetAvailableDother()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.DOTHER && i.is_shiftsales).ToList();
            }
        }

        private List<dother> GetDother()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.dother.Where(d => d.salessummary_id == this.salessummary.id).ToList();
            }
        }

        private void FillForm()
        {
            this.bl_dother = null;
            this.bl_dother = new BindingList<dotherVM>(this.GetDother().ToViewModel(this.main_form.working_express_db).OrderBy(d => d.typdes).ToList());
            this.dgv.DataSource = this.bl_dother;
        }

        private void ShowInlineForm()
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_dother = (dother)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_dother.Name].Value;

            int col_index;

            if(this.form_mode == FORM_MODE.ADD_ITEM)
            {
                col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_typdes.DataPropertyName).First().Index;
                this.inline_dother.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
                this.inline_dother._ReadOnly = false;
            }
            else
            {
                this.inline_dother.SetBounds(-9999, 0, 0, 0);
                this.inline_dother._ReadOnly = true;
            }
            //this.inline_dother._SelectedItem = this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.istab_id).FirstOrDefault() != null ? this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.tmp_dother.istab_id).First() : this.inline_dother._Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == -1).First();

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_qty.DataPropertyName).First().Index;
            this.inline_qty.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
            this.inline_qty._Value = this.tmp_dother.qty;
        }

        private void RemoveInlineForm()
        {
            this.inline_dother.SetBounds(-9999, 0, 0, 0);
            this.inline_qty.SetBounds(-9999, 0, 0, 0);
            this.tmp_dother = null;
        }

        private void inline_dother__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_dother != null)
                this.tmp_dother.istab_id = (int)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void inline_qty__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_dother != null)
                this.tmp_dother.qty = ((XNumEdit)sender)._Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var is_approved = this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsApproved();
            if (is_approved != null && is_approved == true)
            {
                MessageBox.Show("รายการถูกรับรองไปแล้ว ไม่สามารถแก้ไขได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.bl_dother.Add(new dother
            {
                id = -1,
                salessummary_id = this.salessummary.id,
                istab_id = -1,
                qty = 0m,
                creby = this.main_form.loged_in_status.loged_in_user_name
            }.ToViewModel(this.main_form.working_express_db));

            this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typdes.Name].Selected = true;
            this.ResetControlState(FORM_MODE.ADD_ITEM);
            this.ShowInlineForm();
            this.inline_dother.Focus();
            SendKeys.Send("{F6}");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var is_approved = this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsApproved();
            if (is_approved != null && is_approved == true)
            {
                MessageBox.Show("รายการถูกรับรองไปแล้ว ไม่สามารถแก้ไขได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.ResetControlState(FORM_MODE.EDIT_ITEM);
            this.ShowInlineForm();
            this.inline_qty.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            int focused_id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value;

            this.RemoveInlineForm();
            this.FillForm();
            this.ResetControlState(FORM_MODE.READ_ITEM);

            if(this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == focused_id).FirstOrDefault() != null)
            {
                this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == focused_id).First().Cells[this.col_typdes.Name].Selected = true;
            }
            else
            {
                if(this.dgv.Rows.Count > 0)
                {
                    this.dgv.Rows[this.dgv.Rows.Count - 1].Cells[this.col_typdes.Name].Selected = true;
                }
            }

            this.ActiveControl = this.dgv;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var is_approved = this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsApproved();
            if (is_approved != null && is_approved == true)
            {
                MessageBox.Show("รายการถูกรับรองไปแล้ว ไม่สามารถแก้ไขได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (this.tmp_dother.istab_id == -1)
            {
                MessageBox.Show("กรุณาระบุรายละเอียดการหักฯ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.inline_dother.Focus();
                SendKeys.Send("{F6}");
                return;
            }
            if(this.tmp_dother.qty <= 0)
            {
                MessageBox.Show("ปริมาณต้องมากกว่า 0", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.inline_qty.Focus();
                return;
            }
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if(this.form_mode == FORM_MODE.ADD_ITEM)
                {
                    try
                    {
                        this.tmp_dother.cretime = DateTime.Now;
                        db.dother.Add(this.tmp_dother);

                        var sales_to_update = db.salessummary.Find(this.salessummary.id);
                        sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        sales_to_update.chgtime = DateTime.Now;

                        var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                        shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        shiftsales_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();

                        this.RemoveInlineForm();
                        this.ResetControlState(FORM_MODE.READ_ITEM);
                        this.btnAdd.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }
                
                if(this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    try
                    {
                        var dother_to_update = db.dother.Find(this.tmp_dother.id);

                        if(dother_to_update == null)
                        {
                            MessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        dother_to_update.istab_id = this.tmp_dother.istab_id;
                        dother_to_update.qty = this.tmp_dother.qty;
                        dother_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        dother_to_update.chgtime = DateTime.Now;

                        var sales_to_update = db.salessummary.Find(this.salessummary.id);
                        sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        sales_to_update.chgtime = DateTime.Now;

                        var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                        shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        shiftsales_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();
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
            if (this.dgv.CurrentCell == null)
                return;

            var is_approved = this.salessummary.shiftsales.ToViewModel(this.main_form.working_express_db).IsApproved();
            if (is_approved != null && is_approved == true)
            {
                MessageBox.Show("รายการถูกรับรองไปแล้ว ไม่สามารถแก้ไขได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var dother = (dother)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_dother.Name].Value;

            if(MessageBox.Show("ลบ \"" + dother.ToViewModel(this.main_form.working_express_db).typdes + "\" : " + dother.qty + " ลิตร, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        var dother_to_delete = db.dother.Find(dother.id);
                        if(dother_to_delete == null)
                        {
                            MessageBox.Show("ข้อมูลที่ต้องการลบไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            db.dother.Remove(dother_to_delete);

                            var sales_to_update = db.salessummary.Find(this.salessummary.id);
                            sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            sales_to_update.chgtime = DateTime.Now;

                            var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                            shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                            shiftsales_to_update.chgtime = DateTime.Now;

                            db.SaveChanges();

                            this.bl_dother.Remove(this.bl_dother.Where(d => d.id == dother_to_delete.id).First());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_typdes.Name].Selected = true;

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

        private void DialogDother_Deactivate(object sender, EventArgs e)
        {
            //this.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return true;
                }
                else
                {
                    this.btnStop.PerformClick();
                    return true;
                }
            }

            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if (this.inline_qty._Focused)
                    {
                        this.btnSave.PerformClick();
                        return true;
                    }

                    SendKeys.Send("{TAB}");
                    return true;
                }
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.ResetControlState(FORM_MODE.EDIT_ITEM);
            this.ShowInlineForm();
            this.inline_qty.Focus();
        }
    }
}
