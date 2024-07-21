using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Detalle_Venta
    {
        public static detalle_venta InsertD_Ingreso(detalle_venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {

                bd.Detalle_venta.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        //Update
        public static bool Update(detalle_venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Detalle_venta.Find(Entidad.iddetalle_venta);
                RegistroBD.idventa = Entidad.idventa;
                RegistroBD.iddetalle_ingreso = Entidad.iddetalle_ingreso;
                RegistroBD.cantidad = Entidad.cantidad;
                RegistroBD.precio_venta = Entidad.precio_venta;
                RegistroBD.descuento = Entidad.descuento;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
    }
}
