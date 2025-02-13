
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("TheLoai")]
    public class TheLoaiEntity : Entity
    {
        public string? TenTheLoai { get; set; }
        //quan hệ 1-n từ phía 1
        public virtual ICollection<SanPhamEntity>? SanPhams { get; set; } 

    }
}
