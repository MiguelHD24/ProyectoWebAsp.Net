using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_RolFormulario
    {
        public static RolFormularios Insert(RolFormularios Entidad)
        {
            return DAL_RolFormulario.Insert(Entidad);
        }
        public static bool Update(RolFormularios Entidad)
        {
            return DAL_RolFormulario.Update(Entidad);
        }
        public static bool Delete(RolFormularios Entidad)
        {
            return DAL_RolFormulario.Delete(Entidad);
        }
        public static List<RolFormularios> List(int IdRol, bool Activo = true)
        {
            return DAL_RolFormulario.List(IdRol, Activo);
        }
        public static RolFormularios Registro(int IdRegistro)
        {
            return DAL_RolFormulario.Registro(IdRegistro);
        }

    }
}
