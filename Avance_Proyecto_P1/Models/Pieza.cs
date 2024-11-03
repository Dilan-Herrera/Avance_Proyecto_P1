using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto_P1.Models
{
    public class Pieza
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CantidadDisponible { get; set; }
        public double PrecioUnitario { get; set; }
    }
}
