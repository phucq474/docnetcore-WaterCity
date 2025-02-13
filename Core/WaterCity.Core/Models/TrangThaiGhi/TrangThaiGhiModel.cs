using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.TrangThaiGhi
{
    public class TrangThaiGhiModel
    {
        public string KeyId { get; set; }
        public string TenTrangThai { get; set; }
        public string MaMau { get; set; }
        public string? MoTaNgan { get; set; }
        public int? SoTt { get; set; }
        public bool? KhongChoPhepGhi { get; set; }
        public bool? KhongChoPhepHienThi { get; set; }
    }
}
