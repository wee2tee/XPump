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
using System.Data.Entity.Infrastructure;

namespace XPump.SubForm
{
    public partial class DialogStmasImportProgress : Form
    {
        private MainForm main_form;
        private BackgroundWorker worker;
        private List<StmasDbfVM> stmas_list;
        private bool skip_duplicate_all = false;
        private bool replace_duplicate_all = false;

        public DialogStmasImportProgress(MainForm main_form, List<StmasDbfVM> stmas_list)
        {
            InitializeComponent();
            this.stmas_list = stmas_list;
            this.progressBar1.Maximum = this.stmas_list.Count;
            this.main_form = main_form;
        }

        private void DialogStmasImportProgress_Load(object sender, EventArgs e)
        {
            this.worker = new BackgroundWorker();
            this.worker.WorkerSupportsCancellation = true;
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += delegate (object obj_sender, DoWorkEventArgs we)
            {
                for (int i = 0; i < this.stmas_list.Count; i++)
                {
                    if (((BackgroundWorker)obj_sender).CancellationPending == true)
                    {
                        we.Cancel = true;
                        break;
                    }

                    worker.ReportProgress(i + 1);
                    using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                    {
                        try
                        {
                            string stkcod = this.stmas_list[i].stkcod;
                            if (db.stmas.Where(s => s.name == stkcod).Count() > 0)
                            {
                                this.DuplicateAlert(this.stmas_list[i]);
                                continue;
                            }

                            db.stmas.Add(new stmas
                            {
                                name = this.stmas_list[i].stkcod,
                                description = this.stmas_list[i].stkdes,
                                remark = this.stmas_list[i].remark
                            });
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            if (ex is DbUpdateException)
                            {
                                string message = string.Empty; ;

                                // adding a duplicate unique value
                                if (ex.InnerException.InnerException.Message.ToLower().Contains("duplicate entry"))
                                {
                                    this.DuplicateAlert(this.stmas_list[i]);
                                    continue;
                                }
                            }
                        }
                    }
                }
            };

            this.worker.ProgressChanged += delegate (object obj_sender, ProgressChangedEventArgs we)
            {
                this.lblCount.Text = we.ProgressPercentage.ToString() + "/" + this.stmas_list.Count;
                this.lblStkcod.Text = this.stmas_list[we.ProgressPercentage - 1].stkcod;
                this.progressBar1.Value = we.ProgressPercentage;
            };

            this.worker.RunWorkerCompleted += delegate (object obj_sender, RunWorkerCompletedEventArgs we)
            {
                this.btnOK.Enabled = true;
                this.btnCancel.Enabled = false;

                if (we.Cancelled)
                {
                    this.btnOK.Text = "ปิด";
                }
                else
                {
                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อย");
                }
            };

            if (!this.worker.IsBusy)
            {
                this.btnCancel.Enabled = true;
                this.worker.RunWorkerAsync();
            }
        }

        private void DuplicateAlert(StmasDbfVM stmasdbfvm)
        {
            if (this.skip_duplicate_all == false && this.replace_duplicate_all == false)
            {
                DialogImportStmasConfirmReplace conf = new DialogImportStmasConfirmReplace(this.main_form, "รหัสสินค้า \"" + stmasdbfvm.stkcod + "\" นี้มีอยู่แล้ว ท่านต้องการให้โปรแกรมทำอย่างไร?");

                if (conf.ShowDialog() == DialogResult.OK)
                {
                    if (conf.confirm_result == DialogImportStmasConfirmReplace.CONFIRM_RESULT.SKIP_ONE)
                    {
                        return;
                    }
                    if (conf.confirm_result == DialogImportStmasConfirmReplace.CONFIRM_RESULT.SKIP_ALL)
                    {
                        this.skip_duplicate_all = true;
                        return;
                    }
                    if (conf.confirm_result == DialogImportStmasConfirmReplace.CONFIRM_RESULT.REPLACE_ONE)
                    {
                        // replace existing data with new one
                        this.UpdateExistingStmas(stmasdbfvm);
                        return;
                    }
                    if (conf.confirm_result == DialogImportStmasConfirmReplace.CONFIRM_RESULT.REPLACE_ALL)
                    {
                        this.replace_duplicate_all = true;
                        // replace existing data with new one
                        this.UpdateExistingStmas(stmasdbfvm);
                        return;
                    }
                }
            }
            else if (this.skip_duplicate_all)
            {
                return;
            }
            else if (this.replace_duplicate_all)
            {
                // replace existing data with new one
                this.UpdateExistingStmas(stmasdbfvm);
                return;
            }
        }

        private void UpdateExistingStmas(StmasDbfVM stmasdbfvm)
        {
            using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
            {
                stmas stmas_to_update = db.stmas.Where(s => s.name == stmasdbfvm.stkcod).FirstOrDefault();

                if (stmas_to_update == null)
                    return;

                stmas_to_update.description = stmasdbfvm.stkdes;
                stmas_to_update.remark = stmasdbfvm.remark;

                db.SaveChanges();
            }
        }

        //private Point CalCenterOfThisForm()
        //{
        //    Point p = this.PointToScreen(Point.Empty);
        //    return new Point(p.X + (int)Math.Floor((float)this.Width / 2), p.Y + (int)Math.Floor((float)this.Height / 2));
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.worker.CancelAsync();
        }
    }
}
