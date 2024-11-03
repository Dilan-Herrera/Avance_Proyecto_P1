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
        public int IdEncabezado { get; set; }
        public Pieza? Pieza { get; set; }
        [ForeignKey(nameof(Pieza))]
        public int IdPieza { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}
