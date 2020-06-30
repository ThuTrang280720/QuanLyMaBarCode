using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_Win.Controlls
{
    class sp
    {
        private static Image qrCode;
        private static Image maVach;

        public static Image QrCode { get => qrCode; set => qrCode = value; }
        public static Image MaVach { get => maVach; set => maVach = value; }
    }
}
