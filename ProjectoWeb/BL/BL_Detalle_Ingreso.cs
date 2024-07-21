using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Detalle_Ingreso
    {
        public static detalle_ingreso InsertD_Ingreso(detalle_ingreso Entidad)
        {
            return DAL_Detalle_Ingreso.InsertD_Ingreso (Entidad);
        }
        public static bool Update(detalle_ingreso Entidad)
        {
            return DAL_Detalle_Ingreso.Update (Entidad);
        }
    }
}
