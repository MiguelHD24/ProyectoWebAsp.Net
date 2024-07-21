using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using EL;
using Utilidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //byte[] Key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");
            //byte[] IV = Encoding.UTF8.GetBytes("Pr0y3ct03J3mpl00");//16 Caracteres

            //Usuarios user = new Usuarios();
            //user.IdUsuario = 3;
            //user.IdUsuarioActualiza = 3;
            //user.Password = Utilidades.Encripty.Encrypt("123", Key, IV);
            //BL_Usuarios.PasswordUpdate(user);


            //Permisos Permiso = new Permisos();
            //Permiso.IdPermiso = 3;
            //Permiso.Permiso = "Actualizar";
            //Permiso.IdUsuarioActualiza = 3;

            //Console.WriteLine(BL_Permisos.Update(Permiso));
            //cliente cliente = new cliente();
            //cliente.nombre = "Cliente";
            //cliente.apellidos = "General";
            //cliente.fecha_nacimiento = DateTime.Now;
            //cliente.num_identidad = "0010811940023C";
            //cliente.direccion = "No Aplica";
            //cliente.telefono = "87909041";
            //cliente.correo = "General@gmail.com";
            //BL_Cliente.Insert(cliente);

            categoria categoria = new categoria();
            Console.WriteLine(BL_Categoria.Mostrar());

        }

    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EL;
//using BL;


//namespace Test
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            Roles roles = new Roles();

//            roles.Rol = "Caja";
//            roles.IdUsuarioRegistra = 1;
//            Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);

//            //roles.Rol = "Jefe de Almacen";
//            //roles.IdUsuarioRegistra = 1;
//            //Console.WriteLine(BL_Roles.InsertarRoles(roles).IdRol);

//            //roles.Rol = "Oficial de Bodega";
//            //roles.IdUsuarioRegistra = 1;
//            //Console.WriteLine(BL_Roles.InsertarRoles(roles).IdRol);

//            //roles.Rol = "Jefe de Contabilidad";
//            //roles.IdUsuarioRegistra = 1;
//            //Console.WriteLine(BL_Roles.InsertarRoles(roles).IdRol);

//            //roles.Rol = "Oficial Contable";
//            //roles.IdUsuarioRegistra = 1;
//            //Console.WriteLine(BL_Roles.InsertarRoles(roles).IdRol);

//            //foreach (var item in BL_Roles.Buscar_("ca"))
//            //{
//            //    Console.WriteLine(item.IdRol + "\t" + item.Rol + "\n");
//            //}

//            //roles = BL_Roles.Registro___(5);
//            //Console.WriteLine(roles.IdRol + "\t" + roles.Rol + "\n");

//            //Permisos Permiso = new Permisos();
//            //Permiso.IdPermiso = 3;
//            //Permiso.Permiso = "Actualizar";
//            //Permiso.IdUsuarioActualiza = 1;

//            //Console.WriteLine(BL_Permisos.Update(Permiso));





//            //Console.ReadLine();

//        }
//    }
//}
