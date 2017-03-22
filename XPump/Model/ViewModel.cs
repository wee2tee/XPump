﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using XPump.Misc;

namespace XPump.Model
{
    public class shiftVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public int seq { get; set; }
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
        public shift shift { get; set; }
    }

    public class tankVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime startdate { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
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
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public decimal begtak { get; set; }
        public decimal begacc { get; set; }
        public decimal begdif { get; set; }
        public decimal totbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    int[] nozzle_ids = db.nozzle.Where(n => n.section_id == this.id).Select(n => n.id).ToArray<int>();

                    return this.begacc - db.saleshistory.Where(s => nozzle_ids.Contains<int>(s.nozzle_id)).ToList().Sum(s => s.salqty);
                    decimal beg_qty;

                    //var last_sttak = db.daysttak.Include("dayend").Where(d => d.dayend.stmas_id == this.stmas_id && d.section_id == this.id).OrderByDescending(d => d.dayend.saldat).First();
                    //if(last_sttak != null)
                    //{
                    //    var tak_date = db.dayend.Find(last_sttak.dayend_id).saldat;
                    //    var rcvqty =
                    //    var salqty = db.saleshistory.Include("nozzle")
                    //                .Where(s => s.nozzle.section_id == this.id)
                    //                .Where(s => s.saldat.CompareTo(tak_date) > 0)
                    //                .ToList().Sum(s => s.salqty);
                    //    return last_sttak.qty - salqty;
                    //}
                    //else
                    //{
                    //    var salqty = db.saleshistory.Include("nozzle")
                    //                .Where(s => s.nozzle.section_id == this.id)
                    //                .ToList().Sum(s => s.salqty);
                    //    return this.begtak - salqty;
                    //}

                }
            }
        }
        public int tank_id { get; set; }
        public int stmas_id { get; set; }
        
        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }

        public string loccod { get; set; }

        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.tank.Find(this.tank_id) != null ? db.tank.Find(this.tank_id).name : string.Empty;
                }
            }
        }

        public DateTime start_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.tank.Find(this.tank_id) != null ? db.tank.Find(this.tank_id).startdate : DateTime.Now;
                }
            }
        }

        public DateTime? end_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.tank.Find(this.tank_id) != null ? db.tank.Find(this.tank_id).enddate : null;
                }
            }
        }

        public int nozzlecount
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
        public SccompDbf working_express_db { get; set; }
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
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string remark { get; set; }

        public stmas stmas { get; set; }
        public int price_id
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
        public SccompDbf working_express_db { get; set; }
        public int price_id { get; set; }
        public int stmas_id { get; set; }
        public DateTime? price_date { get; set; }
        public decimal unitpr { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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

    public class shiftsalesVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public DateTime? saldat
        {
            get
            {
                return this.shiftsales != null ? (DateTime?)this.shiftsales.saldat : null;
            }
        }
        public string shift_name
        {
            get
            {
                return this.shiftsales != null ? this.shiftsales.shift.name : string.Empty;
            }
        }
        public DateTime? cretime
        {
            get
            {
                return this.shiftsales != null ? (DateTime?)this.shiftsales.cretime : null;
            }
        }
        public bool closed
        {
            get
            {
                return this.shiftsales != null ? this.shiftsales.closed : false;
            }
        }
        public string _closed
        {
            get
            {
                return this.closed ? "ปิดยอดขายแล้ว" : "";
            }
        }
        public int shift_id
        {
            get
            {
                return this.shiftsales != null ? this.shiftsales.shift_id : -1;
            }
        }
        public shiftsales shiftsales
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.shiftsales.Include("shift").Where(s => s.id == this.id).FirstOrDefault();
                }
            }
        }
    }

    public class salessummaryVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public System.DateTime saldat { get; set; }
        public decimal total
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using(xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
                }
            }
        }

        public TimeSpan shift_start
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).starttime : TimeSpan.Parse("0:0:0");
                }
            }
        }

        public TimeSpan shift_end
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).endtime : TimeSpan.Parse("0:0:0");
                }
            }
        }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }

        public DateTime? price_date
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.pricelist.Find(this.pricelist_id) != null ? (DateTime?)db.pricelist.Find(this.pricelist_id).date : null;
                }
            }
        }


        public salessummary salessummary { get; set; }
    }

    public class saleshistoryVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public System.DateTime saldat { get; set; }
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var nozzle = db.nozzle.Find(this.nozzle_id);
                        var section = db.section.Find(nozzle.section_id);
                        var tank = db.tank.Find(section.tank_id);
                        return tank != null ? tank.name : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string section_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var nozzle = db.nozzle.Find(this.nozzle_id);
                        var section = db.section.Where(s => s.id == nozzle.section_id).First();
                        return section != null ? section.name : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string nozzle_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.pricelist.Find(this.pricelist_id) != null ? db.pricelist.Find(this.pricelist_id).date : DateTime.Now;
                }
            }
        }

        public string shift_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.shift.Find(this.shift_id) != null ? db.shift.Find(this.shift_id).name : string.Empty;
                }
            }
        }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }

        public saleshistory saleshistory { get; set; }
    }

    public class dailysaleshistoryVM
    {
        public SccompDbf working_express_db { get; set; }
        public System.DateTime saldat { get; set; }
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var nozzle = db.nozzle.Find(this.nozzle_id);
                        var section = db.section.Find(nozzle.section_id);
                        var tank = db.tank.Find(section.tank_id);
                        return tank != null ? tank.name : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string section_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var nozzle = db.nozzle.Find(this.nozzle_id);
                        var section = db.section.Where(s => s.id == nozzle.section_id).First();
                        return section != null ? section.name : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string nozzle_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.nozzle.Find(this.nozzle_id) != null ? db.nozzle.Find(this.nozzle_id).name : string.Empty;
                }
            }
        }
        public decimal salqty
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.saleshistory.Where(s => s.saldat == this.saldat)
                            .Where(s => s.nozzle_id == this.nozzle_id)
                            .Where(s => s.stmas_id == this.stmas_id)
                            .Sum(s => s.salqty);
                }
            }
        }
        public decimal salval
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var val = db.saleshistory.Include("pricelist").Where(s => s.saldat == this.saldat)
                                .Where(s => s.nozzle_id == this.nozzle_id)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .Sum(s => s.salqty * s.pricelist.unitpr);
                    return val;
                }
            }
        }
        public int nozzle_id { get; set; }
        public int stmas_id { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }
    }

    public class pricelistVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public int stmas_id { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id).name;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
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

    public class shiftsttakVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public DateTime takdat { get; set; }
        public int section_id { get; set; }
        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var sect = db.section.Find(this.section_id);
                        return db.stmas.Find(sect.stmas_id).name;
                    }
                    catch (Exception)
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
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var sect = db.section.Find(this.section_id);
                        return db.stmas.Find(sect.stmas_id).description;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        var sect = db.section.Find(this.section_id);
                        return db.tank.Find(sect.tank_id).name;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string section_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        return db.section.Find(this.section_id).name;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public decimal qty { get; set; }
        public shiftsttak sttak { get; set; }
    }

    public class dayendVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public DateTime saldat { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }

        public decimal endbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var qty = db.daysttak.Where(d => d.dayend_id == this.id).Select(d => d.qty).ToList();
                    if (qty.Contains<decimal>(-1m) || qty.Count == 0)
                    {
                        return -1;
                    }

                    return db.daysttak.Where(d => d.dayend_id == this.id).ToList().Sum(d => d.qty);
                }
            }
        }

        public decimal begbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    decimal beg;
                    var prev_dayend = db.dayend.Where(d => d.saldat.CompareTo(this.saldat) < 0)
                                    .Where(d => d.stmas_id == this.stmas_id)
                                    .OrderByDescending(d => d.saldat).FirstOrDefault();
                    if(prev_dayend != null)
                    {
                        if(db.daysttak.Where(d => d.dayend_id == prev_dayend.id).Select(d => d.qty).Contains<decimal>(-1m))
                        {
                            beg = -1;
                        }
                        else
                        {
                            beg = db.daysttak.Where(d => d.dayend_id == prev_dayend.id).ToList().Sum(d => d.qty);
                        }
                    }
                    else
                    {
                        beg = db.section.Where(s => s.stmas_id == this.stmas_id).ToList().Sum(s => s.begtak);
                    }

                    return beg;
                }
            }
        }

        //public decimal rcvqty { get; set; }
        public decimal rcvqty
        {
            get
            {
                if (DbfTable.IsDataFileExist("Stcrd.dbf", this.working_express_db))
                {
                    var xtrnqty = DbfTable.Stcrd(this.working_express_db).ToStcrdList()
                            .Where(s => s.docdat.HasValue)
                            .Where(s => s.docdat.Value == this.saldat)
                            .Where(s => s.stkcod.Trim() == this.stkcod.Trim())
                            .Sum(s => s.xtrnqty);

                    var rcv = Convert.ToDecimal(xtrnqty);
                    this.dayend.rcvqty = rcv;
                    return rcv;
                }
                else
                {
                    return 0m;
                }
            }
        }
        //public decimal salqty { get; set; }
        public decimal salqty
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var sum_sal = db.saleshistory.Where(s => s.saldat == this.saldat)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .ToList()
                                .Sum(s => s.salqty);

                    var sum_dtest = db.salessummary.Where(s => s.saldat == this.saldat)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .ToList()
                                .Sum(s => s.dtest);

                    var sum_dother = db.salessummary.Where(s => s.saldat == this.saldat)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .ToList()
                                .Sum(s => s.dother);

                    var sum = sum_sal - (sum_dtest + sum_dother);
                    this.dayend.salqty = sum;
                    return sum;
                }
            }
        }
        public string dothertxt { get; set; }
        public decimal dother { get; set; }
        public decimal accbal
        {
            get
            {
                return this.begbal + this.rcvqty - (this.salqty + this.dother);
            }
        }
        //public decimal difqty { get; set; }
        public decimal difqty
        {
            get
            {
                var dif = this.endbal - this.accbal;
                this.dayend.difqty = dif;
                return dif;
            }
        }
        public decimal begdif
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var tmp = db.dayend
                            .Where(d => d.stmas_id == this.stmas_id)
                            .Where(d => d.saldat.CompareTo(this.saldat) < 0).ToViewModel(this.working_express_db);

                    var section_beg_dif = db.section.Where(s => s.stmas_id == this.stmas_id).Sum(s => s.begdif);

                    return tmp.Sum(d => (d.endbal - d.accbal)) + section_beg_dif;
                }
            }
        }
        public int stmas_id { get; set; }

        public dayend dayend { get; set; }
    }

    public class daysttakVM
    {
        public SccompDbf working_express_db { get; set; }
        public int id { get; set; }
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        return db.section.Include("tank").Where(s => s.id == this.section_id).First().tank.name;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string section_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.section.Find(this.section_id) != null ? db.section.Find(this.section_id).name : string.Empty;
                }
            }
        }
        public decimal qty { get; set; }
        public int dayend_id { get; set; }
        public int section_id { get; set; }

        public daysttak daysttak { get; set; }
    }

    public class monthendVM
    {
        public SccompDbf working_express_db { get; set; }
        public DateTime first_date { get; set; }
        public DateTime last_date { get; set; }

        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).name : string.Empty;
                }
            }
        }

        public string stkdes
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.stmas.Find(this.stmas_id) != null ? db.stmas.Find(this.stmas_id).description : string.Empty;
                }
            }
        }

        private List<daysttak> sttaks
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.daysttak.Include("dayend").Where(d => d.dayend.stmas_id == this.stmas_id && d.dayend.saldat.CompareTo(this.first_date) >= 0 && d.dayend.saldat.CompareTo(this.last_date) <= 0).ToList();
                }
            }
        }

        public decimal endbal
        {
            get
            {
                var qty = this.sttaks.Where(d => d.dayend.saldat == this.last_date).Sum(d => d.qty);
                return qty;
            }
        }

        public decimal begbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var prev_month_sttak = db.daysttak.Include("dayend").Where(d => d.dayend.stmas_id == this.stmas_id && d.dayend.saldat.CompareTo(this.first_date) < 0).OrderByDescending(d => d.dayend.saldat).ToList();

                    if(prev_month_sttak.Count > 0)
                    {
                        return prev_month_sttak.Sum(s => s.qty);
                    }
                    else
                    {
                        return db.section.Where(s => s.stmas_id == this.stmas_id).ToList().Sum(s => s.begtak);
                    }
                    
                    //decimal beg;
                    //var prev_dayend = db.dayend.Where(d => d.saldat.CompareTo(this.saldat) < 0)
                    //                .Where(d => d.stmas_id == this.stmas_id)
                    //                .OrderByDescending(d => d.saldat).FirstOrDefault();
                    //if (prev_dayend != null)
                    //{
                    //    if (db.daysttak.Where(d => d.dayend_id == prev_dayend.id).Select(d => d.qty).Contains<decimal>(-1m))
                    //    {
                    //        beg = -1;
                    //    }
                    //    else
                    //    {
                    //        beg = db.daysttak.Where(d => d.dayend_id == prev_dayend.id).ToList().Sum(d => d.qty);
                    //    }
                    //}
                    //else
                    //{
                    //    beg = db.section.Where(s => s.stmas_id == this.stmas_id).ToList().Sum(s => s.begtak);
                    //}

                    //return beg;
                }
            }
        }

        //public decimal rcvqty { get; set; }
        public decimal rcvqty
        {
            get
            {
                if (DbfTable.IsDataFileExist("Stcrd.dbf", this.working_express_db))
                {
                    var xtrnqty = DbfTable.Stcrd(this.working_express_db).ToStcrdList()
                            .Where(s => s.docdat.HasValue)
                            .Where(s => s.docdat.Value.CompareTo(this.first_date) >= 0 && s.docdat.Value.CompareTo(this.last_date) <= 0)
                            .Where(s => s.posopr.Trim() == "0")
                            .Where(s => s.stkcod.Trim() == this.stkcod.Trim())
                            .Sum(s => s.xtrnqty);

                    var rcv = Convert.ToDecimal(xtrnqty);
                    return rcv;
                }
                else
                {
                    return 0m;
                }
            }
        }
        //public decimal salqty { get; set; }
        public decimal salqty
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var sum_sal = db.saleshistory.Where(s => s.saldat.CompareTo(this.first_date) >= 0 && s.saldat.CompareTo(this.last_date) <= 0)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .ToList()
                                .Sum(s => s.salqty);

                    var sum_dtest = db.salessummary.Where(s => s.saldat.CompareTo(this.first_date) >= 0 && s.saldat.CompareTo(this.last_date) <= 0)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .ToList()
                                .Sum(s => s.dtest);

                    var sum_dother = db.salessummary.Where(s => s.saldat.CompareTo(this.first_date) >= 0 && s.saldat.CompareTo(this.last_date) <= 0)
                                .Where(s => s.stmas_id == this.stmas_id)
                                .ToList()
                                .Sum(s => s.dother);

                    var sum = sum_sal - (sum_dtest + sum_dother);
                    return sum;
                }
            }
        }
        public string dothertxt { get; set; }
        public decimal dother
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var disc = db.dayend.Where(d => d.stmas_id == this.stmas_id && d.saldat.CompareTo(this.first_date) >= 0 && d.saldat.CompareTo(this.last_date) <= 0).ToList().Sum(d => d.dother);
                    return disc;
                }
            }
        }
        public decimal accbal
        {
            get
            {
                return this.begbal + this.rcvqty - (this.salqty + this.dother);
            }
        }
        //public decimal difqty { get; set; }
        public decimal difqty
        {
            get
            {
                var dif = this.endbal - this.accbal;
                return dif;
            }
        }
        public decimal begdif
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    decimal trans_dif = db.dayend.Where(d => d.stmas_id == this.stmas_id && d.saldat.CompareTo(this.first_date) < 0).ToViewModel(this.working_express_db).Sum(d => d.difqty);
                    decimal beg_dif = db.section.Where(s => s.stmas_id == this.stmas_id).ToList().Sum(s => s.begdif);

                    return beg_dif + trans_dif;

                    //var tmp = db.dayend
                    //        .Where(d => d.stmas_id == this.stmas_id)
                    //        .Where(d => d.saldat.CompareTo(this.saldat) < 0).ToViewModel();

                    //var section_beg_dif = db.section.Where(s => s.stmas_id == this.stmas_id).Sum(s => s.begdif);

                    //return tmp.Sum(d => (d.endbal - d.accbal)) + section_beg_dif;
                }
            }
        }
        public int stmas_id { get; set; }

        public List<monthsttakVM> monthsttakVM
        {
            get
            {
                List<monthsttakVM> sttak = new List<Model.monthsttakVM>();

                DateTime? last_date_sttak = this.sttaks.OrderByDescending(s => s.dayend.saldat).FirstOrDefault() != null ? (DateTime?)this.sttaks.OrderByDescending(s => s.dayend.saldat).First().dayend.saldat : null;

                foreach (var item in this.sttaks.Where(s => s.dayend.saldat == last_date_sttak))
                {
                    sttak.Add(new monthsttakVM
                    {
                        section_id = item.section_id,
                        qty = item.qty
                    });
                }

                return sttak;
            }
        }
    }

    public class monthsttakVM
    {
        public SccompDbf working_express_db { get; set; }
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    try
                    {
                        return db.section.Include("tank").Where(s => s.id == this.section_id).First().tank.name;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }
        public string section_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.section.Find(this.section_id) != null ? db.section.Find(this.section_id).name : string.Empty;
                }
            }
        }
        public decimal qty { get; set; }
        public int section_id { get; set; }
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

    public class StlocDbfVM
    {
        public string stkcod { get; set; }
        public string loccod { get; set; }

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

    public class IsinfoDbfVM
    {
        public SccompDbf working_express_db { get; set; }
        public string compnam { get; set; }
        public string orgnam
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.settings.FirstOrDefault() != null ? db.settings.First().orgname : string.Empty;
                }
            }
        }
        public string addr { get; set; }
        public string telnum { get; set; }
        public string taxid { get; set; }
    }

    public class VatTransDbfVM
    {
        public string docnum { get; set; }
        public DateTime docdat { get; set; }
        public string people { get; set; }
        public string stkcod { get; set; }
        public double netval { get; set; }
        public double vatamt { get; set; }
    }

    public class ReportAModel
    {
        public DateTime reportDate { get; set; }
        public IsinfoDbfVM isinfoDbfVM { get; set; }
        public shift shift { get; set; }
        public List<VatTransDbfVM> phpvattransVM { get; set; }
        public List<VatTransDbfVM> prrvattransVM { get; set; }
        public List<VatTransDbfVM> shsvattransVM { get; set; }
        public List<VatTransDbfVM> sivvattransVM { get; set; }
        //public List<pricelistVM> pricelistVM_list { get; set; }
        public List<salessummaryVM> salessummaryVM_list { get; set; }
        public List<saleshistoryVM> saleshistoryVM_list { get; set; }
    }

    //public class ReportBModel
    //{
    //    public ReportBModel()
    //    {

    //    }

    //    public DateTime reportDate { get; set; }
    //    public IsinfoDbfVM isinfoDbfVM { get; set; }
    //    public List<VatTransDbfVM> purvattransVM { get; set; }
    //    public List<dayend> dayend { get; set; }
    //}

    public class ReportBModel
    {
        private DateTime report_date;
        private SccompDbf working_express_db;
        public ReportBModel(DateTime date, SccompDbf working_express_db)
        {
            this.report_date = date;
            this.working_express_db = working_express_db;
            DbfTable.Isinfo(this.working_express_db);
            DbfTable.Apmas(this.working_express_db);
            DbfTable.Aptrn(this.working_express_db);
            DbfTable.Stcrd(this.working_express_db);
        }

        public DateTime reportDate
        {
            get
            {
                return this.report_date;
            }
        }
        public IsinfoDbfVM isinfoDbfVM
        {
            get
            {
                if (DbfTable.IsDataFileExist("Isinfo.dbf", this.working_express_db))
                {
                    return DbfTable.Isinfo(this.working_express_db).Rows.Count > 0 ? DbfTable.Isinfo(this.working_express_db).ToList<IsinfoDbf>().First().ToViewModel(this.working_express_db) : new IsinfoDbfVM { compnam = string.Empty, addr = string.Empty, telnum = string.Empty, taxid = string.Empty };
                }
                else
                {
                    return new IsinfoDbfVM { compnam = string.Empty, addr = string.Empty, telnum = string.Empty, taxid = string.Empty };
                }
                
            }
        }
        public List<VatTransDbfVM> purvattransVM
        {
            get
            {
                if (DbfTable.IsDataFileExist("Apmas.dbf", this.working_express_db) && DbfTable.IsDataFileExist("Aptrn.dbf", this.working_express_db) && DbfTable.IsDataFileExist("Stcrd.dbf", this.working_express_db))
                {
                    using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                    {
                        List<string> doc_hp = new List<string>();
                        List<string> doc_rr = new List<string>();
                        foreach (shift s in db.shift.ToList())
                        {
                            doc_hp.Add(s.phpprefix);
                            doc_rr.Add(s.prrprefix);
                        }
                        var apmas = DbfTable.Apmas(this.working_express_db).ToApmasList();
                        var aptrn = DbfTable.Aptrn(this.working_express_db).ToAptrnList()
                                    .Where(a => a.docdat.HasValue)
                                    .Where(a => a.docdat.Value == this.reportDate)
                                    .Where(a => doc_hp.Contains(a.docnum.Substring(0, 2)) || doc_rr.Contains(a.docnum.Substring(0, 2)))
                                    .OrderBy(a => a.docnum).ToList();
                        var stcrd = DbfTable.Stcrd(this.working_express_db).ToStcrdList()
                                    .Where(s => s.docdat.HasValue)
                                    .Where(s => s.docdat.Value == this.reportDate)
                                    .Where(s => aptrn.Select(a => a.docnum).Contains(s.docnum))
                                    .OrderBy(s => s.docnum).ToList();

                        var purvattrans = stcrd.Where(s => doc_hp.Contains(s.docnum.Substring(0, 2)) || doc_rr.Contains(s.docnum.Substring(0, 2)))
                                    .GroupBy(s => s.docnum.Trim())
                                    .Select(s => new VatTransDbfVM
                                    {
                                        docnum = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docnum.Trim(),
                                        docdat = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docdat.Value,
                                        people = apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).FirstOrDefault() != null ? apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().prenam.Trim() + " " + apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().supnam.Trim() : string.Empty,
                                        stkcod = stcrd.Where(st => st.docnum.Trim() == s.Key).First().stkcod.Trim(),
                                        netval = stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval,
                                        vatamt = Convert.ToDouble(string.Format("{0:0.00}", (stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval * 7) / 100))
                                    }).OrderBy(s => s.docdat).ThenBy(s => s.docnum).ToList();

                        return purvattrans;
                    }
                }
                else
                {
                    return new List<VatTransDbfVM>();
                }
                
            }
        }
        public List<dayend> dayend
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    return db.dayend.Include("daysttak").Include("stmas").Where(d => d.saldat == this.reportDate).ToList();
                }
            }
        }
    }

    public class ReportCModel
    {
        private DateTime first_date;
        private DateTime last_date;
        private SccompDbf working_express_db;
        public ReportCModel(DateTime first_date, DateTime last_date, SccompDbf working_express_db)
        {
            this.first_date = first_date;
            this.last_date = last_date;
            this.working_express_db = working_express_db;
            DbfTable.Isinfo(this.working_express_db);
            DbfTable.Apmas(this.working_express_db);
            DbfTable.Aptrn(this.working_express_db);
            DbfTable.Stcrd(this.working_express_db);
        }

        public DateTime reportDate
        {
            get
            {
                return this.last_date;
            }
        }
        public IsinfoDbfVM isinfoDbfVM
        {
            get
            {
                if (DbfTable.IsDataFileExist("Isinfo.dbf", this.working_express_db))
                {
                    return DbfTable.Isinfo(this.working_express_db).Rows.Count > 0 ? DbfTable.Isinfo(this.working_express_db).ToList<IsinfoDbf>().First().ToViewModel(this.working_express_db) : new IsinfoDbfVM { compnam = string.Empty, addr = string.Empty, telnum = string.Empty, taxid = string.Empty };
                }
                else
                {
                    return new IsinfoDbfVM { compnam = string.Empty, addr = string.Empty, telnum = string.Empty, taxid = string.Empty };
                }
            }
        }
        public List<VatTransDbfVM> purvattransVM
        {
            get
            {
                if (DbfTable.IsDataFileExist("Apmas.dbf", this.working_express_db) && DbfTable.IsDataFileExist("Aptrn.dbf", this.working_express_db) && DbfTable.IsDataFileExist("Stcrd.dbf", this.working_express_db))
                {
                    using(xpumpEntities db = DBX.DataSet(this.working_express_db))
                    {
                        List<string> doc_hp = new List<string>();
                        List<string> doc_rr = new List<string>();
                        foreach (shift s in db.shift.ToList())
                        {
                            doc_hp.Add(s.phpprefix);
                            doc_rr.Add(s.prrprefix);
                        }
                        var apmas = DbfTable.Apmas(this.working_express_db).ToApmasList();
                        var aptrn = DbfTable.Aptrn(this.working_express_db).ToAptrnList()
                                    .Where(a => a.docdat.HasValue)
                                    .Where(a => a.docdat.Value.CompareTo(this.first_date) >= 0 && a.docdat.Value.CompareTo(this.last_date) <= 0)
                                    .Where(a => doc_hp.Contains(a.docnum.Substring(0, 2)) || doc_rr.Contains(a.docnum.Substring(0, 2)))
                                    .OrderBy(a => a.docnum).ToList();
                        var stcrd = DbfTable.Stcrd(this.working_express_db).ToStcrdList()
                                    .Where(s => s.docdat.HasValue)
                                    .Where(s => s.docdat.Value.CompareTo(this.first_date) >= 0 && s.docdat.Value.CompareTo(this.last_date) <= 0)
                                    .Where(s => aptrn.Select(a => a.docnum).Contains(s.docnum))
                                    .OrderBy(s => s.docnum).ToList();

                        return stcrd.Where(s => doc_hp.Contains(s.docnum.Substring(0, 2)) || doc_rr.Contains(s.docnum.Substring(0, 2)))
                                    .GroupBy(s => s.docnum.Trim())
                                    .Select(s => new VatTransDbfVM
                                    {
                                        docnum = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docnum.Trim(),
                                        docdat = stcrd.Where(st => st.docnum.Trim() == s.Key).First().docdat.Value,
                                        people = apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).FirstOrDefault() != null ? apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().prenam.Trim() + " " + apmas.Where(a => a.supcod.Trim() == stcrd.Where(st => st.docnum.Trim() == s.Key).First().people.Trim()).First().supnam.Trim() : string.Empty,
                                        stkcod = stcrd.Where(st => st.docnum.Trim() == s.Key).First().stkcod.Trim(),
                                        netval = stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval,
                                        vatamt = Convert.ToDouble(string.Format("{0:0.00}", (stcrd.Where(st => st.docnum.Trim() == s.Key).First().netval * 7) / 100))
                                    }).OrderBy(s => s.docdat).ThenBy(s => s.docnum).ToList();
                    }
                }
                else
                {
                    return new List<VatTransDbfVM>();
                }
            }
        }
        public List<monthendVM> monthend
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet(this.working_express_db))
                {
                    var stmas_id_movement_in_month = db.dayend.Include("stmas").Where(d => d.saldat.CompareTo(this.first_date) >= 0 && d.saldat.CompareTo(this.last_date) <= 0).GroupBy(d => d.stmas_id).Select(d => d.Key).ToList();

                    var monthend = new List<monthendVM>();
                    foreach (var stmas_id in stmas_id_movement_in_month)
                    {
                        var me = db.stmas.Find(stmas_id).GetMonthEndVM(this.first_date, this.last_date, this.working_express_db);
                        monthend.Add(me);
                    }

                    return monthend;
                }
            }
        }
    }
}