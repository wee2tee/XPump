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
    public partial class FormApmas : Form
    {
        private MainForm main_form;
        private BindingSource bs;
        private List<apmas> apmas_list;
        private FORM_MODE form_mode;
        private apmas temp_apmas; // model for add/edit tank
        private XTextBox inline_supcod; // inline control for name
        private XTextBox inline_supnam; // inline control for description
        //private XComboBox inline_isactive; // inline control for isactive

        public FormApmas()
        {
            InitializeComponent();
        }

        public FormApmas(MainForm main_form)
            : this()
        {
            this.main_form = main_form;
        }

        private void FormApmas_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.bs.DataSource = this.apmas_list;
            this.dgv.DataSource = this.bs;

            this.apmas_list = this.GetApmasList();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.apmas_list;
        }

        public List<apmas> GetApmasList()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.apmas.ToList();
            }
        }

        public apmas GetApmasById(int id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.apmas.Find(id);
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

            if (this.temp_apmas == null)
                return;

            int col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_supcod.DataPropertyName).First().Index;
            this.inline_supcod = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_apmas, "supcod");
            this.inline_supcod.MaxLength = 20;
            this.inline_supcod.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_supnam.DataPropertyName).First().Index;
            this.inline_supnam = this.dgv.Rows[row_index].Cells[col_ndx].CreateXTextBoxEdit(this.temp_apmas, "supnam");
            this.inline_supnam.MaxLength = 100;
            this.inline_supnam.SetInlineControlPosition(this.dgv, row_index, col_ndx);

            if (this.form_mode == FORM_MODE.ADD)
                this.dgv.Parent.Controls.Add(this.inline_supcod);
            this.dgv.Parent.Controls.Add(this.inline_supnam);
            this.inline_supcod.BringToFront();
            this.inline_supnam.BringToFront();
            if (this.form_mode == FORM_MODE.ADD)
            {
                this.inline_supcod.Focus();
            }
            else
            {
                this.inline_supnam.Focus();
            }
        }

        private void RemoveInlineControl()
        {
            if(this.inline_supcod != null)
            {
                this.inline_supcod.Dispose();
                this.inline_supcod = null;
            }

            if(this.inline_supnam != null)
            {
                this.inline_supnam.Dispose();
                this.inline_supnam = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ)
            {
                if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
            this.temp_apmas = new apmas()
            {
                id = -1,
                supcod = string.Empty,
                supnam = string.Empty
            };

            this.apmas_list.Add(this.temp_apmas);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.apmas_list;

            this.dgv.CurrentCell = this.dgv.Rows[this.apmas_list.Count - 1].Cells["col_supcod"];
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.temp_apmas = this.GetApmasById((int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_id"].Value);
            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string supcod_to_delete = (string)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_supcod"].Value;

            if (MessageBox.Show("ลบรหัสผู้ค้าน้ำมัน \"" + supcod_to_delete + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        apmas apmas_to_delete = db.apmas.Find((int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_id"].Value);

                        db.apmas.Remove(apmas_to_delete);
                        db.SaveChanges();
                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รหัส", supcod_to_delete);
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
            this.temp_apmas = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                if(this.temp_apmas.supcod.Trim().Length == 0)
                {
                    MessageBox.Show("กรุณาป้อนรหัส");
                    this.inline_supcod.Focus();
                    return;
                }

                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.apmas.Add(this.temp_apmas);
                        db.SaveChanges();
                        this.RemoveInlineControl();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                        this.btnAdd.PerformClick();
                    }
                    catch (DbUpdateException ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_apmas.supcod);
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
                        apmas apmas = db.apmas.Find(this.temp_apmas.id);

                        apmas.supcod = this.temp_apmas.supcod;
                        apmas.supnam = this.temp_apmas.supnam;
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
            this.apmas_list = this.GetApmasList();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.apmas_list;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1 && e.Button == MouseButtons.Left)
            {
                ((XDatagrid)sender).SortByColumn<apmas>(e.ColumnIndex);
                return;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.btnEdit.PerformClick();
            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_supcod.DataPropertyName).First().Index)
            {
                this.inline_supcod.Focus();
                return;
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_supnam.DataPropertyName).First().Index)
            {
                this.inline_supnam.Focus();
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
            this.inline_supcod.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_supcod.DataPropertyName).First().Index);
            this.inline_supnam.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_supnam.DataPropertyName).First().Index);
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
                if (this.inline_supnam != null && this.inline_supnam.Focused)
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
