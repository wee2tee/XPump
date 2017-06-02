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
using System.Drawing.Printing;

namespace XPump.SubForm
{
    public partial class FormDailyClose : Form
    {
        private MainForm main_form;
        private FORM_MODE form_mode;
        private BindingSource bs;
        private List<dayend> dayend_list;
        private DateTime? curr_date;
        private dayend curr_dayend;
        public string menu_id;

        public FormDailyClose(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    if (this.form_mode != FORM_MODE.READ && this.form_mode != FORM_MODE.READ_ITEM)
        //    {
        //        if (MessageBox.Show("ข้อมูลที่กำลังเพิ่ม/แก้ไข จะไม่ถูกบันทึก", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //    }

        //    this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
        //    base.OnFormClosing(e);
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void DialogDailySummary_Load(object sender, EventArgs e)
        {
            this.menu_id = this.GetType().Name;
            this.BackColor = MiscResource.WIND_BG;
            this.bs = new BindingSource();
            this.dgv.DataSource = this.bs;

            this.form_mode = FORM_MODE.READ;
            this.btnLast.PerformClick();
            this.ActiveControl = this.dgv;

            if (this.curr_date.HasValue)
            {
                DbfTable.Isinfo(this.main_form.working_express_db);
                DbfTable.Apmas(this.main_form.working_express_db);
                DbfTable.Aptrn(this.main_form.working_express_db);
            }
        }

        private void ResetControlState()
        {
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrint.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrintB.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrintC.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnApprove.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnApproveMulti.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnUnApprove.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /*Form control state depend on data*/
            if (this.form_mode == FORM_MODE.READ)
            {
                this.btnEdit.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnDelete.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnFirst.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnPrevious.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnNext.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnLast.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnSearch.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnInquiryAll.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnInquiryRest.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnPrint.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnItem.Enabled = this.dayend_list.Count == 0 ? false : true;
                //this.btnRefresh.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnApprove.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnApproveMulti.Enabled = this.dayend_list.Count == 0 ? false : true;
                this.btnUnApprove.Enabled = this.dayend_list.Count == 0 ? false : true;
            }

            this.ResetApproveBtn();
        }

        private void ResetApproveBtn()
        {
            if(this.form_mode == FORM_MODE.READ)
            {
                this.btnApprove.Enabled = this.curr_dayend == null ? false : (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsApproved().HasValue && this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsApproved().Value == true ? false : true);

                this.btnApproveMulti.Enabled = this.curr_dayend == null ? false : (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsApproved().HasValue && this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsApproved().Value == true ? false : true);

                this.btnUnApprove.Enabled = this.curr_dayend == null ? false : (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsApproved().HasValue && this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsApproved().Value == true ? true : false);
            }
        }

        private List<dayend> GetDayEnd(DateTime date)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.dayend.Include("daysttak").Where(d => d.saldat == date).ToList();
            }
        }

        private void FillForm()
        {
            this.lblDate.Text = this.curr_date.HasValue && this.dayend_list.Count > 0 ? this.curr_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) : string.Empty;

            this.bs.ResetBindings(true);
            this.bs.DataSource = this.dayend_list.ToViewModel(this.main_form.working_express_db);

            ///*Form control state depend on data*/
            //if (this.form_mode == FORM_MODE.READ)
            //{
            //    this.btnEdit.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnDelete.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnFirst.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnPrevious.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnNext.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnLast.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnSearch.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnInquiryAll.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnInquiryRest.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnPrint.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnItem.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    //this.btnRefresh.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnApprove.Enabled = this.dayend_list.Count == 0 ? false : true;
            //    this.btnUnApprove.Enabled = this.dayend_list.Count == 0 ? false : true;
            //}

