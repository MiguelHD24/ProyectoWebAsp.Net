using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;


namespace DAL
{
    public static class DAL_Articulo
    {

        //Metodo Insertar
        public static int InsertArticulo(articulo Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);
            bd.Open();

            SqlCommand cmd = new SqlCommand("spinsertar_articulo", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", Entidad.codigo);
            cmd.Parameters.AddWithValue("@nombre", Entidad.nom_articulo);
            cmd.Parameters.AddWithValue("@descripcion", Entidad.descripcion);
            cmd.Parameters.AddWithValue("@idcategoria", Entidad.idcategoria);
            cmd.Parameters.AddWithValue("@idpresentacion", Entidad.idpresentacion);


            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;

        }

        //Metodo Editar
        public static int EditarArticulo(articulo Entidad)
        {
            SqlConnection bd = new SqlConnection(Conexion.Cn);
            bd.Open();

            SqlCommand cmd = new SqlCommand("speditar_articulo", bd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idarticulo", Entidad.idarticulo);
            cmd.Parameters.AddWithValue("@codigo", Entidad.codigo);
            cmd.Parameters.AddWithValue("@nombre", Entidad.nom_articulo);
            cmd.Parameters.AddWithValue("@descripcion", Entidad.descripcion);
            cmd.Parameters.AddWithValue("@idcategoria", Entidad.idcategoria);
            cmd.Parameters.AddWithValue("@idpresentacion", Entidad.idpresentacion);


            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            bd.Close();
            bd.Dispose();

            return ID;


        }

       

        //Metodo Mostrar

        public static DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spmostrar_articulo", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        //Metodo Buscar por Nombre y codigo

        public static DataTable BuscarCodNombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spbuscar_articulo_cod_nombre", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@TextoBuscar", TextoBuscar);
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        //Metodo Mostrar Stock Articulo

        public static DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection SqlCon = new SqlConnection(Conexion.Cn))
            {
                SqlCommand SqlCmd = new SqlCommand("spstock_articulos", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            return DtResultado;
        }

        //Metodo insertar con Entity Framework
        public static articulo Insert(articulo Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                bd.Articulo.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        //Metodo Editar con Entity Framework
        public static bool UpdateArticulo(articulo Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Articulo.Find(Entidad.idarticulo);
                RegistroBD.codigo = Entidad.codigo;
                RegistroBD.nom_articulo = Entidad.nom_articulo;
                RegistroBD.descripcion = Entidad.descripcion;
                RegistroBD.idcategoria = Entidad.idcategoria;
                RegistroBD.idpresentacion = Entidad.idpresentacion;
                return bd.SaveChanges() > 0;


            }
        }
        //Metodo Insert con Entity Framework (Retorna el ID)
        public static int InsertArticuloEF(articulo Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                bd.Articulo.Add(Entidad);
                bd.SaveChanges();
                return Entidad.idarticulo;
            }
        }
        public static List<Varticulo> ListarArticulosGV()
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = (from tblarticulo in bd.Articulo
                                join tblpresentacion in bd.Presentacion on tblarticulo.idpresentacion equals tblpresentacion.idpresentacion 
                                join tblcategoria in bd.Categoria on tblarticulo.idcategoria equals tblcategoria.idcategoria
                                where tblarticulo.Activo == true
                                 && tblcategoria.Activo == true
                                select new Varticulo
                                {
                                    idarticulo = tblarticulo.idarticulo,
                                    codigo = tblarticulo.codigo,
                                    nom_articulo = tblarticulo.nom_articulo,
                                    descripcion = tblarticulo.descripcion,
                                    categoria = tblcategoria.nom_categoria,
                                    presentacion = tblpresentacion.nom_presentacion
                                }).ToList();
                                
                return Consulta;
            }
        }

        //metodo para listar articulos pero mostrar el campo nombre de sus llaves foraneas
        public static List<articulo> ListarArticulos()
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Articulo.Include("nom_categoria").Include("nom_presentacion").ToList();
            }
        }

        public static List<articulo> List(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Articulo.Where(a => a.Activo == Activo).ToList();
            }
        }

    }
}
