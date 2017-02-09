using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPump.Model
{
    public class StmasDbf
    {
        public string stkcod { get; set; }
        public string stkdes { get; set; }
        public string stkdes2 { get; set; }
        public string stktyp { get; set; }
        public string stklev { get; set; }
        public string stkgrp { get; set; }
        public string barcod { get; set; }
        public string stkcods { get; set; }
        public string acccod { get; set; }
        public string isinv { get; set; }
        public string stkclass { get; set; }
        public string negallow { get; set; }
        public string qucod { get; set; }
        public string cqucod { get; set; }
        public double cfactor { get; set; }
        public double stnpr { get; set; }
        public string ispur { get; set; }
        public string pqucod { get; set; }
        public double pfactor { get; set; }
        public string lpurqu { get; set; }
        public double lpurfac { get; set; }
        public double lpurpr { get; set; }
        public string lpdisc { get; set; }
        public DateTime? lpurdat { get; set; }
        public string supcod { get; set; }
        public string issal { get; set; }
        public string squcod { get; set; }
        public double sfactor { get; set; }
        public double sellpr1 { get; set; }
        public double sellpr2 { get; set; }
        public double sellpr3 { get; set; }
        public double sellpr4 { get; set; }
        public double sellpr5 { get; set; }
        public string tracksal { get; set; }
        public string vatcod { get; set; }
        public string iscom { get; set; }
        public string comrat { get; set; }
        public string lsellqu { get; set; }
        public double lsellfac { get; set; }
        public double lsellpr { get; set; }
        public string lsdisc { get; set; }
        public DateTime? lseldat { get; set; }
        public decimal? numelem { get; set; }
        public double totbal { get; set; }
        public double totval { get; set; }
        public double totreo { get; set; }
        public double totres { get; set; }
        public double opnbal { get; set; }
        public double unitpr { get; set; }
        public double opnval { get; set; }
        public DateTime? lasupd { get; set; }
        public string packing { get; set; }
        public string mlotnum { get; set; }
        public double mrembal { get; set; }
        public double mremval { get; set; }
        public string remark { get; set; }
        public DateTime? dat1 { get; set; }
        public DateTime? dat2 { get; set; }
        public double num1 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
        public string str3 { get; set; }
        public string str4 { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }

    }

    public class SccompDbf
    {
        public string compnam { get; set; }
        public string compcod { get; set; }
        public string path { get; set; }
        public DateTime? gendat { get; set; }
        public string candel { get; set; }

    }
}
