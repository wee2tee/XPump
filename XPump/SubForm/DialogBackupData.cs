using System;
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

namespace XPump.SubForm
{
    public partial class DialogBackupData : Form
    {
        private string selected_path;
        private string file_name;

        public DialogBackupData()
        {
            InitializeComponent();
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
            this.selected_path = ((XTextEdit)sender)._Text;
        }

        private void txtTargetFile__TextChanged(object sender, EventArgs e)
        {
            this.file_name = ((XTextEdit)sender)._Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.file_name = this.file_name.EndsWith(".rp") ? this.file_name : this.file_name + ".rp";

            if(MessageBox.Show("สำรองข้อมูลไปไว้ที่ \"" + this.selected_path + "\\" + this.file_name + "\", ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection())
                {

                }
            }
        }
    }
}
