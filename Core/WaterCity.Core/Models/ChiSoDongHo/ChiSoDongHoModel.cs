using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Core.Models.ChiSoDongHo
{
    public class ChiSoDongHoModel
    {
        public string KeyId
        {
            get; set;
        }
        public int ChiSoCu
        {
            get; set;
        }
        public int ChiSoMoi
        {
            get; set;
        }
        public DateTimeOffset NgayDoc
        {
            get; set;
        }
        public DateTimeOffset? NgayDongBo
        {
            get; set;
        }
        public int? ChiSoDauCu
        {
            get; set;
        }
        public int? ChiSoCuoiCu
        {
            get; set;
        }
        public string? GhiChu
        {
            get; set;
        }
        public string? Tthu
        {
            get; set;
        }
        public string DongHoNuocId
        {
            get; set;
        }
        public string SoDocChiSoId
        {
            get; set;
        }
        public string? TrangThaiGhiId
        {
            get; set;
        }
    }
}
