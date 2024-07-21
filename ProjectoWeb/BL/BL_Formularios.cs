using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Formularios
    {
        public static Formularios Insert(Formularios Entidad)
        {
            return DAL_Formularios.Insert(Entidad);
        }

        public static bool Update(Formularios Entidad)
        {
            return DAL_Formularios.Update(Entidad);
        }
        public static bool Delete(Formularios Entidad)
        {
            return DAL_Formularios.Delete(Entidad);
        }
        public static List<Formularios> List(bool Activo = true)
        {
            return DAL_Formularios.List(Activo);
        }
        public static Formularios Registro(int IdRegistro)
        {
            return DAL_Formularios.Registro(IdRegistro);
        }
        public static List<Formularios> Buscar(string Palabra)
        {
            return DAL_Formularios.Buscar(Palabra);
        }

    }
}
