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

namespace XPump.Model
{
    public class LocalDb
    {
        public SQLiteConnection connection;
        private string local_db_file_name = "XPUMP.RDB";

        //public LocalDb()
        //{
        //    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name))
        //    {
        //        SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name);
        //    }

        //    this.connection = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"Local\" + this.local_db_file_name + ";Version=3");

        //}

        public LocalDb(SccompDbf working_express_db)
        {
            if (!File.Exists(working_express_db.abs_path + @"\" + this.local_db_file_name))
            {
                SQLiteConnection.CreateFile(working_express_db.abs_path + @"\" + this.local_db_file_name);
            }

            this.connection = new SQLiteConnection("Data Source=" + working_express_db.abs_path + @"\" + this.local_db_file_name + ";Version=3");
        }

        public LocalConfig LocalConfig
        {
            get
            {
                if (!this.IsTableExists("config"))
                {
                    this.connection.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS config (id INTEGER PRIMARY KEY AUTOINCREMENT, servername VARCHAR(254) NOT NULL, dbname VARCHAR(50) NOT NULL, port INTEGER(9) NOT NULL, uid VARCHAR(50) NOT NULL, passwordhash VARCHAR(254) NOT NULL)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, this.connection);
                    cmd.ExecuteNonQuery();

                    sql = "INSERT INTO config (servername, dbname, port, uid, passwordhash) VALUES('', '', 3306, '', '')";
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
                        dbname = reader["dbname"].ToString(),
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

    public partial class LocalConfig
    {
        public int id { get; set; }
        public string servername { get; set; }
        public string dbname { get; set; }
        public int port { get; set; }
        public string uid { get; set; }
        public string passwordhash { get; set; }
    }

    public static class LocalDbHelper
    {
        public static bool Save(this LocalConfig local_config, SccompDbf working_express_db)
        {
            try
            {
                LocalDb db = new LocalDb(working_express_db);
                db.connection.Open();
                string sql = "UPDATE config SET servername='" + local_config.servername + "', dbname='" + local_config.dbname + "', port=" + local_config.port.ToString() + ", uid='" + local_config.uid + "', passwordhash='" + local_config.passwordhash + "' WHERE id = 1";
                SQLiteCommand cmd = new SQLiteCommand(sql, db.connection);
                cmd.ExecuteNonQuery();
                db.connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static MySqlConnectionResult TestMysqlConnection(this LocalConfig local_config)
        {
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };

            //bool isConn = false;
            var conn_info = "Server=" + local_config.servername + ";Port=" + local_config.port.ToString() + ";Database=" + local_config.dbname + ";Uid=" + local_config.uid + ";Pwd=" + local_config.passwordhash.Decrypted();

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(conn_info);
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
            //catch (MySqlException ex)
            //{
            //    /*string sqlErrorMessage = "Message: " + ex.Message + "\n" +
            //    "Source: " + ex.Source + "\n" +
            //    "Number: " + ex.Number;
            //    Console.WriteLine(sqlErrorMessage);
            //    */
            //    isConn = false;
            //    switch (ex.Number)
            //    {
            //        //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
            //        case 1042: // Unable to connect to any of the specified MySQL hosts (Check Server,Port)
            //            break;
            //        case 0: // Access denied (Check DB name,username,password)
            //            break;
            //        default:
            //            break;
            //    }
            //}
            catch(MySqlException ex)
            {
                conn_result.is_connected = false;
                if (ex.Message.ToLower().Contains("unable to connect to any of the specified mysql hosts"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.HOST_NOT_FOUND;
                    conn_result.err_message = "ไม่สามารถเชื่อมต่อไปยังเซิร์ฟเวอร์ \"" + local_config.servername + "\", กรุณาตรวจสอบการกำหนดค่าการเชื่อมต่อฐานข้อมูล MySQL อีกครั้ง";
                }
                else if (ex.Message.ToLower().Contains("unknown database"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.UNKNOW_DATABASE;
                    conn_result.err_message = "ไม่พบฐานข้อมูลชื่อ \"" + local_config.dbname + "\"";
                }
                else if (ex.Message.ToLower().Contains("access denied"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.ACCESS_DENIED;
                    conn_result.err_message = "รหัสผู้ใช้/รหัสผ่านที่ระบุไว้ ไม่สามารถใช้งานฐานข้อมูล \"" + local_config.dbname + "\" ได้, กรุณาตรวจสอบการกำหนดค่าการเชื่อมต่อฐานข้อมูล MySQL อีกครั้ง";
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
                }
            }
            return conn_result;
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
}
