using WaterCity.Core.EnumCore;

namespace WaterCity.Core.Models.ThongBao
{
    public class ThongBaoModel
    {
        public string KeyId { get; set; }
        public KieuGui KieuGuiTB { get; set; }
        public TrangThaiThanhToan TrangThaiTT { get; set; }
        public TinhTrangThongBao TinhTrang { get; set; }
        public TrangThaiThongBao TrangThaiTB { get; set; }
        public string DanhMucThongBaoId { get; set; }
        public string HoaDonId { get; set; }
    }
}
