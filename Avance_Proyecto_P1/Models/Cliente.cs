using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto_P1.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [MinLength(1), MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(0 , 9999999999)]
        public int Telefono { get; set; }
        [Required]
        [MinLength(1), MaxLength(150)]
        public string Direccion { get; set; }
    }
}
