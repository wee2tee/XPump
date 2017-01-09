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
using System.Resources;
using System.Data.SqlClient;
using System.Data.Entity.Core;
using MySql.Data.MySqlClient;
using System.Data.Entity.Infrastructure;

namespace XPump.SubForm
{
    public partial class FormShift : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<shiftVM> shift_list;
        private FORM_MODE form_mode;
        private shiftVM temp_shift; // model for add/edit shift
        private XTextBox inline_name; // inline control for name
        private XTimePicker inline_start; // inline control for start time
        private XTimePicker inline_end; // inline control for end time
        private XTextBox inline_desc; // inline control for description

        public FormShift()
        {
            InitializeComponent();
        }

        public FormShift(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.bs.DataSource = this.shift_list;
            this.dgv.DataSource = this.bs;

            this.shift_list = this.GetShiftList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;
        }

        public List<shift> GetShiftList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shift.Include("saleshistory").Include("salessummary").ToList();
            }
        }

        private void ResetControlState()
        {
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            if (this.dgv.Enabled)
            {
                this.dgv.Focus();
            }
        }

        private void ShowInlineControl(int row_index)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if (this.temp_shift == null)
                return;

            int col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index;
            this.inline_name = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_shift.shift, "name");
            this.inline_name.MaxLength = 20;
            this.inline_name.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().Index;
            this.inline_start = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTimePickerEdit(this.temp_shift.shift, "starttime");
            this.inline_start.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().Index;
            this.inline_end = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTimePickerEdit(this.temp_shift.shift, "endtime");
            this.inline_end.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index;
            this.inline_desc = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_shift.shift, "description");
            this.inline_desc.MaxLength = 50;
            this.inline_desc.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            if (this.form_mode == FORM_MODE.ADD)
                this.dgv.Parent.Controls.Add(this.inline_name);
            this.dgv.Parent.Controls.Add(this.inline_start);
            this.dgv.Parent.Controls.Add(this.inline_end);
            this.dgv.Parent.Controls.Add(this.inline_desc);
            this.inline_name.BringToFront();
            this.inline_start.BringToFront();
            this.inline_end.BringToFront();
            this.inline_desc.BringToFront();
            if(this.form_mode == FORM_MODE.ADD)
            {
                this.inline_name.Focus();
            }
            else
            {
                this.inline_start.Focus();
            }
        }

        private void RemoveInlineControl()
        {
            if (this.inline_name != null)
            {
                this.inline_name.Dispose();
                this.inline_name = null;
            }
            
            if(this.inline_start != null)
            {
                this.inline_start.Dispose();
                this.inline_start = null;
            }

            if(this.inline_end != null)
            {
                this.inline_end.Dispose();
                this.inline_end = null;
            }

            if(this.inline_desc != null)
            {
                this.inline_desc.Dispose();
                this.inline_desc = null;
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.temp_shift = new shift()
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                starttime = new TimeSpan(0, 0, 0),
                endtime = new TimeSpan(0, 0, 0),
                remark = string.Empty,
                saleshistory = null,
                salessummary = null
            }.ToViewModel();

            this.shift_list.Add(this.temp_shift);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;

            this.dgv.CurrentCell = this.dgv.Rows[this.shift_list.Count - 1].Cells["col_name"];
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.temp_shift = ((shift)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_shift"].Value).ToViewModel();
            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(StringResource.Msg("0003"), "Message # 0003", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        shift shift_to_delete = db.shift.Find(((shift)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_shift"].Value).id);

                        if(shift_to_delete == null)
                        {
                            MessageBox.Show(StringResource.Msg("0004"), "Message # 0004", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        db.shift.Remove(shift_to_delete);
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
            this.RemoveInlineControl();
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.btnRefresh.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                if(this.temp_shift.shift.name.Trim().Length == 0)
                {
                    MessageBox.Show("กรุณาป้อนชื่อผลัด");

                    this.inline_name.Focus();
                    return;
                }

                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.shift.Add(this.temp_shift.shift);
                        db.SaveChanges();
                        this.RemoveInlineControl();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                        this.btnAdd.PerformClick();
                    }
                    catch (DbUpdateException ex)
                    {
                        if (ex.InnerException.Message.ToLower().Contains("Duplicate entry") || ex.InnerException.InnerException.Message.ToLower().Contains("Duplicate entry"))
                        {
                            MessageBox.Show("ชื่อผลัด \"" + this.temp_shift.shift.name + "\" มีอยู่แล้วในระบบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.inline_name.Focus();
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
                        shift shift = db.shift.Find(this.temp_shift.id);
                        if(shift == null)
                        {
                            MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        shift.name = this.temp_shift.shift.name;
                        shift.starttime = this.temp_shift.shift.starttime;
                        shift.endtime = this.temp_shift.shift.endtime;
                        shift.description = this.temp_shift.shift.description;
                        shift.remark = this.temp_shift.shift.remark;
                        db.SaveChanges();
                        this.RemoveInlineControl();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.shift_list = this.GetShiftList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.Button == MouseButtons.Left/* && this.form_mode == FORM_MODE_LIST.READ*/)
            {
                ((XDatagrid)sender).SortByColumn<shiftVM>(e.ColumnIndex);
                return;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.btnEdit.PerformClick();
            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index)
            {
                this.inline_name.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().Index)
            {
                this.inline_start.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().Index)
            {
                this.inline_end.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index)
            {
                this.inline_desc.Focus();
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
            int col_index = ((XDatagrid)sender).HitTest(e.X, e.Y).ColumnIndex;

            if (e.Button == MouseButtons.Right && row_index > -1)
            {
                ((XDatagrid)sender).Rows[row_index].Cells[col_index].Selected = true;

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
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ <Alt+D>");
                mnu_delete.Click += delegate
                {
                    this.btnDelete.PerformClick();
                };
                cm.MenuItems.Add(mnu_delete);

                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            this.inline_name.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index);
            this.inline_start.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().Index);
            this.inline_end.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().Index);
            this.inline_desc.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index);
        }

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

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT))
            {
                if (this.inline_desc.Focused)
                {
                    this.btnSave.PerformClick();
                    return true;
                }

                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
