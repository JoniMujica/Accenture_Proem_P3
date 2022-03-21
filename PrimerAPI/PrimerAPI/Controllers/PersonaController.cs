using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerAPI.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly MyContext context;
        public PersonaController(MyContext context)
        {
            this.context = context;
        }

        //Gets

        [HttpGet] //esto es importante agregar, es el tipo de solicitud
        async public Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            try
            {
                return await context.Personas.ToListAsync();
            }
            catch (System.Exception)
            {

                return NoContent();
            }

        }

        [HttpGet("{id:int}")] //esto ademas de ser un get de persona, al indicar esos atributos, va a estar esperando un ID
        async public Task<ActionResult<Persona>> GetPersona(int id)
        {
            try
            {
                return await context.Personas.Where(p => p.Id == id).FirstAsync(); //ESTO RETORNA UNA UNICA PERSONA
            }
            catch (System.Exception)
            {

                return NoContent();
            }

        }
        //agregar
        [HttpPost("alta")] //esto ademas de ser un get de persona, al indicar esos atributos, va a estar esperando un ID
        public ActionResult<Persona> AltaPersona(Persona persona)
        {
            if (persona == null)
            {
                return BadRequest();
            }
            else
            {
                context.Personas.Add(persona).State = EntityState.Added;
                context.SaveChanges();
                return persona;
            }
        }
        //modificar
        [HttpPut("modificar/{id:int}")]
        public ActionResult<Persona> ModificacionPersona(int id,Persona persona)
        {
            if (persona == null && id < 1)
            {
                return BadRequest();
            }
            else
            {
                Persona p = context.Personas.Where((p) => p.Id == id).First();
                p.Nombre = persona.Nombre;
                p.Apellido = persona.Apellido;
                p.Sexo = persona.Sexo;
                context.Personas.Update(p).State = EntityState.Modified;
                context.SaveChanges();
                return persona;
            }
        }
        //eliminar
        [HttpDelete("{id:int}")]
        public IActionResult EliminarPersona(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            else
            {
                Persona p = context.Personas.Where((p) => p.Id == id).First();

                context.Personas.Remove(p).State = EntityState.Deleted;
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
