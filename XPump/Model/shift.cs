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
    
    public partial class shift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public shift()
        {
            this.saleshistory = new HashSet<saleshistory>();
            this.salessummary = new HashSet<salessummary>();
            this.shiftsales = new HashSet<shiftsales>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.TimeSpan starttime { get; set; }
        public System.TimeSpan endtime { get; set; }
        public string remark { get; set; }
        public string saiprefix { get; set; }
        public string shsprefix { get; set; }
        public string sivprefix { get; set; }
        public string paeprefix { get; set; }
        public string phpprefix { get; set; }
        public string prrprefix { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<saleshistory> saleshistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<salessummary> salessummary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shiftsales> shiftsales { get; set; }
    }
}
