namespace WaterCity.Core.Models.ChiTietGia
{
    public class ChiTietGiaModel
    {
        public string KeyId
        {
            get; set;
        }
        public string MoTaChiTiet
        {
            get; set;
        }
        public decimal TuSo
        {
            get; set;
        }
        public decimal DenSo
        {
            get; set;
        }
        public decimal GiaCoVat
        {
            get; set;
        }
        public decimal Gia
        {
            get; set;
        }
        public string? DoiTuongGiaId
        {
            get; set;
        }
    }
}
