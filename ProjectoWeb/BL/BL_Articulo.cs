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
    public class BL_Articulo
    {
        //Metodo Insertar
        public static int InsertArticulo(articulo Entidad) 
        { 
            return DAL_Articulo.InsertArticulo(Entidad);    
        }

        //Metodo Editar
        public static int EditarArticulo(articulo Entidad)
        {
            return DAL_Articulo.EditarArticulo(Entidad);
        }

        public static int InsertArticuloEF(articulo Entidad)
        {  
            return DAL_Articulo.InsertArticuloEF(Entidad);
        }
        //Metodo Mostar Articulo
        public static DataTable Mostrar()
        {
            return DAL_Articulo.Mostrar();
        }

        //Metodo Buscar por Nombre y Codigo
        public static DataTable BuscarCodNombre(string TextoBuscar)
        {
            return DAL_Articulo.BuscarCodNombre(TextoBuscar);
        }

        //Metodo Mostrar Stock de Articulo
        public static DataTable MostrarStockArticulos()
        {
            return DAL_Articulo.Stock_Articulos();
        }

        public static List<articulo> List(bool Activo = true)
        {
            return DAL_Articulo.List(Activo);
        }

        public static bool UpdateArticulo(articulo Entidad)
        {
            return DAL_Articulo.UpdateArticulo(Entidad);
        }
        public static articulo Insert(articulo Entidad)
        {
            return DAL_Articulo.Insert(Entidad);
        }
        public static List<articulo> ListarArticulos()
        {
            return DAL_Articulo.ListarArticulos();
        }
        public static List<Varticulo> ListarArticulosGV()
        {
            return DAL_Articulo.ListarArticulosGV();
        }
    }
}