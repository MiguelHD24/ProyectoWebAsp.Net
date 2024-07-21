using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }

        [MaxLength(50)]
        [Required]
        public string Rol { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int IdUsuarioRegistra { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public int? IdUsuarioActualiza { get; set; }

        public DateTime? FechaActualizacion { get; set; }

    }
}
