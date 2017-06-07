﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC;
using MySql.Data.MySqlClient;
using XPump.Model;
using XPump.Misc;

namespace XPump.SubForm
{
    public partial class DialogBackupData : Form
    {
        private string backup_path = string.Empty;
        private string backup_file_name = string.Empty;
        private MainForm main_form;

        public DialogBackupData(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string user_folder_path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                user_folder_path = Directory.GetParent(user_folder_path).ToString();
            }

            FolderBrowserDialog fold = new FolderBrowserDialog();
            fold.SelectedPath = user_folder_path;
            if(fold.ShowDialog() == DialogResult.OK)
            {
                this.txtTargetFolder._Text = fold.SelectedPath;
            }
        }

        private void txtTargetFolder__TextChanged(object sender, EventArgs e)
        {
            this.backup_path = ((XTextEdit)sender)._Text;
            this.ResetBtnOKState();
        }

        private void txtTargetFile__TextChanged(object sender, EventArgs e)
        {
            this.backup_file_name = ((XTextEdit)sender)._Text;
            this.ResetBtnOKState();
        }

        private void ResetBtnOKState()
        {
            if(this.backup_path.Trim().Length == 0 || this.backup_file_name.Trim().Length == 0)
            {
                this.btnOK.Enabled = false;
            }
            else
            {
                this.btnOK.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.backup_file_name = this.backup_file_name.EndsWith(".rp") ? this.backup_file_name : this.backup_file_name + ".rp";

            if(XMessageBox.Show("สำรองข้อมูลไปไว้ที่ \"" + this.backup_path + "\\" + this.backup_file_name + "\", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) == DialogResult.OK)
            {
                if(File.Exists(this.backup_path + "\\" + this.backup_file_name))
                {
                    if (XMessageBox.Show("แฟ้ม \"" + this.backup_path + "\\" + this.backup_file_name + "\" มีอยู่แล้ว, ต้องการแทนที่ด้วยแฟ้มใหม่นี้ใช่หรือไม่?", "", MessageBoxButtons.OKCancel, XMessageBoxIcon.Question) != DialogResult.OK)
                        return;
                }

                DbConnectionConfig config = new LocalDbConfig(this.main_form.working_express_db).ConfigValue;

                string conn_string = "server=" + config.servername + ";user=" + config.uid + ";pwd=" + config.passwordhash.Decrypted() + ";database=" + config.dbname + ";charset=utf8;";
                using (MySqlConnection conn = new MySqlConnection(conn_string))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        BackgroundWorker worker = new BackgroundWorker();
                        LoadingForm loading = new LoadingForm();
                        loading.ShowCenterParent(this);

                        bool is_success = false;
                        string err_msg = string.Empty;

                        worker.DoWork += delegate
                        {
                            try
                            {
                                cmd.Connection = conn;
                                conn.Open();
                                MySqlBackup bck = new MySqlBackup(cmd);
                                bck.ExportToFile(this.backup_path + "\\" + this.backup_file_name);
                                conn.Close();
                                bck.Dispose();
                                bck = null;
                                is_success = true;
                                this.main_form.islog.BackupData(config.dbname, this.backup_path + "\\" + this.backup_file_name).Save();
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
                                this.DialogResult = DialogResult.OK;
                                XMessageBox.Show("สำรองข้อมูลเสร็จเรียบร้อย", "", MessageBoxButtons.OK);
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
