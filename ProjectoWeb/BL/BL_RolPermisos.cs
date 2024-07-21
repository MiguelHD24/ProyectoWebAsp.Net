using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_RolPermisos
    {
        public static RolPermisos Insert(RolPermisos Entidad)
        {
            return DAL_RolPermisos.Insert(Entidad);
        }
        public static bool Update(RolPermisos Entidad)
        {
            return DAL_RolPermisos.Update(Entidad);
        }
        public static bool Delete(RolPermisos Entidad)
        {
            return DAL_RolPermisos.Delete(Entidad);
        }
        public static List<RolPermisos> List(int IdRol, bool Activo = true)
        {
            return DAL_RolPermisos.List(IdRol, Activo);
        }
        public static RolPermisos Registro(int IdRegistro)
        {
            return DAL_RolPermisos.Registro(IdRegistro);
        }

    }
}
