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
    
    public partial class scmodul
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public scmodul()
        {
            this.scacclv = new HashSet<scacclv>();
        }
    
        public int id { get; set; }
        public string modcod { get; set; }
        public string description { get; set; }
        public string description_en { get; set; }
        public string p_modcod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scacclv> scacclv { get; set; }
    }
}
