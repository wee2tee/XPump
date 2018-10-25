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

namespace XPump.SubForm
{
    public partial class DialogCreditCardRcv : Form
    {
        private MainForm main_form;
        private arrcpcq arrcpcq;

        public DialogCreditCardRcv(MainForm main_form, arrcpcq arrcpcq)
        {
            this.main_form = main_form;
            this.arrcpcq = arrcpcq;
            InitializeComponent();
        }

        private void DialogCreditCardRcv_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.creditCardNum;
            this.LoadBankCodeToCombobox();

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                var istab_cr = db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.RCV_METHOD && i.typcod == "CR").FirstOrDefault();
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

            this.creditCardNum.Text = this.arrcpcq.cardnum;

            XDropdownListItem selected_bank = null;
            if(this.arrcpcq.bank_id != null)
                selected_bank = this.bnkCod.Items.Cast<XDropdownListItem>().Where(i => (int)i.Value == this.arrcpcq.bank_id).FirstOrDefault();

            if (selected_bank != null)
            {
                this.bnkCod.SelectedItem = selected_bank;
            }
            else
            {
                this.bnkCod.SelectedItem = this.bnkCod.Items.Cast<XDropdownListItem>().Where(i => i.Value == null).First();
            }
        }

        private void LoadBankCodeToCombobox()
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.bnkCod.Items.Add(new XDropdownListItem { Text = string.Empty, Value = null });

                db.istab.Where(i => i.tabtyp == ISTAB_TABTYP.BANK).OrderBy(i => i.typcod).ToList().ForEach(i =>
                {
                    this.bnkCod.Items.Add(new XDropdownListItem { Text = i.typcod + " : " + i.typdes, Value = i.id });
                });
            }
        }

        private void SetBtnOkState()
        {
            if(this.arrcpcq.cardnum.Replace("-", "").Trim().Length > 0 && this.arrcpcq.rcvamt > 0)
            {
                this.btnOK.Enabled = true;
            }
            else
            {
                this.btnOK.Enabled = false;
            }
        }

        private void creditCardNum_TextChanged(object sender, EventArgs e)
        {
            this.arrcpcq.cardnum = ((MaskedTextBox)sender).Text;
            this.SetBtnOkState();
        }

        private void bnkCod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.arrcpcq.bank_id = (int?)((XDropdownListItem)((ComboBox)sender).SelectedItem).Value;
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
