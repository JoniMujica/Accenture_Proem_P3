namespace MVC_ABM.Models
{
    public class GestorClientes
    {
        public Clientes clientes { get; set; }
        public ListaClientes Listado { get; set; }
        public GestorClientes()
        {
            clientes = new Clientes();
            Listado = new ListaClientes();
        }
    }
}
