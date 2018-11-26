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
            //Console.WriteLine(" ==> doc.prefix : " + this.selected_doctype.prefix);
            //Console.WriteLine(" ==> selected_date_from : " + this.selected_date_from.Value);
            //Console.WriteLine(" ==> selected_date_to : " + this.selected_date_to.Value);
            //Console.WriteLine(" ==> group_bill : " + this.group_bill);

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

                int completed_row = 0;

                using (BackgroundWorker wrk = new BackgroundWorker())
                {
                    wrk.WorkerSupportsCancellation = true;
                    wrk.WorkerReportsProgress = true;

                    if (!this.group_bill)
                    {
                        this.progressBar1.Maximum = this.artrn.Count;
                        this.progressBar1.Value = 0;

                        wrk.DoWork += delegate (object obj, DoWorkEventArgs ev)
                        {
                            this.artrn.ForEach(a =>
                            {
                                var insert_result = this.InsertInvoice(this.main_form.working_express_db, a);
                                if (insert_result.success)
                                {
                                    using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log\" + log_file_name))
                                    {
                                        sw.WriteLine(a.docnum + "\t" + a.docdat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")) + "\tAdd document completed");
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

                            if (!Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.ARTRN))
                            {
                                XMessageBox.Show("แฟ้ม ARTRN ถูกเปิดใช้อยู่ กรุณาสั่งจัดเรียงข้อมูลแฟ้ม ARTRN ในโปรแกรมเอ็กซ์เพรสอีกครั้ง");
                            }
                            if (!Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.STCRD))
                            {
                                XMessageBox.Show("แฟ้ม STCRD ถูกเปิดใช้อยู่ กรุณาสั่งจัดเรียงข้อมูลแฟ้ม STCRD ในโปรแกรมเอ็กซ์เพรสอีกครั้ง");
                            }
                            if (!Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.ARRCPCQ))
                            {
                                XMessageBox.Show("แฟ้ม ARRCPCQ ถูกเปิดใช้อยู่ กรุณาสั่งจัดเรียงข้อมูลแฟ้ม ARRCPCQ ในโปรแกรมเอ็กซ์เพรสอีกครั้ง");
                            }
                        };

                        wrk.ProgressChanged += delegate (object obj, ProgressChangedEventArgs ev)
                        {
                            this.progressBar1.Value = ev.ProgressPercentage;
                            var perc = (decimal)(Convert.ToDecimal(ev.ProgressPercentage) / Convert.ToDecimal(this.progressBar1.Maximum)) * 100;
                            this.lblProgressPercent.Text = perc.ToString("N0") + "%";
                        };

                        wrk.RunWorkerCompleted += delegate (object obj, RunWorkerCompletedEventArgs ev)
                        {
                            MessageBox.Show("completed");
                        };

                        wrk.RunWorkerAsync();
                    }
                    else
                    {
                        this.progressBar1.Maximum = artrn.Count;
                        this.progressBar1.Value = 0;

                        wrk.DoWork += delegate(object obj, DoWorkEventArgs ev)
                        {
                            artrn.GroupBy(a1 => a1.docdat).ToList().ForEach(g1 =>
                            {
                                //Console.WriteLine("=> Docdat " + g1.First().docdat);
                                g1.ToList().GroupBy(a2 => a2.cuscod).ToList().ForEach(g2 =>
                                {
                                    //Console.WriteLine("  => Cuscod " + g2.First().cuscod);

                                    var insert_result = this.InsertInvoiceGroup(this.main_form.working_express_db, g2);
                                    if (insert_result.success)
                                    {
                                        g2.ToList().ForEach(a =>
                                        {
                                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log\" + log_file_name))
                                            {
                                                sw.WriteLine(a.docnum + "\t" + a.docdat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")) + "\tAdd document completed as a part of " + insert_result.inserted_docnum);
                                            }
                                        });
                                    }
                                    else
                                    {
                                        g2.ToList().ForEach(a =>
                                        {
                                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"\Transfer_log\" + log_file_name))
                                            {
                                                sw.WriteLine(a.docnum + "\t" + a.docdat.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("TH-th")) + "\tError: " + insert_result.err_message);
                                            }
                                        });
                                    }

                                    completed_row += g2.Count();
                                    wrk.ReportProgress(completed_row);

                                    if (!Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.ARTRN))
                                    {
                                        XMessageBox.Show("แฟ้ม ARTRN ถูกเปิดใช้อยู่ กรุณาสั่งจัดเรียงข้อมูลแฟ้ม ARTRN ในโปรแกรมเอ็กซ์เพรสอีกครั้ง");
                                    }
                                    if (!Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.STCRD))
                                    {
                                        XMessageBox.Show("แฟ้ม STCRD ถูกเปิดใช้อยู่ กรุณาสั่งจัดเรียงข้อมูลแฟ้ม STCRD ในโปรแกรมเอ็กซ์เพรสอีกครั้ง");
                                    }
                                    if (!Helper.Reindex(this.main_form.working_express_db, Helper.DBF_FILENAME_FLAG.ARRCPCQ))
                                    {
                                        XMessageBox.Show("แฟ้ม ARRCPCQ ถูกเปิดใช้อยู่ กรุณาสั่งจัดเรียงข้อมูลแฟ้ม ARRCPCQ ในโปรแกรมเอ็กซ์เพรสอีกครั้ง");
                                    }
                                });
                            });

                        };

                        wrk.ProgressChanged += delegate(object obj, ProgressChangedEventArgs ev)
                        {
                            this.progressBar1.Value = ev.ProgressPercentage;
                            var perc = (decimal)(Convert.ToDecimal(ev.ProgressPercentage) / Convert.ToDecimal(this.progressBar1.Maximum)) * 100;
                            this.lblProgressPercent.Text = perc.ToString("N0") + "%";
                        };

                        wrk.RunWorkerCompleted += delegate(object obj, RunWorkerCompletedEventArgs ev)
                        {
                            MessageBox.Show("completed");
                        };

                        wrk.RunWorkerAsync();
                    }
                }
            }
        }

        private DbfInsertResult InsertInvoice(SccompDbf working_express_db, artrn artrn)
        {
            DbfInsertResult result = new DbfInsertResult { success = false, err_message = string.Empty, inserted_docnum = string.Empty };
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + working_express_db.abs_path))
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        /* Check docnum is exist */
                        cmd.CommandText = "Select count(docnum) as cnt From artrn Where docnum = ?";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@docnum", artrn.docnum);
                        conn.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            conn.Close();
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int existing_row = Convert.ToInt32(dt.Rows[0]["cnt"]);
                            if(existing_row > 0)
                            {
                                result.err_message = "Document number " + artrn.docnum + " is already exist.";
                                Console.WriteLine(" => Error : " + result.err_message);
                                return result;
                            }
                        }

                        /* Artrn */
                        cmd.CommandText = "Insert into artrn (";
                        cmd.CommandText += string.Join(",", artrn.GetType().GetProperties().ToList().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").Select(p => p.Name));
                        cmd.CommandText += ") Values(";
                        cmd.CommandText += string.Join(",", artrn.GetType().GetProperties().ToList().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").Select(p => p.PropertyType == typeof(DateTime?) && p.GetValue(artrn, null) == null ? "{}" : "?"));
                        cmd.CommandText += ")";
                        cmd.Parameters.Clear();

                        artrn.GetType().GetProperties().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").ToList().ForEach(p =>
                        {
                            if(!(p.PropertyType == typeof(System.DateTime?) && p.GetValue(artrn, null) == null))
                            {
                                cmd.Parameters.AddWithValue("@" + p.Name, p.GetValue(artrn, null));
                            }
                        });

                        conn.Open();
                        if(cmd.ExecuteNonQuery() > 0)
                        {
                            using (xpumpEntities db = DBX.DataSet(working_express_db))
                            {
                                var artrn_to_update = db.artrn.Find(artrn.id);
                                artrn_to_update.str1 = artrn.docnum;
                                db.SaveChanges();
                            }
                        }
                        conn.Close();

                        /* Stcrd */
                        foreach (stcrd stcrd in artrn.stcrd)
                        {
                            cmd.CommandText = "Insert into stcrd (";
                            cmd.CommandText += string.Join(", ", stcrd.GetType().GetProperties().Where(s => s.Name.ToLower() != "id" && s.Name.ToLower() != "artrn" && s.Name.ToLower() != "artrn_id").ToList().Select(s => s.Name));
                            cmd.CommandText += ") Values(";
                            cmd.CommandText += string.Join(", ", stcrd.GetType().GetProperties().Where(s => s.Name.ToLower() != "id" && s.Name.ToLower() != "artrn" && s.Name.ToLower() != "artrn_id").ToList().Select(s => s.PropertyType == typeof(DateTime?) && s.GetValue(stcrd, null) == null ? "{}" : "?"));
                            cmd.CommandText += ")";

                            cmd.Parameters.Clear();
                            stcrd.GetType().GetProperties().Where(s => s.Name.ToLower() != "id" && s.Name.ToLower() != "artrn" && s.Name.ToLower() != "artrn_id").ToList().ForEach(s =>
                            {
                                if (!(s.PropertyType == typeof(System.DateTime?) && s.GetValue(stcrd, null) == null))
                                {
                                    cmd.Parameters.AddWithValue("@" + s.Name, s.GetValue(stcrd, null));
                                }
                            });

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        /* Arrcpcq */
                        foreach (arrcpcq arrcpcq in artrn.arrcpcq)
                        {
                            cmd.CommandText = "Insert into arrcpcq (rcpnum, chqnum, rcvamt, userid, chgdat) Values(?, ?, ?, ?, ?)";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@rcpnum", arrcpcq.rcpnum);
                            cmd.Parameters.AddWithValue("@chqnum", arrcpcq.chqnum);
                            cmd.Parameters.AddWithValue("@rcvamt", arrcpcq.rcvamt);
                            cmd.Parameters.AddWithValue("@userid", arrcpcq.userid);
                            cmd.Parameters.AddWithValue("@chgdat", arrcpcq.chgdat);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

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

        private DbfInsertResult InsertInvoiceGroup(SccompDbf working_express_db, IEnumerable<artrn> artrns /* artrn grouping by date and cuscod */)
        {
            DbfInsertResult result = new DbfInsertResult { success = false, err_message = string.Empty, inserted_docnum = string.Empty };

            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.main_form.working_express_db.abs_path))
                {
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string last_docnum = string.Empty;
                        string prefix = artrns.First().docnum.Substring(0, 2);

                        cmd.CommandText = "Select docnum From artrn Where SUBSTR(docnum,1,2) = ?  Order By docnum DESC TOP 1";
                        cmd.Parameters.AddWithValue("@prefix", prefix);

                        conn.Open();
                        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            last_docnum = dt.Rows.Count > 0 ? dt.Rows[0].Field<string>("docnum") : last_docnum;
                        }
                        conn.Close();

                        var docnum = prefix + Helper.CalNextDocnum(last_docnum);
                        result.inserted_docnum = docnum;

                        /* Artrn */
                        var dummy_artrn = artrns.First();
                        dummy_artrn.amount = artrns.Sum(a => a.amount);
                        dummy_artrn.total = artrns.Sum(a => a.total);
                        dummy_artrn.netamt = artrns.Sum(a => a.netamt);
                        dummy_artrn.netval = artrns.Sum(a => a.netval);
                        dummy_artrn.vatamt = artrns.Sum(a => a.vatamt);
                        dummy_artrn.cshrcv = artrns.Sum(a => a.cshrcv);
                        dummy_artrn.chqrcv = artrns.Sum(a => a.chqrcv);
                        int nxtseq = 0;
                        artrns.ToList().ForEach(a => { nxtseq += a.stcrd.Count; });
                        dummy_artrn.nxtseq = nxtseq.FillSpaceBeforeNum(3);

                        cmd.CommandText = "Insert into artrn (";
                        cmd.CommandText += string.Join(",", dummy_artrn.GetType().GetProperties().ToList().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").Select(p => p.Name));
                        cmd.CommandText += ") Values(";
                        cmd.CommandText += string.Join(",", dummy_artrn.GetType().GetProperties().ToList().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").Select(p => p.PropertyType == typeof(DateTime?) && p.GetValue(dummy_artrn, null) == null ? "{}" : "?"));
                        cmd.CommandText += ")";
                        cmd.Parameters.Clear();

                        dummy_artrn.GetType().GetProperties().Where(p => p.Name.ToLower() != "id" && p.Name.ToLower() != "arrcpcq" && p.Name.ToLower() != "stcrd").ToList().ForEach(p =>
                        {
                            if (!(p.PropertyType == typeof(System.DateTime?) && p.GetValue(dummy_artrn, null) == null))
                            {
                                if (p.Name.ToLower() == "docnum")
                                {
                                    cmd.Parameters.AddWithValue("@" + p.Name, docnum);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@" + p.Name, p.GetValue(dummy_artrn, null));
                                }
                            }
                        });

                        conn.Open();
                        if(cmd.ExecuteNonQuery() > 0)
                        {
                            using (xpumpEntities db = DBX.DataSet(working_express_db))
                            {
                                db.artrn.ToList().Where(a => artrns.Select(ar => ar.id).ToList<int>().Contains(a.id)).ToList().ForEach(a => Console.WriteLine(" ==> artrn.id : " + a.id));
                                //artrns.Select(a => a.id).ToList().ForEach(a => Console.WriteLine(" ==> artrns.id : " + a));
                                //Console.WriteLine(" ****************************** ");
                                artrns.Select(a => a.id).ToList().ForEach(a =>
                                {
                                    var artrn_to_update = db.artrn.Find(a);
                                    if(artrn_to_update != null)
                                    {
                                        artrn_to_update.str1 = result.inserted_docnum;
                                        db.SaveChanges();
                                    }
                                });
                            }
                        }
                        conn.Close();

                        int seq = 0;
                        artrns.ToList().ForEach(a =>
                        {
                            /* Stcrd */
                            a.stcrd.OrderBy(st => st.docnum).ThenBy(st => st.id).ToList().ForEach(st =>
                            {
                                st.seqnum = (++seq).FillSpaceBeforeNum(3);

                                cmd.CommandText = "Insert into stcrd (";
                                cmd.CommandText += string.Join(", ", st.GetType().GetProperties().Where(s => s.Name.ToLower() != "id" && s.Name.ToLower() != "artrn" && s.Name.ToLower() != "artrn_id").ToList().Select(s => s.Name));
                                cmd.CommandText += ") Values(";
                                cmd.CommandText += string.Join(", ", st.GetType().GetProperties().Where(s => s.Name.ToLower() != "id" && s.Name.ToLower() != "artrn" && s.Name.ToLower() != "artrn_id").ToList().Select(s => s.PropertyType == typeof(DateTime?) && s.GetValue(st, null) == null ? "{}" : "?"));
                                cmd.CommandText += ")";

                                cmd.Parameters.Clear();
                                st.GetType().GetProperties().Where(s => s.Name.ToLower() != "id" && s.Name.ToLower() != "artrn" && s.Name.ToLower() != "artrn_id").ToList().ForEach(s =>
                                {
                                    if (!(s.PropertyType == typeof(System.DateTime?) && s.GetValue(st, null) == null))
                                    {
                                        if(s.Name.ToLower() == "docnum")
                                        {
                                            cmd.Parameters.AddWithValue("@" + s.Name, docnum);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@" + s.Name, s.GetValue(st, null));
                                        }
                                    }
                                });

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            });
                        });

                        /* Arrcpcq */
                        artrns.ToList().ForEach(a =>
                        {
                            a.arrcpcq.OrderBy(q => q.id).ToList().ForEach(q =>
                            {
                                cmd.CommandText = "Insert into arrcpcq (rcpnum, chqnum, rcvamt, userid, chgdat) Values(?, ?, ?, ?, ?)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@rcpnum", docnum);
                                cmd.Parameters.AddWithValue("@chqnum", q.chqnum);
                                cmd.Parameters.AddWithValue("@rcvamt", q.rcvamt);
                                cmd.Parameters.AddWithValue("@userid", q.userid);
                                cmd.Parameters.AddWithValue("@chgdat", q.chgdat);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            });
                        });

                        result.success = true;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.err_message = ex.Message;
                return result;
            }
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

    public class DbfInsertResult
    {
        public bool success { get; set; }
        public string err_message { get; set; }
        public string inserted_docnum { get; set; }
    }
}
