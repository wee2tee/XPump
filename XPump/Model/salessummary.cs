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
    
    public partial class salessummary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public salessummary()
        {
            this.saleshistory = new HashSet<saleshistory>();
        }
    
        public int id { get; set; }
        public System.DateTime saldat { get; set; }
        public decimal total { get; set; }
        public decimal dtest { get; set; }
        public decimal dother { get; set; }
        public string dothertxt { get; set; }
        public decimal totqty { get; set; }
        public decimal totval { get; set; }
        public decimal ddisc { get; set; }
        public decimal netval { get; set; }
        public decimal salvat { get; set; }
        public decimal purvat { get; set; }
        public int shift_id { get; set; }
        public int stmas_id { get; set; }
        public int pricelist_id { get; set; }
        public int shiftsales_id { get; set; }
    
        public virtual pricelist pricelist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saleshistory> saleshistory { get; set; }
        public virtual shift shift { get; set; }
        public virtual shiftsales shiftsales { get; set; }
        public virtual stmas stmas { get; set; }
    }
}
