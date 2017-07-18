using CC;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XPump.Misc;
using XPump.Model;

namespace XPump.Model
{
    public class LocalSecureDbConfig
    {
        public SQLiteConnection connection;
        private string securedbconfig_file_name = "LOCAL.RDB";

        public LocalSecureDbConfig()
        {
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Local"))
            {
                try
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Local");
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                    return;
                }
            }

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Local\" + this.securedbconfig_file_name))
            {
                SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory + @"\Local\" + this.securedbconfig_file_name);
            }

            this.connection = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\Local\" + this.securedbconfig_file_name + ";Version=3");
        }

        public SecureDbConnectionConfig ConfigValue
        {
            get
            {
                if (!this.IsTableExists("config"))
                {
                    this.connection.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS config (id INTEGER PRIMARY KEY AUTOINCREMENT, servername VARCHAR(254) NOT NULL, port INTEGER(9) NOT NULL, uid VARCHAR(50) NOT NULL, passwordhash VARCHAR(254) NOT NULL, db_prefix VARCHAR(30) NOT NULL)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, this.connection);
                    cmd.ExecuteNonQuery();

                    sql = "INSERT INTO config (servername, port, uid, passwordhash, db_prefix) VALUES('', 3306, '', '', '')";
                    cmd = new SQLiteCommand(sql, this.connection);
                    cmd.ExecuteNonQuery();

                    this.connection.Close();
                }

                this.connection.Open();
                string sql_select = "SELECT * from config WHERE id = 1";
                SQLiteCommand cmd_select = new SQLiteCommand(sql_select, this.connection);
                SQLiteDataReader reader = cmd_select.ExecuteReader();
                SecureDbConnectionConfig config = null;
                while (reader.Read())
                {
                    config = new Model.SecureDbConnectionConfig
                    {
                        id = Convert.ToInt32(reader["id"]),
                        servername = reader["servername"].ToString(),
                        port = Convert.ToInt32(reader["port"]),
                        uid = reader["uid"].ToString(),
                        passwordhash = reader["passwordhash"].ToString(),
                        db_prefix = reader["db_prefix"].ToString()
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

    public partial class SecureDbConnectionConfig
    {
        public int id { get; set; }
        public string servername { get; set; }
        public int port { get; set; }
        public string uid { get; set; }
        public string passwordhash { get; set; }
        public string db_prefix { get; set; }
    }

    public static class SecureDbHelper
    {
        public static MySqlConnection GetSecureDbConnection(this SecureDbConnectionConfig config)
        {
            MySqlConnection conn = new MySqlConnection("Server=" + config.servername + ";Port=" + config.port.ToString() + ";Database=" + config.db_prefix + "_xpumpsecure;Uid=" + config.uid + ";Pwd=" + config.passwordhash.Decrypted() + ";Character Set=utf8");
            return conn;
        }

        public static MySqlConnectionResult TestMysqlConnection(this SecureDbConnectionConfig config)
        {
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };

            MySqlConnection conn = new MySqlConnection("Server=" + config.servername + ";Port=" + config.port.ToString() + ";Uid=" + config.uid + ";Pwd=" + config.passwordhash.Decrypted());
            try
            {
                conn.Open();
                conn_result.is_connected = true;
                conn_result.connection_code = MYSQL_CONNECTION.CONNECTED;
            }
            catch (MySqlException ex)
            {
                conn_result.is_connected = false;
                if (ex.Message.ToLower().Contains("unable to connect to any of the specified mysql hosts"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.HOST_NOT_FOUND;
                    conn_result.err_message = "ไม่สามารถเชื่อมต่อไปยังเซิร์ฟเวอร์ \"" + config.servername + "\", กรุณาตรวจสอบการกำหนดค่าการเชื่อมต่อฐานข้อมูล MySQL อีกครั้ง";
                }
                else if(ex.Message.ToLower().Contains("access denied for user"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.ACCESS_DENIED;
                    conn_result.err_message = "รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้อง";
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

        public static MySqlConnectionResult TestMysqlSecureDbExist(this SecureDbConnectionConfig config)
        {
            MySqlConnectionResult conn_result = new MySqlConnectionResult { is_connected = false, err_message = string.Empty, connection_code = MYSQL_CONNECTION.DISCONNECTED };

            MySqlConnection conn = config.GetSecureDbConnection();
            try
            {
                conn.Open();
                conn_result.is_connected = true;
                conn_result.connection_code = MYSQL_CONNECTION.CONNECTED;
            }
            catch (MySqlException ex)
            {
                conn_result.is_connected = false;
                if (ex.Message.ToLower().Contains("unable to connect to any of the specified mysql hosts"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.HOST_NOT_FOUND;
                    conn_result.err_message = "ไม่สามารถเชื่อมต่อไปยังเซิร์ฟเวอร์ \"" + config.servername + "\", กรุณาตรวจสอบการกำหนดค่าการเชื่อมต่อฐานข้อมูล MySQL อีกครั้ง";
                }
                else if (ex.Message.ToLower().Contains("access denied for user"))
                {
                    conn_result.connection_code = MYSQL_CONNECTION.ACCESS_DENIED;
                    conn_result.err_message = "รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้อง";
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

        public static bool Save(this SecureDbConnectionConfig config)
        {
            try
            {
                LocalSecureDbConfig db = new LocalSecureDbConfig();
                db.connection.Open();
                string sql = "UPDATE config SET servername='" + config.servername + "', port=" + config.port.ToString() + ", uid='" + config.uid + "', passwordhash='" + config.passwordhash + "'" + ", db_prefix='" + config.db_prefix + "' WHERE id = 1";
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

        public static string GetDbPrefix()
        {
            var local_secure_config = new LocalSecureDbConfig().ConfigValue;

            if (local_secure_config.db_prefix.Trim().Length > 0)
            {
                return local_secure_config.db_prefix;
            }
            else
            {
                string serial_file_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\Serial.TXT";
                if (File.Exists(serial_file_path))
                {
                    var lines = File.ReadLines(serial_file_path);
                    return lines.First().Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
