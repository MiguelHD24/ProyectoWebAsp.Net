using EL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace DAL
{
    public class DAL_Usuarios
    {
        private static byte[] Key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");//24 Caracteres
        private static byte[] IV = Encoding.UTF8.GetBytes("Pr0y3ct03J3mpl00");//16 Caracteres
        public static Usuarios Insert(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Usuarios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(Usuarios Entidad, bool UpdatePassword)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Usuarios.Find(Entidad.IdUsuario);
                RegistroBD.NombreCompleto = Entidad.NombreCompleto;
                RegistroBD.Correo = Entidad.Correo;
                RegistroBD.UserName = Entidad.UserName;
                if (UpdatePassword)
                {
                    RegistroBD.Password = Entidad.Password;
                }
                RegistroBD.IdRol = Entidad.IdRol;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool PasswordUpdate(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = bd.Usuarios.Find(Entidad.IdUsuario);
                Consulta.Password = Entidad.Password;
                Consulta.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Consulta.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Delete(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Usuarios.Find(Entidad.IdUsuario);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static List<Usuarios> List(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.Activo == Activo).ToList();
            }
        }
        public static List<vUsuarios> vUsuarios(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {   
                var Consulta = (from tblUsuarios in bd.Usuarios
                                join tblRoles in bd.Roles on tblUsuarios.IdRol equals tblRoles.IdRol
                                where tblUsuarios.Activo == Activo && tblRoles.Activo == Activo
                                select new vUsuarios
                                {
                                    IdUsuario = tblUsuarios.IdUsuario,
                                    NombreCompleto = tblUsuarios.NombreCompleto,
                                    Correo = tblUsuarios.Correo,
                                    UserName = tblUsuarios.UserName,
                                    Bloqueado = tblUsuarios.Bloqueado,
                                    CuentaBloqueada = (tblUsuarios.Bloqueado) ? "SI" : "NO",
                                    IntentosFallidos = tblUsuarios.IntentosFallidos,
                                    IdRol = tblUsuarios.IdRol,
                                    Rol = tblRoles.Rol
                                }).ToList();
                return Consulta;
            }
        }
        public static vUsuarios vUsuario(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = (from tblUsuarios in bd.Usuarios
                                join tblRoles in bd.Roles on tblUsuarios.IdRol equals tblRoles.IdRol
                                where tblUsuarios.Activo == true && tblRoles.Activo == true && tblUsuarios.IdUsuario == IdRegistro
                                select new vUsuarios
                                {
                                    IdUsuario = tblUsuarios.IdUsuario,
                                    NombreCompleto = tblUsuarios.NombreCompleto,
                                    Correo = tblUsuarios.Correo,
                                    UserName = tblUsuarios.UserName,
                                    Bloqueado = tblUsuarios.Bloqueado,
                                    CuentaBloqueada = (tblUsuarios.Bloqueado) ? "SI" : "NO",
                                    IntentosFallidos = tblUsuarios.IntentosFallidos,
                                    IdRol = tblUsuarios.IdRol,
                                    Rol = tblRoles.Rol
                                }).SingleOrDefault();
                return Consulta;
            }
        }
        public static Usuarios Registro(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Find(IdRegistro);
            }
        }
        public static List<Usuarios> Buscar(string Palabra)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.
                      Where(a => a.NombreCompleto.Contains(Palabra)
                              || a.Correo.Contains(Palabra)
                              || a.UserName.Contains(Palabra)
                      ).ToList();
            }
        }
        public static Usuarios ExisteCorreo(string Email)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.Correo.ToLower() == Email.ToLower()).SingleOrDefault();
            }
        }
        public static bool SumarIntentosFallido(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.IntentosFallidos = Convert.ToInt16(Registro.IntentosFallidos + 1);
                return bd.SaveChanges() > 0;
            }
        }
        public static bool RestablecerIntentosFallido(int IdRegistro, int IdUsuarioActualiza)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.IntentosFallidos = 0;
                Registro.IdUsuarioActualiza = IdUsuarioActualiza;
                Registro.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool BloquearCuentaUsuario(int IdRegistro, bool Bloquear, int IdUsuarioActualiza)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.Bloqueado = Bloquear;
                if (!Bloquear) { Registro.IntentosFallidos = 0; }
                Registro.IdUsuarioActualiza = IdUsuarioActualiza;
                Registro.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool ExisteUserName(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).Count() > 0;
            }
        }
        public static bool ExisteUserNameUpdate(string UserName, int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower() && a.IdUsuario != IdRegistro).Count() > 0;
            }
        }
        public static Usuarios ExisteUsuario_x_UserName(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).SingleOrDefault();
            }
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower() && a.Password == Password).Count() > 0;
            }
        }
        public static byte[] Encrypt(string FlatString)
        {
            return Encripty.Encrypt(FlatString, Key, IV);
        }
        public static bool VerificarCuentaBloqueada(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.
                    Where(a => a.UserName.ToLower() == UserName.ToLower()
                    && a.Bloqueado).Count() > 0;
            }
        }
        public static short CatidadIntentosFallidos(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).SingleOrDefault().IntentosFallidos;
            }
        }

    }
}
