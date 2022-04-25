namespace SeguridadABM.Models
{
    public class GestorClientes
    {
        public Cliente clientes { get; set; }
        public ListaClientes Listado { get; set; }
        public GestorClientes()
        {
            clientes = new Cliente();
            Listado = new ListaClientes();
        }
    }
}
