using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Detalle_Ingreso
    {
        //Insert
        public static detalle_ingreso InsertD_Ingreso(detalle_ingreso Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                
                bd.Detalle_ingreso.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        //Update
        public static bool Update(detalle_ingreso Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Detalle_ingreso.Find(Entidad.iddetalle_ingreso);
                RegistroBD.precio_compra = Entidad.precio_compra;
                RegistroBD.precio_venta = Entidad.precio_venta;
                RegistroBD.stock_inicial = Entidad.stock_inicial;
                RegistroBD.stock_actual = Entidad.stock_actual;
                RegistroBD.fecha_produccion = Entidad.fecha_produccion;
                RegistroBD.fecha_vencimiento = Entidad.fecha_vencimiento;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }


    }
}
