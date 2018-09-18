using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using XPump.Model;
using XPump.SubForm;

namespace XPump.Misc
{
    public enum FORM_MODE
    {
        READ,
        ADD,
        EDIT,
        READ_ITEM,
        ADD_ITEM,
        EDIT_ITEM
    }

    public enum PRINT_OUTPUT
    {
        SCREEN,
        PRINTER,
        FILE
    }

    public enum RECORD_STATE : int
    {
        EXISTING = 0,
        NEW = 1
    }

    public enum INQUIRY
    {
        ALL,
        REST
    }

    public enum DGVROW_TAG
    {
        NORMAL,
        DELETE
    }

    public enum UILANGUAGE
    {
        ENG,
        THA
    }

    // Miscellenous class
    public class InlineControlGridPosition
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }

    public class XComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }

    // Extension Method
    public static class Helper
    {
        public static CultureInfo GetCulture(this UILANGUAGE ui_language)
        {
            if(ui_language == UILANGUAGE.ENG)
            {
                return new CultureInfo("en-US");
            }
            else
            {
                return new CultureInfo("th-TH");
            }
        }

        public static string GetMessage(this MainForm main_form, string message_id)
        {
            if (main_form.c_info == null || main_form.msg_template == null)
                return string.Empty;

            var msg = main_form.msg_template.Where(m => m.id == message_id).FirstOrDefault();

            if(msg != null)
            {
                if (main_form.c_info.Name == "en-US")
                    return msg.en;

                if (main_form.c_info.Name == "th-TH")
                    return msg.th;

                return "No message found!";
            }
            else
            {
                return "No message found!";
            }
        }

        public static int GetExpressVersion()
        {
            var serial_file_path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\Serial.TXT";
            if (File.Exists(serial_file_path))
            {
                string[] lines = File.ReadAllLines(serial_file_path);
                string ver = lines[0].Substring(2, 1);
                int version;
                if(Int32.TryParse(ver, out version))
                {
                    return version;
                }
            }
            return 0;
        }

        public static tanksetupVM ToViewModel(this tanksetup tanksetup, SccompDbf working_express_db)
        {
            if(tanksetup == null)
            {
                return null;
            }

            tanksetupVM t = new tanksetupVM
            {
                working_express_db = working_express_db,
                tanksetup = tanksetup,
            };

            return t;
        }

        public static List<tanksetupVM> ToViewModel(this IEnumerable<tanksetup> tanksetups, SccompDbf working_express_db)
        {
            List<tanksetupVM> t = new List<tanksetupVM>();
            foreach (var tanksetup in tanksetups)
            {
                t.Add(tanksetup.ToViewModel(working_express_db));
            }

            return t;
        }

        public static istabVM ToViewModel(this istab istab, SccompDbf working_express_db)
        {
            if(istab == null)
            {
                return null;
            }

            istabVM i = new istabVM
            {
                working_express_db = working_express_db,
                istab = istab
            };

            return i;
        }

        public static List<istabVM> ToViewModel(this IEnumerable<istab> istabs, SccompDbf working_express_db)
        {
            List<istabVM> i = new List<istabVM>();
            foreach (var istab in istabs)
            {
                i.Add(istab.ToViewModel(working_express_db));
            }

            return i;
        }

        public static dotherVM ToViewModel(this dother dother, SccompDbf working_express_db)
        {
            if (dother == null)
                return null;

            dotherVM d = new dotherVM
            {
                working_express_db = working_express_db,
                dother = dother
            };

            return d;
        }

        public static List<dotherVM> ToViewModel(this IEnumerable<dother> dothers, SccompDbf working_express_db)
        {
            List<dotherVM> d = new List<dotherVM>();
            foreach (var dother in dothers)
            {
                d.Add(dother.ToViewModel(working_express_db));
            }

            return d;
        }

        public static shiftVM ToViewModel(this shift shift, SccompDbf working_express_db)
        {
            if (shift == null)
                return null;

            shiftVM s = new shiftVM
            {
                working_express_db = working_express_db,
                shift = shift
            };

            return s;
        }

        public static List<shiftVM> ToViewModel(this IEnumerable<shift> shift_lsit, SccompDbf working_express_db)
        {
            List<shiftVM> s = new List<shiftVM>();
            foreach (var shift in shift_lsit)
            {
                s.Add(shift.ToViewModel(working_express_db));
            }

            return s;
        }

        public static tankVM ToViewModel(this tank tank, SccompDbf working_express_db)
        {
            if (tank == null)
                return null;

            tankVM t = new tankVM
            {
                working_express_db = working_express_db,
                //id = tank.id,
                //name = tank.name,
                //description = tank.description,
                //remark = tank.remark,
                //creby = tank.creby,
                //cretime = tank.cretime,
                //chgby = tank.chgby,
                //chgtime = tank.chgtime,
                tank = tank,
                //tanksetup_id = tank.tanksetup_id
            };

            return t;
        }

        public static List<tankVM> ToViewModel(this IEnumerable<tank> tank_list, SccompDbf working_express_db)
        {
            List<tankVM> t = new List<tankVM>();
            foreach (var tank in tank_list)
            {
                t.Add(tank.ToViewModel(working_express_db));
            }

            return t;
        }

        public static sectionVM ToViewModel(this section section, SccompDbf working_express_db)
        {
            if (section == null)
                return null;

            sectionVM s = new sectionVM
            {
                working_express_db = working_express_db,
                //stkcod = section.stkcod,
                //id = section.id,
                //name = section.name,
                //capacity = section.capacity,
                //begacc = section.begacc,
                //begtak = section.begtak,
                //begdif = section.begdif,
                //loccod = section.loccod,
                //tank_id = section.tank_id,
                section = section
            };

            return s;
        }

        public static List<sectionVM> ToViewModel(this IEnumerable<section> section_list, SccompDbf working_express_db)
        {
            List<sectionVM> s = new List<sectionVM>();
            foreach (var item in section_list)
            {
                s.Add(item.ToViewModel(working_express_db));
            }

            return s;
        }

        public static nozzleVM ToViewModel(this nozzle nozzle, SccompDbf working_express_db)
        {
            if (nozzle == null)
                return null;

            nozzleVM n = new nozzleVM
            {
                working_express_db = working_express_db,
                id = nozzle.id,
                name = nozzle.name,
                description = nozzle.description,
                remark = nozzle.remark,
                isactive = nozzle.isactive,
                nozzle = nozzle
            };

            return n;
        }

        public static List<nozzleVM> ToViewModel(this IEnumerable<nozzle> nozzle_list, SccompDbf working_express_db)
        {
            List<nozzleVM> n = new List<nozzleVM>();
            foreach (var nozzle in nozzle_list)
            {
                n.Add(nozzle.ToViewModel(working_express_db));
            }

            return n;
        }

        //public static stmasVM ToViewModel(this stmas stmas, SccompDbf working_express_db)
        //{
        //    if (stmas == null)
        //        return null;

        //    stmasVM s = new stmasVM
        //    {
        //        working_express_db = working_express_db,
        //        id = stmas.id,
        //        name = stmas.name,
        //        description = stmas.description,
        //        remark = stmas.remark,
        //        stmas = stmas
        //    };

        //    return s;
        //}

        //public static List<stmasVM> ToViewModel(this IEnumerable<stmas> stmas_list, SccompDbf working_express_db)
        //{
        //    List<stmasVM> s = new List<stmasVM>();
        //    foreach (var stmas in stmas_list)
        //    {
        //        s.Add(stmas.ToViewModel(working_express_db));
        //    }

        //    return s;
        //}

        public static stmasPriceVM ToPriceViewModel(this StmasDbf stmas, SccompDbf working_express_db)
        {
            if (stmas == null)
                return null;

            stmasPriceVM s = new stmasPriceVM
            {
                working_express_db = working_express_db,
                stkcod = stmas.stkcod.Trim(),
                //price_id = stmas_vm.price_id,
                //stmas_id = stmas_vm.id,
                //price_date = stmas_vm.price_date,
                //unitpr = stmas_vm.unitpr
            };

            return s;
        }

        public static List<stmasPriceVM> ToPriceViewModel(this IEnumerable<StmasDbf> stmas_list, SccompDbf working_express_db)
        {
            List<stmasPriceVM> s = new List<stmasPriceVM>();
            foreach (var stmas_vm in stmas_list)
            {
                s.Add(stmas_vm.ToPriceViewModel(working_express_db));
            }

            return s;
        }
        
        public static pricelistVM ToViewModel(this pricelist price, SccompDbf working_express_db)
        {
            if (price == null)
                return null;

            pricelistVM p = new pricelistVM
            {
                working_express_db = working_express_db,
                //id = price.id,
                //unitpr = price.unitpr,
                pricelist = price
            };
            return p;
        }

        public static List<pricelistVM> ToViewModel(this IEnumerable<pricelist> pricelist, SccompDbf working_express_db)
        {
            List<pricelistVM> p = new List<pricelistVM>();

            foreach (var item in pricelist)
            {
                p.Add(item.ToViewModel(working_express_db));
            }

            return p;
        }

        public static shiftsalesVM ToViewModel(this shiftsales shiftsales, SccompDbf working_express_db)
        {
            if (shiftsales == null)
                return null;

            shiftsalesVM s = new shiftsalesVM
            {
                working_express_db = working_express_db,
                id = shiftsales.id
            };
            return s;
        }

        public static List<shiftsalesVM> ToViewModel(this IEnumerable<shiftsales> shiftsales_list, SccompDbf working_express_db)
        {
            List<shiftsalesVM> s = new List<shiftsalesVM>();
            foreach (var item in shiftsales_list)
            {
                s.Add(item.ToViewModel(working_express_db));
            }
            return s;
        }

        public static salessummaryVM ToViewModel(this salessummary sales, SccompDbf working_express_db)
        {
            if (sales == null)
                return null;

            salessummaryVM s = new salessummaryVM
            {
                working_express_db = working_express_db,
                salessummary = sales
            };

            return s;
        }

        public static List<salessummaryVM> ToViewModel(this IEnumerable<salessummary> sales_list, SccompDbf working_express_db)
        {
            List<salessummaryVM> s = new List<salessummaryVM>();
            foreach (var item in sales_list)
            {
                s.Add(item.ToViewModel(working_express_db));
            }

            return s;
        }

        public static decimal GetPurVatFromExpress(this salessummary sales, SccompDbf working_express_db)
        {
            using (xpumpEntities db = DBX.DataSet(working_express_db))
            {
                var salessummary = db.salessummary.Include("shiftsales").Include("shiftsales.shift").Where(s => s.id == sales.id).FirstOrDefault();

                if (salessummary == null)
                    return 0m;

                string hp_prefix = salessummary.shiftsales.shift.phpprefix;
                string rr_prefix = salessummary.shiftsales.shift.prrprefix;
                DateTime saldat = salessummary.saldat;

                var locs = db.saleshistory.Include("nozzle.section").Where(s => s.salessummary_id == sales.id).GroupBy(s => s.nozzle.section.loccod).Select(g => g.Key).ToList();
                //.Select(s => s.nozzle.section.loccod).ToList();

                var purvat = DbfTable.Stcrd(working_express_db).ToStcrdList()
                            .Where(s => s.depcod.Trim() == working_express_db.db_conn_config.depcod.Trim())
                            .Where(s => s.docdat.HasValue)
                            .Where(s => s.docdat.Value == saldat)
                            .Where(s => s.posopr.Trim() == "0")
                            .Where(s => s.stkcod.Trim() == salessummary.stkcod.Trim())
                            .Where(s => (s.docnum.Substring(0, 2) == hp_prefix || s.docnum.Substring(0, 2) == rr_prefix))
                            .Where(s => locs.Contains(s.loccod.Trim()))
                            .Sum(s => (s.netval * 7) / 100);

                return Convert.ToDecimal(purvat);
            }
        }

        //public static decimal GetRcvQtyFromExpress(this dayend dayend, SccompDbf working_express_db)
        //{
        //    if (DbfTable.IsDataFileExist("Stcrd.dbf", working_express_db))
        //    {
        //        var xtrnqty = DbfTable.Stcrd(working_express_db).ToStcrdList()
        //                .Where(s => s.docdat.HasValue)
        //                .Where(s => s.docdat.Value == dayend.saldat)
        //                .Where(s => s.stkcod.Trim() == dayend.stkcod.Trim())
        //                .Sum(s => s.xtrnqty);

        //        var rcv = Convert.ToDecimal(xtrnqty);
        //        dayend.rcvqty = rcv;
        //        return rcv;
        //    }
        //    else
        //    {
        //        return 0m;
        //    }
        //}

        public static saleshistoryVM ToViewModel(this saleshistory saleshistory, SccompDbf working_express_db)
        {
            if (saleshistory == null)
                return null;

            saleshistoryVM s = new saleshistoryVM
            {
                working_express_db = working_express_db,
                saleshistory = saleshistory,
                mitbeg = saleshistory.mitbeg
            };

            return s;
        }

        public static List<saleshistoryVM> ToViewModel(this IEnumerable<saleshistory> saleshistory_list, SccompDbf working_express_db)
        {
            List<saleshistoryVM> s = new List<saleshistoryVM>();
            foreach (var item in saleshistory_list)
            {
                s.Add(item.ToViewModel(working_express_db));
            }

            return s;
        }

        public static saleshistoryVM SetMitBeg(this saleshistoryVM sales)
        {
            using (xpumpEntities db = DBX.DataSet(sales.working_express_db))
            {
                var sales_vm = db.saleshistory.Find(sales.id).ToViewModel(sales.working_express_db);
                if (sales_vm == null)
                    return null;

                var find_latest = db.saleshistory.OrderByDescending(s => s.saldat).ThenByDescending(s => s.mitend).Where(s => s.saldat.CompareTo(sales.saldat) <= 0 && s.nozzle_id == sales.nozzle_id && s.mitbeg >= 0 && s.id != sales.id).FirstOrDefault();

                sales_vm.mitbeg = find_latest != null ? find_latest.mitend : 0m;
                return sales_vm;
            }
        }

        public static List<saleshistoryVM> SetMitBeg(this IEnumerable<saleshistoryVM> sales)
        {
            List<saleshistoryVM> sales_vm = new List<saleshistoryVM>();
            foreach (var s in sales)
            {
                sales_vm.Add(s.SetMitBeg());
            }

            return sales_vm;
        }

        public static shiftsttakVM ToViewModel(this shiftsttak sttak, SccompDbf working_express_db/*, IEnumerable<StmasDbf> stmas_dbf_list = null*/)
        {
            if (sttak == null)
                return null;

            shiftsttakVM s = new shiftsttakVM
            {
                working_express_db = working_express_db,
                shiftsttak = sttak,
            };
            //s.stkdes = stmas_dbf_list != null ? (stmas_dbf_list.Where(st => st.stkcod.Trim() == s.stkcod.Trim()).FirstOrDefault() != null ? stmas_dbf_list.Where(st => st.stkcod.Trim() == s.stkcod.Trim()).FirstOrDefault().stkdes.Trim() : string.Empty) : string.Empty;

            return s;
        }

        public static List<shiftsttakVM> ToViewModel(this IEnumerable<shiftsttak> sttak_list, SccompDbf working_express_db)
        {
            //var stmas_dbf_list = DbfTable.Stmas(working_express_db).ToStmasList();

            List<shiftsttakVM> s = new List<shiftsttakVM>();

            foreach (var item in sttak_list)
            {
                s.Add(item.ToViewModel(working_express_db/*, stmas_dbf_list*/));
            }

            return s;
        }

        public static dayendVM ToViewModel(this dayend dayend, SccompDbf working_express_db)
        {
            if (dayend == null)
                return null;

            dayendVM d = new dayendVM
            {
                working_express_db = working_express_db,
                dayend = dayend
            };

            return d;
        }

        public static List<dayendVM> ToViewModel(this IEnumerable<dayend> dayend_list, SccompDbf working_express_db)
        {
            List<dayendVM> d = new List<dayendVM>();

            foreach (var item in dayend_list)
            {
                d.Add(item.ToViewModel(working_express_db));
            }

            return d;
        }

        public static daysttakVM ToViewModel(this daysttak sttak, SccompDbf working_express_db)
        {
            if (sttak == null)
                return null;

            daysttakVM s = new daysttakVM
            {
                working_express_db = working_express_db,
                daysttak = sttak
            };

            return s;
        }

        public static List<daysttakVM> ToViewModel(this IEnumerable<daysttak> sttak_list, SccompDbf working_express_db)
        {
            List<daysttakVM> s = new List<daysttakVM>();

            foreach (var item in sttak_list)
            {
                s.Add(item.ToViewModel(working_express_db));
            }

            return s;
        }

        //public static int GetExpressVersion(this SccompDbf working_express_db)
        //{
        //    var serial_file_path = working_express_db.abs_path + @"\Serial.TXT";
        //    if (File.Exists(serial_file_path))
        //    {

        //    }
        //    return 0;
        //}

        public static IsprdDbf ToIsprd(this DataTable dt_isprd)
        {
            IsprdDbf isprd = new IsprdDbf
            {
                beg1 = dt_isprd.Rows[0].Field<DateTime?>("beg1"),
                end1 = dt_isprd.Rows[0].Field<DateTime?>("end1"),
                lock1 = dt_isprd.Rows[0].Field<string>("lock1"),
                beg2 = dt_isprd.Rows[0].Field<DateTime?>("beg2"),
                end2 = dt_isprd.Rows[0].Field<DateTime?>("end2"),
                lock2 = dt_isprd.Rows[0].Field<string>("lock2"),
                beg3 = dt_isprd.Rows[0].Field<DateTime?>("beg3"),
                end3 = dt_isprd.Rows[0].Field<DateTime?>("end3"),
                lock3 = dt_isprd.Rows[0].Field<string>("lock3"),
                beg4 = dt_isprd.Rows[0].Field<DateTime?>("beg4"),
                end4 = dt_isprd.Rows[0].Field<DateTime?>("end4"),
                lock4 = dt_isprd.Rows[0].Field<string>("lock4"),
                beg5 = dt_isprd.Rows[0].Field<DateTime?>("beg5"),
                end5 = dt_isprd.Rows[0].Field<DateTime?>("end5"),
                lock5 = dt_isprd.Rows[0].Field<string>("lock5"),
                beg6 = dt_isprd.Rows[0].Field<DateTime?>("beg6"),
                end6 = dt_isprd.Rows[0].Field<DateTime?>("end6"),
                lock6 = dt_isprd.Rows[0].Field<string>("lock6"),
                beg7 = dt_isprd.Rows[0].Field<DateTime?>("beg7"),
                end7 = dt_isprd.Rows[0].Field<DateTime?>("end7"),
                lock7 = dt_isprd.Rows[0].Field<string>("lock7"),
                beg8 = dt_isprd.Rows[0].Field<DateTime?>("beg8"),
                end8 = dt_isprd.Rows[0].Field<DateTime?>("end8"),
                lock8 = dt_isprd.Rows[0].Field<string>("lock8"),
                beg9 = dt_isprd.Rows[0].Field<DateTime?>("beg9"),
                end9 = dt_isprd.Rows[0].Field<DateTime?>("end9"),
                lock9 = dt_isprd.Rows[0].Field<string>("lock9"),
                beg10 = dt_isprd.Rows[0].Field<DateTime?>("beg10"),
                end10 = dt_isprd.Rows[0].Field<DateTime?>("end10"),
                lock10 = dt_isprd.Rows[0].Field<string>("lock10"),
                beg11 = dt_isprd.Rows[0].Field<DateTime?>("beg11"),
                end11 = dt_isprd.Rows[0].Field<DateTime?>("end11"),
                lock11 = dt_isprd.Rows[0].Field<string>("lock11"),
                beg12 = dt_isprd.Rows[0].Field<DateTime?>("beg12"),
                end12 = dt_isprd.Rows[0].Field<DateTime?>("end12"),
                lock12 = dt_isprd.Rows[0].Field<string>("lock12"),

                beg1ny = dt_isprd.Rows[0].Field<DateTime?>("beg1ny"),
                end1ny = dt_isprd.Rows[0].Field<DateTime?>("end1ny"),
                lock1ny = dt_isprd.Rows[0].Field<string>("lock1ny"),
                beg2ny = dt_isprd.Rows[0].Field<DateTime?>("beg2ny"),
                end2ny = dt_isprd.Rows[0].Field<DateTime?>("end2ny"),
                lock2ny = dt_isprd.Rows[0].Field<string>("lock2ny"),
                beg3ny = dt_isprd.Rows[0].Field<DateTime?>("beg3ny"),
                end3ny = dt_isprd.Rows[0].Field<DateTime?>("end3ny"),
                lock3ny = dt_isprd.Rows[0].Field<string>("lock3ny"),
                beg4ny = dt_isprd.Rows[0].Field<DateTime?>("beg4ny"),
                end4ny = dt_isprd.Rows[0].Field<DateTime?>("end4ny"),
                lock4ny = dt_isprd.Rows[0].Field<string>("lock4ny"),
                beg5ny = dt_isprd.Rows[0].Field<DateTime?>("beg5ny"),
                end5ny = dt_isprd.Rows[0].Field<DateTime?>("end5ny"),
                lock5ny = dt_isprd.Rows[0].Field<string>("lock5ny"),
                beg6ny = dt_isprd.Rows[0].Field<DateTime?>("beg6ny"),
                end6ny = dt_isprd.Rows[0].Field<DateTime?>("end6ny"),
                lock6ny = dt_isprd.Rows[0].Field<string>("lock6ny"),
                beg7ny = dt_isprd.Rows[0].Field<DateTime?>("beg7ny"),
                end7ny = dt_isprd.Rows[0].Field<DateTime?>("end7ny"),
                lock7ny = dt_isprd.Rows[0].Field<string>("lock7ny"),
                beg8ny = dt_isprd.Rows[0].Field<DateTime?>("beg8ny"),
                end8ny = dt_isprd.Rows[0].Field<DateTime?>("end8ny"),
                lock8ny = dt_isprd.Rows[0].Field<string>("lock8ny"),
                beg9ny = dt_isprd.Rows[0].Field<DateTime?>("beg9ny"),
                end9ny = dt_isprd.Rows[0].Field<DateTime?>("end9ny"),
                lock9ny = dt_isprd.Rows[0].Field<string>("lock9ny"),
                beg10ny = dt_isprd.Rows[0].Field<DateTime?>("beg10ny"),
                end10ny = dt_isprd.Rows[0].Field<DateTime?>("end10ny"),
                lock10ny = dt_isprd.Rows[0].Field<string>("lock10ny"),
                beg11ny = dt_isprd.Rows[0].Field<DateTime?>("beg11ny"),
                end11ny = dt_isprd.Rows[0].Field<DateTime?>("end11ny"),
                lock11ny = dt_isprd.Rows[0].Field<string>("lock11ny"),
                beg12ny = dt_isprd.Rows[0].Field<DateTime?>("beg12ny"),
                end12ny = dt_isprd.Rows[0].Field<DateTime?>("end12ny"),
                lock12ny = dt_isprd.Rows[0].Field<string>("lock12ny"),

            };

            return isprd;

        }

        public static List<StmasDbf> ToStmasList(this DataTable stmas_dbf)
        {
            List<StmasDbf> stmas = new List<StmasDbf>();

            foreach (DataRow row in stmas_dbf.Rows)
            {
                try
                {
                    StmasDbf s = new StmasDbf
                    {
                        stkcod = row.Field<string>("stkcod"),
                        stkdes = row.Field<string>("stkdes"),
                        stkdes2 = row.Field<string>("stkdes2"),
                        stktyp = row.Field<string>("stktyp"),
                        stklev = row.Field<string>("stklev"),
                        stkgrp = row.Field<string>("stkgrp"),
                        barcod = row.Field<string>("barcod"),
                        stkcods = row.Field<string>("stkcods"),
                        acccod = row.Field<string>("acccod"),
                        isinv = row.Field<string>("isinv"),
                        stkclass = row.Field<string>("stkclass"),
                        negallow = row.Field<string>("negallow"),
                        qucod = row.Field<string>("qucod"),
                        cqucod = row.Field<string>("cqucod"),
                        cfactor = row.Field<double>("cfactor"),
                        stnpr = row.Field<double>("stnpr"),
                        ispur = row.Field<string>("ispur"),
                        pqucod = row.Field<string>("pqucod"),
                        pfactor = row.Field<double>("pfactor"),
                        lpurqu = row.Field<string>("lpurqu"),
                        lpurfac = row.Field<double>("lpurfac"),
                        lpurpr = row.Field<double>("lpurpr"),
                        lpdisc = row.Field<string>("lpdisc"),
                        lpurdat = row.Field<DateTime?>("lpurdat"),
                        supcod = row.Field<string>("supcod"),
                        issal = row.Field<string>("issal"),
                        squcod = row.Field<string>("squcod"),
                        sfactor = row.Field<double>("sfactor"),
                        sellpr1 = row.Field<double>("sellpr1"),
                        sellpr2 = row.Field<double>("sellpr2"),
                        sellpr3 = row.Field<double>("sellpr3"),
                        sellpr4 = row.Field<double>("sellpr4"),
                        sellpr5 = row.Field<double>("sellpr5"),
                        tracksal = row.Field<string>("tracksal"),
                        vatcod = row.Field<string>("vatcod"),
                        iscom = row.Field<string>("iscom"),
                        comrat = row.Field<string>("comrat"),
                        lsellqu = row.Field<string>("lsellqu"),
                        lsellfac = row.Field<double>("lsellfac"),
                        lsellpr = row.Field<double>("lsellpr"),
                        lsdisc = row.Field<string>("lsdisc"),
                        lseldat = row.Field<DateTime?>("lseldat"),
                        numelem = row.Field<decimal?>("numelem"),
                        totbal = row.Field<double>("totbal"),
                        totval = row.Field<double>("totval"),
                        totreo = row.Field<double>("totreo"),
                        totres = row.Field<double>("totres"),
                        opnbal = row.Field<double>("opnbal"),
                        unitpr = row.Field<double>("unitpr"),
                        opnval = row.Field<double>("opnval"),
                        lasupd = row.Field<DateTime?>("lasupd"),
                        packing = row.Field<string>("packing"),
                        mlotnum = row.Field<string>("mlotnum"),
                        mrembal = row.Field<double>("mrembal"),
                        mremval = row.Field<double>("mremval"),
                        remark = row.Field<string>("remark"),
                        dat1 = row.Field<DateTime?>("dat1"),
                        dat2 = row.Field<DateTime?>("dat2"),
                        num1 = row.Field<double>("num1"),
                        str1 = row.Field<string>("str1"),
                        str2 = row.Field<string>("str2"),
                        str3 = row.Field<string>("str3"),
                        str4 = row.Field<string>("str4"),
                        creby = row.Field<string>("creby"),
                        credat = row.Field<DateTime?>("credat"),
                        userid = row.Field<string>("userid"),
                        chgdat = row.Field<DateTime?>("chgdat"),
                        status = row.Field<string>("status"),
                        inactdat = row.Field<DateTime?>("inactdat")
                    };
                    stmas.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stmas;
        }

        public static List<StlocDbf> ToStlocList(this DataTable stloc_dbf)
        {
            List<StlocDbf> stloc = new List<StlocDbf>();

            foreach (DataRow row in stloc_dbf.Rows)
            {
                try
                {
                    StlocDbf s = new StlocDbf
                    {
                        stkcod = row.Field<string>("stkcod"),
                        loccod = row.Field<string>("loccod"),
                        area = row.Field<string>("area"),
                        stkclass = row.Field<string>("stkclass"),
                        locbal = !row.IsNull("locbal") ? row.Field<double>("locbal") : 0d,
                        unitpr = !row.IsNull("unitpr") ? row.Field<double>("unitpr") : 0d,
                        locval = !row.IsNull("locval") ? row.Field<double>("locval") : 0d,
                        locreo = !row.IsNull("locreo") ? row.Field<double>("locreo") : 0d,
                        locres = !row.IsNull("locres") ? row.Field<double>("locres") : 0d,
                        lpurdat = !row.IsNull("lpurdat") ? (DateTime?)row.Field<DateTime>("lpurdat") : null,
                        lseldat = !row.IsNull("lseldat") ? (DateTime?)row.Field<DateTime>("lseldat") : null,
                        lmovdat = !row.IsNull("lmovdat") ? (DateTime?)row.Field<DateTime>("lmovdat") : null,
                        takdat = !row.IsNull("takdat") ? (DateTime?)row.Field<DateTime>("takdat") : null,
                        mlotnum = row.Field<string>("mlotnum"),
                        mrembal = !row.IsNull("mrembal") ? row.Field<double>("mrembal") : 0d,
                        mremval = !row.IsNull("mremval") ? row.Field<double>("mremval") : 0d,
                        begbal = !row.IsNull("begbal") ? row.Field<double>("begbal") : 0d,
                        begval = !row.IsNull("begval") ? row.Field<double>("begval") : 0d,
                        qty1 = !row.IsNull("qty1") ? row.Field<double>("qty1") : 0d,
                        qty2 = !row.IsNull("qty2") ? row.Field<double>("qty2") : 0d,
                        qty3 = !row.IsNull("qty3") ? row.Field<double>("qty3") : 0d,
                        qty4 = !row.IsNull("qty4") ? row.Field<double>("qty4") : 0d,
                        qty5 = !row.IsNull("qty5") ? row.Field<double>("qty5") : 0d,
                        qty6 = !row.IsNull("qty6") ? row.Field<double>("qty6") : 0d,
                        qty7 = !row.IsNull("qty7") ? row.Field<double>("qty7") : 0d,
                        qty8 = !row.IsNull("qty8") ? row.Field<double>("qty8") : 0d,
                        qty9 = !row.IsNull("qty9") ? row.Field<double>("qty9") : 0d,
                        qty10 = !row.IsNull("qty10") ? row.Field<double>("qty10") : 0d,
                        qty11 = !row.IsNull("qty11") ? row.Field<double>("qty11") : 0d,
                        qty12 = !row.IsNull("qty12") ? row.Field<double>("qty12") : 0d,
                        qty1ny = !row.IsNull("qty1ny") ? row.Field<double>("qty1ny") : 0d,
                        qty2ny = !row.IsNull("qty2ny") ? row.Field<double>("qty2ny") : 0d,
                        qty3ny = !row.IsNull("qty3ny") ? row.Field<double>("qty3ny") : 0d,
                        qty4ny = !row.IsNull("qty4ny") ? row.Field<double>("qty4ny") : 0d,
                        qty5ny = !row.IsNull("qty5ny") ? row.Field<double>("qty5ny") : 0d,
                        qty6ny = !row.IsNull("qty6ny") ? row.Field<double>("qty6ny") : 0d,
                        qty7ny = !row.IsNull("qty7ny") ? row.Field<double>("qty7ny") : 0d,
                        qty8ny = !row.IsNull("qty8ny") ? row.Field<double>("qty8ny") : 0d,
                        qty9ny = !row.IsNull("qty9ny") ? row.Field<double>("qty9ny") : 0d,
                        qty10ny = !row.IsNull("qty10ny") ? row.Field<double>("qty10ny") : 0d,
                        qty11ny = !row.IsNull("qty11ny") ? row.Field<double>("qty11ny") : 0d,
                        qty12ny = !row.IsNull("qty12ny") ? row.Field<double>("qty12ny") : 0d,
                        val1 = !row.IsNull("val1") ? row.Field<double>("val1") : 0d,
                        val2 = !row.IsNull("val2") ? row.Field<double>("val2") : 0d,
                        val3 = !row.IsNull("val3") ? row.Field<double>("val3") : 0d,
                        val4 = !row.IsNull("val4") ? row.Field<double>("val4") : 0d,
                        val5 = !row.IsNull("val5") ? row.Field<double>("val5") : 0d,
                        val6 = !row.IsNull("val6") ? row.Field<double>("val6") : 0d,
                        val7 = !row.IsNull("val7") ? row.Field<double>("val7") : 0d,
                        val8 = !row.IsNull("val8") ? row.Field<double>("val8") : 0d,
                        val9 = !row.IsNull("val9") ? row.Field<double>("val9") : 0d,
                        val10 = !row.IsNull("val10") ? row.Field<double>("val10") : 0d,
                        val11 = !row.IsNull("val11") ? row.Field<double>("val11") : 0d,
                        val12 = !row.IsNull("val12") ? row.Field<double>("val12") : 0d,
                        val1ny = !row.IsNull("val1ny") ? row.Field<double>("val1ny") : 0d,
                        val2ny = !row.IsNull("val2ny") ? row.Field<double>("val2ny") : 0d,
                        val3ny = !row.IsNull("val3ny") ? row.Field<double>("val3ny") : 0d,
                        val4ny = !row.IsNull("val4ny") ? row.Field<double>("val4ny") : 0d,
                        val5ny = !row.IsNull("val5ny") ? row.Field<double>("val5ny") : 0d,
                        val6ny = !row.IsNull("val6ny") ? row.Field<double>("val6ny") : 0d,
                        val7ny = !row.IsNull("val7ny") ? row.Field<double>("val7ny") : 0d,
                        val8ny = !row.IsNull("val8ny") ? row.Field<double>("val8ny") : 0d,
                        val9ny = !row.IsNull("val9ny") ? row.Field<double>("val9ny") : 0d,
                        val10ny = !row.IsNull("val10ny") ? row.Field<double>("val10ny") : 0d,
                        val11ny = !row.IsNull("val11ny") ? row.Field<double>("val11ny") : 0d,
                        val12ny = !row.IsNull("val12ny") ? row.Field<double>("val12ny") : 0d,
                        status = row.Field<string>("status"),
                        inactdat = !row.IsNull("inactdat") ? (DateTime?)row.Field<DateTime>("inactdat") : null
                    };

                    stloc.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stloc;
        }

        public static List<ScuserDbf> ToScuserList(this DataTable scuser_dbf)
        {
            List<ScuserDbf> scuser = new List<ScuserDbf>();

            foreach (DataRow row in scuser_dbf.Rows)
            {
                try
                {
                    ScuserDbf s = new ScuserDbf
                    {
                        rectyp = row.Field<string>("rectyp").Trim(),
                        reccod = row.Field<string>("reccod").Trim(),
                        connectgrp = row.Field<string>("connectgrp").Trim(),
                        recdes = row.Field<string>("recdes").Trim(),
                        revokedat = !row.IsNull("revokedat") ? row.Field<DateTime?>("revokedat") : null,
                        resumedat = !row.IsNull("resumedat") ? row.Field<DateTime?>("resumedat") : null,
                        language = row.Field<string>("language").Trim(),
                        userattr = !row.IsNull("userattr") ? row.Field<decimal>("userattr") : 0m,
                        laswrk = !row.IsNull("laswrk") ? row.Field<DateTime?>("laswrk") : null,
                        laspwd = !row.IsNull("laspwd") ? row.Field<DateTime?>("laspwd") : null,
                        lasusedat = !row.IsNull("lasusedat") ? row.Field<DateTime?>("lasusedat") : null,
                        lasusetim = row.Field<string>("lasusetim"),
                        secure = row.Field<string>("secure"),
                        authlev = !row.IsNull("authlev") ? row.Field<decimal>("authlev") : 0m,
                        userpwd = row.Field<string>("userpwd"),
                        status = row.Field<string>("status"),
                        prnnum = row.Field<string>("prnnum"),
                        rwttxt = row.Field<string>("rwttxt")
                    };

                    scuser.Add(s);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return scuser;
        }

        public static List<ScacclvDbf> ToScacclvList(this DataTable scacclv_dbf)
        {
            List<ScacclvDbf> scacclv = new List<ScacclvDbf>();
            foreach (DataRow row in scacclv_dbf.Rows)
            {
                try
                {
                    ScacclvDbf s = new ScacclvDbf
                    {
                        compcod = row.Field<string>("compcod").Trim(),
                        filename = row.Field<string>("filename").Trim(),
                        accessid = row.Field<string>("accessid").Trim(),
                        submodule = row.Field<string>("submodule").Trim(),
                        isread = row.Field<string>("isread").Trim(),
                        isadd = row.Field<string>("isadd").Trim(),
                        isedit = row.Field<string>("isedit").Trim(),
                        isdelete = row.Field<string>("isdelete").Trim(),
                        isprint = row.Field<string>("isprint").Trim(),
                        iscancel = row.Field<string>("iscancel").Trim(),
                        isapprove = row.Field<string>("isapprove").Trim()
                    };

                    scacclv.Add(s);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return scacclv;
        }

        public static List<SccompDbf> ToSccompList(this DataTable sccomp_dbf)
        {
            List<SccompDbf> sccomp = new List<SccompDbf>();

            foreach (DataRow row in sccomp_dbf.Rows)
            {
                try
                {
                    SccompDbf s = new SccompDbf
                    {
                        compnam = row.Field<string>("compnam").TrimEnd(),
                        compcod = row.Field<string>("compcod").Trim(),
                        path = row.Field<string>("path").Trim(),
                        gendat = !row.IsNull("gendat") ? row.Field<DateTime?>("gendat") : null,
                        candel = row.Field<string>("candel").Trim()
                    };

                    sccomp.Add(s);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return sccomp;
        }

        public static List<IsrunDbf> ToIsrunList(this DataTable isrun_dbf)
        {
            List<IsrunDbf> isrun = new List<IsrunDbf>();

            foreach (DataRow row in isrun_dbf.Rows)
            {
                try
                {
                    IsrunDbf i = new IsrunDbf
                    {
                        doctyp = !(row.IsNull("doctyp")) ? row.Field<string>("doctyp") : string.Empty,
                        doccod = !(row.IsNull("doccod")) ? row.Field<string>("doccod") : string.Empty,
                        shortnam = !(row.IsNull("shortnam")) ? row.Field<string>("shortnam") : string.Empty,
                        posdes = !(row.IsNull("posdes")) ? row.Field<string>("posdes") : string.Empty,
                        posdes2 = !(row.IsNull("posdes2")) ?  row.Field<string>("posdes2") : string.Empty,
                        prefix = !(row.IsNull("prefix")) ? row.Field<string>("prefix") : string.Empty,
                        docnum = !(row.IsNull("docnum")) ? row.Field<string>("docnum") : string.Empty,
                        ismodify = !(row.IsNull("ismodify")) ? row.Field<bool>("ismodify") : false,
                        depcod = !(row.IsNull("depcod")) ? row.Field<string>("depcod") : string.Empty,
                        jnltyp = !(row.IsNull("jnltyp")) ? row.Field<string>("jnltyp") : string.Empty,
                        jnlexp = !(row.IsNull("jnlexp")) ? row.Field<string>("jnlexp") : string.Empty,
                        accnum01 = !(row.IsNull("accnum01")) ? row.Field<string>("accnum01") : string.Empty,
                        accnum02 = !(row.IsNull("accnum02")) ? row.Field<string>("accnum02") : string.Empty,
                        accnum03 = !(row.IsNull("accnum03")) ? row.Field<string>("accnum03") : string.Empty,
                        accnum04 = !(row.IsNull("accnum04")) ? row.Field<string>("accnum04") : string.Empty,
                        accnum05 = !(row.IsNull("accnum05")) ? row.Field<string>("accnum05") : string.Empty,
                        accnum06 = !(row.IsNull("accnum06")) ? row.Field<string>("accnum06") : string.Empty,
                        accnum07 = !(row.IsNull("accnum07")) ? row.Field<string>("accnum07") : string.Empty,
                        accnum08 = !(row.IsNull("accnum08")) ? row.Field<string>("accnum08") : string.Empty,
                        accnum09 = !(row.IsNull("accnum09")) ? row.Field<string>("accnum09") : string.Empty,
                        accnum10 = !(row.IsNull("accnum10")) ? row.Field<string>("accnum10") : string.Empty,
                        accnum11 = !(row.IsNull("accnum11")) ? row.Field<string>("accnum11") : string.Empty,
                        accnum12 = !(row.IsNull("accnum12")) ? row.Field<string>("accnum12") : string.Empty,
                        flgvat = !(row.IsNull("flgvat")) ? row.Field<string>("flgvat") : string.Empty,
                        vatrat = !(row.IsNull("vatrat")) ? row.Field<decimal>("vatrat") : 0m,
                        srv_vattyp = !(row.IsNull("srv_vattyp")) ? row.Field<string>("srv_vattyp") : string.Empty,
                        autoprn = !(row.IsNull("autoprn")) ? row.Field<string>("autoprn") : string.Empty,
                        whichform = !(row.IsNull("whichform")) ? row.Field<string>("whichform") : string.Empty,
                        reprn_lev = !(row.IsNull("reprn_lev")) ? row.Field<string>("reprn_lev") : string.Empty,
                        cancel_lev = !(row.IsNull("cancel_lev")) ? row.Field<string>("cancel_lev") : string.Empty,
                        delete_lev = !(row.IsNull("delete_lev")) ? row.Field<string>("delete_lev") : string.Empty,
                        approv_met = !(row.IsNull("approv_met")) ? row.Field<string>("approv_met") : string.Empty,
                        approv_lev = !(row.IsNull("approv_lev")) ? row.Field<string>("approv_lev") : string.Empty,
                        ovrlin_lev = !(row.IsNull("ovrlin_lev")) ? row.Field<string>("ovrlin_lev") : string.Empty,
                        vat_initem = !(row.IsNull("vat_initem")) ? row.Field<string>("vat_initem") : string.Empty,
                        loccod = !(row.IsNull("loccod")) ? row.Field<string>("loccod") : string.Empty,
                        usebarcod = !(row.IsNull("usebarcod")) ? row.Field<string>("usebarcod") : string.Empty,
                        pvatprorat = !(row.IsNull("pvatprorat")) ? row.Field<string>("pvatprorat") : string.Empty,
                        reserve1 = !(row.IsNull("reserve1")) ? row.Field<string>("reserve1") : string.Empty,
                        reserve2 = !(row.IsNull("reserve2")) ? row.Field<string>("reserve2") : string.Empty,
                        reserve3 = !(row.IsNull("reserve3")) ? row.Field<double>("reserve3") : 0d
                    };

                    isrun.Add(i);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return isrun;
        }

        public static List<IstabDbf> ToIstabList(this DataTable istab_dbf)
        {
            List<IstabDbf> istab = new List<IstabDbf>();

            foreach (DataRow row in istab_dbf.Rows)
            {
                try
                {
                    IstabDbf i = new IstabDbf
                    {
                        tabtyp = row.Field<string>("tabtyp"),
                        typcod = row.Field<string>("typcod"),
                        shortnam = row.Field<string>("shortnam"),
                        shortnam2 = row.Field<string>("shortnam2"),
                        typdes = row.Field<string>("typdes"),
                        typdes2 = row.Field<string>("typdes2"),
                        fld01 = row.Field<string>("fld01"),
                        fld02 = !(row.IsNull("fld02")) ? row.Field<double>("fld02") : 0d,
                        depcod = row.Field<string>("depcod"),
                        status = row.Field<string>("status")
                    };

                    istab.Add(i);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return istab;
        }

        public static List<StcrdDbf> ToStcrdList(this DataTable stcrd_dbf)
        {
            List<StcrdDbf> stcrd = new List<StcrdDbf>();

            foreach (DataRow row in stcrd_dbf.Rows)
            {
                try
                {
                    StcrdDbf s = new StcrdDbf
                    {
                        stkcod = row.Field<string>("stkcod"),
                        loccod = row.Field<string>("loccod"),
                        docnum = row.Field<string>("docnum").Trim(),
                        seqnum = row.Field<string>("seqnum"),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        rdocnum = row.Field<string>("rdocnum"),
                        refnum = row.Field<string>("refnum"),
                        depcod = row.Field<string>("depcod"),
                        posopr = row.Field<string>("posopr"),
                        free = row.Field<string>("free"),
                        vatcod = row.Field<string>("vatcod"),
                        people = row.Field<string>("people"),
                        slmcod = row.Field<string>("slmcod"),
                        flag = row.Field<string>("flag"),
                        trnqty = row.Field<double>("trnqty"),
                        tqucod = row.Field<string>("tqucod"),
                        tfactor = row.Field<double>("tfactor"),
                        unitpr = row.Field<double>("unitpr"),
                        disc = row.Field<string>("disc"),
                        discamt = row.Field<double>("discamt"),
                        trnval = row.Field<double>("trnval"),
                        phybal = row.Field<double>("phybal"),
                        retstk = row.Field<string>("retstk"),
                        xtrnqty = row.Field<double>("xtrnqty"),
                        xunitpr = row.Field<double>("xunitpr"),
                        xtrnval = row.Field<double>("xtrnval"),
                        xsalval = row.Field<double>("xsalval"),
                        netval = row.Field<double>("netval"),
                        mlotnum = row.Field<string>("mlotnum"),
                        mrembal = row.Field<double>("mrembal"),
                        mremval = row.Field<double>("mremval"),
                        balchg = row.Field<double>("balchg"),
                        valchg = row.Field<double>("valchg"),
                        lotbal = row.Field<double>("lotbal"),
                        lotval = row.Field<double>("lotval"),
                        lunitpr = row.Field<double>("lunitpr"),
                        pstkcod = row.Field<string>("pstkcod"),
                        accnumdr = row.Field<string>("accnumdr"),
                        accnumcr = row.Field<string>("accnumcr"),
                        stkdes = row.Field<string>("stkdes"),
                        packing = row.Field<string>("packing"),
                        jobcod = row.Field<string>("jobcod"),
                        phase = row.Field<string>("phase"),
                        coscod = row.Field<string>("coscod"),
                        reimburse = row.Field<string>("reimburse")
                    };

                    stcrd.Add(s);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return stcrd;
        }

        public static List<ApmasDbf> ToApmasList(this DataTable apmas_dbf)
        {
            List<ApmasDbf> apmas = new List<ApmasDbf>();

            foreach (DataRow row in apmas_dbf.Rows)
            {
                try
                {
                    ApmasDbf a = new ApmasDbf
                    {
                        supcod = row.Field<string>("supcod"),
                        suptyp = row.Field<string>("suptyp"),
                        onhold = row.Field<string>("onhold"),
                        prenam = row.Field<string>("prenam"),
                        supnam = row.Field<string>("supnam"),
                        addr01 = row.Field<string>("addr01"),
                        addr02 = row.Field<string>("addr02"),
                        addr03 = row.Field<string>("addr03"),
                        zipcod = row.Field<string>("zipcod"),
                        telnum = row.Field<string>("telnum"),
                        contact = row.Field<string>("contact"),
                        supnam2 = row.Field<string>("supnam2"),
                        paytrm = !row.IsNull("paytrm") ? row.Field<decimal>("paytrm") : 0m,
                        paycond = row.Field<string>("paycond"),
                        dlvby = row.Field<string>("dlvby"),
                        vatrat = !row.IsNull("vatrat") ? row.Field<decimal>("vatrat") : 0m,
                        flgvat = row.Field<string>("flgvat"),
                        disc = row.Field<string>("disc"),
                        balance = !row.IsNull("balance") ? row.Field<double>("balance") : 0d,
                        chqpay = !row.IsNull("chqpay") ? row.Field<double>("chqpay") : 0d,
                        crline = !row.IsNull("crline") ? row.Field<double>("crline") : 0d,
                        lasrcv = !row.IsNull("lasrcv") ? (DateTime?)row.Field<DateTime>("lasrcv") : null,
                        accnum = row.Field<string>("accnum"),
                        remark = row.Field<string>("remark"),
                        taxid = row.Field<string>("taxid"),
                        orgnum = !row.IsNull("orgnum") ? row.Field<decimal>("orgnum") : 0m,
                        taxdes = row.Field<string>("taxdes"),
                        taxrat = !row.IsNull("taxrat") ? row.Field<decimal>("taxrat") : 0m,
                        taxtyp = row.Field<string>("taxtyp"),
                        taxcond = row.Field<string>("taxcond"),
                        creby = row.Field<string>("creby"),
                        credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null,
                        userid = row.Field<string>("userid"),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        status = row.Field<string>("status"),
                        inactdat = !row.IsNull("inactdat") ? (DateTime?)row.Field<DateTime>("inactdat") : null
                    };

                    apmas.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return apmas;
        }

        public static List<AptrnDbf> ToAptrnList(this DataTable aptrn_dbf)
        {
            List<AptrnDbf> aptrn = new List<AptrnDbf>();

            foreach (DataRow row in aptrn_dbf.Rows)
            {
                try
                {
                    AptrnDbf a = new AptrnDbf
                    {
                        rectyp = row.Field<string>("rectyp"),
                        docnum = row.Field<string>("docnum").Trim(),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        refnum = row.Field<string>("refnum"),
                        vatprd = !row.IsNull("vatprd") ? (DateTime?)row.Field<DateTime>("vatprd") : null,
                        vatlate = row.Field<string>("vatlate"),
                        vattyp = row.Field<string>("vattyp"),
                        postgl = row.Field<string>("postgl"),
                        ponum = row.Field<string>("ponum"),
                        dntyp = row.Field<string>("dntyp"),
                        depcod = row.Field<string>("depcod"),
                        flgvat = row.Field<string>("flgvat"),
                        supcod = row.Field<string>("supcod"),
                        shipto = row.Field<string>("shipto"),
                        youref = row.Field<string>("youref"),
                        paytrm = row.Field<decimal>("paytrm"),
                        duedat = !row.IsNull("duedat") ? (DateTime?)row.Field<DateTime>("duedat") : null,
                        bilnum = row.Field<string>("bilnum"),
                        dlvby = row.Field<string>("dlvby"),
                        nxtseq = row.Field<string>("nxtseq"),
                        amount = row.Field<double>("amount"),
                        disc = row.Field<string>("disc"),
                        discamt = row.Field<double>("discamt"),
                        aftdisc = row.Field<double>("aftdisc"),
                        advnum = row.Field<string>("advnum"),
                        advamt = row.Field<double>("advamt"),
                        total = row.Field<double>("total"),
                        amtrat0 = row.Field<double>("amtrat0"),
                        vatrat = row.Field<decimal>("vatrat"),
                        vatamt = row.Field<double>("vatamt"),
                        netamt = row.Field<double>("netamt"),
                        netval = row.Field<double>("netval"),
                        payamt = row.Field<double>("payamt"),
                        remamt = row.Field<double>("remamt"),
                        cmplapp = row.Field<string>("cmplapp"),
                        cmpldat = !row.IsNull("cmpldat") ? (DateTime?)row.Field<DateTime>("cmpldat") : null,
                        docstat = row.Field<string>("docstat"),
                        cshpay = row.Field<double>("cshpay"),
                        chqpay = row.Field<double>("chqpay"),
                        intpay = row.Field<double>("intpay"),
                        tax = row.Field<double>("tax"),
                        rcvamt = row.Field<double>("rcvamt"),
                        chqpas = row.Field<double>("chqpas"),
                        vatdat = !row.IsNull("vatdat") ? (DateTime?)row.Field<DateTime>("vatdat") : null,
                        srv_vattyp = row.Field<string>("srv_vattyp"),
                        pvatprorat = row.Field<string>("pvatprorat"),
                        pvat_rf = row.Field<decimal>("pvat_rf"),
                        pvat_nrf = row.Field<decimal>("pvat_nrf"),
                        userid = row.Field<string>("userid"),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        userprn = row.Field<string>("userprn"),
                        prndat = !row.IsNull("prndat") ? (DateTime?)row.Field<DateTime>("prndat") : null,
                        prncnt = row.Field<decimal>("prncnt"),
                        authid = row.Field<string>("authid"),
                        approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
                        billbe = row.Field<string>("billbe"),
                        orgnum = row.Field<decimal>("orgnum")
                    };
                    /* only in V.1 */
                    if (aptrn_dbf.Columns.Contains("prntim"))
                        a.prntim = row.Field<string>("prntim");

                    /* only in V.2^ */
                    if (aptrn_dbf.Columns.Contains("creby"))
                        a.creby = row.Field<string>("creby");
                    if (aptrn_dbf.Columns.Contains("credat"))
                        a.credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null;
                    if (aptrn_dbf.Columns.Contains("c_type"))
                        a.c_type = row.Field<string>("c_type");
                    if (aptrn_dbf.Columns.Contains("c_date"))
                        a.c_date = !row.IsNull("c_date") ? (DateTime?)row.Field<DateTime>("c_date") : null;
                    if (aptrn_dbf.Columns.Contains("c_ref"))
                        a.c_ref = row.Field<string>("c_ref");
                    if (aptrn_dbf.Columns.Contains("c_rate"))
                        a.c_rate = row.Field<double>("c_rate");
                    if (aptrn_dbf.Columns.Contains("c_fixrate"))
                        a.c_fixrate = row.Field<string>("c_fixrate");
                    if (aptrn_dbf.Columns.Contains("c_ratio"))
                        a.c_ratio = row.Field<double>("c_ratio");
                    if (aptrn_dbf.Columns.Contains("c_amount"))
                        a.c_amount = row.Field<double>("c_amount");
                    if (aptrn_dbf.Columns.Contains("c_disc"))
                        a.c_disc = row.Field<string>("c_disc");
                    if (aptrn_dbf.Columns.Contains("c_discamt"))
                        a.c_discamt = row.Field<double>("c_discamt");
                    if (aptrn_dbf.Columns.Contains("c_aftdisc"))
                        a.c_aftdisc = row.Field<double>("c_aftdisc");
                    if (aptrn_dbf.Columns.Contains("c_advamt"))
                        a.c_advamt = row.Field<double>("c_advamt");
                    if (aptrn_dbf.Columns.Contains("c_total"))
                        a.c_total = row.Field<double>("c_total");
                    if (aptrn_dbf.Columns.Contains("c_netamt"))
                        a.c_netamt = row.Field<double>("c_netamt");
                    if (aptrn_dbf.Columns.Contains("c_netval"))
                        a.c_netval = row.Field<double>("c_netval");
                    if (aptrn_dbf.Columns.Contains("c_rcvamt"))
                        a.c_rcvamt = row.Field<double>("c_rcvamt");
                    if (aptrn_dbf.Columns.Contains("c_difamt"))
                        a.c_difamt = row.Field<double>("c_difamt");
                    if (aptrn_dbf.Columns.Contains("c_payamt"))
                        a.c_payamt = row.Field<double>("c_payamt");
                    if (aptrn_dbf.Columns.Contains("c_remamt"))
                        a.c_remamt = row.Field<double>("c_remamt");
                    if (aptrn_dbf.Columns.Contains("link1"))
                        a.link1 = row.Field<string>("link1");
                    if (aptrn_dbf.Columns.Contains("dat1"))
                        a.dat1 = !row.IsNull("dat1") ? (DateTime?)row.Field<DateTime>("dat1") : null;
                    if (aptrn_dbf.Columns.Contains("dat2"))
                        a.dat2 = !row.IsNull("dat2") ? (DateTime?)row.Field<DateTime>("dat2") : null;
                    if (aptrn_dbf.Columns.Contains("num1"))
                        a.num1 = row.Field<double>("num1");
                    if (aptrn_dbf.Columns.Contains("num2"))
                        a.num2 = row.Field<double>("num2");
                    if (aptrn_dbf.Columns.Contains("str1"))
                        a.str1 = row.Field<string>("str1");
                    if (aptrn_dbf.Columns.Contains("str2"))
                        a.str2 = row.Field<string>("str2");

                    aptrn.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return aptrn;
        }

        public static List<ArtrnDbf> ToArtrnList(this DataTable artrn_dbf)
        {
            List<ArtrnDbf> artrn = new List<ArtrnDbf>();

            foreach (DataRow row in artrn_dbf.Rows)
            {
                try
                {
                    ArtrnDbf a = new ArtrnDbf
                    {
                        rectyp = row.Field<string>("rectyp"),
                        docnum = row.Field<string>("docnum").Trim(),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        postgl = row.Field<string>("postgl"),
                        sonum = row.Field<string>("sonum"),
                        cntyp = row.Field<string>("cntyp"),
                        depcod = row.Field<string>("depcod"),
                        flgvat = row.Field<string>("flgvat"),
                        slmcod = row.Field<string>("slmcod"),
                        cuscod = row.Field<string>("cuscod"),
                        shipto = row.Field<string>("shipto"),
                        youref = row.Field<string>("youref"),
                        areacod = row.Field<string>("areacod"),
                        paytrm = row.Field<decimal>("paytrm"),
                        duedat = !row.IsNull("duedat") ? (DateTime?)row.Field<DateTime>("duedat") : null,
                        bilnum = row.Field<string>("bilnum"),
                        nxtseq = row.Field<string>("nxtseq"),
                        amount = row.Field<double>("amount"),
                        disc = row.Field<string>("disc"),
                        discamt = row.Field<double>("discamt"),
                        aftdisc = row.Field<double>("aftdisc"),
                        advnum = row.Field<string>("advnum"),
                        advamt = row.Field<double>("advamt"),
                        total = row.Field<double>("total"),
                        amtrat0 = row.Field<double>("amtrat0"),
                        vatrat = row.Field<decimal>("vatrat"),
                        vatamt = row.Field<double>("vatamt"),
                        netamt = row.Field<double>("netamt"),
                        netval = row.Field<double>("netval"),
                        rcvamt = row.Field<double>("rcvamt"),
                        remamt = row.Field<double>("remamt"),
                        comamt = row.Field<double>("comamt"),
                        cmplapp = row.Field<string>("cmplapp"),
                        cmpldat = !row.IsNull("cmpldat") ? (DateTime?)row.Field<DateTime>("cmpldat") : null,
                        docstat = row.Field<string>("docstat"),
                        cshrcv = row.Field<double>("cshrcv"),
                        chqrcv = row.Field<double>("chqrcv"),
                        intrcv = row.Field<double>("intrcv"),
                        beftax = row.Field<double>("beftax"),
                        taxrat = row.Field<decimal>("taxrat"),
                        taxcond = row.Field<string>("taxcond"),
                        tax = row.Field<double>("tax"),
                        ivcamt = row.Field<double>("ivcamt"),
                        chqpas = row.Field<double>("chqpas"),
                        vatdat = !row.IsNull("vatdat") ? (DateTime?)row.Field<DateTime>("vatdat") : null,
                        vatprd = !row.IsNull("vatprd") ? (DateTime?)row.Field<DateTime>("vatprd") : null,
                        vatlate = row.Field<string>("vatlate"),
                        srv_vattyp = row.Field<string>("srv_vattyp"),
                        dlvby = row.Field<string>("dlvby"),
                        reserve = !row.IsNull("reserve") ? (DateTime?)row.Field<DateTime>("reserve") : null,
                        userid = row.Field<string>("userid"),
                        chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
                        userprn = row.Field<string>("userprn"),
                        prndat = !row.IsNull("prndat") ? (DateTime?)row.Field<DateTime>("prndat") : null,
                        prncnt = row.Field<decimal>("prncnt"),
                        authid = row.Field<string>("authid"),
                        approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
                        billto = row.Field<string>("billto"),
                        orgnum = row.Field<decimal>("orgnum")
                    };

                    /* only in v.1 */
                    if (artrn_dbf.Columns.Contains("prntim"))
                        a.prntim = row.Field<string>("prntim");
                    /* only in v.2 */
                    if (artrn_dbf.Columns.Contains("creby"))
                        a.creby = row.Field<string>("creby");
                    if (artrn_dbf.Columns.Contains("credat"))
                        a.credat = !row.IsNull("credat") ? (DateTime?)row.Field<DateTime>("credat") : null;
                    if (artrn_dbf.Columns.Contains("ponum"))
                        a.ponum = row.Field<string>("ponum");
                    if (artrn_dbf.Columns.Contains("c_type"))
                        a.c_type = row.Field<string>("c_type");
                    if (artrn_dbf.Columns.Contains("c_date"))
                        a.c_date = !row.IsNull("c_date") ? (DateTime?)row.Field<DateTime>("c_date") : null;
                    if (artrn_dbf.Columns.Contains("c_ref"))
                        a.c_ref = row.Field<string>("c_ref");
                    if (artrn_dbf.Columns.Contains("c_rate"))
                        a.c_rate = row.Field<double>("c_rate");
                    if (artrn_dbf.Columns.Contains("c_fixrate"))
                        a.c_fixrate = row.Field<string>("c_fixrate");
                    if (artrn_dbf.Columns.Contains("c_ratio"))
                        a.c_ratio = row.Field<double>("c_ratio");
                    if (artrn_dbf.Columns.Contains("c_amount"))
                        a.c_amount = row.Field<double>("c_amount");
                    if (artrn_dbf.Columns.Contains("c_disc"))
                        a.c_disc = row.Field<string>("c_disc");
                    if (artrn_dbf.Columns.Contains("c_discamt"))
                        a.c_discamt = row.Field<double>("c_discamt");
                    if (artrn_dbf.Columns.Contains("c_aftdisc"))
                        a.c_aftdisc = row.Field<double>("c_aftdisc");
                    if (artrn_dbf.Columns.Contains("c_advamt"))
                        a.c_advamt = row.Field<double>("c_advamt");
                    if (artrn_dbf.Columns.Contains("c_total"))
                        a.c_total = row.Field<double>("c_total");
                    if (artrn_dbf.Columns.Contains("c_netamt"))
                        a.c_netamt = row.Field<double>("c_netamt");
                    if (artrn_dbf.Columns.Contains("c_netval"))
                        a.c_netval = row.Field<double>("c_netval");
                    if (artrn_dbf.Columns.Contains("c_ivcamt"))
                        a.c_ivcamt = row.Field<double>("c_ivcamt");
                    if (artrn_dbf.Columns.Contains("c_difamt"))
                        a.c_difamt = row.Field<double>("c_difamt");
                    if (artrn_dbf.Columns.Contains("c_rcvamt"))
                        a.c_rcvamt = row.Field<double>("c_rcvamt");
                    if (artrn_dbf.Columns.Contains("c_remamt"))
                        a.c_remamt = row.Field<double>("c_remamt");
                    if (artrn_dbf.Columns.Contains("link1"))
                        a.link1 = row.Field<string>("link1");
                    if (artrn_dbf.Columns.Contains("dat1"))
                        a.dat1 = !row.IsNull("dat1") ? (DateTime?)row.Field<DateTime>("dat1") : null;
                    if (artrn_dbf.Columns.Contains("dat2"))
                        a.dat2 = !row.IsNull("dat2") ? (DateTime?)row.Field<DateTime>("dat2") : null;
                    if (artrn_dbf.Columns.Contains("num1"))
                        a.num1 = row.Field<double>("num1");
                    if (artrn_dbf.Columns.Contains("num2"))
                        a.num2 = row.Field<double>("num2");
                    if (artrn_dbf.Columns.Contains("str1"))
                        a.str1 = row.Field<string>("str1");
                    if (artrn_dbf.Columns.Contains("str2"))
                        a.str2 = row.Field<string>("str2");
                        
                    artrn.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return artrn;
        }

        /** For Express V.2 **/

        //public static List<AptrnDbf> ToAptrn246List(this DataTable aptrn_dbf)
        //{
        //    List<AptrnDbf> aptrn = new List<AptrnDbf>();

        //    foreach (DataRow row in aptrn_dbf.Rows)
        //    {
        //        try
        //        {
        //            AptrnDbf a = new AptrnDbf
        //            {
        //                rectyp = row.Field<string>("rectyp"),
        //                docnum = row.Field<string>("docnum").Trim(),
        //                docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
        //                refnum = row.Field<string>("refnum"),
        //                vatprd = !row.IsNull("vatprd") ? (DateTime?)row.Field<DateTime>("vatprd") : null,
        //                vatlate = row.Field<string>("vatlate"),
        //                vattyp = row.Field<string>("vattyp"),
        //                postgl = row.Field<string>("postgl"),
        //                ponum = row.Field<string>("ponum"),
        //                dntyp = row.Field<string>("dntyp"),
        //                depcod = row.Field<string>("depcod"),
        //                flgvat = row.Field<string>("flgvat"),
        //                supcod = row.Field<string>("supcod"),
        //                shipto = row.Field<string>("shipto"),
        //                youref = row.Field<string>("youref"),
        //                paytrm = row.Field<decimal>("paytrm"),
        //                duedat = !row.IsNull("duedat") ? (DateTime?)row.Field<DateTime>("duedat") : null,
        //                bilnum = row.Field<string>("bilnum"),
        //                dlvby = row.Field<string>("dlvby"),
        //                nxtseq = row.Field<string>("nxtseq"),
        //                amount = row.Field<double>("amount"),
        //                disc = row.Field<string>("disc"),
        //                discamt = row.Field<double>("discamt"),
        //                aftdisc = row.Field<double>("aftdisc"),
        //                advnum = row.Field<string>("advnum"),
        //                advamt = row.Field<double>("advamt"),
        //                total = row.Field<double>("total"),
        //                amtrat0 = row.Field<double>("amtrat0"),
        //                vatrat = row.Field<decimal>("vatrat"),
        //                vatamt = row.Field<double>("vatamt"),
        //                netamt = row.Field<double>("netamt"),
        //                netval = row.Field<double>("netval"),
        //                payamt = row.Field<double>("payamt"),
        //                remamt = row.Field<double>("remamt"),
        //                cmplapp = row.Field<string>("cmplapp"),
        //                cmpldat = !row.IsNull("cmpldat") ? (DateTime?)row.Field<DateTime>("cmpldat") : null,
        //                docstat = row.Field<string>("docstat"),
        //                cshpay = row.Field<double>("cshpay"),
        //                chqpay = row.Field<double>("chqpay"),
        //                intpay = row.Field<double>("intpay"),
        //                tax = row.Field<double>("tax"),
        //                rcvamt = row.Field<double>("rcvamt"),
        //                chqpas = row.Field<double>("chqpas"),
        //                vatdat = !row.IsNull("vatdat") ? (DateTime?)row.Field<DateTime>("vatdat") : null,
        //                srv_vattyp = row.Field<string>("srv_vattyp"),
        //                pvatprorat = row.Field<string>("pvatprorat"),
        //                pvat_rf = row.Field<decimal>("pvat_rf"),
        //                pvat_nrf = row.Field<decimal>("pvat_nrf"),
        //                /* +creby +credat */
        //                userid = row.Field<string>("userid"),
        //                chgdat = !row.IsNull("chgdat") ? (DateTime?)row.Field<DateTime>("chgdat") : null,
        //                userprn = row.Field<string>("userprn"),
        //                prndat = !row.IsNull("prndat") ? (DateTime?)row.Field<DateTime>("prndat") : null,
        //                prncnt = row.Field<decimal>("prncnt"),
        //                prntim = row.Field<string>("prntim"), /* only in v.1 */
        //                authid = row.Field<string>("authid"),
        //                approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
        //                billbe = row.Field<string>("billbe"),
        //                orgnum = row.Field<decimal>("orgnum")
        //            };

        //            aptrn.Add(a);
        //        }
        //        catch (Exception ex)
        //        {
        //            continue;
        //        }
        //    }

        //    return aptrn;
        //}
        /** End for Express V.2 **/

        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            if (propertyInfo.PropertyType == typeof(string))
                            {
                                propertyInfo.SetValue(obj, ((string)Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType)).Trim(), null);
                            }
                            else if (propertyInfo.PropertyType.FullName.Contains("DateTime"))
                            {
                                propertyInfo.SetValue(obj, ((DateTime?)Convert.ChangeType(row[prop.Name], typeof(DateTime))), null);
                            }
                            else
                            {
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static StmasDbfVM ToViewModel(this StmasDbf stmasdbf)
        {
            if (stmasdbf == null)
                return null;

            StmasDbfVM s = new StmasDbfVM
            {
                selected = false,
                stkcod = stmasdbf.stkcod.Trim(),
                stkdes = stmasdbf.stkdes.Trim(),
                stkdes2 = stmasdbf.stkdes2.Trim(),
                stktyp = stmasdbf.stktyp.Trim(),
                remark = stmasdbf.remark.Trim(),
                StmasDbf = stmasdbf
            };

            return s;
        }

        public static List<StmasDbfVM> ToViewModel(this IEnumerable<StmasDbf> stmasdbf_list)
        {
            List<StmasDbfVM> s = new List<StmasDbfVM>();
            foreach (var item in stmasdbf_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static StlocDbfVM ToLocSelectionModel(this StlocDbf stlocdbf, SccompDbf working_express_db)
        {
            if (stlocdbf == null)
                return null;

            StlocDbfVM s = new StlocDbfVM
            {
                selected = false,
                stkcod = stlocdbf.stkcod.Trim(),
                loccod = stlocdbf.loccod.Trim(),
                working_express_db = working_express_db
            };

            return s;
        }

        public static List<StlocDbfVM> ToLocSelectionModel(this IEnumerable<StlocDbf> stlocdbf_list, SccompDbf working_express_db)
        {
            List<StlocDbfVM> s = new List<StlocDbfVM>();
            foreach (var item in stlocdbf_list)
            {
                s.Add(item.ToLocSelectionModel(working_express_db));
            }

            return s;
        }

        public static IsrunDbfVM ToViewModel(this IsrunDbf isrundbf)
        {
            if (isrundbf == null)
                return null;

            IsrunDbfVM i = new IsrunDbfVM
            {
                doctyp = isrundbf.doctyp,
                doccod = isrundbf.doccod,
                shortnam = isrundbf.shortnam,
                posdes = isrundbf.posdes,
                prefix = isrundbf.prefix,
                docnum = isrundbf.docnum,
                depcod = isrundbf.depcod,
                IsrunDbf = isrundbf
            };

            return i;
        }

        public static List<IsrunDbfVM> ToViewModel(this IEnumerable<IsrunDbf> isrundbf_list)
        {
            List<IsrunDbfVM> i = new List<IsrunDbfVM>();

            foreach (var item in isrundbf_list)
            {
                i.Add(item.ToViewModel());
            }

            return i;
        }

        public static IsinfoDbfVM ToViewModel(this IsinfoDbf isinfodbf, SccompDbf working_express_db)
        {
            if (isinfodbf == null)
                return null;

            IsinfoDbfVM i = new IsinfoDbfVM
            {
                working_express_db = working_express_db,
                compnam = isinfodbf.thinam.Trim(),
                addr = isinfodbf.addr01.Trim() + " " + isinfodbf.addr02.Trim(),
                telnum = isinfodbf.telnum.Trim(),
                taxid = isinfodbf.taxid.Trim()
            };

            return i;
        }

        public static StlocDbfVM ToViewModel(this StlocDbf stlocdbf, SccompDbf working_express_db)
        {
            if (stlocdbf == null)
                return null;

            StlocDbfVM s = new StlocDbfVM
            {
                selected = false,
                stkcod = stlocdbf.stkcod,
                loccod = stlocdbf.loccod,
                working_express_db = working_express_db
            };
            return s;
        }

        public static List<StlocDbfVM> ToViewModel(this IEnumerable<StlocDbf> stlocdbf_list, SccompDbf working_express_db)
        {
            List<StlocDbfVM> s = new List<StlocDbfVM>();

            foreach (var item in stlocdbf_list)
            {
                s.Add(item.ToViewModel(working_express_db));
            }
            return s;
        }

        public static scacclvVM ToViewModel(this scacclv scacclv)
        {
            if (scacclv == null)
                return null;

            return new scacclvVM
            {
                scacclv = scacclv
            };
        }

        public static List<scacclvVM> ToViewModel(this IEnumerable<scacclv> scacclv_list)
        {
            List<scacclvVM> sc = new List<scacclvVM>();
            foreach (var item in scacclv_list)
            {
                sc.Add(item.ToViewModel());
            }

            return sc;
        }

        public static islogVM ToViewModel(this islog islog)
        {
            if (islog == null)
                return null;

            return new islogVM
            {
                islog = islog
            };
        }

        public static List<islogVM> ToViewModel(this IEnumerable<islog> islog_list)
        {
            List<islogVM> i = new List<islogVM>();
            foreach (var item in islog_list)
            {
                i.Add(item.ToViewModel());
            }

            return i;
        }

        public static void SetControlState(this Component comp, FORM_MODE[] form_mode_to_enable, FORM_MODE form_mode, string accessibility_by_scacclv = null)
        {
            if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true;
                    if(accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripButton)comp).Enabled = false;

                    return;
                }
                if(comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripSplitButton)comp).Enabled = false;

                    return;
                }
                if(comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripDropDownButton)comp).Enabled = false;

                    return;
                }
                if(comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((ToolStripMenuItem)comp).Enabled = false;

                    return;
                }
                if(comp is TabControl)
                {
                    ((TabControl)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((TabControl)comp).Enabled = false;

                    return;
                }
                if(comp is Button)
                {
                    ((Button)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((Button)comp).Enabled = false;

                    return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = true;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((DataGridView)comp).Enabled = false;

                    return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XTextEdit)comp)._ReadOnly = true;

                    return;
                }
                if(comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XDropdownList)comp)._ReadOnly = true;

                    return;
                }
                if(comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XDatePicker)comp)._ReadOnly = true;

                    return;
                }
                if(comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = false;
                    if (accessibility_by_scacclv != null && accessibility_by_scacclv == "N")
                        ((XBrowseBox)comp)._ReadOnly = true;

                    return;
                }
            }
            else
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = false; return;
                }
                if (comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = false; return;
                }
                if(comp is TabControl)
                {
                    ((TabControl)comp).Enabled = false; return;
                }
                if (comp is Button)
                {
                    ((Button)comp).Enabled = false; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = false; return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = true; return;
                }
                if (comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = true; return;
                }
                if (comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = true; return;
                }
                if (comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = true; return;
                }
            }
        }

        public static void SetControlVisibility(this Component comp, FORM_MODE[] form_mode_to_visible, FORM_MODE form_mode)
        {
            if(form_mode_to_visible.Where(fm => fm == form_mode).Count() > 0)
            {
                if(comp is Control)
                {
                    ((Control)comp).Visible = true; return;
                }
            }
            else
            {
                if(comp is Control)
                {
                    ((Control)comp).Visible = false; return;
                }
            }
        }

        public static XTextBox CreateXTextBoxEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            XTextBox xtext = new XTextBox();
            xtext.Text = (string)affected_object.GetType().GetProperty(affected_field).GetValue(affected_object, null); //(string)dgv_cell.Value;
            xtext.TextChanged += delegate
            {
                dgv_cell.Value = xtext.Text;
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, xtext.Text, null);
            };
            return xtext;
        }

        public static XTimePicker CreateXTimePickerEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            XTimePicker xtime = new XTimePicker();
            xtime.Text = ((TimeSpan)affected_object.GetType().GetProperty(affected_field).GetValue(affected_object, null)).ToString(@"hh\:mm\:ss");
            xtime.ValueChanged += delegate
            {
                string str_time = xtime.Value.ToString("HH") + ":" + xtime.Value.ToString("mm") + ":" + xtime.Value.ToString("ss");
                dgv_cell.Value = TimeSpan.Parse(str_time);
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, TimeSpan.Parse(str_time), null);
            };
            return xtime;
        }

        public static XComboBox CreateXComboBoxTrueFalseEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            XComboBox xcb = new XComboBox();
            xcb.Items.Add(new XComboBoxItem
            {
                Text = "ใช้งาน",
                Value = true
            });
            xcb.Items.Add(new XComboBoxItem
            {
                Text = "ไม่ใช้งาน",
                Value = false
            });
            xcb.SelectedItem = xcb.Items.Cast<XComboBoxItem>().Where(i => (bool)i.Value == (bool)affected_object.GetType().GetProperty(affected_field).GetValue(affected_object, null)).First();
            xcb.SelectedValueChanged += delegate
            {
                var selected_value = (object)((XComboBoxItem)xcb.SelectedItem).Value;
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, selected_value, null);
            };
            return xcb;
        }

        public static XComboBox CreateXComboBoxEdit(this DataGridViewCell dgv_cell, List<XComboBoxItem> item_list, object affected_object, string affected_field)
        {
            XComboBox xcb = new XComboBox();
            foreach (var item in item_list)
            {
                xcb.Items.Add(item);
            }
            xcb.SelectedValueChanged += delegate
            {
                var selected_value = (object)((XComboBoxItem)xcb.SelectedItem).Value;
                affected_object.GetType().GetProperty(affected_field).SetValue(affected_object, selected_value, null);
            };
            return xcb;
        }
        
        public static XBrowseBox CreateXBrowseBoxEdit(this DataGridViewCell dgv_cell, object affected_object, string affected_field)
        {
            return null;
        }

        public static void SetInlineControlPosition(this Control inline_control, DataGridView dgv, int row_index, int column_index)
        {
            if(inline_control != null)
            {
                Rectangle rect = dgv.GetCellDisplayRectangle(column_index, row_index, true);
                inline_control.SetBounds(rect.X, rect.Y + 1, rect.Width - 1, rect.Height - 3);
            }
        }

        /// <summary>
        ///     Displays a message box with a message of Exception(especialy for DbUpdateException).
        /// </summary>
        /// <param name="exception_key">
        ///     The text to display as a DB error key, such as a duplicate field name in case duplicate entry.
        /// </param>
        /// <param name="exception_value">
        ///     The text to display as a DB error value.
        /// </param>
        /// <param name="exception_parent_key">
        ///     The text to display as a DB error key of parent table(foreign key contraint), in case add/update a child row while parent row is deleted.
        /// </param>
        /// <param name="exception_parent_value">
        ///     The text to display as a DB error value of parent table.
        /// </param>
        public static void ShowMessage(this Exception ex, string exception_key, string exception_value, string exception_parent_key = "", string exception_parent_value = "")
        {
            if(ex is DbUpdateException)
            {
                string message = string.Empty; ;

                // adding a duplicate unique value
                if (ex.InnerException.InnerException.Message.ToLower().Contains("duplicate entry"))
                {
                    message = string.Format("{0} \"{1}\" มีอยู่แล้วในระบบ", exception_key, exception_value);
                }

                // adding/updating a child row while parent row(foreign key constraint) is deleted
                if (ex.InnerException.InnerException.Message.ToLower().Contains("cannot add or update a child row"))
                {
                    message = string.Format("{0} \"{1}\" ไม่มีอยู่ในระบบ, ไม่สามารถแก้ไขได้", exception_parent_key, exception_parent_value);
                }

                // delete a parent row while a child row(foreign key constraint) is exist
                if (ex.InnerException.InnerException.Message.ToLower().Contains("cannot delete or update a parent row"))
                {
                    message = string.Format("{0} \"{1}\" ยังไม่สามารถลบได้ เนื่องจากมีการนำไปใช้งานแล้ว", exception_key, exception_value);
                }

                XMessageBox.Show(message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);

                return;
            }
            else if(ex is ArgumentNullException)
            {
                if(ex.Message.ToLower().Contains("value cannot be null") && ex.StackTrace.ToLower().Contains(".remove("))
                {
                    XMessageBox.Show(string.Format("{0} \"{1}\" ไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", exception_key, exception_value), "");
                    return;
                }
            }

            XMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
        }

        public static string FormatCurrency(this decimal val)
        {
            return string.Format("{0:#,#0.00}", val);
        }

        public static string FormatCurrency(this double val)
        {
            return string.Format("{0:#,#0.00}", val);
        }

        public static int Width(this string str, Font fnt)
        {
            return TextRenderer.MeasureText(str, fnt).Width + 5;
        }

        public static int Height(this string str, Font fnt)
        {
            return TextRenderer.MeasureText(str, fnt).Height;
        }

        public static Rectangle GetDisplayRect(this string str, Font fnt, int x, int y)
        {
            return new Rectangle(x, y, str.Width(fnt), str.Height(fnt));
        }

        public static int CompareDateTo(this DateTime date_instance, DateTime date_to_compare)
        {
            var d1 = Convert.ToInt32(date_instance.ToString("yyyyMMdd", CultureInfo.CurrentCulture));
            var d2 = Convert.ToInt32(date_to_compare.ToString("yyyyMMdd", CultureInfo.CurrentCulture));

            if (d1 > d2)
            {
                return 1;
            }
            else if (d1 < d2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static void SetLastestPrice(this stmasPriceVM stmas_price, DateTime price_date)
        {
            using (xpumpEntities db = DBX.DataSet(stmas_price.working_express_db))
            {
                var latest_price = db.pricelist.OrderByDescending(p => p.date).Where(p => p.stkcod == stmas_price.stkcod && p.date.CompareTo(price_date) <= 0).FirstOrDefault();

                stmas_price.unitpr = latest_price != null ? latest_price.unitpr : 0m;
                stmas_price.price_date = latest_price != null ? (DateTime?)latest_price.date : null;
            }
        }

        public static void SetLatestPrice(this IEnumerable<stmasPriceVM> stmas_prices, DateTime price_date)
        {
            foreach (var s in stmas_prices)
            {
                s.SetLastestPrice(price_date);
            }
        }

        public static bool IsEditableTankSetup(this tanksetupVM tanksetup, bool show_alert = true)
        {
            using (xpumpEntities db = DBX.DataSet(tanksetup.working_express_db))
            {
                var ts = db.tanksetup.Find(tanksetup.id);
                if(ts == null)
                {
                    if(show_alert)
                        XMessageBox.Show("ข้อมูลที่ต้องการไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                var saleshistory = db.saleshistory
                                    .Include("nozzle.section.tank")
                                    .Where(s => s.nozzle.section.tank.tanksetup_id == ts.id).FirstOrDefault();
                var shiftsttak = db.shiftsttak
                                    .Include("section.tank")
                                    .Where(s => s.section.tank.tanksetup_id == ts.id).FirstOrDefault();

                if(saleshistory != null || shiftsttak != null)
                {
                    if (show_alert)
                        XMessageBox.Show("มีการนำไปเดินรายการแล้ว ห้ามแก้ไข หรือ ลบ", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                return true;
            }
        }

        public static bool IsEditableShiftSales(this shiftsalesVM shiftsales, bool show_alert = true)
        {
            using (xpumpEntities db = DBX.DataSet(shiftsales.working_express_db))
            {
                var sales = db.shiftsales.Find(shiftsales.id);
                if(sales == null)
                {
                    if(show_alert)
                        XMessageBox.Show("ข้อมูลที่ต้องการไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                if(shiftsales.IsClosedShiftSales().Value == true)
                {
                    if(show_alert)
                        XMessageBox.Show("ปิดยอดขายของวันที่ " + shiftsales.saldat.Value.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("th-TH")) + " ไปแล้ว ไม่สามารถแก้ไข/ลบ ได้, ต้องไปลบรายการปิดยอดขายออกก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                if(shiftsales.IsApproved().Value == true)
                {
                    if(show_alert)
                        XMessageBox.Show("รายการถูกรับรองไปแล้ว ไม่สามารถแก้ไขหรือลบ, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                return true;
            }
        }

        public static bool IsEditableDayend(this dayendVM dayend, bool show_alert = true)
        {
            using (xpumpEntities db = DBX.DataSet(dayend.working_express_db))
            {
                var de = db.dayend.Find(dayend.id);
                if (de == null)
                {
                    if (show_alert)
                        XMessageBox.Show("ข้อมูลที่ต้องการไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                if (dayend.IsApprovedAll().Value == true)
                {
                    if (show_alert)
                        XMessageBox.Show("รายการถูกรับรองไปแล้ว ไม่สามารถแก้ไขหรือลบ, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                return true;
            }
        }

        public static bool IsPrintableShiftSales(this shiftsalesVM shiftsales, bool show_alert = true)
        {
            using (xpumpEntities db = DBX.DataSet(shiftsales.working_express_db))
            {
                var sales = db.shiftsales.Find(shiftsales.id);
                if (sales == null)
                {
                    if (show_alert)
                        XMessageBox.Show("ข้อมูลที่ต้องการไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                var settings = DialogSettings.GetSettings(shiftsales.working_express_db);
                if(settings.shiftprintmet == ((int)PRINT_METHOD.APPROVED_BEFORE_PRINT).ToString() && shiftsales.IsApproved().Value == false)
                {
                    if (show_alert)
                        XMessageBox.Show("ต้องรับรองรายการก่อนพิมพ์", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                if(settings.shiftprintmet == ((int)PRINT_METHOD.PRINT_BEFORE_APPROVED).ToString() && shiftsales.IsApproved().Value == true)
                {
                    if (show_alert)
                        XMessageBox.Show("รับรองรายการแล้ว ไม่สามารถพิมพ์ได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                return true;
            }
        }

        public static bool IsPrintableDayend(this dayendVM dayend, bool show_alert = true)
        {
            using (xpumpEntities db = DBX.DataSet(dayend.working_express_db))
            {
                var de = db.dayend.Find(dayend.id);
                if (de == null)
                {
                    if (show_alert)
                        XMessageBox.Show("ข้อมูลที่ต้องการไม่มีอยู่ในระบบ, อาจมีผู้ใช้งานรายอื่นลบออกไปแล้ว", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                var settings = DialogSettings.GetSettings(dayend.working_express_db);
                if (settings.dayprintmet == ((int)PRINT_METHOD.APPROVED_BEFORE_PRINT).ToString() && dayend.IsApproved().Value == false)
                {
                    if (show_alert)
                        XMessageBox.Show("ต้องรับรองรายการก่อนพิมพ์", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                if (settings.dayprintmet == ((int)PRINT_METHOD.PRINT_BEFORE_APPROVED).ToString() && dayend.IsApproved().Value == true)
                {
                    if (show_alert)
                        XMessageBox.Show("รับรองรายการแล้ว ไม่สามารถพิมพ์ได้, ต้องไปยกเลิกการรับรองรายการก่อน", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                    return false;
                }

                return true;
            }
        }

        public static PRINT_AUTHORIZE_STATE GetPrintAuthorizeState(this shiftsalesVM shiftsales)
        {
            using (xpumpEntities db = DBX.DataSet(shiftsales.working_express_db))
            {
                var sales = db.shiftsales.Find(shiftsales.id);
                if (sales == null)
                {
                    return PRINT_AUTHORIZE_STATE.DATA_NOT_FOUND;
                }

                var settings = DialogSettings.GetSettings(shiftsales.working_express_db);
                if (settings.shiftprintmet == ((int)PRINT_METHOD.APPROVED_BEFORE_PRINT).ToString() && shiftsales.IsApproved().Value == false)
                {
                    return PRINT_AUTHORIZE_STATE.MUST_APPROVE_BEFORE_PRINT;
                }

                if (settings.shiftprintmet == ((int)PRINT_METHOD.PRINT_BEFORE_APPROVED).ToString() && shiftsales.IsApproved().Value == true)
                {
                    return PRINT_AUTHORIZE_STATE.MUST_UNAPPROVE_BEFORE_PRINT;
                }

                return PRINT_AUTHORIZE_STATE.READY_TO_PRINT;
            }
        }

        public static PRINT_AUTHORIZE_STATE GetPrintAuthorizeState(this dayendVM dayend)
        {
            using (xpumpEntities db = DBX.DataSet(dayend.working_express_db))
            {
                var de = db.dayend.Find(dayend.id);
                if (de == null)
                {
                    return PRINT_AUTHORIZE_STATE.DATA_NOT_FOUND;
                }

                var settings = DialogSettings.GetSettings(dayend.working_express_db);
                if (settings.dayprintmet == ((int)PRINT_METHOD.APPROVED_BEFORE_PRINT).ToString() && dayend.IsApproved().Value == false)
                {
                    return PRINT_AUTHORIZE_STATE.MUST_APPROVE_BEFORE_PRINT;
                }

                if (settings.dayprintmet == ((int)PRINT_METHOD.PRINT_BEFORE_APPROVED).ToString() && dayend.IsApproved().Value == true)
                {
                    return PRINT_AUTHORIZE_STATE.MUST_UNAPPROVE_BEFORE_PRINT;
                }

                return PRINT_AUTHORIZE_STATE.READY_TO_PRINT;
            }
        }

        public static bool? IsClosedShiftSales(this shiftsalesVM shiftsales)
        {
            if (shiftsales == null)
                return null;

            using (xpumpEntities db = DBX.DataSet(shiftsales.working_express_db))
            {
                var tmp = db.shiftsales.Find(shiftsales.id);
                if (tmp == null)
                    return null;

                return tmp.closed;
            }
        }

        public static bool? IsApproved(this shiftsalesVM shiftsales)
        {
            if (shiftsales == null)
                return null;

            using (xpumpEntities db = DBX.DataSet(shiftsales.working_express_db))
            {
                var sales = db.shiftsales.Find(shiftsales.id);
                if (sales == null)
                    return null;

                return sales.apprtime.HasValue ? true : false;
            }
        }

        public static bool? IsApproved(this dayendVM dayend)
        {
            if (dayend == null)
                return null;

            using (xpumpEntities db = DBX.DataSet(dayend.working_express_db))
            {
                var d = db.dayend.Find(dayend.id);
                if (d == null)
                    return null;

                return d.apprtime.HasValue ? true : false;
            }
        }

        public static bool? IsApprovedAll(this dayendVM dayend)
        {
            if (dayend == null)
                return null;

            using (xpumpEntities db = DBX.DataSet(dayend.working_express_db))
            {
                if (db.dayend.Where(d => d.saldat == dayend.saldat && d.apprtime.HasValue).ToList().Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<daysttak> GetIncompleteDaysttak(this dayendVM dayend)
        {
            using (xpumpEntities db = DBX.DataSet(dayend.working_express_db))
            {
                return db.daysttak.Where(d => d.dayend_id == dayend.id && d.takqty < 0).ToList();
            }
        }

        public static void ShowHelp(string html_file_name)
        {
            Form helpParentWind = new Form();
            Help.ShowHelp(helpParentWind, MainForm.helpfile, HelpNavigator.Topic, html_file_name);
        }

        public static string SubStringX(this string str, int start, int length)
        {
            if (str.Length < length)
                return str;

            return str.Substring(start, length);
        }

        // For display branch with db_connection
        public static dbconnVM ToDbconnVM(this DbConnectionConfig conn, SccompDbf working_express_db)
        {
            if (conn == null)
                return null;

            dbconnVM c = new dbconnVM
            {
                working_express_db = working_express_db,
                db_connection_config = conn
            };

            return c;
        }

        public static List<dbconnVM> ToDbconnVM(this IEnumerable<DbConnectionConfig> conn, SccompDbf working_express_db)
        {
            List<dbconnVM> c = new List<dbconnVM>();

            foreach (var item in conn)
            {
                c.Add(item.ToDbconnVM(working_express_db));
            }

            return c;
        }

        public static bool IsInUse(this FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                Console.WriteLine(ex.Message);
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static bool Reindex(SccompDbf working_express_db, DBF_FILENAME_FLAG dbf_file_flag)
        {
            //ReIndexResult result = new ReIndexResult { success = false, err_message = string.Empty };
            string express_dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\";
            FileInfo file_dbinf = new FileInfo(express_dir + "dbinf.dbf");

            string file_name = dbf_file_flag.ToString() + ".dbf"; //dbf_file_name.ToLower().Contains(".dbf") ? dbf_file_name : dbf_file_name + ".dbf";
            FileInfo data_file = new FileInfo(working_express_db.abs_path + file_name);

            if (!File.Exists(express_dir + "dbinf.dbf"))
            {
                XMessageBox.Show("File Not Found DBINF.DBF", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return false;
            }
            if (file_dbinf.IsInUse())
            {
                XMessageBox.Show("Permission Error File DBINF.DBF", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return false;
            }
            if (data_file.IsInUse())
            {
                XMessageBox.Show("Permission Error File " + dbf_file_flag.ToString() + ".dbf", "Error", MessageBoxButtons.OK, XMessageBoxIcon.Error);
                return false;
            }


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = express_dir;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;

            startInfo.FileName = express_dir + "adm32.exe";
            startInfo.Arguments = working_express_db.abs_path;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine(((int)dbf_file_flag).ToString());

            StringBuilder message = new StringBuilder();
            while (!process.StandardOutput.EndOfStream)
            {
                char[] buffer = new char[200];
                int chars = process.StandardOutput.Read(buffer, 0, buffer.Length);
                message.Append(buffer, 0, chars);
            }

            return true;
        }

        public static string ToStringDescription(this STKGRP stkgrp)
        {
            switch (stkgrp)
            {
                case STKGRP.FUEL:
                    return "น้ำมันเชื้อเพลิง (น้ำมันใส)";
                case STKGRP.OTHER:
                    return "สินค้าอื่น ๆ";
                case STKGRP.NA_O:
                    return "ไม่ได้ระบุ (สินค้าอื่น ๆ)";
                default:
                    return string.Empty;
            }
        }

        public static string ToStringDescription(this BILL_METHOD bill_method)
        {
            switch (bill_method)
            {
                case BILL_METHOD.QTY:
                    return "ป้อนจำนวน";
                case BILL_METHOD.VAL:
                    return "ป้อนราคารวม";
                case BILL_METHOD.NA_Q:
                    return "ไม่ได้ระบุ (ป้อนจำนวน)";
                default:
                    return string.Empty;
            }
        }

        public enum DBF_FILENAME_FLAG : int
        {
            ARMAS = 9
        }
    }
}
