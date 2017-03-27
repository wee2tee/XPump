using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPump.Model;
using XPump.Misc;
using XPump.SubForm;
using System.IO;
using System.Data.SQLite;

namespace XPump.Misc
{
    public class Log
    {
        private MainForm main_form;

        public LogObject LoginSuccess;
        public LogObject LoginFail;
        public LogObject Logout;

        public LogObject SelectCompany;
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

            this.LoginSuccess = new LogObject(this.main_form) { Code = "001", Template = "ล็อกอินเข้าระบบด้วยรหัสผู้ใช้ \"{0}\" สำเร็จ" };
            this.LoginFail = new LogObject(this.main_form) { Code = "002", Template = "ล็อกอินเข้าระบบด้วยรหัสผู้ใช้ \"{0}\" ไม่สำเร็จเนื่องจาก{1}" };
            this.Logout = new LogObject(this.main_form) { Code = "003", Template = "รหัสผู้ใช้ \"{0}\" ออกจากระบบ" };

            this.SelectCompany = new LogObject(this.main_form) { Code = "004", Template = "เข้าใช้งานที่เก็บข้อมูล \"{0}\"" };
            this.ConfigMysqlDb = new LogObject(this.main_form) { Code = "005", Template = "ตั้งค่าการเชื่อมต่อฐานข้อมูล MySQL ไปยังเซิร์ฟเวอร์ \"{0}\", ฐานข้อมูลชื่อ \"{1}\"" };
            this.CreateMysqlDb = new LogObject(this.main_form) { Code = "006", Template = "สร้างฐานข้อมูล MySQL {0}.{1} สำเร็จ" };
            this.ConnectMysqlSuccess = new LogObject(this.main_form) { Code = "007", Template = "เชื่อมต่อฐานข้อมูล {0}.{1} สำเร็จ" };
            this.ConnectMysqlFail = new LogObject(this.main_form) { Code = "008", Template = "ไม่สามารถเชื่อมต่อฐานข้อมูล {0}.{1} เนื่องจาก{2}" };

            //this.OpenForm = new LogObject { Code = "", Template = "" };
            this.AddSuccess = new LogObject(this.main_form) { Code = "009", Template = "เพิ่ม{0} {1} สำเร็จ" };
            this.AddFail = new LogObject(this.main_form) { Code = "010", Template = "เพิ่ม{0} {1} ไม่สำเร็จ เนื่องจาก{2}" };
            this.EditSuccess = new LogObject(this.main_form) { Code = "011", Template = "แก้ไข{0} {1} สำเร็จ" };
            this.EditFail = new LogObject(this.main_form) { Code = "012", Template = "แก้ไข{0} {1} ไม่สำเร็จ เนื่องจาก{2}" };
            this.DeleteSuccess = new LogObject(this.main_form) { Code = "013", Template = "ลบ{0} {1} สำเร็จ" };
            this.DeleteFail = new LogObject(this.main_form) { Code = "014", Template = "ลบ{0} {1} ไม่สำเร็จ เนื่องจาก{2}" };

            this.ImportData = new LogObject(this.main_form) { Code = "015", Template = "นำเข้าข้อมูลรายละเอียดสินค้าจำนวน {0} รายการเสร็จสมบูรณ์" };
            this.ChangeCodeSuccess = new LogObject(this.main_form) { Code = "016", Template = "เปลี่ยนรหัสสินค้าจาก \"{0}\" เป็น \"{1}\" สำเร็จ" };
            this.ChangeCodeFail = new LogObject(this.main_form) { Code = "017", Template = "เปลี่ยนรหัสสินค้าจาก \"{0}\" เป็น \"{1}\" ไม่สำเร็จ เนื่องจาก{2}" };
            this.ApproveOk = new LogObject(this.main_form) { Code = "018", Template = "รับรองรายการ{0} สำเร็จ" };
            this.ApproveCancel = new LogObject(this.main_form) { Code = "019", Template = "ยกเลิกการรับรองรายการ{0} สำเร็จ" };
            this.Print = new LogObject(this.main_form) { Code = "020", Template = "พิมพ์{0} ออกทาง{1}" };
            this.ChangeSettings = new LogObject(this.main_form) { Code = "021", Template = "แก้ไขการตั้งค่าระบบสำเร็จแล้ว" };
            this.ChangeCompany = new LogObject(this.main_form) { Code = "022", Template = "เปลี่ยนไปใช้ข้อมูล {0}" };
        }
    }

    public class LogObject
    {
        public string Code { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }

        private MainForm main_form { get; set; }

        public LogObject(MainForm main_form)
        {
            this.main_form = main_form;
        }

        public LogObject SetLogDescription(params string[] log_val)
        {
            this.Description = string.Format(this.Template, log_val);
            return this;
        }

        public bool Save()
        {
            try
            {
                using (xpumpEntities db = DBX.DataSet(this.main_form.working_express_db))
                {
                    db.xlog.Add(new xlog
                    {
                        logcode = this.Code,
                        description = this.Description,
                        username = this.main_form.loged_in_status != null ? this.main_form.loged_in_status.loged_in_user_name : string.Empty,
                        cretime = DateTime.Now
                    });

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
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
