using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Cliente
    {
        public static cliente Insert(cliente Entidad)
        {
            return DAL_Cliente.Insert(Entidad);
        }
        public static bool Update(cliente Entidad)
        {
            return DAL_Cliente.Update(Entidad);
        }
        public static bool Delete(cliente Entidad)
        {
            return DAL_Cliente.Delete(Entidad);
        }
        public static List<cliente> List(bool Activo = true)
        {
            return DAL_Cliente.List(Activo);
        }
        public static cliente Registro(int idcliente)
        {
            return DAL_Cliente.Registro(idcliente);
        }
        public static List<cliente> Buscar(string Palabra)
        {
            return DAL_Cliente.Buscar(Palabra);
        }
    }
}
