using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class BL_Usuarios
    {
        public static Usuarios Insert(Usuarios Entidad)
        {
            return DAL_Usuarios.Insert(Entidad);
        }

        public static bool Update(Usuarios Entidad, bool UpdatePassword)
        {
            return DAL_Usuarios.Update(Entidad, UpdatePassword);
        }
        public static bool PasswordUpdate(Usuarios Entidad)
        {
            return DAL_Usuarios.PasswordUpdate(Entidad);
        }
        public static bool Delete(Usuarios Entidad)
        {
            return DAL_Usuarios.Delete(Entidad);
        }
        public static List<Usuarios> List(bool Activo = true)
        {
            return DAL_Usuarios.List(Activo);
        }
        public static List<vUsuarios> vUsuarios(bool Activo = true)
        {
            return DAL_Usuarios.vUsuarios(Activo);
        }
        public static vUsuarios vUsuario(int IdRegistro)
        {
            return DAL_Usuarios.vUsuario(IdRegistro);
        }
        public static Usuarios Registro(int IdRegistro)
        {
            return DAL_Usuarios.Registro(IdRegistro);
        }
        public static List<Usuarios> Buscar(string Palabra)
        {
            return DAL_Usuarios.Buscar(Palabra);
        }
        public static Usuarios ExisteCorreo(string Email)
        {
            return DAL_Usuarios.ExisteCorreo(Email);
        }
        public static bool SumarIntentosFallido(int IdRegistro)
        {
            return DAL_Usuarios.SumarIntentosFallido(IdRegistro);
        }
        public static bool RestablecerIntentosFallido(int IdRegistro, int IdUsuarioActualiza)
        {
            return DAL_Usuarios.RestablecerIntentosFallido(IdRegistro, IdUsuarioActualiza);
        }
        public static bool BloquearCuentaUsuario(int IdRegistro, bool Bloquear, int IdUsuarioActualiza)
        {
            return DAL_Usuarios.BloquearCuentaUsuario(IdRegistro, Bloquear, IdUsuarioActualiza);
        }
        public static bool ExisteUserName(string UserName)
        {
            return DAL_Usuarios.ExisteUserName(UserName);
        }
        public static bool ExisteUserNameUpdate(string UserName, int IdRegistro)
        {
            return DAL_Usuarios.ExisteUserNameUpdate(UserName, IdRegistro);
        }
        public static Usuarios ExisteUsuario_x_UserName(string UserName)
        {
            return DAL_Usuarios.ExisteUsuario_x_UserName(UserName);
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        {
            return DAL_Usuarios.ValidarCredenciales(UserName, Password);
        }
        public static byte[] Encrypt(string FlatString)
        {
            return DAL_Usuarios.Encrypt(FlatString);
        }
        public static bool VerificarCuentaBloqueada(string UserName)
        {
            return DAL_Usuarios.VerificarCuentaBloqueada(UserName);
        }
        public static short CatidadIntentosFallidos(string UserName)
        {
            return DAL_Usuarios.CatidadIntentosFallidos(UserName);
        }

    }
}
