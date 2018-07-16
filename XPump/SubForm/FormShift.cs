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
        public const string modcod = "24";
        private MainForm main_form;
        private scacclvVM scacclv;
        private BindingSource bs;
        private List<shiftVM> shift_list;
        private shift curr_shift; // current focused row
        private FORM_MODE form_mode;
        private shiftVM temp_shift; // model for add/edit shift

        public FormShift()
        {
            InitializeComponent();
        }

        public FormShift(MainForm main_form, scacclvVM scacclv)
            : this()
        {
            this.main_form = main_form;
            this.scacclv = scacclv;
        }

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            //this.menu_id = this.GetType().Name;
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.bs.DataSource = this.shift_list;
            this.dgv.DataSource = this.bs;

            this.shift_list = this.GetShiftList().ToViewModel(this.main_form.working_express_db);
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;
            this.ActiveControl = this.dgv;
            this.ResetControlState();
        }

        public List<shift> GetShiftList()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.shift.Include("shiftsales").OrderBy(s => s.seq).ToList();
            }
        }

        private void ResetControlState()
        {
            string ac_add = null;
            string ac_edit = null;
            string ac_delete = null;
            if (this.main_form.loged_in_status.is_secure)
            {
                if(this.scacclv != null)
                {
                    ac_add = this.scacclv.add;
                    ac_edit = this.scacclv.edit;
                    ac_delete = this.scacclv.delete;
                }
                else
                {
                    ac_add = "N";
                    ac_edit = "N";
                    ac_delete = "N";
                }
            }

            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_add);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_edit);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode, ac_delete);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnUp.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDown.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            if(this.form_mode == FORM_MODE.READ)
            {
                if (this.shift_list == null || this.shift_list.Count == 0)
                {
                    this.btnEdit.Enabled = false;
                    this.btnDelete.Enabled = false;
                }
            }

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

            DataTable dt = DbfTable.Isrun(this.main_form.working_express_db);
            if(dt == null)
            {
                this.btnStop.PerformClick();
                return;
            }

            List<IsrunDbfVM> isrun = dt.ToIsrunList().ToViewModel(); //ToList<IsrunDbf>().ToViewModel();

            int col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index;
            this.inline_name.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_name._Text = this.temp_shift.name;
            this.inline_name.Visible = this.form_mode == FORM_MODE.ADD ? true : false;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().Index;
            this.inline_start.Text = this.temp_shift.starttime.ToString(@"hh\:mm\:ss");
            this.inline_start.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_start.Visible = true;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().Index;
            this.inline_end.Text = this.temp_shift.endtime.ToString(@"hh\:mm\:ss");
            this.inline_end.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_end.Visible = true;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index;
            this.inline_desc._Text = this.temp_shift.description;
            this.inline_desc.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_desc.Visible = true;

            //col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_paeprefix.DataPropertyName).First().Index;
            //this.inline_pae.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            //this.inline_pae._Items.Clear();
            //foreach (var item in isrun.Where(i => i.doctyp == "AE").ToList())
            //{
            //    this.inline_pae._Items.Add(new XDropdownListItem { Text = item.prefix, Value = item.prefix });
            //}
            //this.inline_pae._Text = this.temp_shift.paeprefix; 
            //this.inline_pae.Visible = true;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_phpprefix.DataPropertyName).First().Index;
            this.inline_php.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_php._Items.Clear();
            foreach (var item in isrun.Where(i => i.doctyp == "HP").ToList())
            {
                this.inline_php._Items.Add(new XDropdownListItem { Text = item.prefix, Value = item.prefix });
            }
            this.inline_php._Text = this.temp_shift.phpprefix;
            this.inline_php.Visible = true;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_prrprefix.DataPropertyName).First().Index;
            this.inline_prr.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_prr._Items.Clear();
            foreach (var item in isrun.Where(i => i.doctyp == "RR").ToList())
            {
                this.inline_prr._Items.Add(new XDropdownListItem { Text = item.prefix, Value = item.prefix });
            }
            this.inline_prr._Text = this.temp_shift.prrprefix;
            this.inline_prr.Visible = true;

            //col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_saiprefix.DataPropertyName).First().Index;
            //this.inline_sai.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            //this.inline_sai._Items.Clear();
            //foreach (var item in isrun.Where(i => i.doctyp == "AI").ToList())
            //{
            //    this.inline_sai._Items.Add(new XDropdownListItem { Text = item.prefix, Value = item.prefix });
            //}
            //this.inline_sai._Text = this.temp_shift.saiprefix;
            //this.inline_sai.Visible = true;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shsprefix.DataPropertyName).First().Index;
            this.inline_shs.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_shs._Items.Clear();
            foreach (var item in isrun.Where(i => i.doctyp == "HS").ToList())
            {
                this.inline_shs._Items.Add(new XDropdownListItem { Text = item.prefix, Value = item.prefix });
            }
            this.inline_shs._Text = this.temp_shift.shsprefix;
            this.inline_shs.Visible = true;

            col_ndx = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sivprefix.DataPropertyName).First().Index;
            this.inline_siv.SetInlineControlPosition(this.dgv, row_index, col_ndx);
            this.inline_siv._Items.Clear();
            foreach (var item in isrun.Where(i => i.doctyp == "IV").ToList())
            {
                this.inline_siv._Items.Add(new XDropdownListItem { Text = item.prefix, Value = item.prefix });
            }
            this.inline_siv._Text = this.temp_shift.sivprefix;
            this.inline_siv.Visible = true;

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
            this.inline_name.Visible = false;
            this.inline_start.Visible = false;
            this.inline_end.Visible = false;
            this.inline_desc.Visible = false;
            this.inline_pae.Visible = false;
            this.inline_php.Visible = false;
            this.inline_prr.Visible = false;
            this.inline_sai.Visible = false;
            this.inline_shs.Visible = false;
            this.inline_siv.Visible = false;
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if(this.form_mode != FORM_MODE.READ)
        //    {
        //        if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }
        //    this.RemoveInlineControl();
        //    this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
        //    base.OnFormClosing(e);
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
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
                paeprefix = string.Empty,
                phpprefix = string.Empty,
                prrprefix = string.Empty,
                saiprefix = string.Empty,
                shsprefix = string.Empty,
                sivprefix = string.Empty
            }.ToViewModel(this.main_form.working_express_db);

            this.shift_list.Add(this.temp_shift);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;

            this.dgv.CurrentCell = this.dgv.Rows[this.shift_list.Count - 1].Cells[this.col_name.Name];
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.temp_shift = ((shift)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_shift"].Value).ToViewModel(this.main_form.working_express_db);
            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.ShowInlineControl(this.dgv.CurrentCell.RowIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.curr_shift == null)
                return;

            if(XMessageBox.Show("ลบ \"" + this.curr_shift.name + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        //shift shift_to_delete = db.shift.Find(((shift)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells["col_shift"].Value).id);

                        //if(shift_to_delete == null)
                        //{
                        //    MessageBox.Show(StringResource.Msg("0004"), "Message # 0004", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //    return;
                        //}

                        //db.shift.Remove(shift_to_delete);
                        db.shift.Remove(db.shift.Find(this.curr_shift.id));
                        db.SaveChanges();
                        this.main_form.islog.DeleteData(modcod, "ลบผลัดพนักงาน \"" + this.curr_shift.name + "\"", this.curr_shift.name, "shift", this.curr_shift.id).Save();

                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("", this.curr_shift.name);
                        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (this.temp_shift.shift.name.Trim().Length == 0)
                {
                    XMessageBox.Show("กรุณาระบุชื่อผลัด");

                    this.inline_name.Focus();
                    return;
                }

                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        var tmp = db.shift.OrderByDescending(s => s.seq).FirstOrDefault();
                        if(tmp == null)
                        {
                            this.temp_shift.shift.seq = 1;
                        }
                        else
                        {
                            this.temp_shift.shift.seq = tmp.seq + 1;
                        }
                        this.temp_shift.shift.creby = this.main_form.loged_in_status.loged_in_user_name;
                        this.temp_shift.shift.cretime = DateTime.Now;
                        db.shift.Add(this.temp_shift.shift);
                        db.SaveChanges();

                        this.main_form.islog.AddData(modcod, "เพิ่มผลัดพนักงาน \"" + this.temp_shift.name + "\"", this.temp_shift.name, "shift", this.temp_shift.id).Save();

                        this.RemoveInlineControl();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                        this.btnAdd.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("ชื่อผลัด", this.temp_shift.shift.name);
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
                        shift shift = db.shift.Find(this.temp_shift.id);
                        if (shift == null)
                        {
                            XMessageBox.Show("ค้นหา \"" + this.temp_shift.name + "\" เพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            return;
                        }
                        shift.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        shift.chgtime = DateTime.Now;
                        shift.name = this.temp_shift.shift.name;
                        shift.starttime = this.temp_shift.shift.starttime;
                        shift.endtime = this.temp_shift.shift.endtime;
                        shift.description = this.temp_shift.shift.description;
                        shift.remark = this.temp_shift.shift.remark;
                        shift.paeprefix = this.temp_shift.shift.paeprefix;
                        shift.phpprefix = this.temp_shift.shift.phpprefix;
                        shift.prrprefix = this.temp_shift.shift.prrprefix;
                        shift.saiprefix = this.temp_shift.shift.saiprefix;
                        shift.shsprefix = this.temp_shift.shift.shsprefix;
                        shift.sivprefix = this.temp_shift.shift.sivprefix;
                        db.SaveChanges();

                        this.main_form.islog.EditData(modcod, "แก้ไขผลัดพนักงาน \"" + this.temp_shift.name + "\"", this.temp_shift.name, "shift", this.temp_shift.id).Save();

                        this.RemoveInlineControl();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    }
                }
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.shift_list = this.GetShiftList().ToViewModel(this.main_form.working_express_db);
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.shift_list;
            this.ResetControlState();
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex == -1 && e.Button == MouseButtons.Left/* && this.form_mode == FORM_MODE_LIST.READ*/)
            //{
            //    //((XDatagrid)sender).SortByColumn<shiftVM>(e.ColumnIndex);
            //    return;
            //}
            //else
            //{
            //    ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_name.Name].Selected = true;
            //    this.curr_shift = (shift)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_shift.Name].Value;
            //}
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
            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_paeprefix.DataPropertyName).First().Index)
            {
                this.inline_pae.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_phpprefix.DataPropertyName).First().Index)
            {
                this.inline_php.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_prrprefix.DataPropertyName).First().Index)
            {
                this.inline_prr.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_saiprefix.DataPropertyName).First().Index)
            {
                this.inline_sai.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shsprefix.DataPropertyName).First().Index)
            {
                this.inline_shs.Focus();
            }
            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sivprefix.DataPropertyName).First().Index)
            {
                this.inline_siv.Focus();
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
            int col_index = ((XDatagrid)sender).HitTest(e.X, e.Y).ColumnIndex;

            if (e.Button == MouseButtons.Right/* && row_index > -1*/)
            {
                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[col_index].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม <Alt+A>");
                mnu_add.Click += delegate
                {
                    this.btnAdd.PerformClick();
                };
                mnu_add.Enabled = this.btnAdd.Enabled;
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : this.btnEdit.Enabled;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ <Alt+D>");
                mnu_delete.Click += delegate
                {
                    this.btnDelete.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : this.btnDelete.Enabled;
                cm.MenuItems.Add(mnu_delete);

                //MenuItem mnu_up = new MenuItem("เลื่อนขึ้น");
                //mnu_up.Click += delegate
                //{
                //    this.btnUp.PerformClick();
                //};
                //cm.MenuItems.Add(mnu_up);

                //MenuItem mnu_down = new MenuItem("เลื่อนลง");
                //mnu_down.Click += delegate
                //{
                //    this.btnDown.PerformClick();
                //};
                //cm.MenuItems.Add(mnu_down);

                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_seq.DataPropertyName).First().DisplayIndex = 0;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().DisplayIndex = 1;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().DisplayIndex = 2;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().DisplayIndex = 3;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().DisplayIndex = 4;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_paeprefix.DataPropertyName).First().DisplayIndex = 5;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_phpprefix.DataPropertyName).First().DisplayIndex = 6;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_prrprefix.DataPropertyName).First().DisplayIndex = 7;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_saiprefix.DataPropertyName).First().DisplayIndex = 8;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shsprefix.DataPropertyName).First().DisplayIndex = 9;
            ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sivprefix.DataPropertyName).First().DisplayIndex = 10;
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.inline_name.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index);
            this.inline_start.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().Index);
            this.inline_end.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().Index);
            this.inline_desc.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index);
            this.inline_php.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_phpprefix.DataPropertyName).First().Index);
            this.inline_prr.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_prrprefix.DataPropertyName).First().Index);
            this.inline_shs.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shsprefix.DataPropertyName).First().Index);
            this.inline_siv.SetInlineControlPosition((XDatagrid)sender, ((XDatagrid)sender).CurrentCell.RowIndex, ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sivprefix.DataPropertyName).First().Index);
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
                if((this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT))
                {
                    if (this.inline_siv._Focused)
                    {
                        this.btnSave.PerformClick();
                        return true;
                    }

                    SendKeys.Send("{TAB}");
                    return true;
                }

                if(this.form_mode == FORM_MODE.READ && this.dgv.Focused)
                {
                    return true;
                }
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

            if(keyData == Keys.Tab)
            {
                if (this.form_mode != FORM_MODE.READ)
                    return false;

                if (this.dgv.CurrentCell == null)
                    return false;

                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    int id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value;

                    var shift = db.shift.Find(id);
                    var total_recs = db.shift.AsEnumerable().Count();

                    if(shift != null)
                    {
                        DialogDataInfo info = new DialogDataInfo("Shift", shift.id, total_recs, shift.creby, shift.cretime, shift.chgby, shift.chgtime);
                        info.ShowDialog();
                        return true;
                    }
                }
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.4.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_seq.DataPropertyName).First().Index)
                {
                    string content = this.col_seq.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_name.DataPropertyName).First().Index)
                {
                    string content = this.col_name.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_start.DataPropertyName).First().Index)
                {
                    string content = this.col_start.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_end.DataPropertyName).First().Index)
                {
                    string content = this.col_end.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
                
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_desc.DataPropertyName).First().Index)
                {
                    string content = this.col_desc.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_paeprefix.DataPropertyName).First().Index)
                {
                    string content = this.col_paeprefix.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_phpprefix.DataPropertyName).First().Index)
                {
                    string content = this.col_phpprefix.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_prrprefix.DataPropertyName).First().Index)
                {
                    string content = this.col_prrprefix.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);

                    Rectangle rect = new Rectangle(e.CellBounds.X /*- this.col_paeprefix.Width*/ - this.col_phpprefix.Width + 1, e.CellBounds.Y + 2, /*this.col_paeprefix.Width +*/ this.col_phpprefix.Width + this.col_prrprefix.Width - 2, 20);
                    e.Graphics.FillRectangle(new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor), rect);

                    e.Graphics.DrawLine(new Pen(Color.Gray), e.CellBounds.X /*- this.col_paeprefix.Width*/ - this.col_phpprefix.Width, e.CellBounds.Y + 20, e.CellBounds.X + this.col_prrprefix.Width, e.CellBounds.Y + 20);

                    TextRenderer.DrawText(e.Graphics, "เอกสารด้านซื้อ", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_saiprefix.DataPropertyName).First().Index)
                {
                    string content = this.col_saiprefix.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_shsprefix.DataPropertyName).First().Index)
                {
                    string content = this.col_shsprefix.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_sivprefix.DataPropertyName).First().Index)
                {
                    string content = this.col_sivprefix.HeaderText;
                    TextRenderer.DrawText(e.Graphics, content, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, e.CellBounds, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);

                    Rectangle rect = new Rectangle(e.CellBounds.X /*- this.col_saiprefix.Width*/ - this.col_shsprefix.Width + 1, e.CellBounds.Y + 2, /*this.col_saiprefix.Width +*/ this.col_shsprefix.Width + this.col_sivprefix.Width - 2, 20);
                    e.Graphics.FillRectangle(new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor), rect);

                    e.Graphics.DrawLine(new Pen(Color.Gray), e.CellBounds.X - /*this.col_saiprefix.Width -*/ this.col_shsprefix.Width, e.CellBounds.Y + 20, e.CellBounds.X + this.col_sivprefix.Width, e.CellBounds.Y + 20);

                    TextRenderer.DrawText(e.Graphics, "เอกสารด้านขาย", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, Color.Black, TextFormatFlags.NoClipping | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true;
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            this.curr_shift = (shift)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_shift.Name].Value;

            int col_index = ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_seq.DataPropertyName).First().Index;
            Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(col_index, ((XDatagrid)sender).CurrentCell.RowIndex, false);
            this.btnUp.SetBounds(rect.X + rect.Width - this.btnUp.Width - this.btnDown.Width - 1, rect.Y + 2, this.btnUp.Width, this.btnUp.Height);
            this.btnDown.SetBounds(rect.X + rect.Width - this.btnDown.Width - 1, rect.Y + 2, this.btnDown.Width, this.btnDown.Height);
        }

        private void inline_name__TextChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
                this.temp_shift.shift.name = ((XTextEdit)sender)._Text;
        }

        private void inline_start_ValueChanged(object sender, EventArgs e)
        {
            if(this.temp_shift != null)
            {
                string str_time = ((XTimePicker)sender).Value.ToString("HH") + ":" + ((XTimePicker)sender).Value.ToString("mm") + ":" + ((XTimePicker)sender).Value.ToString("ss");
                this.temp_shift.shift.starttime = TimeSpan.Parse(str_time);
            }
        }

        private void inline_end_ValueChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
            {
                string str_time = ((XTimePicker)sender).Value.ToString("HH") + ":" + ((XTimePicker)sender).Value.ToString("mm") + ":" + ((XTimePicker)sender).Value.ToString("ss");
                this.temp_shift.shift.endtime = TimeSpan.Parse(str_time);
            }
        }

        private void inline_desc__TextChanged(object sender, EventArgs e)
        {
            if(this.temp_shift != null)
            {
                this.temp_shift.shift.description = ((XTextEdit)sender)._Text;
            }
        }

        private void inline_pae__SelectedItemChanged(object sender, EventArgs e)
        {
            if(this.temp_shift != null)
            {
                this.temp_shift.shift.paeprefix = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            }
        }

        private void inline_php__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
            {
                this.temp_shift.shift.phpprefix = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            }
        }

        private void inline_prr__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
            {
                this.temp_shift.shift.prrprefix = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            }
        }

        private void inline_sai__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
            {
                this.temp_shift.shift.saiprefix = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            }
        }

        private void inline_shs__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
            {
                this.temp_shift.shift.shsprefix = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            }
        }

        private void inline_siv__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.temp_shift != null)
            {
                this.temp_shift.shift.sivprefix = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            }
        }

        private void inline_name__Leave(object sender, EventArgs e)
        {
            if(this.temp_shift != null)
            {
                if(this.temp_shift.shift.name.Trim().Length == 0)
                {
                    this.inline_name.Focus();
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int curr_id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    shift curr_shift = db.shift.Find(curr_id);
                    if (curr_shift == null)
                    {
                        XMessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }
                    int curr_seq = curr_shift.seq;

                    shift prev_shift = db.shift.OrderByDescending(s => s.seq).Where(s => s.seq < curr_shift.seq).FirstOrDefault();

                    if (prev_shift == null)
                        return;
                    int prev_seq = prev_shift.seq;

                    curr_shift.seq = prev_seq;
                    prev_shift.seq = curr_seq;

                    db.SaveChanges();

                    this.shift_list = this.GetShiftList().ToViewModel(this.main_form.working_express_db);
                    this.bs.ResetBindings(true);
                    this.bs.DataSource = this.shift_list;
                    this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == curr_shift.id).First().Cells[this.col_seq.Name].Selected = true;
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int curr_id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value;
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    shift curr_shift = db.shift.Find(curr_id);
                    if (curr_shift == null)
                    {
                        XMessageBox.Show("ข้อมูลที่ต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }
                    int curr_seq = curr_shift.seq;

                    shift next_shift = db.shift.OrderBy(s => s.seq).Where(s => s.seq > curr_shift.seq).FirstOrDefault();

                    if (next_shift == null)
                        return;
                    int next_seq = next_shift.seq;

                    curr_shift.seq = next_seq;
                    next_shift.seq = curr_seq;

                    db.SaveChanges();

                    this.shift_list = this.GetShiftList().ToViewModel(this.main_form.working_express_db);
                    this.bs.ResetBindings(true);
                    this.bs.DataSource = this.shift_list;
                    this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == curr_shift.id).First().Cells[this.col_seq.Name].Selected = true;
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }
    }
}
