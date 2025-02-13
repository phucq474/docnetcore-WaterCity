using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Core.Models.DanhSachHoDan
{
    public class DanhSachHoDanModel
    {
        public string KeyId
        {
            get; set;
        }
        public string TenKhachHang
        {
            get; set;
        }
        public string? TenThuongGoi
        {
            get; set;
        }
        public int? SoHo
        {
            get; set;
        }
        public string? Email
        {
            get; set;
        }
        public string? DienThoai
        {
            get; set;
        }
        public int SoKhau
        {
            get; set;
        }
        public string? GhiChu
        {
            get; set;
        }
        public string KhuVucId
        {
            get; set;
        }
    }
}
