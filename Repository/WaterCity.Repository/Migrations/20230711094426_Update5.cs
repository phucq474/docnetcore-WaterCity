using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HopDongId",
                table: "HopDong");

            migrationBuilder.AddColumn<string>(
                name: "NguoiDaiDien",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ChiSoCuoi",
                table: "DongHoNuoc",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ChiSoDau",
                table: "DongHoNuoc",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViHC",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoThuTu",
                table: "DongHoNuoc",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NguoiDaiDien",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "ChiSoCuoi",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "ChiSoDau",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "DonViHC",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "SoThuTu",
                table: "DongHoNuoc");

            migrationBuilder.AddColumn<string>(
                name: "HopDongId",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
