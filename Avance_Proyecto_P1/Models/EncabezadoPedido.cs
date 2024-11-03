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
        public DateTime FechaPedido { get; set; } = DateTime.Now;
        public Estados Estado { get; set; }
    }
}
