using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto_P1.Models
{
    public enum Metodo
    {
        TarjetaDeCredito,
        Paypal
    }
    public class Pago
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        [Required]
        public double Monto { get; set; }
        [Required]
        public Metodo Metodo { get; set; }
    }
}
