using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kuaforsln.Migrations
{
    /// <inheritdoc />
    public partial class UzmanFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzman_Kullanici_KullaniciId",
                table: "Uzman");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Uzman",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzman_Kullanici_KullaniciId",
                table: "Uzman",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "KullaniciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzman_Kullanici_KullaniciId",
                table: "Uzman");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciId",
                table: "Uzman",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzman_Kullanici_KullaniciId",
                table: "Uzman",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
