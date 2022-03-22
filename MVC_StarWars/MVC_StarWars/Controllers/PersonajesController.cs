using Microsoft.AspNetCore.Mvc;

namespace MVC_StarWars.Controllers
{
    public class PersonajesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
