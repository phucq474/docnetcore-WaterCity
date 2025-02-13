
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DanhMucSP")]
    public class DanhMucSPEntity : Entity
    {
        public string? TenDanhMucSP { get; set; }        
        public virtual ICollection<SanPhamEntity>? SanPhams { get; set; }

    }
}
