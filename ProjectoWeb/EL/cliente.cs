using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("cliente")]
    public class cliente
    {
        [Key]
        public int idcliente { get; set; }
        [Required]
        [MaxLength(50)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(40)] 
        public string apellidos { get; set;}
        public DateTime fecha_nacimiento { get; set; }
        [Required]
        [MaxLength(18)]
        public string num_identidad { get; set; }
        public string direccion { get; set; }
        [Required]
        [MaxLength(12)]
        public string telefono { get; set;}
        [Required]
        [MaxLength(50)]
        public string correo { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
