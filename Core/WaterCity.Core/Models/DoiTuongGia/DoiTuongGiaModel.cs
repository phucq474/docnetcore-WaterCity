using WaterCity.Core.EnumCore;

namespace WaterCity.Core.Models.DoiTuongGia
{
    public class DoiTuongGiaModel
    {
        public string KeyId { get; set; }
        public DateTimeOffset NgayBatDau { get; set; }
        public DateTimeOffset? NgayKetThuc { get; set; }

        public decimal VAT { get; set; }
        public CachTinhBVMT BVMT { get; set; }
        public decimal PhiBvmt { get; set; }

        public CachTinhDTGia DTTinhGia { get; set; }
        public KieuTinhGia KieuTinh { get; set; }
        public bool CoToiThieu { get; set; }
        public decimal? TinhTu { get; set; }
        public decimal? ToiThieu { get; set; }
        public string? PhiDuyTriId { get; set; }
        public string DanhSachDoiTuongGiaId { get; set; }
    }
}
