namespace WaterCity.Core.Models.HoaDon
{
    public class HoaDonModel
    {
        public string KeyId { get; set; }
        public string TrangThaiThanhToan
        {
            get; set;
        }
        public string NguoiThuTienId
        {
            get; set;
        }
        public string GhiChu
        {
            get; set;
        }
        public decimal TongTienTruocVat
        {
            get; set;
        }
        public decimal Vat
        {
            get; set;
        }

        public decimal PhiDtdn
        {
            get; set;
        }
        public decimal? PhiBvmt
        {
            get; set;
        }

        public string SeriHoaDon
        {
            get; set;
        }
        public string ChiSoDongHoId
        {
            get; set;
        }
        public string? PhienInThongBaoId { get; set; }
    }
}
