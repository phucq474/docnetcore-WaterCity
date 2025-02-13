using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.DanhSachDoiTuongGia;

namespace WaterCity.Contract.Service
{
    public interface IDanhSachDoiTuongGiaService :
        Base.IGetable<DanhSachDoiTuongGiaEntity, string>,
        Base.ICreateable<DanhSachDoiTuongGiaModel, string>,
        Base.IUpdateable<DanhSachDoiTuongGiaModel, string>,
        Base.IDeleteable<string, bool>
    {/*
        Task<ICollection<DanhSachDoiTuongGiaModel>> GetAllDanhSachDoiTuongGia();
        Task DeleteDanhSachDoiTuongGia(string id, bool isPhysical = false, CancellationToken cancellationToken = default);*/
    }
}
