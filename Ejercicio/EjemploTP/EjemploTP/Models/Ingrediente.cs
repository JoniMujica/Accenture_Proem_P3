namespace EjemploTP.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public int TragoId { get; set; }
        public Trago Trago { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
