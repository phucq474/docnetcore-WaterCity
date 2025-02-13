using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Core.Models.ChiTietHoaDon
{
    public class ChiTietHoaDonModel
    {
        public string KeyId
        {
            get; set;
        }
        public decimal SoTieuThu
        {
            get; set;
        }
        public decimal DonGia
        {
            get; set;
        }
        public decimal ThanhTien
        {
            get; set;
        }
        public string HoaDonId
        {
            get; set;
        }
    }
}
