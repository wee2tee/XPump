﻿using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using XPump.Model;

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
        public static shiftVM ToViewModel(this shift shift)
        {
            if (shift == null)
                return null;

            shiftVM s = new shiftVM
            {
                id = shift.id,
                name = shift.name,
                description = shift.description,
                starttime = shift.starttime,
                endtime = shift.endtime,
                remark = shift.remark,
                paeprefix = shift.paeprefix,
                phpprefix = shift.phpprefix,
                prrprefix = shift.prrprefix,
                saiprefix = shift.saiprefix,
                shsprefix = shift.shsprefix,
                sivprefix = shift.sivprefix,

                shift = shift
            };

            return s;
        }

        public static List<shiftVM> ToViewModel(this IEnumerable<shift> shift_lsit)
        {
            List<shiftVM> s = new List<shiftVM>();
            foreach (var shift in shift_lsit)
            {
                s.Add(shift.ToViewModel());
            }

            return s;
        }

        public static tankVM ToViewModel(this tank tank)
        {
            if (tank == null)
                return null;

            tankVM t = new tankVM
            {
                id = tank.id,
                name = tank.name,
                description = tank.description,
                remark = tank.remark,
                isactive = tank.isactive,
                tank = tank
            };

            return t;
        }

        public static List<tankVM> ToViewModel(this IEnumerable<tank> tank_list)
        {
            List<tankVM> t = new List<tankVM>();
            foreach (var tank in tank_list)
            {
                t.Add(tank.ToViewModel());
            }

            return t;
        }

        public static sectionVM ToViewModel(this section section)
        {
            if (section == null)
                return null;

            sectionVM s = new sectionVM
            {
                id = section.id,
                name = section.name,
                begbal = section.begbal,
                loccod = section.loccod,
                tank_id = section.tank_id,
                stmas_id = section.stmas_id,
                section = section,
            };

            return s;
        }

        public static List<sectionVM> ToViewModel(this IEnumerable<section> section_list)
        {
            List<sectionVM> s = new List<sectionVM>();
            foreach (var item in section_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static nozzleVM ToViewModel(this nozzle nozzle)
        {
            if (nozzle == null)
                return null;

            nozzleVM n = new nozzleVM
            {
                id = nozzle.id,
                name = nozzle.name,
                description = nozzle.description,
                remark = nozzle.remark,
                isactive = nozzle.isactive,
                nozzle = nozzle
            };

            return n;
        }

        public static List<nozzleVM> ToViewModel(this IEnumerable<nozzle> nozzle_list)
        {
            List<nozzleVM> n = new List<nozzleVM>();
            foreach (var nozzle in nozzle_list)
            {
                n.Add(nozzle.ToViewModel());
            }

            return n;
        }

        public static stmasVM ToViewModel(this stmas stmas)
        {
            if (stmas == null)
                return null;

            stmasVM s = new stmasVM
            {
                id = stmas.id,
                name = stmas.name,
                description = stmas.description,
                remark = stmas.remark,
                stmas = stmas
            };

            return s;
        }

        public static List<stmasVM> ToViewModel(this IEnumerable<stmas> stmas_list)
        {
            List<stmasVM> s = new List<stmasVM>();
            foreach (var stmas in stmas_list)
            {
                s.Add(stmas.ToViewModel());
            }

            return s;
        }

        public static stmasPriceVM ToPriceViewModel(this stmasVM stmas_vm)
        {
            if (stmas_vm == null)
                return null;

            stmasPriceVM s = new stmasPriceVM
            {
                price_id = stmas_vm.price_id,
                stmas_id = stmas_vm.id,
                price_date = stmas_vm.price_date,
                unitpr = stmas_vm.unitpr
            };

            return s;
        }

        public static List<stmasPriceVM> ToPriceViewModel(this IEnumerable<stmasVM> stmas_vm_list)
        {
            List<stmasPriceVM> s = new List<stmasPriceVM>();
            foreach (var stmas_vm in stmas_vm_list)
            {
                s.Add(stmas_vm.ToPriceViewModel());
            }

            return s;
        }
        
        public static pricelistVM ToViewModel(this pricelist price)
        {
            if (price == null)
                return null;

            pricelistVM p = new pricelistVM
            {
                id = price.id,
                unitpr = price.unitpr,
                stmas_id = price.stmas_id,
            };
            return p;
        }

        public static List<pricelistVM> ToViewModel(this IEnumerable<pricelist> pricelist)
        {
            List<pricelistVM> p = new List<pricelistVM>();

            foreach (var item in pricelist)
            {
                p.Add(item.ToViewModel());
            }

            return p;
        }

        public static salessummaryVM ToViewModel(this salessummary sales)
        {
            if (sales == null)
                return null;

            salessummaryVM s = new salessummaryVM
            {
                id = sales.id,
                saldat = sales.saldat,
                dtest = sales.dtest,
                dother = sales.dother,
                dothertxt = sales.dothertxt,
                ddisc = sales.ddisc,
                purvat = sales.purvat,
                shift_id = sales.shift_id,
                stmas_id = sales.stmas_id,
                pricelist_id = sales.pricelist_id,
                shiftsales_id = sales.shiftsales_id,
                salessummary = sales
            };

            return s;
        }

        public static List<salessummaryVM> ToViewModel(this IEnumerable<salessummary> sales_list)
        {
            List<salessummaryVM> s = new List<salessummaryVM>();
            foreach (var item in sales_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
        }

        public static saleshistoryVM ToViewModel(this saleshistory saleshistory)
        {
            if (saleshistory == null)
                return null;

            saleshistoryVM s = new saleshistoryVM
            {
                id = saleshistory.id,
                saldat = saleshistory.saldat,
                mitbeg = saleshistory.mitbeg,
                mitend = saleshistory.mitend,
                salqty = saleshistory.salqty,
                salval = saleshistory.salval,
                shift_id = saleshistory.shift_id,
                nozzle_id = saleshistory.nozzle_id,
                stmas_id = saleshistory.stmas_id,
                pricelist_id = saleshistory.pricelist_id,
                salessummary_id = saleshistory.salessummary_id,
                saleshistory = saleshistory
            };

            return s;
        }

        public static List<saleshistoryVM> ToViewModel(this IEnumerable<saleshistory> saleshistory_list)
        {
            List<saleshistoryVM> s = new List<saleshistoryVM>();
            foreach (var item in saleshistory_list)
            {
                s.Add(item.ToViewModel());
            }

            return s;
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

        public static List<SccompDbf> ToSccompList(this DataTable sccomp_dbf)
        {
            List<SccompDbf> sccomp = new List<SccompDbf>();

            foreach (DataRow row in sccomp_dbf.Rows)
            {
                try
                {
                    SccompDbf s = new SccompDbf
                    {
                        compnam = row.Field<string>("compnam").Trim(),
                        compcod = row.Field<string>("compcod").Trim(),
                        path = row.Field<string>("path").Trim(),
                        gendat = row.Field<DateTime?>("gendat"),
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
                        docnum = row.Field<string>("docnum"),
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
                        docnum = row.Field<string>("docnum"),
                        docdat = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("docdat") : null,
                        refnum = row.Field<string>("refnum"),
                        vatprd = !row.IsNull("docdat") ? (DateTime?)row.Field<DateTime>("vatprd") : null,
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
                        prntim = row.Field<string>("prntim"),
                        authid = row.Field<string>("authid"),
                        approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
                        billbe = row.Field<string>("billbe"),
                        orgnum = row.Field<decimal>("orgnum")
                    };

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
                        docnum = row.Field<string>("docnum"),
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
                        prntim = row.Field<string>("prntim"),
                        authid = row.Field<string>("authid"),
                        approve = !row.IsNull("approve") ? (DateTime?)row.Field<DateTime>("approve") : null,
                        billto = row.Field<string>("billto"),
                        orgnum = row.Field<decimal>("orgnum")
                    };

                    artrn.Add(a);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return artrn;
        }

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

        public static StlocDbfVM ToViewModel(this StlocDbf stlocdbf)
        {
            if (stlocdbf == null)
                return null;

            StlocDbfVM s = new StlocDbfVM
            {
                stkcod = stlocdbf.stkcod.Trim(),
                loccod = stlocdbf.loccod.Trim()
            };

            return s;
        }

        public static List<StlocDbfVM> ToViewModel(this IEnumerable<StlocDbf> stlocdbf_list)
        {
            List<StlocDbfVM> s = new List<StlocDbfVM>();
            foreach (var item in stlocdbf_list)
            {
                s.Add(item.ToViewModel());
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

        public static IsinfoDbfVM ToViewModel(this IsinfoDbf isinfodbf)
        {
            if (isinfodbf == null)
                return null;

            IsinfoDbfVM i = new IsinfoDbfVM
            {
                compnam = isinfodbf.thinam.Trim(),
                addr = isinfodbf.addr01.Trim() + " " + isinfodbf.addr02.Trim(),
                telnum = isinfodbf.telnum.Trim(),
                taxid = isinfodbf.taxid.Trim()
            };

            return i;
        }

        public static void SetControlState(this Component comp, FORM_MODE[] form_mode_to_enable, FORM_MODE form_mode)
        {
            if (form_mode_to_enable.ToList().Where(fm => fm == form_mode).Count() > 0)
            {
                if (comp is ToolStripButton)
                {
                    ((ToolStripButton)comp).Enabled = true; return;
                }
                if(comp is ToolStripSplitButton)
                {
                    ((ToolStripSplitButton)comp).Enabled = true; return;
                }
                if(comp is ToolStripDropDownButton)
                {
                    ((ToolStripDropDownButton)comp).Enabled = true; return;
                }
                if(comp is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)comp).Enabled = true; return;
                }
                if(comp is TabControl)
                {
                    ((TabControl)comp).Enabled = true; return;
                }
                if(comp is Button)
                {
                    ((Button)comp).Enabled = true; return;
                }
                if (comp is DataGridView)
                {
                    ((DataGridView)comp).Enabled = true; return;
                }
                if (comp is XTextEdit)
                {
                    ((XTextEdit)comp)._ReadOnly = false; return;
                }
                if(comp is XDropdownList)
                {
                    ((XDropdownList)comp)._ReadOnly = false; return;
                }
                if(comp is XDatePicker)
                {
                    ((XDatePicker)comp)._ReadOnly = false; return;
                }
                if(comp is XBrowseBox)
                {
                    ((XBrowseBox)comp)._ReadOnly = false; return;
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

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else if(ex is ArgumentNullException)
            {
                if(ex.Message.ToLower().Contains("value cannot be null") && ex.StackTrace.ToLower().Contains(".remove("))
                {
                    MessageBox.Show(string.Format("{0} \"{1}\" ไม่มีอยู่ในระบบ, อาจมีผู้ใช้รายอื่นลบออกไปแล้ว", exception_key, exception_value));
                    return;
                }
            }

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
