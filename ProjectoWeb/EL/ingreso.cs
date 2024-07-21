using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    [Table("ingreso")]
    public class ingreso
    {
        [Key]
        public int idingreso { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int idproveedor { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        [MaxLength(20)]
        public string tipo_comprobante { get; set; }
        [Required]
        [MaxLength(4)]
        public string serie { get; set; }
        [Required]
        [MaxLength(7)]
        public string correlativo { get; set; }
        [Required]
        public double igv { get; set; }
        [Required]
        [MaxLength(7)]
        public string estado { get; set; }
        public int? IdUsuarioActualiza { get; set; }
        public DateTime? FechaActualizacion { get; set; }


    }
}
