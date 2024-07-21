using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_Presentacion
    {
        //Metodo Insertar
        public static int InsertPresentacion(presentacion Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.Cn))
            {
                SqlCommand cmd = new SqlCommand("spinsertar_presentacion", bd);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", Entidad.nom_presentacion);
                cmd.Parameters.AddWithValue("@description", Entidad.description);

                int ID = Convert.ToInt32(cmd.ExecuteScalar());

                return ID;

            }
            
        }

        //Metodo Editar

        public static int EditarPresentacion(presentacion Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);
            bd.Open();

            SqlCommand cmd = new SqlCommand("speditar_presentacion", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idpresentacion", Entidad.idpresentacion);
            cmd.Parameters.AddWithValue("@nombre", Entidad.nom_presentacion);
            cmd.Parameters.AddWithValue("@description", Entidad.description);

            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;

        }

        //Metodo Eliminar

        public static int EliminarPresentacion (presentacion Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);
            bd.Open() ;

            SqlCommand cmd = new SqlCommand("speliminar_presentacion", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpresentacion", Entidad.idpresentacion);

            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close() ;
            bd.Dispose();

            return ID;

        }
        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("presentacion");
            using (SqlConnection bd = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spmostrar_presentacion", bd);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        public static List<presentacion> Lista(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Presentacion.Where(a => a.Activo == Activo).ToList();
            }
        }

        // Metodo Buscar

        public static DataTable BuscarPresentacion(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("presentacion");
            using (SqlConnection bd = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spbuscar_presentacion", bd);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }
    }
}
