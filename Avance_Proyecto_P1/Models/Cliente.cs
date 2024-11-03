using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto_P1.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
