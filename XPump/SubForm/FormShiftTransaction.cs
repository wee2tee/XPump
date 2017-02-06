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
    public partial class FormShiftTransaction : Form
    {
        private MainForm main_form;
        private shiftsales curr_shiftsales;
        private shiftsales tmp_shiftsales;
        private List<salessummaryVM> sales_list;
        public salessummary curr_salessummary;
        private BindingSource bs;
        private FORM_MODE form_mode;

        public FormShiftTransaction(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormShiftTransaction_Load(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.btnLast.PerformClick();
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.brShift.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtSaldat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dgv.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.inline_btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.inline_btnSaleshistory.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.panel2.Refresh();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
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

        public shiftsales GetShiftSales(int id)
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shiftsales.Include("salessummary").Include("shift").Where(s => s.id == id).FirstOrDefault();
            }
        }

        private shiftsales GetFirst()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shiftsales.Include("salessummary").Include("shift").OrderBy(s => s.saldat).ThenBy(s => s.id).FirstOrDefault();
            }
        }

        private shiftsales GetPrevious()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (db.shiftsales.Count() == 0)
                    return null;


                if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return this.GetFirst();


                var id_list = db.shiftsales.OrderBy(s => s.saldat).ThenBy(s => s.id).Select(s => s.id).ToList<int>();

                if (id_list.IndexOf(this.curr_shiftsales.id) == -1)
                {
                    shiftsales tmp = db.shiftsales.Include("salessummary").Include("shift").OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).Where(s => this.curr_shiftsales.saldat.CompareTo(s.saldat) == 0 || this.curr_shiftsales.saldat.CompareTo(s.saldat) > 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        return tmp;
                    }
                    else
                    {
                        return this.GetFirst();
                    }
                }

                if (id_list.IndexOf(this.curr_shiftsales.id) == 0)
                {
                    return this.GetShiftSales(this.curr_shiftsales.id);
                }

                if (id_list.IndexOf(this.curr_shiftsales.id) > 0)
                {
                    int target_index = id_list.IndexOf(this.curr_shiftsales.id) - 1;
                    return this.GetShiftSales(id_list[target_index]);
                }

                return null;
            }
        }

        private shiftsales GetNext()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                if (db.shiftsales.Count() == 0)
                    return null;

                if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return this.GetLast();

                var id_list = db.shiftsales.OrderBy(s => s.saldat).ThenBy(s => s.id).Select(s => s.id).ToList<int>();

                if (id_list.IndexOf(this.curr_shiftsales.id) == -1)
                {
                    shiftsales tmp = db.shiftsales.Include("salessummary").Include("shift").OrderBy(s => s.saldat).ThenBy(s => s.id).Where(s => this.curr_shiftsales.saldat.CompareTo(s.saldat) == 0 || this.curr_shiftsales.saldat.CompareTo(s.saldat) < 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        return tmp;
                    }
                    else
                    {
                        return this.GetLast();
                    }
                }
                
                if (id_list.IndexOf(this.curr_shiftsales.id) == id_list.Count - 1)
                {
                    return this.GetShiftSales(this.curr_shiftsales.id);
                }

                if (id_list.IndexOf(this.curr_shiftsales.id) < id_list.Count - 1)
                {
                    int target_index = id_list.IndexOf(this.curr_shiftsales.id) + 1;
                    return this.GetShiftSales(id_list[target_index]);
                }
            }

            return null;
        }

        private shiftsales GetLast()
        {
            using (xpumpEntities db = DBX.DataSet())
            {
                return db.shiftsales.Include("salessummary").Include("shift").OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).FirstOrDefault();
            }
        }

        private void FillForm(shiftsales shift_sales = null)
        {
            shiftsales sales = shift_sales != null ? shift_sales : this.curr_shiftsales;
            this.curr_salessummary = null;

            if(sales == null)
            {
                this.brShift._Text = string.Empty;
                this.dtSaldat._SelectedDate = null;
                this.dgv.Rows.Clear();
                return;
            }

            using (xpumpEntities db = DBX.DataSet())
            {
                this.brShift._Text = db.shift.Find(sales.shift_id) != null ? db.shift.Find(sales.shift_id).name : string.Empty;
            }
            this.dtSaldat._SelectedDate = sales.saldat;
            this.sales_list = sales.salessummary.ToViewModel().OrderBy(s => s.stkcod).ToList();
            this.bs.ResetBindings(true);
            this.bs.DataSource = this.sales_list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tmp_shiftsales = new shiftsales
            {
                id = -1,
                saldat = DateTime.Now,
                shift_id = -1
            };

            this.FillForm(this.tmp_shiftsales);

            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();
            this.toolStrip1.Focus();
            this.dtSaldat.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            this.tmp_shiftsales = this.GetShiftSales(this.curr_shiftsales.id);
            this.FillForm(this.tmp_shiftsales);

            this.form_mode = FORM_MODE.EDIT;
            this.ResetControlState();
            this.toolStrip1.Focus();
            this.dtSaldat.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            if(MessageBox.Show("ลบบันทึกรายการขายประจำผลัด \"" + this.curr_shiftsales.shift.name + "\" วันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + ", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        foreach (var s in db.salessummary.Where(ss => ss.shiftsales_id == this.curr_shiftsales.id).ToList())
                        {
                            int sales_summary_id = s.id;
                            foreach (var item in db.saleshistory.Where(sh => sh.salessummary_id == sales_summary_id))
                            {
                                db.saleshistory.Remove(item);
                            }
                            int pricelist_id = s.pricelist_id;
                            db.salessummary.Remove(s);
                            db.pricelist.Remove(db.pricelist.Find(pricelist_id));
                        }

                        db.shiftsales.Remove(db.shiftsales.Find(this.curr_shiftsales.id));
                        db.SaveChanges();

                        this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowMessage("รายการนี้ ", "");
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.FillForm();
            this.tmp_shiftsales = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                DialogPrice price = new DialogPrice(this.main_form);
                if (price.ShowDialog() != DialogResult.OK)
                    return;

                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        db.shiftsales.Add(this.tmp_shiftsales);
                        foreach (stmas s in db.stmas.ToList())
                        {
                            var x = new salessummary
                            {
                                saldat = this.tmp_shiftsales.saldat,
                                dtest = 0m,
                                dother = 0m,
                                dothertxt = string.Empty,
                                ddisc = 0m,
                                purvat = 0m,
                                shift_id = this.tmp_shiftsales.shift_id,
                                stmas_id = s.id,
                                pricelist_id = price.price_list.Where(p => p.stmas_id == s.id).FirstOrDefault() != null ? price.price_list.Where(p => p.stmas_id == s.id).First().id : -1,
                                shiftsales_id = this.tmp_shiftsales.id
                            };
                            db.salessummary.Add(x);
                        }

                        db.SaveChanges();
                        this.curr_shiftsales = this.GetShiftSales(this.tmp_shiftsales.id);
                        this.FillForm();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.dgv_SelectionChanged(this.dgv, new EventArgs());
                        this.dgv.Focus();
                        this.tmp_shiftsales = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
                        shiftsales shiftsales_to_update = db.shiftsales.Find(this.tmp_shiftsales.id);
                        if(shiftsales_to_update == null)
                        {
                            MessageBox.Show("ค้นหารายการเพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        shiftsales_to_update.saldat = this.tmp_shiftsales.saldat;
                        shiftsales_to_update.shift_id = this.tmp_shiftsales.shift_id;
                        db.SaveChanges();

                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.tmp_shiftsales = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                return;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetFirst();
            this.FillForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetPrevious();
            this.FillForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetNext();
            this.FillForm();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.curr_shiftsales = this.GetLast();
            this.FillForm();
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {

        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {

        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.dgv.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            shiftsales tmp = this.GetShiftSales(this.curr_shiftsales.id);
            if(tmp != null)
            {
                this.curr_shiftsales = tmp;
                this.FillForm();
                return;
            }
            else
            {
                this.btnNext.PerformClick();
            }
        }

        private void dtSaldat__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_shiftsales != null)
                this.tmp_shiftsales.saldat = ((XDatePicker)sender)._SelectedDate.HasValue ? ((XDatePicker)sender)._SelectedDate.Value : DateTime.Now;
        }

        private void dtSaldat__Leave(object sender, EventArgs e)
        {
            if (!((XDatePicker)sender)._SelectedDate.HasValue)
            {
                ((XDatePicker)sender)._SelectedDate = DateTime.Now;
            }
        }

        private void brShift__ButtonClick(object sender, EventArgs e)
        {
            if (this.tmp_shiftsales != null)
            {
                DialogShiftSelector sel = new DialogShiftSelector(this.tmp_shiftsales.shift_id);
                Point p = ((XBrowseBox)sender).PointToScreen(Point.Empty);
                sel.SetBounds(p.X + ((XBrowseBox)sender).Width, p.Y, sel.Width, sel.Height);
                if (sel.ShowDialog() == DialogResult.OK)
                {
                    ((XBrowseBox)sender)._Text = sel.selected_shift.name;
                    this.tmp_shiftsales.shift_id = sel.selected_shift.id;
                    ((XBrowseBox)sender).Focus();
                }
            }
        }

        private void brShift__Leave(object sender, EventArgs e)
        {
            if(((XBrowseBox)sender)._Text.Trim().Length == 0)
            {
                if (this.tmp_shiftsales != null)
                    this.tmp_shiftsales.shift_id = -1;

                ((XBrowseBox)sender).Focus();
            }
            else
            {
                string txt = ((XBrowseBox)sender)._Text;

                shift shift = DialogShiftSelector.GetShiftList().Where(s => s.name == txt).FirstOrDefault();
                if(shift != null)
                {
                    if (this.tmp_shiftsales != null)
                        this.tmp_shiftsales.shift_id = shift.id;
                }
                else
                {
                    if (this.tmp_shiftsales != null)
                        this.tmp_shiftsales.shift_id = -1;

                    ((XBrowseBox)sender).Focus();
                    ((XBrowseBox)sender).PerformButtonClick();
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (this.form_mode == FORM_MODE.READ_ITEM || this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                using (Pen p0 = new Pen(Color.LimeGreen))
                {
                    using (Pen p = new Pen(Color.PaleGreen))
                    {
                        e.Graphics.DrawRectangle(p0, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                        e.Graphics.DrawRectangle(p, e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 3, e.ClipRectangle.Height - 3);
                    }
                }
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.READ_ITEM)
            {
                if (((XDatagrid)sender).CurrentCell == null)
                {
                    this.inline_btnEdit.Visible = false;
                    this.inline_btnSaleshistory.Visible = false;
                    return;
                }

                this.curr_salessummary = (salessummary)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells["col_salessummary"].Value;
                this.SetInlineBtnPosition();
                this.inline_btnEdit.Visible = true;
                this.inline_btnSaleshistory.Visible = true;
            }
            else
            {
                this.inline_btnEdit.Visible = false;
                this.inline_btnSaleshistory.Visible = false;
            }
        }

        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
            if (!this.inline_btnEdit.Visible)
                return;

            this.SetInlineBtnPosition();
        }

        private void SetInlineBtnPosition()
        {
            if (this.dgv.CurrentCell == null)
                return;

            int col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index;
            int row_index = this.dgv.CurrentCell.RowIndex;

            Rectangle rect = this.dgv.GetCellDisplayRectangle(col_index, row_index, true);
            this.inline_btnEdit.SetBounds(rect.X, rect.Y + 1, this.inline_btnEdit.Width, rect.Height - 3);

            col_index = this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_totqty.DataPropertyName).First().Index;

            rect = this.dgv.GetCellDisplayRectangle(col_index, row_index, true);
            this.inline_btnSaleshistory.SetBounds(rect.X, rect.Y + 1, this.inline_btnSaleshistory.Width, rect.Height - 3);
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            if (this.inline_btnEdit.Visible || this.inline_btnSaleshistory.Visible)
            {
                this.SetInlineBtnPosition();
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_stkcod.Name].Selected = true;
            this.dgv_SelectionChanged((XDatagrid)sender, new EventArgs());

            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index)
            {
                this.inline_btnEdit.PerformClick();
                return;
            }
            else
            {
                this.inline_btnSaleshistory.PerformClick();
                return;
            }

        }

        private void inline_btnSaleshistory_Click(object sender, EventArgs e)
        {
            if (this.curr_salessummary == null)
                return;

            if(this.form_mode != FORM_MODE.READ_ITEM)
            {
                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();
            }

            using (xpumpEntities db = DBX.DataSet())
            {
                var sections = db.section.Include("tank").Include("nozzle")
                    .Where(s => s.stmas_id == this.curr_salessummary.stmas_id)
                    .Where(s => s.tank.startdate.CompareTo(this.curr_salessummary.saldat) <= 0)
                    .Where(s => s.tank.isactive)
                    .Where(s => !s.tank.enddate.HasValue || s.tank.enddate.Value.CompareTo(this.curr_salessummary.saldat) >= 0).ToList();

                foreach (section sec in sections)
                {
                    foreach (nozzle noz in sec.nozzle.Where(n => n.isactive))
                    {
                        try
                        {
                            var tmp = db.saleshistory.Where(s => s.saldat == this.curr_salessummary.saldat)
                                        .Where(s => s.shift_id == this.curr_salessummary.shift_id)
                                        .Where(s => s.nozzle_id == noz.id)
                                        .Where(s => s.stmas_id == this.curr_salessummary.stmas_id).FirstOrDefault();

                            if (tmp != null)
                                continue;

                            db.saleshistory.Add(new saleshistory
                            {
                                saldat = this.curr_salessummary.saldat,
                                mitbeg = 0m,
                                mitend = 0m,
                                salqty = 0m,
                                salval = 0m,
                                shift_id = this.curr_salessummary.shift_id,
                                nozzle_id = noz.id,
                                stmas_id = this.curr_salessummary.stmas_id,
                                pricelist_id = this.curr_salessummary.pricelist_id,
                                salessummary_id = this.curr_salessummary.id
                            });
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }

            DialogSalesHistory sh = new DialogSalesHistory(this.curr_salessummary);
            sh.ShowDialog();
        }

        private void inline_unitpr_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentCell == null)
                return;

            if (this.form_mode != FORM_MODE.READ_ITEM)
            {
                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();
            }

            int pricelist_id = (int)this.dgv.Rows[this.dgv.CurrentCell.RowIndex].Cells[this.col_pricelist_id.Name].Value;
            Rectangle rect = this.dgv.GetCellDisplayRectangle(this.dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index, this.dgv.CurrentCell.RowIndex, false);

            DialogEditPrice pr = new DialogEditPrice(pricelist_id, new Size(rect.Width + 4, rect.Height), new Point(this.dgv.PointToScreen(Point.Empty).X + rect.X - 2, this.dgv.PointToScreen(Point.Empty).Y + rect.Y - 2), this.curr_salessummary.ToViewModel().unitpr);
            if (pr.ShowDialog() == DialogResult.OK)
            {
                this.curr_shiftsales = this.GetShiftSales(this.curr_shiftsales.id);
                this.FillForm();
            }
            this.dgv.Focus();
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM))
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_stkcod.Name].Selected = true;
                this.dgv_SelectionChanged((XDatagrid)sender, new EventArgs());
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_sales = new MenuItem();
                mnu_sales.Text = "บันทึกปริมาณการขาย <Ctrl+Space>";
                mnu_sales.Click += delegate
                {
                    this.inline_btnSaleshistory.PerformClick();
                    return;
                };
                cm.MenuItems.Add(mnu_sales);

                MenuItem mnu_price = new MenuItem();
                mnu_price.Text = "แก้ไขราคาขาย <Alt+E>";
                mnu_price.Click += delegate
                {
                    this.inline_btnEdit.PerformClick();
                    return;
                };
                cm.MenuItems.Add(mnu_price);

                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }
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
                if(this.form_mode == FORM_MODE.READ)
                {
                    this.btnEdit.PerformClick();
                    return true;
                }

                if (this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.inline_btnEdit.PerformClick();
                    return true;
                }
            }

            if(keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Space) && this.dgv.Focused && this.inline_btnEdit.Visible)
            {
                this.inline_btnSaleshistory.PerformClick();
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

            if(keyData == Keys.PageUp)
            {
                this.btnPrevious.PerformClick();
                return true;
            }

            if(keyData == Keys.PageDown)
            {
                this.btnNext.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.L))
            {
                this.btnInquiryAll.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.L))
            {
                this.btnInquiryRest.PerformClick();
                return true;
            }

            if(keyData == Keys.F8)
            {
                this.btnItem.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PerformEdit(object sender, EventArgs e)
        {
            this.btnEdit.PerformClick();

            ((Control)sender).Focus();
        }
    }
}
