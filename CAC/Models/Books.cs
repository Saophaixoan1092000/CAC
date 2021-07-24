using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CAC.Models
{
    public partial class Books : DbContext
    {
        public Books()
            : base("name=Books")
        {
        }

        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Tacgia> Tacgias { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sach>()
                .Property(e => e.Hinh)
                .IsFixedLength();

            modelBuilder.Entity<Sach>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tacgia>()
                .HasMany(e => e.Saches)
                .WithOptional(e => e.Tacgia1)
                .HasForeignKey(e => e.Tacgia);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.Saches)
                .WithOptional(e => e.TheLoai1)
                .HasForeignKey(e => e.Theloai);
        }
    }
}
