using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Cliente
    {
        public static cliente Insert(cliente Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.activo = true;               
                bd.Cliente.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(cliente Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Cliente.Find(Entidad.idcliente);
                RegistroBD.nombre = Entidad.nombre;
                RegistroBD.apellidos = Entidad.apellidos;
                RegistroBD.fecha_nacimiento = Entidad.fecha_nacimiento;
                RegistroBD.num_identidad = Entidad.num_identidad;
                RegistroBD.direccion = Entidad.direccion;
                RegistroBD.telefono = Entidad.telefono;
                RegistroBD.correo = Entidad.correo;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Delete(cliente Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Cliente.Find(Entidad.idcliente);
                RegistroBD.activo = false;
                return bd.SaveChanges() > 0;
            }
        }
        public static List<cliente> List(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Cliente.Where(a => a.activo == Activo).ToList();
            }
        }
        public static cliente Registro(int idcliente)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Cliente.Find(idcliente);
            }
        }
        public static List<cliente> Buscar(string Palabra)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = bd.Cliente.Where(a => a.nombre.Contains(Palabra)).ToList();
                return Consulta;
            }
        }
    }
}
