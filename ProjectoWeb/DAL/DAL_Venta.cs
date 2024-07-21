using System;
using System.Collections.Generic;
using System.Linq;
using EL;

namespace DAL
{
    public static class DAL_venta
    {
        public static venta Insert(venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                bd.Venta.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Venta.Find(Entidad.idventa);
                Registro.idcliente = Entidad.idcliente;
                Registro.IdUsuario = Entidad.IdUsuario;
                Registro.fecha = Entidad.fecha;
                Registro.tipo_comprobante = Entidad.tipo_comprobante;
                Registro.serie = Entidad.serie;
                Registro.correlativo = Entidad.correlativo;
                Registro.iva = Entidad.iva;
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Anular(venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Venta.Find(Entidad.idventa);
                Registro.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Registro.FechaActualizacion = Entidad.FechaActualizacion;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Existe(venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Venta.Where(a => a.idventa == Entidad.idventa).Count() > 0;
            }
        }
        public static venta Registro(venta Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Venta.Where(a => a.idventa == Entidad.idventa).SingleOrDefault();
            }
        }
        public static List<venta> Lista(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Venta.Where(a => a.idventa > 0).ToList();
            }
        }
    }
}
