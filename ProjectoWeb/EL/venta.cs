using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("venta")]
    public class venta
    {
        [Key]
        public int idventa { get; set; }
        [Required] 
        public int idcliente { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public DateTime fecha { get; set;}
        [Required]
        [MaxLength(20)]
        public string tipo_comprobante { get; set; }
        [Required]
        [MaxLength(4)]
        public string serie { get; set; }
        [Required]
        [MaxLength(7)]
        public string correlativo { get;set; }
        [Required]
        public decimal iva { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }

    }
}








