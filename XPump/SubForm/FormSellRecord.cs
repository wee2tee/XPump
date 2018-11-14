using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;
using CC;
using XPump.CustomControls;
using XPump.Misc;
using System.Drawing.Printing;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class FormSellRecord : Form
    {
        public const string modcod = "";
        private MainForm main_form;
        private scacclvVM scacclv;
        private BindingList<StmasDbfPrice> stmas1;
        private BindingList<StmasDbfPrice> stmas2;
        private BindingList<StcrdInvoice> stcrd;
        private BindingList<ArrcpcqInvoice> arrcpcq_credit_card;
        private BindingList<ArrcpcqInvoice> arrcpcq_coupon;
        private FORM_MODE form_mode;
        private artrn tmp_artrn = null;
        private arrcpcq tmp_arrcpcq;
        private IsrunDbf curr_docprefix = null;
        private artrn curr_artrn = null;
        private nozzle curr_nozzle = null;
        private ITEM_MODE item_mode;

        private enum ITEM_MODE
        {
            STOCK,
            RECEIVE
        }

        public FormSellRecord(MainForm main_form, IsrunDbf isrun_doc_prefix, scacclvVM scacclv)
        {
            this.main_form = main_form;
            this.curr_docprefix = isrun_doc_prefix;
            this.scacclv = scacclv;
            InitializeComponent();
        }

        private void FormSellRecord_Load(object sender, EventArgs e)
        {
            //decimal[] dec = new decimal[] { 5678.345m, 200.01m, 121.20m, 101.41m, 120.21m, 1.10m, 31.70m, 21m, 20m, 12m, .25m};

            //foreach (var d in dec)
            //{
            //    Console.WriteLine(" ==> " + d + " : " + d.ToBahtText());
            //}

            this.BackColor = MiscResource.WIND_BG;
            this.HideInlineForm();
            this.LoadRcvBankDropdownList();

            this.cCuscod._DataPath = this.main_form.working_express_db.abs_path;
            this.LoadStmasDgv();
            this.lblDocType.Text = this.curr_docprefix.prefix + " : " + this.curr_docprefix.posdes;
            this.ResetFormState(FORM_MODE.READ);

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix).OrderByDescending(a => a.docnum).FirstOrDefault();
                this.FillForm(this.curr_artrn);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            base.OnFormClosed(e);
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnAdd.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnVoid.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT, FORM_MODE.EDIT_ITEM }, this.form_mode);
            this.btnFirst.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrevious.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnNext.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnLast.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSearch.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryAll.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnInquiryRest.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnPrint.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            this.btnManageStkgrp.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            //this.btnChangeDocTyp.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.cCuscod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cDocdat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnAddCreditCard.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnAddCoupon.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            //this.cNozzle.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            //this.cCshrcv.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);

            this.dgvRcv1.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.dgvRcv2.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
        }

        private List<IsrunDbf> GetIsrunInvoiceDoc()
        {
            return DbfTable.Isrun(this.main_form.working_express_db).ToIsrunList().Where(i => i.doctyp.TrimEnd() == "IV" || i.doctyp.TrimEnd() == "HS").OrderBy(i => i.doctyp).ThenBy(i => i.prefix).ToList();
        }

        private void LoadRcvBankDropdownList()
        {
            this.inlineBank._Items.Add(new XDropdownListItem { Text = string.Empty, Value = null });
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                foreach (var item in db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.BANK).OrderBy(i => i.typcod))
                {
                    this.inlineBank._Items.Add(new XDropdownListItem { Text = item.typcod + " : " + item.typdes, Value = item.id });
                }
            }
        }

        private void LoadStmasDgv()
        {
            stmas1 = new BindingList<StmasDbfPrice>(this.GetStmasDbfPrice(new STKGRP[] { STKGRP.FUEL }));
            stmas2 = new BindingList<StmasDbfPrice>(this.GetStmasDbfPrice(new STKGRP[] { STKGRP.OTHER, STKGRP.NA_O }).OrderBy(s => s.stkcod).ToList());

            this.dgvGoods1.DataSource = stmas1;
            this.tabGoods1.Text = "น้ำมันใส (" + stmas1.Count.ToString() + ")";
            this.dgvGoods2.DataSource = stmas2;
            this.tabGoods2.Text = "อื่น ๆ (" + stmas2.Count.ToString() + ")";
        }

        private void FillForm(artrn artrn_to_fill)
        {
            artrn artrn = artrn_to_fill != null ? artrn_to_fill : new artrn();
            
            var cus = DbfTable.Armas(this.main_form.working_express_db, artrn.cuscod.TrimEnd());

            this.cDocnum._Text = artrn.docnum;
            this.cDocdat._SelectedDate = artrn.docdat;
            this.cCuscod._Text = artrn.cuscod;
            this.cNozzle._Text = artrn.youref;
            this.lblCusnam.Text = cus != null ? cus.cusnam.TrimEnd() : string.Empty;
            this.cCshrcv._Value = artrn.cshrcv;
            this.cChqrcv.Text = string.Format("{0:N2}", artrn.chqrcv);
            this.lblAmount.Text = string.Format("{0:n}", artrn.amount);
            this.lblVatrat.Text = string.Format("{0:n}", artrn.vatrat) + "%";
            this.lblVatamt.Text = string.Format("{0:n}", artrn.vatamt);
            this.lblNetval.Text = string.Format("{0:n}", artrn.netval);
            if(artrn.chqrcv + artrn.cshrcv != artrn.amount)
            {
                this.lblNotComplete.Text = "ยอดชำระไม่เท่ากับยอดขาย";
            }
            else if(artrn.docstat == "C")
            {
                this.lblNotComplete.Text = "ถูกยกเลิก";
            }
            else
            {
                this.lblNotComplete.Text = string.Empty;
            }

            this.stcrd = new BindingList<StcrdInvoice>(artrn.stcrd.OrderBy(st => st.seqnum).ToStcrdInvoice());
            this.dgvStcrd.DataSource = this.stcrd;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                int credit_card_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").First().id;
                int coupon_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").First().id;

                var rcv_credit_card_list = artrn.arrcpcq.Where(i => i.rcv_method_id == credit_card_id).OrderBy(i => i.id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
                this.arrcpcq_credit_card = new BindingList<ArrcpcqInvoice>(rcv_credit_card_list);
                this.dgvRcv1.DataSource = this.arrcpcq_credit_card;

                var rcv_coupon_list = artrn.arrcpcq.Where(i => i.rcv_method_id == coupon_id).OrderBy(i => i.id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
                this.arrcpcq_coupon = new BindingList<ArrcpcqInvoice>(rcv_coupon_list);
                this.dgvRcv2.DataSource = this.arrcpcq_coupon;
            }
        }

        private List<StmasDbfPrice> GetStmasDbfPrice(STKGRP[] stkgroups)
        {
            List<StmasDbfPrice> stmas_list = new List<StmasDbfPrice>();
            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
            {
                foreach (var stkgrp in stkgroups)
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "Select st.stkcod as stkcod, st.stkdes as stkdes, st.sellpr1 as sellpr1, st.sellpr2 as sellpr2, st.sellpr3 as sellpr3, st.sellpr4 as sellpr4, st.sellpr5 as sellpr5, st.stkgrp as stkgrp, tab.tabtyp as tabtyp, tab.shortnam2 as shortnam2 From stmas st ";
                        cmd.CommandText += "Left Join istab tab On tab.typcod=st.stkgrp and tab.tabtyp=? ";
                        if(stkgrp == STKGRP.NA_O)
                        {
                            cmd.CommandText += "Where shortnam2 LIKE '%" + stkgrp.ToString() + "%' or LEN(TRIM(shortnam2)) = 0 ";
                            cmd.CommandText += "or (shortnam2 NOT LIKE '%" + STKGRP.FUEL.ToString() + "%' and shortnam2 NOT LIKE '%" + STKGRP.OTHER.ToString() + "%' and shortnam2 NOT LIKE '%" + STKGRP.NA_O.ToString() + "%')";
                            //cmd.CommandText += "Where (shortnam2 NOT LIKE '%" + STKGRP.FUEL.ToString() + "%')";
                        }
                        else
                        {
                            cmd.CommandText += "Where shortnam2 like '%" + stkgrp.ToString() + "%'";
                        }
                        cmd.Parameters.AddWithValue("@tabtyp", "22");

                        conn.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            conn.Close();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                var grp = STKGRP.NA_O;
                                var method = BILL_METHOD.NA_Q;
                                if (!dt.Rows[i].IsNull("shortnam2"))
                                {
                                    grp = dt.Rows[i]["shortnam2"].ToString().Contains(STKGRP.FUEL.ToString()) ? STKGRP.FUEL : (dt.Rows[i]["shortnam2"].ToString().Contains(STKGRP.OTHER.ToString()) ? STKGRP.OTHER : STKGRP.NA_O);
                                    method = dt.Rows[i]["shortnam2"].ToString().Contains(BILL_METHOD.QTY.ToString()) ? BILL_METHOD.QTY : (dt.Rows[i]["shortnam2"].ToString().Contains(BILL_METHOD.VAL.ToString()) ? BILL_METHOD.VAL : BILL_METHOD.NA_Q);
                                }

                                stmas_list.Add(new StmasDbfPrice
                                {
                                    stkcod = !dt.Rows[i].IsNull("stkcod") ? dt.Rows[i]["stkcod"].ToString().TrimEnd() : string.Empty,
                                    stkdes = !dt.Rows[i].IsNull("stkdes") ? dt.Rows[i]["stkdes"].ToString().TrimEnd() : string.Empty,
                                    sellpr1 = !dt.Rows[i].IsNull("sellpr1") ? Convert.ToDecimal(dt.Rows[i]["sellpr1"]) : 0,
                                    sellpr2 = !dt.Rows[i].IsNull("sellpr2") ? Convert.ToDecimal(dt.Rows[i]["sellpr2"]) : 0,
                                    sellpr3 = !dt.Rows[i].IsNull("sellpr3") ? Convert.ToDecimal(dt.Rows[i]["sellpr3"]) : 0,
                                    sellpr4 = !dt.Rows[i].IsNull("sellpr4") ? Convert.ToDecimal(dt.Rows[i]["sellpr4"]) : 0,
                                    sellpr5 = !dt.Rows[i].IsNull("sellpr5") ? Convert.ToDecimal(dt.Rows[i]["sellpr5"]) : 0,
                                    stkgrp = grp,
                                    bill_method = method
                                });
                            }
                        }
                    }
                }
            }
            return stmas_list;
        }

        private void btnManageStkgrp_Click(object sender, EventArgs e)
        {
            DialogStkgrp sg = new DialogStkgrp(this.main_form);
            sg.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadStmasDgv();
            if(this.curr_artrn == null || this.curr_artrn.id < 0)
            {
                this.btnLast.PerformClick();
                return;
            }
            else
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.docnum.TrimEnd() == this.curr_artrn.docnum.TrimEnd()).FirstOrDefault();
                    if (artrn != null)
                    {
                        this.curr_artrn = artrn;
                        this.FillForm(this.curr_artrn);
                    }
                    else
                    {
                        this.btnLast.PerformClick();
                        return;
                    }
                }
            }
        }

        private void dgvGoods1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_g1_sellpr1.Name).First().Index && e.RowIndex > -1)
                {
                    ((XDatagrid)sender).Cursor = Cursors.Hand;
                }
                else
                {
                    ((XDatagrid)sender).Cursor = Cursors.Default;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dgvGoods1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_g1_sellpr1.Name).First().Index && e.RowIndex > -1)
            {
                ((XDatagrid)sender).Cursor = Cursors.Default;
            }
        }

        private void dgvGoods1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
                {
                    this.btnSave.PerformClick();
                }

                if (this.form_mode == FORM_MODE.READ && this.curr_artrn != null && this.curr_artrn.id > -1)
                {
                    if (((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_g1_sellpr1.Name || ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_g2_sellpr1.Name)
                    {
                        bool is_fuel_goods = ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_g1_sellpr1.Name ? true : false;
                        string stkcod;
                        string stkdes;
                        decimal unitpr;

                        BILL_METHOD bill_method;

                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                            if (artrn == null)
                                return;

                            if (is_fuel_goods)
                            {
                                stkcod = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_stkcod.Name].Value.ToString();
                                stkdes = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_stkdes.Name].Value.ToString();
                                unitpr = Convert.ToDecimal(((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_sellpr1.Name].Value);

                                if (artrn.stcrd.Select(s => s.stkcod).Where(s => this.stmas1.Select(st => st.stkcod).Contains(s)).Count() > 0)
                                {
                                    XMessageBox.Show("มีรายการน้ำมันใสในบิลนี้แล้ว\n\t- หากต้องการแก้ไขชนิดน้ำมัน ต้องลบรายการเดิมออกก่อน\n\t- หากต้องการแก้ไขจำนวนเงินให้คลิกที่ปุ่มแก้ไขที่ท้ายรายการนั้น ๆ", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                                    return;
                                }
                                bill_method = (BILL_METHOD)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_bill_method.Name].Value;
                            }
                            else
                            {
                                stkcod = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g2_stkcod.Name].Value.ToString();
                                stkdes = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g2_stkdes.Name].Value.ToString();
                                unitpr = Convert.ToDecimal(((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g2_sellpr1.Name].Value);
                                bill_method = (BILL_METHOD)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g2_bill_method.Name].Value;
                            }

                            if (artrn.stcrd.Where(s => s.stkcod == stkcod).Count() > 0)
                            {
                                XMessageBox.Show("มีรายการสินค้านี้อยู่ในบิลแล้ว, หากต้องการแก้ไขจำนวน/มูลค่า กรุณาคลิกที่ปุ่มแก้ไขที่ท้ายรายการนั้น ๆ", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                                return;
                            }


                            /*************/
                            StmasDbf stmas = DbfTable.Stmas(this.main_form.working_express_db.abs_path, stkcod);

                            var tmp_stcrd = new stcrd
                            {
                                docnum = artrn.docnum,
                                artrn_id = artrn.id,
                                stkcod = stkcod,
                                stkdes = stkdes,
                                unitpr = unitpr,
                                docdat = artrn.docdat,
                                slmcod = artrn.slmcod,
                                depcod = artrn.depcod,
                                loccod = this.curr_docprefix.loccod.TrimEnd(),
                                people = artrn.cuscod,
                                tqucod = stmas.squcod,
                                tfactor = Convert.ToDecimal(stmas.sfactor),
                                posopr = "9",
                                creby = this.main_form.loged_in_status.loged_in_user_name,
                                userid = this.main_form.loged_in_status.loged_in_user_name

                            };

                            var artrn_to_update = db.artrn.Include("stcrd").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                            if(artrn_to_update == null)
                            {
                                XMessageBox.Show("เอกสารเลขที่ " + this.curr_artrn.docnum + " ไม่มีอยู่ในระบบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                                return;
                            }

                            if (bill_method == BILL_METHOD.VAL)
                            {
                                DialogSellValue ds = new DialogSellValue(this.main_form, artrn, tmp_stcrd);
                                if (ds.ShowDialog() != DialogResult.OK)
                                    return;

                                artrn_to_update.youref = ds.selected_nozzle.name;
                                tmp_stcrd.loccod = this.curr_nozzle != null ? this.curr_nozzle.section.loccod : tmp_stcrd.loccod;
                            }
                            else
                            {
                                DialogSellQty ds = new DialogSellQty(this.main_form, artrn, tmp_stcrd);
                                if (ds.ShowDialog() != DialogResult.OK)
                                    return;
                            }

                            try
                            {
                                if (artrn_to_update != null)
                                {
                                    if (is_fuel_goods)
                                    {
                                        if (artrn_to_update.stcrd.Select(s => s.stkcod).Where(s => this.stmas1.Select(st => st.stkcod).Contains(s)).Count() > 0)
                                        {
                                            XMessageBox.Show("มีรายการน้ำมันใสในบิลนี้แล้ว\n\t- หากต้องการแก้ไขชนิดน้ำมัน ต้องลบรายการเดิมออกก่อน\n\t- หากต้องการแก้ไขจำนวนเงินให้คลิกที่ปุ่มแก้ไขที่ท้ายรายการนั้น ๆ", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                                            this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                                            this.FillForm(this.curr_artrn);
                                            return;
                                        }
                                    }
                                    if (artrn_to_update.stcrd.Where(s => s.stkcod == stkcod).Count() > 0)
                                    {
                                        XMessageBox.Show("มีรายการสินค้านี้อยู่ในบิลแล้ว, หากต้องการแก้ไขจำนวน/มูลค่า กรุณาคลิกที่ปุ่มแก้ไขที่ท้ายรายการนั้น ๆ", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                                        this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                                        this.FillForm(this.curr_artrn);
                                        return;
                                    }

                                    tmp_stcrd.seqnum = artrn_to_update.nxtseq.Trim().Length == 0 ? 1.FillSpaceBeforeNum(3) : (Convert.ToInt32(artrn_to_update.nxtseq) + 1).FillSpaceBeforeNum(3);
                                    db.stcrd.Add(tmp_stcrd);

                                    artrn_to_update.CalNeccessaryValue();
                                    artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                                    artrn_to_update.chgdat = DateTime.Now;

                                    if (db.SaveChanges() > 0)
                                    {
                                        this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                                        this.FillForm(this.curr_artrn);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, XMessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //List<XDropdownListItem> items = new List<XDropdownListItem>();
            //this.GetIsrunInvoiceDoc().ForEach(i => items.Add(new XDropdownListItem { Text = i.prefix.TrimEnd() + " : " + i.posdes.TrimEnd(), Value = i }));
            //DialogDropdownlistSelector dr = new DialogDropdownlistSelector("เลือกประเภทรายการขาย", "ประเภทการขาย", items, this.curr_docprefix);
            //if (dr.ShowDialog() == DialogResult.OK)
            //{
            //    this.lblDocType.Text = dr.selected_item.Text;
            //    this.curr_docprefix = (IsrunDbf)dr.selected_item.Value;

            //    this.tabRcv.SelectedTab = this.tabCreditCard;
            //    this.panelRcv.Enabled = this.curr_docprefix.doctyp == "HS" ? true : false;

            //    this.tmp_artrn = new artrn
            //    {
            //        rectyp = this.curr_docprefix.doctyp.TrimEnd() == "HS" ? "1" : (this.curr_docprefix.doctyp.TrimEnd() == "IV" ? "3" : ""),
            //        docnum = this.curr_docprefix + "**NEW**",
            //        docdat = DateTime.Now,
            //        depcod = this.curr_docprefix.depcod,
            //        flgvat = this.curr_docprefix.flgvat,
            //        duedat = DateTime.Now,
            //        bilnum = "~",
            //        vatrat = this.curr_docprefix.vatrat,
            //        docstat = "N",
            //        srv_vattyp = this.curr_docprefix.srv_vattyp != "" ? this.curr_docprefix.srv_vattyp : "-",
            //        creby = this.main_form.loged_in_status.loged_in_user_name,
            //        credat = DateTime.Now,
            //        userid = this.main_form.loged_in_status.loged_in_user_name,
            //        chgdat = DateTime.Now,
            //        cmplapp = this.curr_docprefix.doctyp == "HS" ? "Y" : "N",
            //        cmpldat = this.curr_docprefix.doctyp == "HS" ? (DateTime?)DateTime.Now : null
            //        //stcrd = new List<stcrd> { new stcrd { stkcod = "01-INTL-CL-600" }, new stcrd { stkcod = "01-INTL-PT-750" } }
            //    };

            //    this.ResetFormState(FORM_MODE.ADD);
            //    this.FillForm(this.tmp_artrn);

            //    this.cCuscod.Focus();
            //}

            this.tabRcv.SelectedTab = this.tabCreditCard;
            this.panelRcv.Enabled = this.curr_docprefix.doctyp == "HS" ? true : false;

            this.tmp_artrn = new artrn
            {
                rectyp = this.curr_docprefix.doctyp.TrimEnd() == "HS" ? "1" : (this.curr_docprefix.doctyp.TrimEnd() == "IV" ? "3" : ""),
                docnum = this.curr_docprefix + "**NEW**",
                docdat = DateTime.Now,
                depcod = this.curr_docprefix.depcod,
                flgvat = this.curr_docprefix.flgvat,
                duedat = DateTime.Now,
                bilnum = "~",
                vatrat = this.curr_docprefix.vatrat,
                docstat = "N",
                srv_vattyp = this.curr_docprefix.srv_vattyp != "" ? this.curr_docprefix.srv_vattyp : "-",
                creby = this.main_form.loged_in_status.loged_in_user_name,
                credat = DateTime.Now,
                userid = this.main_form.loged_in_status.loged_in_user_name,
                chgdat = DateTime.Now,
                cmplapp = this.curr_docprefix.doctyp == "HS" ? "Y" : "N",
                cmpldat = this.curr_docprefix.doctyp == "HS" ? (DateTime?)DateTime.Now : null
            };

            this.ResetFormState(FORM_MODE.ADD);
            this.FillForm(this.tmp_artrn);

            this.cCuscod.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            if (this.curr_artrn.docstat == "C")
            {
                XMessageBox.Show("เอกสารถูกยกเลิกแล้ว");
                return;
            }

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.tmp_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();

                if(this.tmp_artrn != null)
                {
                    this.FillForm(this.tmp_artrn);
                    this.ResetFormState(FORM_MODE.EDIT);
                    this.cCuscod.Focus();
                }
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            if (XMessageBox.Show("กรุณาเลือกตกลง เพื่อยืนยันให้ยกเลิกเอกสาร", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var artrn_to_update = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();

                if(artrn_to_update == null)
                {
                    XMessageBox.Show("เอกสารเลขที่ " + this.curr_artrn.docnum + " ไม่มีอยู่ในระบบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }

                artrn_to_update.stcrd.ToList().ForEach(s => db.stcrd.Remove(s));
                artrn_to_update.arrcpcq.ToList().ForEach(a => db.arrcpcq.Remove(a));

                artrn_to_update.docstat = "C";
                artrn_to_update.cmplapp = "Y";
                artrn_to_update.cmpldat = DateTime.Now;
                artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                artrn_to_update.chgdat = DateTime.Now;
                artrn_to_update.CalNeccessaryValue();

                if(db.SaveChanges() > 0)
                {
                    this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                    this.FillForm(this.curr_artrn);
                    Console.WriteLine(" ==> Void document completed.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            if(this.curr_artrn.docstat != "C")
            {
                XMessageBox.Show("สถานะเอกสารต้องเป็น \"ถูกยกเลิก\" เสียก่อน");
                return;
            }

            if (XMessageBox.Show("ลบข้อมูลนี้หรือไม่", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    var artrn_to_delete = db.artrn.Find(this.curr_artrn.id);
                    db.artrn.Remove(artrn_to_delete);

                    db.stcrd.Where(s => s.artrn_id == this.curr_artrn.id).ToList().ForEach(s => db.stcrd.Remove(s));
                    db.arrcpcq.Where(s => s.artrn_id == this.curr_artrn.id).ToList().ForEach(s => db.arrcpcq.Remove(s));

                    if(db.SaveChanges() > 0)
                    {
                        this.btnNext.PerformClick();
                        Console.WriteLine(" ==> Deleted.");
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
            {
                if (XMessageBox.Show("ยกเลิกการเพิ่ม/แก้ไขข้อมูล, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.ResetFormState(FORM_MODE.READ);
                    this.tmp_artrn = null;
                    this.FillForm(this.curr_artrn);
                }

                return;
            }

            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                if (XMessageBox.Show("ยกเลิกการเพิ่ม/แก้ไขข้อมูล, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.ResetFormState(FORM_MODE.READ);
                    this.HideInlineForm();
                    this.FillForm(this.curr_artrn);
                }

                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                try
                {
                    if((this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT) && this.tmp_artrn.cuscod.Trim().Length == 0)
                    {
                        this.cCuscod.Focus();
                        return;
                    }

                    if((this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT) && this.cDocdat._SelectedDate == null)
                    {
                        this.cDocdat.Focus();
                        SendKeys.Send("{F6}");
                        return;
                    }

                    if (this.form_mode == FORM_MODE.ADD)
                    {
                        var isrun = DbfTable.Isrun(this.main_form.working_express_db).ToIsrunList().Where(i => i.prefix == this.curr_docprefix.prefix).FirstOrDefault();
                        this.tmp_artrn.docnum = isrun.GetNextDocnum(this.main_form.working_express_db);
                        this.tmp_artrn.credat = DateTime.Now;
                        this.tmp_artrn.chgdat = DateTime.Now;
                        this.tmp_artrn.stcrd.ToList().ForEach(s =>
                        {
                            s.docnum = this.tmp_artrn.docnum;
                            s.artrn_id = this.tmp_artrn.id;
                            s.credat = DateTime.Now;
                            s.chgdat = DateTime.Now;
                        });

                        db.artrn.Add(this.tmp_artrn);
                        if (db.SaveChanges() > 0)
                        {
                            var next_docnum = Helper.CalNextDocnum(this.tmp_artrn.docnum);
                            isrun.SetNextDocnum(this.main_form.working_express_db, next_docnum);
                            this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.tmp_artrn.id).FirstOrDefault();
                            this.FillForm(this.curr_artrn);
                            this.ResetFormState(FORM_MODE.READ);
                        }
                    }

                    if (this.form_mode == FORM_MODE.EDIT)
                    {
                        var artrn_to_update = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.tmp_artrn.id).FirstOrDefault();

                        artrn_to_update.cuscod = this.tmp_artrn.cuscod;
                        artrn_to_update.orgnum = this.tmp_artrn.orgnum;
                        artrn_to_update.slmcod = this.tmp_artrn.slmcod;
                        artrn_to_update.areacod = this.tmp_artrn.areacod;
                        artrn_to_update.docdat = this.tmp_artrn.docdat;
                        artrn_to_update.paytrm = this.tmp_artrn.paytrm;
                        artrn_to_update.duedat = this.tmp_artrn.docdat.AddDays(this.tmp_artrn.paytrm);
                        artrn_to_update.taxrat = this.tmp_artrn.taxrat;
                        artrn_to_update.vatdat = this.tmp_artrn.vatdat;
                        artrn_to_update.dlvby = this.tmp_artrn.dlvby;
                        artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                        artrn_to_update.chgdat = DateTime.Now;
                        artrn_to_update.stcrd.ToList().ForEach(st =>
                        {
                            st.people = this.tmp_artrn.cuscod;
                            st.docdat = this.tmp_artrn.docdat;
                            st.slmcod = this.tmp_artrn.slmcod;
                        });
                        
                        if(db.SaveChanges() > 0)
                        {
                            this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.tmp_artrn.id).FirstOrDefault();

                            this.ResetFormState(FORM_MODE.READ);
                            this.FillForm(this.curr_artrn);
                        }
                    }

                    if (this.form_mode == FORM_MODE.EDIT_ITEM)
                    {
                        if (this.tmp_arrcpcq != null)
                        {
                            if(this.curr_artrn.cshrcv == 0)
                            {
                                XMessageBox.Show("ยอดชำระต้องไม่มากกว่ายอดขายสินค้า", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                return;
                            }

                            if(this.tmp_arrcpcq.rcvamt == 0)
                            {
                                XMessageBox.Show("ยอดชำระต้องมากกว่า 0.00", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                return;
                            }

                            if(this.curr_artrn.cshrcv > 0 && this.tmp_arrcpcq.rcvamt > this.curr_artrn.cshrcv)
                            {
                                XMessageBox.Show("ยอดชำระต้องน้อยกว่าหรือเท่ากับ " + String.Format("{0:N2}", this.curr_artrn.cshrcv), "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                return;
                            }

                            var artrn_to_update = db.artrn.Find(this.curr_artrn.id);
                            artrn_to_update.chqrcv += this.tmp_arrcpcq.rcvamt;
                            artrn_to_update.cshrcv -= this.tmp_arrcpcq.rcvamt;
                            artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                            artrn_to_update.chgdat = DateTime.Now;

                            this.tmp_arrcpcq.chgdat = DateTime.Now;
                            db.arrcpcq.Add(this.tmp_arrcpcq);

                            if (db.SaveChanges() > 0)
                            {
                                int arrcpcq_id = this.tmp_arrcpcq.id;

                                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                                this.HideInlineForm();
                                this.FillForm(this.curr_artrn);
                                this.ResetFormState(FORM_MODE.READ);
                                if(this.tabRcv.SelectedTab == this.tabCreditCard)
                                {
                                    this.dgvRcv1.Rows.Cast<DataGridViewRow>().Where(r => ((arrcpcq)r.Cells[this.col_rcv1_arrcpcq.Name].Value).id == arrcpcq_id).First().Cells[this.dgvRcv1.FirstDisplayedCell.ColumnIndex].Selected = true;
                                    return;
                                }

                                if(this.tabRcv.SelectedTab == this.tabCoupon)
                                {
                                    this.dgvRcv2.Rows.Cast<DataGridViewRow>().Where(r => ((arrcpcq)r.Cells[this.col_rcv2_arrcpcq.Name].Value).id == arrcpcq_id).First().Cells[this.dgvRcv2.FirstDisplayedCell.ColumnIndex].Selected = true;
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").OrderBy(a => a.docnum).Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix).FirstOrDefault();
                this.FillForm(this.curr_artrn);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").OrderByDescending(a => a.docnum).Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix && a.docnum.CompareTo(this.curr_artrn.docnum) < 0).FirstOrDefault();
                if(this.curr_artrn == null)
                {
                    this.btnFirst.PerformClick();
                    return;
                }
                else
                {
                    this.FillForm(this.curr_artrn);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").OrderBy(a => a.docnum).Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix && a.docnum.CompareTo(this.curr_artrn.docnum) > 0).FirstOrDefault();
                if(this.curr_artrn == null)
                {
                    this.btnLast.PerformClick();
                    return;
                }
                else
                {
                    this.FillForm(this.curr_artrn);
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").OrderByDescending(a => a.docnum).Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix).FirstOrDefault();
                this.FillForm(this.curr_artrn);
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            //DialogSimpleSearch ds = new DialogSimpleSearch("เลขที่เอกสาร", "");
            DialogSearchDocnum ds = new DialogSearchDocnum(this.curr_docprefix.prefix.RewriteToTextMask() + "AAAAAAAAAA");
            if(ds.ShowDialog() == DialogResult.OK)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.docnum.TrimEnd().CompareTo(ds.keyword.TrimEnd()) == 0).FirstOrDefault();
                    if(artrn != null)
                    {
                        this.curr_artrn = artrn;
                        this.FillForm(this.curr_artrn);
                    }
                    else
                    {
                        XMessageBox.Show("ค้นหาเอกสารเลขที่ " + ds.keyword + " ไม่พบ", "");
                    }
                }
            }
        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                List<dynamic> list = db.artrn.Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix).Select(a => new ArtrnInquiry { express_data_path = this.main_form.working_express_db.abs_path, docdat = a.docdat, docnum = a.docnum, cuscod = a.cuscod, amount = a.amount }).ToList<dynamic>();
                DataGridViewTextBoxColumn col_artrn = new DataGridViewTextBoxColumn
                {
                    Name = "col_artrn",
                    Visible = false,
                    DataPropertyName = "artrn"
                };
                DataGridViewTextBoxColumn col_express_data_path = new DataGridViewTextBoxColumn
                {
                    Name = "col_express_data_path",
                    Visible = false,
                    DataPropertyName = "express_data_path"
                };
                DataGridViewTextBoxColumn col_docdat = new DataGridViewTextBoxColumn
                {
                    Name = "col_docdat",
                    DataPropertyName = "docdat",
                    HeaderText = "วันที่",
                    Width = 100,
                    MinimumWidth = 100
                };
                DataGridViewTextBoxColumn col_docnum = new DataGridViewTextBoxColumn
                {
                    Name = "col_docnum",
                    DataPropertyName = "docnum",
                    HeaderText = "เลขที่",
                    Width = 120,
                    MinimumWidth = 120
                };
                DataGridViewTextBoxColumn col_cuscod = new DataGridViewTextBoxColumn
                {
                    Name = "col_cuscod",
                    DataPropertyName = "cuscod",
                    HeaderText = "รหัสลูกค้า",
                    Width = 140,
                    MinimumWidth = 140
                };
                DataGridViewTextBoxColumn col_cusnam = new DataGridViewTextBoxColumn
                {
                    Name = "col_cusnam",
                    DataPropertyName = "cusnam",
                    HeaderText = "ชื่อลูกค้า",
                    Width = 200,
                    MinimumWidth = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                DataGridViewTextBoxColumn col_amount = new DataGridViewTextBoxColumn
                {
                    Name = "col_amount",
                    DataPropertyName = "amount",
                    HeaderText = "จำนวนเงิน",
                    Width = 140,
                    MinimumWidth = 140
                };
                List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
                {
                    col_artrn, col_express_data_path, col_docdat, col_docnum, col_cuscod, col_cusnam, col_amount
                };

                DialogInquiry di = new DialogInquiry(list, cols, col_docnum);
                if(di.ShowDialog() == DialogResult.OK)
                {
                    string docnum = di.selected_row.Cells[col_docnum.Name].Value.ToString();
                    var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.docnum == docnum).FirstOrDefault();
                    if(artrn != null)
                    {
                        this.curr_artrn = artrn;
                        this.FillForm(this.curr_artrn);
                    }
                    else
                    {
                        XMessageBox.Show("ค้นหาเอกสารเลขที่ " + docnum + " ไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                List<dynamic> list = db.artrn.Where(a => a.docnum.Substring(0, 2) == this.curr_docprefix.prefix).Select(a => new ArtrnInquiry { express_data_path = this.main_form.working_express_db.abs_path, docdat = a.docdat, docnum = a.docnum, cuscod = a.cuscod, amount = a.amount }).ToList<dynamic>();
                DataGridViewTextBoxColumn col_artrn = new DataGridViewTextBoxColumn
                {
                    Name = "col_artrn",
                    Visible = false,
                    DataPropertyName = "artrn"
                };
                DataGridViewTextBoxColumn col_express_data_path = new DataGridViewTextBoxColumn
                {
                    Name = "col_express_data_path",
                    Visible = false,
                    DataPropertyName = "express_data_path"
                };
                DataGridViewTextBoxColumn col_docdat = new DataGridViewTextBoxColumn
                {
                    Name = "col_docdat",
                    DataPropertyName = "docdat",
                    HeaderText = "วันที่",
                    Width = 100,
                    MinimumWidth = 100
                };
                DataGridViewTextBoxColumn col_docnum = new DataGridViewTextBoxColumn
                {
                    Name = "col_docnum",
                    DataPropertyName = "docnum",
                    HeaderText = "เลขที่",
                    Width = 120,
                    MinimumWidth = 120
                };
                DataGridViewTextBoxColumn col_cuscod = new DataGridViewTextBoxColumn
                {
                    Name = "col_cuscod",
                    DataPropertyName = "cuscod",
                    HeaderText = "รหัสลูกค้า",
                    Width = 140,
                    MinimumWidth = 140
                };
                DataGridViewTextBoxColumn col_cusnam = new DataGridViewTextBoxColumn
                {
                    Name = "col_cusnam",
                    DataPropertyName = "cusnam",
                    HeaderText = "ชื่อลูกค้า",
                    Width = 200,
                    MinimumWidth = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                DataGridViewTextBoxColumn col_amount = new DataGridViewTextBoxColumn
                {
                    Name = "col_amount",
                    DataPropertyName = "amount",
                    HeaderText = "จำนวนเงิน",
                    Width = 140,
                    MinimumWidth = 140
                };
                List<DataGridViewColumn> cols = new List<DataGridViewColumn>()
                {
                    col_artrn, col_express_data_path, col_docdat, col_docnum, col_cuscod, col_cusnam, col_amount
                };

                DialogInquiry di;
                if(this.curr_artrn != null && this.curr_artrn.id > 0)
                {
                    di = new DialogInquiry(list, cols, col_docnum, this.curr_artrn.docnum);
                }
                else
                {
                    di = new DialogInquiry(list, cols, col_docnum, null);
                }

                if (di.ShowDialog() == DialogResult.OK)
                {
                    string docnum = di.selected_row.Cells[col_docnum.Name].Value.ToString();
                    var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.docnum == docnum).FirstOrDefault();
                    if (artrn != null)
                    {
                        this.curr_artrn = artrn;
                        this.FillForm(this.curr_artrn);
                    }
                    else
                    {
                        XMessageBox.Show("ค้นหาเอกสารเลขที่ " + docnum + " ไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                        return;
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.btnPrintA4.PerformClick();
        }

        private void btnPrintA4_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                if (artrn == null)
                {
                    XMessageBox.Show("ค้นหาเอกสารเลขที่ " + this.curr_artrn.docnum + " ไม่พบ");
                    return;
                }

                int total_page = XPrintPreview.GetTotalPageCount(MakePrintDoc(artrn, this.main_form.working_express_db, PaperKind.A4));

                DialogPrintSetupA ps = new DialogPrintSetupA();
                if (ps.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument print_doc = MakePrintDoc(artrn, this.main_form.working_express_db, PaperKind.A4, total_page);

                    if (ps.output == PRINT_OUTPUT.PRINTER)
                    {
                        PrintDialog pd = new PrintDialog();
                        pd.Document = print_doc;
                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            pd.Document.Print();
                        }
                    }

                    if (ps.output == PRINT_OUTPUT.SCREEN)
                    {
                        XPrintPreview xp = new XPrintPreview(print_doc, total_page, PRINT_AUTHORIZE_STATE.READY_TO_PRINT, artrn.docnum);
                        xp.MdiParent = this.main_form;
                        xp.Show();
                    }
                }
            }
        }

        private void btnPrintA5_Click(object sender, EventArgs e)
        {
            if (this.curr_artrn == null || this.curr_artrn.id < 0)
                return;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                if (artrn == null)
                {
                    XMessageBox.Show("ค้นหาเอกสารเลขที่ " + this.curr_artrn.docnum + " ไม่พบ");
                    return;
                }

                int total_page = XPrintPreview.GetTotalPageCount(MakePrintDoc(artrn, this.main_form.working_express_db, PaperKind.A5));

                DialogPrintSetupA ps = new DialogPrintSetupA();
                if (ps.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument print_doc = MakePrintDoc(artrn, this.main_form.working_express_db, PaperKind.A5, total_page);

                    if (ps.output == PRINT_OUTPUT.PRINTER)
                    {
                        PrintDialog pd = new PrintDialog();
                        pd.Document = print_doc;
                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            pd.Document.Print();
                        }
                    }

                    if (ps.output == PRINT_OUTPUT.SCREEN)
                    {
                        XPrintPreview xp = new XPrintPreview(print_doc, total_page, PRINT_AUTHORIZE_STATE.READY_TO_PRINT, artrn.docnum);
                        xp.MdiParent = this.main_form;
                        xp.Show();
                    }
                }
            }
        }

        public static PrintDocument MakePrintDoc(artrn artrn_to_print, SccompDbf working_express_db, PaperKind paper_kind = PaperKind.A4, int? total_page = null)
        {
            string[] doc_title = artrn_to_print.rectyp == "1" ? new string[] { "ใบเสร็จรับเงิน/ใบกำกับภาษี", "RECEIPT/TAX INVOICE" } : new string[] { "ใบกำกับสินค้า/ใบกำกับภาษี", "TAX INVOICE" };
            DataTable dt_isinfo = DbfTable.Isinfo(working_express_db);
            string compnam = !dt_isinfo.Rows[0].IsNull("thinam") ? dt_isinfo.Rows[0].Field<string>("thinam").TrimEnd() : string.Empty;
            string comp_addr01 = !dt_isinfo.Rows[0].IsNull("addr01") ? dt_isinfo.Rows[0].Field<string>("addr01").TrimEnd() : string.Empty;
            string comp_addr02 = !dt_isinfo.Rows[0].IsNull("addr02") ? dt_isinfo.Rows[0].Field<string>("addr02").TrimEnd() : string.Empty;
            string comp_telnum = !dt_isinfo.Rows[0].IsNull("telnum") ? dt_isinfo.Rows[0].Field<string>("telnum").TrimEnd() : string.Empty;
            string comp_taxid = !dt_isinfo.Rows[0].IsNull("taxid") ? dt_isinfo.Rows[0].Field<string>("taxid").TrimEnd() : string.Empty;

            ArmasDbf armas = DbfTable.Armas(working_express_db, artrn_to_print.cuscod);
            string cusnam = armas != null ? armas.prenam.TrimEnd() + " " + armas.cusnam.TrimEnd() : string.Empty;
            string addr = armas != null ? armas.addr01.TrimEnd() + " " + armas.addr02.TrimEnd() + " " + armas.addr03.TrimEnd() + " " + armas.zipcod.TrimEnd() : string.Empty;
            string telnum = armas != null ? armas.telnum.TrimEnd() : string.Empty;
            string remark = armas != null ? armas.remark.TrimEnd() : string.Empty;

            Font fnt_xlarge = paper_kind == PaperKind.A4 ? new Font("angsana new", 20f, FontStyle.Regular) : new Font("angsana new", 18f, FontStyle.Regular);
            Font fnt_xlarge_bold = paper_kind == PaperKind.A4 ? new Font("angsana new", 20f, FontStyle.Bold) : new Font("angsana new", 18f, FontStyle.Bold);
            Font fnt_large = paper_kind == PaperKind.A4 ? new Font("angsana new", 18f, FontStyle.Regular) : new Font("angsana new", 14f, FontStyle.Regular);
            Font fnt_large_bold = paper_kind == PaperKind.A4 ? new Font("angsana new", 18f, FontStyle.Bold) : new Font("angsana new", 14f, FontStyle.Bold);
            Font fnt_medium = paper_kind == PaperKind.A4 ? new Font("angsana new", 14f, FontStyle.Regular) : new Font("angsana new", 10f, FontStyle.Regular);
            Font fnt_medium_bold = paper_kind == PaperKind.A4 ? new Font("angsana new", 14f, FontStyle.Bold) : new Font("angsana new", 10f, FontStyle.Bold);
            Font fnt_small = paper_kind == PaperKind.A4 ? new Font("angsana new", 12f, FontStyle.Regular) : new Font("angsana new", 8f, FontStyle.Regular);
            Font fnt_small_bold = paper_kind == PaperKind.A4 ? new Font("angsana new", 12f, FontStyle.Bold) : new Font("angsana new", 8f, FontStyle.Bold);

            Pen p = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat format_left = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_right = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };
            StringFormat format_center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap };

            int page = 0;
            int item_count = 0;

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Margins = paper_kind == PaperKind.A4 ? new Margins(46, 45, 20, 30) : new Margins(33, 620/*30*/, 15, 20);
            PaperSize paper_size = pd.PrinterSettings.PaperSizes.Cast<PaperSize>().First(size => size.Kind == PaperKind.A4 /*paper_kind*/);
            pd.DefaultPageSettings.PaperSize = paper_size;
            pd.DefaultPageSettings.Landscape = paper_kind == PaperKind.A4 ? false : true;

            pd.BeginPrint += delegate(object sender, PrintEventArgs e)
            {
                page = 0;
                item_count = 0;
            };

            pd.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int line_height = paper_kind == PaperKind.A4 ? fnt_medium.Height + 3 : fnt_medium.Height + 2;
                int max_column = 16;
                int max_item_row = paper_kind == PaperKind.A4 ? 18 : 18/*16*/;
                int col_width = e.MarginBounds.Width / max_column;

                List<int> columns = new List<int>();
                for (int i = 0; i < max_column; i++)
                {
                    columns.Add(e.MarginBounds.Left + (col_width * i));
                }

                List<int> lines = new List<int>();
                for (int i = 0; i < Convert.ToInt32(Math.Round((double)(e.MarginBounds.Bottom - e.MarginBounds.Top) / line_height)) ; i++)
                {
                    lines.Add(e.MarginBounds.Top + (line_height * i));
                }

                List<List<Rectangle>> grid = new List<List<Rectangle>>();
                for (int line = 0; line < lines.Count; line++)
                {
                    grid.Add(new List<Rectangle>());
                    for (int col = 0; col < columns.Count; col++)
                    {
                        Rectangle rect = new Rectangle(columns[col], lines[line], col_width, line_height);
                        grid[line].Add(rect);
                    }
                }

                page++;

                /* draw vertical grid line */
                //int rec_cnt = 0;
                //foreach (var rec in grid[0])
                //{
                //    e.Graphics.DrawLine(new Pen(Color.Gainsboro), new Point(rec.X, e.MarginBounds.Top), new Point(rec.X, e.MarginBounds.Bottom));
                //    e.Graphics.DrawString(rec_cnt.ToString(), fnt_large, new SolidBrush(Color.Gray), rec, format_center);
                //    rec_cnt++;
                //}
                //e.Graphics.DrawLine(new Pen(Color.Gainsboro), new Point(grid[0].Last().X + grid[0].Last().Width, e.MarginBounds.Top), new Point(grid[0].Last().X + grid[0].Last().Width, e.MarginBounds.Bottom));

                if (total_page != null)
                    e.Graphics.DrawString("หน้า " + page.ToString() + " / " + total_page.ToString(), fnt_small_bold, brush, new Rectangle(grid[0][15].X, grid[0][15].Y, col_width * 2, line_height));

                e.Graphics.DrawString(compnam, fnt_large_bold, brush, new Rectangle(grid[2][0].X, grid[2][0].Y - 5, col_width * 11, line_height + 5));
                e.Graphics.DrawString(comp_addr01 + " " + comp_addr02, fnt_medium, brush, new Rectangle(grid[3][0].X, grid[3][0].Y, col_width * 11, line_height));
                e.Graphics.DrawString("โทร. " + comp_telnum, fnt_medium, brush, new Rectangle(grid[4][0].X, grid[4][0].Y, col_width * 11, line_height));
                e.Graphics.DrawString("เลขประจำตัวผู้เสียภาษี " + comp_taxid, fnt_medium, brush, new Rectangle(grid[5][0].X, grid[5][0].Y, col_width * 11, line_height));

                

                e.Graphics.DrawString(doc_title[0], fnt_large_bold, brush, new Rectangle(grid[2][11].X, grid[2][11].Y, col_width * 5, line_height), format_center);
                e.Graphics.DrawString(doc_title[1], fnt_large_bold, brush, new Rectangle(grid[3][11].X, grid[3][11].Y, col_width * 5, line_height), format_center);

                e.Graphics.DrawString("เลขที่", fnt_medium_bold, brush, new Rectangle(grid[7][12].X, grid[7][12].Y, col_width, line_height));
                e.Graphics.DrawString(artrn_to_print.docnum, fnt_medium_bold, brush, new Rectangle(grid[7][13].X, grid[7][13].Y, col_width * 3, line_height));

                e.Graphics.DrawString("วันที่", fnt_medium_bold, brush, new Rectangle(grid[8][12].X, grid[8][12].Y, col_width, line_height));
                e.Graphics.DrawString(artrn_to_print.docdat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")), fnt_medium_bold, brush, new Rectangle(grid[8][13].X, grid[8][13].Y, col_width * 3, line_height));

                e.Graphics.DrawString("ได้รับเงินจาก", fnt_medium_bold, brush, new Rectangle(grid[7][0].X, grid[7][0].Y, col_width * 10, line_height));
                e.Graphics.DrawString(cusnam, fnt_medium, brush, new Rectangle(grid[7][2].X, grid[7][2].Y, col_width * 8, line_height));
                e.Graphics.DrawString("ที่อยู่", fnt_medium_bold, brush, new Rectangle(grid[8][0].X, grid[8][0].Y, col_width * 10, line_height));
                e.Graphics.DrawString(addr, fnt_medium, brush, new Rectangle(grid[8][1].X, grid[8][1].Y, col_width * 11, line_height));
                e.Graphics.DrawString("เลขทะเบียนรถยนต์", fnt_medium_bold, brush, new Rectangle(grid[9][0].X, grid[9][0].Y, col_width * 10, line_height));
                e.Graphics.DrawString(remark, fnt_medium, brush, new Rectangle(grid[9][3].X, grid[9][3].Y, col_width * 7, line_height));

                e.Graphics.DrawRectangle(p, new Rectangle(grid[11][0].X, grid[11][0].Y, col_width * 16, line_height * max_item_row));
                e.Graphics.DrawLine(p, new Point(grid[13][0].X, grid[13][0].Y), new Point(grid[13][0].X + (col_width * 16), grid[13][0].Y));
                e.Graphics.DrawLine(p, new Point(grid[11][1].X, grid[11][1].Y), new Point(grid[11][1].X, grid[11][1].Y + (line_height * max_item_row)));
                e.Graphics.DrawLine(p, new Point(grid[11][10].X, grid[11][10].Y), new Point(grid[11][10].X, grid[11][10].Y + (line_height * max_item_row)));
                e.Graphics.DrawLine(p, new Point(grid[11][10].X, grid[11][10].Y), new Point(grid[11][10].X, grid[11][10].Y + (line_height * max_item_row)));
                e.Graphics.DrawLine(p, new Point(grid[11][10].X, grid[11][10].Y), new Point(grid[11][10].X, grid[11][10].Y + (line_height * max_item_row)));
                e.Graphics.DrawLine(p, new Point(grid[11][12].X, grid[11][12].Y), new Point(grid[11][12].X, grid[11][12].Y + (line_height * max_item_row)));
                e.Graphics.DrawLine(p, new Point(grid[11][14].X, grid[11][14].Y), new Point(grid[11][14].X, grid[11][14].Y + (line_height * max_item_row)));
                e.Graphics.DrawRectangle(p, new Rectangle(grid[11 + max_item_row][0].X, grid[11 + max_item_row][0].Y, col_width * 16, line_height * 3));
                e.Graphics.DrawLine(p, new Point(grid[11 + max_item_row][14].X, grid[11 + max_item_row][14].Y), new Point(grid[11 + max_item_row + 3][14].X, grid[11 + max_item_row + 3][14].Y));
                e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), new Rectangle(grid[11 + max_item_row + 3][0].X, grid[11 + max_item_row + 3][0].Y, col_width * 16, line_height));
                e.Graphics.DrawRectangle(p, new Rectangle(grid[11 + max_item_row + 3][0].X, grid[11 + max_item_row + 3][0].Y, col_width * 16, line_height));

                if (total_page != null && page == total_page)
                    e.Graphics.DrawString(artrn_to_print.amount.ToBahtText(true), fnt_medium_bold, brush, new Rectangle(grid[11 + max_item_row + 3][0].X, grid[11 + max_item_row + 3][0].Y, col_width * 16, line_height));

                e.Graphics.DrawString("ลำดับ", fnt_medium_bold, brush, new Rectangle(grid[11][0].X, grid[11][0].Y, col_width, line_height), format_center);
                e.Graphics.DrawString("No.", fnt_medium_bold, brush, new Rectangle(grid[12][0].X, grid[12][0].Y, col_width, line_height), format_center);

                e.Graphics.DrawString("รายการ", fnt_medium_bold, brush, new Rectangle(grid[11][1].X, grid[11][1].Y, col_width * 9, line_height), format_center);
                e.Graphics.DrawString("Description", fnt_medium_bold, brush, new Rectangle(grid[12][1].X, grid[12][1].Y, col_width * 9, line_height), format_center);

                e.Graphics.DrawString("ปริมาณ", fnt_medium_bold, brush, new Rectangle(grid[11][10].X, grid[11][10].Y, col_width * 2, line_height), format_center);
                e.Graphics.DrawString("Quantity", fnt_medium_bold, brush, new Rectangle(grid[12][10].X, grid[12][10].Y, col_width * 2, line_height), format_center);

                e.Graphics.DrawString("ราคา/หน่วย", fnt_medium_bold, brush, new Rectangle(grid[11][12].X, grid[11][12].Y, col_width * 2, line_height), format_center);
                e.Graphics.DrawString("Unit Price", fnt_medium_bold, brush, new Rectangle(grid[12][12].X, grid[12][12].Y, col_width * 2, line_height), format_center);

                e.Graphics.DrawString("จำนวนเงิน", fnt_medium_bold, brush, new Rectangle(grid[11][14].X, grid[11][14].Y, col_width * 2, line_height), format_center);
                e.Graphics.DrawString("Amount", fnt_medium_bold, brush, new Rectangle(grid[12][14].X, grid[12][14].Y, col_width * 2, line_height), format_center);

                e.Graphics.DrawString("จำนวนเงินรวมทั้งสิ้น", fnt_medium_bold, brush, new Rectangle(grid[11 + max_item_row][11].X, grid[11 + max_item_row][11].Y, col_width * 3, line_height), format_right);
                e.Graphics.DrawString("ภาษีมูลค่าเพิ่ม", fnt_medium_bold, brush, new Rectangle(grid[11 + max_item_row + 1][11].X, grid[11 + max_item_row + 1][11].Y, col_width * 3, line_height), format_right);
                e.Graphics.DrawString("มูลค่าสินค้าและบริการ", fnt_medium_bold, brush, new Rectangle(grid[11 + max_item_row + 2][11].X, grid[11 + max_item_row + 2][11].Y, col_width * 3, line_height), format_right);
                
                if(total_page != null && page == total_page)
                {
                    e.Graphics.DrawString(string.Format("{0:N2}", artrn_to_print.amount), fnt_medium_bold, brush, new Rectangle(grid[11 + max_item_row][14].X, grid[11 + max_item_row][14].Y, col_width * 2, line_height), format_right);
                    e.Graphics.DrawString(string.Format("{0:N2}", artrn_to_print.vatamt), fnt_medium, brush, new Rectangle(grid[11 + max_item_row + 1][14].X, grid[11 + max_item_row + 1][14].Y, col_width * 2, line_height), format_right);
                    e.Graphics.DrawString(string.Format("{0:N2}", artrn_to_print.netval), fnt_medium, brush, new Rectangle(grid[11 + max_item_row + 2][14].X, grid[11 + max_item_row + 2][14].Y, col_width * 2, line_height), format_right);
                }

                e.Graphics.DrawString("ลงชื่อ ________________________________ ผู้รับเงิน", fnt_medium, brush, new Rectangle(grid[lines.Count - 2][0].X, grid[lines.Count - 2][0].Y, col_width * 8, line_height));

                int item_of_page = 0;
                for (int i = item_count; i < artrn_to_print.stcrd.Count; i++)
                {
                    

                    int row = 13 + item_of_page;

                    if(grid[row][0].Y > grid[11 + max_item_row - 1][0].Y)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                    
                    e.Graphics.DrawString((i + 1).ToString(), fnt_medium, brush, new Rectangle(grid[row][0].X, grid[row][0].Y, col_width, line_height), format_center);
                    e.Graphics.DrawString(artrn_to_print.stcrd.OrderBy(st => st.id).ToList()[i].stkdes, fnt_medium, brush, new Rectangle(grid[row][1].X, grid[row][1].Y, col_width * 9, line_height));
                    e.Graphics.DrawString(string.Format("{0:N2}", artrn_to_print.stcrd.OrderBy(st => st.id).ToList()[i].trnqty), fnt_medium, brush, new Rectangle(grid[row][10].X, grid[row][10].Y, col_width * 2, line_height), format_right);
                    e.Graphics.DrawString(string.Format("{0:N2}", artrn_to_print.stcrd.OrderBy(st => st.id).ToList()[i].unitpr), fnt_medium, brush, new Rectangle(grid[row][12].X, grid[row][12].Y, col_width * 2, line_height), format_right);
                    e.Graphics.DrawString(string.Format("{0:N2}", artrn_to_print.stcrd.OrderBy(st => st.id).ToList()[i].trnval), fnt_medium, brush, new Rectangle(grid[row][14].X, grid[row][14].Y, col_width * 2, line_height), format_right);

                    item_of_page++;
                    item_count++;

                    //if (i > 0 && (i + 1) % (max_item_row - 2) == 0)
                    //{
                    //    e.HasMorePages = true;
                    //    return;
                    //}
                }
            };

            return pd;
        }

        private void cCuscod__SelectedCuscodChanged(object sender, EventArgs e)
        {
            this.lblCusnam.Text = this.cCuscod.selected_cust != null ? this.cCuscod.selected_cust.cusnam : string.Empty;
            
            if (this.tmp_artrn != null)
            {
                if (this.cCuscod.selected_cust == null)
                    return;

                this.tmp_artrn.cuscod = this.cCuscod.selected_cust.cuscod;
                this.tmp_artrn.areacod = this.cCuscod.selected_cust.areacod;
                this.tmp_artrn.paytrm = this.cCuscod.selected_cust.paytrm;
                this.tmp_artrn.duedat = (this.curr_docprefix.doctyp == "IV" ? this.tmp_artrn.docdat.AddDays(this.cCuscod.selected_cust.paytrm) : this.tmp_artrn.docdat);
                this.tmp_artrn.taxrat = this.cCuscod.selected_cust.taxrat;
                this.tmp_artrn.vatdat = this.tmp_artrn.flgvat != "0" ? (DateTime?)this.tmp_artrn.docdat : null;
                this.tmp_artrn.dlvby = this.cCuscod.selected_cust.dlvby;
                this.tmp_artrn.orgnum = this.cCuscod.selected_cust.orgnum;
                this.tmp_artrn.slmcod = this.cCuscod.selected_cust.slmcod;
            }
        }

        private void cCuscod__Leave(object sender, EventArgs e)
        {
            if (this.tmp_artrn != null && this.tmp_artrn.cuscod.Trim().Length == 0)
                this.cCuscod.PerformButtonClick();
        }

        private void cDocdat__SelectedDateChanged(object sender, EventArgs e)
        {
            if (this.tmp_artrn != null)
            {
                this.tmp_artrn.docdat = ((XDatePicker)sender)._SelectedDate.Value;
                this.tmp_artrn.duedat = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.docdat : this.tmp_artrn.docdat.AddDays(this.tmp_artrn.paytrm);
                this.tmp_artrn.cmpldat = this.curr_docprefix.doctyp == "HS" ? (DateTime?)this.tmp_artrn.docdat : null;
            }
        }

        private void dgvStcrd_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ((XDatagrid)sender).Columns[this.col_st_stkdes.Name].DisplayIndex = 0;
            ((XDatagrid)sender).Columns[this.col_st_trnqty.Name].DisplayIndex = 1;
            ((XDatagrid)sender).Columns[this.col_st_unitpr.Name].DisplayIndex = 2;
            ((XDatagrid)sender).Columns[this.col_st_trnval.Name].DisplayIndex = 3;
            ((XDatagrid)sender).Columns[this.col_st_edit.Name].DisplayIndex = 4;
            ((XDatagrid)sender).Columns[this.col_st_delete.Name].DisplayIndex = 5;

        }

        private void dgvStcrd_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if (((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_st_edit.Name)
                {
                    if(this.form_mode == FORM_MODE.READ)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(XPump.Properties.Resources.edit_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.edit_16.Width, XPump.Properties.Resources.edit_16.Height));
                    }
                    else
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                        e.Graphics.DrawImage(XPump.Properties.Resources.edit_gray_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.edit_gray_16.Width, XPump.Properties.Resources.edit_gray_16.Height));
                    }
                    e.Handled = true;
                }

                if (((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_st_delete.Name)
                {
                    if(this.form_mode == FORM_MODE.READ)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(XPump.Properties.Resources.close_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.close_16.Width, XPump.Properties.Resources.close_16.Height));
                    }
                    else
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                        e.Graphics.DrawImage(XPump.Properties.Resources.close_gray_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.close_gray_16.Width, XPump.Properties.Resources.close_gray_16.Height));
                    }
                    e.Handled = true;
                }
            }
        }

        private void dgvRcv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //if (((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv1_edit.Name || ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv2_edit.Name)
                //{
                //    if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
                //    {
                //        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                //        e.Graphics.DrawImage(XPump.Properties.Resources.edit_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.edit_16.Width, XPump.Properties.Resources.edit_16.Height));
                //    }
                //    else
                //    {
                //        e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                //        e.Graphics.DrawImage(XPump.Properties.Resources.edit_gray_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.edit_gray_16.Width, XPump.Properties.Resources.edit_gray_16.Height));
                //    }
                //    e.Handled = true;
                //}

                if (((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv1_delete.Name || ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv2_delete.Name)
                {
                    if (this.form_mode == FORM_MODE.READ)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(XPump.Properties.Resources.close_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.close_16.Width, XPump.Properties.Resources.close_16.Height));
                        using (SolidBrush brush = new SolidBrush(Color.Red))
                        {
                            e.Graphics.DrawString("ลบ", ((XDatagrid)sender).DefaultCellStyle.Font, brush, new Rectangle(e.CellBounds.X + XPump.Properties.Resources.close_16.Width + 7, e.CellBounds.Y + 3, e.CellBounds.Width - XPump.Properties.Resources.close_16.Width, e.CellBounds.Height));
                        }
                    }
                    if (this.form_mode == FORM_MODE.EDIT_ITEM)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                        e.Graphics.DrawImage(XPump.Properties.Resources.close_gray_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.close_gray_16.Width, XPump.Properties.Resources.close_gray_16.Height));
                        using (SolidBrush brush = new SolidBrush(Color.DarkGray))
                        {
                            e.Graphics.DrawString("ลบ", ((XDatagrid)sender).DefaultCellStyle.Font, brush, new Rectangle(e.CellBounds.X + XPump.Properties.Resources.close_16.Width + 7, e.CellBounds.Y + 3, e.CellBounds.Width - XPump.Properties.Resources.close_16.Width, e.CellBounds.Height));
                        }
                    }
                    e.Handled = true;
                }
            }
        }

        private void dgvStcrd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            stcrd stcrd = (stcrd)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_st_stcrd.Name].Value;
            bool is_fuel_goods = this.stmas1.Select(st => st.stkcod).Where(st => st.Contains(stcrd.stkcod)).Count() > 0 ? true : false;


            if (this.form_mode == FORM_MODE.READ && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_st_delete.Name)
            {
                ((XDatagrid)sender).Rows[e.RowIndex].DrawDeletingRowOverlay();

                if(XMessageBox.Show("ลบรายการนี้หรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        int deleting_id = ((stcrd)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_st_stcrd.Name].Value).id;

                        var stcrd_to_delete = db.stcrd.Find(deleting_id);
                        var artrn_to_update = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();

                        db.stcrd.Remove(stcrd_to_delete);

                        artrn_to_update.CalNeccessaryValue();
                        artrn_to_update.youref = is_fuel_goods ? string.Empty : artrn_to_update.youref;
                        artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                        artrn_to_update.chgdat = DateTime.Now;

                        if(db.SaveChanges() > 0)
                        {
                            this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                            this.FillForm(this.curr_artrn);
                        }
                    }
                }
                else
                {
                    ((XDatagrid)sender).Rows[e.RowIndex].ClearDeletingRowOverlay();
                }
            }
            if(this.form_mode == FORM_MODE.READ && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_st_edit.Name)
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    var artrn_to_update = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                    if (artrn_to_update == null)
                    {
                        XMessageBox.Show("เอกสารเลขที่ " + this.curr_artrn.docnum + " ไม่มีอยู่ในระบบ", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                        return;
                    }

                    stcrd stcrd_to_update = db.stcrd.Find(stcrd.id);

                    if (is_fuel_goods)
                    {
                        nozzle nozzle = db.nozzle.Where(n => n.name == this.cNozzle._Text).FirstOrDefault();

                        DialogSellValue ds = new DialogSellValue(this.main_form, this.curr_artrn, stcrd_to_update, nozzle);
                        if (ds.ShowDialog() != DialogResult.OK)
                            return;

                        artrn_to_update.youref = ds.selected_nozzle.name;
                    }
                    else
                    {
                        DialogSellQty ds = new DialogSellQty(this.main_form, this.curr_artrn, stcrd_to_update);
                        if (ds.ShowDialog() != DialogResult.OK)
                            return;
                    }

                    artrn_to_update.CalNeccessaryValue();
                    artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                    artrn_to_update.chgdat = DateTime.Now;
                    stcrd_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                    stcrd_to_update.chgdat = DateTime.Now;

                    if(db.SaveChanges() > 0)
                    {
                        this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                        this.FillForm(this.curr_artrn);
                    }
                }

                

                ///*******************/

                //var vatamt = Math.Round(this.tmp_artrn.stcrd.Sum(st => st.trnval) * this.tmp_artrn.vatrat / (100 + this.tmp_artrn.vatrat), 2);

                //this.tmp_artrn.amount = this.tmp_artrn.stcrd.Sum(st => st.trnval);
                //this.tmp_artrn.vatamt = vatamt;
                //this.tmp_artrn.aftdisc = this.tmp_artrn.amount;
                //this.tmp_artrn.total = this.tmp_artrn.amount;
                //this.tmp_artrn.netamt = this.tmp_artrn.amount;
                //this.tmp_artrn.netval = this.tmp_artrn.amount - this.tmp_artrn.vatamt;
                //this.tmp_artrn.rcvamt = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt : 0;
                //this.tmp_artrn.remamt = this.curr_docprefix.doctyp == "IV" ? this.tmp_artrn.netamt : 0;
                //this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
                //this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

                ///*******************/

                //this.lblAmount.Text = string.Format("{0:n}", this.tmp_artrn.amount);
                //this.lblVatamt.Text = string.Format("{0:n}", this.tmp_artrn.vatamt);
                //this.lblNetval.Text = string.Format("{0:n}", this.tmp_artrn.netval);
            }
        }

        private void dgvRcv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && this.form_mode == FORM_MODE.READ)
            {
                if(((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv1_delete.Name || ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv2_delete.Name)
                {
                    ((XDatagrid)sender).Rows[e.RowIndex].DrawDeletingRowOverlay();

                    arrcpcq deleting_arrcpcq;

                    if (this.tabRcv.SelectedTab == this.tabCreditCard)
                    {
                        deleting_arrcpcq = (arrcpcq)this.dgvRcv1.Rows[e.RowIndex].Cells[this.col_rcv1_arrcpcq.Name].Value;
                    }
                    else
                    {
                        deleting_arrcpcq = (arrcpcq)this.dgvRcv2.Rows[e.RowIndex].Cells[this.col_rcv2_arrcpcq.Name].Value;
                    }

                    if (XMessageBox.Show("ลบรายการนี้หรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                    {
                        using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                        {
                            var artrn_to_update = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                            var arrcpcq_to_delete = db.arrcpcq.Find(deleting_arrcpcq.id);

                            if(arrcpcq_to_delete == null)
                            {
                                XMessageBox.Show("ค้นหารายการที่ต้องการลบไม่พบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                                this.FillForm(this.curr_artrn);
                                return;
                            }

                            db.arrcpcq.Remove(arrcpcq_to_delete);

                            //artrn_to_update.chqrcv -= deleting_arrcpcq.rcvamt;
                            //artrn_to_update.cshrcv += deleting_arrcpcq.rcvamt;
                            artrn_to_update.CalNeccessaryValue();
                            artrn_to_update.userid = this.main_form.loged_in_status.loged_in_user_name;
                            artrn_to_update.chgdat = DateTime.Now;

                            if(db.SaveChanges() > 0)
                            {
                                this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.curr_artrn.id).FirstOrDefault();
                                this.FillForm(this.curr_artrn);
                            }
                        }
                    }
                    else
                    {
                        ((XDatagrid)sender).Rows[e.RowIndex].ClearDeletingRowOverlay();
                    }
                }
            }
        }

        private void cNozzle__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_artrn != null)
                this.tmp_artrn.youref = ((XTextEdit)sender)._Text;
        }

        private void btnAddCreditCard_Click(object sender, EventArgs e)
        {
            //using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            //{
            //    arrcpcq tmp_arrcpcq = new arrcpcq
            //    {
            //        id = -1,
            //        artrn_id = -1,
            //        cardnum = string.Empty,
            //        chqnum = string.Empty,
            //        bank_id = null,
            //        rcpnum = string.Empty,
            //        rcvamt = 0,
            //        userid = this.main_form.loged_in_status.loged_in_user_name
            //    };

            //    DialogCreditCardRcv rcv = new DialogCreditCardRcv(this.main_form, tmp_arrcpcq);
            //    if (rcv.ShowDialog() == DialogResult.OK)
            //    {
            //        this.tmp_artrn.arrcpcq.Add(tmp_arrcpcq);
            //        this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
            //        this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

            //        this.cCshrcv._Value = this.tmp_artrn.cshrcv;
            //        var rcv_list = this.tmp_artrn.arrcpcq.Where(i => i.rcv_method_id == tmp_arrcpcq.rcv_method_id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
            //        this.arrcpcq_credit_card = new BindingList<ArrcpcqInvoice>(rcv_list);

            //        this.dgvRcv1.DataSource = this.arrcpcq_credit_card;
            //    }
            //}

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                istab credit_card_method = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault();
                if(credit_card_method == null)
                {
                    XMessageBox.Show("ยังไม่ได้กำหนดวิธีการรับชำระด้วยบัตรเครดิต", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return;
                }

                if(credit_card_method.shortnam.Trim().Length == 0)
                {
                    XMessageBox.Show("ท่านจะต้องกำหนดวิธีการรับชำระโดยจับคู่กับวิธีการรับชำระในโปรแกรมเอ็กซ์เพรสให้เรียบร้อยก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                    var rcv_method_form = new FormRcvMethod(this.main_form);
                    rcv_method_form.ShowDialog();
                    return;
                }

                string chqnum = credit_card_method.shortnam + this.curr_artrn.docnum;
                var lst_chqnum = db.arrcpcq.Where(a => a.artrn_id == this.curr_artrn.id && a.rcv_method_id == credit_card_method.id).OrderByDescending(a => a.chqnum).FirstOrDefault();
                if(lst_chqnum != null)
                {
                    string lst_char = lst_chqnum.chqnum.Substring(lst_chqnum.chqnum.Length - 1, 1);
                    string next_char = ((char)(((int)Convert.ToChar(lst_char)) + 1)).ToString();
                    chqnum += next_char;
                }
                else
                {
                    chqnum += "A";
                }

                this.tmp_arrcpcq = new arrcpcq
                {
                    id = -1,
                    artrn_id = this.curr_artrn.id,
                    cardnum = string.Empty,
                    chqnum = chqnum,
                    bank_id = null,
                    rcpnum = this.curr_artrn.docnum,
                    rcvamt = 0,
                    rcv_method_id = credit_card_method.id,
                    userid = this.main_form.loged_in_status.loged_in_user_name,
                    
                };

                ((BindingList<ArrcpcqInvoice>)this.dgvRcv1.DataSource).Add(new ArrcpcqInvoice { arrcpcq = this.tmp_arrcpcq, working_express_db = this.main_form.working_express_db });
                this.dgvRcv1.Refresh();
                this.dgvRcv1.Rows.Cast<DataGridViewRow>().Where(r => ((arrcpcq)r.Cells[this.col_rcv1_arrcpcq.Name].Value).id == -1).First().Cells[this.col_rcv1_chqnum.Name].Selected = true;
                this.ShowInlineRcvForm();
                this.inlineCardNo.Focus();
                this.ResetFormState(FORM_MODE.EDIT_ITEM);
            }
        }

        private void btnAddCoupon_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                istab coupon_method = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault();
                if (coupon_method == null)
                {
                    XMessageBox.Show("ยังไม่ได้กำหนดวิธีการรับชำระด้วยคูปอง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return;
                }

                if (coupon_method.shortnam.Trim().Length == 0)
                {
                    XMessageBox.Show("ท่านจะต้องกำหนดวิธีการรับชำระโดยจับคู่กับวิธีการรับชำระในโปรแกรมเอ็กซ์เพรสให้เรียบร้อยก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                    var rcv_method_form = new FormRcvMethod(this.main_form);
                    rcv_method_form.ShowDialog();
                    return;
                }

                string chqnum = coupon_method.shortnam + this.curr_artrn.docnum;
                var lst_chqnum = db.arrcpcq.Where(a => a.artrn_id == this.curr_artrn.id && a.rcv_method_id == coupon_method.id).OrderByDescending(a => a.chqnum).FirstOrDefault();
                if (lst_chqnum != null)
                {
                    string lst_char = lst_chqnum.chqnum.Substring(lst_chqnum.chqnum.Length - 1, 1);
                    string next_char = ((char)(((int)Convert.ToChar(lst_char)) + 1)).ToString();
                    chqnum += next_char;
                }
                else
                {
                    chqnum += "A";
                }

                this.tmp_arrcpcq = new arrcpcq
                {
                    id = -1,
                    artrn_id = this.curr_artrn.id,
                    cardnum = string.Empty,
                    chqnum = chqnum,
                    bank_id = null,
                    rcpnum = this.curr_artrn.docnum,
                    rcvamt = 0,
                    rcv_method_id = coupon_method.id,
                    userid = this.main_form.loged_in_status.loged_in_user_name
                };

                ((BindingList<ArrcpcqInvoice>)this.dgvRcv2.DataSource).Add(new ArrcpcqInvoice { arrcpcq = this.tmp_arrcpcq, working_express_db = this.main_form.working_express_db });
                this.dgvRcv2.Refresh();
                this.dgvRcv2.Rows.Cast<DataGridViewRow>().Where(r => ((arrcpcq)r.Cells[this.col_rcv2_arrcpcq.Name].Value).id == -1).First().Cells[this.col_rcv2_chqnum.Name].Selected = true;
                this.ShowInlineRcvForm();
                this.inlineCouponNo.Focus();
                this.ResetFormState(FORM_MODE.EDIT_ITEM);
            }
        }

        /** Receive_By Section *****************************/

        private void HideInlineForm()
        {
            this.inlineCardNo.SetBounds(-99999, -99999, 0, 0);
            this.inlineBank.SetBounds(-99999, -99999, 0, 0);
            this.inlineAmount1.SetBounds(-99999, -99999, 0, 0);
            this.inlineCouponNo.SetBounds(-99999, -99999, 0, 0);
            this.inlineAmount2.SetBounds(-99999, -99999, 0, 0);
            this.tmp_arrcpcq = null;
            this.inlineCardNo._ReadOnly = true;
            this.inlineBank._ReadOnly = true;
            this.inlineAmount1._ReadOnly = true;
            this.inlineCouponNo._ReadOnly = true;
            this.inlineAmount2._ReadOnly = true;
        }

        private void ShowInlineRcvForm()
        {
            if(this.tmp_arrcpcq != null)
            {
                XDropdownListItem selected_bank = ((XDropdownList)this.inlineBank)._Items.Cast<XDropdownListItem>().Where(i => (int?)i.Value == this.tmp_arrcpcq.bank_id).FirstOrDefault() != null ? ((XDropdownList)this.inlineBank)._Items.Cast<XDropdownListItem>().Where(i => (int?)i.Value == this.tmp_arrcpcq.bank_id).FirstOrDefault() : ((XDropdownList)this.inlineBank)._Items.Cast<XDropdownListItem>().Where(i => (int?)i.Value == null).FirstOrDefault();

                this.inlineCardNo._Text = this.tmp_arrcpcq.cardnum.TrimEnd();
                this.inlineCouponNo._Text = this.tmp_arrcpcq.cardnum.TrimEnd();
                this.inlineBank._SelectedItem = selected_bank;
                this.inlineAmount1._Value = this.tmp_arrcpcq.rcvamt;
                this.inlineAmount2._Value = this.tmp_arrcpcq.rcvamt;
            }

            this.SetInlineControlPosition();
        }

        private void SetInlineControlPosition()
        {
            if(this.tabRcv.SelectedTab == this.tabCreditCard)
            {
                this.inlineCardNo._ReadOnly = false;
                this.inlineBank._ReadOnly = false;
                this.inlineAmount1._ReadOnly = false;
                this.inlineCardNo.SetInlineControlPosition(this.dgvRcv1, this.dgvRcv1.CurrentCell.RowIndex, this.dgvRcv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_rcv1_cardno.Name).First().Index);
                this.inlineBank.SetInlineControlPosition(this.dgvRcv1, this.dgvRcv1.CurrentCell.RowIndex, this.dgvRcv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_rcv1_bank.Name).First().Index);
                this.inlineAmount1.SetInlineControlPosition(this.dgvRcv1, this.dgvRcv1.CurrentCell.RowIndex, this.dgvRcv1.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_rcv1_rcvamt.Name).First().Index);
                return;
            }
            
            if(this.tabRcv.SelectedTab == this.tabCoupon)
            {
                this.inlineCouponNo._ReadOnly = false;
                this.inlineAmount2._ReadOnly = false;
                this.inlineCouponNo.SetInlineControlPosition(this.dgvRcv2, this.dgvRcv2.CurrentCell.RowIndex, this.dgvRcv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_rcv2_coupon_num.Name).First().Index);
                this.inlineAmount2.SetInlineControlPosition(this.dgvRcv2, this.dgvRcv2.CurrentCell.RowIndex, this.dgvRcv2.Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_rcv2_rcvamt.Name).First().Index);
                return;
            }
        }

        private void dgvRcv_Resize(object sender, EventArgs e)
        {
            if(this.tmp_arrcpcq != null)
            {
                this.SetInlineControlPosition();
            }
        }

        private void tabRcv_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if(this.form_mode == FORM_MODE.EDIT_ITEM)
            {
                e.Cancel = true;
            }
        }

        private void inlineCardNo__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_arrcpcq != null)
                this.tmp_arrcpcq.cardnum = ((XTextEditMasked)sender)._Text;
        }

        private void inlineBank__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_arrcpcq != null && ((XDropdownList)sender)._SelectedItem != null)
                this.tmp_arrcpcq.bank_id = (int?)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;

            Console.WriteLine(" => bank_id : " + this.tmp_arrcpcq.bank_id);
        }

        private void inlineAmount1__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_arrcpcq != null)
                this.tmp_arrcpcq.rcvamt = ((XNumEdit)sender)._Value;
        }

        private void inlineCouponNo__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_arrcpcq != null)
                this.tmp_arrcpcq.cardnum = ((XTextEdit)sender)._Text;
        }

        private void inlineAmount2__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_arrcpcq != null)
                this.tmp_arrcpcq.rcvamt = ((XNumEdit)sender)._Value;
        }

        //private List<stmasPriceVM> GetStmas(bool oil_only = true)
        //{
        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {

        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.A))
            {
                this.btnAdd.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.D))
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

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.L))
            {
                this.btnInquiryRest.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.L))
            {
                this.btnInquiryAll.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.P))
            {
                this.btnPrint.PerformClick();
                return true;
            }

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT || this.form_mode == FORM_MODE.ADD_ITEM || this.form_mode == FORM_MODE.EDIT_ITEM)
                {
                    if(this.inlineAmount1._Focused || this.inlineAmount2._Focused)
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class StcrdInvoice
    {
        public stcrd stcrd { get; set; }
        public string stkcod { get; set; }
        public string stkdes { get; set; }
        public decimal trnqty { get; set; }
        public decimal unitpr { get; set; }
        public decimal trnval { get; set; }

    }

    public class ArrcpcqInvoice
    {
        public SccompDbf working_express_db { get; set; }
        public arrcpcq arrcpcq { get; set; }
        public string chqnum { get { return this.arrcpcq.chqnum; } }
        public string cardnum { get { return this.arrcpcq.cardnum; } }
        public string bank
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var bnk = db.istab.Where(i => i.id == this.arrcpcq.bank_id).FirstOrDefault();
                    return bnk != null ? bnk.typcod + " : " + bnk.typdes : string.Empty;
                }
            }
        }
        public decimal rcvamt { get { return this.arrcpcq.rcvamt; } }
    }

    public class ArtrnInquiry
    {
        public string express_data_path { get; set; }

        public DateTime? docdat { get; set; }
        public string docnum { get; set; }
        public string cuscod { get; set; }
        public string cusnam
        {
            get
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.express_data_path))
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Select armas.cusnam From armas Where armas.cuscod=?";
                        cmd.Parameters.AddWithValue("@Cuscod", this.cuscod);
                        conn.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            conn.Close();
                            if (dt.Rows.Count > 0)
                            {
                                return dt.Rows[0].Field<string>("cusnam").ToString().TrimEnd();
                            }
                            else
                            {
                                return string.Empty;
                            }
                        }
                    }
                }
            }
        }
        public decimal amount { get; set; }
    }
}
