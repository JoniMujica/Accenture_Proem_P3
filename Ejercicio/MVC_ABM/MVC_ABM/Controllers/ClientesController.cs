using Microsoft.AspNetCore.Mvc;
using MVC_ABM.Models;

namespace MVC_ABM.Controllers
{
    public class ClientesController : Controller
    {
        public MyDBContext context { get; set; }
        public ClientesController( MyDBContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult Crear(GestorClientes cliente)
        {
            if (cliente.clientes == null)
            {
                return BadRequest();
            }
            else
            {
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
                Clientes c = context.Clientes.Where(p => p.Id == Id).First();
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
