using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("detalle_ingreso")]
    public class detalle_ingreso
    {
        [Key] 
        public int iddetalle_ingreso { get; set; }
        [Required] 
        public int idingreso { get; set; }
        [Required]
        public int idarticulo { get; set; }
        [Required]
        public decimal precio_compra { get; set; }
        [Required]
        public decimal precio_venta { get; set; }
        [Required]
        public int stock_inicial { get; set; }
        [Required]
        public int stock_actual { get; set; }
        [Required]
        public DateTime fecha_produccion { get; set; }
        [Required]
        public decimal fecha_vencimiento { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    
    }
}
