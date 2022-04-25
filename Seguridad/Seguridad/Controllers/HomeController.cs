using Microsoft.AspNetCore.Mvc;
using Seguridad.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Seguridad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*var claim = new Claim("Admin", "false"); //agrega "roles" a los usuarios
            if (User.Claims.Any(x => x.Type == "Admin")*/ //con eso verifico si el usuario tiene un rol X
            

            /*if (User.Identity.IsAuthenticated) //valida si esta logueado
            {
                return View();
            }*/

            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}