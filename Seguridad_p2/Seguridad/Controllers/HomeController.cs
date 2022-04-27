using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seguridad.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Seguridad.Controllers
{
    //[Authorize] //esto hace que requiera que este autorizado para acceder al Home

    //[Authorize(Policy = "SoloClientes")] //este Claim, se agrega en Program.cs
    //[Authorize(Policy = "Remotos")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            /*var claim = new Claim("Admin", "false"); //agrega "roles" a los usuarios
            if (User.Claims.Any(x => x.Type == "Admin")*/ //con eso verifico si el usuario tiene un rol X


            /*if (User.Identity.IsAuthenticated) //valida si esta logueado
            {
                return View();
            }*/
            _logger.LogError("test");
            ViewBag.Valor1 = "valor1";
            TempData["valor2"] = "valor2";

            return View();
            
        }

        public IActionResult Privacy()
        {
            var valor2 = TempData["valor2"];
            var valor1 = ViewBag.Valor1;
            TempData.Keep("valor2");
            return View();
        }
        public IActionResult Empresa()
        {
            var options = new EmpresaOptions();
            _configuration.GetSection(EmpresaOptions.Seccion).Bind(options);
            return Content($"Empresa {options.RazonSocial} y CUIT {options.Cuit}"); //aca hago referencia de las cfgs  del appsetting con objeto desde _configuration 
        }
        public IActionResult Test4()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Test1()
        {
            return File("/Files/pyton.pdf", "application/pdf");
            //return File("/Files/pyton.pdf", "application/pdf", "Manual.pdf");
        }
        [HttpGet]
        public IActionResult Test3()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Test3(IList<IFormFile> files)
        {
            foreach (var file in files)
            {

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
/*
 TIPOS DE ACTION RESULT
  return Ok();
  return BadRequest();
  return NoContent();
  return Unauthorized();
 */