using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avance_Proyecto_P1.Models
{
    public class EncabezadoPedido
    {
        [Key]
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPedido { get; set; } 
        [Required]
        public Estados Estado { get; set; }
    }
    public enum Estados
    {
        Pendiente,
        Completado,
        EnProceso,
    }
}
