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
    
    public partial class tank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tank()
        {
            this.section = new HashSet<section>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string remark { get; set; }
        public string creby { get; set; }
        public System.DateTime cretime { get; set; }
        public string chgby { get; set; }
        public Nullable<System.DateTime> chgtime { get; set; }
        public int tanksetup_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<section> section { get; set; }
        public virtual tanksetup tanksetup { get; set; }
    }
}
