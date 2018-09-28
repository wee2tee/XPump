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

namespace XPump.SubForm
{
    public partial class FormSellRecord : Form
    {
        public const string modcod = "";
        private MainForm main_form;
        private scacclvVM scacclv;
        private BindingList<StmasDbfPrice> stmas1;
        private BindingList<StmasDbfPrice> stmas2;
        private FORM_MODE form_mode;
        private artrn tmp_artrn = null;
        private IsrunDbf curr_docprefix = null;
        private artrn curr_artrn = null;

        public FormSellRecord(MainForm main_form, scacclvVM scacclv)
        {
            this.main_form = main_form;
            this.scacclv = scacclv;
            InitializeComponent();
        }

        private void FormSellRecord_Load(object sender, EventArgs e)
        {
            this.BackColor = MiscResource.WIND_BG;

            this.curr_docprefix = this.GetIsrunInvoiceDoc().Where(i => i.doctyp.TrimEnd() == "HS").First();
            this.LoadStmasDgv();
            this.lblDocType.Text = this.curr_docprefix.prefix + " : " + this.curr_docprefix.posdes;
            this.ResetFormState(FORM_MODE.READ);
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

            this.btnManageStkgrp.SetControlState(new FORM_MODE[] { FORM_MODE.READ, FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.btnChangeDocTyp.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.cCuscod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cDocdat.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cNozzle.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
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
            this.lblCusnam.Text = cus != null ? cus.cusnam.TrimEnd() : string.Empty;
            this.cCshrcv._Value = artrn.cshrcv;

            this.dgvStcrd.DataSource = artrn.stcrd;
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
            if(e.RowIndex > -1)
            {
                if(e.ColumnIndex == ((XDatagrid)sender).Columns.Cast<DataGridViewColumn>().Where(c => c.Name == this.col_g1_sellpr1.Name).First().Index)
                {
                    BILL_METHOD bill_method = (BILL_METHOD)((XDatagrid)sender).Rows[e.RowIndex].Cells[this.col_g1_bill_method.Name].Value;
                    if (bill_method == BILL_METHOD.VAL)
                    {

                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<XDropdownListItem> items = new List<XDropdownListItem>();
            this.GetIsrunInvoiceDoc().ForEach(i => items.Add(new XDropdownListItem { Text = i.prefix.TrimEnd() + " : " + i.posdes.TrimEnd(), Value = i }));
            DialogDropdownlistSelector dr = new DialogDropdownlistSelector("เลือกประเภทรายการขาย", "ประเภทการขาย", items, this.curr_docprefix);
            if (dr.ShowDialog() == DialogResult.OK)
            {
                this.lblDocType.Text = dr.selected_item.Text;
                this.curr_docprefix = (IsrunDbf)dr.selected_item.Value;

                this.tmp_artrn = new artrn
                {
                    rectyp = this.curr_docprefix.doctyp.TrimEnd() == "HS" ? "1" : (this.curr_docprefix.doctyp.TrimEnd() == "IV" ? "3" : ""),
                    docnum = this.curr_docprefix + "**NEW**",
                    docdat = DateTime.Now,
                    flgvat = this.curr_docprefix.flgvat,
                    duedat = DateTime.Now,
                    bilnum = "~",
                    vatrat = this.curr_docprefix.vatrat,
                    docstat = "N",
                    creby = this.main_form.loged_in_status.loged_in_user_name,
                    credat = DateTime.Now,
                    userid = this.main_form.loged_in_status.loged_in_user_name,
                    chgdat = DateTime.Now,
                    //stcrd = new List<stcrd> { new stcrd { stkcod = "01-INTL-CL-600" }, new stcrd { stkcod = "01-INTL-PT-750" } }
                };

                this.ResetFormState(FORM_MODE.ADD);
                this.FillForm(this.tmp_artrn);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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

        private void cCuscod__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_cuscod = new DataGridViewTextBoxColumn
            {
                Name = "col_cuscod",
                DataPropertyName = "cuscod",
                Width = 100,
                MinimumWidth = 100,
            };

            //DataGridViewColumn[] cols = new DataGridViewColumn[] { };
            var armas_list = DbfTable.ArmasList(this.main_form.working_express_db);

            //DialogBrowseBoxSelector br = new DialogBrowseBoxSelector()
        }

        private void btnChangeDocTyp_Click(object sender, EventArgs e)
        {
            List<XDropdownListItem> items = new List<XDropdownListItem>();
            this.GetIsrunInvoiceDoc().ForEach(i => items.Add(new XDropdownListItem { Text = i.prefix.TrimEnd() + " : " + i.posdes.TrimEnd(), Value = i }));
            DialogDropdownlistSelector dr = new DialogDropdownlistSelector("เลือกประเภทรายการขาย", "ประเภทการขาย", items, this.curr_docprefix);
            if (dr.ShowDialog() == DialogResult.OK)
            {
                this.lblDocType.Text = dr.selected_item.Text;
                this.curr_docprefix = (IsrunDbf)dr.selected_item.Value;
            }
        }

        //private List<stmasPriceVM> GetStmas(bool oil_only = true)
        //{
        //    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
        //    {

        //    }
        //}
    }
}
