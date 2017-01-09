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
    public partial class FormTank : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<tankVM> tank_list;
        private FORM_MODE form_mode;
        private tankVM temp_tank; // model for add/edit tank
        private XTextBox inline_name; // inline control for name
        private XTextBox inline_desc; // inline control for description
        private XComboBox inline_isactive; // inline control for isactive

        public FormTank()
        {
            InitializeComponent();
        }

        public FormTank(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void TankForm_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.bs.DataSource = this.tank_list;
            this.dgv.DataSource = this.bs;

            this.tank_list = this.GetTankList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.tank_list;
        }

        public List<tank> GetTankList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.tank.ToList();
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

            if (this.temp_tank == null)
                return;

            int col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index;
            this.inline_name = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_tank.tank, "name");
            this.inline_name.MaxLength = 20;
            this.inline_name.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index;
            this.inline_desc = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_tank.tank, "description");
            this.inline_desc.MaxLength = 50;
            this.inline_desc.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col__isactive.DataPropertyName).First().Index;
            this.inline_isactive = this.dgv.Rows[row_index].Cells[col_ndx].CreateXComboBoxTrueFalseEdit(this.temp_tank.tank, "isactive");
            this.inline_isactive.DropDownStyle = ComboBoxStyle.DropDownList;
            this.inline_isactive.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            if (this.form_mode == FORM_MODE.ADD)
                this.dgv.Parent.Controls.Add(this.inline_name);
            this.dgv.Parent.Controls.Add(this.inline_desc);
            this.dgv.Parent.Controls.Add(this.inline_isactive);
            this.inline_name.BringToFront();
            this.inline_desc.BringToFront();
            this.inline_isactive.BringToFront();
            if (this.form_mode == FORM_MODE.ADD)
            {
                this.inline_name.Focus();
            }
            else
            {
                this.inline_desc.Focus();
            }
        }

        private void RemoveInlineControl()
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

            if (this.inline_isactive != null)
            {
                this.inline_isactive.Dispose();
                this.inline_isactive = null;
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
            this.temp_tank = new tank()
            {
                id = -1,
                name = string.Empty,
                description = string.Empty,
                isactive = true,
                remark = string.Empty,
            }.ToViewModel();

            this.tank_list.Add(this.temp_tank);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.tank_list;

            this.dgv.CurrentCell = this.dgv.Rows[this.tank_list.Count - 1].Cells["col_name"];
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.temp_tank = ((tank)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_tank"].Value).ToViewModel();
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
                        tank tank_to_delete = db.tank.Find(((tank)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_tank"].Value).id);

                        if(tank_to_delete == null)
                        {
                            MessageBox.Show(StringResource.Msg("0004"), "Message # 0004", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        db.tank.Remove(tank_to_delete);
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
                if(this.temp_tank.tank.name.Trim().Length == 0)
                {
                    MessageBox.Show("กรุณาป้อนรหัส");
                    this.inline_name.Focus();
                    return;
                }

                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.tank.Add(this.temp_tank.tank);
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
                            MessageBox.Show("รหัส \"" + this.temp_tank.tank.name + "\" มีอยู่แล้วในระบบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        tank tank = db.tank.Find(this.temp_tank.id);
                        if(tank == null)
                        {
                            MessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        tank.name = this.temp_tank.tank.name;
                        tank.description = this.temp_tank.tank.description;
                        tank.isactive = this.temp_tank.tank.isactive;
                        tank.remark = this.temp_tank.tank.remark;
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
            this.tank_list = this.GetTankList().ToViewModel();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.tank_list;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1 && e.Button == MouseButtons.Left)
            {
                ((XDatagrid)sender).SortByColumn<tankVM>(e.ColumnIndex);
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
                return;
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index)
            {
                this.inline_desc.Focus();
                return;
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col__isactive.DataPropertyName).First().Index)
            {
                this.inline_isactive.Focus();
                return;
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
            int col_index = ((XDatagrid)sender).HitTest(e.X, e.Y).ColumnIndex;

            if(e.Button == MouseButtons.Right && row_index > -1)
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
            this.inline_desc.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index);
            this.inline_isactive.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col__isactive.DataPropertyName).First().Index);
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

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT))
            {
                if (this.inline_isactive != null && this.inline_isactive.Focused)
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
