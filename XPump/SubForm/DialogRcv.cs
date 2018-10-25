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

namespace XPump.SubForm
{
    public partial class DialogRcv : Form
    {
        private MainForm main_form;
        private artrn artrn;
        private BindingList<ArrcpcqInvoice> arrcpcq_credit_card;
        private BindingList<ArrcpcqInvoice> arrcpcq_coupon;
        private int rcv_credit_card_method_id;
        private int rcv_coupon_method_id;

        public DialogRcv(MainForm main_form, artrn artrn)
        {
            this.main_form = main_form;
            this.artrn = artrn;
            InitializeComponent();
        }

        private void DialogRcv_Load(object sender, EventArgs e)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.rcv_credit_card_method_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").First().id;
                this.rcv_coupon_method_id = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").First().id;
            }

            this.arrcpcq_credit_card = new BindingList<ArrcpcqInvoice>(this.artrn.arrcpcq.Where(a => a.rcv_method_id == this.rcv_credit_card_method_id).Select(a => new ArrcpcqInvoice { arrcpcq = a, working_express_db = this.main_form.working_express_db }).ToList());
            this.dgvRcv1.DataSource = this.arrcpcq_credit_card;

            this.arrcpcq_coupon = new BindingList<ArrcpcqInvoice>(this.artrn.arrcpcq.Where(a => a.rcv_method_id == this.rcv_coupon_method_id).Select(a => new ArrcpcqInvoice { arrcpcq = a, working_express_db = this.main_form.working_express_db }).ToList());
            this.dgvRcv2.DataSource = this.arrcpcq_coupon;
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
                    rcpnum = this.artrn.docnum,
                    rcvamt = 0,
                    userid = this.main_form.loged_in_status.loged_in_user_name
                };

                DialogCreditCardRcv rcv = new DialogCreditCardRcv(this.main_form, tmp_arrcpcq);
                if (rcv.ShowDialog() == DialogResult.OK)
                {
                    this.artrn.arrcpcq.Add(tmp_arrcpcq);
                    this.artrn.chqrcv = this.artrn.arrcpcq.Sum(q => q.rcvamt);
                    this.artrn.cshrcv = this.artrn.netamt - this.artrn.chqrcv;

                    var rcv_list = this.artrn.arrcpcq.Where(i => i.rcv_method_id == tmp_arrcpcq.rcv_method_id).Select(i => new ArrcpcqInvoice { working_express_db = this.main_form.working_express_db, arrcpcq = i }).ToList();
                    this.arrcpcq_credit_card = new BindingList<ArrcpcqInvoice>(rcv_list);

                    this.dgvRcv1.DataSource = this.arrcpcq_credit_card;
                }

                DialogCreditCardRcv cr = new DialogCreditCardRcv(this.main_form, tmp_arrcpcq);
            }
        }

        private void btnAddCoupon_Click(object sender, EventArgs e)
        {

        }
    }
}
