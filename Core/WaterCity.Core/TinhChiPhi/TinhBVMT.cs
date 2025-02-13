using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterCity.Core.EnumCore;

namespace WaterCity.Core.TinhChiPhi
{
    public class TinhBVMT
    {
        public decimal GiaBVMT(CachTinhBVMT cTinh, decimal donViTinh, decimal giaTri)
        {
            //Tính theo phần trăm: tiền theo phần trăm
            if (cTinh == CachTinhBVMT.PhanTram)
            {
                return giaTri * (donViTinh / 100);
            }
            //Tính theo m3: số lượng m3 * tiền
            else if (cTinh == CachTinhBVMT.M3)
            {
                return donViTinh * giaTri;
            }
            //tính theo m3: không miễn phí
            return donViTinh * giaTri;
        }

    }
}
