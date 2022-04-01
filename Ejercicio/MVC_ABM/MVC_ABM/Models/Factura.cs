namespace MVC_ABM.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Comprobantes { get; set; }
        public decimal Importe { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
    }
}
