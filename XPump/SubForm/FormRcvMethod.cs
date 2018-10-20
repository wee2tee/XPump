using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using CC;
using System.Data.OleDb;
using XPump.Misc;

namespace XPump.SubForm
{
    public partial class FormRcvMethod : Form
    {
        //private IsrunDbf pCreditCard = null;
        //private IsrunDbf pCoupon = null;
        private MainForm main_form;
        private List<IsrunRcvMethod> isrun_rcv_method;
        private istab rcvCreditCard = null;
        private istab rcvCoupon = null;
        private istab tmpRcvCreditCard = null;
        private istab tmpRcvCoupon = null;
        private FORM_MODE form_mode;

        public FormRcvMethod(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void FormRcvMethod_Load(object sender, EventArgs e)
        {
            this.EnsureRcvMethodIsReady();
            this.isrun_rcv_method = GetIsrunRcvMethodList(this.main_form.working_express_db);
            this.isrun_rcv_method.ForEach(r =>
            {
                this.pairingCoupon._Items.Add(new XDropdownListItem { Text = r.prefix + " : " + r.posdes, Value = r.prefix });
                this.pairingCreditCard._Items.Add(new XDropdownListItem { Text = r.prefix + " : " + r.posdes, Value = r.prefix });
            });

            var selected_creditcard_pair = this.pairingCreditCard._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.rcvCreditCard.shortnam.TrimEnd()).FirstOrDefault();
            if (selected_creditcard_pair != null)
                this.pairingCreditCard._SelectedItem = selected_creditcard_pair;

            var selected_coupon_pair = this.pairingCoupon._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.rcvCoupon.shortnam.TrimEnd()).FirstOrDefault();
            if (selected_coupon_pair != null)
                this.pairingCoupon._SelectedItem = selected_coupon_pair;
        }

        private void EnsureRcvMethodIsReady()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                if (db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault() == null)
                {
                    db.istab.Add(new istab
                    {
                        creby = this.main_form.loged_in_status.loged_in_user_name,
                        cretime = DateTime.Now,
                        id = -1,
                        is_dayend = false,
                        is_shiftsales = false,
                        shortnam = "บัตรเครดิต",
                        shortnam2 = "Credit Card",
                        tabtyp = ISTAB_TABTYP.RCV_METHOD,
                        typcod = "CR",
                        typdes = "รับชำระด้วยบัตรเครดิต",
                        typdes2 = "Receive by Credit Card"
                    });
                    db.SaveChanges();
                }

                if (db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault() == null)
                {
                    db.istab.Add(new istab
                    {
                        creby = this.main_form.loged_in_status.loged_in_user_name,
                        cretime = DateTime.Now,
                        id = -1,
                        is_dayend = false,
                        is_shiftsales = false,
                        shortnam = "คูปอง",
                        shortnam2 = "Coupon",
                        tabtyp = ISTAB_TABTYP.RCV_METHOD,
                        typcod = "CP",
                        typdes = "รับชำระด้วยคูปองแทนเงินสด",
                        typdes2 = "Receive by Coupon"
                    });
                    db.SaveChanges();
                }

