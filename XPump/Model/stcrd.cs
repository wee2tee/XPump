//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XPump.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class stcrd
    {
        public stcrd()
        {
            this.accchgcr = string.Empty;
            this.accchgdr = string.Empty;
            this.accnumcr = string.Empty;
            this.accnumdr = string.Empty;
            this.approve = null;
            this.authid = string.Empty;
            this.balchg = 0;
            this.billxx = string.Empty;
            this.chgdat = DateTime.Now;
            this.coscod = string.Empty;
            this.creby = string.Empty;
            this.credat = DateTime.Now;
            this.c_disc = string.Empty;
            this.c_discamt = 0;
            this.c_netval = 0;
            this.c_trnval = 0;
            this.c_unitpr = 0;
            this.depcod = string.Empty;
            this.disc = string.Empty;
            this.discamt = 0;
            this.docdat = DateTime.Now;
            this.docnum = string.Empty;
            this.flag = string.Empty;
            this.free = string.Empty;
            this.id = -1;
            this.ispi = string.Empty;
            this.jobcod = string.Empty;
            this.loccod = string.Empty;
            this.lotbal = 0;
            this.lotseq = string.Empty;
            this.lotval = 0;
            this.lot_qty = 0;
            this.lot_val = 0;
            this.lunitpr = 0;
            this.mlotnum = string.Empty;
            this.mrembal = 0;
            this.mremval = 0;
            this.netval = 0;
            this.old_status = string.Empty;
            this.packing = string.Empty;
            this.people = string.Empty;
            this.phase = string.Empty;
            this.phybal = 0;
            this.posopr = string.Empty;
            this.pstkcod = string.Empty;
            this.rdocnum = string.Empty;
            this.refnum = string.Empty;
            this.reimburse = string.Empty;
            this.retqty = 0;
            this.retstk = string.Empty;
            this.retval = 0;
            this.seqnum = string.Empty;
            this.slmcod = string.Empty;
            this.status = string.Empty;
            this.stkcod = string.Empty;
            this.stkdes = string.Empty;
            this.tfactor = 0;
            this.tqucod = string.Empty;
            this.trnqty = 0;
            this.trnval = 0;
            this.unitpr = 0;
            this.userid = string.Empty;
            this.valchg = 0;
            this.vatcod = string.Empty;
            this.vatgrp = string.Empty;
            this.warmonth = 0;
            this.xaccnum = string.Empty;
            this.xcoscod = string.Empty;
            this.xdepcod = string.Empty;
            this.xjobcod = string.Empty;
            this.xphase = string.Empty;
            this.xsalval = 0;
            this.xtrnqty = 0;
            this.xtrnval = 0;
            this.xunitpr = 0;
        }

        public int id { get; set; }
        public string stkcod { get; set; }
        public string loccod { get; set; }
        public string docnum { get; set; }
        public string seqnum { get; set; }
        public System.DateTime docdat { get; set; }
        public string rdocnum { get; set; }
        public string refnum { get; set; }
        public string depcod { get; set; }
        public string posopr { get; set; }
        public string free { get; set; }
        public string vatcod { get; set; }
        public string people { get; set; }
        public string slmcod { get; set; }
        public string flag { get; set; }
        public decimal trnqty { get; set; }
        public string tqucod { get; set; }
        public decimal tfactor { get; set; }
        public decimal unitpr { get; set; }
        public string disc { get; set; }
        public decimal discamt { get; set; }
        public decimal trnval { get; set; }
        public decimal phybal { get; set; }
        public string retstk { get; set; }
        public decimal xtrnqty { get; set; }
        public decimal xunitpr { get; set; }
        public decimal xtrnval { get; set; }
        public decimal xsalval { get; set; }
        public decimal netval { get; set; }
        public string mlotnum { get; set; }
        public decimal mrembal { get; set; }
        public decimal mremval { get; set; }
        public decimal balchg { get; set; }
        public decimal valchg { get; set; }
        public decimal lotbal { get; set; }
        public decimal lotval { get; set; }
        public decimal lunitpr { get; set; }
        public string pstkcod { get; set; }
        public string accnumdr { get; set; }
        public string accnumcr { get; set; }
        public string stkdes { get; set; }
        public string packing { get; set; }
        public string jobcod { get; set; }
        public string phase { get; set; }
        public string coscod { get; set; }
        public string reimburse { get; set; }
        public string creby { get; set; }
        public System.DateTime credat { get; set; }
        public string userid { get; set; }
        public System.DateTime chgdat { get; set; }
        public string authid { get; set; }
        public Nullable<System.DateTime> approve { get; set; }
        public string xcoscod { get; set; }
        public string xdepcod { get; set; }
        public string xjobcod { get; set; }
        public string xphase { get; set; }
        public string xaccnum { get; set; }
        public string accchgdr { get; set; }
        public string accchgcr { get; set; }
        public string ispi { get; set; }
        public string vatgrp { get; set; }
        public decimal lot_qty { get; set; }
        public decimal lot_val { get; set; }
        public decimal warmonth { get; set; }
        public string status { get; set; }
        public string old_status { get; set; }
        public decimal c_unitpr { get; set; }
        public string c_disc { get; set; }
        public decimal c_discamt { get; set; }
        public decimal c_trnval { get; set; }
        public decimal c_netval { get; set; }
        public string lotseq { get; set; }
        public string billxx { get; set; }
        public decimal retqty { get; set; }
        public decimal retval { get; set; }
        public Nullable<int> artrn_id { get; set; }
    
        public virtual artrn artrn { get; set; }
    }
}