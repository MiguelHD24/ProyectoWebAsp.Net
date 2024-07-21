using System;
using System.Collections.Generic;
using System.Linq;
using EL;
using DAL;
namespace BL
{
    public static class BL_venta
    {
        public static venta Insert(venta Entidad)
        {
            return DAL_venta.Insert(Entidad);
        }
        public static bool Update(venta Entidad)
        {
            return DAL_venta.Update(Entidad);
        }
        public static bool Anular(venta Entidad)
        {
            return DAL_venta.Anular(Entidad);
        }
        public static bool Existe(venta Entidad)
        {
            return DAL_venta.Existe(Entidad);
        }
        public static venta Registro(venta Entidad)
        {
            return DAL_venta.Registro(Entidad);
        }
        public static List<venta> Lista(bool Activo = true)
        {
            return DAL_venta.Lista(Activo);
        }
    }
}