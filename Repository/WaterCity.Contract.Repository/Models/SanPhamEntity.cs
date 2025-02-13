using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("SanPham")]
    public class SanPhamEntity : Entity
    {
        public string? TenSanPham { get; set; }
        public decimal? GiaSanPham { get; set; }

        [ForeignKey("NhaCungCap")]
        public string? NhaCungCapId { get; set; }

        [ForeignKey("TheLoai")]
        public string? TheLoaiId { get; set; }

        [ForeignKey("DanhMucSP")]
        public string? DanhMucSPId { get; set; }        
        public virtual NhaCungCapEntity? NhaCungCap { get; set; }
        public virtual DanhMucSPEntity? DanhMucSP { get; set; }
        public virtual TheLoaiEntity? TheLoai  { get; set; }
        public virtual ICollection<ChiTietDonHangEntity>? ChiTiets { get; set; }
        public virtual ICollection<DonHangEntity>? DonHangs { get; set; }

    }
}
