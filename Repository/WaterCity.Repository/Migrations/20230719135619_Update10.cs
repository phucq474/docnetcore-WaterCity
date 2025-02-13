using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_ChucNang_ChucNangId",
                table: "ChucNangEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_NguoiDung_NguoiDungId",
                table: "ChucNangEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_ChucVu_ChucVuId",
                table: "ChucVuEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_NguoiDung_NguoiDungId",
                table: "ChucVuEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NguoiDung_NguoiDungId",
                table: "NguoiDungEntityNhaMayEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NhaMay_NhaMayId",
                table: "NguoiDungEntityNhaMayEntity");

            migrationBuilder.RenameColumn(
                name: "NhaMayId",
                table: "NguoiDungEntityNhaMayEntity",
                newName: "NhaMaysId");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "NguoiDungEntityNhaMayEntity",
                newName: "NguoiDungsId");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDungEntityNhaMayEntity_NhaMayId",
                table: "NguoiDungEntityNhaMayEntity",
                newName: "IX_NguoiDungEntityNhaMayEntity_NhaMaysId");

            migrationBuilder.RenameColumn(
                name: "PhamVi",
                table: "DongHoNuoc",
                newName: "ViTriLapDat");

            migrationBuilder.RenameColumn(
                name: "LyDoHuy",
                table: "DongHoNuoc",
                newName: "SoTem");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "ChucVuEntityNguoiDungEntity",
                newName: "NguoiDungsId");

            migrationBuilder.RenameColumn(
                name: "ChucVuId",
                table: "ChucVuEntityNguoiDungEntity",
                newName: "ChucVusId");

            migrationBuilder.RenameIndex(
                name: "IX_ChucVuEntityNguoiDungEntity_NguoiDungId",
                table: "ChucVuEntityNguoiDungEntity",
                newName: "IX_ChucVuEntityNguoiDungEntity_NguoiDungsId");

            migrationBuilder.RenameColumn(
                name: "NguoiDungId",
                table: "ChucNangEntityNguoiDungEntity",
                newName: "NguoiDungsId");

            migrationBuilder.RenameColumn(
                name: "ChucNangId",
                table: "ChucNangEntityNguoiDungEntity",
                newName: "ChucNangsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChucNangEntityNguoiDungEntity_NguoiDungId",
                table: "ChucNangEntityNguoiDungEntity",
                newName: "IX_ChucNangEntityNguoiDungEntity_NguoiDungsId");

            migrationBuilder.AddColumn<string>(
                name: "DiaChiThu",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KyGhiChiSoId",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayGhiCSDen",
                table: "TuyenDoc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayGhiCSTu",
                table: "TuyenDoc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhanVienSua",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NhanVienXem",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDTHoaDon",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDTNguoiThu",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDTSuaChua",
                table: "TuyenDoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ThoiGianThu",
                table: "TuyenDoc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CamKetSuDungNuoc",
                table: "HopDong",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChungTu",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiamTruTheo",
                table: "HopDong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HinhThucTT",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhoiLuongCamKet",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuVucTT",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaVach",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDatCoc",
                table: "HopDong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayNT",
                table: "HopDong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiLapDat",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiNop",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoTien",
                table: "HopDong",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TienDatCoc",
                table: "HopDong",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TienLapDat",
                table: "HopDong",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThaiSuDung",
                table: "DongHoNuoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DaiKhoiThuy",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DuongKinh",
                table: "DongHoNuoc",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HangSXId",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "HieuLucKD",
                table: "DongHoNuoc",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "HinhThucXL",
                table: "DongHoNuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HopBaoVe",
                table: "DongHoNuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KhuyenMai",
                table: "DongHoNuoc",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KieuDongHoId",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiKM",
                table: "DongHoNuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LyDoHuyId",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LyDoKiemDinh",
                table: "DongHoNuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LyDoThay",
                table: "DongHoNuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaDHThay",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKiemDinh",
                table: "DongHoNuoc",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "NguoiThayId",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NuocSXId",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OngDan",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhamViId",
                table: "DongHoNuoc",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoPhieuThay",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrangThaiDHLap",
                table: "DongHoNuoc",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VanMotChieu",
                table: "DongHoNuoc",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KieuDongHo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KieuDongHo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_KieuDongHo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LyDoHuy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_LyDoHuy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NuocSanXuat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_NuocSanXuat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhamVi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhamVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_PhamVi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tinh",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Tinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HangSanXuat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NuocSanXuatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_HangSanXuat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangSanXuat_NuocSanXuat_NuocSanXuatId",
                        column: x => x.NuocSanXuatId,
                        principalTable: "NuocSanXuat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Huyen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Huyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huyen_Tinh_TinhId",
                        column: x => x.TinhId,
                        principalTable: "Tinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuyenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Xa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xa_Huyen_HuyenId",
                        column: x => x.HuyenId,
                        principalTable: "Huyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DongHoNuoc_PhamViId",
                table: "DongHoNuoc",
                column: "PhamViId");

            migrationBuilder.CreateIndex(
                name: "IX_HangSanXuat_NuocSanXuatId",
                table: "HangSanXuat",
                column: "NuocSanXuatId");

            migrationBuilder.CreateIndex(
                name: "IX_Huyen_TinhId",
                table: "Huyen",
                column: "TinhId");

            migrationBuilder.CreateIndex(
                name: "IX_Xa_HuyenId",
                table: "Xa",
                column: "HuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_ChucNang_ChucNangsId",
                table: "ChucNangEntityNguoiDungEntity",
                column: "ChucNangsId",
                principalTable: "ChucNang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_NguoiDung_NguoiDungsId",
                table: "ChucNangEntityNguoiDungEntity",
                column: "NguoiDungsId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_ChucVu_ChucVusId",
                table: "ChucVuEntityNguoiDungEntity",
                column: "ChucVusId",
                principalTable: "ChucVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_NguoiDung_NguoiDungsId",
                table: "ChucVuEntityNguoiDungEntity",
                column: "NguoiDungsId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DongHoNuoc_PhamVi_PhamViId",
                table: "DongHoNuoc",
                column: "PhamViId",
                principalTable: "PhamVi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NguoiDung_NguoiDungsId",
                table: "NguoiDungEntityNhaMayEntity",
                column: "NguoiDungsId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NhaMay_NhaMaysId",
                table: "NguoiDungEntityNhaMayEntity",
                column: "NhaMaysId",
                principalTable: "NhaMay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_ChucNang_ChucNangsId",
                table: "ChucNangEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_NguoiDung_NguoiDungsId",
                table: "ChucNangEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_ChucVu_ChucVusId",
                table: "ChucVuEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_NguoiDung_NguoiDungsId",
                table: "ChucVuEntityNguoiDungEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_DongHoNuoc_PhamVi_PhamViId",
                table: "DongHoNuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NguoiDung_NguoiDungsId",
                table: "NguoiDungEntityNhaMayEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NhaMay_NhaMaysId",
                table: "NguoiDungEntityNhaMayEntity");

            migrationBuilder.DropTable(
                name: "HangSanXuat");

            migrationBuilder.DropTable(
                name: "KieuDongHo");

            migrationBuilder.DropTable(
                name: "LyDoHuy");

            migrationBuilder.DropTable(
                name: "PhamVi");

            migrationBuilder.DropTable(
                name: "Xa");

            migrationBuilder.DropTable(
                name: "NuocSanXuat");

            migrationBuilder.DropTable(
                name: "Huyen");

            migrationBuilder.DropTable(
                name: "Tinh");

            migrationBuilder.DropIndex(
                name: "IX_DongHoNuoc_PhamViId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "DiaChiThu",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "KyGhiChiSoId",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "NgayGhiCSDen",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "NgayGhiCSTu",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "NhanVienSua",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "NhanVienXem",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "SDTHoaDon",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "SDTNguoiThu",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "SDTSuaChua",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "ThoiGianThu",
                table: "TuyenDoc");

            migrationBuilder.DropColumn(
                name: "CamKetSuDungNuoc",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "ChungTu",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "GiamTruTheo",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "HinhThucTT",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "KhoiLuongCamKet",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "KhuVucTT",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "MaVach",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "NgayDatCoc",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "NgayNT",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "NguoiLapDat",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "NguoiNop",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "SoTien",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "TienDatCoc",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "TienLapDat",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "DaiKhoiThuy",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "DuongKinh",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "HangSXId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "HieuLucKD",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "HinhThucXL",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "HopBaoVe",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "KhuyenMai",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "KieuDongHoId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "LoaiKM",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "LyDoHuyId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "LyDoKiemDinh",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "LyDoThay",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "MaDHThay",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "NgayKiemDinh",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "NguoiThayId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "NuocSXId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "OngDan",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "PhamViId",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "SoPhieuThay",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "TrangThaiDHLap",
                table: "DongHoNuoc");

            migrationBuilder.DropColumn(
                name: "VanMotChieu",
                table: "DongHoNuoc");

            migrationBuilder.RenameColumn(
                name: "NhaMaysId",
                table: "NguoiDungEntityNhaMayEntity",
                newName: "NhaMayId");

            migrationBuilder.RenameColumn(
                name: "NguoiDungsId",
                table: "NguoiDungEntityNhaMayEntity",
                newName: "NguoiDungId");

            migrationBuilder.RenameIndex(
                name: "IX_NguoiDungEntityNhaMayEntity_NhaMaysId",
                table: "NguoiDungEntityNhaMayEntity",
                newName: "IX_NguoiDungEntityNhaMayEntity_NhaMayId");

            migrationBuilder.RenameColumn(
                name: "ViTriLapDat",
                table: "DongHoNuoc",
                newName: "PhamVi");

            migrationBuilder.RenameColumn(
                name: "SoTem",
                table: "DongHoNuoc",
                newName: "LyDoHuy");

            migrationBuilder.RenameColumn(
                name: "NguoiDungsId",
                table: "ChucVuEntityNguoiDungEntity",
                newName: "NguoiDungId");

            migrationBuilder.RenameColumn(
                name: "ChucVusId",
                table: "ChucVuEntityNguoiDungEntity",
                newName: "ChucVuId");

            migrationBuilder.RenameIndex(
                name: "IX_ChucVuEntityNguoiDungEntity_NguoiDungsId",
                table: "ChucVuEntityNguoiDungEntity",
                newName: "IX_ChucVuEntityNguoiDungEntity_NguoiDungId");

            migrationBuilder.RenameColumn(
                name: "NguoiDungsId",
                table: "ChucNangEntityNguoiDungEntity",
                newName: "NguoiDungId");

            migrationBuilder.RenameColumn(
                name: "ChucNangsId",
                table: "ChucNangEntityNguoiDungEntity",
                newName: "ChucNangId");

            migrationBuilder.RenameIndex(
                name: "IX_ChucNangEntityNguoiDungEntity_NguoiDungsId",
                table: "ChucNangEntityNguoiDungEntity",
                newName: "IX_ChucNangEntityNguoiDungEntity_NguoiDungId");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThaiSuDung",
                table: "DongHoNuoc",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_ChucNang_ChucNangId",
                table: "ChucNangEntityNguoiDungEntity",
                column: "ChucNangId",
                principalTable: "ChucNang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucNangEntityNguoiDungEntity_NguoiDung_NguoiDungId",
                table: "ChucNangEntityNguoiDungEntity",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_ChucVu_ChucVuId",
                table: "ChucVuEntityNguoiDungEntity",
                column: "ChucVuId",
                principalTable: "ChucVu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChucVuEntityNguoiDungEntity_NguoiDung_NguoiDungId",
                table: "ChucVuEntityNguoiDungEntity",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NguoiDung_NguoiDungId",
                table: "NguoiDungEntityNhaMayEntity",
                column: "NguoiDungId",
                principalTable: "NguoiDung",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDungEntityNhaMayEntity_NhaMay_NhaMayId",
                table: "NguoiDungEntityNhaMayEntity",
                column: "NhaMayId",
                principalTable: "NhaMay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
