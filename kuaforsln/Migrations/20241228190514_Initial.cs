using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kuaforsln.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vizyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hakkinda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yetki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TamAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanici_Yetki_YetkiId",
                        column: x => x.YetkiId,
                        principalTable: "Yetki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimYol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResimId = table.Column<int>(type: "int", nullable: false),
                    ResimKullaniciKullaniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gallery_Kullanici_ResimKullaniciKullaniciID",
                        column: x => x.ResimKullaniciKullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uzman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    UzmanAlan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzman_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    UzmanId = table.Column<int>(type: "int", nullable: false),
                    RandevuTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevu_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_Uzman_UzmanId",
                        column: x => x.UzmanId,
                        principalTable: "Uzman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Yetki",
                columns: new[] { "Id", "RoleAdi" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Kullanici",
                columns: new[] { "KullaniciID", "Adres", "Email", "KullaniciAdi", "Sifre", "TamAdi", "Telefon", "YetkiId" },
                values: new object[,]
                {
                    { 1, "BURSA", "scbr@scbr.com", "admin", "admin", "SC", "5555555", 1 },
                    { 2, "BURSA", "scbr@scbr.com", "username", "12345", "SemihC", "5555555", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_ResimKullaniciKullaniciID",
                table: "Gallery",
                column: "ResimKullaniciKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_YetkiId",
                table: "Kullanici",
                column: "YetkiId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_KullaniciId",
                table: "Randevu",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_UzmanId",
                table: "Randevu",
                column: "UzmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzman_KullaniciId",
                table: "Uzman",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "IletisimForm");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Uzman");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Yetki");
        }
    }
}
