using Microsoft.EntityFrameworkCore;
using WaterCity.Contract.Repository.Models;

namespace WaterCity.Repository.Infrastructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<ChiSoDongHoEntity> ChiSoDongHo { get; set; }
        public DbSet<ChiTietGiaEntity> ChiTietGia { get; set; }
        public DbSet<ChiTietHoaDonEntity> ChiTietHoaDon { get; set; }
        public DbSet<ChucNangEntity> ChucNang { get; set; }
        public DbSet<ChucVuEntity> ChucVu { get; set; }
        public DbSet<DanhSachDoiTuongGiaEntity> DanhSachDoiTuongGia { get; set; }
        public DbSet<DoiTuongGiaEntity> DoiTuongGia { get; set; }
        public DbSet<DongHoNuocEntity> DongHoNuoc { get; set; }
        public DbSet<DongHoNuocSuCoEntity> DongHoNuocSuCo { get; set; }
        public DbSet<HoaDonEntity> HoaDon { get; set; }
        public DbSet<HopDongEntity> HopDong { get; set; }
        public DbSet<KyGhiChiSoEntity> KyGhiChiSo { get; set; }
        public DbSet<KhachHangEntity> KhachHang { get; set; }
        public DbSet<KhuVucEntity> KhuVuc { get; set; }
        public DbSet<NguoiDungEntity> NguoiDung { get; set; }
        public DbSet<NhaMayEntity> NhaMay { get; set; }
        public DbSet<NhatKyDuLieuEntity> NhatKyDuLieu { get; set; }
        public DbSet<NhatKyHoaDonEntity> NhatKyHoaDon { get; set; }
        public DbSet<SoDocChiSoEntity> SoDocChiSo { get; set; }
        public DbSet<SuCoEntity> SuCo { get; set; }
        public DbSet<TuyenDocEntity> TuyenDoc { get; set; }
        public DbSet<PhuongThucThanhToanEntity> PhuongThucThanhToan { get; set; }
        public DbSet<PhiDuyTriEntity> PhiDuyTri { get; set; }
        public DbSet<ThatThoatEntity> ThatThoat { get; set; }
        public DbSet<PhienInThongBaoEntity> PhienInThongBao { get; set; }
        public DbSet<TrangThaiGhiEntity> TrangThaiGhi { get; set; }
        public DbSet<DanhMucSeriHoaDonEntity> DanhMucSeriHoaDon { get; set; }
        public DbSet<DanhMucThongBaoEntity> DanhMucThongBao { get; set; }
        public DbSet<DanhSachHoDanEntity> DanhSachHoDan { get; set; }
        public DbSet<LichSuSMSEntity> LichSuSM { get; set; }
        public DbSet<MauTinSMSEntity> MauTinSMS { get; set; }
        public DbSet<ThongBaoEntity> ThongBao { get; set; }
        public DbSet<VungEntity> Vung { get; set; }
        public DbSet<HangSanXuatEntity> HangSanXuat  { get; set; }
        public DbSet<HuyenEntity> Huyen{ get; set; }
        public DbSet<KieuDongHoEntity> KieuDongHo { get; set; }
        public DbSet<LyDoHuyEntity> LyDoHuy { get; set; }
        public DbSet<NuocSanXuatEntity> NuocSanXuat { get; set; }
        public DbSet<PhamViEntity> PhamVi { get; set; }
        public DbSet<TinhEntity> Tinh { get; set; }
        public DbSet<XaEntity> Xa { get; set; }
        public DbSet<DanhMucSPEntity> DanhMucSP { get; set; }
        public DbSet<SanPhamEntity> SanPham { get; set; }
        public DbSet<TheLoaiEntity> TheLoai { get; set; }
        public DbSet<NhaCungCapEntity> NhaCungCap { get; set; }
        public DbSet<DonHangEntity> DonHang { get; set; }
        public DbSet<ChiTietDonHangEntity> ChiTietDonHang{ get; set; }

    }
}
