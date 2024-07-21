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
    public class BL_Categoria
    {
        //Metodo Insertar
        public static int InsertCategoria(categoria Entidad)
        {
            return DAL_Categoria.InsertCategoria(Entidad);
        }

        //Metodo Editar
        public static int EditarCategoria(categoria Entidad)
        {
            return DAL_Categoria.EditarCategoria(Entidad);
        }

        //Metodo Eliminar
        public static int EliminarCategoria(categoria Entidad)
        {
            return DAL_Categoria.EliminarCategoria(Entidad);

        }
        //Metodo Mostar Categoria
        public static DataTable Mostrar()
        {
            return DAL_Categoria.Mostrar();
        }

        //Metodo Buscar Categoria
        public static DataTable BuscarCategoria(string TextoBuscar)
        {
            return DAL_Categoria.BuscarCategoria(TextoBuscar);
        }

        public static List<categoria> Lista(bool Activo = true)
        {
            return DAL_Categoria.Lista(Activo);
        }
    }
}
