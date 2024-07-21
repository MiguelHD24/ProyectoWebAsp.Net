using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Proveedor
    {
        public static proveedor Insert(proveedor Entidad)
        {
            return DAL_Proveedor.Insert(Entidad);
        }
        public static bool Update(proveedor Entidad)
        {
            return DAL_Proveedor.Update(Entidad);
        }
        public static bool Eliminar(proveedor Entidad)
        {
            return DAL_Proveedor.Eliminar(Entidad);
        }
        public static List<proveedor> List(bool Activo = true)
        {
            return DAL_Proveedor.List(Activo);
        }
        public static List<proveedor> Buscar(string Palabra)
        {
            return DAL_Proveedor.Buscar(Palabra);
        }
    }
}
