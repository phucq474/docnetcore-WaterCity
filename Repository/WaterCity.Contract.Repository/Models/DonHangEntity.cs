using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DonHang")]
    public class DonHangEntity : Entity
    {
        public string? TenDonHang { get; set; }
        public DateTimeOffset? NgayDat { get; set; }
        public string? TenKhachHang { get; set; }
        public string? DiaChiGiao { get; set; }
        public decimal? TongTien { get; set; }
        public virtual ICollection<ChiTietDonHangEntity>? ChiTiets { get; set; }
        public virtual ICollection<SanPhamEntity>? SanPhams { get; set; }

    }
}
