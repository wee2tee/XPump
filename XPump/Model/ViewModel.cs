using System;
using System.Collections.Generic;
using System.Globalization;
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
        public decimal begbal { get; set; }
        public decimal totbal { get; set; }
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

        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.tank.Find(this.tank_id) != null ? db.tank.Find(this.tank_id).name : string.Empty;
                }
            }
        }

        public DateTime start_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.tank.Find(this.tank_id) != null ? db.tank.Find(this.tank_id).startdate : DateTime.Now;
                }
            }
        }

        public DateTime? end_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.tank.Find(this.tank_id) != null ? db.tank.Find(this.tank_id).enddate : null;
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
        public int state
        {
            get
            {
                return this.id > -1 ? 0 : 1;
            }
        }
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
        public int price_id
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    pricelist price = db.pricelist.Where(p => p.stmas_id == this.id).Where(p => DateTime.Now.CompareTo(p.date) >= 0).OrderByDescending(p => p.date).ThenByDescending(p => p.id).FirstOrDefault();

                    if (price != null)
                    {
                        return price.id;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        public decimal unitpr
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    pricelist price = db.pricelist.Where(p => p.stmas_id == this.id).Where(p => DateTime.Now.CompareTo(p.date) >= 0).OrderByDescending(p => p.date).ThenByDescending(p => p.id).FirstOrDefault();

                    if (price != null)
                    {
                        return price.unitpr;
                    }
                    else
                    {
                        return 0m;
                    }
                }
            }
        }
        public DateTime? price_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    pricelist price = db.pricelist.Where(p => p.stmas_id == this.id).Where(p => DateTime.Now.CompareTo(p.date) >= 0).OrderByDescending(p => p.date).ThenByDescending(p => p.id).FirstOrDefault();

                    if (price != null)
                    {
                        return price.date;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }

    public class stmasPriceVM
    {
        public int price_id { get; set; }
        public int stmas_id { get; set; }
        public DateTime? date { get; set; }
        public decimal unitpr { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    stmas s = db.stmas.Find(this.stmas_id);
                    if(s != null)
                    {
                        return s.name;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    stmas s = db.stmas.Find(this.stmas_id);
                    if (s != null)
                    {
                        return s.description;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }
    }

    public class pricelistVM
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public decimal unitpr { get; set; }
        public int stmas_id { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.stmas.Find(this.stmas_id).name;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.stmas.Find(this.stmas_id).description;
                }
            }
        }
    }
}
