using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto_P1.Models
{
    public class Pieza
    {
        [Key]
        public int Id { get; set; }
        [MinLength(1), MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [Range(1, 100)]
        public int CantidadDisponible { get; set; }
        [Range(1, 300)]
        [Required]
        public double PrecioUnitario { get; set; }
    }
}
