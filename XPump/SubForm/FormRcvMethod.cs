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
