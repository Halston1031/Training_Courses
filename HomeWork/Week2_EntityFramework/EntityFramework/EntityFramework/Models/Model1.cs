using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace EntityFramework.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
        }

        public virtual DbSet<ItemsTable> ItemsTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsTable>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<ItemsTable>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ItemsTable>()
                .Property(e => e.Type)
                .IsFixedLength();
        }
    }
}
