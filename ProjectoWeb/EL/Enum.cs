using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Enum
    {
        public enum eMessage
        {
            Exito = 1,
            Alerta = 2,
            Error = 3,
            Info = 4
        }
        public enum eFormulario
        {
            Formulario_1 = 1,
            Formulario_2 = 2,
            Formulario_3 = 3,
            AdministracionUsuarios = 5,
        }
        public enum eRoles
        {
            Administrador = 1,
            GerenteGeneral = 2,
            OficialVentas = 3,
            Caja = 4,
            JefeAlmacen = 5,
            OficialBodega = 7,
            JefeContabilidad = 8,
            OficialContable = 9,
            Cliente = 10
        }
        public enum ePermisos
        {
            Escritura = 1,
            Anular = 2,
            Bloqueo = 4
        }
    }
}
