using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.EnumCore
{
    //MKhoi = mét khối
    //SD = sử dụng
    //Ko = không
    public enum CachTinhPhiDuyTri
    {
        //MKhoi,
        //TienHoaDon,
        //TienMKhoi,
        //TienMKhoi_KoMienPhi,
        //MKhoiHoaDon_KoSDNuoc,
        //TienHoaDon_KoSDNuoc
        MKhoi = 1,
        TienHoaDon = 2,
        TienMKhoi = 3,
        TienMKhoi_KoMienPhi = 4,
        MKhoiHoaDon_KoSDNuoc = 5,
        TienHoaDon_KoSDNuo = 6

    }
}
