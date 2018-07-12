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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogNozzle : Form
    {
        private string menu_id;
        private MainForm main_form;
        private FormTankConfig form_tankconfig;
        //private tank tank;
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

        public DialogNozzle(MainForm main_form, FormTankConfig form_tanksetup, section section_object)
        {
            InitializeComponent();
            this.menu_id = this.GetType().Name;
            this.main_form = main_form;
            this.section = section_object;
            this.form_tankconfig = form_tanksetup;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.form_mode != FORM_MODE.READ_ITEM)
            {
                if(XMessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();

            using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
            {
                this.section = db.section.Find(this.section.id);
                if (this.section == null)
                {
                    XMessageBox.Show("ไม่สามารถค้นหาช่องเก็บน้ำมันที่ต้องการแก้ไข, อาจมีผู้ใช้รายอื่นลบไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                this.lblSection.Text = this.section.name;

                this.lblTank.Text = db.tank.Find(this.section.tank_id) != null ? db.tank.Find(this.section.tank_id).name : string.Empty;

                this.lblStkdes.Text = this.section.stkcod + " / " + this.section.stkdes;

                this.list_nozzle = this.GetNozzleList();

                this.bs = new BindingSource();
                this.bs.DataSource = this.list_nozzle.ToViewModel(this.main_form.working_express_db);
                this.dgv.DataSource = this.bs;
            }
            this.ActiveControl = this.dgv;
        }

        public List<nozzle> GetNozzleList()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
            {
                return db.nozzle.Where(n => n.section_id == this.section.id).ToList();
            }
        }

        private void ResetControlState()
        {
            string ac_edit = null;
            if (this.main_form.loged_in_status.is_secure)
            {
                if(this.form_tankconfig.scacclv != null)
                {
                    ac_edit = this.form_tankconfig.scacclv.edit;
                }
                else
                {
                    ac_edit = "N";
                }
            }

            this.btnAddItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnEditItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnDeleteItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode, ac_edit);
            this.btnSaveItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode, ac_edit);
            this.btnStopItem.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode, ac_edit);
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
                section_id = this.section.id,
                creby = this.main_form.loged_in_status.loged_in_user_name,
            };
            this.list_nozzle.Add(this.temp_nozzle);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.list_nozzle.ToViewModel(this.main_form.working_express_db);

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

            if (XMessageBox.Show("ลบรหัสหัวจ่าย \"" + tmp.name + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                return;

            try
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
                {
                    var nozzle_to_delete = db.nozzle.Find(tmp.id);
                    db.nozzle.Remove(nozzle_to_delete);
                    db.SaveChanges();

                    this.main_form.islog.DeleteData(this.menu_id, "ลบรหัสหัวจ่ายน้ำมัน \"" + nozzle_to_delete.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.form_tankconfig.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), nozzle_to_delete.name, "nozzle", nozzle_to_delete.id).Save();

                    this.list_nozzle = this.GetNozzleList();
                    this.bs.ResetBindings(true);
                    this.bs.DataSource = this.list_nozzle.ToViewModel(this.main_form.working_express_db);
                    if (this.form_tankconfig != null)
                    {
                        //this.form_tankconfig.RefreshDgvSection();
                    }
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
            this.bs.DataSource = this.list_nozzle.ToViewModel(this.main_form.working_express_db);
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
                using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
                {
                    try
                    {
                        if(db.nozzle.Include("section").Where(n => n.section.tank.tanksetup_id == this.section.tank.tanksetup_id && n.name == this.temp_nozzle.name).ToList().Count > 0)
                        {
                            XMessageBox.Show("เลขที่หัวจ่ายซ้ำ กรุณาเปลี่ยนใหม่", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            this.inline_name.Focus();
                            return;
                        }

                        this.temp_nozzle.cretime = DateTime.Now;
                        db.nozzle.Add(this.temp_nozzle);
                        db.SaveChanges();

                        this.main_form.islog.AddData(this.menu_id, "เพิ่มรหัสหัวจ่ายน้ำมัน \"" + this.temp_nozzle.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.form_tankconfig.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.temp_nozzle.name, "nozzle", this.temp_nozzle.id).Save();

                        this.list_nozzle = this.GetNozzleList();
                        this.bs.ResetBindings(true);
                        this.bs.DataSource = this.list_nozzle.ToViewModel(this.main_form.working_express_db);
                        if (this.form_tankconfig != null)
                        {
                            //this.form_tankconfig.RefreshDgvSection();
                        }

                        this.btnStopItem.PerformClick();
                        this.btnAddItem.PerformClick();
                    }
                    catch(Exception ex)
                    {
                        ex.ShowMessage("รหัส", this.temp_nozzle.name, "รหัสช่องเก็บน้ำมัน", this.section.name);
                    }
                }

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
                {
                    try
                    {
                        nozzle nozzle_to_update = db.nozzle.Find(this.temp_nozzle.id);

                        if (nozzle_to_update == null)
                        {
                            XMessageBox.Show(StringResource.Msg("0002"), "Message # 0002", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            return;
                        }

                        nozzle_to_update.name = this.temp_nozzle.name;
                        nozzle_to_update.description = this.temp_nozzle.description;
                        nozzle_to_update.isactive = this.temp_nozzle.isactive;
                        nozzle_to_update.remark = this.temp_nozzle.remark;
                        nozzle_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        nozzle_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();

                        this.main_form.islog.EditData(this.menu_id, "แก้ไขรายละเอียดหัวจ่ายน้ำมัน \"" + this.temp_nozzle.name + "\" ในการตั้งค่าแท๊งค์วันที่ " + this.form_tankconfig.tanksetup.startdate.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.temp_nozzle.name, "nozzle", this.temp_nozzle.id).Save();

                        this.list_nozzle = this.GetNozzleList();
                        this.bs.ResetBindings(true);
                        this.bs.DataSource = this.list_nozzle.ToViewModel(this.main_form.working_express_db);

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

            if(keyData == Keys.Tab)
            {
                if (!(this.form_mode == FORM_MODE.READ_ITEM && this.dgv.CurrentCell != null))
                    return false;

                using (xpumpEntities db = DBX.DataSet(this.main_form.db_conn_config))
                {
                    int noz_id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_id.Name].Value;
                    var tmp = db.nozzle.Find(noz_id);
                    var total_recs = db.nozzle.AsEnumerable().Count();
                    DialogDataInfo info = new DialogDataInfo("Nozzle", tmp.id, total_recs, tmp.creby, tmp.cretime, tmp.chgby, tmp.chgtime);
                    info.ShowDialog();
                    return true;
                }
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-1.3.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

            if(e.Button == MouseButtons.Right/* && row_index > -1*/)
            {
                if(row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells["col_name"].Selected = true;
                
                ContextMenu cm = new ContextMenu();

                MenuItem mnu_add = new MenuItem();
                mnu_add.Text = "เพิ่ม <Alt+A>";
                mnu_add.Click += delegate
                {
                    this.btnAddItem.PerformClick();
                };
                mnu_add.Enabled = this.btnAddItem.Enabled;
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem();
                mnu_edit.Text = "แก้ไข <Alt+E>";
                mnu_edit.Click += delegate
                {
                    this.btnEditItem.PerformClick();
                };
                mnu_edit.Enabled = row_index < 0 ? false : this.btnEditItem.Enabled;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem();
                mnu_delete.Text = "ลบ <Alt+D>";
                mnu_delete.Click += delegate
                {
                    this.btnDeleteItem.PerformClick();
                };
                mnu_delete.Enabled = row_index < 0 ? false : this.btnDeleteItem.Enabled;
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
