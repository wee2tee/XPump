﻿using System;
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
            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.bs_sales = new BindingSource();
            this.dgvSalesSummary.DataSource = this.bs_sales;

            this.bs_sttak = new BindingSource();
            //this.dgvSttak.DataSource = this.bs_sttak;

            this.btnLast.PerformClick();
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
            this.btnItemF8.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            /* Form control */
            this.brShift.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dtSaldat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.dgvSalesSummary.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.READ_ITEM }, this.form_mode);
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
            this.dtSaldat._SelectedDate = sales.saldat;

            this.sales_list = sales.salessummary.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.stkcod).ToList();
            this.bs_sales.ResetBindings(true);
            this.bs_sales.DataSource = this.sales_list;

            this.bs_sttak.ResetBindings(true);
            this.bs_sttak.DataSource = sales.shiftsttak.ToViewModel(this.main_form.working_express_db).OrderBy(s => s.tank_name).ThenBy(s => s.section_name).ToList();

            this.ValidateSttak();

            /*Form control state depend on data*/
            if (this.form_mode == FORM_MODE.READ)
            {
                this.btnEdit.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnDelete.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnFirst.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnPrevious.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnNext.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnLast.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnSearch.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnInquiryAll.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnInquiryRest.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnPrint.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnPrintALandscape.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnItem.Enabled = sales == null || sales.id == -1 ? false : true;
                this.btnRefresh.Enabled = sales == null || sales.id == -1 ? false : true;

                this.dtSaldat._SelectedDate = sales == null || sales.id == -1 ? null : (DateTime?)sales.saldat;
            }
        }

        private bool ValidateClosedShiftSales(shiftsales shiftsales)
        {
            bool isclosed = shiftsales.IsClosedShiftSales(this.main_form.working_express_db);
            if (isclosed == true)
            {
                MessageBox.Show("วันที่ " + this.curr_shiftsales.saldat.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + " ปิดยอดขายประจำวันไปแล้ว ไม่สามารถแก้ไขได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return isclosed;
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

            if (this.ValidateClosedShiftSales(this.curr_shiftsales))
            {
                return;
            }

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

            if (this.ValidateClosedShiftSales(this.curr_shiftsales))
            {
                return;
            }

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
            //if(this.form_mode == FORM_MODE.EDIT_ITEM && this.tmp_sttak != null)
            //{
            //    this.RemoveSttakInlineForm();
            //    this.form_mode = FORM_MODE.READ_ITEM;
            //    this.ResetControlState();
            //    return;
            //}

            this.form_mode = FORM_MODE.READ;
            this.ResetControlState();

            this.FillForm();
            this.tmp_shiftsales = null;
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
                            var x = new salessummary
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
                            db.salessummary.Add(x);

                            // add sttak
                            var sections = db.section.Include("tank").Include("tank.tanksetup")
                                            .Where(sect => sect.tank.tanksetup.startdate.CompareTo(this.tmp_shiftsales.saldat) <= 0)
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

            DataGridViewColumn col_cretime = new DataGridViewTextBoxColumn();
            col_cretime.HeaderText = "เพิ่มวันที่";
            col_cretime.DataPropertyName = "cretime";
            col_cretime.DefaultCellStyle.Format = "dd/MM/yyyy";
            col_cretime.Visible = false;
            cols.Add(col_cretime);

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
                var report_data = this.GetReportAData();
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_A(report_data, true));
                if (print.output == PRINT_OUTPUT.SCREEN)
                {
                    //XPrintPreviewDialog pd = new XPrintPreviewDialog(total_page);
                    //pd.MdiParent = this.main_form;
                    //pd.Document = this.PreparePrintDoc_A(report_data, total_page);
                    //pd.Show();

                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_A(report_data, true, total_page), total_page);
                    xp.MdiParent = this.main_form;
                    xp.Show();
                }

                if (print.output == PRINT_OUTPUT.PRINTER)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_A(report_data, true, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
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
                var report_data = this.GetReportAData();
                int total_page = XPrintPreview.GetTotalPageCount(this.PreparePrintDoc_A(report_data, false));
                if (print.output == PRINT_OUTPUT.SCREEN)
                {
                    XPrintPreview xp = new XPrintPreview(this.PreparePrintDoc_A(report_data, false, total_page), total_page);
                    xp.MdiParent = this.main_form;
                    xp.Show();
                }

                if (print.output == PRINT_OUTPUT.PRINTER)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.Document = this.PreparePrintDoc_A(report_data, false, total_page);
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
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

                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();

                ((XDatagrid)sender).Rows[row_index].Cells[this.col_stkcod.Name].Selected = true;
                //this.dgv_SelectionChanged((XDatagrid)sender, new EventArgs());
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_sales = new MenuItem();
                mnu_sales.Text = "บันทึกปริมาณการขาย <Ctrl+Space>";
                mnu_sales.Click += delegate
                {
                    this.ShowSalesForm();
                    return;
                };
                cm.MenuItems.Add(mnu_sales);

                MenuItem mnu_price = new MenuItem();
                mnu_price.Text = "แก้ไขราคาขาย <Alt+E>";
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

        private ReportAModel GetReportAData()
        {
            ReportAModel report_data = new ReportAModel();
            report_data.reportDate = this.curr_shiftsales.saldat;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    //int[] pricelist_id = db.salessummary.Where(s => s.shiftsales_id == this.curr_shiftsales.id).Select(s => s.pricelist_id).ToArray<int>();
                    //report_data.pricelistVM_list = db.pricelist.Where(p => pricelist_id.Contains<int>(p.id)).ToViewModel();

                    report_data.salessummaryVM_list = db.salessummary.Where(s => s.shiftsales_id == this.curr_shiftsales.id).ToViewModel(this.main_form.working_express_db).OrderBy(s => s.stkcod).ToList();

                    int[] salessummary_ids = db.salessummary.Where(s => s.shiftsales_id == this.curr_shiftsales.id).Select(s => s.id).ToArray<int>();
                    report_data.saleshistoryVM_list = db.saleshistory.Where(s => salessummary_ids.Contains<int>(s.salessummary_id)).ToViewModel(this.main_form.working_express_db).ToList();

                    report_data.shift = db.shift.Find(this.curr_shiftsales.shift_id);
                    report_data.isinfoDbfVM = DbfTable.Isinfo(this.main_form.working_express_db).Rows.Count > 0 ? DbfTable.Isinfo(this.main_form.working_express_db).ToList<IsinfoDbf>().First().ToViewModel(this.main_form.working_express_db) : new IsinfoDbfVM { compnam = string.Empty, addr = string.Empty, telnum = string.Empty, taxid = string.Empty };

                    var aptrn = DbfTable.Aptrn(this.main_form.working_express_db).ToAptrnList()
                        .Where(a => a.docdat.HasValue)
                        .Where(a => a.docdat.Value == report_data.reportDate)
                        .Where(a => (a.docnum.Substring(0, 2) == report_data.shift.phpprefix || a.docnum.Substring(0, 2) == report_data.shift.prrprefix)).ToList();
                    var artrn = DbfTable.Artrn(this.main_form.working_express_db).ToArtrnList()
                        .Where(a => a.docdat.HasValue)
                        .Where(a => a.docdat.Value == report_data.reportDate)
                        .Where(a => (a.docnum.Substring(0, 2) == report_data.shift.shsprefix || a.docnum.Substring(0, 2) == report_data.shift.sivprefix)).ToList();
                    var stcrd = DbfTable.Stcrd(this.main_form.working_express_db).ToStcrdList()
                        .Where(s => s.docdat.HasValue)
                        .Where(s => s.docdat.Value == report_data.reportDate)
                        .Where(s => aptrn.Select(a => a.docnum).Contains(s.docnum) || artrn.Select(a => a.docnum).Contains(s.docnum))
                        .OrderBy(s => s.docnum).ToList();

                    report_data.phpvattransVM = stcrd.Where(s => s.docnum.Substring(0, 2) == report_data.shift.phpprefix)
                        .Select(s => new VatTransDbfVM {
                            docnum = s.docnum.Trim(),
                            docdat = s.docdat.Value,
                            people = s.people.Trim(), //apmas.Where(a => a.supcod.Trim() == s.people.Trim()).FirstOrDefault() != null ? apmas.Where(a => a.supcod.Trim() == s.people.Trim()).First().prenam.Trim() + " " + apmas.Where(a => a.supcod.Trim() == s.people.Trim()).First().supnam.Trim() : string.Empty,
                            stkcod = s.stkcod.Trim(),
                            netval = s.netval,
                            vatamt = Convert.ToDouble(string.Format("{0:0.00}", (s.netval * 7) / 100))
                        }).OrderBy(s => s.docnum).ToList();

                    report_data.prrvattransVM = stcrd.Where(s => s.docnum.Substring(0, 2) == report_data.shift.prrprefix)
                        .Select(s => new VatTransDbfVM
                        {
                            docnum = s.docnum.Trim(),
                            docdat = s.docdat.Value,
                            people = s.people.Trim(),
                            stkcod = s.stkcod.Trim(),
                            netval = s.netval,
                            vatamt = Convert.ToDouble(string.Format("{0:0.00}", (s.netval * 7) / 100))
                        }).OrderBy(s => s.docnum).ToList();

                    report_data.shsvattransVM = stcrd.Where(s => s.docnum.Substring(0, 2) == report_data.shift.shsprefix)
                        .Select(s => new VatTransDbfVM
                        {
                            docnum = s.docnum.Trim(),
                            docdat = s.docdat.Value,
                            people = s.people.Trim(),
                            stkcod = s.stkcod.Trim(),
                            netval = s.netval,
                            vatamt = Convert.ToDouble(string.Format("{0:0.00}", (s.netval * 7) / 100))
                        }).OrderBy(s => s.docnum).ToList();

                    report_data.sivvattransVM = stcrd.Where(s => s.docnum.Substring(0, 2) == report_data.shift.sivprefix)
                        .Select(s => new VatTransDbfVM
                        {
                            docnum = s.docnum.Trim(),
                            docdat = s.docdat.Value,
                            people = s.people.Trim(),
                            stkcod = s.stkcod.Trim(),
                            netval = s.netval,
                            vatamt = Convert.ToDouble(string.Format("{0:0.00}", (s.netval * 7) / 100))
                        }).OrderBy(s => s.docnum).ToList();

                    foreach (var item in report_data.salessummaryVM_list)
                    {
                        //item.purvat = Convert.ToDecimal(report_data.phpvattransVM.Where(p => p.stkcod == item.stkcod.Trim()).Sum(p => p.vatamt) + report_data.prrvattransVM.Where(p => p.stkcod == item.stkcod.Trim()).Sum(p => p.vatamt));
                    }
                }
                catch (Exception)
                {
                    return report_data;
                }
            }

            return report_data;
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
            SolidBrush bg_gray = new SolidBrush(Color.Gainsboro);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;
            int item_per_page = landscape ? 4 : 3;

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
            };
            docs.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int line_height = fnt_header.Height - 1;

                page++;

                //if(page < docs.PrinterSettings.FromPage || page > docs.PrinterSettings.ToPage)
                //{
                    
                //}


                // draw margin bound
                //e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(x, y, e.MarginBounds.Right - x, e.MarginBounds.Bottom - y));

                /* report header */
                Rectangle rect = new Rectangle(x, y, e.MarginBounds.Right - x, line_height);
                string str = "รายงานแสดงรายละเอียดการขายน้ำมันเชื้อเพลิง";
                e.Graphics.DrawString(str, fnt_header_bold, brush, rect, format_center);

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
                List<VatTransDbfVM> sal_vattrans = new List<VatTransDbfVM>();
                List<VatTransDbfVM> pur_vattrans = new List<VatTransDbfVM>();
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
                    int nozz_count = landscape ? 12 : 30;
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

                    Rectangle rect_qty = new Rectangle(x + rect_total_txt.Width, rect_salqty.Y, rect_salqty.Width, line_height * 8);
                    e.Graphics.DrawRectangle(p, rect_qty);

                    Rectangle rect_val = new Rectangle(rect_qty.X + rect_qty.Width, rect_salval.Y, rect_salval.Width, line_height * 8);
                    e.Graphics.DrawRectangle(p, rect_val);

                    Rectangle rect_total = new Rectangle(rect_salqty.X, rect_total_txt.Y, rect_salqty.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].total.FormatCurrency(), fnt, brush, rect_total, new StringFormat { Alignment = StringAlignment.Far});

                    Rectangle rect_dtest_txt = new Rectangle(x, rect_total_txt.Y + line_height, rect_total_txt.Width, line_height);
                    e.Graphics.DrawString("  2.หักยอดขายน้ำมันทดสอบ", fnt_bold, brush, rect_dtest_txt);

                    Rectangle rect_dtest = new Rectangle(rect_salqty.X, rect_dtest_txt.Y, rect_total.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].dtest.FormatCurrency(), fnt, brush, rect_dtest, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_dother_txt = new Rectangle(x + 12, rect_dtest_txt.Y + line_height, rect_dtest_txt.Width - 12, line_height);
                    e.Graphics.DrawString("หักอื่น ๆ ระบุ ______________________", fnt_bold, brush, rect_dother_txt);

                    rect_dother_txt.X += 60;
                    rect_dother_txt.Width -= 60;
                    //e.Graphics.DrawString(report_data.salessummaryVM_list[i].dothertxt, fnt_bold, brush, rect_dother_txt);

                    Rectangle rect_dother = new Rectangle(rect_salqty.X, rect_dother_txt.Y, rect_total.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].dother.FormatCurrency(), fnt, brush, rect_dother, new StringFormat { Alignment = StringAlignment.Far });

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
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].totval.FormatCurrency(), fnt, brush, rect_netval, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_salvat_txt = new Rectangle(x, rect_net_txt.Y + line_height, rect_net_txt.Width, line_height);
                    e.Graphics.DrawString("  6.ภาษีขาย ((5)X7)/107)", fnt_bold, brush, rect_salvat_txt);

                    Rectangle rect_salvat = new Rectangle(rect_salval.X, rect_salvat_txt.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].salvat.FormatCurrency(), fnt, brush, rect_salvat, new StringFormat { Alignment = StringAlignment.Far });

                    Rectangle rect_purvat_txt = new Rectangle(x, rect_salvat_txt.Y + line_height, rect_salvat_txt.Width, line_height);
                    e.Graphics.DrawString("  7.ภาษีซื้อของน้ำมันเชื้อเพลิง", fnt_bold, brush, rect_purvat_txt);

                    Rectangle rect_purvat = new Rectangle(rect_salval.X, rect_purvat_txt.Y, rect_salval.Width, line_height);
                    e.Graphics.DrawString(report_data.salessummaryVM_list[i].purvat.FormatCurrency(), fnt, brush, rect_purvat, new StringFormat { Alignment = StringAlignment.Far });

                    foreach (var item in report_data.shsvattransVM.Where(s => s.stkcod == report_data.salessummaryVM_list[i].stkcod))
                    {
                        sal_vattrans.Add(item);
                    }
                    foreach (var item in report_data.sivvattransVM.Where(s => s.stkcod == report_data.salessummaryVM_list[i].stkcod))
                    {
                        sal_vattrans.Add(item);
                    }

                    tot_salvat += report_data.salessummaryVM_list[i].salvat;
                    tot_purvat += report_data.salessummaryVM_list[i].purvat;

                    if(page_item == item_per_page || item_count == report_data.salessummaryVM_list.Count)
                    {
                        Rectangle rect_tot_salvat_txt = new Rectangle(e.MarginBounds.Left, rect_purvat_txt.Y + line_height, rect_purvat_txt.Width, line_height);
                        e.Graphics.DrawString("  รวมภาษีขายน้ำมันเชื้อเพลิงทั้งสิ้น", fnt_bold, brush, rect_tot_salvat_txt);

                        Rectangle rect_tot_salvat = new Rectangle(rect_tot_salvat_txt.X + rect_tot_salvat_txt.Width, rect_tot_salvat_txt.Y, rect_salqty.Width, line_height);
                        e.Graphics.DrawString(tot_salvat.FormatCurrency(), fnt_bold, brush, rect_tot_salvat, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawLine(p, new Point(rect_tot_salvat.X, rect_tot_salvat.Y + line_height), new Point(rect_tot_salvat.X + rect_tot_salvat.Width, rect_tot_salvat.Y + line_height));
                        e.Graphics.DrawLine(p, new Point(rect_tot_salvat.X, rect_tot_salvat.Y + line_height + 2), new Point(rect_tot_salvat.X + rect_tot_salvat.Width, rect_tot_salvat.Y + line_height + 2));

                        Rectangle rect_tot_purvat_txt = new Rectangle(e.MarginBounds.Left + rect_tot_salvat_txt.Width + rect_tot_salvat.Width + rect_salval.Width, rect_tot_salvat_txt.Y, rect_tot_salvat_txt.Width, line_height);
                        e.Graphics.DrawString("  รวมภาษีซื้อน้ำมันเชื้อเพลิงทั้งสิ้น", fnt_bold, brush, rect_tot_purvat_txt);

                        Rectangle rect_tot_purvat = new Rectangle(rect_tot_purvat_txt.X + rect_tot_purvat_txt.Width, rect_tot_purvat_txt.Y, rect_salqty.Width, line_height);
                        e.Graphics.DrawString(tot_purvat.FormatCurrency(), fnt_bold, brush, rect_tot_purvat, new StringFormat { Alignment = StringAlignment.Far });
                        e.Graphics.DrawLine(p, new Point(rect_tot_purvat.X, rect_tot_purvat.Y + line_height), new Point(rect_tot_purvat.X + rect_tot_purvat.Width, rect_tot_purvat.Y + line_height));
                        e.Graphics.DrawLine(p, new Point(rect_tot_purvat.X, rect_tot_purvat.Y + line_height + 2), new Point(rect_tot_purvat.X + rect_tot_purvat.Width, rect_tot_purvat.Y + line_height + 2));

                        str = "ใบกำกับภาษีเต็มรูปแบบตามมาตรา 86/4 แห่งประมวลรัษฎากร (จากการขายน้ำมันเชื้อเพลิงผ่านมิเตอร์หัวจ่าย)";
                        Rectangle rect_vatdoc_title = new Rectangle(e.MarginBounds.Left, rect_tot_purvat_txt.Y + (line_height * 2), str.Width(fnt), line_height);
                        e.Graphics.DrawString(str, fnt, brush, rect_vatdoc_title);

                        y = rect_vatdoc_title.Y;
                        var sal_hs = sal_vattrans.Where(s => s.docnum.Substring(0, 2) == report_data.shift.shsprefix).ToList();
                        if(sal_hs.Count > 0)
                        {
                            y += line_height;
                            if (sal_hs.Count == 1)
                            {
                                str = "เลขที่ " + sal_hs.First().docnum.PadLeft(12);
                            }
                            else
                            {
                                str = "เลขที่ " + sal_hs.First().docnum.PadLeft(12) + " ถึงเลขที่ " + sal_hs.Last().docnum.PadLeft(12);
                            }

                            str += " จำนวน " + sal_hs.GroupBy(s => s.docnum).Count().ToString().PadLeft(4) + " ฉบับ จำนวนเงิน " + string.Format("{0:#,#0.00}", sal_hs.Sum(s => s.netval) + sal_hs.Sum(s => s.vatamt)).PadLeft(15) + " บาท ภาษีมูลค่าเพิ่ม " + string.Format("{0:#,#0.00}", sal_hs.Sum(s => s.vatamt)).PadLeft(13) + " บาท";
                            Rectangle rect_hs_vat = str.GetDisplayRect(fnt, e.MarginBounds.Left, y);
                            rect_hs_vat.Width += 15;
                            e.Graphics.DrawString(str, fnt, brush, rect_hs_vat);
                        }
                        var sal_iv = sal_vattrans.Where(s => s.docnum.Substring(0, 2) == report_data.shift.sivprefix).ToList();
                        if(sal_iv.Count > 0)
                        {
                            y += line_height;
                            if(sal_iv.Count == 1)
                            {
                                str = "เลขที่ " + sal_iv.First().docnum.PadLeft(12);
                            }
                            else
                            {
                                str = "เลขที่ " + sal_iv.First().docnum.PadLeft(12) + " ถึงเลขที่ " + sal_iv.Last().docnum.PadLeft(12);
                            }

                             str += " จำนวน " + sal_iv.GroupBy(s => s.docnum).Count().ToString().PadLeft(4) + " ฉบับ จำนวนเงิน " + string.Format("{0:#,#0.00}", sal_iv.Sum(s => s.netval) + sal_iv.Sum(s => s.vatamt)).PadLeft(15) + " บาท ภาษีมูลค่าเพิ่ม " + string.Format("{0:#,#0.00}", sal_iv.Sum(s => s.vatamt)).PadLeft(13) + " บาท";
                            Rectangle rect_iv_vat = str.GetDisplayRect(fnt, e.MarginBounds.Left, y);
                            rect_iv_vat.Width += 15;
                            e.Graphics.DrawString(str, fnt, brush, rect_iv_vat);
                        }

                        using(Font fnt_price = new Font("angsana new", 9f))
                        {
                            Rectangle rect_price = new Rectangle(e.MarginBounds.Right - 200, rect_tot_purvat_txt.Y + line_height, 200, fnt_price.Height * 11);
                            e.Graphics.FillRectangle(bg_gray, rect_price);
                            e.Graphics.DrawRectangle(p, rect_price);

                            rect = new Rectangle(rect_price.X, rect_price.Y, rect_price.Width, fnt_price.Height);
                            e.Graphics.DrawString("ราคาน้ำมันวันนี้", fnt_price, brush, rect, new StringFormat { Alignment = StringAlignment.Center });

                            for (int k = 0; k < 10; k++)
                            {
                                if(k < report_data.salessummaryVM_list.Count)
                                {
                                    rect = new Rectangle(rect_price.X, rect_price.Y + (fnt_price.Height * (k + 1)), rect_price.Width * 2 / 4, fnt_price.Height);
                                    e.Graphics.DrawString(report_data.salessummaryVM_list[k].stkcod, fnt_price, brush, rect);

                                    rect = new Rectangle(rect.X + rect.Width, rect.Y, rect.Width / 2, fnt_price.Height);
                                    e.Graphics.DrawString(report_data.salessummaryVM_list[k].unitpr.FormatCurrency(), fnt_price, brush, rect, new StringFormat { Alignment = StringAlignment.Far });

                                    rect = new Rectangle(rect.X + rect.Width, rect.Y, rect.Width, fnt_price.Height);
                                    e.Graphics.DrawString("บาท", fnt_price, brush, rect, new StringFormat { Alignment = StringAlignment.Center });
                                }
                            }
                        }
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
                //if (this.form_mode == FORM_MODE.READ)
                //{
                //    this.btnEdit.PerformClick();
                //    return true;
                //}

                if (this.form_mode == FORM_MODE.READ_ITEM)
                {
                    if(this.tabControl1.SelectedTab == this.tabPage1)
                    {
                        this.ShowEditPrice();
                        return true;
                    }
                }
            }

            if (keyData == (Keys.Alt | Keys.D))
            {
                this.btnDelete.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Space))
            {
                this.ShowSalesForm();
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

            if(keyData == (Keys.Alt | Keys.P))
            {
                this.btnPrintALandscape.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.P))
            {
                this.btnPrintAPortrait.PerformClick();
                return true;
            }

            if (keyData == Keys.F8)
            {
                this.btnItemF8.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

                if (this.form_mode != FORM_MODE.READ_ITEM)
                {
                    this.form_mode = FORM_MODE.READ_ITEM;
                    this.ResetControlState();
                }

                var sales = (salessummary)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_salessummary.Name].Value;

                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var tanksetup = db.tanksetup.OrderByDescending(t => t.startdate).Where(t => t.startdate.CompareTo(sales.saldat) <= 0).FirstOrDefault();

                    if (tanksetup == null)
                    {
                        MessageBox.Show("ไม่พบการกำหนดค่าแท๊งค์เก็บน้ำมัน สำหรับการขายในวันที่ \"" + this.curr_salessummary.saldat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var nozz = db.nozzle.Include("section").Include("section.tank").Where(n => n.section.tank.tanksetup_id == tanksetup.id && n.section.stkcod == sales.stkcod && n.isactive).ToList();

                    try
                    {
                        foreach (var n in nozz)
                        {
                            if (db.saleshistory.Where(s => s.salessummary_id == sales.id && s.nozzle_id == n.id).Count() > 0)
                                continue;

                            db.saleshistory.Add(new saleshistory
                            {
                                saldat = sales.saldat,
                                mitbeg = 0m,
                                mitend = 0m,
                                salqty = 0m,
                                salval = 0m,
                                nozzle_id = n.id,
                                salessummary_id = sales.id,
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

                DialogSalesHistory sh = new DialogSalesHistory(this.main_form, this, sales);
                sh.ShowDialog();
            }
        }

        private void ShowEditPrice()
        {
            if (this.dgvSalesSummary.CurrentCell == null)
                return;

            if (this.ValidateClosedShiftSales(this.curr_shiftsales))
            {
                MessageBox.Show("ปิดยอดขายแล้ว ไม่สามารถแก้ไขราคาได้", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (this.form_mode != FORM_MODE.READ_ITEM)
            {
                this.form_mode = FORM_MODE.READ_ITEM;
                this.ResetControlState();
            }

            salessummary sales = (salessummary)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_salessummary.Name].Value;

            int pricelist_id = (int)this.dgvSalesSummary.Rows[this.dgvSalesSummary.CurrentCell.RowIndex].Cells[this.col_pricelist_id.Name].Value;
            Rectangle rect = this.dgvSalesSummary.GetCellDisplayRectangle(this.dgvSalesSummary.Columns.Cast<DataGridViewColumn>().Where(c => c.DataPropertyName == this.col_unitpr.DataPropertyName).First().Index, this.dgvSalesSummary.CurrentCell.RowIndex, false);

            DialogEditPrice pr = new DialogEditPrice(this.main_form, this, pricelist_id, new Size(rect.Width + 4, rect.Height), new Point(this.dgvSalesSummary.PointToScreen(Point.Empty).X + rect.X - 2, this.dgvSalesSummary.PointToScreen(Point.Empty).Y + rect.Y - 2), sales.ToViewModel(this.main_form.working_express_db).unitpr);
            if (pr.ShowDialog() == DialogResult.OK)
            {
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
                e.ToolTipText = "บันทึกปริมาณการขาย <Ctrl+Space>";
                return;
            }

            if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_btn_price.Name).First().Index)
            {
                e.ToolTipText = "แก้ไขราคาขาย <Alt+E>";
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
    }
}
