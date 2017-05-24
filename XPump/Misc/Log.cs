using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPump.Model;
using XPump.Misc;
using XPump.SubForm;
using System.IO;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace XPump.Misc
{
    public class Log
    {
        private MainForm main_form;

        public Log(MainForm main_form)
        {
            this.main_form = main_form;

            //this.LoginSuccess = new LogObject(this.main_form) { Code = "001", Template = "ล็อกอินเข้าระบบด้วยรหัสผู้ใช้ \"{0}\" สำเร็จ" };
            //this.LoginFail = new LogObject(this.main_form) { Code = "002", Template = "ล็อกอินเข้าระบบด้วยรหัสผู้ใช้ \"{0}\" ไม่สำเร็จเนื่องจาก{1}" };
            //this.Logout = new LogObject(this.main_form) { Code = "003", Template = "รหัสผู้ใช้ \"{0}\" ออกจากระบบ" };

            //this.SelectCompany = new LogObject(this.main_form) { Code = "004", Template = "เข้าใช้งานที่เก็บข้อมูล \"{0}\" [{1}]" };
            //this.ConfigMysqlDb = new LogObject(this.main_form) { Code = "005", Template = "ตั้งค่าการเชื่อมต่อฐานข้อมูล MySQL ไปยังเซิร์ฟเวอร์ \"{0}\", ฐานข้อมูลชื่อ \"{1}\"" };
            //this.CreateMysqlDb = new LogObject(this.main_form) { Code = "006", Template = "สร้างฐานข้อมูล MySQL {0}.{1} สำเร็จ" };
            //this.ConnectMysqlSuccess = new LogObject(this.main_form) { Code = "007", Template = "เชื่อมต่อฐานข้อมูล {0}.{1} สำเร็จ" };
            //this.ConnectMysqlFail = new LogObject(this.main_form) { Code = "008", Template = "ไม่สามารถเชื่อมต่อฐานข้อมูล {0}.{1} เนื่องจาก{2}" };

            ////this.OpenForm = new LogObject { Code = "", Template = "" };
            //this.AddSuccess = new LogObject(this.main_form) { Code = "009", Template = "เพิ่ม{0} {1} สำเร็จ" };
            //this.AddFail = new LogObject(this.main_form) { Code = "010", Template = "เพิ่ม{0} {1} ไม่สำเร็จ เนื่องจาก{2}" };
            //this.EditSuccess = new LogObject(this.main_form) { Code = "011", Template = "แก้ไข{0} {1} สำเร็จ" };
            //this.EditFail = new LogObject(this.main_form) { Code = "012", Template = "แก้ไข{0} {1} ไม่สำเร็จ เนื่องจาก{2}" };
            //this.DeleteSuccess = new LogObject(this.main_form) { Code = "013", Template = "ลบ{0} {1} สำเร็จ" };
            //this.DeleteFail = new LogObject(this.main_form) { Code = "014", Template = "ลบ{0} {1} ไม่สำเร็จ เนื่องจาก{2}" };

            //this.ImportData = new LogObject(this.main_form) { Code = "015", Template = "นำเข้าข้อมูลรายละเอียดสินค้าจำนวน {0} รายการเสร็จสมบูรณ์" };
            //this.ChangeCodeSuccess = new LogObject(this.main_form) { Code = "016", Template = "เปลี่ยนรหัสสินค้าจาก \"{0}\" เป็น \"{1}\" สำเร็จ" };
            //this.ChangeCodeFail = new LogObject(this.main_form) { Code = "017", Template = "เปลี่ยนรหัสสินค้าจาก \"{0}\" เป็น \"{1}\" ไม่สำเร็จ เนื่องจาก{2}" };
            //this.ApproveOk = new LogObject(this.main_form) { Code = "018", Template = "รับรองรายการ{0} สำเร็จ" };
            //this.ApproveCancel = new LogObject(this.main_form) { Code = "019", Template = "ยกเลิกการรับรองรายการ{0} สำเร็จ" };
            //this.Print = new LogObject(this.main_form) { Code = "020", Template = "พิมพ์{0} ออกทาง{1}" };
            //this.ChangeSettings = new LogObject(this.main_form) { Code = "021", Template = "แก้ไขการตั้งค่าระบบสำเร็จแล้ว" };
            //this.ChangeCompany = new LogObject(this.main_form) { Code = "022", Template = "เปลี่ยนไปใช้ข้อมูล {0}" };
        }

        public LogObject LoginSuccess(string user_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "001",
                Description = string.Format("ล็อกอินเข้าระบบด้วยรหัสผู้ใช้ \"{0}\" สำเร็จ", user_name),
            };
            return l;
        }

        public LogObject LoginFail(string user_name, string reason)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "002",
                Description = string.Format("ล็อกอินเข้าระบบด้วยรหัสผู้ใช้ \"{0}\" ไม่สำเร็จเนื่องจาก{1}", user_name, reason)
            };
            return l;
        }

        public LogObject SelectCompany(string absolute_data_path, string company_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "003",
                Description = string.Format("เข้าใช้งานที่เก็บข้อมูล \"{0}\" [{1}]", absolute_data_path.Replace("\\", "\\\\"), company_name),
            };
            return l;
        }

        public LogObject ConnectMysqlSuccess(string server_name, string db_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "004",
                Description = string.Format("เชื่อมต่อฐานข้อมูล {0}.{1} สำเร็จ", server_name, db_name)
            };
            return l;
        }

        public LogObject ConnectMysqlFail(string server_name, string db_name, string reason)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "005",
                Description = string.Format("ไม่สามารถเชื่อมต่อฐานข้อมูล {0}.{1} เนื่องจาก{2}", server_name, db_name, reason)
            };
            return l;
        }

        public LogObject ConfigMysqlConnection(string server_name, string db_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "006",
                Description = string.Format("ตั้งค่าการเชื่อมต่อฐานข้อมูล MySQL ไปยังเซิร์ฟเวอร์ \"{0}\", ฐานข้อมูลชื่อ \"{1}\" สำเร็จ", server_name, db_name)
            };
            return l;
        }

        public LogObject CreateMysqlDb(string server_name, string db_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "007",
                Description = string.Format("สร้างฐานข้อมูล MySQL {0}.{1} สำเร็จ", server_name, db_name)
            };
            return l;
        }

        public LogObject AddData(string menu_id, string added_key, string added_value, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "008",
                Description = string.Format("เพิ่ม{0} {1} สำเร็จ", added_key, added_value),
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject AddData(string menu_id, string description, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "008",
                Description = description,
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject EditData(string menu_id, string edited_key, string edited_value, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "009",
                Description = string.Format("แก้ไข{0} {1} สำเร็จ", edited_key, edited_value),
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject EditData(string menu_id, string description, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "009",
                Description = description,
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject DeleteData(string menu_id, string deleted_key, string deleted_value, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "010",
                Description = string.Format("ลบ{0} {1} สำเร็จ", deleted_key, deleted_value),
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject DeleteData(string menu_id, string description, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "010",
                Description = description,
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject Approve(string menu_id, string description, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "013",
                Description = description,
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        public LogObject UnApprove(string menu_id, string description, string docnum, string affected_table = null, int? affected_id = null)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "014",
                Description = description,
                Module = menu_id,
                Docnum = docnum,
                afftable = affected_table,
                affid = affected_id
            };
            return l;
        }

        //public LogObject Approve(string menu_id, string approved_key, string approved_val)
        //{
        //    LogObject l = new LogObject(this.main_form)
        //    {
        //        Code = "013",
        //        Description = string.Format("รับรองรายการ{0} {1}", approved_key, approved_val),
        //        Module = menu_id,
        //        Docnum = approved_val
        //    };
        //    return l;
        //}

        public LogObject ImportData(string menu_id, string imported_key, int imported_item_count)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "011",
                Description = string.Format("นำเข้าข้อมูล{0}จำนวน {1} รายการ เสร็จสมบูรณ์", imported_key, imported_item_count),
                Module = menu_id
            };
            return l;
        }

        public LogObject ChangeCode(string menu_id, string changed_key, string old_code, string new_code)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "012",
                Description = string.Format("เปลี่ยนรหัส{0} \"{1}\" เป็น \"{2}\" สำเร็จ", changed_key, old_code, new_code),
                Module = menu_id,
                Docnum = new_code
            };
            return l;
        }

        public LogObject Print(string menu_id, string printed_key, string printed_val, string print_output)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "015",
                Description = string.Format("พิมพ์{0} {1} ออกทาง{2}", printed_key, printed_val, print_output),
                Module = menu_id,
                Docnum = printed_val
            };
            return l;
        }

        public LogObject ChangeSettings()
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "016",
                Description = string.Format("เปลี่ยนแปลงการตั้งค่าระบบสำเร็จ")
            };
            return l;
        }

        public LogObject ChangeCompany(string absolute_data_path, string company_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "017",
                Description = string.Format("เปลี่ยนไปใช้ข้อมูล \"{0}\" [{1}]", absolute_data_path.Replace("\\", "\\\\"), company_name)
            };
            return l;
        }

        public LogObject Logout(string user_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "000",
                Description = string.Format("รหัสผู้ใช้ \"{0}\" ออกจากระบบ", user_name),
            };
            return l;
        }
    }

    public class LogObject
    {
        public string Code { get; set; }
        public string ExpressData
        {
            get
            {
                return this.main_form.working_express_db != null ? this.main_form.working_express_db.path : string.Empty;
            }
        }
        public string XPumpData
        {
            get
            {
                return this.main_form.GetCurrentDbName();
            }
        }
        public string XPumpUser
        {
            get
            {
                if(this.main_form.working_express_db != null)
                {
                    LocalDbConfig loc = new LocalDbConfig(this.main_form.working_express_db);
                    return loc.ConfigValue.uid;
                }
                return string.Empty;
            }
        }
        public string Docnum { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public string afftable { get; set; }
        public int? affid { get; set; }
        public string UserName
        {
            get
            {
                return this.main_form.loged_in_status != null ? this.main_form.loged_in_status.loged_in_user_name : string.Empty;
            }
        }

        private MainForm main_form { get; set; }

        public LogObject(MainForm main_form)
        {
            this.main_form = main_form;
        }

        //public LogObject SetLogDescription(params string[] log_val)
        //{
        //    this.Description = string.Format(this.Template, log_val);
        //    return this;
        //}

        public LogSaveResult Save()
        {
            MySqlConnection conn = this.main_form.secure_db_config.GetSecureDbConnection();

            try
            {
                string module = this.Module != null ? this.Module : string.Empty;
                string docnum = this.Docnum != null ? this.Docnum : string.Empty;
                
                //string data = this.main_form.working_express_db != null ? this.ExpressData : string.Empty;
                //string xpump_data = this.XPumpData != null ? this.XPumpData : string.Empty;

                string sql = "INSERT INTO `xpumpsecure`.`islog` (`logcode`, `expressdata`, `xpumpdata`, `xpumpuser`, `module`, `afftable`, `affid`, `docnum`, `description`, `username`) VALUES ('" + this.Code + "', '" + this.ExpressData + "', '" + this.XPumpData + "', '" + this.XPumpUser + "', '" + module + "', " + (this.afftable != null ? "'" + this.afftable + "'" : "NULL") + ", " + (this.affid != null ? this.affid.ToString() : "NULL") + ", '" + docnum + "', '" + this.Description + "', '" + this.UserName + "')";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return new LogSaveResult { isSuccess = true, errMessage = string.Empty };
            }
            catch (MySqlException ex)
            {
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message);
                return new LogSaveResult { isSuccess = false, errMessage = ex.Message };
            }
        }

        public LogSaveResult Save(string user_name)
        {
            MySqlConnection conn = this.main_form.secure_db_config.GetSecureDbConnection();

            try
            {
                string module = this.Module != null ? this.Module : string.Empty;
                string docnum = this.Docnum != null ? this.Docnum : string.Empty;

                //string data = this.main_form.working_express_db != null ? this.ExpressData : string.Empty;
                //string xpump_data = this.XPumpData != null ? this.XPumpData : string.Empty;

                string sql = "INSERT INTO `xpumpsecure`.`islog` (`logcode`, `expressdata`, `xpumpdata`, `xpumpuser`, `module`, `afftable`, `affid`, `docnum`, `description`, `username`) VALUES ('" + this.Code + "', '" + this.ExpressData + "', '" + this.XPumpData + "', '" + this.XPumpUser + "', '" + module + "', " + (this.afftable != null ? "'" + this.afftable + "'" : "NULL") + ", " + (this.affid != null ? this.affid.ToString() : "NULL") + ", '" + docnum + "', '" + this.Description + "', '" + user_name + "')";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return new LogSaveResult { isSuccess = true, errMessage = string.Empty };
            }
            catch (MySqlException ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message);
                return new LogSaveResult { isSuccess = false, errMessage = ex.Message };
            }
        }
    }

    public class LogSaveResult
    {
        public bool isSuccess { get; set; }
        public string errMessage { get; set; }
    }

    //public static class LogHelper
    //{
    //    public static void Save(this LogObject log, SccompDbf working_express_db, LoginStatus login_status = null)
    //    {
    //        using(xpumpEntities db = DBX.DataSet(working_express_db))
    //        {
    //            db.xlog.Add(new xlog
    //            {
    //                logcode = log.Code,
    //                description = log.Description,
    //                username = login_status != null ? login_status.loged_in_user_name : string.Empty,
    //                cretime = DateTime.Now
    //            });

    //            db.SaveChanges();
    //        }
    //    }
    //}
}
