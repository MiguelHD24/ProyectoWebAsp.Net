using EL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_Proveedor
    {
        //Metodo insertar
        public static proveedor Insert(proveedor Entidad) 
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.activo = true;
                bd.Proveedor.Add(Entidad);
                bd.SaveChanges();
                return Entidad;

            }
        }
        //Metodo Update
        public static bool Update(proveedor Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Proveedor.Find(Entidad.idproveedor);
                RegistroBD.idproveedor = Entidad.idproveedor;
                RegistroBD.nombre = Entidad.nombre;
                RegistroBD.sector_comercial = Entidad.sector_comercial;
                RegistroBD.tipo_documento = Entidad.tipo_documento;
                RegistroBD.num_documento = Entidad.num_documento;
                RegistroBD.direccion = Entidad.direccion;
                RegistroBD.telefono = Entidad.telefono;
                RegistroBD.email = Entidad.email;
                RegistroBD.url = Entidad.url;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        //Metodo eliminar
        public static bool Eliminar(proveedor Entidad)
        {
            using (BDContexto bd = new BDContexto()) 
            {
                var RegistroBD = bd.Proveedor.Find(Entidad.idproveedor);
                RegistroBD.activo = false;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;

            }
        }

        public static List<proveedor> List(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Proveedor.Where(a => a.activo == Activo).ToList();
            }
        }
        public static List<proveedor> Buscar(string Palabra)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = bd.Proveedor.Where(a => a.nombre.Contains(Palabra)).ToList();
                return Consulta;
            }
        }
    }
}
