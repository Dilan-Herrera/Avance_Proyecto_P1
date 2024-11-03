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
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public double Monto { get; set; }
        public Metodo Metodo { get; set; }
    }
}
