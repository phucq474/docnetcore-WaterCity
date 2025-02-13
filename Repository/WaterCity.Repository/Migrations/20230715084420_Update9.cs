using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KyHieu",
                table: "DanhSachDoiTuongGia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KyHieu",
                table: "DanhSachDoiTuongGia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
