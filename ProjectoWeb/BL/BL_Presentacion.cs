using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Presentacion
    {
        //Metodo Insertar
        public static int InsertPresentacion(presentacion Entidad)
        {
            return DAL_Presentacion.InsertPresentacion(Entidad);
        }

        //Metodo Editar
        public static int EditarPresentacion(presentacion Entidad)
        {
            return DAL_Presentacion.EditarPresentacion(Entidad);
        }

        //Metodo Eliminar
        public static int EliminarPresentacion(presentacion Entidad)
        {
            return DAL_Presentacion.EliminarPresentacion(Entidad);

        }
        //Metodo Mostar Presentacion
        public static DataTable Mostrar()
        {
            return DAL_Presentacion.Mostrar();
        }

        //Metodo Buscar Presentacion
        public static DataTable BuscarPresentacion(string TextoBuscar)
        {
            return DAL_Presentacion.BuscarPresentacion(TextoBuscar);
        }
        //Metodo Listar
        public static List<presentacion> Lista(bool Activo = true)
        {
            return DAL_Presentacion.Lista(Activo);
        }
    }
}
