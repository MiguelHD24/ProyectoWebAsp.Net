using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("presentacion")]
    public class presentacion
    {
        [Key]
        public int idpresentacion { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom_presentacion { get; set; }    
        public string description { get; set; } 
        
        public bool Activo { get; set; }
            


    }
}
