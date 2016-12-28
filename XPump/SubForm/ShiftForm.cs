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

namespace XPump.SubForm
{
    public partial class ShiftForm : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<shiftVM> shift_list;
        private FORM_MODE_LIST form_mode;
        private shiftVM temp_shift; // model for create new shift
        private Control inline_control; // control for add/edit inline form

        public ShiftForm()
        {
            InitializeComponent();
        }

        public ShiftForm(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE_LIST.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.bs.DataSource = this.shift_list;
            this.dgv.DataSource = this.bs;

            this.shift_list = this.GetShiftList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;

            //using (xpumpEntities db = DBX.DataSet())
            //{
            //    List<shiftVM> list_shift = db.shift.ToList().ToViewModel();
            //    var list_obj = list_shift.Select(s => new { id = s.id, ชื่อย่อ = s.name, เวลาเริ่มต้น = s.starttime, เวลาสิ้นสุด = s.endtime, คำอธิบายเพิ่มเติม = s.description });
            //    XBrowseBox xb = new XBrowseBox("Shift selector.", list_obj, "ชื่อย่อ");
            //    xb.SetBounds(0, 0, xb.Width, xb.Height);
            //    this.panel1.Controls.Add(xb);
            //}
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
            this.ValidateControlState(this.btnAdd, new FORM_MODE_LIST[] { FORM_MODE_LIST.READ });
            this.ValidateControlState(this.btnEdit, new FORM_MODE_LIST[] { FORM_MODE_LIST.READ });
            this.ValidateControlState(this.btnDelete, new FORM_MODE_LIST[] { FORM_MODE_LIST.READ });
            this.ValidateControlState(this.btnStop, new FORM_MODE_LIST[] { FORM_MODE_LIST.ADD, FORM_MODE_LIST.EDIT });
            this.ValidateControlState(this.btnSave, new FORM_MODE_LIST[] { FORM_MODE_LIST.ADD, FORM_MODE_LIST.EDIT });
            this.ValidateControlState(this.btnRefresh, new FORM_MODE_LIST[] { FORM_MODE_LIST.READ });
        }

        private void ValidateControlState(Component comp, FORM_MODE_LIST[] form_mode_to_enable)
        {
            if(form_mode_to_enable.ToList().Where(fm => fm == this.form_mode).Count() > 0)
            {
                if(comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true; return;
                }
            }
            else
            {
                if(comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = false; return;
                }
            }
        }

        private void ShowInlineControl(XDatagrid dgv, int row_index, int column_index)
        {
            if (dgv.CurrentCell == null)
                return;

            //shift shift = (shift)dgv.Rows[row_index].Cells["col_shift"].Value;
            //if (shift == null)
            //    return;

            if (this.temp_shift == null)
                return;

            if (column_index == this.dgv.Columns.Cast<DataGridViewColumn>().Where(col => col.DataPropertyName == this.col_start.DataPropertyName).First().Index)
            {
                //this.inline_control = new XTimePicker();
                //((XTimePicker)this.inline_control).Text = ((TimeSpan)dgv.Rows[row_index].Cells[column_index].Value).ToString(@"hh\:mm\:ss");
                this.inline_control = dgv.Rows[row_index].Cells[column_index].CreateXTimePickerEdit(this.temp_shift.shift, "starttime");
            }

            if (column_index == this.dgv.Columns.Cast<DataGridViewColumn>().Where(col => col.DataPropertyName == this.col_end.DataPropertyName).First().Index)
            {
                //this.inline_control = new XTimePicker();
                //((XTimePicker)this.inline_control).Text = ((TimeSpan)dgv.Rows[row_index].Cells[column_index].Value).ToString(@"hh\:mm\:ss");
                this.inline_control = dgv.Rows[row_index].Cells[column_index].CreateXTimePickerEdit(this.temp_shift.shift, "endtime");
            }

            if(column_index == this.dgv.Columns.Cast<DataGridViewColumn>().Where(col => col.DataPropertyName == this.col_name.DataPropertyName).First().Index)
            {
                this.inline_control = dgv.Rows[row_index].Cells[column_index].CreateXTextBoxEdit(this.temp_shift.shift, "name");
            }

            if (column_index == this.dgv.Columns.Cast<DataGridViewColumn>().Where(col => col.DataPropertyName == this.col_desc.DataPropertyName).First().Index)
            {
                this.inline_control = dgv.Rows[row_index].Cells[column_index].CreateXTextBoxEdit(this.temp_shift.shift, "description");
            }
            
            this.dgv.Tag = new InlineControlGridPosition() { RowIndex = row_index, ColumnIndex = column_index };
            this.inline_control.SetInlineControlPosition(this.dgv);
            this.dgv.Parent.Controls.Add(this.inline_control);
            this.inline_control.BringToFront();
            this.inline_control.Focus();
        }

