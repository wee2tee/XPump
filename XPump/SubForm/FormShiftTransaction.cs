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
    public partial class FormShiftTransaction : Form
    {
        private MainForm main_form;
        public shiftsales curr_shiftsales;
        private shiftsales tmp_shiftsales;
        private shiftsttak tmp_sttak;
        private List<salessummaryVM> sales_list;
        public salessummary curr_salessummary;
        private BindingSource bs_sales;
        private BindingSource bs_sttak;
        private FORM_MODE form_mode;
        public string menu_id;
        //private List<salessummaryVM> reportAData;
        //private List<salessummaryVM> reportBData;
        //private List<salessummaryVM> reportCData;

        public FormShiftTransaction(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FormShiftTransaction_Load(object sender, EventArgs e)
        {
            this.menu_id = this.GetType().Name;
            this.BackColor = MiscResource.WIND_BG;

            this.bs_sales = new BindingSource();
            this.dgvSalesSummary.DataSource = this.bs_sales;

            this.bs_sttak = new BindingSource();

            this.btnLast.PerformClick();
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();
            this.ActiveControl = this.dgvSalesSummary;
        }

        private void ResetControlState()
        {
            /* Toolstrip button */
            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.READ_ITEM, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrint.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrintALandscape.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            //this.btnItemF7.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnItem.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnApprove.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnUnApprove.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.brShift.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtSaldat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dgvSalesSummary.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
            this.btnSttak.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            this.ResetApproveBtn();

            /*Form control state depend on data*/
            if (this.form_mode == FORM_MODE.READ)
            {
                this.btnEdit.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnDelete.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnFirst.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnPrevious.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnNext.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnLast.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnSearch.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnInquiryAll.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnInquiryRest.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnPrint.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnPrintALandscape.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnItem.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnApprove.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnUnApprove.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                //this.btnRefresh.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;
                this.btnSttak.Enabled = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? false : true;

                this.dtSaldat._SelectedDate = this.curr_shiftsales == null || this.curr_shiftsales.id == -1 ? null : (DateTime?)this.curr_shiftsales.saldat;

                this.ResetApproveBtn();
            }
        }

        private void ResetApproveBtn()
        {
            if (this.form_mode == FORM_MODE.READ)
            {
                this.btnApprove.Enabled = this.curr_shiftsales != null && this.curr_shiftsales.id != -1 && !this.curr_shiftsales.apprtime.HasValue ? true : false;
                this.btnUnApprove.Enabled = this.curr_shiftsales != null && this.curr_shiftsales.id != -1 && this.curr_shiftsales.apprtime.HasValue ? true : false;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        public shiftsales GetShiftSales(int id)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.shiftsales.Include("salessummary").Include("shift").Include("shiftsttak").Where(s => s.id == id).FirstOrDefault();
            }
        }

        private shiftsales GetFirst()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.shiftsales.Include("salessummary").Include("shift").Include("shiftsttak").OrderBy(s => s.saldat).ThenBy(s => s.id).FirstOrDefault();
            }
        }

        private shiftsales GetPrevious()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if (db.shiftsales.Count() == 0)
                    return null;


                if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return this.GetFirst();


                var id_list = db.shiftsales.OrderBy(s => s.saldat).ThenBy(s => s.id).Select(s => s.id).ToList<int>();

                if (id_list.IndexOf(this.curr_shiftsales.id) == -1)
                {
                    shiftsales tmp = db.shiftsales.Include("salessummary").Include("shift").Include("shiftsttak").OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).Where(s => this.curr_shiftsales.saldat.CompareTo(s.saldat) == 0 || this.curr_shiftsales.saldat.CompareTo(s.saldat) > 0).FirstOrDefault();

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
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if (db.shiftsales.Count() == 0)
                    return null;

                if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return this.GetLast();

                var id_list = db.shiftsales.OrderBy(s => s.saldat).ThenBy(s => s.id).Select(s => s.id).ToList<int>();

                if (id_list.IndexOf(this.curr_shiftsales.id) == -1)
                {
                    shiftsales tmp = db.shiftsales.Include("salessummary").Include("shift").Include("shiftsttak").OrderBy(s => s.saldat).ThenBy(s => s.id).Where(s => this.curr_shiftsales.saldat.CompareTo(s.saldat) == 0 || this.curr_shiftsales.saldat.CompareTo(s.saldat) < 0).FirstOrDefault();

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
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                return db.shiftsales.Include("salessummary").Include("shift").Include("shiftsttak").OrderByDescending(s => s.saldat).ThenByDescending(s => s.id).FirstOrDefault();
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
                this.dgvSalesSummary.Rows.Clear();
                return;
            }

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.brShift._Text = db.shift.Find(sales.shift_id) != null ? db.shift.Find(sales.shift_id).name : string.Empty;
                var x = db.dayend.Where(d => d.saldat == sales.saldat).FirstOrDefault();
                this.lblDayEnded.Visible = db.dayend.Where(d => d.saldat == sales.saldat).FirstOrDefault() == null ? false : true;
            }

            if(this.form_mode == FORM_MODE.READ)
            {
                this.dtSaldat._SelectedDate = sales.id == -1 ? null : (DateTime?)sales.saldat;
            }
            if(this.form_mode == FORM_MODE.ADD)
            {
                this.dtSaldat._SelectedDate = sales.saldat;
            }

            this.sales_list = sales.salessummary.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.stkcod).ToList();
            this.bs_sales.ResetBindings(true);
            this.bs_sales.DataSource = this.sales_list;

            this.bs_sttak.ResetBindings(true);
            this.bs_sttak.DataSource = sales.shiftsttak.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.tank_name).ThenBy(s => s.section_name).ToList();

            this.ValidateSttak();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tmp_shiftsales = new shiftsales
            {
                id = -1,
                saldat = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture), CultureInfo.CurrentCulture),
                shift_id = -1,
                closed = false,
            };

            this.dgvSalesSummary.Rows.Clear();
            this.tabControl1.SelectedTab = this.tabPage1;
            this.form_mode = FORM_MODE.ADD;
            this.ResetControlState();

            this.FillForm(this.tmp_shiftsales);
            this.toolStrip1.Focus();
            this.dtSaldat.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            if (this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
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

            if (this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
                return;

            if(MessageBox.Show("ลบบันทึกรายการขายประจำผลัด \"" + this.curr_shiftsales.shift.name + "\" วันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + ", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        foreach (var d in db.dother.Include("salessummary").Where(d => d.salessummary.shiftsales_id == this.curr_shiftsales.id))
                        {
                            db.dother.Remove(d);
                        }

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

                        foreach (var item in db.shiftsttak.Where(st => st.shiftsales_id == this.curr_shiftsales.id).ToList())
                        {
                            db.shiftsttak.Remove(db.shiftsttak.Find(item.id));
                        }

                        var shiftsales_to_delete = db.shiftsales.Find(this.curr_shiftsales.id);
                        var shift_name = shiftsales_to_delete.ToViewModel(this.main_form.working_express_db).shift_name;
                        db.shiftsales.Remove(shiftsales_to_delete);
                        db.SaveChanges();

                        this.main_form.islog.AddData(this.menu_id, "ลบบันทึกรายการประจำผลัด \"" + shift_name + "\" วันที่ " + shiftsales_to_delete.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), shiftsales_to_delete.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + shift_name, "shiftsales", shiftsales_to_delete.id).Save();

                        this.btnRefresh.PerformClick();
                        this.ResetControlState();
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

            this.tmp_shiftsales = null;
            this.FillForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tmp_shiftsales.shift_id == -1)
            {
                this.brShift.Focus();
                SendKeys.Send("{F6}");
                return;
            }

            if (this.form_mode == FORM_MODE.ADD)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    if(db.shiftsales.Where(s => s.saldat == this.tmp_shiftsales.saldat && s.shift_id == this.tmp_shiftsales.shift_id).Count() > 0)
                    {
                        MessageBox.Show("รายการวันที่ \"" + this.tmp_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + "\" ของผลัด \"" + db.shift.Find(this.tmp_shiftsales.shift_id).name + "\" มีอยู่แล้ว, ไม่สามารถบันทึกซ้ำได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var tanksetup = db.tanksetup.OrderByDescending(t => t.startdate).Where(t => t.startdate.CompareTo(this.tmp_shiftsales.saldat) <= 0).FirstOrDefault();

                    if (tanksetup == null)
                    {
                        MessageBox.Show("ไม่พบการตั้งค่าแท๊งค์เก็บน้ำมันที่เริ่มใช้วันที่ " + this.tmp_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var stkcods = db.section.Include("nozzle").Include("tank").Include("tank.tanksetup")
                                    //.Where(s => s.tank.tanksetup.startdate.CompareTo(this.tmp_shiftsales.saldat) <= 0)
                                    .Where(s => s.tank.tanksetup_id == tanksetup.id)
                                    .GroupBy(s => s.stkcod)
                                    .Select(s => s.Key).ToArray();

                    DialogPrice price = new DialogPrice(this.main_form, stkcods, this.tmp_shiftsales.saldat);
                    if (price.ShowDialog() != DialogResult.OK)
                        return;

                    try
                    {
                        if (db.dayend.Where(d => d.saldat == this.tmp_shiftsales.saldat).FirstOrDefault() != null)
                        {
                            MessageBox.Show("วันที่ " + this.tmp_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + " ปิดยอดขายประจำวันไปแล้ว ไม่สามารถเพิ่มรายการของวันที่นี้ได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        this.tmp_shiftsales.creby = this.main_form.loged_in_status.loged_in_user_name;
                        this.tmp_shiftsales.cretime = DateTime.Now;
                        db.shiftsales.Add(this.tmp_shiftsales);

                        foreach (string stkcod in stkcods)
                        {
                            // add salessummary
                            var salessummary = new salessummary
                            {
                                saldat = this.tmp_shiftsales.saldat,
                                stkcod = stkcod,
                                pricelist_id = price.price_list.Where(p => p.stkcod == stkcod).First().id,
                                dtest = 0m,
                                ddisc = 0m,
                                purvat = 0m,
                                shiftsales_id = this.tmp_shiftsales.id,
                                creby = this.main_form.loged_in_status.loged_in_user_name,
                                cretime = DateTime.Now
                            };
                            db.salessummary.Add(salessummary);

                            // add sttak
                            var sections = db.section.Include("tank")
                                            .Where(sect => sect.tank.tanksetup_id == tanksetup.id)
                                            .Where(sect => sect.stkcod == stkcod).ToList();
                            foreach (var item in sections)
                            {
                                db.shiftsttak.Add(new shiftsttak
                                {
                                    takdat = this.tmp_shiftsales.saldat,
                                    qty = -1,
                                    section_id = item.id,
                                    shiftsales_id = this.tmp_shiftsales.id,
                                    creby = this.main_form.loged_in_status.loged_in_user_name,
                                    cretime = DateTime.Now
                                });
                            }

                            //var sales = (salessummary)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_salessummary.Name].Value;

                            /*************/
                            if (tanksetup == null)
                            {
                                MessageBox.Show("ไม่พบการกำหนดค่าแท๊งค์เก็บน้ำมัน สำหรับการขายในวันที่ \"" + this.curr_salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            var nozz = db.nozzle.Include("section").Include("section.tank").Where(n => n.section.tank.tanksetup_id == tanksetup.id && n.section.stkcod == salessummary.stkcod && n.isactive).ToList();

                            try
                            {
                                foreach (var n in nozz)
                                {
                                    if (db.saleshistory.Where(s => s.salessummary_id == salessummary.id && s.nozzle_id == n.id).Count() > 0)
                                        continue;

                                    db.saleshistory.Add(new saleshistory
                                    {
                                        saldat = salessummary.saldat,
                                        mitbeg = -1m,
                                        mitend = -1m,
                                        salqty = 0m,
                                        nozzle_id = n.id,
                                        salessummary_id = salessummary.id,
                                        creby = this.main_form.loged_in_status.loged_in_user_name,
                                        cretime = DateTime.Now
                                    });

                                    db.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                        db.SaveChanges();

                        this.main_form.islog.AddData(this.menu_id, "เพิ่มบันทึกรายการประจำผลัด \"" + this.tmp_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + "\" วันที่ " + this.tmp_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), this.tmp_shiftsales.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.tmp_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", this.tmp_shiftsales.id).Save();

                        this.curr_shiftsales = this.GetShiftSales(this.tmp_shiftsales.id);
                        this.FillForm();
                        this.form_mode = FORM_MODE.READ;
                        this.ResetControlState();
                        this.dgvSalesSummary.Focus();
                        this.tmp_shiftsales = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                return;
            }

            if (this.form_mode == FORM_MODE.EDIT)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    try
                    {
                        shiftsales shiftsales_to_update = db.shiftsales.Find(this.tmp_shiftsales.id);
                        if (shiftsales_to_update == null)
                        {
                            MessageBox.Show("ค้นหารายการเพื่อทำการแก้ไขไม่พบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        shiftsales_to_update.saldat = this.tmp_shiftsales.saldat;
                        shiftsales_to_update.shift_id = this.tmp_shiftsales.shift_id;

                        foreach (var item in db.salessummary.Where(s => s.shiftsales_id == shiftsales_to_update.id).ToList())
                        {
                            item.saldat = this.tmp_shiftsales.saldat;
                            //item.shift_id = this.tmp_shiftsales.shift_id;

                            foreach (var sh in db.saleshistory.Where(s => s.salessummary_id == item.id).ToList())
                            {
                                sh.saldat = this.tmp_shiftsales.saldat;
                                //sh.shift_id = this.tmp_shiftsales.shift_id;
                            }
                        }

                        foreach (var item in db.shiftsttak.Where(s => s.shiftsales_id == shiftsales_to_update.id).ToList())
                        {
                            item.takdat = this.tmp_shiftsales.saldat;
                        }

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
            var tmp = this.GetFirst();

            if(tmp != null)
            {
                this.curr_shiftsales = tmp;
            }
            else
            {
                this.curr_shiftsales = new shiftsales
                {
                    id = -1,
                    saldat = DateTime.Now,
                    shift_id = -1
                };
            }

            this.curr_shiftsales = this.GetFirst();
            this.FillForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var tmp = this.GetPrevious();

            if(tmp != null)
            {
                this.curr_shiftsales = tmp;
                this.FillForm();
            }
            else
            {
                this.btnFirst.PerformClick();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var tmp = this.GetNext();

            if(tmp != null)
            {
                this.curr_shiftsales = tmp;
                this.FillForm();
            }
            else
            {
                this.btnLast.PerformClick();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            var tmp = this.GetLast();

            if(tmp != null)
            {
                this.curr_shiftsales = tmp;
            }
            else
            {
                this.curr_shiftsales = new shiftsales
                {
                    id = -1,
                    saldat = DateTime.Now,
                    shift_id = -1
                };
            }

            this.FillForm();
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            DialogSearchShiftTransaction search = new DialogSearchShiftTransaction(this.main_form);
            if(search.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var tmp = db.shiftsales.Where(s => s.saldat == search.selected_date.Value && s.shift_id == search.selected_shift_id).FirstOrDefault();
                    
                    if(tmp != null)
                    {
                        this.curr_shiftsales = this.GetShiftSales(tmp.id);
                        this.FillForm();
                    }
                    else
                    {
                        MessageBox.Show("ค้นหาข้อมูลตามที่ระบุไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            col_saldat.HeaderText = "วันที่";
            col_saldat.Name = "col_saldat";
            col_saldat.DataPropertyName = "saldat";
            col_saldat.MinimumWidth = 80;
            col_saldat.Width = 80;
            cols.Add(col_saldat);

            DataGridViewColumn col_shift_name = new DataGridViewTextBoxColumn();
            col_shift_name.HeaderText = "ผลัด";
            col_shift_name.DataPropertyName = "shift_name";
            col_shift_name.MinimumWidth = 60;
            col_shift_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cols.Add(col_shift_name);

            DataGridViewColumn col_closed = new DataGridViewTextBoxColumn();
            col_closed.HeaderText = "Closed";
            col_closed.DataPropertyName = "closed";
            col_closed.Visible = false;
            cols.Add(col_closed);

            DataGridViewColumn col__closed = new DataGridViewTextBoxColumn();
            col__closed.HeaderText = "สถานะ";
            col__closed.DataPropertyName = "_closed";
            col__closed.MinimumWidth = 130;
            col__closed.Width = 130;
            cols.Add(col__closed);

            DataGridViewColumn col_creby = new DataGridViewTextBoxColumn();
            col_creby.HeaderText = "เพิ่มโดย";
            col_creby.DataPropertyName = "creby";
            col_creby.MinimumWidth = 120;
            col_creby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cols.Add(col_creby);

            DataGridViewColumn col_cretime = new DataGridViewTextBoxColumn();
            col_cretime.HeaderText = "เพิ่มเมื่อ";
            col_cretime.DataPropertyName = "cretime";
            col_cretime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col_cretime.Width = 140;
            col_cretime.MinimumWidth = 140;
            cols.Add(col_cretime);

            DataGridViewColumn col_chgby = new DataGridViewTextBoxColumn();
            col_chgby.HeaderText = "บันทึกล่าสุดโดย";
            col_chgby.DataPropertyName = "chgby";
            col_chgby.MinimumWidth = 120;
            col_chgby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cols.Add(col_chgby);

            DataGridViewColumn col_chgtime = new DataGridViewTextBoxColumn();
            col_chgtime.HeaderText = "บันทึกล่าสุดเมื่อ";
            col_chgtime.DataPropertyName = "chgtime";
            col_chgtime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col_chgtime.Width = 140;
            col_chgtime.MinimumWidth = 140;
            cols.Add(col_chgtime);

            DataGridViewColumn col_apprby = new DataGridViewTextBoxColumn();
            col_apprby.HeaderText = "รับรองโดย";
            col_apprby.DataPropertyName = "apprby";
            col_apprby.MinimumWidth = 120;
            col_apprby.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_apprby.Visible = false;
            cols.Add(col_apprby);

            DataGridViewColumn col_apprtime = new DataGridViewTextBoxColumn();
            col_apprtime.HeaderText = "รับรองเมื่อ";
            col_apprtime.DataPropertyName = "apprtime";
            col_apprtime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col_apprtime.Visible = false;
            cols.Add(col_apprtime);

            DataGridViewColumn col_shift_id = new DataGridViewTextBoxColumn();
            col_shift_id.HeaderText = "Shift Id";
            col_shift_id.DataPropertyName = "shift_id";
            col_shift_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_shift_id.Visible = false;
            cols.Add(col_shift_id);

            DataGridViewColumn col_shiftsales = new DataGridViewTextBoxColumn();
            col_shiftsales.HeaderText = "Shiftsales";
            col_shiftsales.DataPropertyName = "shiftsales";
            col_shiftsales.Visible = false;
            cols.Add(col_shiftsales);

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
                var shiftsales = db.shiftsales.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.saldat).ThenBy(s => s.shift_name).ToList<dynamic>();
                var col_search_key = cols.Where(c => c.Name == "col_id").FirstOrDefault();
                DialogInquiry inq = new DialogInquiry(shiftsales, cols, col_search_key, null, false);

                if (inq.ShowDialog() == DialogResult.OK)
                {
                    var id = (int)inq.selected_row.Cells["col_id"].Value;
                    this.curr_shiftsales = this.GetShiftSales(id);
                    this.FillForm();
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            var cols = this.GetInquiryDgvColumns();

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var shiftsales = db.shiftsales.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.saldat).ThenBy(s => s.shift_name).ToList<dynamic>();
                var col_search_key = cols.Where(c => c.Name == "col_id").FirstOrDefault();
                DialogInquiry inq = new DialogInquiry(shiftsales, cols, col_search_key, this.curr_shiftsales.id, false);

                if (inq.ShowDialog() == DialogResult.OK)
                {
                    var id = (int)inq.selected_row.Cells["col_id"].Value;
                    this.curr_shiftsales = this.GetShiftSales(id);
                    this.FillForm();
                }
            }
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

        private void btnPrintALandscape_Click(object sender, EventArgs e)
        {
            DialogPrintSetupA print = new DialogPrintSetupA();
            if (print.ShowDialog() == DialogResult.OK)
            {
                settings settings = DialogSettings.GetSettings(this.main_form.working_express_db);

                var report_data = new ReportAModel(this.curr_shiftsales, this.main_form.working_express_db);
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_A(report_data, true));
                if (print.output == PRINT_OUTPUT.SCREEN)
                {
                    var print_auth_state = this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).GetPrintAuthorizeState();
                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_A(report_data, true, total_page), total_page, print_auth_state);
                    xp.MdiParent = this.main_form;
                    xp._OnOutputToPrinter += delegate
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var shiftsales_to_update = db.shiftsales.Find(this.curr_shiftsales.id);
                            if (shiftsales_to_update != null)
                            {
                                shiftsales_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                                shiftsales_to_update.prntime = DateTime.Now;
                                shiftsales_to_update.prncnt += 1;

                                db.SaveChanges();
                            }
                        }
                        this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ก. ของวันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " (" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + ") ออกทางเครื่องพิมพ์", this.curr_shiftsales.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", this.curr_shiftsales.id).Save();
                    };
                    xp.Show();
                }

                if (print.output == PRINT_OUTPUT.PRINTER)
                {
                    if (this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).IsPrintableShiftSales() != true)
                        return;

                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_A(report_data, true, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var shiftsales_to_update = db.shiftsales.Find(this.curr_shiftsales.id);
                            if(shiftsales_to_update != null)
                            {
                                shiftsales_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                                shiftsales_to_update.prntime = DateTime.Now;
                                shiftsales_to_update.prncnt += 1;

                                db.SaveChanges();
                            }
                        }
                        this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ก. ของวันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " (" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + ") ออกทางเครื่องพิมพ์", this.curr_shiftsales.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", this.curr_shiftsales.id).Save();

                        pd.Document.Print();
                    }
                }
            }
        }

        private void btnPrintAPortrait_Click(object sender, EventArgs e)
        {
            DialogPrintSetupA print = new DialogPrintSetupA();
            if (print.ShowDialog() == DialogResult.OK)
            {
                var report_data = new ReportAModel(this.curr_shiftsales, this.main_form.working_express_db);
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_A(report_data, false));
                if (print.output == PRINT_OUTPUT.SCREEN)
                {
                    var print_auth_state = this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).GetPrintAuthorizeState();
                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_A(report_data, false, total_page), total_page, print_auth_state);
                    xp.MdiParent = this.main_form;
                    xp._OnOutputToPrinter += delegate
                    {
                        this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ก. ของวันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " (" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + ") ออกทางเครื่องพิมพ์", this.curr_shiftsales.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", this.curr_shiftsales.id).Save();
                    };
                    xp.Show();
                }

                if (print.output == PRINT_OUTPUT.PRINTER)
                {
                    if (this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).IsPrintableShiftSales() != true)
                        return;

                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_A(report_data, false, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var shiftsales_to_update = db.shiftsales.Find(this.curr_shiftsales.id);
                            if (shiftsales_to_update != null)
                            {
                                shiftsales_to_update.prnby = this.main_form.loged_in_status.loged_in_user_name;
                                shiftsales_to_update.prntime = DateTime.Now;
                                shiftsales_to_update.prncnt += 1;

                                db.SaveChanges();
                            }
                        }
                        this.main_form.islog.Print(this.menu_id, "พิมพ์รายงานส่วน ก. ของวันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " (" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name + ") ออกทางเครื่องพิมพ์", this.curr_shiftsales.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", this.curr_shiftsales.id).Save();

                        pd.Document.Print();
                    }
                }
            }
        }

        private void btnPrintB_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPrintC_Click(object sender, EventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            //if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
            //    return;

            //this.form_mode = FORM_MODE.READ_ITEM;
            //this.ResetControlState();
            //this.dgvSalesSummary.Focus();
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
                DialogShiftSelector sel = new DialogShiftSelector(this.main_form, this.tmp_shiftsales.shift_id);
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

                //((XBrowseBox)sender).Focus();
            }
            else
            {
                string txt = ((XBrowseBox)sender)._Text.Trim();
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var shift = db.shift.Where(s => s.name == txt).FirstOrDefault();

                    if (shift != null)
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

                //shift shift = DialogShiftSelector.GetShiftList().Where(s => s.name == txt).FirstOrDefault();
            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM))
            {
                int row_index = ((XDatagrid)sender).HitTest(e.X, e.Y).RowIndex;

                if (row_index == -1)
                    return;

                //this.form_mode = FORM_MODE.READ_ITEM;
                //this.ResetControlState();

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_stkcod.Name].Selected = true;
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_sales = new MenuItem();
                mnu_sales.Text = "แก้ไขรายละเอียดการขาย <Alt+E>";
                mnu_sales.Click += delegate
                {
                    this.ShowSalesForm();
                    return;
                };
                cm.MenuItems.Add(mnu_sales);

                MenuItem mnu_price = new MenuItem();
                mnu_price.Text = "แก้ไขราคาขาย <Ctrl+E>";
                mnu_price.Click += delegate
                {
                    this.ShowEditPrice();
                    return;
                };
                cm.MenuItems.Add(mnu_price);

                cm.Show((XDatagrid)sender, new Point(e.X, e.Y));
            }
        }

        private void PerformEdit(object sender, EventArgs e)
        {
            this.btnEdit.PerformClick();

            ((Control)sender).Focus();
        }

        private PrintDocument PreparePrintDoc_A(ReportAModel report_data, bool landscape = true, int total_page = 0)
        {
            Font fnt_title_bold = new Font("angsana new", 12f, FontStyle.Bold);
            Font fnt_header_bold = new Font("angsana new", 11f, FontStyle.Bold); // tahoma 8f bold
            Font fnt_header = new Font("angsana new", 11f, FontStyle.Regular); // tahoma 8f
            Font fnt_bold = new Font("angsana new", 10f, FontStyle.Bold); // tahoma 7f bold
            Font fnt = new Font("angsana new", 10f, FontStyle.Regular); // tahoma 7f
            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush bg_gray = new SolidBrush(Color.Silver);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;
            int item_per_page = landscape ? 4 : 3;
            int max_dother_item = 5;
            int printed_vatdoc = -1;
            int vatdoc_item_per_column = 33;
            int vatdoc_item_page = vatdoc_item_per_column * 3;


            PrintDocument docs = new PrintDocument();
            //PaperSize ps = new PaperSize();
            //ps.RawKind = (int)PaperKind.A4;
            //docs.DefaultPageSettings.PaperSize = ps;
            docs.DefaultPageSettings.Margins = new Margins(20, 20, 30, 30);
            docs.DefaultPageSettings.Landscape = landscape;
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
                int line_height = fnt_header.Height - 2;

                page++;

                //if(page < docs.PrinterSettings.FromPage || page > docs.PrinterSettings.ToPage)
                //{
                    
                //}


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

                str = "[ส่วน ก]";
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
                //var svat_trans = report_data.shsvattransVM.Concat(report_data.sivvattransVM).GroupBy(s => s.docnum);
                //List<VatTransDbfVM> sal_vattrans = new List<VatTransDbfVM>();
                //foreach (var item in svat_trans)
                //{
                //    var svat = new VatTransDbfVM
                //    {
                //        docnum = item.First().docnum,
                //        docdat = item.First().docdat,
                //        people = item.First().people,
                //        stkcod = item.First().stkcod,
                //        netval = item.Sum(s => s.netval),
                //        vatamt = item.Sum(s => s.vatamt)
                //    };
                //    sal_vattrans.Add(svat);
                //}

                //List<VatTransDbfVM> sal_vattrans = report_data.shsvattransVM
                //                                    .Concat(report_data.sivvattransVM)
                //                                    .OrderBy(v => v.docdat).ThenBy(v => v.docnum).ToList();
                List<VatTransDbfVM> pur_vattrans = report_data.phpvattransVM
                                                    .Concat(report_data.prrvattransVM)
                                                    .OrderBy(v => v.docdat).ThenBy(v => v.docnum).ToList();
                
                decimal tot_salvat = 0m;
                decimal tot_purvat = 0m;

                for (int i = item_count; i < report_data.salessummaryVM_list.Count; i++)
                {
                    page_item++;
                    item_count++;

                    Point block_begin_point = new Point((((e.MarginBounds.Right - e.MarginBounds.Left) / item_per_page) * (page_item - 1)) + e.MarginBounds.Left, y);
                    Point block_end_point = new Point(((e.MarginBounds.Right - e.MarginBounds.Left)/item_per_page) + block_begin_point.X, y);

                    x = block_begin_point.X;

                    int rect_noz_width = Convert.ToInt32((block_end_point.X - block_begin_point.X) - (Math.Ceiling((block_end_point.X - block_begin_point.X) *.21) * 4));
                    //int sub_block_widht = (int)Math.Floor((decimal)rect_stkcod.Width / 4);
                    int sub_block_width = Convert.ToInt32( Math.Ceiling((block_end_point.X - block_begin_point.X) * .21));
                    Rectangle rect_noz = new Rectangle(x, y, rect_noz_width, line_height * 3);
                    e.Graphics.FillRectangle(bg_gray, rect_noz);
                    e.Graphics.DrawRectangle(p, rect_noz);
                    e.Graphics.DrawString("หัว" + Environment.NewLine + "จ่าย" + Environment.NewLine + "เลขที่", fnt_bold, brush, rect_noz, new StringFormat { Alignment = StringAlignment.Center });

                    Rectangle rect_stkcod = new Rectangle(x + rect_noz.Width, y, block_end_point.X - (x + rect_noz.Width), line_height);
                    str = report_data.salessummaryVM_list[i].stkcod;
                    e.Graphics.FillRectangle(bg_gray, rect_stkcod);
                    e.Graphics.DrawRectangle(p, rect_stkcod);
                    e.Graphics.DrawString(str, fnt_bold, brush, rect_stkcod, format_center);

                    
                    Rectangle rect_mitbeg = new Rectangle(rect_stkcod.X, block_begin_point.Y + line_height, sub_block_width, line_height * 2);
                    e.Graphics.FillRectangle(bg_gray, rect_mitbeg);
                    e.Graphics.DrawRectangle(p, rect_mitbeg);
                    e.Graphics.DrawString("มิเตอร์" + Environment.NewLine + "เริ่มต้น", fnt_bold, brush, rect_mitbeg, new StringFormat { Alignment = StringAlignment.Center });

                    Rectangle rect_mitend = new Rectangle(rect_mitbeg.X + rect_mitbeg.Width, block_begin_point.Y + line_height, sub_block_width, line_height * 2);
                    e.Graphics.FillRectangle(bg_gray, rect_mitend);
                    e.Graphics.DrawRectangle(p, rect_mitend);
                    e.Graphics.DrawString("มิเตอร์" + Environment.NewLine + "สิ้นสุด", fnt_bold, brush, rect_mitend, new StringFormat { Alignment = StringAlignment.Center });

                    Rectangle rect_salqty = new Rectangle(rect_mitend.X + rect_mitend.Width, block_begin_point.Y + line_height, sub_block_width, line_height * 2);
                    e.Graphics.FillRectangle(bg_gray, rect_salqty);
                    e.Graphics.DrawRectangle(p, rect_salqty);
                    e.Graphics.DrawString("ปริมาณ" + Environment.NewLine + "ขาย(ลิตร)", fnt_bold, brush, rect_salqty, new StringFormat { Alignment = StringAlignment.Center });

                    Rectangle rect_salval = new Rectangle(rect_salqty.X + rect_salqty.Width, block_begin_point.Y + line_height, sub_block_width, line_height * 2);
                    e.Graphics.FillRectangle(bg_gray, rect_salval);
                    e.Graphics.DrawRectangle(p, rect_salval);
                    e.Graphics.DrawString("มูลค่า" + Environment.NewLine + "ขาย(บาท)", fnt_bold, brush, rect_salval, new StringFormat { Alignment = StringAlignment.Center });

                    rect_noz.Height = line_height;
                    rect_mitbeg.Height = line_height;
                    rect_mitend.Height = line_height;
                    rect_salqty.Height = line_height;
                    rect_salval.Height = line_height;

                    rect_noz.Y += line_height * 3;
                    rect_mitbeg.Y += line_height * 2;
                    rect_mitend.Y += line_height * 2;
                    rect_salqty.Y += line_height * 2;
                    rect_salval.Y += line_height * 2;

                    var sales_history = report_data.saleshistoryVM_list.Where(s => s.salessummary_id == report_data.salessummaryVM_list[i].id).OrderBy(s => s.nozzle_name).ToList();
                    int nozz_count = landscape ? 20/*12*/ : 30;
                    for (int j = 0; j < nozz_count; j++)
                    {
                        e.Graphics.FillRectangle(bg_gray, rect_noz);
                        e.Graphics.DrawRectangle(p, rect_noz);

                        e.Graphics.DrawRectangle(p, rect_mitbeg);

                        e.Graphics.DrawRectangle(p, rect_mitend);

                        e.Graphics.DrawRectangle(p, rect_salqty);

                        e.Graphics.DrawRectangle(p, rect_salval);

                        if(sales_history.Count > j)
                        {
                            e.Graphics.DrawString(sales_history[j].nozzle_name, fnt, brush, rect_noz, new StringFormat { Alignment = StringAlignment.Center });
                            e.Graphics.DrawString(sales_history[j].mitbeg.FormatCurrency(), fnt, brush, rect_mitbeg, new StringFormat { Alignment = StringAlignment.Far });
                            e.Graphics.DrawString(sales_history[j].mitend.FormatCurrency(), fnt, brush, rect_mitend, new StringFormat { Alignment = StringAlignment.Far });
                            e.Graphics.DrawString(sales_history[j].salqty.FormatCurrency(), fnt, brush, rect_salqty, new StringFormat { Alignment = StringAlignment.Far });
                            e.Graphics.DrawString(sales_history[j].salval.FormatCurrency(), fnt, brush, rect_salval, new StringFormat { Alignment = StringAlignment.Far });
                        }

                        rect_noz.Y += line_height;
                        rect_mitbeg.Y += line_height;
                        rect_mitend.Y += line_height;
                        rect_salqty.Y += line_height;
                        rect_salval.Y += line_height;
                    }

                    /* Summary line start */
                    x = block_begin_point.X;
                    Rectangle rect_total_txt = new Rectangle(x, rect_noz.Y, rect_noz.Width + rect_mitbeg.Width + rect_mitend.Width, line_height);
                    e.Graphics.DrawString("  1.รวม", fnt_bold, brush, rect_total_txt);

                    Rectangle rect_qty = new Rectangle(x + rect_total_txt.Width, rect_salqty.Y, rect_salqty.Width, line_height * (7 + max_dother_item));
                    e.Graphics.DrawRectangle(p, rect_qty);

                    Rectangle rect_val = new Rectangle(rect_qty.X + rect_qty.Width, rect_salval.Y, rect_salval.Width, line_height * (7 + max_dother_item));
                    e.Graphics.DrawRectangle(p, rect_val);

                    Rectangle rect_total = new Rectangle(rect_salqty.X, rect_total_txt.Y, rect_salqty.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].total.FormatCurrency(), fnt, brush, rect_total, new StringFormat { Alignment = StringAlignment.Far});

                    Rectangle rect_dtest_txt = new Rectangle(x, rect_total_txt.Y + line_height, rect_total_txt.Width, line_height);
                    e.Graphics.DrawString("  2.หักยอดขายน้ำมันทดสอบ", fnt_bold, brush, rect_dtest_txt);

                    Rectangle rect_dtest = new Rectangle(rect_salqty.X, rect_dtest_txt.Y, rect_total.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].dtest.FormatCurrency(), fnt, brush, rect_dtest, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_dother_txt = new Rectangle(x + 12, rect_dtest_txt.Y + line_height, rect_dtest_txt.Width, line_height);
                    //e.Graphics.DrawString("หักอื่น ๆ ระบุ ______________________", fnt_bold, brush, rect_dother_txt);
                    //e.Graphics.DrawRectangle(new Pen(Color.Red), rect_dother_txt);
                    e.Graphics.DrawString("หักอื่น ๆ ระบุ", fnt_bold, brush, rect_dother_txt);

                    rect_dother_txt.X += 50;
                    rect_dother_txt.Width = rect_noz.Width + rect_mitbeg.Width + rect_mitend.Width - 50 - 16;
                    //foreach (var d in report_data.salessummaryVM_list[i].dother_list)
                    //{
                    //    e.Graphics.DrawString(d.ToViewModel(this.main_form.working_express_db).typcod, fnt, brush, rect_dother_txt);
                    //    rect_dother_txt.Y += line_height;
                    //}

                    for (int r = 0; r < max_dother_item/*4*/; r++)
                    {
                        Rectangle rect_dother = new Rectangle(rect_salqty.X, rect_dother_txt.Y, rect_total.Width, line_height);
                        if (report_data.salessummaryVM_list[i].dother_list.Count > r)
                        {
                            e.Graphics.DrawString(report_data.salessummaryVM_list[i].dother_list[r].ToViewModel(this.main_form.working_express_db).typdes, fnt, brush, rect_dother_txt);

                            e.Graphics.DrawString(report_data.salessummaryVM_list[i].dother_list[r].qty.FormatCurrency(), fnt, brush, rect_dother, new StringFormat { Alignment = StringAlignment.Far });
                        }
                        else
                        {
                            e.Graphics.DrawString("-", fnt, brush, rect_dother, new StringFormat { Alignment = StringAlignment.Far });
                        }

                        e.Graphics.DrawLine(p, new Point(rect_dother_txt.X, rect_dother_txt.Y + rect_dother_txt.Height - 2), new Point(rect_dother_txt.X + rect_dother_txt.Width, rect_dother_txt.Y + rect_dother_txt.Height - 2));

                        if(r < max_dother_item - 1/*3*/)
                        {
                            rect_dother_txt.Y += line_height;
                            rect_dother.Y += line_height;
                        }
                    }
                    //e.Graphics.DrawString(report_data.salessummaryVM_list[i].dothertxt, fnt_bold, brush, rect_dother_txt);

                    //Rectangle rect_dother = new Rectangle(rect_salqty.X, rect_dother_txt.Y, rect_total.Width, line_height);
                    //e.Graphics.DrawString(report_data.salessummaryVM_list[i].dother.FormatCurrency(), fnt, brush, rect_dother, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_totqty_txt = new Rectangle(x, rect_dother_txt.Y + line_height, rect_dtest_txt.Width, line_height);
                    e.Graphics.DrawString("  3.รวมยอดขายประจำวัน", fnt_bold, brush, rect_totqty_txt);

                    Rectangle rect_totqty = new Rectangle(rect_salqty.X, rect_totqty_txt.Y, rect_total.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].totqty.FormatCurrency(), fnt, brush, rect_totqty, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_totval = new Rectangle(rect_salval.X, rect_totqty.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].totval.FormatCurrency(), fnt, brush, rect_totval, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_ddisc_txt = new Rectangle(x, rect_totqty_txt.Y + line_height, rect_totqty_txt.Width, line_height);
                    e.Graphics.DrawString("  4.หักส่วนลดการค้าหน้าลาน", fnt_bold, brush, rect_ddisc_txt);

                    Rectangle rect_ddisc = new Rectangle(rect_salval.X, rect_ddisc_txt.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].ddisc.FormatCurrency(), fnt, brush, rect_ddisc, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_net_txt = new Rectangle(x, rect_ddisc_txt.Y + line_height, rect_totqty_txt.Width, line_height);
                    e.Graphics.DrawString("  5.ยอดขายสุทธิ", fnt_bold, brush, rect_net_txt);

                    Rectangle rect_netqty = new Rectangle(rect_salqty.X, rect_net_txt.Y, rect_salqty.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].totqty.FormatCurrency(), fnt, brush, rect_netqty, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_netval = new Rectangle(rect_salval.X, rect_net_txt.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].netval.FormatCurrency(), fnt, brush, rect_netval, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_salvat_txt = new Rectangle(x, rect_net_txt.Y + line_height, rect_net_txt.Width, line_height);
                    e.Graphics.DrawString("  6.ภาษีขาย ((5)X7)/107)", fnt_bold, brush, rect_salvat_txt);

                    Rectangle rect_salvat = new Rectangle(rect_salval.X, rect_salvat_txt.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].salvat.FormatCurrency(), fnt, brush, rect_salvat, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_purvat_txt = new Rectangle(x, rect_salvat_txt.Y + line_height, rect_salvat_txt.Width, line_height);
                    e.Graphics.DrawString("  7.ภาษีซื้อของน้ำมันเชื้อเพลิง", fnt_bold, brush, rect_purvat_txt);

                    Rectangle rect_purvat = new Rectangle(rect_salval.X, rect_purvat_txt.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].purvat.FormatCurrency(), fnt, brush, rect_purvat, new StringFormat { Alignment = StringAlignment.Far });

                    //foreach (var item in report_data.shsvattransVM.Where(s => s.stkcod == report_data.salessummaryVM_list[i].stkcod))
                    //{
                    //    sal_vattrans.Add(item);
                    //}
                    //foreach (var item in report_data.sivvattransVM.Where(s => s.stkcod == report_data.salessummaryVM_list[i].stkcod))
                    //{
                    //    sal_vattrans.Add(item);
                    //}

                    tot_salvat += report_data.salessummaryVM_list[i].salvat;
                    tot_purvat += report_data.salessummaryVM_list[i].purvat;

                    if(page_item == item_per_page || item_count == report_data.salessummaryVM_list.Count)
                    {
                        Rectangle rect_tot_salvat_txt = new Rectangle(e.MarginBounds.Left, rect_purvat_txt.Y + line_height, rect_purvat_txt.Width, line_height);
                        e.Graphics.DrawString("  รวมภาษีขายน้ำมันเชื้อเพลิงในหน้านี้", fnt_bold, brush, rect_tot_salvat_txt);

                        Rectangle rect_tot_salvat = new Rectangle(rect_tot_salvat_txt.X + rect_tot_salvat_txt.Width, rect_tot_salvat_txt.Y, rect_salqty.Width, line_height);
                        e.Graphics.DrawString(tot_salvat.FormatCurrency(), fnt_bold, brush, rect_tot_salvat, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawLine(p, new Point(rect_tot_salvat.X, rect_tot_salvat.Y + line_height), new Point(rect_tot_salvat.X + rect_tot_salvat.Width, rect_tot_salvat.Y + line_height));
                        e.Graphics.DrawLine(p, new Point(rect_tot_salvat.X, rect_tot_salvat.Y + line_height + 2), new Point(rect_tot_salvat.X + rect_tot_salvat.Width, rect_tot_salvat.Y + line_height + 2));

                        Rectangle rect_tot_purvat_txt = new Rectangle(e.MarginBounds.Left + rect_tot_salvat_txt.Width + rect_tot_salvat.Width + rect_salval.Width, rect_tot_salvat_txt.Y, rect_tot_salvat_txt.Width, line_height);
                        e.Graphics.DrawString("  รวมภาษีซื้อน้ำมันเชื้อเพลิงในหน้านี้", fnt_bold, brush, rect_tot_purvat_txt);

                        Rectangle rect_tot_purvat = new Rectangle(rect_tot_purvat_txt.X + rect_tot_purvat_txt.Width, rect_tot_purvat_txt.Y, rect_salqty.Width, line_height);
                        e.Graphics.DrawString(tot_purvat.FormatCurrency(), fnt_bold, brush, rect_tot_purvat, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawLine(p, new Point(rect_tot_purvat.X, rect_tot_purvat.Y + line_height), new Point(rect_tot_purvat.X + rect_tot_purvat.Width, rect_tot_purvat.Y + line_height));
                        e.Graphics.DrawLine(p, new Point(rect_tot_purvat.X, rect_tot_purvat.Y + line_height + 2), new Point(rect_tot_purvat.X + rect_tot_purvat.Width, rect_tot_purvat.Y + line_height + 2));

                        
                    }

                    /* Summary line end */
                    y = start_body_y;

                    if (page_item == item_per_page && item_count < report_data.salessummaryVM_list.Count)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }

                /* VAT. document */
                if(printed_vatdoc == -1)
                {
                    e.HasMorePages = true;
                    printed_vatdoc++;
                    return;
                }

                rect = new Rectangle(e.MarginBounds.X, rect.Y + (line_height * 2), 500, line_height);
                e.Graphics.DrawString("ใบกำกับภาษีเต็มรูปแบบตามมาตรา 86/4 แห่งประมวลรัษฎากร (จากการขายน้ำมันเชื้อเพลิงผ่านมิเตอร์หัวจ่าย)", fnt_bold, brush, rect);

                int begining_x = rect.X;
                int begining_y = rect.Y;

                Rectangle rect_seq = new Rectangle(begining_x, begining_y + line_height, 28, line_height);
                Rectangle rect_docnum = new Rectangle(rect_seq.X + rect_seq.Width, begining_y + line_height, 85, line_height);
                RectangleF rect_net = new RectangleF(rect_docnum.X + rect_docnum.Width, begining_y + line_height, 75, line_height);
                RectangleF rect_vat = new RectangleF(rect_net.X + rect_net.Width, begining_y + line_height, 85, line_height);
                for (int b = 0; b < 3; b++)
                {
                    e.Graphics.FillRectangle(bg_gray, rect_seq);
                    e.Graphics.FillRectangle(bg_gray, rect_docnum);
                    e.Graphics.FillRectangle(bg_gray, rect_net);
                    e.Graphics.FillRectangle(bg_gray, rect_vat);
                    rect_seq.Y = begining_y + line_height;
                    e.Graphics.DrawString("ลำดับ", fnt_bold, brush, rect_seq);
                    rect_docnum.Y = begining_y + line_height;
                    e.Graphics.DrawString("เล่มที่/เลขที่", fnt_bold, brush, rect_docnum);
                    rect_net.Y = begining_y + line_height;
                    e.Graphics.DrawString("จำนวนเงิน(บาท)", fnt_bold, brush, rect_net, new StringFormat { Alignment = StringAlignment.Far });
                    rect_vat.Y = begining_y + line_height;
                    e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม(บาท)", fnt_bold, brush, rect_vat, new StringFormat { Alignment = StringAlignment.Far });

                    e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect.Y + line_height, rect_seq.Width + rect_docnum.Width + (int)rect_net.Width + (int)rect_vat.Width, line_height));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect.Y + (line_height * 2), rect_seq.Width + rect_docnum.Width + (int)rect_net.Width + (int)rect_vat.Width, line_height * vatdoc_item_per_column));
                    e.Graphics.DrawRectangle(p, new Rectangle(rect_seq.X, rect.Y + line_height, rect_seq.Width, line_height + (line_height * vatdoc_item_per_column)));

                    var col_width = rect_seq.Width + rect_docnum.Width + (int)rect_net.Width + (int)rect_vat.Width + 10;
                    rect_seq.X += col_width;
                    rect_docnum.X += col_width;
                    rect_net.X += col_width;
                    rect_vat.X += col_width;
                }
                rect_seq.X = begining_x;
                rect_docnum.X = rect_seq.X + rect_seq.Width;
                rect_net.X = rect_docnum.X + rect_docnum.Width;
                rect_vat.X = rect_net.X + rect_net.Width;

                /*** Total VAT. block ***/
                Rectangle rect_tot_vat = new Rectangle(900, begining_y + (line_height * 2), 140, line_height);
                Rectangle rect_tot_vat_amt = new Rectangle(rect_tot_vat.X + rect_tot_vat.Width, begining_y + (line_height * 2), 60, line_height);
                Rectangle rect_tot_vat_baht = new Rectangle(rect_tot_vat_amt.X + rect_tot_vat_amt.Width, begining_y + (line_height * 2), 30, line_height);

                Rectangle rect_totvat_block = new Rectangle(rect_tot_vat.X - 10, begining_y + line_height, rect_tot_vat.Width + rect_tot_vat_amt.Width + rect_tot_vat_baht.Width + 10, line_height * 4);
                e.Graphics.DrawRectangle(p, rect_totvat_block);
                e.Graphics.DrawString("รวมภาษีขายน้ำมันเชื้อเพลิงทั้งสิ้น", fnt_bold, brush, rect_tot_vat);
                e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.salessummaryVM_list.Sum(s => s.salvat) /*sal_vattrans.Sum(sal => sal.vatamt)*/), fnt_bold, brush, rect_tot_vat_amt, new StringFormat { Alignment = StringAlignment.Far });
                e.Graphics.DrawString("บาท", fnt_bold, brush, rect_tot_vat_baht);
                rect_tot_vat.Y += line_height;
                rect_tot_vat_amt.Y += line_height;
                rect_tot_vat_baht.Y += line_height;
                e.Graphics.DrawString("รวมภาษีซื้อน้ำมันเชื้อเพลิงทั้งสิ้น", fnt_bold, brush, rect_tot_vat);
                e.Graphics.DrawString(string.Format("{0:#,#0.00}", pur_vattrans.Sum(pur => pur.vatamt)), fnt_bold, brush, rect_tot_vat_amt, new StringFormat { Alignment = StringAlignment.Far });
                e.Graphics.DrawString("บาท", fnt_bold, brush, rect_tot_vat_baht);

                /*** Price block ***/
                Rectangle rect_stk = new Rectangle(900, rect_totvat_block.Y + rect_totvat_block.Height + line_height, 140, line_height);
                Rectangle rect_unitpr = new Rectangle(rect_stk.X + rect_stk.Width, rect_totvat_block.Y + rect_totvat_block.Height + line_height, 60, line_height);
                Rectangle rect_baht = new Rectangle(rect_unitpr.X + rect_unitpr.Width, rect_totvat_block.Y + rect_totvat_block.Height + line_height, 30, line_height);

                Rectangle rect_price_block = new Rectangle(rect_stk.X - 10, rect_totvat_block.Y + rect_totvat_block.Height + line_height, rect_stk.Width + rect_unitpr.Width + rect_baht.Width + 10, line_height * 15);
                e.Graphics.FillRectangle(bg_gray, rect_price_block);
                e.Graphics.DrawRectangle(p, rect_price_block);

                e.Graphics.DrawString("ราคาน้ำมันวันนี้", fnt_bold, brush, new Rectangle(rect_stk.X, rect_stk.Y, rect_stk.Width + rect_unitpr.Width + rect_baht.Width, line_height), new StringFormat { Alignment = StringAlignment.Center });

                foreach (var price in report_data.salessummaryVM_list)
                {
                    rect_stk.Y += line_height;
                    rect_unitpr.Y += line_height;
                    rect_baht.Y += line_height;
                    e.Graphics.DrawString(price.stkcod, fnt_bold, brush, rect_stk);
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", price.unitpr), fnt_bold, brush, rect_unitpr, new StringFormat { Alignment = StringAlignment.Far });
                    e.Graphics.DrawString("บาท", fnt_bold, brush, rect_baht);
                }

                int cnt_page_vatdoc = 0;
                for (int vat_item = printed_vatdoc; vat_item < /*sal_vattrans*/report_data.sales_vatdoc.Count; vat_item++)
                {
                    if (cnt_page_vatdoc > 0 && cnt_page_vatdoc % vatdoc_item_per_column == 0)
                    {
                        var col_width = rect_seq.Width + rect_docnum.Width + (int)rect_net.Width + (int)rect_vat.Width + 10;
                        rect_seq.X += col_width;
                        rect_seq.Y = begining_y + line_height;
                        rect_docnum.X += col_width;
                        rect_docnum.Y = begining_y + line_height;
                        rect_net.X += col_width;
                        rect_net.Y = begining_y + line_height;
                        rect_vat.X += col_width;
                        rect_vat.Y = begining_y + line_height;
                    }

                    rect_seq.Y += line_height;
                    rect_docnum.Y += line_height;
                    rect_net.Y += line_height;
                    rect_vat.Y += line_height;

                    e.Graphics.DrawString((vat_item + 1).ToString(), fnt, brush, rect_seq, new StringFormat { Alignment = StringAlignment.Far });
                    e.Graphics.DrawString(report_data.sales_vatdoc[vat_item].docnum, fnt, brush, rect_docnum);
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.sales_vatdoc[vat_item].netval), fnt, brush, rect_net, new StringFormat { Alignment = StringAlignment.Far });
                    e.Graphics.DrawString(string.Format("{0:#,#0.00}", report_data.sales_vatdoc[vat_item].vatamt), fnt, brush, rect_vat, new StringFormat { Alignment = StringAlignment.Far });
                   

                    printed_vatdoc++;
                    cnt_page_vatdoc++;
                    if(cnt_page_vatdoc >= vatdoc_item_page)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            };

            return docs;
        }

        private bool SaveSttak()
        {
            if (this.tmp_sttak == null)
                return false;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    var sttak_to_update = db.shiftsttak.Find(this.tmp_sttak.id);

                    if (sttak_to_update == null)
                    {
                        MessageBox.Show("ข้อมูลที่ท่านต้องการแก้ไขไม่มีอยู่ในระบบ อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }

                    sttak_to_update.qty = this.tmp_sttak.qty;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD ||
                this.form_mode == FORM_MODE.EDIT || 
                this.form_mode == FORM_MODE.READ_ITEM || 
                this.form_mode == FORM_MODE.EDIT_ITEM ||
                this.curr_shiftsales == null || 
                this.curr_shiftsales.id == -1) 
            {
                e.Cancel = true;
            }
        }

        private void btnItemF8_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null || this.curr_shiftsales.id == -1)
                return;

            this.tabControl1.SelectedTab = this.tabPage1;
            this.form_mode = FORM_MODE.READ_ITEM;
            this.ResetControlState();
            this.dgvSalesSummary.Focus();
        }

        private void btnSttak_Click(object sender, EventArgs e)
        {
            DialogShiftSttak sttak = new DialogShiftSttak(this.main_form, this, this.curr_shiftsales);
            if(sttak.ShowDialog() == DialogResult.OK)
            {
                this.ValidateSttak();
            }
        }

        private void ValidateSttak()
        {
            if(this.curr_shiftsales == null)
            {
                this.btnSttak.Image = XPump.Properties.Resources.exclaimation_16;
                return;
            }

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if(db.shiftsttak.Where(s => s.shiftsales_id == this.curr_shiftsales.id && s.qty < 0).ToList().Count > 0)
                {
                    this.btnSttak.Image = XPump.Properties.Resources.exclaimation_16;
                    return;
                }
                else
                {
                    this.btnSttak.Image = XPump.Properties.Resources.ok_16;
                }
            }
        }

        private void dgvSalesSummary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_totqty.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    e.Handled = true;
                    return;
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_qty.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    using (SolidBrush brush = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(brush, new Rectangle(e.CellBounds.X - 3, e.CellBounds.Y + 2, 6, e.CellBounds.Height - 4));
                    }
                    TextRenderer.DrawText(e.Graphics, "ปริมาณขาย(ลิตร)", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, new Rectangle(e.CellBounds.X - 85, e.CellBounds.Y, e.CellBounds.Width + 85, e.CellBounds.Height), ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor, TextFormatFlags.VerticalCenter);
                    e.Handled = true;
                    return;
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    e.Handled = true;
                    return;
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_price.Name).First().Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground);
                    using (SolidBrush brush = new SolidBrush(((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(brush, new Rectangle(e.CellBounds.X - 3, e.CellBounds.Y + 2, 6, e.CellBounds.Height - 4));
                    }
                    TextRenderer.DrawText(e.Graphics, "ราคาขาย/ลิตร(บาท)", ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.Font, new Rectangle(e.CellBounds.X - 98, e.CellBounds.Y, e.CellBounds.Width + 98, e.CellBounds.Height), ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.ForeColor, ((XDatagrid)sender).ColumnHeadersDefaultCellStyle.BackColor, TextFormatFlags.VerticalCenter);
                    e.Handled = true;
                    return;
                }
            }

            if(e.RowIndex > -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_qty.Name).First().Index)
                {
                    int img_w = XPump.Properties.Resources.edit_list_16.Width;
                    int img_h = XPump.Properties.Resources.edit_list_16.Height;
                    int x = e.CellBounds.X + (int)Math.Floor((decimal)(e.CellBounds.Width - img_w) / 2);
                    int y = e.CellBounds.Y + (int)Math.Floor((decimal)(e.CellBounds.Height - img_h) / 2);

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Graphics.DrawImage(XPump.Properties.Resources.edit_list_16, new Rectangle(x, y, img_w, img_h));
                    e.Handled = true;
                    return;
                }

                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_price.Name).First().Index)
                {
                    int img_w = XPump.Properties.Resources.edit_16.Width;
                    int img_h = XPump.Properties.Resources.edit_16.Height;
                    int x = e.CellBounds.X + (int)Math.Floor((decimal)(e.CellBounds.Width - img_w) / 2);
                    int y = e.CellBounds.Y + (int)Math.Floor((decimal)(e.CellBounds.Height - img_h) / 2);

                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                    e.Graphics.DrawImage(XPump.Properties.Resources.edit_16, new Rectangle(x, y, img_w, img_h));
                    e.Handled = true;
                    return;
                }

                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_totqty.DataPropertyName).First().Index)
                {
                    var salessummary = (salessummary)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_salessummary.Name].Value;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        if(db.saleshistory.Where(s => s.salessummary_id == salessummary.id && s.mitbeg < 0).Count() > 0)
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Red;
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void dgvSalesSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(this.dgvSalesSummary.CurrentCell.ColumnIndex == this.dgvSalesSummary.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_qty.Name).First().Index)
            {
                this.ShowSalesForm();
                return;
            }

            if (this.dgvSalesSummary.CurrentCell.ColumnIndex == this.dgvSalesSummary.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_price.Name).First().Index)
            {
                this.ShowEditPrice();
                return;
            }
        }

        private void ShowSalesForm()
        {
            if (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
            {
                if (this.dgvSalesSummary.CurrentCell == null)
                    return;

                if (this.dgvSalesSummary.CurrentCell == null)
                    return;

                //if (this.form_mode != FORM_MODE.READ_ITEM)
                //{
                //    this.form_mode = FORM_MODE.READ_ITEM;
                //    this.ResetControlState();
                //}

                var sales = (salessummary)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_salessummary.Name].Value;

                DialogSalesHistory sh = new DialogSalesHistory(this.main_form, this, sales);
                sh.ShowDialog();
                this.dgvSalesSummary.Focus();
            }
        }

        private void ShowEditPrice()
        {
            if (this.dgvSalesSummary.CurrentCell == null)
                return;

            if (this.curr_shiftsales.ToViewModel(this.main_form.working_express_db).IsEditableShiftSales() == false)
                return;

            //if (this.form_mode != FORM_MODE.READ_ITEM)
            //{
            //    this.form_mode = FORM_MODE.READ_ITEM;
            //    this.ResetControlState();
            //}

            salessummary sales = (salessummary)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_salessummary.Name].Value;

            int pricelist_id = (int)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_pricelist_id.Name].Value;
            Rectangle rect = this.dgvSalesSummary.GetCellDisplayRectangle(this.dgvSalesSummary.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index, this.dgvSalesSummary.CurrentCell.RowIndex, false);

            DialogEditPrice pr = new DialogEditPrice(this.main_form, this, pricelist_id, new Size(rect.Width + 4, rect.Height), new Point(this.dgvSalesSummary.PointToScreen(Point.Empty).X + rect.X - 2, this.dgvSalesSummary.PointToScreen(Point.Empty).Y + rect.Y - 2), sales.ToViewModel(this.main_form.working_express_db).unitpr);
            if (pr.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var sales_to_update = db.salessummary.Find(sales.id);
                    sales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    sales_to_update.chgtime = DateTime.Now;

                    var shiftsales_to_update = db.shiftsales.Find(sales_to_update.shiftsales_id);
                    shiftsales_to_update.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    shiftsales_to_update.chgtime = DateTime.Now;

                    db.SaveChanges();
                }

                this.curr_shiftsales = this.GetShiftSales(this.curr_shiftsales.id);
                this.FillForm();
            }
            this.dgvSalesSummary.Focus();
        }

        private void dgvSalesSummary_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_qty.Name).First().Index)
            {
                e.ToolTipText = "แก้ไขรายละเอียดการขาย <Alt+E>";
                return;
            }

            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_price.Name).First().Index)
            {
                e.ToolTipText = "แก้ไขราคาขาย <Ctrl+E>";
                return;
            }
        }

        private void dgvSalesSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index ||
                e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_btn_price.DataPropertyName).First().Index)
            {
                this.ShowEditPrice();
                return;
            }
            else
            {
                this.ShowSalesForm();
                return;
            }
            
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null)
                return;
            string approved_user = this.main_form.loged_in_status.loged_in_user_name;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if(db.shiftsttak.Where(s => s.shiftsales_id == this.curr_shiftsales.id && s.qty < 0).Count() > 0)
                {
                    if (MessageBox.Show("ปริมาณน้ำมันที่ตรวจวัดได้ยังป้อนไม่ครบ, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return;
                }
            }

            settings settings = DialogSettings.GetSettings(this.main_form.working_express_db);
            if (this.main_form.loged_in_status.loged_in_user_level < settings.shiftauthlev)
            {
                DialogValidateUser validate = new DialogValidateUser(this.main_form, settings.shiftauthlev);
                if (validate.ShowDialog() != DialogResult.OK)
                    return;

                approved_user = validate.validated_status.loged_in_user_name;
            }

            if (MessageBox.Show("กรุณายืนยันเพื่อทำการรับรองรายการ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            try
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var shiftsales_to_appr = db.shiftsales.Find(this.curr_shiftsales.id);
                    shiftsales_to_appr.apprby = approved_user;
                    shiftsales_to_appr.apprtime = DateTime.Now;

                    db.SaveChanges();

                    this.main_form.islog.Approve(this.menu_id, "รับรองรายการ บันทึกรายการประจำผลัด \"" + shiftsales_to_appr.ToViewModel(this.main_form.working_express_db).shift_name + "\" วันที่ " + shiftsales_to_appr.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), shiftsales_to_appr.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + shiftsales_to_appr.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", shiftsales_to_appr.id).Save(approved_user);

                    this.btnRefresh.PerformClick();
                    this.ResetApproveBtn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnApprove_Click(object sender, EventArgs e)
        {
            if (this.curr_shiftsales == null)
                return;

            string unapproved_user = this.main_form.loged_in_status.loged_in_user_name;

            settings settings = DialogSettings.GetSettings(this.main_form.working_express_db);
            if (this.main_form.loged_in_status.loged_in_user_level < settings.shiftauthlev)
            {
                DialogValidateUser validate = new DialogValidateUser(this.main_form, settings.shiftauthlev);
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
                    var shiftsales_to_appr = db.shiftsales.Find(this.curr_shiftsales.id);
                    shiftsales_to_appr.apprby = null;
                    shiftsales_to_appr.apprtime = null;

                    db.SaveChanges();

                    this.main_form.islog.UnApprove(this.menu_id, "ยกเลิกการรับรองรายการ บันทึกรายการประจำผลัด \"" + shiftsales_to_appr.ToViewModel(this.main_form.working_express_db).shift_name + "\" วันที่ " + shiftsales_to_appr.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")), shiftsales_to_appr.saldat.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("th-TH")) + "|" + shiftsales_to_appr.ToViewModel(this.main_form.working_express_db).shift_name, "shiftsales", shiftsales_to_appr.id).Save(unapproved_user);

                    this.btnRefresh.PerformClick();
                    this.ResetApproveBtn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
                {
                    if (this.brShift._Focused)
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
            }

            if (keyData == (Keys.Alt | Keys.A))
            {
                this.btnAdd.PerformClick();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.E))
            {
                if (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.ShowSalesForm();
                    return true;
                }
            }

            if (keyData == (Keys.Control | Keys.E))
            {
                if (this.form_mode == FORM_MODE.READ || this.form_mode == FORM_MODE.READ_ITEM)
                {
                    this.ShowEditPrice();
                    return true;
                }
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.btnStop.PerformClick();
                return true;
            }

            if (keyData == Keys.F9)
            {
                this.btnSave.PerformClick();
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

            if (keyData == (Keys.Control | Keys.Home))
            {
                this.btnFirst.PerformClick();
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

            if (keyData == (Keys.Alt | Keys.P))
            {
                this.btnPrintALandscape.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                this.btnPrintAPortrait.PerformClick();
                return true;
            }

            if (keyData == Keys.F8)
            {
                this.btnItem.PerformClick();
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

            if(keyData == (Keys.Control | Keys.O))
            {
                this.btnUnApprove.PerformClick();
                return true;
            }

            if(keyData == Keys.Tab)
            {
                //if(this.form_mode == FORM_MODE.READ)
                //{
                //    if (this.curr_shiftsales == null)
                //        return false;

                //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                //    {
                //        var total_recs = db.shiftsales.AsEnumerable().Count();
                //        var data_info = db.shiftsales.Find(this.curr_shiftsales.id);
                //        if (data_info == null)
                //            return false;

                //        DialogDataInfo info = new DialogDataInfo("Shiftsales", data_info.id, total_recs, data_info.creby, data_info.cretime, data_info.chgby, data_info.chgtime, data_info.apprby, data_info.apprtime);
                //        info.ShowDialog();
                //        return true;
                //    }
                //}
                if(this.form_mode == FORM_MODE.READ)
                {
                    if (this.dgvSalesSummary.CurrentCell == null)
                        return false;

                    var sales = (salessummary)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_salessummary.Name].Value;

                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        var total_recs = db.salessummary.AsEnumerable().Count();
                        var data_info = db.salessummary.Include("shiftsales").Where(s => s.id == sales.id).FirstOrDefault();

                        if (data_info == null)
                            return false;

                        DialogDataInfo info = new DialogDataInfo("Salessummary", data_info.id, total_recs, data_info.creby, data_info.cretime, data_info.chgby, data_info.chgtime, data_info.shiftsales.apprby, data_info.shiftsales.apprtime, data_info.shiftsales.prnby, data_info.shiftsales.prntime, data_info.shiftsales.prncnt);
                        info.ShowDialog();
                        return true;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
