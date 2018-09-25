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
using XPump.CustomControls;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Data.OleDb;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class FormArmas : Form
    {
        private MainForm main_form;
        private List<ArmasDbfList> armas;
        private ArmasDbf curr_armas;
        private ArmasDbf tmp_armas;
        private FORM_MODE form_mode;
        private string search_keyword = string.Empty;

        public FormArmas(MainForm main_form)
        {
            this.BackColor = MiscResource.WIND_BG;
            this.main_form = main_form;
            InitializeComponent();
        }

        private void FormArmas_Load(object sender, EventArgs e)
        {
            this.ApplyDropdownSelection();
            this.cSlmcod._DataPath = this.main_form.working_express_db.abs_path;
            this.cAccnum._DataPath = this.main_form.working_express_db.abs_path;
            this.cCustyp._DataPath = this.main_form.working_express_db.abs_path;
            this.cDlvby._DataPath = this.main_form.working_express_db.abs_path;
            this.cAreacod._DataPath = this.main_form.working_express_db.abs_path;
        }

        private void FormArmas_Shown(object sender, EventArgs e)
        {
            this.ResetFormState(FORM_MODE.READ);
            this.btnFirst.PerformClick();
            this.ActiveControl = this.cStatus;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.main_form.opened_child_form.Remove(this.main_form.opened_child_form.Where(f => f.form.GetType() == this.GetType()).First());
            this.form_mode = FORM_MODE.READ;
            base.OnFormClosed(e);
        }

        private void ApplyDropdownSelection()
        {
            this.cStatus._Items.Add(new XDropdownListItem { Text = "Active", Value = "A" });
            this.cStatus._Items.Add(new XDropdownListItem { Text = "Inactive", Value = "I" });
            this.cStatus._Items.Add(new XDropdownListItem { Text = "ไม่ได้ระบุ(Active)", Value = "" });

            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายล่าสุด", Value = "0" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 1", Value = "1" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 2", Value = "2" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 3", Value = "3" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 4", Value = "4" });
            this.cTabpr._Items.Add(new XDropdownListItem { Text = "ราคาขายที่ 5", Value = "5" });
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
            this.btnRefresh.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);

            this.cCuscod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD }, this.form_mode);
            this.cPrenam.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cCusnam.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAddr01.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAddr02.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAddr03.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cZipcod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cTelnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cContact.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cRemark.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cTaxid.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cStatus.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cOrgnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cCustyp.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAccnum.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cSlmcod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cAreacod.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cDlvby.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cPaytrm.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cPaycond.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cTabpr.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cDisc.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
            this.cCrline.SetControlState(new FORM_MODE[] { FORM_MODE.ADD, FORM_MODE.EDIT }, this.form_mode);
        }

        private void FillForm(ArmasDbf data_to_fill)
        {
            ArmasDbf armas;
            if(data_to_fill == null)
            {
                armas = new ArmasDbf
                {
                    cuscod = string.Empty
                };
            }
            else
            {
                armas = data_to_fill;
            }

            var status = this.cStatus._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == armas.status).FirstOrDefault();
            var tabpr = this.cTabpr._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == armas.tabpr).FirstOrDefault();

            this.cCuscod._Text = armas.cuscod;
            this.cPrenam._Text = armas.prenam;
            this.cCusnam._Text = armas.cusnam;
            this.cAddr01._Text = armas.addr01;
            this.cAddr02._Text = armas.addr02;
            this.cAddr03._Text = armas.addr03;
            this.cZipcod._Text = armas.zipcod;
            this.cTelnum._Text = armas.telnum;
            this.cContact._Text = armas.contact;
            this.cRemark._Text = armas.remark;
            this.cStatus._SelectedItem = status != null ? status : this.cStatus._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == "").First();
            this.cTaxid._Text = armas.taxid;
            this.cOrgnum._Value = Convert.ToDecimal(armas.orgnum);
            this.cCustyp._Text = armas.custyp;
            this.cCustypDesc.Text = armas._custypdesc;
            this.cAccnum._Text = armas.accnum;
            this.cAccnam.Text = armas._accnam;
            this.cSlmcod._Text = armas.slmcod;
            this.cSlmnam.Text = armas._slmnam;
            this.cAreacod._Text = armas.areacod;
            this.cAreaDesc.Text = armas._areadesc;
            this.cDlvby._Text = armas.dlvby;
            this.cDlvbyDesc.Text = armas._dlvbydesc;
            this.cPaytrm._Value = Convert.ToDecimal(armas.paytrm);
            this.cPaycond._Text = armas.paycond;
            this.cTabpr._SelectedItem = tabpr != null ? tabpr : this.cTabpr._Items.Cast<XDropdownListItem>().Where(i => (string)i.Value == "0").First();
            this.cDisc._Text = armas.disc;
            this.cCrline._Value = Convert.ToDecimal(armas.crline);
        }

        private void PerformEdit(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.READ && this.curr_armas != null)
            {
                this.btnEdit.PerformClick();
                if(((Control)sender).Name == this.cCuscod.Name)
                {
                    this.cPrenam.Focus();
                }
                else
                {
                    ((Control)sender).Focus();
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, DbfTable.RECORD_FLAG.FIRST);
            this.FillForm(this.curr_armas);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false).OrderByDescending(c => c).ToList();
            //int curr_index = cuscod_list.IndexOf(this.curr_armas.cuscod);
            //if (curr_index > 0)
            //{
            //    this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, cuscod_list[curr_index - 1]);
            //    this.FillForm(this.curr_armas);
            //}

            //var selected_cuscod = cuscod_list.Where(c => c.Trim().CompareTo(this.curr_armas.cuscod.Trim()) < 0).FirstOrDefault();
            //if (selected_cuscod != null)
            //{
            //    this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, selected_cuscod);
            //    this.FillForm(this.curr_armas);
            //}
            //else
            //{
            //    this.btnFirst.PerformClick();
            //}

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    string prev_cuscod = null;
                    cmd.CommandText = "Select cuscod From armas Where (cuscod < '" + this.curr_armas.cuscod.TrimEnd() + "') and cuscod != '" + this.curr_armas.cuscod.TrimEnd() + "' Order By cuscod DESC Top 1"; //cuscod like '" + this.curr_armas.cuscod.TrimEnd() + "%' or 
                    conn.Open();
                    using (OleDbDataAdapter da =new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                            prev_cuscod = !dt.Rows[0].IsNull("cuscod") ? dt.Rows[0]["cuscod"].ToString() : null;

                        if(prev_cuscod != null)
                        {
                            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, prev_cuscod);
                            this.FillForm(this.curr_armas);
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false).OrderBy(c => c).ToList();
            //int curr_index = cuscod_list.IndexOf(this.curr_armas.cuscod);
            //if (curr_index < cuscod_list.Count - 1)
            //{
            //    this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, cuscod_list[curr_index + 1]);
            //    this.FillForm(this.curr_armas);
            //}

            //var selected_cuscod = cuscod_list.Where(c => c.Trim().CompareTo(this.curr_armas.cuscod.Trim()) > 0).FirstOrDefault();
            //if(selected_cuscod != null)
            //{
            //    this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, selected_cuscod);
            //    this.FillForm(this.curr_armas);
            //}
            //else
            //{
            //    this.btnLast.PerformClick();
            //}

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    string prev_cuscod = null;
                    cmd.CommandText = "Select cuscod From armas Where (cuscod > '" + this.curr_armas.cuscod.TrimEnd() + "') and cuscod != '" + this.curr_armas.cuscod.TrimEnd() + "' Order By cuscod ASC Top 1"; //cuscod like '" + this.curr_armas.cuscod.TrimEnd() + "%' or 
                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                            
                        if (dt.Rows.Count > 0)
                            prev_cuscod = !dt.Rows[0].IsNull("cuscod") ? dt.Rows[0]["cuscod"].ToString() : null;

                        if (prev_cuscod != null)
                        {
                            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, prev_cuscod);
                            this.FillForm(this.curr_armas);
                        }
                    }
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, DbfTable.RECORD_FLAG.LAST);
            this.FillForm(this.curr_armas);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.tmp_armas = new ArmasDbf
            {
                cuscod = this.curr_armas.cuscod,
                cusnam = this.curr_armas.cusnam,
                prenam = this.curr_armas.prenam,
                addr01 = this.curr_armas.addr01,
                addr02 = this.curr_armas.addr02,
                addr03 = this.curr_armas.addr03,
                zipcod = this.curr_armas.zipcod,
                telnum = this.curr_armas.telnum,
                contact = this.curr_armas.contact,
                remark = this.curr_armas.remark,
                taxid = this.curr_armas.taxid,
                orgnum = this.curr_armas.orgnum,
                status = this.curr_armas.status,
                custyp = this.curr_armas.custyp,
                accnum = this.curr_armas.accnum,
                slmcod = this.curr_armas.slmcod,
                areacod = this.curr_armas.areacod,
                dlvby = this.curr_armas.dlvby,
                paytrm = this.curr_armas.paytrm,
                paycond = this.curr_armas.paycond,
                tabpr = this.curr_armas.tabpr,
                disc = this.curr_armas.disc,
                crline = this.curr_armas.crline,
                _accnam = this.curr_armas._accnam,
                _areadesc = this.curr_armas._areadesc,
                _custypdesc = this.curr_armas._custypdesc,
                _dlvbydesc = this.curr_armas._dlvbydesc,
                _slmnam = this.curr_armas._slmnam,

                cusnam2 = string.Empty,
                payer = string.Empty,
                shipto = string.Empty,
                taxcond = string.Empty,
                //taxgrp = string.Empty, // V.1
                taxdes = string.Empty, // V.2
                dat1 = null,
                dat2 = null,
                num1 = 0,
                str1 = string.Empty,
                str2 = string.Empty,
                str3 = string.Empty,
                str4 = string.Empty,
                taxtyp = string.Empty,
                tracksal = string.Empty,
                balance = 0,
                chqrcv = 0,
                taxrat = 0,
                
            };

            this.FillForm(this.tmp_armas);
            this.ResetFormState(FORM_MODE.ADD);
            this.cCuscod.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.curr_armas == null)
                return;

            this.tmp_armas = DbfTable.Armas(this.main_form.working_express_db, this.curr_armas.cuscod.TrimEnd());

            if (this.tmp_armas == null)
                return;

            this.FillForm(this.tmp_armas);
            this.ResetFormState(FORM_MODE.EDIT);
            this.cPrenam.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XMessageBox.Show("ลบข้อมูลนี้หรือไม่", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
            {
                if (conn == null)
                    return;
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "Delete From armas Where cuscod = ?";
                        cmd.Parameters.AddWithValue("@Cuscod", this.curr_armas.cuscod);

                        var row_deleted = cmd.ExecuteNonQuery();
                        if (row_deleted > 0)
                        {
                            conn.Close();
                            Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.ARMAS);
                            this.btnNext.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(XMessageBox.Show("กรุณายืนยัน เพื่อยกเลิกการเพิ่มหรือแก้ไข", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                this.ResetFormState(FORM_MODE.READ);
                this.FillForm(this.curr_armas);
                this.tmp_armas = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        if (this.form_mode == FORM_MODE.ADD)
                        {
                            cmd.CommandText = "Select count(cuscod) as cnt From Armas Where TRIM(cuscod) = ?";
                            cmd.Parameters.AddWithValue("@cuscod", this.tmp_armas.cuscod.Trim());

                            conn.Open();
                            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                int rows = dt.Rows[0].IsNull("cnt") ? 0 : Convert.ToInt32(dt.Rows[0]["cnt"]);
                                conn.Close();
                                if(rows > 0)
                                {
                                    XMessageBox.Show("รหัส '" + this.tmp_armas.cuscod + "' นี้มีอยู่แล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                                    return;
                                }
                            }

                            cmd.CommandText = "Insert into Armas (cuscod, prenam, cusnam, addr01, addr02, addr03, zipcod, telnum, contact, remark, taxid, orgnum, status, custyp, accnum, slmcod, areacod, dlvby, paytrm, paycond, tabpr, disc, crline, cusnam2, payer, shipto, taxcond, taxtyp, tracksal, balance, chqrcv, taxrat, taxdes, dat1, dat2, num1, str1, str2, str3, str4, c_type, inactdat, lasivc, creby, credat, userid, chgdat) Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,{},{},?,?,?,?,?,?,{},{},?,?,?,?)";
                        }

                        if (this.form_mode == FORM_MODE.EDIT)
                        {
                            cmd.CommandText = "Update Armas Set prenam=?, cusnam=?, addr01=?, addr02=?, addr03=?, zipcod=?, telnum=?, contact=?, remark=?, taxid=?, orgnum=?, status=?, custyp=?, accnum=?, slmcod=?, areacod=?, dlvby=?, paytrm=?, paycond=?, tabpr=?, disc=?, crline=?, userid=?, chgdat=? Where cuscod=?";
                        }

                        cmd.Parameters.Clear();

                        if (this.form_mode == FORM_MODE.ADD)
                            cmd.Parameters.AddWithValue("@cuscod", this.tmp_armas.cuscod);

                        cmd.Parameters.AddWithValue("@prenam", this.tmp_armas.prenam);
                        cmd.Parameters.AddWithValue("@cusnam", this.tmp_armas.cusnam);
                        cmd.Parameters.AddWithValue("@addr01", this.tmp_armas.addr01);
                        cmd.Parameters.AddWithValue("@addr02", this.tmp_armas.addr02);
                        cmd.Parameters.AddWithValue("@addr03", this.tmp_armas.addr03);
                        cmd.Parameters.AddWithValue("@zipcod", this.tmp_armas.zipcod);
                        cmd.Parameters.AddWithValue("@telnum", this.tmp_armas.telnum);
                        cmd.Parameters.AddWithValue("@contact", this.tmp_armas.contact);
                        cmd.Parameters.AddWithValue("@remark", this.tmp_armas.remark);
                        cmd.Parameters.AddWithValue("@taxid", this.tmp_armas.taxid);
                        cmd.Parameters.AddWithValue("@orgnum", this.tmp_armas.orgnum);
                        cmd.Parameters.AddWithValue("@status", this.tmp_armas.status);
                        cmd.Parameters.AddWithValue("@custyp", this.tmp_armas.custyp);
                        cmd.Parameters.AddWithValue("@accnum", this.tmp_armas.accnum);
                        cmd.Parameters.AddWithValue("@slmcod", this.tmp_armas.slmcod);
                        cmd.Parameters.AddWithValue("@areacod", this.tmp_armas.areacod);
                        cmd.Parameters.AddWithValue("@dlvby", this.tmp_armas.dlvby);
                        cmd.Parameters.AddWithValue("@paytrm", this.tmp_armas.paytrm);
                        cmd.Parameters.AddWithValue("@paycond", this.tmp_armas.paycond);
                        cmd.Parameters.AddWithValue("@tabpr", this.tmp_armas.tabpr);
                        cmd.Parameters.AddWithValue("@disc", this.tmp_armas.disc);
                        cmd.Parameters.AddWithValue("@crline", this.tmp_armas.crline);
                        

                        if (this.form_mode == FORM_MODE.ADD) // add
                        {
                            cmd.Parameters.AddWithValue("@cusnam2", this.tmp_armas.cusnam2);
                            cmd.Parameters.AddWithValue("@payer", this.tmp_armas.payer);
                            cmd.Parameters.AddWithValue("@shipto", this.tmp_armas.shipto);
                            cmd.Parameters.AddWithValue("@taxcond", this.tmp_armas.taxcond);
                            //cmd.Parameters.AddWithValue("@taxgrp", this.tmp_armas.taxgrp); // V.1
                            cmd.Parameters.AddWithValue("@taxtyp", this.tmp_armas.taxtyp);
                            cmd.Parameters.AddWithValue("@tracksal", this.tmp_armas.tracksal);
                            cmd.Parameters.AddWithValue("@balance", this.tmp_armas.balance);
                            cmd.Parameters.AddWithValue("@chqrcv", this.tmp_armas.chqrcv);
                            cmd.Parameters.AddWithValue("@taxrat", this.tmp_armas.taxrat);
                            cmd.Parameters.AddWithValue("@taxdes", this.tmp_armas.taxdes); // V.2
                            //cmd.Parameters.AddWithValue("@dat1", this.tmp_armas.dat1); // V.2
                            //cmd.Parameters.AddWithValue("@dat2", this.tmp_armas.dat2); // V.2
                            cmd.Parameters.AddWithValue("@num1", this.tmp_armas.num1); // V.2
                            cmd.Parameters.AddWithValue("@str1", this.tmp_armas.str1); // V.2
                            cmd.Parameters.AddWithValue("@str2", this.tmp_armas.str2); // V.2
                            cmd.Parameters.AddWithValue("@str3", this.tmp_armas.str3); // V.2
                            cmd.Parameters.AddWithValue("@str4", this.tmp_armas.str4); // V.2
                            cmd.Parameters.AddWithValue("@c_type", this.tmp_armas.c_type); // V.2
                            cmd.Parameters.AddWithValue("@creby", this.main_form.loged_in_status.loged_in_user_name);
                            cmd.Parameters.AddWithValue("@credat", DateTime.Now);
                            cmd.Parameters.AddWithValue("@userid", this.main_form.loged_in_status.loged_in_user_name);
                            cmd.Parameters.AddWithValue("@chgdat", DateTime.Now);
                        }
                        else // edit
                        {
                            cmd.Parameters.AddWithValue("@userid", this.main_form.loged_in_status.loged_in_user_name);
                            cmd.Parameters.AddWithValue("@chgdat", DateTime.Now);
                            cmd.Parameters.AddWithValue("@cuscod", this.tmp_armas.cuscod);
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        if(this.form_mode == FORM_MODE.ADD)
                            Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.ARMAS);

                        this.ResetFormState(FORM_MODE.READ);
                        this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, this.tmp_armas.cuscod.TrimEnd());
                        this.FillForm(this.curr_armas);
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return;
            }
        }

        private void btnSearch_ButtonClick(object sender, EventArgs e)
        {
            DialogSimpleSearch search = new DialogSimpleSearch("รหัสลูกค้า", this.search_keyword, CultureInfo.GetCultureInfo("TH-th"));
            search.txtKeyword.Width -= 50;
            search.txtKeyword.MaxLength = 10;
            search.txtKeyword.CharacterCasing = CharacterCasing.Upper;
            search.txtKeyword.SelectionStart = search.txtKeyword.Text.Length;
            if(search.ShowDialog() == DialogResult.OK)
            {
                this.search_keyword = search.keyword;

                var searching_cust = DbfTable.Armas(this.main_form.working_express_db, search.keyword.TrimEnd());
                if(searching_cust == null)
                {
                    if(XMessageBox.Show("ค้นหาไม่พบ ... ต้องการข้อมูลถัดไปหรือไม่ (Y/N)", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
                    {
                        var next_cuscod = DbfTable.ArmasCuscodList(this.main_form.working_express_db, false).Where(c => c.TrimEnd().CompareTo(search.keyword.TrimEnd()) > 0).FirstOrDefault();
                        searching_cust = DbfTable.Armas(this.main_form.working_express_db, next_cuscod);
                    }
                }

                if(searching_cust != null)
                {
                    this.curr_armas = searching_cust;
                    this.FillForm(this.curr_armas);
                }
            }
        }

        private DataGridViewColumn[] GetInquiryColumn()
        {
            DataGridViewTextBoxColumn col_cuscod = new DataGridViewTextBoxColumn
            {
                Name = "col_cuscod",
                HeaderText = "รหัส",
                DataPropertyName = "cuscod",
                Width = 120,
                MinimumWidth = 120
            };

            DataGridViewTextBoxColumn col_cusnam = new DataGridViewTextBoxColumn
            {
                Name = "col_cusnam",
                HeaderText = "ชื่อลูกค้า",
                DataPropertyName = "cusnam",
                Width = 220,
                MinimumWidth = 220,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_prenam = new DataGridViewTextBoxColumn
            {
                Name = "col_prenam",
                HeaderText = "คำนำหน้า",
                DataPropertyName = "prenam",
                Width = 140,
                MinimumWidth = 140
            };
            DataGridViewTextBoxColumn col_contact = new DataGridViewTextBoxColumn
            {
                Name = "col_contact",
                HeaderText = "ชื่อผู้ติดต่อ",
                DataPropertyName = "contact",
                Width = 140,
                MinimumWidth = 140
            };
            DataGridViewTextBoxColumn col_paytrm = new DataGridViewTextBoxColumn
            {
                Name = "col_paytrm",
                HeaderText = "เครดิต",
                DataPropertyName = "paytrm",
                Width = 60,
                MinimumWidth = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            DataGridViewTextBoxColumn col_paycond = new DataGridViewTextBoxColumn
            {
                Name = "col_paycond",
                HeaderText = "เงื่อนไข",
                DataPropertyName = "paycond",
                Width = 140,
                MinimumWidth = 140
            };
            DataGridViewTextBoxColumn col_tabpr = new DataGridViewTextBoxColumn
            {
                Name = "col_tabpr",
                HeaderText = "ราคา",
                DataPropertyName = "tabpr",
                Width = 60,
                MinimumWidth = 60
            };
            DataGridViewTextBoxColumn col_disc = new DataGridViewTextBoxColumn
            {
                Name = "col_disc",
                HeaderText = "ส่วนลด",
                DataPropertyName = "disc",
                Width = 100,
                MinimumWidth = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            DataGridViewTextBoxColumn col_crline = new DataGridViewTextBoxColumn
            {
                Name = "col_crline",
                HeaderText = "วงเงินอนุมัติ",
                DataPropertyName = "crline",
                Width = 120,
                MinimumWidth = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }
            };
            DataGridViewTextBoxColumn col_slmcod = new DataGridViewTextBoxColumn
            {
                Name = "col_slmcod",
                HeaderText = "พนักงานขาย",
                DataPropertyName = "slmcod",
                Width = 100,
                MinimumWidth = 100
            };
            DataGridViewTextBoxColumn col_areacod = new DataGridViewTextBoxColumn
            {
                Name = "col_areacod",
                HeaderText = "เขต",
                DataPropertyName = "areacod",
                Width = 60,
                MinimumWidth = 60
            };
            DataGridViewTextBoxColumn col_dlvby = new DataGridViewTextBoxColumn
            {
                Name = "col_dlvby",
                HeaderText = "ขนส่ง",
                DataPropertyName = "dlvby",
                Width = 80,
                MinimumWidth = 80
            };
            DataGridViewTextBoxColumn col_accnum = new DataGridViewTextBoxColumn
            {
                Name = "col_accnum",
                HeaderText = "เลขที่บัญชี",
                DataPropertyName = "accnum",
                Width = 120,
                MinimumWidth = 120
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[] { col_cuscod, col_cusnam, col_prenam, col_contact, col_paytrm, col_paycond, col_tabpr, col_disc, col_crline, col_slmcod, col_areacod, col_dlvby, col_accnum };
            return cols;
        }

        private void btnInquiryAll_Click(object sender, EventArgs e)
        {
            var cust_list = DbfTable.ArmasList(this.main_form.working_express_db);

            string init_cuscod = cust_list.Count > 0 ? cust_list.First().cuscod : null;

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.GetInquiryColumn(), cust_list, "col_cuscod", init_cuscod);
            br.Width = 1050;
            br.StartPosition = FormStartPosition.CenterParent;
            if(br.ShowDialog() == DialogResult.OK)
            {
                string selected_cuscod = (string)br.selected_row.Cells["col_cuscod"].Value;
                var selected_cust = DbfTable.Armas(this.main_form.working_express_db, selected_cuscod);

                if(selected_cuscod != null)
                {
                    this.curr_armas = selected_cust;
                    this.FillForm(this.curr_armas);
                }
            }
        }

        private void btnInquiryRest_Click(object sender, EventArgs e)
        {
            var cust_list = DbfTable.ArmasList(this.main_form.working_express_db);

            string init_cuscod = this.curr_armas != null ? this.curr_armas.cuscod : null;

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(this.GetInquiryColumn(), cust_list, "col_cuscod", init_cuscod);
            br.Width = 1050;
            br.StartPosition = FormStartPosition.CenterParent;
            if (br.ShowDialog() == DialogResult.OK)
            {
                string selected_cuscod = (string)br.selected_row.Cells["col_cuscod"].Value;
                var selected_cust = DbfTable.Armas(this.main_form.working_express_db, selected_cuscod);

                if (selected_cuscod != null)
                {
                    this.curr_armas = selected_cust;
                    this.FillForm(this.curr_armas);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(this.curr_armas != null)
            {
                this.curr_armas = DbfTable.Armas(this.main_form.working_express_db, this.curr_armas.cuscod);
                this.FillForm(this.curr_armas);
            }
        }

        private void cCuscod_Leave(object sender, EventArgs e)
        {
            if(this.form_mode == FORM_MODE.ADD)
            {
                var cuscod_list = DbfTable.ArmasCuscodList(this.main_form.working_express_db);
                if(cuscod_list.Where(c => c.TrimEnd() == ((XTextEdit)sender)._Text.TrimEnd()).Count() > 0)
                {
                    ((XTextEdit)sender).Focus();
                    XMessageBox.Show("รหัสลูกค้า '" + ((XTextEdit)sender)._Text.TrimEnd() + "' นี้มีอยู่แล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void cPrenam__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "ข้อความ",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "รหัส",
                DataPropertyName = "shortnam",
                Width = 80,
                MinimumWidth = 80,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typdes,
                col_shortnam
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.PRENAM).Select(i => new { shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(/*this.main_form, */cols, datasource, col_typdes.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typdes;
            }
        }

        private void cRemark__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "ข้อความ",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "รหัส",
                DataPropertyName = "shortnam",
                Width = 80,
                MinimumWidth = 80,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typdes,
                col_shortnam
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.REMARK_AR).Select(i => new { shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(/*this.main_form, */cols, datasource, col_typdes.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typdes;
            }
        }

        private void cPaycond__ButtonClick(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col_typdes = new DataGridViewTextBoxColumn
            {
                Name = "col_typdes",
                HeaderText = "ข้อความ",
                DataPropertyName = "typdes",
                Width = 160,
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            DataGridViewTextBoxColumn col_shortnam = new DataGridViewTextBoxColumn
            {
                Name = "col_shortnam",
                HeaderText = "รหัส",
                DataPropertyName = "shortnam",
                Width = 80,
                MinimumWidth = 80,
            };

            DataGridViewColumn[] cols = new DataGridViewColumn[]
            {
                col_typdes,
                col_shortnam
            };

            var datasource = DbfTable.IstabList(this.main_form.working_express_db, TABTYP.PAYCOND).Select(i => new { shortnam = i.shortnam, typdes = i.typdes }).ToList();

            DialogBrowseBoxSelector br = new DialogBrowseBoxSelector(/*this.main_form, */cols, datasource, col_typdes.Name, ((XBrowseBox)sender)._Text.TrimEnd());
            br.SetBounds(((XBrowseBox)sender).PointToScreen(Point.Empty).X - 5, ((XBrowseBox)sender).PointToScreen(Point.Empty).Y + ((XBrowseBox)sender).Height, br.Width, br.Height);

            if (br.ShowDialog() == DialogResult.OK)
            {
                string typdes = br.selected_row.Cells[col_typdes.Name].Value.ToString();
                ((XBrowseBox)sender)._Text = typdes;
            }
        }

        private void cSlmcod__Leave(object sender, EventArgs e)
        {
            this.cSlmnam.Text = ((BrowseBoxSlm)sender).selected_slmnam;
        }

        private void cSlmcod__SelectedSlmcodChanged(object sender, EventArgs e)
        {
            this.cSlmnam.Text = ((BrowseBoxSlm)sender).selected_slmnam;
        }

        private void cAccnum__Leave(object sender, EventArgs e)
        {
            this.cAccnam.Text = ((BrowseBoxAccnum)sender).selected_accnam;
        }

        private void cAccnum__SelectedAccnumChanged(object sender, EventArgs e)
        {
            this.cAccnam.Text = ((BrowseBoxAccnum)sender).selected_accnam;
        }

        private void cCustyp__Leave(object sender, EventArgs e)
        {
            this.cCustypDesc.Text = ((BrowseBoxIstabFixed)sender).selected_typdes;
        }

        private void cCustyp__SelectedIstabChanged(object sender, EventArgs e)
        {
            this.cCustypDesc.Text = ((BrowseBoxIstabFixed)sender).selected_typdes;
        }

        private void cDlvby__Leave(object sender, EventArgs e)
        {
            this.cDlvbyDesc.Text = ((BrowseBoxIstabFixed)sender).selected_typdes;
        }

        private void cDlvby__SelectedIstabChanged(object sender, EventArgs e)
        {
            this.cDlvbyDesc.Text = ((BrowseBoxIstabFixed)sender).selected_typdes;
        }

        private void cAreacod__Leave(object sender, EventArgs e)
        {
            this.cAreaDesc.Text = ((BrowseBoxIstabFixed)sender).selected_typdes;
        }

        private void cAreacod__SelectedIstabChanged(object sender, EventArgs e)
        {
            this.cAreaDesc.Text = ((BrowseBoxIstabFixed)sender).selected_typdes;
        }

        private void cCuscod__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.cuscod = ((XTextEdit)sender)._Text;
        }

        private void cPrenam__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.prenam = ((XBrowseBox)sender)._Text;
        }

        private void cCusnam__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.cusnam = ((XTextEdit)sender)._Text;
        }

        private void cAddr01__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.addr01 = ((XTextEdit)sender)._Text;
        }

        private void cAddr02__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.addr02 = ((XTextEdit)sender)._Text;
        }

        private void cAddr03__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.addr03 = ((XTextEdit)sender)._Text;
        }

        private void cZipcod__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.zipcod = ((XNumTextEdit)sender)._Text;
        }

        private void cTelnum__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.telnum = ((XTextEdit)sender)._Text;
        }

        private void cContact__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.contact = ((XTextEdit)sender)._Text;
        }

        private void cRemark__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.remark = ((XBrowseBox)sender)._Text;
        }

        private void cTaxid__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.taxid = ((XNumTextEdit)sender)._Text;
        }

        private void cStatus__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.status = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void cPaytrm__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.paytrm = Convert.ToInt32(((XNumEdit)sender)._Value);
        }

        private void cOrgnum__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.orgnum = Convert.ToInt32(((XNumEdit)sender)._Value);
        }

        private void cPaycond__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.paycond = ((XBrowseBox)sender)._Text;
        }

        private void cTabpr__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.tabpr = (string)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
        }

        private void cDisc__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.disc = ((TextEditDisc)sender)._Text;
        }

        private void cCrline__ValueChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.crline = Convert.ToDouble(((XNumEdit)sender)._Value);
        }

        private void cCustyp__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.custyp = ((BrowseBoxIstabFixed)sender)._Text;
        }

        private void cAccnum__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.accnum = ((BrowseBoxAccnum)sender)._Text;
        }

        private void cSlmcod__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.slmcod = ((BrowseBoxSlm)sender)._Text;
        }

        private void cAreacod__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.areacod = ((BrowseBoxIstabFixed)sender)._Text;
        }

        private void cDlvby__TextChanged(object sender, EventArgs e)
        {
            if (this.tmp_armas != null)
                this.tmp_armas.dlvby = ((BrowseBoxIstabFixed)sender)._Text;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.form_mode == FORM_MODE.ADD || this.form_mode == FORM_MODE.EDIT)
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

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

            if(keyData == (Keys.Control | Keys.End))
            {
                this.btnLast.PerformClick();
                return true;
            }

            if(keyData == (Keys.Alt | Keys.S))
            {
                this.btnSearch.PerformButtonClick();
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

            if(keyData == (Keys.Control | Keys.F5))
            {
                this.btnRefresh.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}