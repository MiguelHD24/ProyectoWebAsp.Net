using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Detalle_Venta
    {
        public static detalle_venta InsertD_Ingreso(detalle_venta Entidad)
        {
            return DAL_Detalle_Venta.InsertD_Ingreso (Entidad);
        }
        public static bool Update(detalle_venta Entidad)
        {
            return DAL_Detalle_Venta.Update (Entidad);
        }
    }
}
