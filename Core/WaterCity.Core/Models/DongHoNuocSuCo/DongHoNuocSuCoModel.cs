namespace WaterCity.Core.Models.DongHoNuocSuCo
{
    public class DongHoNuocSuCoModel
    {
        public string KeyId { get; set; }  
        public DateTimeOffset NgaySuCo { get; set; }
        public string NguoiBaoCaoId { get; set; }
        public string NguoiThucHienId { get; set; }
        public int TienDo { get; set; }
        public string CachKhacPhuc { get; set; }
        public string DongHoNuocId { get; set; }
        public string SuCoId { get; set; }
    }
}
