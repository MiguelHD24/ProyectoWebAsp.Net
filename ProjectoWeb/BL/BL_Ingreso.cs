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
    public class BL_Ingreso
    {
        //Metodo Insertar

        public static int InsertIngreso(ingreso Entidad)
        {
            return DAL_Ingreso.InsertIngreso(Entidad);
        }

        //Metodo Anular Ingreso

        public static int AnularIngreso(ingreso Entidad)
        {
            return DAL_Ingreso.AnularIngreso(Entidad);
        }

        

        //Metodo Mostrar

        public static DataTable Mostrar()
        {
            return DAL_Ingreso.Mostrar();
        }

        //Metodo Buscar Ingreso por fecha

        public static DataTable BuscarIngresoFecha(string TextoBuscar, string TextoBuscar2)
        {
            return DAL_Ingreso.BuscarIngresoFecha(TextoBuscar, TextoBuscar2);
        }
    }
}
