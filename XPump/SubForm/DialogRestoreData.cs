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
using System.IO;

namespace XPump.SubForm
{
    public partial class DialogRestoreData : Form
    {
        public const string modcod = "312";
        private MainForm main_form;
        private string backup_file_path = string.Empty;
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
            of.Filter = "XPump backup file(*.oil7)|*.oil7";
            string init_dir = string.Empty;

            if(this.backup_file_path.Trim().Length > 0 && Directory.Exists(Directory.GetParent(this.backup_file_path).FullName))
            {
                of.InitialDirectory = Directory.GetParent(this.backup_file_path).Name; //this.main_form.working_express_db.abs_path;
            }
            else
            {
                of.InitialDirectory = this.main_form.working_express_db.abs_path;
            }
            
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
            DbConnectionConfig config = this.main_form.working_express_db.db_conn_config; //new LocalDbConfig(this.main_form.working_express_db).ConfigValue;

            if (XMessageBox.Show(string.Format(this.main_form.GetMessage("0014"), this.backup_file_path, config.dbname), "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                return;

            string conn_string = "server=" + config.servername + ";port=" + config.port.ToString() + ";user=" + config.uid + ";pwd=" + config.passwordhash.Decrypted() + ";database=" + config.db_prefix + "_" + config.dbname + ";charset=utf8;";

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
                                this.main_form.islog.RestoreData(this.backup_file_path, config.dbname).Save();
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
                                XMessageBox.Show(this.main_form.GetMessage("0015"), "", MessageBoxButtons.OK);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                XMessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
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

            if (keyData == Keys.F1)
            {
                Helper.ShowHelp("page-3.1.2.html");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
