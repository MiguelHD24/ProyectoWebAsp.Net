using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EL;
using System.Data.Entity.Migrations.Design;

namespace DAL
{
    public class BDContexto :DbContext
    {
        public BDContexto():base(Conexion.Cn) 
        { 

        } 

        public virtual DbSet<articulo> Articulo { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Formularios> Formularios { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<RolFormularios> RolFormularios { get; set; }
        public virtual DbSet<RolPermisos> RolPermisos { get; set; }
        public virtual DbSet<categoria> Categoria { get; set; }
        public virtual DbSet<cliente> Cliente { get; set; }
        public virtual DbSet<detalle_ingreso> Detalle_ingreso { get; set; }
        public virtual DbSet<detalle_venta> Detalle_venta { get; set; }
        public virtual DbSet<ingreso> Ingreso { get; set; }
        public virtual DbSet<presentacion> Presentacion { get; set; }
        public virtual DbSet<proveedor> Proveedor { get; set;}
        public virtual DbSet<venta> Venta { get; set; }
        

    }
}
