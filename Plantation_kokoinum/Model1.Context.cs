﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plantation_kokoinum
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class Plantation_DBEntities : DbContext
    {
        public Plantation_DBEntities()
            : base("name=Plantation_DBEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Culture_table> Culture_tables { get; set; }
        public virtual DbSet<Districts_table> Districts_tables { get; set; }
        public virtual DbSet<Productivity_table> Productivity_tables { get; set; }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        private static Plantation_DBEntities _context;

        public static Plantation_DBEntities GetContext()
        {
            if (_context == null)
            {
                _context = new Plantation_DBEntities();
            }
            return _context;
        }
    }
}
