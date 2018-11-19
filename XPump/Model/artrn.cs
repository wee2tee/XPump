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
    
    public partial class artrn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public artrn()
        {
            this.arrcpcq = new HashSet<arrcpcq>();
            this.stcrd = new HashSet<stcrd>();

            this.advamt = 0;
            this.advnum = "";
            this.aftdisc = 0;
            this.amount = 0;
            this.amtrat0 = 0;
            this.approve = null;
            this.areacod = string.Empty;
            this.authid = string.Empty;
            this.beftax = 0;
            this.billto = string.Empty;
            this.bilnum = string.Empty;
            this.chgdat = DateTime.Now;
            this.chqpas = 0;
            this.chqrcv = 0;
            this.cmplapp = "N";
            this.cmpldat = null;
            this.cntyp = string.Empty;
            this.comamt = 0;
            this.creby = string.Empty;
            this.credat = DateTime.Now;
            this.cshrcv = 0;
            this.cuscod = string.Empty;
            this.c_advamt = 0;
            this.c_aftdisc = 0;
            this.c_amount = 0;
            this.c_date = null;
            this.c_difamt = 0;
            this.c_disc = string.Empty;
            this.c_discamt = 0;
            this.c_fixrate = string.Empty;
            this.c_ivcamt = 0;
            this.c_netamt = 0;
            this.c_netval = 0;
            this.c_rate = 0;
            this.c_ratio = 0;
            this.c_rcvamt = 0;
            this.c_ref = string.Empty;
            this.c_remamt = 0;
            this.c_total = 0;
            this.c_type = string.Empty;
            this.dat1 = null;
            this.dat2 = null;
            this.depcod = string.Empty;
            this.disc = string.Empty;
            this.discamt = 0;
            this.dlvby = string.Empty;
            this.docdat = DateTime.Now;
            this.docnum = string.Empty;
            this.docstat = string.Empty;
            this.duedat = DateTime.Now;
            this.flgvat = string.Empty;
            this.id = -1;
            this.intrcv = 0;
            this.ivcamt = 0;
            this.link1 = string.Empty;
            this.netamt = 0;
            this.netval = 0;
            this.num1 = 0;
            this.num2 = 0;
            this.nxtseq = string.Empty;
            this.orgnum = 0;
            this.paytrm = 0;
            this.ponum = string.Empty;
            this.postgl = string.Empty;
            this.prncnt = 0;
            this.prndat = null;
            this.rcvamt = 0;
            this.rectyp = string.Empty;
            this.remamt = 0;
            this.reserve = null;
            this.shipto = string.Empty;
            this.slmcod = string.Empty;
            this.sonum = string.Empty;
            this.srv_vattyp = string.Empty;
            this.str1 = string.Empty;
            this.str2 = string.Empty;
            this.tax = 0;
            this.taxcond = string.Empty;
            this.taxrat = 0;
            this.total = 0;
            this.userid = string.Empty;
            this.userprn = string.Empty;
            this.vatamt = 0;
            this.vatdat = null;
            this.vatlate = string.Empty;
            this.vatprd = null;
            this.vatrat = 0;
            this.youref = string.Empty;
        }
    
        public int id { get; set; }
        public string rectyp { get; set; }
        public string docnum { get; set; }
        public System.DateTime docdat { get; set; }
        public string postgl { get; set; }
        public string sonum { get; set; }
        public string cntyp { get; set; }
        public string depcod { get; set; }
        public string flgvat { get; set; }
        public string slmcod { get; set; }
        public string cuscod { get; set; }
        public string shipto { get; set; }
        public string youref { get; set; }
        public string areacod { get; set; }
        public int paytrm { get; set; }
        public System.DateTime duedat { get; set; }
        public string bilnum { get; set; }
        public string nxtseq { get; set; }
        public decimal amount { get; set; }
        public string disc { get; set; }
        public decimal discamt { get; set; }
        public decimal aftdisc { get; set; }
        public string advnum { get; set; }
        public decimal advamt { get; set; }
        public decimal total { get; set; }
        public decimal amtrat0 { get; set; }
        public decimal vatrat { get; set; }
        public decimal vatamt { get; set; }
        public decimal netamt { get; set; }
        public decimal netval { get; set; }
        public decimal rcvamt { get; set; }
        public decimal remamt { get; set; }
        public decimal comamt { get; set; }
        public string cmplapp { get; set; }
        public Nullable<System.DateTime> cmpldat { get; set; }
        public string docstat { get; set; }
        public decimal cshrcv { get; set; }
        public decimal chqrcv { get; set; }
        public decimal intrcv { get; set; }
        public decimal beftax { get; set; }
        public decimal taxrat { get; set; }
        public string taxcond { get; set; }
        public decimal tax { get; set; }
        public decimal ivcamt { get; set; }
        public decimal chqpas { get; set; }
        public Nullable<System.DateTime> vatdat { get; set; }
        public Nullable<System.DateTime> vatprd { get; set; }
        public string vatlate { get; set; }
        public string srv_vattyp { get; set; }
        public string dlvby { get; set; }
        public Nullable<System.DateTime> reserve { get; set; }
        public string creby { get; set; }
        public System.DateTime credat { get; set; }
        public string userid { get; set; }
        public System.DateTime chgdat { get; set; }
        public string userprn { get; set; }
        public Nullable<System.DateTime> prndat { get; set; }
        public int prncnt { get; set; }
        public string authid { get; set; }
        public Nullable<System.DateTime> approve { get; set; }
        public string ponum { get; set; }
        public string billto { get; set; }
        public int orgnum { get; set; }
        public string c_type { get; set; }
        public Nullable<System.DateTime> c_date { get; set; }
        public string c_ref { get; set; }
        public decimal c_rate { get; set; }
        public string c_fixrate { get; set; }
        public decimal c_ratio { get; set; }
        public decimal c_amount { get; set; }
        public string c_disc { get; set; }
        public decimal c_discamt { get; set; }
        public decimal c_aftdisc { get; set; }
        public decimal c_advamt { get; set; }
        public decimal c_total { get; set; }
        public decimal c_netamt { get; set; }
        public decimal c_netval { get; set; }
        public decimal c_ivcamt { get; set; }
        public decimal c_difamt { get; set; }
        public decimal c_rcvamt { get; set; }
        public decimal c_remamt { get; set; }
        public string link1 { get; set; }
        public Nullable<System.DateTime> dat1 { get; set; }
        public Nullable<System.DateTime> dat2 { get; set; }
        public decimal num1 { get; set; }
        public decimal num2 { get; set; }
        public string str1 { get; set; }
        public string str2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<arrcpcq> arrcpcq { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stcrd> stcrd { get; set; }
    }
}