        private void RemoveInlineControl()
        {
            if (this.inline_control == null)
                return;

            this.inline_control.Dispose();
            this.inline_control = null;
            this.dgv.Tag = null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE_LIST.READ)
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
            ShiftAddEditForm add_form = new ShiftAddEditForm();
            add_form.ShowDialog();
            //this.temp_shift = new shift()
            //{
            //    id = -1,
            //    name = string.Empty,
            //    description = string.Empty,
            //    starttime = new TimeSpan(0, 0, 0),
            //    endtime = new TimeSpan(0, 0, 0),
            //    remark = string.Empty,
            //    saleshistory = null,
            //    salessummary = null
            //}.ToViewModel();

            //this.temp_shift.record_state = RECORD_STATE.NEW;

            //this.shift_list.Add(this.temp_shift);

            //this.bs.ResetBindings(true);
            //this.bs.DataSource = this.shift_list;

            //this.dgv.CurrentCell = this.dgv.Rows[this.shift_list.Count - 1].Cells["col_name"];
            //this.ShowInlineControl(this.dgv, this.dgv.CurrentCell.RowIndex, this.dgv.CurrentCell.ColumnIndex);
            //this.form_mode = FORM_MODE_LIST.ADD;
            //this.ResetControlState();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.temp_shift = ((shift)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_shift"].Value).ToViewModel();
            this.ShowInlineControl(this.dgv, this.dgv.CurrentCell.RowIndex, this.dgv.CurrentCell.ColumnIndex);
            this.form_mode = FORM_MODE_LIST.EDIT;
            this.ResetControlState();
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
            this.form_mode = FORM_MODE_LIST.READ;
            this.ResetControlState();
            this.btnRefresh.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE_LIST.ADD)
            {
                if(this.temp_shift.shift.name.Trim().Length == 0)
                {
                    MessageBox.Show("กรุณาป้อนชื่อผลัด");

                    //this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_name"].Selected = true;
                    //Console.WriteLine(" .. >>>> temp_shift.id = " + this.temp_shift.id);
                    //this.dgv.CurrentCell = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells["col_id"].Value == this.temp_shift.id).First().Cells["col_desc"];
                    return;
                }

                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.shift.Add(this.temp_shift.shift);
                        db.SaveChanges();
                        this.RemoveInlineControl();
                        this.form_mode = FORM_MODE_LIST.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                        this.btnAdd.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }

            if(this.form_mode == FORM_MODE_LIST.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        shift shift = db.shift.Find(this.temp_shift.id);
                        if(shift == null)
                        {
                            MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        shift.name = this.temp_shift.shift.name;
                        shift.starttime = this.temp_shift.shift.starttime;
                        shift.endtime = this.temp_shift.shift.endtime;
                        shift.description = this.temp_shift.shift.description;
                        shift.remark = this.temp_shift.shift.remark;
                        db.SaveChanges();
                        this.RemoveInlineControl();
                        this.form_mode = FORM_MODE_LIST.READ;
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

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
            int col_index = ((XDatagrid)sender).HitTest(e.X, e.Y).ColumnIndex;

            if (row_index == -1 && e.Button == MouseButtons.Left && this.form_mode == FORM_MODE_LIST.READ)
            {
                ((XDatagrid)sender).SortByColumn<shiftVM>(col_index);
            }

            if (this.form_mode == FORM_MODE_LIST.READ && e.Button == MouseButtons.Right && row_index > -1)
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

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            Console.WriteLine(" .. >>> current_cell changed");
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if(((XDatagrid)sender).Tag != null && (((XDatagrid)sender).Tag.GetType() == typeof(InlineControlGridPosition))) // If (XDatagrid)sender.Tag storing a details of inline control
            {
                if(((InlineControlGridPosition)((XDatagrid)sender).Tag).RowIndex == ((XDatagrid)sender).CurrentCell.RowIndex) // If current cell changed in same row
                {
                    this.RemoveInlineControl();
                    this.ShowInlineControl((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).CurrentCell.ColumnIndex);
                }
                else // If current cell changed in another row
                {
                    this.btnSave.PerformClick();
                    //this.RemoveInlineControl();
                    //this.ShowInlineControl((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).CurrentCell.ColumnIndex);
                }
            }
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            this.inline_control.SetInlineControlPosition((XDatagrid)sender);
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

            if(keyData == Keys.Enter)
            {

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

        private void dgv_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            Console.WriteLine("... >> row validating");
            //if (((string)((XDatagrid)sender).Rows[e.RowIndex].Cells["col_name"].Value).Trim().Length == 0)
            //    e.Cancel = true;
            if (this.form_mode == FORM_MODE_LIST.ADD || this.form_mode == FORM_MODE_LIST.EDIT)
                e.Cancel = true;
        }
    }
}
