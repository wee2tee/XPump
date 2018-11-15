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
    public partial class DialogTransferInvoiceData : Form
    {
        private MainForm main_form;
        private List<IsrunDbf> isrun;
        private IsrunDbf selected_doctype;
        private DateTime? selected_date;

        public DialogTransferInvoiceData(MainForm main_form)
        {
            this.main_form = main_form;
            InitializeComponent();
        }

        private void DialogTransferInvoiceData_Load(object sender, EventArgs e)
        {
            this.isrun = DbfTable.Isrun(this.main_form.working_express_db).ToIsrunList().Where(i => i.doctyp.TrimEnd() == "HS" || i.doctyp.TrimEnd() == "IV").OrderBy(i => i.doctyp).ThenBy(i => i.prefix).ToList();
            //var mnu_iv = DbfTable.Isrun(this.main_form.working_express_db).ToIsrunList().Where(i => i.doctyp.TrimEnd() == "IV").OrderBy(i => i.prefix).ToList();
            this.isrun.ForEach(i =>
            {
                this.cDocPrefix._Items.Add(new XDropdownListItem { Text = i.prefix.TrimEnd() + " : " + i.posdes.TrimEnd(), Value = i });
            });
        }

        private void cDocPrefix__SelectedItemChanged(object sender, EventArgs e)
        {
            this.selected_doctype = (IsrunDbf)((XDropdownListItem)((XDropdownList)sender)._SelectedItem).Value;
            this.SetBtnOkState();
        }

        private void cDate__SelectedDateChanged(object sender, EventArgs e)
        {
            this.selected_date = ((XDatePicker)sender)._SelectedDate;
            this.SetBtnOkState();
        }

        private void cDate__Leave(object sender, EventArgs e)
        {
            this.selected_date = ((XDatePicker)sender)._SelectedDate;
            this.SetBtnOkState();
        }

        private void SetBtnOkState()
        {
            this.btnOK.Enabled = this.selected_doctype != null && this.selected_date.HasValue ? true : false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Console.WriteLine(" ==> doc.prefix : " + this.selected_doctype.prefix);
            Console.WriteLine(" ==> selected_date : " + this.selected_date.Value);
        }
    }
}
