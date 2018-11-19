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
using System.Data.OleDb;
using System.Threading;
using System.IO;
using System.Globalization;

namespace XPump.SubForm
{
    public partial class DialogTransferInvoiceData : Form
    {
        private MainForm main_form;
        private List<IsrunDbf> isrun;
        private List<artrn> artrn;
        private IsrunDbf selected_doctype;
        private DateTime? selected_date_from;
        private DateTime? selected_date_to;
        private bool group_bill = false;

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

        private void cDateFrom__SelectedDateChanged(object sender, EventArgs e)
        {
            this.selected_date_from = ((XDatePicker)sender)._SelectedDate;
            this.SetBtnOkState();
        }

        private void cDateFrom__Leave(object sender, EventArgs e)
        {
            this.selected_date_from = ((XDatePicker)sender)._SelectedDate;
            this.SetBtnOkState();
        }

        private void cDateTo__SelectedDateChanged(object sender, EventArgs e)
        {
            this.selected_date_to = ((XDatePicker)sender)._SelectedDate;
            this.SetBtnOkState();
        }

        private void cDateTo__Leave(object sender, EventArgs e)
        {
            this.selected_date_to = ((XDatePicker)sender)._SelectedDate;
            this.SetBtnOkState();
        }

        private void cGroupBill_CheckedChanged(object sender, EventArgs e)
        {
            this.group_bill = ((CheckBox)sender).Checked;
        }

        private void SetBtnOkState()
        {
            this.btnOK.Enabled = this.selected_doctype != null && this.selected_date_from.HasValue && this.selected_date_to.HasValue ? true : false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Console.WriteLine(" ==> doc.prefix : " + this.selected_doctype.prefix);
            Console.WriteLine(" ==> selected_date_from : " + this.selected_date_from.Value);
            Console.WriteLine(" ==> selected_date_to : " + this.selected_date_to.Value);
            Console.WriteLine(" ==> group_bill : " + this.group_bill);

            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                this.artrn = db.artrn.Include("stcrd").Include("arrcpcq").Where(a => a.docnum.Substring(0, 2) == this.selected_doctype.prefix && a.docdat.CompareTo(this.selected_date_from.Value) >= 0 && a.docdat.CompareTo(this.selected_date_to.Value) <= 0 && (a.str1 == null || a.str1.Trim().Length == 0)).ToList();
                if(this.artrn.Count == 0)
                {
                    XMessageBox.Show("ไม่มีข้อมูลตามขอบเขตที่กำหนด");
                    return;
                }

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log");

                DateTime curr_time = DateTime.Now;
                string log_file_name = curr_time.ToString("yyyy-MM-dd_HH-mm-ss", CultureInfo.GetCultureInfo("EN-us")) + ".txt";
                using (StreamWriter wr = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log\" + log_file_name))
                {
                    wr.WriteLine("Transfer data at " + curr_time.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("TH-th")));
                    wr.WriteLine("Document prefix : '" + this.selected_doctype.prefix + "'");
                    wr.WriteLine("Date range : " + this.selected_date_from.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")) + " - " + this.selected_date_to.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")));
                    wr.WriteLine("");
                    wr.WriteLine("Number\t\tDate\t\tResult");
                    wr.WriteLine("================================");
                }


                if (!this.group_bill)
                {
                    BackgroundWorker wrk = new BackgroundWorker();
                    wrk.WorkerSupportsCancellation = true;
                    wrk.WorkerReportsProgress = true;

                    this.progressBar1.Maximum = this.artrn.Count;
                    this.progressBar1.Value = 0;

                    int completed_row = 0;
                    wrk.DoWork += delegate (object obj, DoWorkEventArgs ev)
                    {
                        this.artrn.ForEach(a =>
                        {
                            var insert_result = this.InsertInvoice(this.main_form.working_express_db, a);
                            if (insert_result.success)
                            {
                                using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log\" + log_file_name))
                                {
                                    sw.WriteLine(a.docnum + "\t" + a.docdat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")) + "\tcompleted.");
                                }
                            }
                            else
                            {
                                using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log\" + log_file_name))
                                {
                                    sw.WriteLine(a.docnum + "\t" + a.docdat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")) + "\tError: " + insert_result.err_message);
                                }
                            }

                            wrk.ReportProgress(++completed_row);
                        });
                    };

                    wrk.RunWorkerCompleted += delegate (object obj, RunWorkerCompletedEventArgs ev)
                    {
                        MessageBox.Show("completed");
                    };

                    wrk.ProgressChanged += delegate (object obj, ProgressChangedEventArgs ev)
                    {
                        this.progressBar1.Value = ev.ProgressPercentage;
                        var perc = (decimal)(Convert.ToDecimal(ev.ProgressPercentage) / Convert.ToDecimal(this.progressBar1.Maximum)) * 100;
                        this.lblProgressPercent.Text = perc.ToString("N0") + "%";
                    };
                    wrk.RunWorkerAsync();

                    //this.artrn.ForEach(a =>
                    //{
                    //    DbfInsertResult result = this.InsertInvoice(conn, a);
                    //    if (!result.success)
                    //    {

                    //    }
                    //});
                }
                else
                {

                }

            }
        }

        private DbfInsertResult InsertInvoice(SccompDbf working_express_db, artrn artrn)
        {
            DbfInsertResult result = new DbfInsertResult { success = false, err_message = string.Empty };
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + working_express_db.abs_path))
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into artrn (";
                        cmd.CommandText += string.Join(",", artrn.GetType().GetProperties().ToList().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").Select(p => p.Name));
                        cmd.CommandText += ") Values(";
                        cmd.CommandText += string.Join(",", artrn.GetType().GetProperties().ToList().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").Select(p => "?"));
                        cmd.CommandText += ")";

                        artrn.GetType().GetProperties().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").ToList().ForEach(p =>
                        {
                            cmd.Parameters.AddWithValue("@" + p.Name, p.GetValue(artrn, null));
                        });

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        result.success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.err_message = ex.Message;
            }

            return result;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F9)
            {
                this.btnOK.Focus();
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class DbfInsertResult
    {
        public bool success { get; set; }
        public string err_message { get; set; }
    }
}
