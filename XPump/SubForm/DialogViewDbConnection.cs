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
using MySql.Data.MySqlClient;

namespace XPump.SubForm
{
    public partial class DialogViewDbConnection : Form
    {
        public List<string> db_name_list;

        public DialogViewDbConnection()
        {
            InitializeComponent();
        }

        private void DialogViewDbConnection_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtServerName;
        }

        private void btnDefaultPort_Click(object sender, EventArgs e)
        {
            this.numPort.Value = 3306;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string conn_str = "SERVER=" + this.txtServerName.Text.Trim() + ";Port=" + this.numPort.Value.ToString() + ";UID='" + this.txtUserId.Text.Trim() + "';" + "PASSWORD='" + this.txtPassword.Text.Trim() + "';";
            MySqlConnection conn = new MySqlConnection(conn_str);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Show Databases";

            this.db_name_list = new List<string>();

            try
            {
                conn.Open();
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        this.db_name_list.Add(rdr.GetValue(0).ToString());
                    }
                }
                conn.Close();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
