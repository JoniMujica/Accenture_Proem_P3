using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_StarWars.Models;

namespace MVC_StarWars.Controllers
{
    public class MisionController : Controller
    {
        public StarwarsDb context { get; set; }
        public MisionController(StarwarsDb context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Lista = context.Misiones.Include(x=> x.Personaje).ToList(); //con esto me va a traer todas las misiones con sus personajes (por esoel include)
            return View();
        }
        public IActionResult Editar(string id)
        {
            return View();
        }
    }
}
