using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Core.Models.NhatKyHoaDon
{
    public class NhatKyHoaDonModel
    {
        public string KeyId
        {
            get; set;
        }
        public string NguoiDungId
        {
            get; set;
        }
        public DateTimeOffset NgaySua
        {
            get; set;
        }
        public string NoiDung
        {
            get; set;
        }
        public string HoaDonId
        {
            get; set;
        }
    }
}
