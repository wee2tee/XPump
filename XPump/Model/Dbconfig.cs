using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace XPump.Model
{
    public class LocalDB
    {
        private SQLiteConnection connection;
        private string local_db_file_name = "local.dbx";

        public LocalDB()
        {
            if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name))
            {
                SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name);
            }

            this.connection = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name + ";Version=3");

        }

        public LocalConfig LocalConfig
        {
            get
            {
                if (!this.IsTableExists("config"))
                {
                    this.connection.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS config (id INTEGER PRIMARY KEY AUTOINCREMENT, servername VARCHAR(254) NOT NULL, uid VARCHAR(50) NOT NULL, passwordhash VARCHAR(254) NOT NULL)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, this.connection);
                    cmd.ExecuteNonQuery();

                    sql = "INSERT INTO config (servername, uid, passwordhash) VALUES('', '', '')";
                    cmd = new SQLiteCommand(sql, this.connection);
                    cmd.ExecuteNonQuery();

                    this.connection.Close();
                }

                this.connection.Open();
                string sql_select = "SELECT * from config WHERE id = 1";
                SQLiteCommand cmd_select = new SQLiteCommand(sql_select, this.connection);
                SQLiteDataReader reader = cmd_select.ExecuteReader();
                LocalConfig config = null;
                while (reader.Read())
                {
                    config = new Model.LocalConfig
                    {
                        id = Convert.ToInt32(reader["id"]),
                        servername = reader["servername"].ToString(),
                        uid = reader["uid"].ToString(),
                        passwordhash = reader["passwordhash"].ToString()
                    };
                }
                this.connection.Close();
                return config;
            }
        }

        private bool IsTableExists(string table_name)
        {
            this.connection.Open();

            bool is_table_exist = false;
            string sql_check_exist = "SELECT COUNT(*) as cnt FROM sqlite_master WHERE type='table' AND name='" + table_name + "'";
            SQLiteCommand cmd_check_exist = new SQLiteCommand(sql_check_exist, this.connection);
            SQLiteDataReader reader = cmd_check_exist.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["cnt"]) > 0)
                {
                    is_table_exist = true;
                }
            }
            this.connection.Close();

            return is_table_exist;
        }
    }

    public partial class LocalConfig
    {
        public int id { get; set; }
        public string servername { get; set; }
        public string uid { get; set; }
        public string passwordhash { get; set; }
    }

}
