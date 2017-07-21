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
    public partial class FormSecure : Form
    {
        private MainForm main_form;
        private List<ScuserDbf> scusers;
        private ScuserDbf curr_user;
        private scacclvVM tmp_scacclv;
        private BindingList<scacclvVM> bl_scacclv = new BindingList<scacclvVM>();
        private List<scmodul> scmodul_list;
        private List<SccompDbf> sccomp_list;
        private FORM_MODE form_mode;

        public FormSecure(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormSecure_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.dgv.Dock = DockStyle.Fill;
            this.btnFirst.PerformClick();
            this.dgv.DataSource = this.bl_scacclv;
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                this.scmodul_list = sec.scmodul.ToList();
            }
            this.sccomp_list = DbfTable.Sccomp().ToSccompList();

            this.ResetFormState(FORM_MODE.READ);
            this.RemoveInlineForm();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM, FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            this.btnAddItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnEditItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDeleteItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ_ITEM }, this.form_mode);

            this.dgv.TabStop = this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM ? false : true;
        }

        private void FillForm()
        {
            if(this.curr_user != null)
            {
                this.txtUserId.Text = this.curr_user.reccod.Trim();
                this.txtUserName.Text = this.curr_user.recdes.Trim();
                this.txtGroup.Text = this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).FirstOrDefault() != null ? this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).First().reccod.Trim() : string.Empty;
                this.lblUserGroup.Text = this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).FirstOrDefault() != null ? this.scusers.Where(s => s.rectyp.Trim() == "G" && s.reccod.Trim() == this.curr_user.connectgrp.Trim()).First().recdes.Trim() : string.Empty;
                this.txtLevel.Text = this.curr_user.authlev.ToString();
                this.txtSecure.Text = this.curr_user.secure == "1" ? "ตรวจสอบสิทธิก่อนใช้งาน" : "ไม่ตรวจสอบสิทธิ";
                this.txtLanguage.Text = this.curr_user.language == "E" ? "English" : "ไทย";
                switch (this.curr_user.status.Trim())
                {
                    case "":
                        this.txtStatus.Text = "ปกติ";
                        break;
                    case "S":
                        this.txtStatus.Text = "ตรวจสอบเข้มงวด";
                        break;
                    case "X":
                        this.txtStatus.Text = "ห้ามใช้";
                        break;
                    default:
                        this.txtStatus.Text = "";
                        break;
                }
                this.dgv.DataSource = this.bl_scacclv;
            }
            else
            {
                this.txtUserId.Text = string.Empty;
                this.txtUserName.Text = string.Empty;
                this.txtGroup.Text = string.Empty;
                this.lblUserGroup.Text = string.Empty;
                this.txtLevel.Text = string.Empty;
                this.txtSecure.Text = string.Empty;
                this.txtLanguage.Text = string.Empty;
                this.txtStatus.Text = string.Empty;
            }
        }

        private void ShowInlineForm()
        {
            //this.tmp_scacclv = (scacclv)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_scacclv.Name].Value;
            this.SetInlineControlPosition();

            List<XDropdownList> dl = new List<XDropdownList>
            {
                this.inline_read,
                this.inline_add,
                this.inline_edit,
                this.inline_delete,
                this.inline_print,
                this.inline_approve
            };

            foreach (var item in dl)
            {
                item._Items.Clear();
                item._Items.Add(new XDropdownListItem { Text = "Y", Value = "Y" });
                item._Items.Add(new XDropdownListItem { Text = "N", Value = "N" });
            }
        }

        private void SetInlineControlPosition()
        {
            if (!(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM))
                return;

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_datacod.Name).First().Index;
            this.inline_datacod.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_modcod.Name).First().Index;
            this.inline_menu.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_read.Name).First().Index;
            this.inline_read.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_add.Name).First().Index;
            this.inline_add.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_edit.Name).First().Index;
            this.inline_edit.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_delete.Name).First().Index;
            this.inline_delete.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_print.Name).First().Index;
            this.inline_print.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_approve.Name).First().Index;
            this.inline_approve.SetInlineControlPosition(this.dgv, this.dgv.CurrentCell.RowIndex, col_index);
        }

        private void RemoveInlineForm()
        {
            this.inline_datacod.SetBounds(-9999, 0, 0, 0);
            this.inline_datacod._Text = string.Empty;
            this.inline_menu.SetBounds(-9999, 0, 0, 0);
            this.inline_menu._Text = string.Empty;
            this.inline_read.SetBounds(-9999, 0, 0, 0);
            this.inline_read._Text = string.Empty;
            this.inline_add.SetBounds(-9999, 0, 0, 0);
            this.inline_add._Text = string.Empty;
            this.inline_edit.SetBounds(-9999, 0, 0, 0);
            this.inline_edit._Text = string.Empty;
            this.inline_delete.SetBounds(-9999, 0, 0, 0);
            this.inline_delete._Text = string.Empty;
            this.inline_print.SetBounds(-9999, 0, 0, 0);
            this.inline_print._Text = string.Empty;
            this.inline_approve.SetBounds(-9999, 0, 0, 0);
            this.inline_approve._Text = string.Empty;

            this.tmp_scacclv = null;
        }

        private List<scacclv> GetScacclv(ScuserDbf scuser)
        {
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                if (scuser == null)
                    return new List<scacclv>();

                var scacclv = sec.scacclv.Where(s => s.username == scuser.reccod.Trim()).ToList();
                return scacclv;
            }
        }

        private ScuserDbf GetScuser(string user_name)
        {
            return DbfTable.Scuser().ToScuserList().Where(s => s.reccod.Trim() == user_name && s.rectyp == "U").FirstOrDefault();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U").OrderBy(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.First();
                this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
            }
            else
            {
                this.curr_user = null;
                this.bl_scacclv = new BindingList<scacclvVM>();
            }

            this.FillForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.curr_user == null)
                return;

            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U" && s.reccod.Trim().CompareTo(this.curr_user.reccod.Trim()) < 0).OrderByDescending(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.First();
                this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
                this.FillForm();
            }
            else
            {
                this.btnFirst.PerformClick();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.curr_user == null)
                return;

            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U" && s.reccod.Trim().CompareTo(this.curr_user.reccod.Trim()) > 0).OrderBy(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.First();
                this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
                this.FillForm();
            }
            else
            {
                this.btnLast.PerformClick();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.scusers = DbfTable.Scuser().ToScuserList();
            var sc = this.scusers.Where(s => s.rectyp == "U").OrderBy(s => s.reccod.Trim()).ToList();
            if (sc.Count > 0)
            {
                this.curr_user = sc.Last();
                this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
            }
            else
            {
                this.curr_user = null;
                this.bl_scacclv = new BindingList<scacclvVM>();
            }

            this.FillForm();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            this.tmp_scacclv = new scacclv { id = -1, username = this.curr_user.reccod.Trim(), datacod = string.Empty, scmodul_id = -1, read = string.Empty, add = string.Empty, edit = string.Empty, delete = string.Empty, print = string.Empty, approve = string.Empty }.ToViewModel();
            this.bl_scacclv.Add(this.tmp_scacclv);
            
            var added_row = this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_scacclv.id).FirstOrDefault();
            if(added_row != null)
            {
                this.ResetFormState(FORM_MODE.ADD_ITEM);
                added_row.Cells[this.col_datacod.Name].Selected = true;
                this.ShowInlineForm();
                this.inline_datacod.Focus();
            }
            else
            {
                return;
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            scacclv s = (scacclv)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_scacclv.Name].Value;
            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                try
                {
                    var scacclv_to_delete = sec.scacclv.Find(s.id);
                    if(scacclv_to_delete != null)
                    {
                        XMessageBox.Show("ข้อมูลที่ต้องการลบไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    }
                    else
                    {
                        sec.scacclv.Remove(scacclv_to_delete);
                        sec.SaveChanges();
                        this.bl_scacclv.Remove(this.bl_scacclv.Where(sc => sc.id == scacclv_to_delete.id).FirstOrDefault());
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index > -1)
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_datacod.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem("เพิ่ม <Alt + A>");
                mnu_add.Click += delegate
                {
                    this.btnAddItem.PerformClick();
                };
                cm.MenuItems.Add(mnu_add);

                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt + E>");
                mnu_edit.Click += delegate
                {
                    this.btnEditItem.PerformClick();
                };
                mnu_edit.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_edit);

                MenuItem mnu_delete = new MenuItem("ลบ <Alt + D>");
                mnu_delete.Click += delegate
                {
                    this.btnDeleteItem.PerformClick();
                };
                mnu_delete.Enabled = row_index == -1 ? false : true;
                cm.MenuItems.Add(mnu_delete);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            this.SetInlineControlPosition();
        }

        private void inline_datacod__ButtonClick(object sender, EventArgs e)
        {
            List<dynamic> list = this.sccomp_list.Select(c => new { compnam = c.compnam, compcod = c.compcod, path = c.path }).ToList<dynamic>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "compnam",
                    Name = "col_compnam",
                    HeaderText = "ชื่อข้อมูล",
                    MinimumWidth = 180,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "compcod",
                    Name = "col_compcod",
                    HeaderText = "รหัส",
                    Width = 120,
                    MinimumWidth = 120
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "path",
                    Name = "col_path",
                    HeaderText = "ที่เก็บข้อมูล",
                    MinimumWidth = 180,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                }

            };

            DialogInquiry inq = new DialogInquiry(list, cols, cols.Where(c => c.DataPropertyName == "compcod").First(), ((XBrowseBox)sender)._Text);
            Point p = ((XBrowseBox)sender).PointToScreen(Point.Empty);
            inq.StartPosition = FormStartPosition.Manual;
            inq.SetBounds(p.X + ((XBrowseBox)sender).Width, p.Y, inq.Width, inq.Height);
            if(inq.ShowDialog() == DialogResult.OK)
            {
                ((XBrowseBox)sender)._Text = (string)inq.selected_row.Cells[cols.Where(c => c.DataPropertyName == "compcod").First().Name].Value;
            }
        }

        private void inline_menu__ButtonClick(object sender, EventArgs e)
        {
            List<dynamic> list = this.scmodul_list.ToList<dynamic>();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "id",
                    Name = "col_id",
                    Visible = false
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "modcod",
                    Name = "col_modcod",
                    HeaderText = "รหัสเมนู",
                    MinimumWidth = 100,
                    Width = 100
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "p_modcod",
                    Name = "col_p_modcod",
                    HeaderText = "Parent Module Code",
                    Visible = false
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "description",
                    Name = "col_desc",
                    HeaderText = "รายละเอียด",
                    MinimumWidth = 220,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "scacclv",
                    Name = "col_scacclv",
                    Visible = false
                }
            };

            DialogInquiry inq = new DialogInquiry(list, cols, cols.Where(c => c.DataPropertyName == "modcod").First(), ((XBrowseBox)sender)._Text);
            Point p = ((XBrowseBox)sender).PointToScreen(Point.Empty);
            inq.StartPosition = FormStartPosition.Manual;
            inq.SetBounds(p.X + ((XBrowseBox)sender).Width, p.Y, inq.Width, inq.Height);
            if (inq.ShowDialog() == DialogResult.OK)
            {
                ((XBrowseBox)sender)._Text = (string)inq.selected_row.Cells[cols.Where(c => c.DataPropertyName == "modcod").First().Name].Value;
            }
        }

        private void inline_datacod__Leave(object sender, EventArgs e)
        {
            if (this.tmp_scacclv == null)
                return;

            var selected_data = this.sccomp_list.Where(s => s.compcod.Trim() == ((XBrowseBox)sender)._Text).FirstOrDefault();

            if(selected_data != null)
            {
                this.tmp_scacclv.scacclv.datacod = selected_data.compcod;
            }
            else
            {
                this.tmp_scacclv.scacclv.datacod = string.Empty;
            }

            this.bl_scacclv.ResetItem(this.bl_scacclv.IndexOf(this.bl_scacclv.Where(b => b.id == this.tmp_scacclv.id).First()));
            ((XBrowseBox)sender)._Text = this.bl_scacclv[this.bl_scacclv.IndexOf(this.bl_scacclv.Where(b => b.id == this.tmp_scacclv.id).First())].datacod;

            if(this.tmp_scacclv.datacod.Trim().Length == 0)
            {
                ((XBrowseBox)sender).Focus();
                SendKeys.Send("{F6}");
            }
        }

        private void inline_menu__Leave(object sender, EventArgs e)
        {
            if (this.tmp_scacclv == null)
                return;

            var selected_menu = this.scmodul_list.Where(s => s.modcod == ((XBrowseBox)sender)._Text).FirstOrDefault();

            if(selected_menu != null)
            {
                this.tmp_scacclv.scacclv.scmodul_id = selected_menu.id;
            }
            else
            {
                this.tmp_scacclv.scacclv.scmodul_id = -1;
            }
            this.bl_scacclv.ResetItem(this.bl_scacclv.IndexOf(this.bl_scacclv.Where(b => b.id == this.tmp_scacclv.id).First()));
            ((XBrowseBox)sender)._Text = this.bl_scacclv[this.bl_scacclv.IndexOf(this.bl_scacclv.Where(b => b.id == this.tmp_scacclv.id).First())].modcod;

            if(this.tmp_scacclv.scmodul_id == -1)
            {
                ((XBrowseBox)sender).Focus();
                SendKeys.Send("{F6}");
            }
        }

        private void inline_dropdownlist_Enter(object sender, EventArgs e)
        {
            //SendKeys.Send("{F6}");
            //((XDropdownList)sender).comboBox1.DroppedDown = true;
        }

        private void inline_read__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_scacclv != null)
                this.tmp_scacclv.scacclv.read = ((XDropdownList)sender)._Text;
        }

        private void inline_add__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_scacclv != null)
                this.tmp_scacclv.scacclv.add = ((XDropdownList)sender)._Text;
        }

        private void inline_edit__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_scacclv != null)
                this.tmp_scacclv.scacclv.edit = ((XDropdownList)sender)._Text;
        }

        private void inline_delete__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_scacclv != null)
                this.tmp_scacclv.scacclv.delete = ((XDropdownList)sender)._Text;
        }

        private void inline_print__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_scacclv != null)
                this.tmp_scacclv.scacclv.print = ((XDropdownList)sender)._Text;
        }

        private void inline_approve__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_scacclv != null)
                this.tmp_scacclv.scacclv.approve = ((XDropdownList)sender)._Text;
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.ResetFormState(FORM_MODE.READ_ITEM);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                this.RemoveInlineForm();
                this.bl_scacclv.Remove(this.bl_scacclv.Where(s => s.id == -1).FirstOrDefault());
                this.ResetFormState(FORM_MODE.READ_ITEM);
                return;
            }
            if(this.form_mode == FORM_MODE.READ_ITEM)
            {
                this.ResetFormState(FORM_MODE.READ);
                this.toolStrip1.Focus();
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tmp_scacclv == null)
                return;

            using (xpumpsecureEntities sec = DBX.DataSecureSet())
            {
                try
                {
                    sec.scacclv.Add(this.tmp_scacclv.scacclv);
                    sec.SaveChanges();
                    //this.ReloadCurrentScuser();
                    //this.btnStop.PerformClick();
                    this.RemoveInlineForm();
                    this.ResetFormState(FORM_MODE.READ_ITEM);
                    this.btnAddItem.PerformClick();
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "col_reccod",
                    DataPropertyName = "reccod",
                    HeaderText = "รหัสผู้ใช้",
                    Width = 120,
                    MinimumWidth = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "col_recdes",
                    DataPropertyName = "recdes",
                    HeaderText = "รายละเอียด",
                    MinimumWidth = 250,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                }
            };

            var scusers = DbfTable.Scuser().ToScuserList().Where(s => s.rectyp == "U").Select(s => new { reccod = s.reccod.Trim(), recdes = s.recdes.Trim() }).ToList<dynamic>();
            DialogInquiry inq = new DialogInquiry(scusers, cols, cols.Where(c => c.DataPropertyName == "reccod").First());
            if(inq.ShowDialog() == DialogResult.OK)
            {
                var selected_user_name = (string)inq.selected_row.Cells[cols.Where(c => c.DataPropertyName == "reccod").First().Name].Value;
                var user = this.GetScuser(selected_user_name);
                if (user == null)
                    return;

                this.curr_user = user;
                this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
                this.FillForm();
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "col_reccod",
                    DataPropertyName = "reccod",
                    HeaderText = "รหัสผู้ใช้",
                    Width = 120,
                    MinimumWidth = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "col_recdes",
                    DataPropertyName = "recdes",
                    HeaderText = "รายละเอียด",
                    MinimumWidth = 250,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                }
            };

            var scusers = DbfTable.Scuser().ToScuserList().Where(s => s.rectyp == "U").Select(s => new { reccod = s.reccod.Trim(), recdes = s.recdes.Trim() }).ToList<dynamic>();
            string current_usr_name = this.curr_user != null ? this.curr_user.reccod : string.Empty;
            DialogInquiry inq = new DialogInquiry(scusers, cols, cols.Where(c => c.DataPropertyName == "reccod").First(), current_usr_name);
            if (inq.ShowDialog() == DialogResult.OK)
            {
                var selected_user_name = (string)inq.selected_row.Cells[cols.Where(c => c.DataPropertyName == "reccod").First().Name].Value;
                var user = this.GetScuser(selected_user_name);
                if (user == null)
                    return;

                this.curr_user = user;
                this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
                this.FillForm();
            }
        }

        private void ReloadCurrentScuser()
        {
            if (this.curr_user != null)
            {
                this.curr_user = this.GetScuser(this.curr_user.reccod.Trim());
                if (this.curr_user != null)
                {
                    this.bl_scacclv = new BindingList<scacclvVM>(this.GetScacclv(this.curr_user).ToViewModel());
                    this.FillForm();
                }
                else
                {
                    this.btnNext.PerformClick();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadCurrentScuser();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if(keyData == Keys.Tab)
            //{
            //    Console.WriteLine(" ==> " + this.ActiveControl.Name + " is focused.");
            //}

            if (keyData == Keys.F8)
            {
                this.btnItem.PerformClick();
                return true;
            }

            if (keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                if (!(this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM))
                    return false;

                if (this.inline_approve._Focused)
                {
                    this.btnSave.PerformClick();
                    return true;
                }
                else
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            if (keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
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

            if (keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.L))
            {
                this.btnInquiryAll.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.L))
            {
                this.btnInquiryRest.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.A))
            {
                this.btnAddItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                this.btnEditItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDeleteItem.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
