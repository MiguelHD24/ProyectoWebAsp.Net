using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Permisos
    {
        public static Permisos Insert(Permisos Entidad)
        {
            return DAL_Permisos.Insert(Entidad);
        }
        public static bool Update(Permisos Entidad)
        {
            return DAL_Permisos.Update(Entidad);
        }
        public static bool Delete(Permisos Entidad)
        {
            return DAL_Permisos.Delete(Entidad);
        }
        public static List<Permisos> List(bool Activo = true)
        {
            return DAL_Permisos.List(Activo);
        }
        public static Permisos Registro(int IdRegistro)
        {
            return DAL_Permisos.Registro(IdRegistro);
        }
        public static List<Permisos> Buscar(string Palabra)
        {
            return DAL_Permisos.Buscar(Palabra);
        }

    }
}
