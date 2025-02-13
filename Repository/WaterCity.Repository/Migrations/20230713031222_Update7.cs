using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGia_DoiTuongGia_DoiTuongGiaId",
                table: "ChiTietGia");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "Vung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "TrangThaiGhi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ThongBao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ThatThoat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "SuCo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "SoDocChiSo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "PhuongThucThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "PhienInThongBao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "PhiDuyTri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "NhatKyHoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "NhatKyDuLieu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "NhaMay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "NguoiDung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "MauTinSMS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "LichSuSMS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "KyGhiChiSo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "KhuVuc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DongHoNuocSuCo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DoiTuongGia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DanhSachHoDan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DanhSachDoiTuongGia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DanhMucThongBao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "DanhMucSeriHoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ChucVu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ChucNang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ChiTietHoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DoiTuongGiaId",
                table: "ChiTietGia",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ChiTietGia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KeyId",
                table: "ChiSoDongHo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGia_DoiTuongGia_DoiTuongGiaId",
                table: "ChiTietGia",
                column: "DoiTuongGiaId",
                principalTable: "DoiTuongGia",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietGia_DoiTuongGia_DoiTuongGiaId",
                table: "ChiTietGia");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "Vung");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "TrangThaiGhi");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ThatThoat");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "SuCo");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "SoDocChiSo");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "PhuongThucThanhToan");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "PhienInThongBao");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "PhiDuyTri");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "NhatKyHoaDon");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "NhatKyDuLieu");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "NhaMay");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "MauTinSMS");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "LichSuSMS");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "KyGhiChiSo");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "KhuVuc");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DongHoNuocSuCo");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DanhSachHoDan");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DanhSachDoiTuongGia");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DanhMucThongBao");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "DanhMucSeriHoaDon");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ChucVu");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ChucNang");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ChiTietGia");

            migrationBuilder.DropColumn(
                name: "KeyId",
                table: "ChiSoDongHo");

            migrationBuilder.AlterColumn<string>(
                name: "DoiTuongGiaId",
                table: "ChiTietGia",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietGia_DoiTuongGia_DoiTuongGiaId",
                table: "ChiTietGia",
                column: "DoiTuongGiaId",
                principalTable: "DoiTuongGia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
