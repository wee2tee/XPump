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
    
    public partial class dayend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dayend()
        {
            this.daysttak = new HashSet<daysttak>();
        }
    
        public int id { get; set; }
        public System.DateTime saldat { get; set; }
        public decimal rcvqty { get; set; }
        public decimal salqty { get; set; }
        public Nullable<int> dothercause_id { get; set; }
        public decimal dother { get; set; }
        public decimal difqty { get; set; }
        public int stmas_id { get; set; }
        public string creby { get; set; }
        public System.DateTime cretime { get; set; }
        public string chgby { get; set; }
        public Nullable<System.DateTime> chgtime { get; set; }
        public string apprby { get; set; }
        public Nullable<System.DateTime> apprtime { get; set; }
    
        public virtual istab istab { get; set; }
        public virtual stmas stmas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<daysttak> daysttak { get; set; }
    }
}
