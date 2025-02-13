using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_HopDong_HopDongNavigationId",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_ThongBao_ThongBaoNavigationId",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DanhSachDoiTuongGia_DanhSachDoiTuongGiaId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_TuyenDoc_TuyenDocNavigationId",
                table: "HopDong");

            migrationBuilder.DropTable(
                name: "TyLeBaoPhu");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_TuyenDocNavigationId",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_HopDongNavigationId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_ThongBaoNavigationId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TuyenDocNavigationId",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "HopDongId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "HopDongNavigationId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "ThongBaoNavigationId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "ApDungKhiTieuThu",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "TinhPhiDuyTri",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "VatphiDuyTri",
                table: "DoiTuongGia");

            migrationBuilder.RenameColumn(
                name: "PhuongThucThanhToan",
                table: "HopDong",
                newName: "PhuongThucThanhToanId");

            migrationBuilder.RenameColumn(
                name: "DanhSachDoiTuongGiaId",
                table: "HopDong",
                newName: "DoiTuongGiaId");

            migrationBuilder.RenameIndex(
                name: "IX_HopDong_DanhSachDoiTuongGiaId",
                table: "HopDong",
                newName: "IX_HopDong_DoiTuongGiaId");

            migrationBuilder.RenameColumn(
                name: "CoVat",
                table: "DoiTuongGia",
                newName: "VAT");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Vung",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "TrangThaiGhi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ThongBao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ThatThoat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SuCo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SoDocChiSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "NhatKyHoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "NhatKyDuLieu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "NhaMay",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "NguoiDung",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "KyGhiChiSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "KhuVuc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TuyenDocId",
                table: "HopDong",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThongBaoId",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChiSoDongHoId",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DongHoNuocSuCo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BVMT",
                table: "DoiTuongGia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DoiTuongGia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DTTinhGia",
                table: "DoiTuongGia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KieuTinh",
                table: "DoiTuongGia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhiDuyTriId",
                table: "DoiTuongGia",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DanhSachDoiTuongGia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ChucVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ChucNang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ChiTietHoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ChiTietGia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ChiSoDongHo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhiDuyTri",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KieuTinh = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApDungKhiTieuThu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_PhiDuyTri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucThanhToan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoTaPhuongThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PhuongThucThanhToan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_TuyenDocId",
                table: "HopDong",
                column: "TuyenDocId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ChiSoDongHoId",
                table: "HoaDon",
                column: "ChiSoDongHoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThongBaoId",
                table: "HoaDon",
                column: "ThongBaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiTuongGia_PhiDuyTriId",
                table: "DoiTuongGia",
                column: "PhiDuyTriId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoiTuongGia_PhiDuyTri_PhiDuyTriId",
                table: "DoiTuongGia",
                column: "PhiDuyTriId",
                principalTable: "PhiDuyTri",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_ChiSoDongHo_ChiSoDongHoId",
                table: "HoaDon",
                column: "ChiSoDongHoId",
                principalTable: "ChiSoDongHo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_ThongBao_ThongBaoId",
                table: "HoaDon",
                column: "ThongBaoId",
                principalTable: "ThongBao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DoiTuongGia_DoiTuongGiaId",
                table: "HopDong",
                column: "DoiTuongGiaId",
                principalTable: "DoiTuongGia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_TuyenDoc_TuyenDocId",
                table: "HopDong",
                column: "TuyenDocId",
                principalTable: "TuyenDoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoiTuongGia_PhiDuyTri_PhiDuyTriId",
                table: "DoiTuongGia");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_ChiSoDongHo_ChiSoDongHoId",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_ThongBao_ThongBaoId",
                table: "HoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DoiTuongGia_DoiTuongGiaId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_TuyenDoc_TuyenDocId",
                table: "HopDong");

            migrationBuilder.DropTable(
                name: "PhiDuyTri");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_TuyenDocId",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_ChiSoDongHoId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_ThongBaoId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_DoiTuongGia_PhiDuyTriId",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Vung");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "TrangThaiGhi");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ThongBao");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ThatThoat");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SuCo");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SoDocChiSo");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "NhatKyHoaDon");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "NhatKyDuLieu");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "NhaMay");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "KyGhiChiSo");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "KhuVuc");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "ChiSoDongHoId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DongHoNuocSuCo");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "BVMT",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "DTTinhGia",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "KieuTinh",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "PhiDuyTriId",
                table: "DoiTuongGia");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DanhSachDoiTuongGia");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ChucVu");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ChucNang");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ChiTietGia");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ChiSoDongHo");

            migrationBuilder.RenameColumn(
                name: "PhuongThucThanhToanId",
                table: "HopDong",
                newName: "PhuongThucThanhToan");

            migrationBuilder.RenameColumn(
                name: "DoiTuongGiaId",
                table: "HopDong",
                newName: "DanhSachDoiTuongGiaId");

            migrationBuilder.RenameIndex(
                name: "IX_HopDong_DoiTuongGiaId",
                table: "HopDong",
                newName: "IX_HopDong_DanhSachDoiTuongGiaId");

            migrationBuilder.RenameColumn(
                name: "VAT",
                table: "DoiTuongGia",
                newName: "CoVat");

            migrationBuilder.AlterColumn<string>(
                name: "TuyenDocId",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "TuyenDocNavigationId",
                table: "HopDong",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThongBaoId",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HopDongId",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HopDongNavigationId",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThongBaoNavigationId",
                table: "HoaDon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ApDungKhiTieuThu",
                table: "DoiTuongGia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TinhPhiDuyTri",
                table: "DoiTuongGia",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VatphiDuyTri",
                table: "DoiTuongGia",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TyLeBaoPhu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyLeBaoPhu", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_TuyenDocNavigationId",
                table: "HopDong",
                column: "TuyenDocNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_HopDongNavigationId",
                table: "HoaDon",
                column: "HopDongNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThongBaoNavigationId",
                table: "HoaDon",
                column: "ThongBaoNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_HopDong_HopDongNavigationId",
                table: "HoaDon",
                column: "HopDongNavigationId",
                principalTable: "HopDong",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_ThongBao_ThongBaoNavigationId",
                table: "HoaDon",
                column: "ThongBaoNavigationId",
                principalTable: "ThongBao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DanhSachDoiTuongGia_DanhSachDoiTuongGiaId",
                table: "HopDong",
                column: "DanhSachDoiTuongGiaId",
                principalTable: "DanhSachDoiTuongGia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_TuyenDoc_TuyenDocNavigationId",
                table: "HopDong",
                column: "TuyenDocNavigationId",
                principalTable: "TuyenDoc",
                principalColumn: "Id");
        }
    }
}
