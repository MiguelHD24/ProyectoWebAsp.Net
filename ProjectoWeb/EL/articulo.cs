using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("articulo")]
    public class articulo
    {
        [Key]
        public int idarticulo { get; set; }
        [Required]
        [MaxLength(50)]
        public string codigo { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom_articulo { get; set; }
        [Required]
        [MaxLength(1024)]
        public string descripcion { get; set; }
        [Required]
        public int idcategoria { get; set; }
        [Required]
        public int idpresentacion { get; set; }

        public bool Activo { get; set; }

    }
    public class Varticulo
    {
        [Key]
        public int idarticulo { get; set; }
        public string codigo { get; set; }
        public string nom_articulo { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }
        public string presentacion { get; set; }
    }

}
