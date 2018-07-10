using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using XPump.Misc;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel;
using CC;
using System.Globalization;

namespace XPump.Model
{
    public class LocalDbConfig
    {
        public SQLiteConnection connection;
        private string dbconfig_file_name = "XPUMP.RDB";
        private SccompDbf working_express_db;

        //public LocalDb()
        //{
        //    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name))
        //    {
        //        SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name);
        //    }

        //    this.connection = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name + ";Version=3");

        //}

        public LocalDbConfig(SccompDbf working_express_db)
        {
            this.working_express_db = working_express_db;

            if (!File.Exists(working_express_db.abs_path + @"\" + this.dbconfig_file_name))
            {
                SQLiteConnection.CreateFile(working_express_db.abs_path + @"\" + this.dbconfig_file_name);
            }

            this.connection = new SQLiteConnection("Data Source=" + working_express_db.abs_path + @"\" + this.dbconfig_file_name + ";Version=3");
        }

        private void CreateFirstRow()
        {
            this.connection.Open();
            //string sql = "CREATE TABLE IF NOT EXISTS config (id INTEGER PRIMARY KEY AUTOINCREMENT, servername VARCHAR(254) NOT NULL, db_prefix VARCHAR(30) NOT NULL, dbname VARCHAR(50) NOT NULL, port INTEGER(9) NOT NULL, uid VARCHAR(50) NOT NULL, passwordhash VARCHAR(254) NOT NULL)";
            string sql = "CREATE TABLE IF NOT EXISTS config (id INTEGER PRIMARY KEY AUTOINCREMENT, branch VARCHAR(254) NOT NULL, servername VARCHAR(254) NOT NULL, db_prefix VARCHAR(30) NOT NULL, dbname VARCHAR(50) NOT NULL, depcod VARCHAR(10) NOT NULL, port INTEGER(9) NOT NULL, uid VARCHAR(50) NOT NULL, passwordhash VARCHAR(254) NOT NULL)";
            SQLiteCommand cmd = new SQLiteCommand(sql, this.connection);
            cmd.ExecuteNonQuery();

            //sql = "INSERT INTO config (servername, db_prefix, dbname, port, uid, passwordhash) VALUES('', '', '', '', 3306, '', '')";
            sql = "INSERT INTO config (branch, servername, db_prefix, dbname, depcod, port, uid, passwordhash) VALUES('" + this.working_express_db.compnam.Trim() + "', '', '', '', '', 3306, '', '')";
            cmd = new SQLiteCommand(sql, this.connection);
            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public List<DbConnectionConfig> BranchList
        {
            get
            {
                if (!this.IsTableExists("config"))
                {
                    this.CreateFirstRow();
                }

                this.connection.Open();
                string sql_select = "SELECT * from config";
                SQLiteCommand cmd_select = new SQLiteCommand(sql_select, this.connection);
                SQLiteDataReader reader = cmd_select.ExecuteReader();
                List<DbConnectionConfig> configs = new List<DbConnectionConfig>();
                while (reader.Read())
                {
                    configs.Add(new Model.DbConnectionConfig
                    {
                        id = Convert.ToInt32(reader["id"]),
                        branch = reader["branch"].ToString(),
                        servername = reader["servername"].ToString(),
                        db_prefix = reader["db_prefix"].ToString(),
                        dbname = reader["dbname"].ToString(),
                        depcod = reader["depcod"].ToString(),
                        port = Convert.ToInt32(reader["port"]),
                        uid = reader["uid"].ToString(),
                        passwordhash = reader["passwordhash"].ToString()
                    });
                }
                this.connection.Close();
                return configs;
            }
        }

        public DbConnectionConfig ConfigValue
        {
            get
            {
                if (!this.IsTableExists("config"))
                {
                    //this.connection.Open();
                    //string sql = "CREATE TABLE IF NOT EXISTS config (id INTEGER PRIMARY KEY AUTOINCREMENT, branch VARCHAR(254) NOT NULL, servername VARCHAR(254) NOT NULL, db_prefix VARCHAR(30) NOT NULL, dbname VARCHAR(50) NOT NULL, depcod VARCHAR(10) NOT NULL, port INTEGER(9) NOT NULL, uid VARCHAR(50) NOT NULL, passwordhash VARCHAR(254) NOT NULL)";
                    //SQLiteCommand cmd = new SQLiteCommand(sql, this.connection);
                    //cmd.ExecuteNonQuery();

                    //sql = "INSERT INTO config (branch, servername, db_prefix, dbname, depcod, port, uid, passwordhash) VALUES('', '', '', '', '', 3306, '', '')";
                    //cmd = new SQLiteCommand(sql, this.connection);
                    //cmd.ExecuteNonQuery();

                    //this.connection.Close();
                    this.CreateFirstRow();
                }

                this.connection.Open();
                string sql_select = "SELECT * from config WHERE id = 1";
                SQLiteCommand cmd_select = new SQLiteCommand(sql_select, this.connection);
                SQLiteDataReader reader = cmd_select.ExecuteReader();
                DbConnectionConfig config = null;
                while (reader.Read())
                {
                    config = new Model.DbConnectionConfig
                    {
                        id = Convert.ToInt32(reader["id"]),
                        branch = reader["branch"].ToString(),
                        servername = reader["servername"].ToString(),
                        db_prefix = reader["db_prefix"].ToString(),
                        dbname = reader["dbname"].ToString(),
                        depcod = reader["depcod"].ToString(),
                        port = Convert.ToInt32(reader["port"]),
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

    public partial class DbConnectionConfig
    {
        public int id { get; set; }
        public string branch { get; set; }
        public string servername { get; set; }
        public string db_prefix { get; set; }
        public string dbname { get; set; }
        public string depcod { get; set; }
        public int port { get; set; }
        public string uid { get; set; }
        public string passwordhash { get; set; }
    }

    public static class LocalDbHelper
    {
        /** SQLite **/

        public static bool Save(this DbConnectionConfig local_config, SccompDbf working_express_db)
        {
            try
            {
                LocalDbConfig db = new LocalDbConfig(working_express_db);
                db.connection.Open();
                string sql = "UPDATE config SET servername='" + local_config.servername + "', db_prefix='" + local_config.db_prefix + "', dbname='" + local_config.dbname + "', port=" + local_config.port.ToString() + ", uid='" + local_config.uid + "', passwordhash='" + local_config.passwordhash + "' WHERE id = 1";
                SQLiteCommand cmd = new SQLiteCommand(sql, db.connection);
                cmd.ExecuteNonQuery();
                db.connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return false;
            }
        }

        /** MySQL **/

        public static MySqlConnection GetMysqlDbConnection(this DbConnectionConfig local_config)
        {
            var conn_info = "Server=" + local_config.servername + ";Port=" + local_config.port.ToString() + ";Database=" + local_config.db_prefix + "_" + local_config.dbname + ";Uid=" + local_config.uid + ";Pwd=" + local_config.passwordhash.Decrypted() + ";Character Set=utf8";
            return new MySqlConnection(conn_info);
        }

        public static MySqlConnectionResult TestMysqlDbConnection(this DbConnectionConfig local_config, MainForm main_form)
        {
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };

            MySqlConnection conn = null;
            try
            {
                conn = local_config.GetMysqlDbConnection();
                conn.Open();
                conn_result.is_connected = true;
                conn_result.connection_code = MYSQL_CONNECTION.CONNECTED;
            }
            //catch (ArgumentException a_ex)
            //{
            //    /*
            //    Console.WriteLine("Check the Connection String.");
            //    Console.WriteLine(a_ex.Message);
            //    Console.WriteLine(a_ex.ToString());
            //    */
            //}
           
            catch(MySqlException ex)
            {
                conn_result.is_connected = false;
                if (ex.Message.ToLower().Contains("unable to connect to any of the specified mysql hosts"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.HOST_NOT_FOUND;
                    conn_result.err_message = string.Format(main_form.GetMessage("0003"), local_config.servername);
                }
                else if (ex.Message.ToLower().Contains("unknown database"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.UNKNOW_DATABASE;
                    conn_result.err_message = string.Format(main_form.GetMessage("0005"), local_config.dbname);
                }
                else if (ex.Message.ToLower().Contains("access denied"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.ACCESS_DENIED;
                    conn_result.err_message = string.Format(main_form.GetMessage("0006"), local_config.dbname);
                }
                else
                {
                    conn_result.connection_code = MYSQL_CONNECTION.DISCONNECTED;
                    conn_result.err_message = ex.Message;
                }
            }
            catch (Exception ex)
            {
                conn_result.is_connected = false;
                conn_result.err_message = ex.Message;
                conn_result.connection_code = MYSQL_CONNECTION.DISCONNECTED;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            return conn_result;
        }

        public static string GetDbPrefix(SccompDbf working_express_db)
        {
            var config = new LocalDbConfig(working_express_db).ConfigValue;
            if(config.db_prefix.Trim().Length > 0)
            {
                return config.db_prefix;
            }
            else
            {
                return SecureDbHelper.GetDbPrefix();
            }
        }
    }

    public enum MYSQL_CONNECTION
    {
        DISCONNECTED,
        CONNECTED,
        UNKNOW_DATABASE,
        HOST_NOT_FOUND,
        ACCESS_DENIED
    }

    public class MySqlConnectionResult
    {
        public bool is_connected { get; set; }
        public string err_message { get; set; }
        public MYSQL_CONNECTION connection_code { get; set; }
    }

    public class MySqlCreateResult
    {
        public bool is_success { get; set; }
        public string err_message { get; set; }
    }
}
