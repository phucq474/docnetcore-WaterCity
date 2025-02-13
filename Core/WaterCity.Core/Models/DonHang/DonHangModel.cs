using WaterCity.Core.EnumCore;


namespace WaterCity.Core.Models.DonHang
{
    public class DonHangModel    
    {
        public string KeyId { get; set; }
        public string TenDonHang { get; set; }
        public DateTimeOffset? NgayDat { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChiGiao { get; set; }
        public decimal TongTien { get; set; }         
    }
}
