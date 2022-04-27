using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        [HttpGet]
        public Articulo Get()
        {
            return new Articulo();
        }
        [HttpPost]
        public Articulo Post()
        {
            return new Articulo { Id = 1 };
        }
    }
}
