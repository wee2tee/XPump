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
        public string saiprefix { get; set; }
        public string shsprefix { get; set; }
        public string sivprefix { get; set; }
        public string paeprefix { get; set; }
        public string phpprefix { get; set; }
        public string prrprefix { get; set; }
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
        public decimal totbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    int[] nozzle_ids = db.nozzle.Where(n => n.section_id == this.id).Select(n => n.id).ToArray<int>();

                    return this.begbal - db.saleshistory.Where(s => nozzle_ids.Contains<int>(s.nozzle_id)).ToList().Sum(s => s.salqty);
                }
            }
        }
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

    //public class nozzleTransVM
    //{
    //    public int id { get; set; }
    //    public int shift_id { get; set; }
    //    public int nozzle_id { get; set; }
    //    public int stmas_id { get; set; }
    //    public int pricelist_id { get; set; }
    //    public DateTime saldate { get; set; }
    //    public decimal mitbeg { get; set; }
    //    public decimal mitend { get; set; }
    //    public decimal salqty { get; set; }
    //    public decimal salval { get; set; }
    //}

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
        public DateTime? price_date { get; set; }
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

    //public class shiftsalesVM
    //{
    //    public int id { get; set; }
    //    public DateTime saldat { get; set; }
    //    public int shift_id { get; set; }

    //    public string shift_name
    //    {
    //        get
    //        {
    //            using(xpumpEntities db = DBX.DataSet())
    //            {
    //                return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
    //            }
    //        }
    //    }

    //    public shiftsales shiftsales { get; set; }
    //}

    public class salessummaryVM
    {
        public int id { get; set; }
        public System.DateTime saldat { get; set; }
        public decimal total
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.saleshistory.Where(s => s.salessummary_id == this.id).Count() > 0 ? db.saleshistory.Where(s => s.salessummary_id == this.id).Sum(s => s.salqty) : 0m;
                }
            }
        }
        public decimal dtest { get; set; }
        public decimal dother { get; set; }
        public string dothertxt { get; set; }
        public decimal totqty
        {
            get
            {
                return this.total - this.dtest - this.dother;
            }
        }
        public decimal unitpr
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.pricelist.Find(this.pricelist_id) != null ? db.pricelist.Find(this.pricelist_id).unitpr : 0m;
                }
            }
        }
        public decimal totval
        {
            get
            {
                return this.totqty * this.unitpr;
            }
        }
        public decimal ddisc { get; set; }
        public decimal netval
        {
            get
            {
                return this.totval - this.ddisc;
            }
        }
        public decimal salvat
        {
            get
            {
                return (this.netval * 7) / 107;
            }
        }
        public decimal purvat { get; set; }
        public int shift_id { get; set; }
        public int stmas_id { get; set; }
        public int pricelist_id { get; set; }
        public int shiftsales_id { get; set; }

        public string shift_name
        {
            get
            {
                using(xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
                }
            }
        }

        public TimeSpan shift_start
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).starttime : TimeSpan.Parse("0:0:0");
                }
            }
        }

        public TimeSpan shift_end
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).endtime : TimeSpan.Parse("0:0:0");
                }
            }
        }

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

        public DateTime? price_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.pricelist.Find(this.pricelist_id) != null ? (DateTime?)db.pricelist.Find(this.pricelist_id).date : null;
                }
            }
        }


        public salessummary salessummary { get; set; }
    }

    public class saleshistoryVM
    {
        public int id { get; set; }
        public System.DateTime saldat { get; set; }
        public string nozzle_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.nozzle.Find(this.nozzle_id) != null ? db.nozzle.Find(this.nozzle_id).name : string.Empty;
                }
            }
        }
        public decimal mitbeg { get; set; }
        public decimal mitend { get; set; }
        public decimal salqty { get; set; }
        public decimal unitpr
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.pricelist.Find(this.pricelist_id) != null ? db.pricelist.Find(this.pricelist_id).unitpr : 0m;
                }
            }
        }
        public decimal salval { get; set; }
        public int shift_id { get; set; }
        public int nozzle_id { get; set; }
        public int stmas_id { get; set; }
        public int pricelist_id { get; set; }
        public int salessummary_id { get; set; }

        public DateTime price_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.pricelist.Find(this.pricelist_id) != null ? db.pricelist.Find(this.pricelist_id).date : DateTime.Now;
                }
            }
        }

        public string shift_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
                }
            }
        }

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

        public saleshistory saleshistory { get; set; }

        //public virtual nozzle nozzle { get; set; }
        //public virtual pricelist pricelist { get; set; }
        //public virtual salessummary salessummary { get; set; }
        //public virtual shift shift { get; set; }
        //public virtual stmas stmas { get; set; }
    }

    public class pricelistVM
    {
        public int id { get; set; }
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
        public DateTime price_date { get; set; }
        public decimal unitpr { get; set; }
        public string currency
        {
            get
            {
                return "บาท";
            }
        }
    }

    public class aptrnVM
    {
        public int id { get; set; }
        public DateTime? rcvdat { get; set; }
        public string vatnum { get; set; }
        public DateTime? vatdat { get; set; }
        public int apmas_id { get; set; }
        public int shift_id { get; set; }

        public string shift_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
                }
            }
        }

        public string shift_desc
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).description : string.Empty;
                }
            }
        }

        public string supcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.apmas.Where(a => a.id == this.apmas_id).FirstOrDefault() != null ? db.apmas.Where(a => a.id == this.apmas_id).First().supcod : string.Empty;
                }
            }
        }

        public string supnam
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.apmas.Where(a => a.id == this.apmas_id).FirstOrDefault() != null ? db.apmas.Where(a => a.id == this.apmas_id).First().supnam : string.Empty;
                }
            }
        }

        public aptrn aptrn { get; set; }
    }

    public class stcrdVM
    {
        public int id { get; set; }
        public decimal trnqty { get; set; }
        public decimal trnval { get; set; }
        public decimal vatamt { get; set; }
        public int aptrn_id { get; set; }
        public int section_id { get; set; }
        public int shift_id { get; set; }

        public DateTime? rcvdat
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.aptrn.Find(aptrn_id) != null ? (DateTime?) db.aptrn.Find(aptrn_id).rcvdat : null;
                }
            }
        }

        public string shift_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
                }
            }
        }

        public string section_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    return db.section.Find(this.section_id) != null ? db.section.Find(this.section_id).name : string.Empty;
                }
            }
        }

        public string supcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    try
                    {
                        var sup_cod = db.apmas.Find(db.aptrn.Find(this.aptrn_id).apmas_id).supcod;
                        return sup_cod;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        public stcrd stcrd { get; set; }
    }

    public class StmasDbfVM
    {
        public bool selected { get; set; }
        public string stkcod { get; set; }
        public string stkdes { get; set; }
        public string stkdes2 { get; set; }
        public string stktyp { get; set; }
        public string remark { get; set; }

        public StmasDbf StmasDbf { get; set; }
    }

    public class IsrunDbfVM
    {
        public string doctyp { get; set; }
        public string doccod { get; set; }
        public string shortnam { get; set; }
        public string posdes { get; set; }
        public string prefix { get; set; }
        public string docnum { get; set; }
        public string depcod { get; set; }

        public IsrunDbf IsrunDbf { get; set; }
    }
}