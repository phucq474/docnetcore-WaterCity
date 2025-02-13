using WaterCity.Core.EnumCore;


namespace WaterCity.Core.Models.SanPham
{
    public class SanPhamModel
    {
        public string KeyId { get; set; }
        public string TenSanPham { get; set; }
        public decimal GiaSanPham { get; set; }       
        public string NhaCungCapId { get; set; }
        public string TheLoaiId { get; set; }
        public string DanhMucSPId { get; set; }

    }
}
