using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.PhienInThongBao
{
    public class PhienInThongBaoModel
    {
        public string KeyId { get; set; }
        public string? TenPhien { get; set; }
        public DateTimeOffset? NgayTao { get; set; }
        public int? DaInXong { get; set; }
        public int? SoLuongHopDong { get; set; }
        public string? NhaMayId { get; set; }
        public string? NguoiDocId { get; set; }
    }
}
