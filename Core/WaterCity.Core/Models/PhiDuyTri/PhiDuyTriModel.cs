using WaterCity.Core.EnumCore;

namespace WaterCity.Core.Models.PhiDuyTri
{
    public class PhiDuyTriModel
    {
        public string KeyId { get; set; }
        public CachTinhPhiDuyTri KieuTinh { get; set; }
        public decimal DonGia { get; set; }
        public decimal? VAT { get; set; }
        public decimal? ApDungKhiTieuThu { get; set; }
    }
}
