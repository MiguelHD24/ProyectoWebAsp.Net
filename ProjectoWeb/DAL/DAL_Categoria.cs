using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Categoria
    {
        //Metodo Insertar
        public static int InsertCategoria(categoria Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);
            bd.Open();

            SqlCommand cmd = new SqlCommand("spinsertar_categoria", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", Entidad.nom_categoria);
            cmd.Parameters.AddWithValue("@Descripcion", Entidad.descripcion);

            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;
        }

        //Metodo Editar
        public static int EditarCategoria(categoria Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);  
            bd.Open() ;

            SqlCommand cmd = new SqlCommand("speditar_categoria", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Idcategoria", Entidad.idcategoria);
            cmd.Parameters.AddWithValue("@Nombre", Entidad.nom_categoria);
            cmd.Parameters.AddWithValue("@Descripcion", Entidad.descripcion);

            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;

        }

        //Metodo Eliminar
        public static int EliminarCategoria(categoria Entidad)
        {
            SqlConnection bd = new SqlConnection();
            bd.Open();

            SqlCommand cmd = new SqlCommand("speliminar_categoria", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Idcategoria", Entidad.idcategoria);

            int ID = Convert.ToInt32((string)cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;

        }

        //Metodo Mostrar

        public static DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spmostrar_categoria", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        public static DataTable BuscarCategoria(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("categoria");
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spbuscar_categoria", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        public static List<categoria> Lista(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Categoria.Where(a => a.Activo == Activo).ToList();
            }
        }
    }
}
