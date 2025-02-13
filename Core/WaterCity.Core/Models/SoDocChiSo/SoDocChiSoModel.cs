using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Core.Models.SoDocChiSo
{
    public class SoDocChiSoModel
    {
        public string KeyId
        {
            get; set;
        }
        public string? TuyenDocId
        {
            get; set;
        }
        public string? NhaMayId
        {
            get; set;
        }
        public string NguoiDungId
        {
            get; set;
        }
        public string KyGhiChiSoId
        {
            get; set;
        }
        public string TenSo
        {
            get; set;
        }
        public int? SoDhdaGhi
        {
            get; set;
        }
        public bool? ChotSo
        {
            get; set;
        }
        public string? TrangThai
        {
            get; set;
        }
        public DateTimeOffset? NgayChot
        {
            get; set;
        }
        public string? HoaDon
        {
            get; set;
        }
    }
}
