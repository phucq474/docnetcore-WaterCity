using WaterCity.Core.EnumCore;

namespace WaterCity.Core.Models.DanhMucThongBao
{
    public class DanhMucThongBaoModel
    {
        public string KeyId { get; set; }
        public HinhThucThongBao HinhThuc { get; set; }
        public string NguoiGuiId { get; set; }
        public DateTimeOffset ThoiGian { get; set; }
        public string TenLanGui { get; set; }
    }
}
