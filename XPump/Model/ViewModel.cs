using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPump.Misc;

namespace XPump.Model
{
    public class shiftVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public TimeSpan starttime { get; set; }
        public TimeSpan endtime { get; set; }
        public string remark { get; set; }

        //public RECORD_STATE record_state { get; set; } // flag for 0 = existing data , 1 = being add new data
        public shift shift { get; set; }
    }

    public class tankVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string remark { get; set; }
        public bool isactive { get; set; }

        public tank tank { get; set; }

        public string _isactive
        {
            get
            {
                return this.isactive ? "ใช้งาน" : "ไม่ใช้งาน";
            }
        }
    }

    public class sectionVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal capacity { get; set; }
        public int tank_id { get; set; }
        public int stmas_id { get; set; }
        
        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }

        public int nozzlecount
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.nozzle.Where(n => n.section_id == this.id).Count();
                }
            }
        }

        public section section { get; set; }
    }

    public class nozzleVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string remark { get; set; }
        public bool isactive { get; set; }

        public nozzle nozzle { get; set; }

        public string _isactive
        {
            get
            {
                return this.isactive ? "ใช้งาน" : "ไม่ใช้งาน";
            }
        }
    }

    public class stmasVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string remark { get; set; }

        public stmas stmas { get; set; }
    }
}
