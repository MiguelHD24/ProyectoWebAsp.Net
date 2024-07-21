using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    [Table("categoria")]
    public class categoria
    {
        [Key]
        public int idcategoria { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom_categoria { get; set; }

        public string descripcion { get; set; }

        public bool Activo { get; set; }
        


    }


}

