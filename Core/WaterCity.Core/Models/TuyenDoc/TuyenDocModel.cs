using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Core.Models.TuyenDoc
{
    public class TuyenDocModel
    {
        public string KeyId
        {
            get; set;
        }
        public string? NhaMayId
        {
            get; set;
        }
        public string NguoiQuanLyId
        {
            get; set;
        }
      /*  public string MaTuyen
        {
            get; set;
        }*/
        public string TenTuyen
        {
            get; set;
        }
        public string NguoiThuTienId
        {
            get; set;
        }
        public string KhuVucId
        {
            get; set;
        }
    }
}