                this.rcvCreditCard = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault();
                this.rcvCoupon = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault();
            }
        }

        public static List<IsrunRcvMethod> GetIsrunRcvMethodList(SccompDbf working_express_db)
        {
            List<IsrunRcvMethod> rcv_method_list = new List<IsrunRcvMethod>();

            using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + working_express_db.abs_path))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Select doctyp, doccod, shortnam, shortnam2, posdes, posdes2, prefix From isrun Where doctyp=?";
                    cmd.Parameters.AddWithValue("@Doctyp", "ZR");

                    conn.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        conn.Close();

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            rcv_method_list.Add(new IsrunRcvMethod
                            {
                                doctyp = !dt.Rows[i].IsNull("doctyp") ? dt.Rows[i]["doctyp"].ToString().TrimEnd() : string.Empty,
                                doccod = !dt.Rows[i].IsNull("doccod") ? dt.Rows[i]["doccod"].ToString().TrimEnd() : string.Empty,
                                shortnam = !dt.Rows[i].IsNull("shortnam") ? dt.Rows[i]["shortnam"].ToString().TrimEnd() : string.Empty,
                                shortnam2 = !dt.Rows[i].IsNull("shortnam2") ? dt.Rows[i]["shortnam2"].ToString().TrimEnd() : string.Empty,
                                posdes = !dt.Rows[i].IsNull("posdes") ? dt.Rows[i]["posdes"].ToString().TrimEnd() : string.Empty,
                                posdes2 = !dt.Rows[i].IsNull("posdes2") ? dt.Rows[i]["posdes2"].ToString().TrimEnd() : string.Empty,
                                prefix = !dt.Rows[i].IsNull("prefix") ? dt.Rows[i]["prefix"].ToString().TrimEnd() : string.Empty,
                            });
                        }

                        return rcv_method_list;
                    }
                }
            }
        }

        private void ResetFormState(FORM_MODE form_mode)
        {
            this.form_mode = form_mode;

            this.btnEdit.SetControlState(new FORM_MODE[] { FORM_MODE.READ }, this.form_mode);
            this.btnSave.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.btnStop.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);

            this.pairingCreditCard.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
            this.pairingCoupon.SetControlState(new FORM_MODE[] { FORM_MODE.EDIT }, this.form_mode);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.tmpRcvCreditCard = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault();
                this.tmpRcvCoupon = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault();

                var selected_creditcard_pair = this.pairingCreditCard._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.tmpRcvCreditCard.shortnam.TrimEnd()).FirstOrDefault();
                if (selected_creditcard_pair != null)
                    this.pairingCreditCard._SelectedItem = selected_creditcard_pair;

                var selected_coupon_pair = this.pairingCoupon._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.tmpRcvCoupon.shortnam.TrimEnd()).FirstOrDefault();
                if (selected_coupon_pair != null)
                    this.pairingCoupon._SelectedItem = selected_coupon_pair;

                this.ResetFormState(FORM_MODE.EDIT);
                this.pairingCreditCard.Focus();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.rcvCreditCard = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault();
                this.rcvCoupon = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault();

                var selected_creditcard_pair = this.pairingCreditCard._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.rcvCreditCard.shortnam.TrimEnd()).FirstOrDefault();
                if (selected_creditcard_pair != null)
                    this.pairingCreditCard._SelectedItem = selected_creditcard_pair;

                var selected_coupon_pair = this.pairingCoupon._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.rcvCoupon.shortnam.TrimEnd()).FirstOrDefault();
                if (selected_coupon_pair != null)
                    this.pairingCoupon._SelectedItem = selected_coupon_pair;

                this.tmpRcvCreditCard = null;
                this.tmpRcvCoupon = null;
                this.ResetFormState(FORM_MODE.READ);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    this.rcvCreditCard = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault();
                    this.rcvCoupon = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault();

                    this.rcvCreditCard.shortnam = this.tmpRcvCreditCard.shortnam;
                    this.rcvCreditCard.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    this.rcvCreditCard.chgtime = DateTime.Now;
                    this.rcvCoupon.shortnam = this.tmpRcvCoupon.shortnam;
                    this.rcvCoupon.chgby = this.main_form.loged_in_status.loged_in_user_name;
                    this.rcvCoupon.chgtime = DateTime.Now;
                    db.SaveChanges();

                    var selected_creditcard_pair = this.pairingCreditCard._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.rcvCreditCard.shortnam.TrimEnd()).FirstOrDefault();
                    if (selected_creditcard_pair != null)
                        this.pairingCreditCard._SelectedItem = selected_creditcard_pair;

                    var selected_coupon_pair = this.pairingCoupon._Items.Cast<XDropdownListItem>().Where(i => i.Value.ToString().TrimEnd() == this.rcvCoupon.shortnam.TrimEnd()).FirstOrDefault();
                    if (selected_coupon_pair != null)
                        this.pairingCoupon._SelectedItem = selected_coupon_pair;

                    this.tmpRcvCreditCard = null;
                    this.tmpRcvCoupon = null;
                    this.ResetFormState(FORM_MODE.READ);
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
            }
        }

        private void pairingCreditCard__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmpRcvCreditCard != null && ((XDropdownList)sender)._SelectedItem != null)
                this.tmpRcvCreditCard.shortnam = ((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value.ToString();
        }

        private void pairingCoupon__SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.tmpRcvCoupon != null && ((XDropdownList)sender)._SelectedItem != null)
                this.tmpRcvCoupon.shortnam = ((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value.ToString();
        }

        private void performEdit(object sender, EventArgs e)
        {
            if (this.form_mode == FORM_MODE.READ)
                this.btnEdit.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Alt | Keys.E))
            {
                this.btnEdit.PerformClick();
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class IsrunRcvMethod
    {
        public string doctyp { get; set; }
        public string doccod { get; set; }
        public string shortnam { get; set; }
        public string shortnam2 { get; set; }
        public string posdes { get; set; }
        public string posdes2 { get; set; }
        public string prefix { get; set; }
    }
}
