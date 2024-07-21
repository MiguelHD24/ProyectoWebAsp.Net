using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BL
{
    public class BL_Roles
    {
        public static Roles Insert(Roles Entidad)
        {
            return DAL_Roles.Insert(Entidad);
        }

        public static Roles Insertar(Roles Entidad)
        {
            return DAL_Roles.Insertar(Entidad);
        }
        public static bool Update(Roles Entidad)
        {
            return DAL_Roles.Update(Entidad);
        }
        public static bool Actualizar(Roles Entidad)
        {
            return DAL_Roles.Actualizar(Entidad);
        }
        public static bool Delete(Roles Entidad)
        {
            return DAL_Roles.Delete(Entidad);
        }
        public static bool Eliminar(Roles Entidad)
        {
            return DAL_Roles.Eliminar(Entidad);
        }
        public static List<Roles> List(bool Activo = true)
        {
            return DAL_Roles.List(Activo);
        }
        public static List<Roles> Lista(bool Activo = true)
        {
            return DAL_Roles.Lista(Activo);
        }
        public static Roles Registro(int IdRegistro)
        {
            return DAL_Roles.Registro(IdRegistro);
        }
        public static Roles Registro_(int IdRegistro)
        {
            return DAL_Roles.Registro_(IdRegistro);
        }
        public static List<Roles> Buscar(string Palabra)
        {
            return DAL_Roles.Buscar(Palabra);
        }
        public static List<Roles> Buscar_(string Palabra)
        {
            return DAL_Roles.Buscar_(Palabra);
        }

    }
}
