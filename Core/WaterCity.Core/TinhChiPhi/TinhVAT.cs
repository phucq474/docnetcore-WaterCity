using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.TinhChiPhi
{
    public class TinhVAT
    {

        public decimal GiaVAT(decimal ChiPhi, decimal VAT)
        {
            return ChiPhi * (VAT / 100);
        }
        public decimal ChiPhiCoVAT(decimal ChiPhi, decimal VAT)
        {
            return ChiPhi + GiaVAT(ChiPhi, VAT);
        }
    }
}
