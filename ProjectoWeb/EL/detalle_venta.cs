using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("detalle_venta")]
    public class detalle_venta
    {
        [Key]
        public int iddetalle_venta { get; set; }
        [Required]
        public int idventa { get; set; }
        [Required]
        public int iddetalle_ingreso { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public decimal precio_venta { get; set; }
        [Required]
        public decimal descuento { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }


    }
}
