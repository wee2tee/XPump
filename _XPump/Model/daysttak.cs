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
    
    public partial class daysttak
    {
        public int id { get; set; }
        public decimal takqty { get; set; }
        public decimal begbal { get; set; }
        public decimal begdif { get; set; }
        public decimal rcvqty { get; set; }
        public decimal salqty { get; set; }
        public int dayend_id { get; set; }
        public int section_id { get; set; }
        public string creby { get; set; }
        public System.DateTime cretime { get; set; }
        public string chgby { get; set; }
        public Nullable<System.DateTime> chgtime { get; set; }
    
        public virtual dayend dayend { get; set; }
        public virtual section section { get; set; }
    }
}
