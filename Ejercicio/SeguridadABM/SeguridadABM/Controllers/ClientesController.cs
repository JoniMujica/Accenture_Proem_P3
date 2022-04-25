using Microsoft.AspNetCore.Mvc;
using SeguridadABM.Data;
using SeguridadABM.Models;

namespace SeguridadABM.Controllers
{
    public class ClientesController : Controller
    {
        public ApplicationDbContext context { get; set; }
        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Crear(GestorClientes cliente)
        {
            if (cliente.clientes == null)
            {
                return BadRequest();
            }
            else
            {

                cliente.clientes.Autor.Nombre = User.Identity.Name;
                cliente.clientes.Autor.fecha = DateTime.Now;
                cliente.clientes.Autor.ModNombre = User.Identity.Name;
                //context.Clientes.Add(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.Clientes.Add(cliente.clientes).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult Editar(GestorClientes cliente)
        {
            context.Attach(cliente.clientes);
            context.Entry(cliente.clientes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(string id)
        {
            int Id = 0;
            if (!Int32.TryParse(id, out Id) || Id < 0)
            {
                return NotFound();
            }
            else
            {
                Cliente c = context.Clientes.Where(p => p.Id == Id).First();
                context.Clientes.Remove(c).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                return RedirectToAction("index");
            }
        }
        public IActionResult Index()
        {
            GestorClientes cli = new GestorClientes();
            cli.Listado.ListadoClientes = context.Clientes.ToList();
            //lista.ListadoClientes = context.Clientes.ToList();

            return View(cli);
        }
    }
}
