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
        private IsrunDbf curr_docprefix = null;
        private artrn curr_artrn = null;
        private nozzle curr_nozzle = null;

        public FormSellRecord(MainForm main_form, IsrunDbf isrun_doc_prefix, scacclvVM scacclv)
        {
            this.main_form = main_form;
            this.curr_docprefix = isrun_doc_prefix;
            this.scacclv = scacclv;
            InitializeComponent();
        }

        private void FormSellRecord_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;

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
            this.btnDelete.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
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
            this.btnAddCreditCard.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnAddCoupon.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            //this.cNozzle.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            //this.cCshrcv.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
        }

        private List<IsrunDbf> GetIsrunInvoiceDoc()
        {
            return DbfTable.Isrun(this.main_form.working_express_db).ToIsrunList().Where(i => i.doctyp.TrimEnd() == "IV" || i.doctyp.TrimEnd() == "HS").OrderBy(i => i.doctyp).ThenBy(i => i.prefix).ToList();
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
            this.lblAmount.Text = string.Format("{0:n}", artrn.amount);
            this.lblVatrat.Text = string.Format("{0:n}", artrn.vatrat) + "%";
            this.lblVatamt.Text = string.Format("{0:n}", artrn.vatamt);
            this.lblNetval.Text = string.Format("{0:n}", artrn.netval);

            this.stcrd = new BindingList<StcrdInvoice>(artrn.stcrd.OrderBy(st => st.seqnum).ToStcrdInvoice());
            this.dgvStcrd.DataSource = this.stcrd;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                int credit_card_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").First().id;
                int coupon_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").First().id;

                var rcv_credit_card_list = artrn.arrcpcq.Where(i => i.rcv_method_id == credit_card_id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
                this.arrcpcq_credit_card = new BindingList<ArrcpcqInvoice>(rcv_credit_card_list);
                this.dgvRcv1.DataSource = this.arrcpcq_credit_card;

                var rcv_coupon_list = artrn.arrcpcq.Where(i => i.rcv_method_id == coupon_id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
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

        private void dgvGoods1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex > -1 && (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT))
            {
                if(((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_g1_sellpr1.Name || ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_g2_sellpr1.Name)
                {
                    bool is_fuel_goods = ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_g1_sellpr1.Name ? true : false;
                    string stkcod;
                    string stkdes;
                    decimal unitpr;

                    BILL_METHOD bill_method;
                    if (is_fuel_goods)
                    {
                        stkcod = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_stkcod.Name].Value.ToString();
                        stkdes = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_stkdes.Name].Value.ToString();
                        unitpr = Convert.ToDecimal(((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_sellpr1.Name].Value);

                        if (this.stcrd.Select(s => s.stkcod).Where(s => this.stmas1.Select(st => st.stkcod).Contains(s)).Count() > 0)
                        {
                            XMessageBox.Show("มีรายการน้ำมันใสชนิดอื่นในบิลนี้แล้ว, หากต้องการแก้ไขชนิดน้ำมัน ต้องลบรายการเดิมออกก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
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

                    if (this.tmp_artrn.stcrd.Where(s => s.stkcod == stkcod).Count() > 0)
                    {
                        XMessageBox.Show("มีรายการสินค้านี้อยู่ในบิลแล้ว, หากต้องการแก้ไขจำนวน/มูลค่า กรุณาคลิกที่ปุ่มแก้ไขรายการที่ท้ายบรรทัดรายการสินค้านั้น ๆ", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                        return;
                    }

                    StmasDbf stmas = DbfTable.Stmas(this.main_form.working_express_db.abs_path, stkcod);

                    var tmp_stcrd = new stcrd
                    {
                        seqnum = this.tmp_artrn.nxtseq.Trim().Length == 0 ? 1.FillSpaceBeforeNum(3) : (Convert.ToInt32(this.tmp_artrn.nxtseq) + 1).FillSpaceBeforeNum(3),
                        stkcod = stkcod,
                        stkdes = stkdes,
                        unitpr = unitpr,
                        docdat = this.tmp_artrn.docdat,
                        slmcod = this.tmp_artrn.slmcod,
                        depcod = this.tmp_artrn.depcod,
                        loccod = this.curr_docprefix.loccod.TrimEnd(),
                        people = this.tmp_artrn.cuscod,
                        tqucod = stmas.squcod,
                        tfactor = Convert.ToDecimal(stmas.sfactor),
                        posopr = "9",
                        creby = this.main_form.loged_in_status.loged_in_user_name,
                        userid = this.main_form.loged_in_status.loged_in_user_name

                    };

                    if (bill_method == BILL_METHOD.VAL)
                    {
                        DialogSellValue ds = new DialogSellValue(this.main_form, this.tmp_artrn, tmp_stcrd);
                        if (ds.ShowDialog() != DialogResult.OK)
                            return;

                        this.curr_nozzle = ds.selected_nozzle;
                        this.cNozzle._Text = this.curr_nozzle != null ? this.curr_nozzle.name : string.Empty;
                        tmp_stcrd.loccod = this.curr_nozzle != null ? this.curr_nozzle.section.loccod : tmp_stcrd.loccod;
                    }
                    else
                    {
                        DialogSellQty ds = new DialogSellQty(this.main_form, this.tmp_artrn, tmp_stcrd);
                        if (ds.ShowDialog() != DialogResult.OK)
                            return;
                    }

                    this.tmp_artrn.nxtseq = tmp_stcrd.seqnum;
                    this.tmp_artrn.stcrd.Add(tmp_stcrd);

                    var vatamt = Math.Round(this.tmp_artrn.stcrd.Sum(st => st.trnval) * this.tmp_artrn.vatrat / (100 + this.tmp_artrn.vatrat), 2);

                    this.tmp_artrn.amount = this.tmp_artrn.stcrd.Sum(st => st.trnval);
                    this.tmp_artrn.vatamt = vatamt;
                    this.tmp_artrn.aftdisc = this.tmp_artrn.amount;
                    this.tmp_artrn.total = this.tmp_artrn.amount;
                    this.tmp_artrn.netamt = this.tmp_artrn.amount;
                    this.tmp_artrn.netval = this.tmp_artrn.amount - this.tmp_artrn.vatamt;
                    this.tmp_artrn.rcvamt = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt : 0;
                    this.tmp_artrn.remamt = this.curr_docprefix.doctyp == "IV" ? this.tmp_artrn.netamt : 0;
                    this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
                    this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

                    this.stcrd = new BindingList<StcrdInvoice>(this.tmp_artrn.stcrd.OrderBy(st => st.seqnum).ToStcrdInvoice());
                    this.dgvStcrd.DataSource = this.stcrd;



                    this.lblAmount.Text = string.Format("{0:n}", this.tmp_artrn.amount);
                    this.lblVatamt.Text = string.Format("{0:n}", this.tmp_artrn.vatamt);
                    this.lblNetval.Text = string.Format("{0:n}", this.tmp_artrn.netval);
                    this.cCshrcv._Value = this.tmp_artrn.cshrcv;
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

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (var c in "ABC".ToCharArray())
            {
                Console.WriteLine(" ==> " + c.ToString() + " : " + (int)c);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(XMessageBox.Show("ยกเลิกการเพิ่ม/แก้ไขข้อมูล, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                this.ResetFormState(FORM_MODE.READ);
                this.tmp_artrn = null;
                this.FillForm(this.curr_artrn);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
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

                    int credit_card_method_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").First().id;
                    // A = 65, B = 66, C = 67, ...
                    int cr_count = 64; // counting loop for credit card receive
                    int cp_count = 64; // counting loop for coupon receive

                    this.tmp_artrn.arrcpcq.ToList().ForEach(a =>
                    {
                        bool is_credit_card = a.rcv_method_id == credit_card_method_id ? true : false;
                        if(is_credit_card)
                        {
                            cr_count++;
                        }
                        else
                        {
                            cp_count++;
                        }

                        a.chqnum = is_credit_card ? a.chqnum + this.tmp_artrn.docnum + ((char)cr_count).ToString() : a.chqnum + this.tmp_artrn.docnum + ((char)cp_count).ToString();
                        a.rcpnum = this.tmp_artrn.docnum;
                        a.artrn_id = this.tmp_artrn.id;
                        a.chgdat = DateTime.Now;
                    });

                    db.artrn.Add(this.tmp_artrn);
                    if(db.SaveChanges() > 0)
                    {
                        var next_docnum = Helper.CalNextDocnum(this.tmp_artrn.docnum);
                        isrun.SetNextDocnum(this.main_form.working_express_db, next_docnum);
                        //if(!isrun.SetNextDocnum(this.main_form.working_express_db, next_docnum))
                        //{
                        //    XMessageBox.Show("การกำหนดเลขที่เอกสารถัดไปใน isrun ยังไม่ถูกต้อง");
                        //}
                        this.curr_artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.id == this.tmp_artrn.id).FirstOrDefault();
                        this.FillForm(this.curr_artrn);
                        this.ResetFormState(FORM_MODE.READ);
                    }

                }

                if (this.form_mode == FORM_MODE.EDIT)
                {

                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {

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

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeDocTyp_Click(object sender, EventArgs e)
        {
            
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

                this.tmp_artrn.stcrd.ToList().ForEach(st => st.people = this.cCuscod.selected_cust.cuscod);
                this.tmp_artrn.stcrd.ToList().ForEach(st => st.slmcod = this.cCuscod.selected_cust.slmcod);
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
                    if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
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
                    if(this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
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
                    if (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Graphics.DrawImage(XPump.Properties.Resources.close_16, new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 4, XPump.Properties.Resources.close_16.Width, XPump.Properties.Resources.close_16.Height));
                        using (SolidBrush brush = new SolidBrush(Color.Red))
                        {
                            e.Graphics.DrawString("ลบ", ((XDatagrid)sender).DefaultCellStyle.Font, brush, new Rectangle(e.CellBounds.X + XPump.Properties.Resources.close_16.Width + 7, e.CellBounds.Y + 3, e.CellBounds.Width - XPump.Properties.Resources.close_16.Width, e.CellBounds.Height));
                        }
                    }
                    else
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
            if((this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT) && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_st_delete.Name)
            {
                string stkcod_to_del = ((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_st_stkcod.Name].Value.ToString();

                ((XDatagrid)sender).Rows[e.RowIndex].DrawDeletingRowOverlay();

                if(XMessageBox.Show("ลบรายการนี้หรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.tmp_artrn.stcrd.Remove(this.tmp_artrn.stcrd.Where(s => s.stkcod == stkcod_to_del).First());
                    this.stcrd = new BindingList<StcrdInvoice>(this.tmp_artrn.stcrd.OrderBy(st => st.seqnum).ToStcrdInvoice());
                    this.dgvStcrd.DataSource = this.stcrd;
                    if(this.stcrd.Where(s => this.stmas1.Select(st => st.stkcod).Contains(s.stkcod)).Count() == 0)
                    {
                        this.cNozzle._Text = string.Empty;
                    }

                    /**********/
                    var vatamt = Math.Round(this.tmp_artrn.stcrd.Sum(st => st.trnval) * this.tmp_artrn.vatrat / (100 + this.tmp_artrn.vatrat), 2);

                    this.tmp_artrn.amount = this.tmp_artrn.stcrd.Sum(st => st.trnval);
                    this.tmp_artrn.vatamt = vatamt;
                    this.tmp_artrn.aftdisc = this.tmp_artrn.amount;
                    this.tmp_artrn.total = this.tmp_artrn.amount;
                    this.tmp_artrn.netamt = this.tmp_artrn.amount;
                    this.tmp_artrn.netval = this.tmp_artrn.amount - this.tmp_artrn.vatamt;
                    this.tmp_artrn.rcvamt = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt : 0;
                    this.tmp_artrn.remamt = this.curr_docprefix.doctyp == "IV" ? this.tmp_artrn.netamt : 0;
                    this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
                    this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

                    /**********/


                    this.lblAmount.Text = string.Format("{0:n}", this.tmp_artrn.amount);
                    this.lblVatamt.Text = string.Format("{0:n}", this.tmp_artrn.vatamt);
                    this.lblNetval.Text = string.Format("{0:n}", this.tmp_artrn.netval);
                }
                else
                {
                    ((XDatagrid)sender).Rows[e.RowIndex].ClearDeletingRowOverlay();
                }
            }
            if((this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT) && ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_st_edit.Name)
            {
                stcrd stcrd_to_edit = (stcrd)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_st_stcrd.Name].Value;
                bool is_fuel_goods = this.stmas1.Select(st => st.stkcod).Where(st => st.Contains(stcrd_to_edit.stkcod)).Count() > 0 ? true : false;

                if (is_fuel_goods)
                {
                    nozzle nozzle;
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        nozzle = db.nozzle.Where(n => n.name == this.cNozzle._Text).FirstOrDefault();
                    }

                    DialogSellValue ds = new DialogSellValue(this.main_form, this.tmp_artrn, stcrd_to_edit, nozzle);
                    if(ds.ShowDialog() == DialogResult.OK)
                    {
                        this.cNozzle._Text = ds.selected_nozzle.name;
                        this.tmp_artrn.stcrd.Where(st => st.stkcod == stcrd_to_edit.stkcod).First().trnqty = ds.stcrd.trnqty;
                        this.tmp_artrn.stcrd.Where(st => st.stkcod == stcrd_to_edit.stkcod).First().trnval = ds.stcrd.trnval;
                        this.stcrd = new BindingList<StcrdInvoice>(this.tmp_artrn.stcrd.OrderBy(st => st.seqnum).ToStcrdInvoice());
                        this.dgvStcrd.DataSource = this.stcrd;
                        this.dgvStcrd.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[this.col_st_stkcod.Name].Value.ToString() == stcrd_to_edit.stkcod).First().Selected = true;
                    }
                }
                else
                {
                    DialogSellQty ds = new DialogSellQty(this.main_form, this.tmp_artrn, stcrd_to_edit);
                    if(ds.ShowDialog() == DialogResult.OK)
                    {
                        this.tmp_artrn.stcrd.Where(st => st.stkcod == stcrd_to_edit.stkcod).First().trnqty = ds.stcrd.trnqty;
                        this.tmp_artrn.stcrd.Where(st => st.stkcod == stcrd_to_edit.stkcod).First().trnval = ds.stcrd.trnval;
                        this.stcrd = new BindingList<StcrdInvoice>(this.tmp_artrn.stcrd.OrderBy(st => st.seqnum).ToStcrdInvoice());
                        this.dgvStcrd.DataSource = this.stcrd;
                        this.dgvStcrd.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[this.col_st_stkcod.Name].Value.ToString() == stcrd_to_edit.stkcod).First().Selected = true;
                    }
                }

                /*******************/
                var vatamt = Math.Round(this.tmp_artrn.stcrd.Sum(st => st.trnval) * this.tmp_artrn.vatrat / (100 + this.tmp_artrn.vatrat), 2);

                this.tmp_artrn.amount = this.tmp_artrn.stcrd.Sum(st => st.trnval);
                this.tmp_artrn.vatamt = vatamt;
                this.tmp_artrn.aftdisc = this.tmp_artrn.amount;
                this.tmp_artrn.total = this.tmp_artrn.amount;
                this.tmp_artrn.netamt = this.tmp_artrn.amount;
                this.tmp_artrn.netval = this.tmp_artrn.amount - this.tmp_artrn.vatamt;
                this.tmp_artrn.rcvamt = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt : 0;
                this.tmp_artrn.remamt = this.curr_docprefix.doctyp == "IV" ? this.tmp_artrn.netamt : 0;
                this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
                this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

                /*******************/

                this.lblAmount.Text = string.Format("{0:n}", this.tmp_artrn.amount);
                this.lblVatamt.Text = string.Format("{0:n}", this.tmp_artrn.vatamt);
                this.lblNetval.Text = string.Format("{0:n}", this.tmp_artrn.netval);
            }
        }

        private void dgvRcv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT))
            {
                if(((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv1_delete.Name || ((XDatagrid)sender).Columns[e.ColumnIndex].Name == this.col_rcv1_delete.Name)
                {
                    ((XDatagrid)sender).Rows[e.RowIndex].DrawDeletingRowOverlay();

                    if(XMessageBox.Show("ลบรายการนี้หรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                    {

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
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                arrcpcq tmp_arrcpcq = new arrcpcq
                {
                    id = -1,
                    artrn_id = -1,
                    cardnum = string.Empty,
                    chqnum = string.Empty,
                    bank_id = null,
                    rcpnum = string.Empty,
                    rcvamt = 0,
                    userid = this.main_form.loged_in_status.loged_in_user_name
                };

                DialogCreditCardRcv rcv = new DialogCreditCardRcv(this.main_form, tmp_arrcpcq);
                if (rcv.ShowDialog() == DialogResult.OK)
                {
                    this.tmp_artrn.arrcpcq.Add(tmp_arrcpcq);
                    this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
                    this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

                    this.cCshrcv._Value = this.tmp_artrn.cshrcv;
                    var rcv_list = this.tmp_artrn.arrcpcq.Where(i => i.rcv_method_id == tmp_arrcpcq.rcv_method_id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
                    this.arrcpcq_credit_card = new BindingList<ArrcpcqInvoice>(rcv_list);

                    this.dgvRcv1.DataSource = this.arrcpcq_credit_card;
                }
            }
        }

        private void btnAddCoupon_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                arrcpcq tmp_arrcpcq = new arrcpcq
                {
                    id = -1,
                    artrn_id = -1,
                    cardnum = string.Empty,
                    chqnum = string.Empty,
                    bank_id = null,
                    rcpnum = string.Empty,
                    rcvamt = 0,
                    userid = this.main_form.loged_in_status.loged_in_user_name
                };

                DialogCouponRcv rcv = new DialogCouponRcv(this.main_form, tmp_arrcpcq);
                if (rcv.ShowDialog() == DialogResult.OK)
                {
                    this.tmp_artrn.arrcpcq.Add(tmp_arrcpcq);
                    this.tmp_artrn.chqrcv = this.tmp_artrn.arrcpcq.Sum(q => q.rcvamt);
                    this.tmp_artrn.cshrcv = this.curr_docprefix.doctyp == "HS" ? this.tmp_artrn.netamt - this.tmp_artrn.chqrcv : 0;

                    this.cCshrcv._Value = this.tmp_artrn.cshrcv;
                    var rcv_list = this.tmp_artrn.arrcpcq.Where(i => i.rcv_method_id == tmp_arrcpcq.rcv_method_id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
                    this.arrcpcq_coupon = new BindingList<ArrcpcqInvoice>(rcv_list);

                    this.dgvRcv2.DataSource = this.arrcpcq_coupon;
                }
            }
        }

        private void btnRcvOther_Click(object sender, EventArgs e)
        {
            DialogRcv rcv = new DialogRcv(this.main_form, this.curr_artrn);
            rcv.ShowDialog();
        }

        //private List<stmasPriceVM> GetStmas(bool oil_only = true)
        //{
        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {

        //    }
        //}
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
}
