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
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogDayendEdit : Form
    {
        private MainForm main_form;
        private dayend curr_dayend;
        private daysttak tmp_sttak;
        private BindingSource bs;
        private FormDailyClose form_dailyclose;
        private FORM_MODE form_mode;

        public DialogDayendEdit(MainForm main_form, FormDailyClose form_dailyclose, dayend curr_dayend)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.form_dailyclose = form_dailyclose;
            this.curr_dayend = curr_dayend;

            DbfTable.Isinfo(this.main_form.working_express_db);
            DbfTable.Apmas(this.main_form.working_express_db);
            DbfTable.Aptrn(this.main_form.working_express_db);
        }

        private void DialogDayendEdit_Load(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.BackColor = MiscResource.WIND_BG;
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.FillForm();
            this.ActiveControl = this.dgv;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
            {
                if (XMessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            base.OnFormClosing(e);
        }

        private dayend GetDayEndData(dayend dayend)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                dayend de = db.dayend.Include("daysttak").Where(d => d.id == dayend.id).FirstOrDefault();

                if (de == null)
                {
                    XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return null;
                }
                else
                {
                    return de;
                }
            }
        }

        private void FillForm()
        {
            this.curr_dayend = this.GetDayEndData(this.curr_dayend);

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.curr_dayend.daysttak.ToViewModel(this.main_form.working_express_db).OrderBy(d => d.section_name);

            this.RefreshSummary();
        }

        private void RefreshSummary()
        {
            dayendVM vm = this.curr_dayend.ToViewModel(this.main_form.working_express_db);
            //this.curr_dayend.difqty = vm.GetDifQty();

            this.lblSaldat.Text = this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            this.lblStkcod.Text = this.curr_dayend.stkcod;
            this.lblStkdes.Text = vm.stkdes;
            this.lblEndbal.Text = string.Format("{0:#,#0.00}", vm.endbal);
            this.lblBegbal.Text = string.Format("{0:#,#0.00}", vm.begbal);
            this.lblRcvqty.Text = string.Format("{0:#,#0.00}", vm.rcvqty);
            this.lblSalqty.Text = string.Format("{0:#,#0.00}", vm.salqty);
            this.lblDother.Text = string.Format("{0:#,#0.00}", vm.dother);
            this.lblAccbal.Text = string.Format("{0:#,#0.00}", vm.accbal);
            this.lblDifqty.Text = string.Format("{0:#,#0.00}", vm.difqty);
            this.lblBegdif.Text = string.Format("{0:#,#0.00}", vm.begdif);
            this.lblTotalDif.Text = string.Format("{0:#,#0.00}", vm.begdif + vm.difqty);
        }

        private void ResetControlState()
        {
            this.inline_qty.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnOK.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnCancel.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
        }

        private void ShowInlineForm(int row_index)
        {
            if (this.dgv.CurrentCell == null)
                return;

            this.tmp_sttak = (daysttak)this.dgv.Rows[row_index].Cells[this.col_daysttak.Name].Value;

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_qty.DataPropertyName).First().Index;
            this.inline_qty.SetInlineControlPosition(this.dgv, row_index, col_index);
            this.inline_qty._Value = this.tmp_sttak.takqty;

            this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().DefaultCellStyle.Padding = new Padding(0, 0, 0, 50);

            this.inline_qty.Focus();
        }

        private void RemoveInlineForm()
        {
            this.inline_qty.SetBounds(-9999, 0, 0, 0);
            this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            this.tmp_sttak = null;
            this.dgv.Focus();
        }

        private void PerformEdit(object sender, EventArgs e)
        {

        }

        private void inline_qty__ValueChanged(object sender, EventArgs e)
        {
            if(this.tmp_sttak != null)
            {
                this.tmp_sttak.takqty = ((XNumEdit)sender)._Value;
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
                return;

            if(this.tmp_sttak != null)
            {
                if (this.SaveSttak(this.tmp_sttak))
                {
                    this.RemoveInlineForm();
                    this.ShowInlineForm(((XDatagrid)sender).CurrentCell.RowIndex);
                }
                else
                {
                    ((XDatagrid)sender).Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_sttak.id).First().Cells[this.col_section_name.Name].Selected = true;
                }
            }
        }

        private bool SaveSttak(daysttak sttak)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    var sttak_to_update = db.daysttak.Find(sttak.id);

                    if (sttak_to_update == null)
                    {
                        XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return false;
                    }

                    sttak_to_update.takqty = sttak.takqty;
                    //sttak_to_update.rcvqty = sttak.rcvqty;
                    sttak_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    sttak_to_update.chgtime = DateTime.Now;
                    db.SaveChanges();

                    dayend dayend_to_update = db.dayend.Find(sttak_to_update.dayend_id);
                    //dayend_to_update.rcvqty = dayend_to_update.ToViewModel(this.main_form.working_express_db).GetRcvQty();
                    //dayend_to_update.difqty = dayend_to_update.ToViewModel(this.main_form.working_express_db).GetDifQty();
                    dayend_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    dayend_to_update.chgtime = DateTime.Now;
                    db.SaveChanges();

                    this.main_form.islog.EditData(this.form_dailyclose.menu_id, "แก้ไขปริมาณน้ำมันที่ตรวจวัดได้ ในรายการปิดยอดขายประจำวันที่ " + this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " , รหัสสินค้า \"" + this.curr_dayend.stkcod + "\", เลขที่ถัง \"" + sttak_to_update.ToViewModel(this.main_form.working_express_db).section_name + "\"", this.curr_dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.curr_dayend.stkcod + "|" + sttak_to_update.ToViewModel(this.main_form.working_express_db).section_name, "daysttak", sttak_to_update.id).Save();

                    this.curr_dayend.daysttak.Where(d => d.id == this.tmp_sttak.id).First().takqty = this.tmp_sttak.takqty;
                    this.dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[this.col_id.Name].Value == this.tmp_sttak.id).First().Cells[this.col_qty.Name].Value = this.tmp_sttak.takqty;
                    this.RefreshSummary();
                    return true;
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return false;
                }
                
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_accbal.Name).First().Index)
                {
                    this.ShowDetailForm();
                }
                else
                {
                    if (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() == false)
                        return;

                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(e.RowIndex);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() == false)
                return;

            if (this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        dayend dayend_to_update = db.dayend.Find(this.curr_dayend.id);
                        if (dayend_to_update == null)
                        {
                            XMessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                            return;
                        }

                        //dayend_to_update.rcvqty = this.curr_dayend.rcvqty;
                        //dayend_to_update.salqty = this.curr_dayend.salqty;
                        //dayend_to_update.begbal = this.curr_dayend.begbal;
                        //dayend_to_update.begdif = this.curr_dayend.begdif;
                        //dayend_to_update.difqty = this.curr_dayend.difqty;
                        dayend_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                        dayend_to_update.chgtime = DateTime.Now;

                        db.SaveChanges();
                        this.main_form.islog.EditData(this.form_dailyclose.menu_id, "แก้ไขรายการปิดยอดขายประจำวันที่ " + dayend_to_update.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " , รหัสสินค้า \"" + dayend_to_update.stkcod + "\"", dayend_to_update.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + dayend_to_update.stkcod, "dayend", dayend_to_update.id).Save();

                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.RefreshSummary();
                    }
                    catch (Exception ex)
                    {
                        XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    }
                }

                return;
            }
            
            if(this.form_mode == FORM_MODE.EDIT_ITEM && this.tmp_sttak != null)
            {
                if (this.SaveSttak(this.tmp_sttak))
                {
                    this.RemoveInlineForm();
                    this.form_mode = FORM_MODE.READ;
                    this.ResetControlState();
                }
                else
                {
                    this.inline_qty.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.RemoveInlineForm();
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.FillForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.E))
            {
                if (this.form_mode != FORM_MODE.READ)
                    return true;

                if (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() == false)
                    return true;

                //if (this.dgv.CurrentCell == null)
                //{
                //    this.form_mode = FORM_MODE.EDIT;
                //    this.ResetControlState();
                //    return true;
                //}

                if(this.dgv.CurrentCell != null)
                {
                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(this.dgv.CurrentCell.RowIndex);
                    return true;
                }
            }

            if (keyData == (Keys.Control | Keys.E))
            {
                if (this.dgv.CurrentCell == null)
                    return false;

                if(this.form_mode == FORM_MODE.READ)
                {
                    this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_btn_rcvqty.Name].Selected = true;
                    this.ShowDetailForm();
                    //Point p = this.dgv.PointToScreen(this.dgv.CurrentCell.ContentBounds.Location);
                    //Rectangle rect = this.dgv.GetCellDisplayRectangle(this.dgv.CurrentCell.ColumnIndex, this.dgv.CurrentCell.RowIndex, true);
                    //DialogDayendItemEdit d = new DialogDayendItemEdit(this.main_form, this.form_dailyclose, (daysttak)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_daysttak.Name].Value);
                    //d.Width = this.col_section_name.Width + this.col_accbal.Width + rect.Width;
                    //Rectangle rect_dialog = new Rectangle(p.X + rect.X + rect.Width - d.Width, p.Y + rect.Y + rect.Height, d.Width, d.Height);
                    //d.SetBounds(rect_dialog.X, rect_dialog.Y, rect_dialog.Width, rect_dialog.Height);
                    //d.ShowDialog();
                    //this.curr_dayend = this.GetDayEndData(this.curr_dayend);
                    //this.FillForm();
                    //this.dgv.Focus();
                    return true;
                }
            }

            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.EDIT_ITEM && this.inline_qty._Focused)
                {
                    if (this.dgv.CurrentCell.RowIndex < this.dgv.Rows.Count - 1)
                    {
                        this.dgv.Rows[this.dgv.CurrentCell.RowIndex + 1].Cells[this.col_section_name.Name].Selected = true;
                    }
                    else if (this.dgv.CurrentCell.RowIndex == this.dgv.Rows.Count - 1)
                    {
                        this.SaveSttak(this.tmp_sttak);
                        this.RemoveInlineForm();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                    }
                    return true;
                }

                //if (this.form_mode == FORM_MODE.EDIT)
                //{
                //    if (this.numBegdif._Focused)
                //    {
                //        this.btnOK.PerformClick();
                //        return true;
                //    }

                //    SendKeys.Send("{TAB}");
                //    return true;
                //}
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                if(this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    this.btnCancel.PerformClick();
                    return true;
                }

                if(this.form_mode == FORM_MODE.READ)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return true;
                }
            }

            if(keyData == Keys.Tab)
            {
                if((this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM) && this.dgv.CurrentCell != null)
                {
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var daysttak = (daysttak)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_daysttak.Name].Value;
                        var data_info = db.daysttak.Find(daysttak.id);
                        var total_recs = db.daysttak.AsEnumerable().Count();

                        if (data_info == null)
                            return false;

                        DialogDataInfo info = new DialogDataInfo("Daysttak", data_info.id, total_recs, data_info.creby, data_info.cretime, data_info.chgby, data_info.chgtime);
                        info.ShowDialog();
                        return true;
                    }
                }
            }

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-2.3.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_accbal.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    e.Handled = true;
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    using (SolidBrush brush_bg = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor))
                    {
                        using (SolidBrush brush_fg = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor))
                        {
                            Rectangle rect = new Rectangle(e.CellBounds.X - 3, e.CellBounds.Y + 2, 6, e.CellBounds.Height - 3);
                            e.Graphics.FillRectangle(brush_bg, rect);
                            e.Graphics.DrawString(this.col_accbal.HeaderText, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, brush_fg, new RectangleF(e.CellBounds.X - this.col_rcvqty.Width, e.CellBounds.Y , e.CellBounds.Width + this.col_rcvqty.Width - 5, e.CellBounds.Height), new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                        }
                    }
                    e.Paint(e.CellBounds, DataGridViewPaintParts.None);
                    e.Handled = true;
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_qty.Name).First().Index)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Handled = true;
                }
            }

            if(e.RowIndex > -1)
            {
                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_qty.Name).First().Index)
                {
                    if ((decimal)((XDatagrid)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Handled = true;
                    }
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_accbal.Name).First().Index)
                {
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        if(this.curr_dayend.daysttak.ToViewModel(this.main_form.working_express_db).OrderBy(d => d.section_name).ToList()[e.RowIndex].rcvqty < 0)
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Red;
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                            e.Handled = true;
                        }
                    }
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    int img_width = XPump.Properties.Resources.edit_list_gray_16.Width;
                    int img_height = XPump.Properties.Resources.edit_list_gray_16.Height;

                    Rectangle rect = new Rectangle(e.CellBounds.X + (int)Math.Floor((decimal)((e.CellBounds.Width - img_width) / 2)), e.CellBounds.Y + (int)Math.Floor((decimal)((e.CellBounds.Height - img_height) / 2)), img_width, img_height);

                    if (this.form_mode == FORM_MODE.EDIT_ITEM)
                    {
                        e.Graphics.DrawImage(XPump.Properties.Resources.edit_list_gray_16, rect);
                    }
                    else
                    {
                        e.Graphics.DrawImage(XPump.Properties.Resources.edit_list_16, rect);
                    }

                    e.Handled = true;
                }
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
                    return;

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_section_name.Name].Selected = true;
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_detail = new MenuItem("ดู/แก้ไข รายละเอียด <Ctrl+E>");
                mnu_detail.Click += delegate
                {
                    this.ShowDetailForm();
                };
                cm.MenuItems.Add(mnu_detail);

                MenuItem mnu_edit = new MenuItem("แก้ไขปริมาณที่ตรวจวัด <Alt+E>");
                mnu_edit.Click += delegate
                {
                    if (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() != true)
                        return;

                    this.form_mode = FORM_MODE.EDIT_ITEM;
                    this.ResetControlState();
                    this.ShowInlineForm(row_index);
                };
                cm.MenuItems.Add(mnu_edit);
                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }

            if(e.Button == MouseButtons.Left)
            {
                if (this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
                    return;

                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;
                int col_index = ((XDatagrid)sender).HitTest(e.X, e.Y).ColumnIndex;

                if (row_index == -1)
                    return;

                if(col_index == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().Index)
                {
                    ((XDatagrid)sender).Rows[row_index].Cells[this.col_btn_rcvqty.Name].Selected = true;
                    this.ShowDetailForm();
                    //Point p = ((XDatagrid)sender).PointToScreen(((XDatagrid)sender).CurrentCell.ContentBounds.Location);
                    //Rectangle rect = ((XDatagrid)sender).GetCellDisplayRectangle(col_index, row_index, true);
                    //DialogDayendItemEdit d = new DialogDayendItemEdit(this.main_form, this.form_dailyclose, (daysttak)((XDatagrid)sender).Rows[row_index].Cells[this.col_daysttak.Name].Value);
                    //d.Width = this.col_section_name.Width + this.col_accbal.Width + rect.Width;
                    //Rectangle rect_dialog = new Rectangle(p.X + rect.X + rect.Width - d.Width, p.Y + rect.Y + rect.Height, d.Width, d.Height);
                    //d.SetBounds(rect_dialog.X, rect_dialog.Y, rect_dialog.Width, rect_dialog.Height);
                    //d.ShowDialog();
                    //this.curr_dayend = this.GetDayEndData(this.curr_dayend);
                    //this.FillForm();
                }
            }
        }

        private void dgv_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(this.form_mode == FORM_MODE.READ)
            {
                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().Index)
                {
                    e.ToolTipText = "ดู/แก้ไขรายละเอียด <Ctrl+E>";
                }
            }
        }
        
        private void ShowDetailForm()
        {
            if (this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.EDIT_ITEM)
                return;

            if (this.dgv.CurrentCell == null || this.dgv.CurrentCell.RowIndex == -1)
                return;

            //var col_btn_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_rcvqty.Name).First().Index;
            this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_btn_rcvqty.Name].Selected = true;
            Point p = this.dgv.PointToScreen(this.dgv.CurrentCell.ContentBounds.Location);
            Rectangle rect = this.dgv.GetCellDisplayRectangle(this.dgv.CurrentCell.ColumnIndex, this.dgv.CurrentCell.RowIndex, true);
            DialogDayendItemEdit d = new DialogDayendItemEdit(this.main_form, this.form_dailyclose, (daysttak)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_daysttak.Name].Value);
            d.Width = this.col_section_name.Width + this.col_accbal.Width + rect.Width;
            Rectangle rect_dialog = new Rectangle(p.X + rect.X + rect.Width - d.Width, p.Y + rect.Y + rect.Height, d.Width, d.Height);
            d.SetBounds(rect_dialog.X, rect_dialog.Y, rect_dialog.Width, rect_dialog.Height);
            d.ShowDialog();
            this.curr_dayend = this.GetDayEndData(this.curr_dayend);
            this.FillForm();
        }
    }
}
