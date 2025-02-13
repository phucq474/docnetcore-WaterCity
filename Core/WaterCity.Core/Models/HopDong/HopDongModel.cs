namespace WaterCity.Core.Models.HopDong
{
    public class HopDongModel
    {
        public string KeyId { get; set; }

        public string DoiTuongGiaId
        {
            get; set;
        }

        public string? KhachHangId
        {
            get; set;
        }

        public string TuyenDocId
        {
            get; set;
        }

        public string? NhaMayId
        {
            get; set;
        }

        public string? PhuongThucThanhToanId
        {
            get; set;
        }

        public string? KhuVucThanhToan
        {
            get; set;
        }
        
        public DateTimeOffset? NgayKyHopDong
        {
            get; set;
        }

        public DateTimeOffset? NgayLapDat
        {
            get; set;
        }

        public string? GhiChu
        {
            get; set;
        }

        public string? Diachi
        {
            get; set;
        }

        public decimal KinhDo { get; set; }
        public decimal ViDo { get; set; }

        public DateTimeOffset? NgayCoHieuLuc
        {
            get; set;
        }
        
        public string MucDichSuDung
        {
            get; set;
        }
    }
}
