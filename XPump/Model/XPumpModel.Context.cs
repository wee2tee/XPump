﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class xpumpEntities : DbContext
    {
        public xpumpEntities()
            : base("name=xpumpEntities")
        {
        }
    
        public xpumpEntities(string connection_string)
            : base(connection_string)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<apmas> apmas { get; set; }
        public virtual DbSet<aptrn> aptrn { get; set; }
        public virtual DbSet<nozzle> nozzle { get; set; }
        public virtual DbSet<pricelist> pricelist { get; set; }
        public virtual DbSet<saleshistory> saleshistory { get; set; }
        public virtual DbSet<salessummary> salessummary { get; set; }
        public virtual DbSet<section> section { get; set; }
        public virtual DbSet<settings> settings { get; set; }
        public virtual DbSet<shift> shift { get; set; }
        public virtual DbSet<shiftsales> shiftsales { get; set; }
        public virtual DbSet<stcrd> stcrd { get; set; }
        public virtual DbSet<stmas> stmas { get; set; }
        public virtual DbSet<tank> tank { get; set; }
    }
}
