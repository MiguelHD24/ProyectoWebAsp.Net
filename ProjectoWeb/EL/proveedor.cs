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
    [Table("proveedor")]
    public class proveedor
    {
        [Key]
        public int idproveedor { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string sector_comercial { get;set; }
        [Required]
        [MaxLength(20)]
        public string tipo_documento { get; set; }
        [Required]
        [MaxLength(11)]
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool activo { get; set; }
    }
}


