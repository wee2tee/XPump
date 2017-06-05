using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using XPump.Misc;
using XPump.Model;
using MySql.Data.MySqlClient;

namespace XPump.SubForm
{
    public partial class DialogRestoreData : Form
    {
        private MainForm main_form;
        private string backup_file_path;
        private DbConnectionConfig config;

        public DialogRestoreData(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DialogRestoreData_Load(object sender, EventArgs e)
        {
            config = new LocalDbConfig(this.main_form.working_express_db).ConfigValue;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "XPump backup file(*.rp)|*.rp";
            of.InitialDirectory = this.main_form.working_express_db.abs_path;
            if(of.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath._Text = of.FileName;
            }
        }

        private void txtFilePath__TextChanged(object sender, EventArgs e)
        {
            this.backup_file_path = ((XTextEdit)sender)._Text;
            this.btnOK.Enabled = this.backup_file_path.Trim().Length > 0 ? true : false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DbConnectionConfig config = new LocalDbConfig(this.main_form.working_express_db).ConfigValue;

            if (MessageBox.Show("นำข้อมูลสำรองจาก \"" + this.backup_file_path + "\" มาใช้ โดยนำมาลงที่ฐานข้อมูล \"" + config.dbname + "\", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            string conn_string = "server=" + config.servername + ";user=" + config.uid + ";pwd=" + config.passwordhash.Decrypted() + ";database=" + config.dbname + ";charset=utf8;";

            using (MySqlConnection conn = new MySqlConnection(conn_string))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup bck = new MySqlBackup(cmd))
                    {
                        LoadingForm loading = new LoadingForm();
                        loading.ShowCenterParent(this);
                        BackgroundWorker worker = new BackgroundWorker();

                        bool is_success = false;
                        string err_msg = string.Empty;

                        worker.DoWork += delegate
                        {
                            try
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                bck.ImportFromFile(this.backup_file_path);
                                conn.Close();
                                is_success = true;
                            }
                            catch (Exception ex)
                            {
                                err_msg = ex.Message;
                            }
                        };
                        worker.RunWorkerCompleted += delegate
                        {
                            loading.Close();
                            if (is_success)
                            {
                                MessageBox.Show("นำข้อมูลสำรองมาใช้เสร็จเรียบร้อย", "", MessageBoxButtons.OK);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };
                        worker.RunWorkerAsync();

                    }
                }
            }
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
