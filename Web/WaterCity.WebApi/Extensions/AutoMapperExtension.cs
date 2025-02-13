using WaterCity.Mapper;

namespace WaterCity.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new VungProfile());
                cfg.AddProfile(new NhaMayProfile());
                cfg.AddProfile(new DanhSachDoiTuongGiaProfile());
                cfg.AddProfile(new NhatKyDuLieuProfile());
                cfg.AddProfile(new KhachHangProfile());
                cfg.AddProfile(new PhiDuyTriProfile()); 
                cfg.AddProfile(new HopDongProfile());
                cfg.AddProfile(new SuCoProfile());
                cfg.AddProfile(new TuyenDocProfile());
                cfg.AddProfile(new DongHoNuocSuCoProfile());
                cfg.AddProfile(new DongHoNuocProfile());
                cfg.AddProfile(new ChiTietGiaProfile());
                cfg.AddProfile(new DoiTuongGiaProfile());
                cfg.AddProfile(new KhuVucProfile());
                cfg.AddProfile(new ThatThoatProfile());
                cfg.AddProfile(new ChiSoDongHoProfile());
                cfg.AddProfile(new DongHoNuocProfile());
                cfg.AddProfile(new SoDocChiSoProfile());
                cfg.AddProfile(new TrangThaiGhiProfile());
                cfg.AddProfile(new KyGhiChiSoProfile());
                cfg.AddProfile(new DanhMucSeriHoaDonProfile());
                cfg.AddProfile(new PhienInThongBaoProfile());
                cfg.AddProfile(new HoaDonProfile());
                cfg.AddProfile(new DanhMucThongBaoProfile());
                cfg.AddProfile(new ThongBaoProfile());
                cfg.AddProfile(new DanhSachHoDanProfile());
                cfg.AddProfile(new PhuongThucThanhToanProfile());
                cfg.AddProfile(new MauTinSMSProfile());
                cfg.AddProfile(new LichSuSMSProfile());
                cfg.AddProfile(new NhatKyHoaDonProfile());
                cfg.AddProfile(new ChiTietHoaDonProfile());
                cfg.AddProfile(new NguoiDungProfile());
                cfg.AddProfile(new TinhProfile());
                cfg.AddProfile(new HuyenProfile());
                cfg.AddProfile(new XaProfile());
                cfg.AddProfile(new PhamViProfile());
                cfg.AddProfile(new LyDoHuyProfile());
                cfg.AddProfile(new KieuDongHoProfile());
                cfg.AddProfile(new NuocSanXuatProfile());
                cfg.AddProfile(new HangSanXuatProfile());
                cfg.AddProfile(new DanhMucSPProfile());
                cfg.AddProfile(new TheLoaiProfile());
                cfg.AddProfile(new NhaCungCapProfile());
                cfg.AddProfile(new SanPhamProfile());
                cfg.AddProfile(new DonHangProfile());
                cfg.AddProfile(new ChiTietDonHangProfile());
            });
            return services;
        }
    }
}
