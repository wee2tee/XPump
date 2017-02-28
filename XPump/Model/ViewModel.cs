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
        public decimal begtak { get; set; }
        public decimal begacc { get; set; }
        public decimal begdif { get; set; }
        public decimal totbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    int[] nozzle_ids = db.nozzle.Where(n => n.section_id == this.id).Select(n => n.id).ToArray<int>();

                    return this.begacc - db.saleshistory.Where(s => nozzle_ids.Contains<int>(s.nozzle_id)).ToList().Sum(s => s.salqty);
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

        public string loccod { get; set; }

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
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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

    public class shiftsttakVM
    {
        public int id { get; set; }
        public DateTime takdat { get; set; }
        public int section_id { get; set; }
        public string stkcod
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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
        public int id { get; set; }
        public DateTime saldat { get; set; }

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

        public decimal endbal
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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
                var xtrnqty = DbfTable.Stcrd().ToStcrdList()
                            .Where(s => s.docdat.HasValue)
                            .Where(s => s.docdat.Value == this.saldat)
                            .Where(s => s.stkcod.Trim() == this.stkcod.Trim())
                            .Sum(s => s.xtrnqty);

                var rcv = Convert.ToDecimal(xtrnqty);
                this.dayend.rcvqty = rcv;
                return rcv;
            }
        }
        //public decimal salqty { get; set; }
        public decimal salqty
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
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
                var dif = this.endbal - (this.begbal + this.rcvqty - (this.salqty + this.dother));
                this.dayend.difqty = dif;
                return dif;
            }
        }
        public decimal begdif
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
                {
                    var tmp = db.dayend
                            .Where(d => d.stmas_id == this.stmas_id)
                            .Where(d => d.saldat.CompareTo(this.saldat) < 0).ToViewModel();

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
        public int id { get; set; }
        public string tank_name
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
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
                using (xpumpEntities db = DBX.DataSet())
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
        public string compnam { get; set; }
        public string orgnam
        {
            get
            {
                using (xpumpEntities db = DBX.DataSet())
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

    public class ReportBModel
    {
        public DateTime reportDate { get; set; }
        public IsinfoDbfVM isinfoDbfVM { get; set; }
        public List<shift> shifts { get; set; }
        public List<VatTransDbfVM> phpvattransVM { get; set; }
        public List<VatTransDbfVM> prrvattransVM { get; set; }
        //public List<VatTransDbfVM> shsvattransVM { get; set; }
        //public List<VatTransDbfVM> sivvattransVM { get; set; }
        //public List<pricelistVM> pricelistVM_list { get; set; }
        public List<salessummaryVM> salessummaryVM_list { get; set; }
        public List<saleshistoryVM> saleshistoryVM_list { get; set; }
    }

    public class ReportCModel
    {

    }
}