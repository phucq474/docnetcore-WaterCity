using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyHoaDon_HoaDon_HoaDonId",
                table: "NhatKyHoaDon");

            migrationBuilder.DropColumn(
                name: "MaTuyen",
                table: "TuyenDoc");

            migrationBuilder.AlterColumn<string>(
                name: "HoaDonId",
                table: "NhatKyHoaDon",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyHoaDon_HoaDon_HoaDonId",
                table: "NhatKyHoaDon",
                column: "HoaDonId",
                principalTable: "HoaDon",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyHoaDon_HoaDon_HoaDonId",
                table: "NhatKyHoaDon");

            migrationBuilder.AddColumn<string>(
                name: "MaTuyen",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HoaDonId",
                table: "NhatKyHoaDon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyHoaDon_HoaDon_HoaDonId",
                table: "NhatKyHoaDon",
                column: "HoaDonId",
                principalTable: "HoaDon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
