namespace WaterCity.Core.Constants
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";

        public static class Vung
        {
            private const string BaseEndpoint = "~/" + AreaName + "/vung";
            public const string GetVung = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllVung = BaseEndpoint + "/get-all";
            public const string AddVung = BaseEndpoint + "/add";
            public const string UpdateVung = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteVung = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class NhaMay
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nha-may";
            public const string GetNhaMay = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNhaMay = BaseEndpoint + "/get-all";
            public const string AddNhaMay = BaseEndpoint + "/add";
            public const string UpdateNhaMay = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNhaMay = BaseEndpoint + "/delete" + "/{keyId}";

        }

        public static class DanhSachDoiTuongGia
        {
            private const string BaseEndpoint = "~/" + AreaName + "/danh-sach-doi-tuong-gia";
            public const string GetDanhSachDoiTuongGia = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDanhSachDoiTuongGia = BaseEndpoint + "/get-all";
            public const string AddDanhSachDoiTuongGia = BaseEndpoint + "/add";
            public const string UpdateDanhSachDoiTuongGia = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDanhSachDoiTuongGia = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class NhatKyDuLieu
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhat-ky-du-lieu";
            public const string GetNhatKyDuLieu = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNhatKyDuLieu = BaseEndpoint + "/get-all";
            public const string AddNhatKyDuLieu = BaseEndpoint + "/add";
            public const string UpdateNhatKyDuLieu = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNhatKyDuLieu = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class KhachHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khach-hang";
            public const string GetKhachHang = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllKhachHang = BaseEndpoint + "/get-all";
            public const string AddKhachHang = BaseEndpoint + "/add";
            public const string UpdateKhachHang = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteKhachHang = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class PhiDuyTri
        {
            private const string BaseEndpoint = "~/" + AreaName + "/phi-duy-tri";
            public const string GetPhiDuyTri = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllPhiDuyTri = BaseEndpoint + "/get-all";
            public const string AddPhiDuyTri = BaseEndpoint + "/add";
            public const string UpdatePhiDuyTri = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeletePhiDuyTri = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class TuyenDoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/tuyen-doc";
            public const string GetTuyenDoc = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllTuyenDoc = BaseEndpoint + "/get-all";
            public const string AddTuyenDoc = BaseEndpoint + "/add";
            public const string UpdateTuyenDoc = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteTuyenDoc = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class KhuVuc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/khu-vuc";
            public const string GetKhuVuc = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllKhuVuc = BaseEndpoint + "/get-all";
            public const string AddKhuVuc = BaseEndpoint + "/add";
            public const string UpdateKhuVuc = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteKhuVuc = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class DoiTuongGia
        {
            private const string BaseEndpoint = "~/" + AreaName + "/doi-tuong-gia";
            public const string GetDoiTuongGia = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDoiTuongGia = BaseEndpoint + "/get-all";
            public const string AddDoiTuongGia = BaseEndpoint + "/add";
            public const string UpdateDoiTuongGia = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDoiTuongGia = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class HopDong
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hop-dong";
            public const string GetHopDongByKeyId = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetHopDongById = BaseEndpoint + "/get-single" + "/{Id}";
            public const string GetAllHopDong = BaseEndpoint + "/get-all";
            public const string AddHopDong = BaseEndpoint + "/add";
            public const string UpdateHopDong = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteHopDong = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class SuCo
        {
            private const string BaseEndpoint = "~/" + AreaName + "/su-co";
            public const string GetSuCo = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllSuCo = BaseEndpoint + "/get-all";
            public const string AddSuCo = BaseEndpoint + "/add";
            public const string UpdateSuCo = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteSuCo = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class DongHoNuocSuCo
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dong-ho-nuoc-su-co";
            public const string GetDongHoNuocSuCo = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDongHoNuocSuCo = BaseEndpoint + "/get-all";
            public const string AddDongHoNuocSuCo = BaseEndpoint + "/add";
            public const string UpdateDongHoNuocSuCo = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDongHoNuocSuCo = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class DongHoNuoc
        {
            private const string BaseEndpoint = "~/" + AreaName + "/dong-ho-nuoc";
            public const string GetDongHoNuoc = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDongHoNuoc = BaseEndpoint + "/get-all";
            public const string AddDongHoNuoc = BaseEndpoint + "/add";
            public const string UpdateDongHoNuoc = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDongHoNuoc = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class ChiTietGia
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-gia";
            public const string GetChiTietGia = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllChiTietGia = BaseEndpoint + "/get-all";
            public const string AddChiTietGia = BaseEndpoint + "/add";
            public const string UpdateChiTietGia = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteChiTietGia = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class ThatThoat
        {
            private const string BaseEndpoint = "~/" + AreaName + "/that-thoat";
            public const string GetThatThoat = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllThatThoat = BaseEndpoint + "/get-all";
            public const string AddThatThoat = BaseEndpoint + "/add";
            public const string UpdateThatThoat = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteThatThoat = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class ChiSoDongHo
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-so-dong-ho";
            public const string GetChiSoDongHo = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllChiSoDongHo = BaseEndpoint + "/get-all";
            public const string AddChiSoDongHo = BaseEndpoint + "/add";
            public const string UpdateChiSoDongHo = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteChiSoDongHo = BaseEndpoint + "/delete" + "/{keyId}";
        }
        
        public static class SoDocChiSo
        {
            private const string BaseEndpoint = "~/" + AreaName + "/so-doc-chi-so";
            public const string GetSoDocChiSo = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllSoDocChiSo = BaseEndpoint + "/get-all";
            public const string AddSoDocChiSo = BaseEndpoint + "/add";
            public const string UpdateSoDocChiSo = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteSoDocChiSo = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class TrangThaiGhi
        {
            private const string BaseEndpoint = "~/" + AreaName + "/trang-thai-ghi";
            public const string GetTrangThaiGhi = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllTrangThaiGhi = BaseEndpoint + "/get-all";
            public const string AddTrangThaiGhi = BaseEndpoint + "/add";
            public const string UpdateTrangThaiGhi = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteTrangThaiGhi = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class KyGhiChiSo
        {
            private const string BaseEndpoint = "~/" + AreaName + "/ky-ghi-chi-so";
            public const string GetKyGhiChiSo = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllKyGhiChiSo = BaseEndpoint + "/get-all";
            public const string AddKyGhiChiSo = BaseEndpoint + "/add";
            public const string UpdateKyGhiChiSo = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteKyGhiChiSo = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class DanhMucSeriHoaDon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/danh-muc-seri-hoa-don";
            public const string GetDanhMucSeriHoaDon = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDanhMucSeriHoaDon = BaseEndpoint + "/get-all";
            public const string AddDanhMucSeriHoaDon = BaseEndpoint + "/add";
            public const string UpdateDanhMucSeriHoaDon = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDanhMucSeriHoaDon = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class PhienInThongBao
        {
            private const string BaseEndpoint = "~/" + AreaName + "/phien-in-thong-bao";
            public const string GetPhienInThongBao = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllPhienInThongBao = BaseEndpoint + "/get-all";
            public const string AddPhienInThongBao = BaseEndpoint + "/add";
            public const string UpdatePhienInThongBao = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeletePhienInThongBao = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class HoaDon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hoa-don";
            public const string GetHoaDon = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllHoaDon = BaseEndpoint + "/get-all";
            public const string AddHoaDon = BaseEndpoint + "/add";
            public const string UpdateHoaDon = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteHoaDon = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class DanhMucThongBao
        {
            private const string BaseEndpoint = "~/" + AreaName + "/danh-muc-thong-bao";
            public const string GetDanhMucThongBao = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDanhMucThongBao = BaseEndpoint + "/get-all";
            public const string AddDanhMucThongBao = BaseEndpoint + "/add";
            public const string UpdateDanhMucThongBao = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDanhMucThongBao = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class ThongBao
        {
            private const string BaseEndpoint = "~/" + AreaName + "/thong-bao";
            public const string GetThongBao = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllThongBao = BaseEndpoint + "/get-all";
            public const string AddThongBao = BaseEndpoint + "/add";
            public const string UpdateThongBao = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteThongBao = BaseEndpoint + "/delete" + "/{keyId}";
        }
        
        public static class PhuongThucThanhToan
        {
            private const string BaseEndpoint = "~/" + AreaName + "/phuong-thuc-thanh-toan";
            public const string GetPhuongThucThanhToan = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllPhuongThucThanhToan = BaseEndpoint + "/get-all";
            public const string AddPhuongThucThanhToan = BaseEndpoint + "/add";
            public const string UpdatePhuongThucThanhToan = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeletePhuongThucThanhToan = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class DanhSachHoDan
        {
            private const string BaseEndpoint = "~/" + AreaName + "/danh-sach-ho-dan";
            public const string GetDanhSachHoDan = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDanhSachHoDan = BaseEndpoint + "/get-all";
            public const string AddDanhSachHoDan = BaseEndpoint + "/add";
            public const string UpdateDanhSachHoDan = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDanhSachHoDan = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class MauTinSMS
        {
            private const string BaseEndpoint = "~/" + AreaName + "/mau-tin-sms";
            public const string GetMauTinSMS = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllMauTinSMS = BaseEndpoint + "/get-all";
            public const string AddMauTinSMS = BaseEndpoint + "/add";
            public const string UpdateMauTinSMS = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteMauTinSMS = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class LichSuSMS
        {
            private const string BaseEndpoint = "~/" + AreaName + "/lich-su-sms";
            public const string GetLichSuSMS = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllLichSuSMS = BaseEndpoint + "/get-all";
            public const string AddLichSuSMS = BaseEndpoint + "/add";
            public const string UpdateLichSuSMS = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteLichSuSMS = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class NhatKyHoaDon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nhat-ky-hoa-don";
            public const string GetNhatKyHoaDon = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNhatKyHoaDon = BaseEndpoint + "/get-all";
            public const string AddNhatKyHoaDon = BaseEndpoint + "/add";
            public const string UpdateNhatKyHoaDon = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNhatKyHoaDon = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class ChiTietHoaDon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-hoa-don";
            public const string GetChiTietHoaDon = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllChiTietHoaDon = BaseEndpoint + "/get-all";
            public const string AddChiTietHoaDon = BaseEndpoint + "/add";
            public const string UpdateChiTietHoaDon = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteChiTietHoaDon = BaseEndpoint + "/delete" + "/{keyId}";
        }

        public static class NguoiDung
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nguoi-dung";
            public const string GetNguoiDung = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNguoiDung = BaseEndpoint + "/get-all";
            public const string AddNguoiDung = BaseEndpoint + "/add";
            public const string UpdateNguoiDung = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNguoiDung = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class Tinh
        {
            private const string BaseEndpoint = "~/" + AreaName + "/tinh";
            public const string GetTinh = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllTinh = BaseEndpoint + "/get-all";
            public const string AddTinh = BaseEndpoint + "/add";
            public const string UpdateTinh = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteTinh = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class Huyen
        {
            private const string BaseEndpoint = "~/" + AreaName + "/huyen";
            public const string GetHuyen = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllHuyen = BaseEndpoint + "/get-all";
            public const string AddHuyen = BaseEndpoint + "/add";
            public const string UpdateHuyen = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteHuyen = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class Xa
        {
            private const string BaseEndpoint = "~/" + AreaName + "/xa";
            public const string GetXa = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllXa = BaseEndpoint + "/get-all";
            public const string AddXa = BaseEndpoint + "/add";
            public const string UpdateXa = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteXa = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class PhamVi
        {
            private const string BaseEndpoint = "~/" + AreaName + "/pham-vi";
            public const string GetPhamVi = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllPhamVi = BaseEndpoint + "/get-all";
            public const string AddPhamVi = BaseEndpoint + "/add";
            public const string UpdatePhamVi = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeletePhamVi = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class LyDoHuy
        {
            private const string BaseEndpoint = "~/" + AreaName + "/ly-do-huy";
            public const string GetLyDoHuy = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllLyDoHuy = BaseEndpoint + "/get-all";
            public const string AddLyDoHuy = BaseEndpoint + "/add";
            public const string UpdateLyDoHuy = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteLyDoHuy = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class KieuDongHo
        {
            private const string BaseEndpoint = "~/" + AreaName + "/kieu-dong-ho";
            public const string GetKieuDongHo = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllKieuDongHo = BaseEndpoint + "/get-all";
            public const string AddKieuDongHo = BaseEndpoint + "/add";
            public const string UpdateKieuDongHo = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteKieuDongHo = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class NuocSanXuat
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nuoc-san-xuat";
            public const string GetNuocSanXuat = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNuocSanXuat = BaseEndpoint + "/get-all";
            public const string AddNuocSanXuat = BaseEndpoint + "/add";
            public const string UpdateNuocSanXuat = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNuocSanXuat = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class HangSanXuat
        {
            private const string BaseEndpoint = "~/" + AreaName + "/hang-san-xuat";
            public const string GetHangSanXuat = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllHangSanXuat = BaseEndpoint + "/get-all";
            public const string AddHangSanXuat = BaseEndpoint + "/add";
            public const string UpdateHangSanXuat = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteHangSanXuat = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class DanhMucSP
        {
            private const string BaseEndpoint = "~/" + AreaName + "/danh-muc-sp";
            public const string GetDanhMucSP = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDanhMucSP = BaseEndpoint + "/get-all";
            public const string AddDanhMucSP = BaseEndpoint + "/add";
            public const string UpdateDanhMucSP = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDanhMucSP = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class TheLoai
        {
            private const string BaseEndpoint = "~/" + AreaName + "/the-loai";
            public const string GetTheLoai = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllTheLoai = BaseEndpoint + "/get-all";
            public const string AddTheLoai = BaseEndpoint + "/add";
            public const string UpdateTheLoai = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteTheLoai = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class NhaCungCap
        {
            private const string BaseEndpoint = "~/" + AreaName + "/nha-cung-cap";
            public const string GetNhaCungCap = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllNhaCungCap = BaseEndpoint + "/get-all";
            public const string AddNhaCungCap = BaseEndpoint + "/add";
            public const string UpdateNhaCungCap = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteNhaCungCap = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class SanPham
        {
            private const string BaseEndpoint = "~/" + AreaName + "/san-pham";
            public const string GetSanPham = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllSanPham = BaseEndpoint + "/get-all";
            public const string AddSanPham = BaseEndpoint + "/add";
            public const string UpdateSanPham = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteSanPham = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class DonHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/don-hang";
            public const string GetDonHang = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllDonHang = BaseEndpoint + "/get-all";
            public const string AddDonHang = BaseEndpoint + "/add";
            public const string UpdateDonHang = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteDonHang = BaseEndpoint + "/delete" + "/{keyId}";
        }
        public static class ChiTietDonHang
        {
            private const string BaseEndpoint = "~/" + AreaName + "/chi-tiet-don-hang";
            public const string GetChiTietDonHang = BaseEndpoint + "/get-single" + "/{keyId}";
            public const string GetAllChiTietDonHang = BaseEndpoint + "/get-all";
            public const string AddChiTietDonHang = BaseEndpoint + "/add";
            public const string UpdateChiTietDonHang = BaseEndpoint + "/update" + "/{keyId}";
            public const string DeleteChiTietDonHang = BaseEndpoint + "/delete" + "/{keyId}";
        }
    }
}