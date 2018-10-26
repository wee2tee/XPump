using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

namespace XPump.SubForm
{
    public partial class DialogCouponRcv : Form
    {
        private MainForm main_form;
        private arrcpcq arrcpcq;

        public DialogCouponRcv(MainForm main_form, arrcpcq arrcpcq)
        {
            this.main_form = main_form;
            this.arrcpcq = arrcpcq;
            InitializeComponent();
        }

        private void DialogCouponRcv_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.couponNum;

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var istab_cr = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CP").FirstOrDefault();
                if (istab_cr.shortnam.Trim().Length == 0)
                {
                    this.Close();

                    XMessageBox.Show("ท่านจะต้องกำหนดวิธีการรับชำระโดยจับคู่กับวิธีการรับชำระในโปรแกรมเอ็กซ์เพรสให้เรียบร้อยก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Information);
                    var rcv_method_form = new FormRcvMethod(this.main_form);
                    rcv_method_form.ShowDialog();
                    return;
                }

                this.arrcpcq.rcv_method_id = istab_cr.id;
                this.arrcpcq.chqnum = istab_cr.shortnam + this.arrcpcq.rcpnum;
                this.chqnum.Text = this.arrcpcq.chqnum;
            }

            this.couponNum.Text = this.arrcpcq.cardnum;
        }

        private void SetBtnOkState()
        {
            if (this.arrcpcq.cardnum.Replace("-", "").Trim().Length > 0 && this.arrcpcq.rcvamt > 0)
            {
                this.btnOK.Enabled = true;
            }
            else
            {
                this.btnOK.Enabled = false;
            }
        }

        private void rcvAmount_Enter(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(string.Format("{0:N0}", ((NumericUpDown)sender).Value).Length, 0);
        }

        private void couponNum_TextChanged(object sender, EventArgs e)
        {
            this.arrcpcq.cardnum = ((TextBox)sender).Text;
            this.SetBtnOkState();
        }

        private void rcvAmount_KeyUp(object sender, KeyEventArgs e)
        {
            this.arrcpcq.rcvamt = ((NumericUpDown)sender).Value;
            this.SetBtnOkState();
        }

        private void rcvAmount_Leave(object sender, EventArgs e)
        {
            this.arrcpcq.rcvamt = ((NumericUpDown)sender).Value;
            this.SetBtnOkState();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter)
            {
                if(!(this.btnOK.Focused || this.btnCancel.Focused))
                {
                    SendKeys.Send("{TAB}");
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
