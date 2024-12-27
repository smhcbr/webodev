using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using kuaforsln.Models;

namespace kuaforsln.Models
{
    public partial class BerberWebContext : DbContext
    {
        public BerberWebContext()
        {
        }

        public BerberWebContext(DbContextOptions<BerberWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Randevu> Randevu { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        public virtual DbSet<IletisimForm> IletisimForm { get; set; }
        public virtual DbSet<Uzman> Uzman { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .HasData(new Kullanici
                {
                    KullaniciID = 1,
                    KullaniciAdi = "admin",
                    Sifre = "admin",
                    TamAdi = "SC",
                    Email = "scbr@scbr.com",
                    Telefon = "5555555",
                    Adres = "BURSA",
                    YetkiId = 1
                },
                new Kullanici
                {
                    KullaniciID = 2,
                    KullaniciAdi = "username",
                    Sifre = "12345",
                    TamAdi = "SemihC",
                    Email = "scbr@scbr.com",
                    Telefon = "5555555",
                    Adres = "BURSA",
                    YetkiId = 2
                });

            modelBuilder.Entity<Yetki>()
                .HasData(new Yetki
                {
                    Id = 1,
                    RoleAdi = "admin"
                },
                new Yetki()
                {
                    Id = 2,
                    RoleAdi = "user"
                });

        }
    }
}
