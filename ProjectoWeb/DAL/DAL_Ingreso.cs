using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Ingreso
    {
        

        //Metodo Insertar
        public static int InsertIngreso(ingreso Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);
            bd.Open();

            SqlCommand cmd = new SqlCommand("spinsertar_ingreso", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idtrabajador", Entidad.IdUsuario);
            cmd.Parameters.AddWithValue("@idproveedor", Entidad.idproveedor);
            cmd.Parameters.AddWithValue("@fecha", Entidad.fecha);
            cmd.Parameters.AddWithValue("@tipo_comprobante", Entidad.tipo_comprobante);
            cmd.Parameters.AddWithValue("@serie", Entidad.serie);
            cmd.Parameters.AddWithValue("@correlativo", Entidad.correlativo);
            cmd.Parameters.AddWithValue("@IVA", Entidad.igv);
            cmd.Parameters.AddWithValue("@estado", Entidad.estado);



            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;

        }



        //Metodo Anular Ingreso

        public static int AnularIngreso(ingreso Entidad)
        {
            using (SqlConnection bd = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand("spanular_ingreso", bd);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idingreso", Entidad.idingreso);

                int ID = Convert.ToInt32((string)cmd.ExecuteScalar());
                return ID;
            }
            
        }

        

        //Metodo Mostrar

        public static DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spmostrar_ingreso", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        //Metodo Buscar Ingreso por fecha

        public static DataTable BuscarIngresoFecha(string TextoBuscar, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("ingreso");
            using (SqlConnection bd = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spbuscar_ingreso_fecha", bd);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);
                SqlCmd.Parameters.AddWithValue("@TextoBuscar2", TextoBuscar2);
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }




    }
}
