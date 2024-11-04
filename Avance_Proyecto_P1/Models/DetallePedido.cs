using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_Proyecto_P1.Models
{
    public class DetallePedido
    {
        [Key]
        public int Id { get; set; }
        public EncabezadoPedido? EncabezadoPedido { get; set; }
        [ForeignKey(nameof(EncabezadoPedido))]
        [Required]
        public int IdEncabezado { get; set; }
        public Pieza? Pieza { get; set; }
        [ForeignKey(nameof(Pieza))]
        [Required]
        public int IdPieza { get; set; }
        [Range(1, 100)]
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int Total { get; set; }
    }
}
