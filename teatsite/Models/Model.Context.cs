﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace teatsite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class att_khovd_drama_dbEntities : DbContext
    {
        public att_khovd_drama_dbEntities()
            : base("name=att_khovd_drama_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<tComment> tComment { get; set; }
        public DbSet<tMenu> tMenu { get; set; }
        public DbSet<tNews> tNews { get; set; }
        public DbSet<tSubmenu> tSubmenu { get; set; }
    }
}