
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHangEntity : Entity
    {
        public decimal? SoLuong { get; set; }
        public decimal? DonGia { get; set; }

        [ForeignKey("DonHang")]
        public string? DonHangId { get; set; }
        public virtual DonHangEntity? DonHang { get; set; }

        [ForeignKey("SanPham")]
        public string? SanPhamId { get; set; }
        public virtual SanPhamEntity? SanPham{ get; set; }

    }
}
