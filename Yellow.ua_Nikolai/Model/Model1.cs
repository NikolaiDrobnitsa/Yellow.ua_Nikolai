using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Yellow.ua_Nikolai.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Yellow> Yellows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yellow>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Yellow>()
                .Property(e => e.Info)
                .IsUnicode(false);

            modelBuilder.Entity<Yellow>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
