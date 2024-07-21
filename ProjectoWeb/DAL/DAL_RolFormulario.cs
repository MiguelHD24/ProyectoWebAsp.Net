using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_RolFormulario
    {
        public static RolFormularios Insert(RolFormularios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.RolFormularios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(RolFormularios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.RolFormularios.Find(Entidad.IdRolFormulario);
                RegistroBD.IdRol = Entidad.IdRol;
                RegistroBD.IdFormulario = Entidad.IdFormulario;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Delete(RolFormularios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.RolFormularios.Find(Entidad.IdRolFormulario);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static List<RolFormularios> List(int IdRol, bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.RolFormularios.Where(a => a.IdRol == IdRol && a.Activo == Activo).ToList();
            }
        }
        public static RolFormularios Registro(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.RolFormularios.Find(IdRegistro);
            }
        }

    }
}
