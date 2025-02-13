using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_ThongBao_ThongBaoId",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_KhuVuc_Vung_VungNavigationId",
                table: "KhuVuc");

            migrationBuilder.DropIndex(
                name: "IX_KhuVuc_VungNavigationId",
                table: "KhuVuc");

            migrationBuilder.DropColumn(
                name: "DaInXong",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "NguoiDocId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "NhaMayId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "SoLuongHopDong",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "TenPhien",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "VungNavigationId",
                table: "KhuVuc");

            migrationBuilder.DropColumn(
                name: "GiaCoVat",
                table: "ChiTietHoaDon");

            migrationBuilder.RenameColumn(
                name: "ThongBaoId",
                table: "HoaDon",
                newName: "PhienInThongBaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_ThongBaoId",
                table: "HoaDon",
                newName: "IX_HoaDon_PhienInThongBaoId");

            migrationBuilder.RenameColumn(
                name: "DongHoChinhId",
                table: "DongHoNuoc",
                newName: "DongHoChaId");

            migrationBuilder.RenameColumn(
                name: "So",
                table: "ChiTietHoaDon",
                newName: "ThanhTien");

            migrationBuilder.RenameColumn(
                name: "Gia",
                table: "ChiTietHoaDon",
                newName: "SoTieuThu");

            migrationBuilder.AddColumn<string>(
                name: "DanhMucThongBaoId",
                table: "ThongBao",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HoaDonId",
                table: "ThongBao",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KieuGuiTB",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TinhTrang",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiTB",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiTT",
                table: "ThongBao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "NhaMay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "VungId",
                table: "KhuVuc",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "KinhDo",
                table: "HopDong",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ViDo",
                table: "HopDong",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "SeriHoaDon",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SeriDongHo",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DongHoNuocEntityId",
                table: "DongHoNuoc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeriChi",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DonGia",
                table: "ChiTietHoaDon",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "DanhMucSeriHoaDon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucSeriHoaDon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucThongBao",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HinhThuc = table.Column<int>(type: "int", nullable: false),
                    NguoiGuiId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TenLanGui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachHoDan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenThuongGoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoHo = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoKhau = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuVucId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachHoDan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhSachHoDan_KhuVuc_KhuVucId",
                        column: x => x.KhuVucId,
                        principalTable: "KhuVuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MauTinSMS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiEndPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauTinSMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungEntityNhaMayEntity",
                columns: table => new
                {
                    NguoiDungId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungEntityNhaMayEntity", x => new { x.NguoiDungId, x.NhaMayId });
                    table.ForeignKey(
                        name: "FK_NguoiDungEntityNhaMayEntity_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDungEntityNhaMayEntity_NhaMay_NhaMayId",
                        column: x => x.NhaMayId,
                        principalTable: "NhaMay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhienInThongBao",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DaInXong = table.Column<int>(type: "int", nullable: true),
                    SoLuongHopDong = table.Column<int>(type: "int", nullable: true),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDocId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhienInThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LichSuSMS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NguoiGuidId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachHangId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoaDonId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HopDongId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongTin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiGui = table.Column<int>(type: "int", nullable: false),
                    MauTinSMSId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuSMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuSMS_MauTinSMS_MauTinSMSId",
                        column: x => x.MauTinSMSId,
                        principalTable: "MauTinSMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_DanhMucThongBaoId",
                table: "ThongBao",
                column: "DanhMucThongBaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongBao_HoaDonId",
                table: "ThongBao",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_VungId",
                table: "KhuVuc",
                column: "VungId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_SeriHoaDon",
                table: "HoaDon",
                column: "SeriHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_DongHoNuoc_DongHoNuocEntityId",
                table: "DongHoNuoc",
                column: "DongHoNuocEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachHoDan_KhuVucId",
                table: "DanhSachHoDan",
                column: "KhuVucId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuSMS_MauTinSMSId",
                table: "LichSuSMS",
                column: "MauTinSMSId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungEntityNhaMayEntity_NhaMayId",
                table: "NguoiDungEntityNhaMayEntity",
                column: "NhaMayId");

            migrationBuilder.AddForeignKey(
                name: "FK_DongHoNuoc_DongHoNuoc_DongHoNuocEntityId",
                table: "DongHoNuoc",
                column: "DongHoNuocEntityId",
                principalTable: "DongHoNuoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_DanhMucSeriHoaDon_SeriHoaDon",
                table: "HoaDon",
                column: "SeriHoaDon",
                principalTable: "DanhMucSeriHoaDon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_PhienInThongBao_PhienInThongBaoId",
                table: "HoaDon",
                column: "PhienInThongBaoId",
                principalTable: "PhienInThongBao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhuVuc_Vung_VungId",
                table: "KhuVuc",
                column: "VungId",
                principalTable: "Vung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_DanhMucThongBao_DanhMucThongBaoId",
                table: "ThongBao",
                column: "DanhMucThongBaoId",
                principalTable: "DanhMucThongBao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongBao_HoaDon_HoaDonId",
                table: "ThongBao",
                column: "HoaDonId",
                principalTable: "HoaDon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DongHoNuoc_DongHoNuoc_DongHoNuocEntityId",
                table: "DongHoNuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_DanhMucSeriHoaDon_SeriHoaDon",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_PhienInThongBao_PhienInThongBaoId",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_KhuVuc_Vung_VungId",
                table: "KhuVuc");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_DanhMucThongBao_DanhMucThongBaoId",
                table: "ThongBao");

            migrationBuilder.DropForeignKey(
                name: "FK_ThongBao_HoaDon_HoaDonId",
                table: "ThongBao");

            migrationBuilder.DropTable(
                name: "DanhMucSeriHoaDon");

            migrationBuilder.DropTable(
                name: "DanhMucThongBao");

            migrationBuilder.DropTable(
                name: "DanhSachHoDan");

            migrationBuilder.DropTable(
                name: "LichSuSMS");

            migrationBuilder.DropTable(
                name: "NguoiDungEntityNhaMayEntity");

            migrationBuilder.DropTable(
                name: "PhienInThongBao");

            migrationBuilder.DropTable(
                name: "MauTinSMS");

            migrationBuilder.DropIndex(
                name: "IX_ThongBao_DanhMucThongBaoId",
                table: "ThongBao");

            migrationBuilder.DropIndex(
                name: "IX_ThongBao_HoaDonId",
                table: "ThongBao");

            migrationBuilder.DropIndex(
                name: "IX_KhuVuc_VungId",
                table: "KhuVuc");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_SeriHoaDon",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_DongHoNuoc_DongHoNuocEntityId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "DanhMucThongBaoId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "HoaDonId",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "KieuGuiTB",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "TrangThaiTB",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "TrangThaiTT",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "NhaMay");

            migrationBuilder.DropColumn(
                name: "KinhDo",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "ViDo",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "DongHoNuocEntityId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "SeriChi",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "DonGia",
                table: "ChiTietHoaDon");

            migrationBuilder.RenameColumn(
                name: "PhienInThongBaoId",
                table: "HoaDon",
                newName: "ThongBaoId");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_PhienInThongBaoId",
                table: "HoaDon",
                newName: "IX_HoaDon_ThongBaoId");

            migrationBuilder.RenameColumn(
                name: "DongHoChaId",
                table: "DongHoNuoc",
                newName: "DongHoChinhId");

            migrationBuilder.RenameColumn(
                name: "ThanhTien",
                table: "ChiTietHoaDon",
                newName: "So");

            migrationBuilder.RenameColumn(
                name: "SoTieuThu",
                table: "ChiTietHoaDon",
                newName: "Gia");

            migrationBuilder.AddColumn<int>(
                name: "DaInXong",
                table: "ThongBao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayTao",
                table: "ThongBao",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiDocId",
                table: "ThongBao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhaMayId",
                table: "ThongBao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongHopDong",
                table: "ThongBao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenPhien",
                table: "ThongBao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VungId",
                table: "KhuVuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "VungNavigationId",
                table: "KhuVuc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SeriHoaDon",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SeriDongHo",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GiaCoVat",
                table: "ChiTietHoaDon",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_VungNavigationId",
                table: "KhuVuc",
                column: "VungNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_ThongBao_ThongBaoId",
                table: "HoaDon",
                column: "ThongBaoId",
                principalTable: "ThongBao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KhuVuc_Vung_VungNavigationId",
                table: "KhuVuc",
                column: "VungNavigationId",
                principalTable: "Vung",
                principalColumn: "Id");
        }
    }
}
