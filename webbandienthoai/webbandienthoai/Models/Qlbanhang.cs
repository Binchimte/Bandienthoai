using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace webbandienthoai.Models
{
    public partial class Qlbanhang : DbContext
    {
        public Qlbanhang()
            : base("name=Qlbanhang")
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<DonHang> Donhangs { get; set; }
        public virtual DbSet<Hangsanxuat> Hangsanxuats { get; set; }
        public virtual DbSet<Hedieuhanh> Hedieuhanhs { get; set; }
        public virtual DbSet<NguoiDung> Nguoidungs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.Chitietdonhang)
                .WithRequired(e => e.Donhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hangsanxuat>()
                .Property(e => e.Tenhang)
                .IsFixedLength();

            modelBuilder.Entity<Hedieuhanh>()
                .Property(e => e.Tenhdh)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giatien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Chitietdonhang)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);
        }
    }
}
