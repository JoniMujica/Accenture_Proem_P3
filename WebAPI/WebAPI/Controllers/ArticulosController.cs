using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        //readonly solose puede escribir en elcontructor
        private readonly DataContext dataContext;
        public ArticulosController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Articulo>> Get()
        {
            return await dataContext.Articulos.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Articulo> Get(int id)
        {
            var entity = await dataContext.Articulos.FindAsync(id);
            if (entity ==null)
            {
                return null;
            }
            return entity; 
        }
        [HttpPost]
        public async Task<Articulo> Post(Articulo entity)
        {

            dataContext.Articulos.Add(entity);
            await dataContext.SaveChangesAsync();
            return entity;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, Articulo entity)
        {
            entity.Id = id;
            dataContext.Articulos.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete] 
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await dataContext.Articulos.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            dataContext.Articulos.Remove(entity);
            await dataContext.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