            this.ResetApproveBtn();
        }

        private void ShowEditForm()
        {
            if (this.curr_dayend == null)
                return;

            DialogDayendEdit dlg = new DialogDayendEdit(this.main_form, this, this.curr_dayend);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                this.FillForm();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogDateSelector dlg = new DialogDateSelector("วันที่ปิดยอดขาย", DateTime.Now);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    if(db.dayend.Where(d => d.saldat == dlg.selected_date).Count() > 0)
                    {
                        MessageBox.Show("วันที่ \"" + dlg.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\" ปิดยอดขายไปแล้ว, ไม่สามารถปิดซ้ำได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    try
                    {
                        var imcomplete_trans = db.saleshistory.Include("salessummary.shiftsales").Where(s => s.salessummary.shiftsales.saldat == dlg.selected_date && s.mitbeg < 0).ToList();
                        if(imcomplete_trans.Count > 0)
                        {
                            MessageBox.Show("มีบางรายการยังไม่ได้ป้อนเลขมิเตอร์เริ่มต้น/สิ้นสุด, กรุณาย้อนกลับไปตรวจสอบที่เมนู \"บันทึกรายการประจำผลัด\"", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        var stkcods = db.salessummary.Include("shiftsales").Where(s => s.shiftsales.saldat == dlg.selected_date)
                                        .GroupBy(s => s.stkcod)
                                        .Select(s => s.Key).ToArray();

                        if(stkcods.Count() == 0)
                        {
                            MessageBox.Show("ไม่พบการบันทึกรายการประจำผลัดของวันที่ \"" + dlg.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\", กรุณาบันทึกรายการประจำผลัดก่อนทำการปิดยอดขายประจำวัน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        List<int> inserted_id = new List<int>();
                        foreach (string stkcod in stkcods)
                        {
                            dayend dayend = new dayend()
                            {
                                id = -1,
                                saldat = dlg.selected_date,
                                stkcod = stkcod,
                                creby = this.main_form.loged_in_status.loged_in_user_name,
                                cretime = DateTime.Now
                            };
                            dayendVM dvm = dayend.ToViewModel(this.main_form.working_express_db);
                            dayend.rcvqty = dvm.GetRcvQty();
                            dayend.salqty = dvm.GetSalQty();
                            dayend.begbal = dvm.GetBegBal();
                            dayend.begdif = dvm.GetBegDif();
                            dayend.difqty = dvm.GetDifQty();

                            //dayendVM d = dayend.ToViewModel(this.main_form.working_express_db);
                            db.dayend.Add(dayend);
                            db.SaveChanges();
                            inserted_id.Add(dayend.id);

                            var tanksetup = db.tanksetup.Where(t => t.startdate.CompareTo(dayend.saldat) <= 0).OrderByDescending(t => t.startdate).FirstOrDefault();

                            var sections = db.section
                                            .Include("tank")
                                            .Where(s => s.stkcod == stkcod)
                                            .Where(s => s.tank.tanksetup_id == tanksetup.id)
                                            .ToList();

                            foreach (var sect in sections)
                            {
                                shiftsttak sttak = db.shiftsttak.Where(s => s.takdat == dlg.selected_date)
                                            .Where(s => s.section_id == sect.id)
                                            .Where(s => s.qty > -1)
                                            .OrderByDescending(s => s.id)
                                            .FirstOrDefault();

                                db.daysttak.Add(new daysttak
                                {
                                    dayend_id = dayend.id,
                                    qty = sttak != null ? sttak.qty : -1,
                                    section_id = sect.id,
                                    creby = this.main_form.loged_in_status.loged_in_user_name,
                                    cretime = DateTime.Now
                                });
                                db.SaveChanges();

                                foreach (shiftsales sales in db.shiftsales.Where(s => s.saldat == dlg.selected_date).ToList())
                                {
                                    sales.closed = true;
                                    db.SaveChanges();
                                }
                            }

                            /* update difqty causing from daysttak that changed */
                            dayend.difqty = dvm.GetDifQty();
                            db.SaveChanges();
                            //this.main_form.islog.AddData(this.menu_id, "เพิ่มรายการปิดยอดขายประจำวันที่ " + dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + dayend.stkcod + "\"", dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + dayend.stkcod, "dayend", dayend.id).Save();
                        }

                        this.main_form.islog.AddData(this.menu_id, "เพิ่มรายการปิดยอดขายประจำวันที่ " + dlg.selected_date.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), dlg.selected_date.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", inserted_id.ToArray()).Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.curr_date = dlg.selected_date;
                this.form_mode = FORM_MODE.READ;
                this.ResetControlState();
                this.btnRefresh.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!this.curr_date.HasValue)
                return;

            if (this.curr_dayend.ToViewModel(this.main_form.working_express_db).IsEditableDayend() == false)
                return;

            if(MessageBox.Show("ลบข้อมูลการปิดยอดขายของวันที่ \"" + this.curr_date.Value.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\" , ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        var dayends = db.dayend.Where(d => d.saldat == this.curr_date.Value).ToList();

                        if(dayends.Count == 0)
                        {
                            MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        List<int> deleted_id = new List<int>();
                        foreach (var de in dayends)
                        {
                            foreach (var sttak in db.daysttak.Where(d => d.dayend_id == de.id).ToList())
                            {
                                db.daysttak.Remove(db.daysttak.Find(sttak.id));
                            }
                            foreach (var dother in db.dother.Where(d => d.dayend_id == de.id).ToList())
                            {
                                db.dother.Remove(db.dother.Find(dother.id));
                            }
                            db.dayend.Remove(db.dayend.Find(de.id));
                            deleted_id.Add(de.id);
                            //this.main_form.islog.DeleteData(this.menu_id, "ลบรายการปิดยอดขายประจำวันที่ " + de.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + ", รหัสสินค้า \"" + de.stkcod + "\"", de.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + de.stkcod, "dayend", de.id).Save();
                        }


                        var shiftsales = db.shiftsales.Where(s => s.saldat == this.curr_date.Value);
                        foreach (var sales in shiftsales)
                        {
                            sales.closed = false;
                        }

                        db.SaveChanges();
                        this.main_form.islog.DeleteData(this.menu_id, "ลบรายการปิดยอดขายประจำวันที่ " + dayends.First().saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), dayends.First().saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", deleted_id.ToArray()).Save();
                        this.btnNext.PerformClick();
                        //this.ResetControlState();
                        //this.btnRefresh.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tmp = db.dayend.OrderBy(d => d.saldat).FirstOrDefault();

                if (tmp != null)
                {
                    this.curr_date = tmp.saldat;
                    this.dayend_list = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend_list = new List<dayend>();
                }

                this.FillForm();
                this.ResetControlState();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if (this.curr_date.HasValue)
                {
                    var tmp = db.dayend.OrderByDescending(d => d.saldat).Where(d => d.saldat.CompareTo(this.curr_date.Value) < 0).FirstOrDefault();

                    if(tmp != null)
                    {
                        this.curr_date = tmp.saldat;
                        this.dayend_list = this.GetDayEnd(tmp.saldat);
                        this.FillForm();
                    }
                    else
                    {
                        this.btnFirst.PerformClick();
                    }
                }
                else
                {
                    this.btnFirst.PerformClick();
                }
                this.ResetControlState();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if (this.curr_date.HasValue)
                {
                    var tmp = db.dayend.OrderBy(d => d.saldat).Where(d => d.saldat.CompareTo(this.curr_date.Value) > 0).FirstOrDefault();

                    if (tmp != null)
                    {
                        this.curr_date = tmp.saldat;
                        this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                        this.FillForm();
                    }
                    else
                    {
                        this.btnLast.PerformClick();
                    }
                }
                else
                {
                    this.btnLast.PerformClick();
                }
                this.ResetControlState();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var tmp = db.dayend.OrderByDescending(d => d.saldat).FirstOrDefault();

                if (tmp != null)
                {
                    this.curr_date = tmp.saldat;
                    this.dayend_list = this.GetDayEnd(tmp.saldat);
                }
                else
                {
                    this.curr_date = null;
                    this.dayend_list = new List<dayend>();
                }

                this.FillForm();
                this.ResetControlState();
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            DialogDateSelector sel = new DialogDateSelector("วันที่ปิดยอดขาย", null);
            if(sel.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var tmp = db.dayend.Where(d => d.saldat == sel.selected_date).FirstOrDefault();

                    if(tmp != null)
                    {
                        this.curr_date = sel.selected_date;
                        this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                        this.FillForm();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบรายการปิดยอดขายของวันที่ " + sel.selected_date.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private List<DataGridViewColumn> GetInquiryDgvColumns()
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            DataGridViewColumn col_id = new DataGridViewTextBoxColumn();
            col_id.Name = "col_id";
            col_id.HeaderText = "ID";
            col_id.DataPropertyName = "id";
            col_id.Visible = false;
            cols.Add(col_id);

            DataGridViewColumn col_saldat = new DataGridViewTextBoxColumn();
            col_saldat.Name = "col_saldat";
            col_saldat.HeaderText = "วันที่";
            col_saldat.Name = "col_saldat";
            col_saldat.DataPropertyName = "saldat";
            col_saldat.DefaultCellStyle.Format = "dd/MM/yyyy";
            col_saldat.Width = 100;
            col_saldat.MinimumWidth = 100;
            cols.Add(col_saldat);

            DataGridViewColumn col_creby = new DataGridViewTextBoxColumn();
            col_creby.DataPropertyName = "creby";
            col_creby.Visible = true;
            col_creby.HeaderText = "สร้างโดย";
            col_creby.MinimumWidth = 100;
            col_creby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cols.Add(col_creby);

            DataGridViewColumn col_cretime = new DataGridViewTextBoxColumn();
            col_cretime.DataPropertyName = "cretime";
            col_cretime.Visible = true;
            col_cretime.HeaderText = "สร้างเมื่อ";
            col_cretime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col_cretime.Width = 140;
            col_cretime.MinimumWidth = 140;
            cols.Add(col_cretime);

            DataGridViewColumn col_chgby = new DataGridViewTextBoxColumn();
            col_chgby.DataPropertyName = "chgby";
            col_chgby.Visible = true;
            col_chgby.HeaderText = "บันทึกล่าสุดโดย";
            col_chgby.MinimumWidth = 100;
            col_chgby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cols.Add(col_chgby);

            DataGridViewColumn col_chgtime = new DataGridViewTextBoxColumn();
            col_chgtime.DataPropertyName = "chgtime";
            col_chgtime.Visible = true;
            col_chgtime.HeaderText = "บันทึกล่าสุดเมื่อ";
            col_chgtime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col_chgtime.Width = 140;
            col_chgtime.MinimumWidth = 140;
            cols.Add(col_chgtime);

            DataGridViewColumn col_apprby = new DataGridViewTextBoxColumn();
            col_apprby.DataPropertyName = "apprby";
            col_apprby.Visible = true;
            col_apprby.HeaderText = "รับรองโดย";
            col_apprby.MinimumWidth = 100;
            col_apprby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_apprby.Visible = false;
            cols.Add(col_apprby);

            DataGridViewColumn col_apprtime = new DataGridViewTextBoxColumn();
            col_apprtime.DataPropertyName = "apprtime";
            col_apprtime.Visible = true;
            col_apprtime.HeaderText = "รับรองเมื่อ";
            col_apprtime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col_apprtime.Width = 140;
            col_apprtime.MinimumWidth = 140;
            col_apprtime.Visible = false;
            cols.Add(col_apprtime);

            DataGridViewColumn col_rcvqty = new DataGridViewTextBoxColumn();
            col_rcvqty.HeaderText = "Rcv qty.";
            col_rcvqty.DataPropertyName = "rcvqty";
            col_rcvqty.Visible = false;
            cols.Add(col_rcvqty);

            DataGridViewColumn col_salqty = new DataGridViewTextBoxColumn();
            col_salqty.HeaderText = "Sale qty.";
            col_salqty.DataPropertyName = "salqty";
            col_salqty.Visible = false;
            cols.Add(col_salqty);

            DataGridViewColumn col_dother = new DataGridViewTextBoxColumn();
            col_dother.HeaderText = "Dother";
            col_dother.DataPropertyName = "dother";
            col_dother.Visible = false;
            cols.Add(col_dother);

            DataGridViewColumn col_difqty = new DataGridViewTextBoxColumn();
            col_difqty.HeaderText = "Dif. qty.";
            col_difqty.DataPropertyName = "difqty";
            col_difqty.Visible = false;
            cols.Add(col_difqty);

            DataGridViewColumn col_stkcod = new DataGridViewTextBoxColumn();
            col_stkcod.HeaderText = "Stkcod";
            col_stkcod.DataPropertyName = "stkcod";
            col_stkcod.Visible = false;
            cols.Add(col_stkcod);

            DataGridViewColumn col_stmas = new DataGridViewTextBoxColumn();
            col_stmas.HeaderText = "Stmas";
            col_stmas.DataPropertyName = "stmas";
            col_stmas.Visible = false;
            cols.Add(col_stmas);

            DataGridViewColumn col_begbal = new DataGridViewTextBoxColumn();
            col_begbal.HeaderText = "Begbal";
            col_begbal.DataPropertyName = "begbal";
            col_begbal.Visible = false;
            cols.Add(col_begbal);

            DataGridViewColumn col_begdif = new DataGridViewTextBoxColumn();
            col_begdif.HeaderText = "Begdif";
            col_begdif.DataPropertyName = "begdif";
            col_begdif.Visible = false;
            cols.Add(col_begdif);

            DataGridViewColumn col_daysttak = new DataGridViewTextBoxColumn();
            col_daysttak.HeaderText = "Day Sttak";
            col_daysttak.DataPropertyName = "daysttak";
            col_daysttak.Visible = false;
            cols.Add(col_daysttak);

            DataGridViewColumn col_working_express_db = new DataGridViewTextBoxColumn();
            col_working_express_db.DataPropertyName = "working_express_db";
            col_working_express_db.Visible = false;
            cols.Add(col_working_express_db);

            return cols;
        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            var cols = this.GetInquiryDgvColumns();

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                //var dayendVM = db.dayend.ToViewModel().OrderBy(s => s.saldat).ToList<dynamic>();
                var dayendVM = db.dayend.OrderBy(s => s.saldat).ToList()
                                .GroupBy(d => d.saldat)
                                .Select(d => d.First())
                                .ToList<dynamic>();
                var col_search_key = cols.Where(c => c.Name == "col_saldat").FirstOrDefault();
                DialogInquiry inq = new DialogInquiry(dayendVM, cols, col_search_key, null, false);

                if (inq.ShowDialog() == DialogResult.OK)
                {
                    var saldat = (DateTime)inq.selected_row.Cells["col_saldat"].Value;
                    this.dayend_list = this.GetDayEnd(saldat);
                    this.curr_date = saldat;
                    this.FillForm();
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            var cols = this.GetInquiryDgvColumns();

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var dayendVM = db.dayend.OrderBy(s => s.saldat).ToList()
                                .GroupBy(d => d.saldat)
                                .Select(d => d.First())
                                .ToList<dynamic>();
                var col_search_key = cols.Where(c => c.Name == "col_saldat").FirstOrDefault();
                DialogInquiry inq = new DialogInquiry(dayendVM, cols, col_search_key, this.curr_date.Value, false);

                if (inq.ShowDialog() == DialogResult.OK)
                {
                    var saldat = (DateTime)inq.selected_row.Cells["col_saldat"].Value;
                    this.dayend_list = this.GetDayEnd(saldat);
                    this.curr_date = saldat;
                    this.FillForm();
                }
            }
        }

        private void btnPrintB_Click(object sender, EventArgs e)
        {
            DialogPrintSetupB print = new DialogPrintSetupB(this.curr_date);
            if (print.ShowDialog() == DialogResult.OK)
            {
                var report_data = new ReportBModel(print.selected_date.Value, this.main_form.working_express_db);
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_B(report_data));
                if(print.output == PRINT_OUTPUT.SCREEN)
                {
                    List<dayendVM> dayends;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        dayends = db.dayend.Where(d => d.saldat == print.selected_date.Value).ToViewModel(this.main_form.working_express_db);
                        if(dayends.Count == 0)
                        {
                            MessageBox.Show("ไม่มีข้อมูลตามขอบเขตที่กำหนด", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    var print_auth_state = dayends.First().GetPrintAuthorizeState();
                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_B(report_data, total_page), total_page, print_auth_state);
                    xp.MdiParent = this.main_form;
                    xp._OnOutputToPrinter += delegate
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var ids = db.dayend.Where(d => d.saldat == print.selected_date.Value).Select(d => d.id).ToArray();
                            var prntim = DateTime.Now;
                            foreach (var id in ids)
                            {
                                var dayend_to_update = db.dayend.Find(id);
                                if (dayend_to_update == null)
                                    continue;

                                dayend_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                                dayend_to_update.prntime = prntim;
                                dayend_to_update.prncnt = ++dayend_to_update.prncnt;
                            }
                            db.SaveChanges();

                            this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ข. ของวันที่ " + print.selected_date.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ออกทางเครื่องพิมพ์", print.selected_date.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", ids).Save();
                        }
                    };
                    xp.Show();
                }

                if(print.output == PRINT_OUTPUT.PRINTER)
                {
                    List<dayendVM> dayends;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        dayends = db.dayend.Where(d => d.saldat == print.selected_date.Value).ToViewModel(this.main_form.working_express_db);
                        if (dayends.Count == 0)
                        {
                            MessageBox.Show("ไม่มีข้อมูลตามขอบเขตที่กำหนด", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    if (dayends.First().IsPrintableDayend() == false)
                        return;

                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_B(report_data, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var ids = db.dayend.Where(d => d.saldat == print.selected_date.Value).Select(d => d.id).ToArray();
                            var prntim = DateTime.Now;
                            foreach (var id in ids)
                            {
                                var dayend_to_update = db.dayend.Find(id);
                                if (dayend_to_update == null)
                                    continue;

                                dayend_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                                dayend_to_update.prntime = prntim;
                                dayend_to_update.prncnt = ++dayend_to_update.prncnt;
                            }
                            db.SaveChanges();

                            this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ข. ของวันที่ " + print.selected_date.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ออกทางเครื่องพิมพ์", print.selected_date.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", ids).Save();
                        }

                        pd.Document.Print();
                    }
                }
            }
        }

        private void btnPrintC_Click(object sender, EventArgs e)
        {
            DialogPrintSetupC print = new DialogPrintSetupC(this.curr_date);
            if (print.ShowDialog() == DialogResult.OK)
            {
                var report_data = new ReportCModel(print.first_date_of_month.Value, print.last_date_of_month.Value, this.main_form.working_express_db);
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_C(report_data));
                if (print.output == PRINT_OUTPUT.SCREEN)
                {
                    List<dayendVM> dayends;
                    var print_auth_state = PRINT_AUTHORIZE_STATE.READY_TO_PRINT;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        dayends = db.dayend.Where(d => d.saldat.CompareTo(print.first_date_of_month.Value) >= 0 && d.saldat.CompareTo(print.last_date_of_month.Value) <= 0).ToViewModel(this.main_form.working_express_db);
                        if (dayends.Count == 0)
                        {
                            MessageBox.Show("ไม่มีข้อมูลตามขอบเขตที่กำหนด", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        foreach (var item in dayends)
                        {
                            var auth_state = item.GetPrintAuthorizeState();
                            if (auth_state == PRINT_AUTHORIZE_STATE.MUST_APPROVE_BEFORE_PRINT || auth_state == PRINT_AUTHORIZE_STATE.MUST_UNAPPROVE_BEFORE_PRINT)
                                print_auth_state = auth_state;
                        }
                    }

                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_C(report_data, total_page), total_page, print_auth_state);
                    xp.MdiParent = this.main_form;
                    xp._OnOutputToPrinter += delegate
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var ids = db.dayend.Where(d => d.saldat == this.curr_dayend.saldat).Select(d => d.id).ToArray();
                            //var prntim = DateTime.Now;
                            //foreach (var id in ids)
                            //{
                            //    var dayend_to_update = db.dayend.Find(id);
                            //    if (dayend_to_update == null)
                            //        continue;

                            //    dayend_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                            //    dayend_to_update.prntime = prntim;
                            //    dayend_to_update.prncnt = ++dayend_to_update.prncnt;
                            //}
                            //db.SaveChanges();

                            this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ค. ของวันที่ " + this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ออกทางเครื่องพิมพ์", this.curr_dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", ids).Save();
                        }
                    };
                    xp.Show();
                }

                if (print.output == PRINT_OUTPUT.PRINTER)
                {
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        List<dayendVM> dayends = db.dayend.Where(d => d.saldat.CompareTo(print.first_date_of_month.Value) >= 0 && d.saldat.CompareTo(print.last_date_of_month.Value) <= 0).ToViewModel(this.main_form.working_express_db);
                        if (dayends.Count == 0)
                        {
                            MessageBox.Show("ไม่มีข้อมูลตามขอบเขตที่กำหนด", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        foreach (var item in dayends)
                        {
                            var auth_state = item.GetPrintAuthorizeState();
                            if (auth_state == PRINT_AUTHORIZE_STATE.MUST_APPROVE_BEFORE_PRINT)
                            {
                                MessageBox.Show("ต้องรับรองรายการก่อนพิมพ์", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            if (auth_state == PRINT_AUTHORIZE_STATE.MUST_UNAPPROVE_BEFORE_PRINT)
                            {
                                MessageBox.Show("รับรองรายการแล้ว ไม่สามารถพิมพ์ได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }

                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_C(report_data, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var ids = db.dayend.Where(d => d.saldat == this.curr_dayend.saldat).Select(d => d.id).ToArray();
                            //var prntim = DateTime.Now;
                            //foreach (var id in ids)
                            //{
                            //    var dayend_to_update = db.dayend.Find(id);
                            //    if (dayend_to_update == null)
                            //        continue;

                            //    dayend_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                            //    dayend_to_update.prntime = prntim;
                            //    dayend_to_update.prncnt = ++dayend_to_update.prncnt;
                            //}
                            //db.SaveChanges();

                            this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ค. ของวันที่ " + this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ออกทางเครื่องพิมพ์", this.curr_dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", ids).Save();
                        }
                        pd.Document.Print();
                    }
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (this.curr_dayend == null)
                return;
            string approved_user = this.main_form.loged_in_status.loged_in_user_name;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var dayend_ids = db.dayend.Where(d => d.saldat == this.curr_dayend.saldat).Select(d => d.id).ToArray();
                if (db.daysttak.Where(s => dayend_ids.Contains(s.dayend_id) && s.qty < 0).Count() > 0)
                {
                    if (MessageBox.Show("ปริมาณน้ำมันที่ตรวจวัดได้ยังป้อนไม่ครบ, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                }

                settings settings = DialogSettings.GetSettings(this.main_form.working_express_db);
                if (this.main_form.loged_in_status.loged_in_user_level < settings.dayauthlev)
                {
                    DialogValidateUser validate = new DialogValidateUser(this.main_form, settings.dayauthlev);
                    if (validate.ShowDialog() != DialogResult.OK)
                        return;

                    approved_user = validate.validated_status.loged_in_user_name;
                }

                if (MessageBox.Show("กรุณายืนยันเพื่อทำการรับรองรายการ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;

                try
                {
                    foreach (var id in dayend_ids)
                    {
                        var dayend_to_appr = db.dayend.Find(id);
                        dayend_to_appr.apprby = approved_user;
                        dayend_to_appr.apprtime = DateTime.Now;

                        db.SaveChanges();
                    }

                    this.main_form.islog.Approve(this.menu_id, "รับรองรายการ ปิดยอดขายประจำวันที่ " + this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.curr_dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", dayend_ids.ToArray()).Save(approved_user);

                    this.btnRefresh.PerformClick();
                    this.ResetApproveBtn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnApproveMulti_Click(object sender, EventArgs e)
        {
            DialogDateRangeSelector date_selector = new DialogDateRangeSelector(this.main_form, false, false);
            if(date_selector.ShowDialog() == DialogResult.OK)
            {
                string approved_user = this.main_form.loged_in_status.loged_in_user_name;
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var sttak = db.daysttak.Include("dayend")
                                .Where(st => st.dayend.saldat.CompareTo(date_selector.FromDate.Value) >= 0 && st.dayend.saldat.CompareTo(date_selector.ToDate.Value) <= 0)
                                .Where(st => st.qty < 0).ToList();

                    if(sttak.Count > 0)
                    {
                        if (MessageBox.Show("ปริมาณน้ำมันที่ตรวจวัดได้ในวันที่ " + sttak.First().dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ยังป้อนไม่ครบ, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                            return;
                    }

                    settings settings = DialogSettings.GetSettings(this.main_form.working_express_db);
                    if (this.main_form.loged_in_status.loged_in_user_level < settings.dayauthlev)
                    {
                        DialogValidateUser validate = new DialogValidateUser(this.main_form, settings.dayauthlev);
                        if (validate.ShowDialog() != DialogResult.OK)
                            return;

                        approved_user = validate.validated_status.loged_in_user_name;
                    }

                    if (MessageBox.Show("กรุณายืนยันเพื่อทำการรับรองรายการ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;

                    try
                    {
                        var dayends = db.dayend
                                    .Where(d => d.saldat.CompareTo(date_selector.FromDate.Value) >= 0 && d.saldat.CompareTo(date_selector.ToDate.Value) <= 0).ToList();
                        foreach (var dayend in dayends)
                        {
                            var dayend_to_appr = db.dayend.Find(dayend.id);
                            dayend_to_appr.apprby = approved_user;
                            dayend_to_appr.apprtime = DateTime.Now;
                        }
                        db.SaveChanges();

                        this.main_form.islog.ApproveMultiple(this.menu_id, "รับรองรายการ ปิดยอดขายประจำวันช่วงวันที่ " + date_selector.FromDate.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ถึงวันที่ " + date_selector.ToDate.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), date_selector.FromDate.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + date_selector.ToDate.Value.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", dayends.Select(d => d.id).ToArray()).Save(approved_user);

                        this.btnRefresh.PerformClick();
                        this.ResetApproveBtn();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void btnUnApprove_Click(object sender, EventArgs e)
        {
            if (this.curr_dayend == null)
                return;

            string unapproved_user = this.main_form.loged_in_status.loged_in_user_name;

            settings settings = DialogSettings.GetSettings(this.main_form.working_express_db);
            if (this.main_form.loged_in_status.loged_in_user_level < settings.dayauthlev)
            {
                DialogValidateUser validate = new DialogValidateUser(this.main_form, settings.dayauthlev);
                if (validate.ShowDialog() != DialogResult.OK)
                    return;

                unapproved_user = validate.validated_status.loged_in_user_name;
            }

            if (MessageBox.Show("กรุณายืนยันเพื่อยกเลิกการรับรองรายการ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    List<int> unapprove_id = new List<int>();
                    foreach (var id in db.dayend.Where(d => d.saldat == this.curr_dayend.saldat).Select(d => d.id).ToArray())
                    {
                        var dayend_to_appr = db.dayend.Find(id);
                        dayend_to_appr.apprby = null;
                        dayend_to_appr.apprtime = null;

                        db.SaveChanges();
                        unapprove_id.Add(id);
                    }
                    

                    this.main_form.islog.UnApprove(this.menu_id, "ยกเลิกการรับรองรายการ ปิดยอดขายประจำวันที่ " + this.curr_dayend.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.curr_dayend.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")), "dayend", unapprove_id.ToArray()).Save(unapproved_user);

                    this.btnRefresh.PerformClick();
                    this.ResetApproveBtn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.curr_date.HasValue)
            {
                this.dayend_list = this.GetDayEnd(this.curr_date.Value);
                this.FillForm();
                this.ResetControlState();
            }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (((XDatagrid)sender).CurrentCell == null)
            {
                this.curr_dayend = null;
                return;
            }

            dayend tmp = (dayend)((XDatagrid)sender).Rows[((XDatagrid)sender).CurrentCell.RowIndex].Cells[this.col_dayend.Name].Value;

            if (this.curr_dayend == null)
            {
                this.curr_dayend = tmp;
            }
            else
            {
                if(this.curr_dayend.id != tmp.id)
                {
                    this.curr_dayend = tmp;
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                this.ShowEditForm();
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_stkcod.Name].Selected = true;

                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem("แก้ไข <Alt+E>");
                mnu_edit.Click += delegate
                {
                    this.ShowEditForm();
                };
                cm.MenuItems.Add(mnu_edit);

                cm.Show(((XDatagrid)sender), new Point(e.X, e.Y));
            }
        }

        private PrintDocument PreparePrintDoc_B(ReportBModel report_data, int total_page = 0)
        {
            Font fnt_title_bold = new Font("angsana new", 12f, FontStyle.Bold);
            Font fnt_header_bold = new Font("angsana new", 11f, FontStyle.Bold); // tahoma 8f bold
            Font fnt_header = new Font("angsana new", 11f, FontStyle.Regular); // tahoma 8f
            Font fnt_bold = new Font("angsana new", 10f, FontStyle.Bold); // tahoma 7f bold
            Font fnt = new Font("angsana new", 10f, FontStyle.Regular); // tahoma 7f
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush bg_gray = new SolidBrush(Color.Silver);
            SolidBrush bg_lightgray = new SolidBrush(Color.Gainsboro);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;
            int item_per_page = 4;
            int section_per_product = 8;
            int max_dother_item = 5;
            int printed_vatdoc = -1;
            int vatdoc_item_per_column = 30;

            PrintDocument docs = new PrintDocument();
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //docs.DefaultPageSettings.PaperSize = ps;
            docs.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
            docs.DefaultPageSettings.Landscape = true;
            docs.BeginPrint += delegate (object sender, PrintEventArgs e)
            {
                page = 0;
                item_count = 0;
                printed_vatdoc = -1;
            };
            docs.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int line_height = fnt_header.Height;

                page++;

                // draw margin bound
                //e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(x, y, e.MarginBounds.Right - x, e.MarginBounds.Bottom - y));

                /* report header */
                Rectangle rect = new Rectangle(x, y, e.MarginBounds.Right - x, line_height);
                string str = "รายงานแสดงรายละเอียดการขายน้ำมันเชื้อเพลิง";
                e.Graphics.DrawString(str, fnt_title_bold, brush, rect, format_center);

                y += line_height; // new line
                str = "วันที่ " + report_data.reportDate.ToString("d MMMM", CultureInfo.CurrentCulture) + " พ.ศ. " + report_data.reportDate.ToString("yyyy", CultureInfo.CurrentCulture);
                rect = str.GetDisplayRect(fnt_header, (int)Math.Round((double)(e.MarginBounds.Width / 2) + x - (str.Width(fnt_header) / 2)), y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อผู้ประกอบการ: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                rect = report_data.isinfoDbfVM.compnam.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(report_data.isinfoDbfVM.compnam, fnt_header, brush, rect, format_left);

                str = "[ส่วน ข]";
                rect = str.GetDisplayRect(fnt_header, x + e.MarginBounds.Width - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawRectangle(Pens.Black, rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อสถานีบริการน้ำมัน: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.orgnam;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "เลขประจำตัวผู้เสียภาษี :   ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.X = e.MarginBounds.Right - rect.Width - 150;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                str = report_data.isinfoDbfVM.taxid;
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                y += line_height; // new line
                str = "ที่อยู่: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.addr;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                rect.Width += 30;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "หน้า " + page.ToString() + "/" + total_page;
                rect = str.GetDisplayRect(fnt_header, e.MarginBounds.Right - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                y += line_height; // new line
                str = report_data.isinfoDbfVM.telnum.Contains("โทร") || report_data.isinfoDbfVM.telnum.ToLower().Contains("tel") ? report_data.isinfoDbfVM.telnum : "โทร. " + report_data.isinfoDbfVM.telnum;
                rect = str.GetDisplayRect(fnt_header, x + 110, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                /* item (loop) */
                y += line_height; // new line
                int start_body_y = y;
                int page_item = 0;
                //List<VatTransDbfVM> sal_vattrans = new List<VatTransDbfVM>();
                //List<VatTransDbfVM> pur_vattrans = new List<VatTransDbfVM>();
                //decimal tot_salvat = 0m;
                //decimal tot_purvat = 0m;

                if (item_count < report_data.dayend.Count)
                {
                    Rectangle rect_str_container = new Rectangle(x, y, 200, line_height * 2);
                    e.Graphics.FillRectangle(bg_gray, rect_str_container);
                    e.Graphics.DrawRectangle(p, rect_str_container);
                    e.Graphics.DrawString("รายการ", fnt_bold, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Center });

                    rect_str_container.Y += rect_str_container.Height;
                    rect_str_container.Height = line_height * section_per_product;
                    e.Graphics.DrawRectangle(p, rect_str_container);
                    e.Graphics.DrawString("1. น้ำมันสะสมในถังวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });

                    rect_str_container.Y += rect_str_container.Height;
                    rect_str_container.Height = line_height;
                    e.Graphics.DrawRectangle(p, rect_str_container);
                    e.Graphics.DrawString("2. รวมยอดน้ำมันวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    rect_str_container.Height = line_height * (7 + max_dother_item);
                    e.Graphics.DrawRectangle(p, rect_str_container);

                    rect_str_container.Height = line_height;
                    e.Graphics.DrawString("3. น้ำมันที่วัดได้จริงต้นงวด", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("4. บวก ยอดรับน้ำมัน", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("5. หัก น้ำมันที่ขายผ่านมิเตอร์ระหว่างวัน", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("   หัก อื่น ๆ ระบุ =======================>", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height * max_dother_item;
                    e.Graphics.DrawString("6. น้ำมันคงเหลือในบัญชี (3+4-5)", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("7. ผลต่างน้ำมันปัจจุบัน (2-6)", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("8. บวก ผลต่างสะสมยกมา", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("9. ผลต่างสะสมปัจจุบันยกไป (7+8)", fnt, brush, rect_str_container, format_left);

                    Rectangle rect_section = new Rectangle(x, y, 80/*60*/, line_height);
                    int sub_col_width = Convert.ToInt32(Math.Floor((double)((e.MarginBounds.Right - e.MarginBounds.Left) - rect_str_container.Width) / item_per_page));
                    Rectangle rect_stk = new Rectangle(x, y, sub_col_width - rect_section.Width, line_height);

                    x += rect_str_container.Width;
                    for (int i = item_count; i < report_data.dayend.Count; i++)
                    {
                        page_item++;
                        item_count++;

                        x = e.MarginBounds.Left + rect_str_container.Width + (sub_col_width * (page_item - 1));

                        rect_section.X = x;
                        rect_section.Y = start_body_y;
                        rect_section.Height = line_height * 2;
                        e.Graphics.FillRectangle(bg_gray, rect_section);
                        e.Graphics.DrawRectangle(p, rect_section);
                        e.Graphics.DrawString("เลขที่" + Environment.NewLine + "ถัง", fnt_bold, brush, rect_section, format_center);
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height, rect_section.Width, line_height * section_per_product));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product), rect_section.Width, line_height));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product) + line_height, rect_section.Width, line_height * (7 + max_dother_item)));

                        rect_stk.X = rect_section.X + rect_section.Width;
                        rect_stk.Y = start_body_y;
                        rect_stk.Height = line_height * 2;
                        e.Graphics.FillRectangle(bg_gray, rect_stk);
                        e.Graphics.DrawRectangle(p, rect_stk);
                        e.Graphics.DrawString(report_data.dayend[i].ToViewModel(this.main_form.working_express_db).stkcod, fnt_bold, brush, rect_stk, format_center);
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height, rect_stk.Width, line_height * section_per_product));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product), rect_stk.Width, line_height));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product) + line_height, rect_stk.Width, line_height * (7 + max_dother_item)));

                        for (int j = 0; j < section_per_product; j++)
                        {
                            rect_section.Y += rect_section.Height;
                            rect_section.Height = line_height;
                            string sect = report_data.dayend[i].daysttak.Count > j ? report_data.dayend[i].daysttak.ToList()[j].ToViewModel(this.main_form.working_express_db).section_name : "-";
                            e.Graphics.DrawString(sect, fnt, brush, rect_section, format_center);

                            rect_stk.Y += rect_stk.Height;
                            rect_stk.Height = line_height;
                            string qty = report_data.dayend[i].daysttak.Count > j ? string.Format("{0:#,#0.00}", report_data.dayend[i].daysttak.ToList()[j].ToViewModel(this.main_form.working_express_db).qty) : string.Empty;
                            e.Graphics.DrawString(qty, fnt, brush, rect_stk, format_right);
                        }

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).endbal), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).begbal), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).rcvqty), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).salqty), fnt, brush, rect_stk, format_right);

                        /** dother **/
                        rect_section.Y = rect_stk.Y;
                        e.Graphics.FillRectangle(bg_lightgray, new Rectangle(rect_section.X + 1, rect_section.Y + rect_section.Height + 1, rect_section.Width - 2, (line_height * max_dother_item) - 2));
                        e.Graphics.FillRectangle(bg_lightgray, new Rectangle(rect_stk.X + 1, rect_stk.Y + rect_stk.Height + 1, rect_stk.Width - 2, (line_height * max_dother_item) - 2));
                        for (int d = 0; d < max_dother_item; d++)
                        {
                            rect_section.Y += rect_section.Height;
                            rect_stk.Y += rect_stk.Height;

                            if (report_data.dayend[i].dother.Count > d)
                            {
                                e.Graphics.DrawString(report_data.dayend[i].dother.ElementAt(d).ToViewModel(this.main_form.working_express_db).typdes, fnt, brush, rect_section);
                                e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].dother.ElementAt(d).qty), fnt, brush, rect_stk, new StringFormat { Alignment = StringAlignment.Far });
                            }
                            else
                            {
                                e.Graphics.DrawString("-", fnt, brush, rect_stk, new StringFormat { Alignment = StringAlignment.Far });
                            }
                        }
                        /****************************************/

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).accbal), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).difqty), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).begdif), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.dayend[i].ToViewModel(this.main_form.working_express_db).begdif + report_data.dayend[i].ToViewModel(this.main_form.working_express_db).difqty), fnt, brush, rect_stk, format_right);

                        Rectangle rect_vat = new Rectangle(e.MarginBounds.Left, rect_stk.Y + line_height, e.MarginBounds.Right - e.MarginBounds.Left, line_height);

                        if (item_count == item_per_page && item_count < report_data.dayend.Count)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                        else
                        {
                            e.HasMorePages = false;
                        }
                    }
                }

                if(report_data.pur_vatdocs.Count > 0)
                {
                    if (printed_vatdoc == -1)
                    {
                        e.HasMorePages = true;
                        printed_vatdoc = 0;
                        return;
                    }

                    //rect.Y += line_height;
                    Rectangle rect_vatdoc_title = new Rectangle(e.MarginBounds.Left, rect.Y + line_height, 400, line_height);
                    e.Graphics.DrawString("ใบจ่ายน้ำมันหรือใบกำกับภาษีขนส่งน้ำมัน", fnt_bold, brush, rect_vatdoc_title);
                    Rectangle rect_seq = new Rectangle(rect_vatdoc_title.X, rect_vatdoc_title.Y + line_height, 30, line_height);
                    Rectangle rect_vatdoc = new Rectangle(rect_seq.X + rect_seq.Width, rect_seq.Y, 85, line_height);
                    Rectangle rect_vatdat = new Rectangle(rect_vatdoc.X + rect_vatdoc.Width, rect_vatdoc.Y, 85, line_height);
                    Rectangle rect_supplier = new Rectangle(rect_vatdat.X + rect_vatdat.Width, rect_vatdat.Y, 190, line_height);
                    Rectangle rect_amt = new Rectangle(rect_supplier.X + rect_supplier.Width, rect_supplier.Y, 80, line_height);
                    Rectangle rect_vatamt = new Rectangle(rect_amt.X + rect_amt.Width, rect_amt.Y, 85, line_height);
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width, rect_seq.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdoc.X, rect_vatdoc.Y, rect_vatdoc.Width, rect_vatdoc.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdat.X, rect_vatdat.Y, rect_vatdat.Width, rect_vatdat.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_supplier.X, rect_supplier.Y, rect_supplier.Width, rect_supplier.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_amt.X, rect_amt.Y, rect_amt.Width, rect_amt.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatamt.X, rect_vatamt.Y, rect_vatamt.Width, rect_vatamt.Height));

                    e.Graphics.DrawString("ลำดับ", fnt_bold, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("เลขที่", fnt_bold, brush, rect_vatdoc, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("วัน เดือน ปี", fnt_bold, brush, rect_vatdat, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("บริษัทผู้ค้าน้ำมัน", fnt_bold, brush, rect_supplier, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("จำนวนเงิน(บาท)", fnt_bold, brush, rect_amt, new StringFormat { Alignment = StringAlignment.Far });
                    e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม(บาท)", fnt_bold, brush, rect_vatamt, new StringFormat { Alignment = StringAlignment.Far });

                    e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width, line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_vatdoc.X, rect_vatdoc.Y), new Point(rect_vatdoc.X, rect_vatdoc.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_vatdat.X, rect_vatdat.Y), new Point(rect_vatdat.X, rect_vatdat.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_supplier.X, rect_supplier.Y), new Point(rect_supplier.X, rect_supplier.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_amt.X, rect_amt.Y), new Point(rect_amt.X, rect_amt.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_vatamt.X, rect_vatamt.Y), new Point(rect_vatamt.X, rect_vatamt.Y + line_height + (line_height * vatdoc_item_per_column)));

                    for (int i = printed_vatdoc; i < report_data.pur_vatdocs.Count; i++)
                    {
                        rect_seq.Y += line_height;
                        rect_vatdoc.Y += line_height;
                        rect_vatdat.Y += line_height;
                        rect_supplier.Y += line_height;
                        rect_amt.Y += line_height;
                        rect_vatamt.Y += line_height;

                        e.Graphics.DrawString((i + 1).ToString(), fnt, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawString(report_data.pur_vatdocs[i].docnum, fnt, brush, rect_vatdoc);
                        e.Graphics.DrawString(report_data.pur_vatdocs[i].docdat.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("th-TH")), fnt, brush, rect_vatdat);
                        e.Graphics.DrawString(report_data.pur_vatdocs[i].people, fnt, brush, rect_supplier);
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.pur_vatdocs[i].netval), fnt, brush, rect_amt, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.pur_vatdocs[i].vatamt), fnt, brush, rect_vatamt, new StringFormat { Alignment = StringAlignment.Far });

                        if ((i + 1) % (vatdoc_item_per_column * 2) == 0)
                        {
                            e.HasMorePages = true;
                            printed_vatdoc++;
                            return;
                        }

                        if ((i + 1) % vatdoc_item_per_column == 0)
                        {
                            rect_seq.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_vatdoc.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_vatdat.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_supplier.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_amt.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_vatamt.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_seq.Y = rect.Y + (line_height * 2);
                            rect_vatdoc.Y = rect.Y + (line_height * 2);
                            rect_vatdat.Y = rect.Y + (line_height * 2);
                            rect_supplier.Y = rect.Y + (line_height * 2);
                            rect_amt.Y = rect.Y + (line_height * 2);
                            rect_vatamt.Y = rect.Y + (line_height * 2);

                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width, rect_seq.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdoc.X, rect_vatdoc.Y, rect_vatdoc.Width, rect_vatdoc.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdat.X, rect_vatdat.Y, rect_vatdat.Width, rect_vatdat.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_supplier.X, rect_supplier.Y, rect_supplier.Width, rect_supplier.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_amt.X, rect_amt.Y, rect_amt.Width, rect_amt.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatamt.X, rect_vatamt.Y, rect_vatamt.Width, rect_vatamt.Height));

                            e.Graphics.DrawString("ลำดับ", fnt_bold, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("เลขที่", fnt_bold, brush, rect_vatdoc, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("วัน เดือน ปี", fnt_bold, brush, rect_vatdat, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("บริษัทผู้ค้าน้ำมัน", fnt_bold, brush, rect_supplier, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("จำนวนเงิน(บาท)", fnt_bold, brush, rect_amt, new StringFormat { Alignment = StringAlignment.Far });
                            e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม(บาท)", fnt_bold, brush, rect_vatamt, new StringFormat { Alignment = StringAlignment.Far });

                            e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width, line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_vatdoc.X, rect_vatdoc.Y), new Point(rect_vatdoc.X, rect_vatdoc.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_vatdat.X, rect_vatdat.Y), new Point(rect_vatdat.X, rect_vatdat.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_supplier.X, rect_supplier.Y), new Point(rect_supplier.X, rect_supplier.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_amt.X, rect_amt.Y), new Point(rect_amt.X, rect_amt.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_vatamt.X, rect_vatamt.Y), new Point(rect_vatamt.X, rect_vatamt.Y + line_height + (line_height * vatdoc_item_per_column)));
                        }

                        printed_vatdoc++;
                    }
                }
            };

            return docs;
        }

        private PrintDocument PreparePrintDoc_C(ReportCModel report_data, int total_page = 0)
        {
            Font fnt_title_bold = new Font("angsana new", 12f, FontStyle.Bold);
            Font fnt_header_bold = new Font("angsana new", 11f, FontStyle.Bold); // tahoma 8f bold
            Font fnt_header = new Font("angsana new", 11f, FontStyle.Regular); // tahoma 8f
            Font fnt_bold = new Font("angsana new", 10f, FontStyle.Bold); // tahoma 7f bold
            Font fnt = new Font("angsana new", 10f, FontStyle.Regular); // tahoma 7f
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush bg_gray = new SolidBrush(Color.Silver);
            SolidBrush bg_lightgray = new SolidBrush(Color.Gainsboro);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;
            int item_per_page = 4;
            int section_per_product = 8;
            int max_dother_item = 5;
            int printed_vatdoc = -1;
            int vatdoc_item_per_column = 30;


            PrintDocument docs = new PrintDocument();
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //docs.DefaultPageSettings.PaperSize = ps;
            docs.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
            docs.DefaultPageSettings.Landscape = true;
            docs.BeginPrint += delegate (object sender, PrintEventArgs e)
            {
                page = 0;
                item_count = 0;
                printed_vatdoc = -1;
            };
            docs.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int line_height = fnt_header.Height;

                page++;

                // draw margin bound
                //e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(x, y, e.MarginBounds.Right - x, e.MarginBounds.Bottom - y));

                /* report header */
                Rectangle rect = new Rectangle(x, y, e.MarginBounds.Right - x, line_height);
                string str = "รายงานแสดงรายละเอียดการขายน้ำมันเชื้อเพลิง";
                e.Graphics.DrawString(str, fnt_header_bold, brush, rect, format_center);

                y += line_height; // new line
                str = "ณ เดือน " + report_data.reportDate.ToString("MMMM", CultureInfo.CurrentCulture) + " พ.ศ. " + report_data.reportDate.ToString("yyyy", CultureInfo.CurrentCulture);
                rect = str.GetDisplayRect(fnt_header, (int)Math.Round((double)(e.MarginBounds.Width / 2) + x - (str.Width(fnt_header) / 2)), y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อผู้ประกอบการ: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                rect = report_data.isinfoDbfVM.compnam.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(report_data.isinfoDbfVM.compnam, fnt_header, brush, rect, format_left);

                str = "[ส่วน ค]";
                rect = str.GetDisplayRect(fnt_header, x + e.MarginBounds.Width - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawRectangle(Pens.Black, rect.X - 5, rect.Y - 3, rect.Width + 10, rect.Height + 6);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_center);

                y += line_height; // new line
                str = "ชื่อสถานีบริการน้ำมัน: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.orgnam;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "เลขประจำตัวผู้เสียภาษี :   ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.X = e.MarginBounds.Right - rect.Width - 150;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                str = report_data.isinfoDbfVM.taxid;
                rect = str.GetDisplayRect(fnt_header, rect.X + rect.Width, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                y += line_height; // new line
                str = "ที่อยู่: ";
                rect = str.GetDisplayRect(fnt_header, x, y);
                rect.Width = 110;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);
                str = report_data.isinfoDbfVM.addr;
                rect = str.GetDisplayRect(fnt_header, x + rect.Width, y);
                rect.Width += 30;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                str = "หน้า " + page.ToString() + "/" + total_page;
                rect = str.GetDisplayRect(fnt_header, e.MarginBounds.Right - str.Width(fnt_header), y);
                rect.X -= 10;
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_right);

                y += line_height; // new line
                str = report_data.isinfoDbfVM.telnum.Contains("โทร") || report_data.isinfoDbfVM.telnum.ToLower().Contains("tel") ? report_data.isinfoDbfVM.telnum : "โทร. " + report_data.isinfoDbfVM.telnum;
                rect = str.GetDisplayRect(fnt_header, x + 110, y);
                e.Graphics.DrawString(str, fnt_header, brush, rect, format_left);

                /* item (loop) */
                y += line_height; // new line
                int start_body_y = y;
                int page_item = 0;
                //List<VatTransDbfVM> sal_vattrans = new List<VatTransDbfVM>();
                //List<VatTransDbfVM> pur_vattrans = new List<VatTransDbfVM>();
                //decimal tot_salvat = 0m;
                //decimal tot_purvat = 0m;

                if(item_count < report_data.monthend.Count)
                {
                    Rectangle rect_str_container = new Rectangle(x, y, 200, line_height * 2);
                    e.Graphics.FillRectangle(bg_gray, rect_str_container);
                    e.Graphics.DrawRectangle(p, rect_str_container);
                    e.Graphics.DrawString("รายการ", fnt_bold, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Center });

                    rect_str_container.Y += rect_str_container.Height;
                    rect_str_container.Height = line_height * section_per_product;
                    e.Graphics.DrawRectangle(p, rect_str_container);
                    e.Graphics.DrawString("1. น้ำมันสะสมในถังวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });

                    rect_str_container.Y += rect_str_container.Height;
                    rect_str_container.Height = line_height;
                    e.Graphics.DrawRectangle(p, rect_str_container);
                    e.Graphics.DrawString("2. รวมยอดน้ำมันวัดได้จริงสิ้นงวด", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    rect_str_container.Height = line_height * (7 + max_dother_item);
                    e.Graphics.DrawRectangle(p, rect_str_container);

                    rect_str_container.Height = line_height;
                    e.Graphics.DrawString("3. น้ำมันที่วัดได้จริงต้นงวด", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("4. บวก ยอดรับน้ำมัน", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("5. หัก น้ำมันที่ขายผ่านมิเตอร์ระหว่างเดือน", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("   หัก อื่น ๆ ระบุ =======================>", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height * max_dother_item;
                    e.Graphics.DrawString("6. น้ำมันคงเหลือในบัญชี (3+4-5)", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("7. ผลต่างน้ำมันปัจจุบัน (2-6)", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("8. บวก ผลต่างสะสมยกมา", fnt, brush, rect_str_container, format_left);

                    rect_str_container.Y += rect_str_container.Height;
                    e.Graphics.DrawString("9. ผลต่างสะสมปัจจุบันยกไป (7+8)", fnt, brush, rect_str_container, format_left);

                    Rectangle rect_section = new Rectangle(x, y, 80, line_height);
                    int sub_col_width = Convert.ToInt32(Math.Floor((double)((e.MarginBounds.Right - e.MarginBounds.Left) - rect_str_container.Width) / item_per_page));
                    Rectangle rect_stk = new Rectangle(x, y, sub_col_width - rect_section.Width, line_height);

                    x += rect_str_container.Width;
                    for (int i = item_count; i < report_data.monthend.Count; i++)
                    {
                        page_item++;
                        item_count++;

                        x = e.MarginBounds.Left + rect_str_container.Width + (sub_col_width * (page_item - 1));

                        rect_section.X = x;
                        rect_section.Y = start_body_y;
                        rect_section.Height = line_height * 2;
                        e.Graphics.FillRectangle(bg_gray, rect_section);
                        e.Graphics.DrawRectangle(p, rect_section);
                        e.Graphics.DrawString("เลขที่" + Environment.NewLine + "ถัง", fnt_bold, brush, rect_section, format_center);
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height, rect_section.Width, line_height * section_per_product));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product), rect_section.Width, line_height));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_section.X, rect_section.Y + rect_section.Height + (line_height * section_per_product) + line_height, rect_section.Width, line_height * (7 + max_dother_item)));

                        rect_stk.X = rect_section.X + rect_section.Width;
                        rect_stk.Y = start_body_y;
                        rect_stk.Height = line_height * 2;
                        e.Graphics.FillRectangle(bg_gray, rect_stk);
                        e.Graphics.DrawRectangle(p, rect_stk);
                        e.Graphics.DrawString(report_data.monthend[i].stkcod, fnt_bold, brush, rect_stk, format_center);
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height, rect_stk.Width, line_height * section_per_product));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product), rect_stk.Width, line_height));
                        e.Graphics.DrawRectangle(p, new Rectangle(rect_stk.X, rect_stk.Y + rect_stk.Height + (line_height * section_per_product) + line_height, rect_stk.Width, line_height * (7 + max_dother_item)));

                        for (int j = 0; j < section_per_product; j++)
                        {
                            rect_section.Y += rect_section.Height;
                            rect_section.Height = line_height;
                            string sect = report_data.monthend[i].monthsttakVM.Count > j ? report_data.monthend[i].monthsttakVM[j].section_name : "-";
                            e.Graphics.DrawString(sect, fnt, brush, rect_section, format_center);

                            rect_stk.Y += rect_stk.Height;
                            rect_stk.Height = line_height;
                            string qty = report_data.monthend[i].monthsttakVM.Count > j ? string.Format("{0:#,#0.00}", report_data.monthend[i].monthsttakVM[j].qty) : string.Empty;
                            e.Graphics.DrawString(qty, fnt, brush, rect_stk, format_right);
                        }

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].endbal), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].begbal), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].rcvqty), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].salqty), fnt, brush, rect_stk, format_right);

                        /** dother ********************************/
                        for (int d = 0; d < max_dother_item; d++)
                        {
                            rect_stk.Y += line_height;
                            rect_section.Y = rect_stk.Y;

                            e.Graphics.FillRectangle(bg_lightgray, new Rectangle(rect_section.X + 1, rect_section.Y, rect_section.Width - 2, rect_section.Height));
                            e.Graphics.FillRectangle(bg_lightgray, new Rectangle(rect_stk.X + 1, rect_stk.Y, rect_stk.Width - 2, rect_stk.Height));

                            if (report_data.monthend[i].dother.Count > d)
                            {
                                e.Graphics.DrawString(report_data.monthend[i].dother[d].ToViewModel(this.main_form.working_express_db).typdes, fnt, brush, rect_section);
                                e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].dother[d].qty), fnt, brush, rect_stk, new StringFormat { Alignment = StringAlignment.Far });
                            }
                            else
                            {
                                e.Graphics.DrawString("-", fnt, brush, rect_stk, new StringFormat { Alignment = StringAlignment.Far });
                            }
                        }
                        /******************************************/

                        //rect_stk.Y += rect_stk.Height;
                        //e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].dother), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].accbal), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].difqty), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].begdif), fnt, brush, rect_stk, format_right);

                        rect_stk.Y += rect_stk.Height;
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.monthend[i].begdif + report_data.monthend[i].difqty), fnt, brush, rect_stk, format_right);

                        if (item_count == item_per_page && item_count < report_data.monthend.Count)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                        else
                        {
                            e.HasMorePages = false;
                        }
                    }
                }

                if(report_data.pur_vatdocs.Count > 0)
                {
                    if(printed_vatdoc == -1)
                    {
                        e.HasMorePages = true;
                        printed_vatdoc = 0;
                        return;
                    }

                    //rect.Y += line_height;
                    Rectangle rect_vatdoc_title = new Rectangle(e.MarginBounds.Left, rect.Y + line_height, 400, line_height);
                    e.Graphics.DrawString("ใบจ่ายน้ำมันหรือใบกำกับภาษีขนส่งน้ำมัน", fnt_bold, brush, rect_vatdoc_title);
                    Rectangle rect_seq = new Rectangle(rect_vatdoc_title.X, rect_vatdoc_title.Y + line_height, 30, line_height);
                    Rectangle rect_vatdoc = new Rectangle(rect_seq.X + rect_seq.Width, rect_seq.Y, 85, line_height);
                    Rectangle rect_vatdat = new Rectangle(rect_vatdoc.X + rect_vatdoc.Width, rect_vatdoc.Y, 85, line_height);
                    Rectangle rect_supplier = new Rectangle(rect_vatdat.X + rect_vatdat.Width, rect_vatdat.Y, 190, line_height);
                    Rectangle rect_amt = new Rectangle(rect_supplier.X + rect_supplier.Width, rect_supplier.Y, 80, line_height);
                    Rectangle rect_vatamt = new Rectangle(rect_amt.X + rect_amt.Width, rect_amt.Y, 85, line_height);
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width, rect_seq.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdoc.X, rect_vatdoc.Y, rect_vatdoc.Width, rect_vatdoc.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdat.X, rect_vatdat.Y, rect_vatdat.Width, rect_vatdat.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_supplier.X, rect_supplier.Y, rect_supplier.Width, rect_supplier.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_amt.X, rect_amt.Y, rect_amt.Width, rect_amt.Height));
                    e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatamt.X, rect_vatamt.Y, rect_vatamt.Width, rect_vatamt.Height));

                    e.Graphics.DrawString("ลำดับ", fnt_bold, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("เลขที่", fnt_bold, brush, rect_vatdoc, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("วัน เดือน ปี", fnt_bold, brush, rect_vatdat, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("บริษัทผู้ค้าน้ำมัน", fnt_bold, brush, rect_supplier, new StringFormat { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("จำนวนเงิน(บาท)", fnt_bold, brush, rect_amt, new StringFormat { Alignment = StringAlignment.Far });
                    e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม(บาท)", fnt_bold, brush, rect_vatamt, new StringFormat { Alignment = StringAlignment.Far });

                    e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width, line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_vatdoc.X, rect_vatdoc.Y), new Point(rect_vatdoc.X, rect_vatdoc.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_vatdat.X, rect_vatdat.Y), new Point(rect_vatdat.X, rect_vatdat.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_supplier.X, rect_supplier.Y), new Point(rect_supplier.X, rect_supplier.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_amt.X, rect_amt.Y), new Point(rect_amt.X, rect_amt.Y + line_height + (line_height * vatdoc_item_per_column)));
                    e.Graphics.DrawLine(p, new Point(rect_vatamt.X, rect_vatamt.Y), new Point(rect_vatamt.X, rect_vatamt.Y + line_height + (line_height * vatdoc_item_per_column)));

                    for (int i = printed_vatdoc; i < report_data.pur_vatdocs.Count; i++)
                    {
                        rect_seq.Y += line_height;
                        rect_vatdoc.Y += line_height;
                        rect_vatdat.Y += line_height;
                        rect_supplier.Y += line_height;
                        rect_amt.Y += line_height;
                        rect_vatamt.Y += line_height;

                        e.Graphics.DrawString((i + 1).ToString(), fnt, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawString(report_data.pur_vatdocs[i].docnum, fnt, brush, rect_vatdoc);
                        e.Graphics.DrawString(report_data.pur_vatdocs[i].docdat.ToString("d MMMM yyyy", CultureInfo.GetCultureInfo("th-TH")), fnt, brush, rect_vatdat);
                        e.Graphics.DrawString(report_data.pur_vatdocs[i].people, fnt, brush, rect_supplier);
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.pur_vatdocs[i].netval), fnt, brush, rect_amt, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.pur_vatdocs[i].vatamt), fnt, brush, rect_vatamt, new StringFormat { Alignment = StringAlignment.Far });

                        if ((i + 1) % (vatdoc_item_per_column * 2) == 0)
                        {
                            e.HasMorePages = true;
                            printed_vatdoc++;
                            return;
                        }

                        if ((i + 1) % vatdoc_item_per_column == 0)
                        {
                            rect_seq.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_vatdoc.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_vatdat.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_supplier.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_amt.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_vatamt.X += rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width + 20;
                            rect_seq.Y = rect.Y + (line_height * 2);
                            rect_vatdoc.Y = rect.Y + (line_height * 2);
                            rect_vatdat.Y = rect.Y + (line_height * 2);
                            rect_supplier.Y = rect.Y + (line_height * 2);
                            rect_amt.Y = rect.Y + (line_height * 2);
                            rect_vatamt.Y = rect.Y + (line_height * 2);

                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width, rect_seq.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdoc.X, rect_vatdoc.Y, rect_vatdoc.Width, rect_vatdoc.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatdat.X, rect_vatdat.Y, rect_vatdat.Width, rect_vatdat.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_supplier.X, rect_supplier.Y, rect_supplier.Width, rect_supplier.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_amt.X, rect_amt.Y, rect_amt.Width, rect_amt.Height));
                            e.Graphics.FillRectangle(bg_gray, new Rectangle(rect_vatamt.X, rect_vatamt.Y, rect_vatamt.Width, rect_vatamt.Height));

                            e.Graphics.DrawString("ลำดับ", fnt_bold, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("เลขที่", fnt_bold, brush, rect_vatdoc, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("วัน เดือน ปี", fnt_bold, brush, rect_vatdat, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("บริษัทผู้ค้าน้ำมัน", fnt_bold, brush, rect_supplier, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString("จำนวนเงิน(บาท)", fnt_bold, brush, rect_amt, new StringFormat { Alignment = StringAlignment.Far });
                            e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม(บาท)", fnt_bold, brush, rect_vatamt, new StringFormat { Alignment = StringAlignment.Far });

                            e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect_seq.Y, rect_seq.Width + rect_vatdoc.Width + rect_vatdat.Width + rect_supplier.Width + rect_amt.Width + rect_vatamt.Width, line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_vatdoc.X, rect_vatdoc.Y), new Point(rect_vatdoc.X, rect_vatdoc.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_vatdat.X, rect_vatdat.Y), new Point(rect_vatdat.X, rect_vatdat.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_supplier.X, rect_supplier.Y), new Point(rect_supplier.X, rect_supplier.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_amt.X, rect_amt.Y), new Point(rect_amt.X, rect_amt.Y + line_height + (line_height * vatdoc_item_per_column)));
                            e.Graphics.DrawLine(p, new Point(rect_vatamt.X, rect_vatamt.Y), new Point(rect_vatamt.X, rect_vatamt.Y + line_height + (line_height * vatdoc_item_per_column)));
                        }

                        printed_vatdoc++;
                    }
                }
            };

            return docs;
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_endbal.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    e.Handled = true;
                    return;
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_button_edit.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    Rectangle rect = new Rectangle(e.CellBounds.X - 3, e.CellBounds.Y + 2, 6, e.CellBounds.Height - 3);
                    using (SolidBrush brush = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    using (Pen p = new Pen(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor))
                    {
                        rect = new Rectangle(e.CellBounds.X - this.col_endbal.Width, e.CellBounds.Y, this.col_endbal.Width + e.CellBounds.Width, e.CellBounds.Height);
                        TextRenderer.DrawText(e.Graphics, this.col_endbal.HeaderText, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                    }
                    
                    e.Handled = true;
                    return;
                }

                if(e.ColumnIndex != ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_stkcod.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    using (Pen p = new Pen(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor))
                    {
                        Rectangle rect = new Rectangle(e.CellBounds.X - this.col_endbal.Width, e.CellBounds.Y, this.col_endbal.Width + e.CellBounds.Width, e.CellBounds.Height);
                        TextRenderer.DrawText(e.Graphics, ((XDatagrid)sender).Columns[e.ColumnIndex].HeaderText, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, rect, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                    }
                    e.Handled = true;
                    return;
                }
            }

            if(e.RowIndex > -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_endbal.DataPropertyName).First().Index)
                {
                    var incomplete = this.dayend_list[e.RowIndex].ToViewModel(this.main_form.working_express_db).GetIncompleteDaysttak();
                    if(incomplete.Count > 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Handled = true;
                    }
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_button_edit.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    var w = XPump.Properties.Resources.edit_list_16.Width;
                    var h = XPump.Properties.Resources.edit_list_16.Height;
                    Rectangle rect = new Rectangle(e.CellBounds.X + (int)Math.Floor((decimal)(e.CellBounds.Width - w) / 2), e.CellBounds.Y + (int)Math.Floor((decimal)(e.CellBounds.Height - h) / 2), w, h);
                    e.Graphics.DrawImage(XPump.Properties.Resources.edit_list_16, rect);
                    e.Handled = true;
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_button_edit.Name).First().Index)
            {
                this.ShowEditForm();
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
                this.ShowEditForm();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
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

            if (keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformButtonClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.L))
            {
                this.btnInquiryRest.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.L))
            {
                this.btnInquiryAll.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.P))
            {
                this.btnPrintB.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                this.btnPrintC.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.O))
            {
                this.btnApprove.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.Shift | Keys.O))
            {
                this.btnApproveMulti.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.O))
            {
                this.btnUnApprove.PerformClick();
                return true;
            }

            if (keyData == Keys.Tab)
            {
                if(this.form_mode == FORM_MODE.READ)
                {
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var data_info = db.dayend.Find(this.curr_dayend.id);
                        if (data_info == null)
                            return false;

                        var total_recs = db.dayend.AsEnumerable().Count();

                        DialogDataInfo info = new DialogDataInfo("Dayend", data_info.id, total_recs, data_info.creby, data_info.cretime, data_info.chgby, data_info.chgtime, data_info.apprby, data_info.apprtime, data_info.prnby, data_info.prntime, data_info.prncnt);
                        info.ShowDialog();
                    }
                    
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_button_edit.Name).First().Index)
            {
                e.ToolTipText = "แก้ไข <Alt+E>";
            }
        }
    }
}
