﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kuaforsln.Models;

#nullable disable

namespace kuaforsln.Migrations
{
    [DbContext(typeof(BerberWebContext))]
    [Migration("20241228193323_UzmanFix")]
    partial class UzmanFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("kuaforsln.Models.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amac")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hakkinda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vizyon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("kuaforsln.Models.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ResimAciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResimId")
                        .HasColumnType("int");

                    b.Property<int>("ResimKullaniciKullaniciID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ResimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResimYol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResimKullaniciKullaniciID");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("kuaforsln.Models.Iletisim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Iletisim");
                });

            modelBuilder.Entity("kuaforsln.Models.IletisimForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IletisimForm");
                });

            modelBuilder.Entity("kuaforsln.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TamAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YetkiId")
                        .HasColumnType("int");

                    b.HasKey("KullaniciID");

                    b.HasIndex("YetkiId");

                    b.ToTable("Kullanici");

                    b.HasData(
                        new
                        {
                            KullaniciID = 1,
                            Adres = "BURSA",
                            Email = "scbr@scbr.com",
                            KullaniciAdi = "admin",
                            Sifre = "admin",
                            TamAdi = "SC",
                            Telefon = "5555555",
                            YetkiId = 1
                        },
                        new
                        {
                            KullaniciID = 2,
                            Adres = "BURSA",
                            Email = "scbr@scbr.com",
                            KullaniciAdi = "username",
                            Sifre = "12345",
                            TamAdi = "SemihC",
                            Telefon = "5555555",
                            YetkiId = 2
                        });
                });

            modelBuilder.Entity("kuaforsln.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RandevuTarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("UzmanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.HasIndex("UzmanId");

                    b.ToTable("Randevu");
                });

            modelBuilder.Entity("kuaforsln.Models.Uzman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<string>("UzmanAlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Uzman");
                });

            modelBuilder.Entity("kuaforsln.Models.Yetki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yetki");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleAdi = "admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleAdi = "user"
                        });
                });

            modelBuilder.Entity("kuaforsln.Models.Gallery", b =>
                {
                    b.HasOne("kuaforsln.Models.Kullanici", "ResimKullanici")
                        .WithMany("Gallery")
                        .HasForeignKey("ResimKullaniciKullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResimKullanici");
                });

            modelBuilder.Entity("kuaforsln.Models.Kullanici", b =>
                {
                    b.HasOne("kuaforsln.Models.Yetki", "Yetki")
                        .WithMany("Kullanici")
                        .HasForeignKey("YetkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Yetki");
                });

            modelBuilder.Entity("kuaforsln.Models.Randevu", b =>
                {
                    b.HasOne("kuaforsln.Models.Kullanici", "Kullanici")
                        .WithMany("Randevu")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kuaforsln.Models.Uzman", "Uzman")
                        .WithMany("Randevu")
                        .HasForeignKey("UzmanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Uzman");
                });

            modelBuilder.Entity("kuaforsln.Models.Uzman", b =>
                {
                    b.HasOne("kuaforsln.Models.Kullanici", "Kullanici")
                        .WithMany("Uzman")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("kuaforsln.Models.Kullanici", b =>
                {
                    b.Navigation("Gallery");

                    b.Navigation("Randevu");

                    b.Navigation("Uzman");
                });

            modelBuilder.Entity("kuaforsln.Models.Uzman", b =>
                {
                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("kuaforsln.Models.Yetki", b =>
                {
                    b.Navigation("Kullanici");
                });
#pragma warning restore 612, 618
        }
    }
}
