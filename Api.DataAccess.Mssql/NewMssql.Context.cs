﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.DataAccess.Mssql
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class checklistEntities : DbContext
    {
        public checklistEntities()
            : base("name=checklistEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblList> tblList { get; set; }
        public virtual DbSet<tblListTipo> tblListTipo { get; set; }
        public virtual DbSet<tblUsuario> tblUsuario { get; set; }
    }
}