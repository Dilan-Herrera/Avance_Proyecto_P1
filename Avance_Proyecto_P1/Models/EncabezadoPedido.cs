using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_Proyecto_P1.Models
{
    public enum Estados
    {
        Pendiente,
        Completado,
        EnProceso,
    }
    public class EncabezadoPedido
    {
        [Key]
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey(nameof(Cliente))]
        public int IdCliente { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPedido { get; set; } = DateTime.Now;
        [Required]
        public Estados Estado { get; set; }
    }
}
