namespace WaterCity.Core.Models.KyGhiChiSo
{
    public class KyGhiChiSoModel
    {
        public string KeyId { get; set; }
        public string MoTa
        {
            get; set;
        }
        public DateTimeOffset NgaySuDungTu
        {
            get; set;
        }
        public DateTimeOffset NgaySuDungDen
        {
            get; set;
        }
        public DateTimeOffset NgayHoaDon
        {
            get; set;
        }

        // [ForeignKey("NhaMay")]
        public string NhaMayId
        {
            get; set;
        }
    }
}
