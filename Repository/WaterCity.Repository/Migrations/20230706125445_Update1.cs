using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhSachDoiTuongGia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KyHieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachDoiTuongGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguonNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenThuongGoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoHo = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCmnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapCmnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiCapCmnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoGcn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoiTuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoKhau = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KyGhiChiSo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySuDungTu = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NgaySuDungDen = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NgayHoaDon = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyGhiChiSo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaMay",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhaMay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaMay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyDuLieu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuLieuTruoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuLieuSau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuocBang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyDuLieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuCo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenSuCo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuCo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DaInXong = table.Column<int>(type: "int", nullable: true),
                    SoLuongHopDong = table.Column<int>(type: "int", nullable: true),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDocId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiGhi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaMau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaNgan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTt = table.Column<int>(type: "int", nullable: true),
                    KhongChoPhepGhi = table.Column<bool>(type: "bit", nullable: true),
                    KhongChoPhepHienThi = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiGhi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TyLeBaoPhu",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyLeBaoPhu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vung",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenVung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoiTuongGia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayBatDau = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NgayKetThuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CoVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhiBvmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoToiThieu = table.Column<bool>(type: "bit", nullable: false),
                    TinhTu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ToiThieu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TinhPhiDuyTri = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VatphiDuyTri = table.Column<bool>(type: "bit", nullable: true),
                    ApDungKhiTieuThu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DanhSachDoiTuongGiaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiTuongGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoiTuongGia_DanhSachDoiTuongGia_DanhSachDoiTuongGiaId",
                        column: x => x.DanhSachDoiTuongGiaId,
                        principalTable: "DanhSachDoiTuongGia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KhuVuc",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VungId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKhuVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VungNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuVuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhuVuc_Vung_VungNavigationId",
                        column: x => x.VungNavigationId,
                        principalTable: "Vung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoTaChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuSo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DenSo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiaCoVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DoiTuongGiaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietGia_DoiTuongGia_DoiTuongGiaId",
                        column: x => x.DoiTuongGiaId,
                        principalTable: "DoiTuongGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TuyenDoc",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KhuVucId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiQuanLyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiThuTienId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TuyenDoc_KhuVuc_KhuVucId",
                        column: x => x.KhuVucId,
                        principalTable: "KhuVuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HopDongId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachHangId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuVucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhSachDoiTuongGiaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayKyHopDong = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NgayLapDat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCoHieuLuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TuyenDocId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MucDichSuDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuyenDocNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhSachDoiTuongGia_DanhSachDoiTuongGiaId",
                        column: x => x.DanhSachDoiTuongGiaId,
                        principalTable: "DanhSachDoiTuongGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_TuyenDoc_TuyenDocNavigationId",
                        column: x => x.TuyenDocNavigationId,
                        principalTable: "TuyenDoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SoDocChiSo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TuyenDocId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NhaMayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDungId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KyGhiChiSoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDhdaGhi = table.Column<int>(type: "int", nullable: true),
                    ChotSo = table.Column<bool>(type: "bit", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayChot = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    HoaDon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoDocChiSo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoDocChiSo_KyGhiChiSo_KyGhiChiSoId",
                        column: x => x.KyGhiChiSoId,
                        principalTable: "KyGhiChiSo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoDocChiSo_TuyenDoc_TuyenDocId",
                        column: x => x.TuyenDocId,
                        principalTable: "TuyenDoc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DongHoNuoc",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DongHoChinhId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiDongHo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiQuanLyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhamVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriDongHo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiSuDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LyDoHuy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HopDongId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DongHoNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DongHoNuoc_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HopDongId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiThuTienId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTienTruocVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhiDtdn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhiBvmt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThongBaoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HopDongNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ThongBaoNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_HopDong_HopDongNavigationId",
                        column: x => x.HopDongNavigationId,
                        principalTable: "HopDong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDon_ThongBao_ThongBaoNavigationId",
                        column: x => x.ThongBaoNavigationId,
                        principalTable: "ThongBao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiSoDongHo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChiSoCu = table.Column<int>(type: "int", nullable: false),
                    ChiSoMoi = table.Column<int>(type: "int", nullable: false),
                    NgayDoc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NgayDongBo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ChiSoDauCu = table.Column<int>(type: "int", nullable: true),
                    ChiSoCuoiCu = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tthu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongHoNuocId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoDocChiSoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThaiGhiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiSoDongHo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiSoDongHo_DongHoNuoc_DongHoNuocId",
                        column: x => x.DongHoNuocId,
                        principalTable: "DongHoNuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiSoDongHo_SoDocChiSo_SoDocChiSoId",
                        column: x => x.SoDocChiSoId,
                        principalTable: "SoDocChiSo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiSoDongHo_TrangThaiGhi_TrangThaiGhiId",
                        column: x => x.TrangThaiGhiId,
                        principalTable: "TrangThaiGhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DongHoNuocSuCo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgaySuCo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NguoiBaoCaoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiThucHienId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TienDo = table.Column<int>(type: "int", nullable: false),
                    CachKhacPhuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DongHoNuocId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SuCoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DongHoNuocSuCo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DongHoNuocSuCo_DongHoNuoc_DongHoNuocId",
                        column: x => x.DongHoNuocId,
                        principalTable: "DongHoNuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DongHoNuocSuCo_SuCo_SuCoId",
                        column: x => x.SuCoId,
                        principalTable: "SuCo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThatThoat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThoiGian = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    XucXa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CongIch = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Khac = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sldhc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DongHoNuocId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThatThoat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThatThoat_DongHoNuoc_DongHoNuocId",
                        column: x => x.DongHoNuocId,
                        principalTable: "DongHoNuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    So = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiaCoVat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoaDonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyHoaDon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NguoiDungId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoaDonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyHoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyHoaDon_HoaDon_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiSoDongHo_DongHoNuocId",
                table: "ChiSoDongHo",
                column: "DongHoNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiSoDongHo_SoDocChiSoId",
                table: "ChiSoDongHo",
                column: "SoDocChiSoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiSoDongHo_TrangThaiGhiId",
                table: "ChiSoDongHo",
                column: "TrangThaiGhiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGia_DoiTuongGiaId",
                table: "ChiTietGia",
                column: "DoiTuongGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_HoaDonId",
                table: "ChiTietHoaDon",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiTuongGia_DanhSachDoiTuongGiaId",
                table: "DoiTuongGia",
                column: "DanhSachDoiTuongGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DongHoNuoc_HopDongId",
                table: "DongHoNuoc",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_DongHoNuocSuCo_DongHoNuocId",
                table: "DongHoNuocSuCo",
                column: "DongHoNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DongHoNuocSuCo_SuCoId",
                table: "DongHoNuocSuCo",
                column: "SuCoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_HopDongNavigationId",
                table: "HoaDon",
                column: "HopDongNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ThongBaoNavigationId",
                table: "HoaDon",
                column: "ThongBaoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_DanhSachDoiTuongGiaId",
                table: "HopDong",
                column: "DanhSachDoiTuongGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_KhachHangId",
                table: "HopDong",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_TuyenDocNavigationId",
                table: "HopDong",
                column: "TuyenDocNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_VungNavigationId",
                table: "KhuVuc",
                column: "VungNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyHoaDon_HoaDonId",
                table: "NhatKyHoaDon",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_SoDocChiSo_KyGhiChiSoId",
                table: "SoDocChiSo",
                column: "KyGhiChiSoId");

            migrationBuilder.CreateIndex(
                name: "IX_SoDocChiSo_TuyenDocId",
                table: "SoDocChiSo",
                column: "TuyenDocId");

            migrationBuilder.CreateIndex(
                name: "IX_ThatThoat_DongHoNuocId",
                table: "ThatThoat",
                column: "DongHoNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_TuyenDoc_KhuVucId",
                table: "TuyenDoc",
                column: "KhuVucId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiSoDongHo");

            migrationBuilder.DropTable(
                name: "ChiTietGia");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "DongHoNuocSuCo");

            migrationBuilder.DropTable(
                name: "NhaMay");

            migrationBuilder.DropTable(
                name: "NhatKyDuLieu");

            migrationBuilder.DropTable(
                name: "NhatKyHoaDon");

            migrationBuilder.DropTable(
                name: "ThatThoat");

            migrationBuilder.DropTable(
                name: "TyLeBaoPhu");

            migrationBuilder.DropTable(
                name: "SoDocChiSo");

            migrationBuilder.DropTable(
                name: "TrangThaiGhi");

            migrationBuilder.DropTable(
                name: "DoiTuongGia");

            migrationBuilder.DropTable(
                name: "SuCo");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "DongHoNuoc");

            migrationBuilder.DropTable(
                name: "KyGhiChiSo");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "DanhSachDoiTuongGia");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "TuyenDoc");

            migrationBuilder.DropTable(
                name: "KhuVuc");

            migrationBuilder.DropTable(
                name: "Vung");
        }
    }
}
