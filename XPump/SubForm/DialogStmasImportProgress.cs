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
    public partial class DialogStmasImportProgress : Form
    {
        private BackgroundWorker worker;
        private List<StmasDbfVM> stmas_list;

        public DialogStmasImportProgress(List<StmasDbfVM> stmas_list)
        {
            InitializeComponent();
            this.stmas_list = stmas_list;
            this.progressBar1.Maximum = this.stmas_list.Count;
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
                    using (xpumpEntities db = DBX.DataSet())
                    {
                        db.stmas.Add(new stmas
                        {
                            name = this.stmas_list[i].stkcod,
                            description = this.stmas_list[i].stkdes,
                            remark = this.stmas_list[i].remark
                        });
                        db.SaveChanges();
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

                if (we.Cancelled)
                {
                    this.btnCancel.Enabled = false;
                    this.btnOK.Text = "ปิด";
                }
                else
                {
                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อย");
                }
            };

            this.worker.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.worker.CancelAsync();
        }
    }
}
