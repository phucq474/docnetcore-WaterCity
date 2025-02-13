using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterCity.Repository.Migrations
{
    public partial class QL_SPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucSP",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMucSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DanhMucSP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDonHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_DonHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_NhaCungCap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheLoai",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_TheLoai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaSanPham = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NhaCungCapId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TheLoaiId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DanhMucSPId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_DanhMucSP_DanhMucSPId",
                        column: x => x.DanhMucSPId,
                        principalTable: "DanhMucSP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_NhaCungCap_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SanPham_TheLoai_TheLoaiId",
                        column: x => x.TheLoaiId,
                        principalTable: "TheLoai",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DonHangId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SanPhamId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonHangEntitySanPhamEntity",
                columns: table => new
                {
                    DonHangsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SanPhamsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangEntitySanPhamEntity", x => new { x.DonHangsId, x.SanPhamsId });
                    table.ForeignKey(
                        name: "FK_DonHangEntitySanPhamEntity_DonHang_DonHangsId",
                        column: x => x.DonHangsId,
                        principalTable: "DonHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangEntitySanPhamEntity_SanPham_SanPhamsId",
                        column: x => x.SanPhamsId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_SanPhamId",
                table: "ChiTietDonHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangEntitySanPhamEntity_SanPhamsId",
                table: "DonHangEntitySanPhamEntity",
                column: "SanPhamsId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_DanhMucSPId",
                table: "SanPham",
                column: "DanhMucSPId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_NhaCungCapId",
                table: "SanPham",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_TheLoaiId",
                table: "SanPham",
                column: "TheLoaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DonHangEntitySanPhamEntity");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "DanhMucSP");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "TheLoai");
        }
    }
}
