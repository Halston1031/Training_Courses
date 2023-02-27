using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityFramework
{
    public partial class Models : DbContext
    {
        public Models()
            : base("name=Models")
        {
        }

        public virtual DbSet<ItemTable> ItemTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemTable>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
