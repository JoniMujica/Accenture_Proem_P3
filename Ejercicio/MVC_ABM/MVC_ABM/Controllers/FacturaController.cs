using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ABM.Models;

namespace MVC_ABM.Controllers
{
    public class FacturaController : Controller
    {
        public readonly MyDBContext context;
        public FacturaController(MyDBContext context)
        {
            this.context = context;
        }
        public IActionResult Index(GestorClientes cli)

        {
            cli.Listado.ListadoClientes = context.Clientes.ToList();

            List<KeyValuePair<int, string>> tipos = new();

            foreach (Clientes cliente in cli.Listado.ListadoClientes)
            {
                string item = string.Format("{0} {1}", cliente.Id, cliente.Nombre);
                tipos.Add(new KeyValuePair<int, string>(cliente.Id, item));
            }
            SelectList items = new(tipos, "Key", "Value"); //esto hace que se agregue select en items ViewbAG
            ViewBag.Tipos = items;
            if (cli.clientes.Id != 0)
            {
                ViewBag.Lista = context.Facturas.Include(x => x.Cliente.Id == cli.clientes.Id).ToList();
            }
            ViewBag.Lista = null;
            return View();
        }
    }
}
