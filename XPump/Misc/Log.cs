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

        //public LogObject LoginSuccess;
        //public LogObject LoginFail;
        //public LogObject Logout;

        /**
         * <summary>Selecting company
         *      <para>arg[0] = data path, arg[1] = company name</para>
         * </summary>
         **/
        //public LogObject SelectCompany;
        /**
         * <summary>Reconfiguring MySQL DB connection
         *      <para>arg[0] = Server name, arg[1] = Database name</para>
         * </summary>
         **/
        public LogObject ConfigMysqlDb;
        public LogObject CreateMysqlDb;
        public LogObject ConnectMysqlSuccess;
        public LogObject ConnectMysqlFail;

        //public LogObject OpenForm;
        public LogObject AddSuccess;
        public LogObject AddFail;
        public LogObject EditSuccess;
        public LogObject EditFail;
        public LogObject DeleteSuccess;
        public LogObject DeleteFail;

        public LogObject ImportData;
        public LogObject ChangeCodeSuccess;
        public LogObject ChangeCodeFail;
        public LogObject ApproveOk;
        public LogObject ApproveCancel;
        public LogObject Print;

        public LogObject ChangeSettings;
        public LogObject ChangeCompany;

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

        public LogObject Logout(string user_name)
        {
            LogObject l = new LogObject(this.main_form)
            {
                Code = "004",
                Description = string.Format("รหัสผู้ใช้ \"{0}\" ออกจากระบบ", user_name),
                //ExpressData = express_path,
                //XPumpData = xpump_path
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
        public string Docnum { get; set; }
        public string Description { get; set; }
        public string MenuId { get; set; }
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
                string menu_id = this.MenuId != null ? this.MenuId : string.Empty;
                string docnum = this.Docnum != null ? this.Docnum : string.Empty;
                //string data = this.main_form.working_express_db != null ? this.ExpressData : string.Empty;
                //string xpump_data = this.XPumpData != null ? this.XPumpData : string.Empty;

                string sql = "INSERT INTO `xpumpsecure`.`islog` (`logcode`, `expressdata`, `xpumpdata`, `menuid`, `docnum`, `description`, `username`) VALUES ('" + this.Code + "', '" + this.ExpressData + "', '" + this.XPumpData + "', '" + menu_id + "', '" + docnum + "', '" + this.Description + "', '" + this.UserName + "')";
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
