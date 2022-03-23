using Microsoft.AspNetCore.Mvc;
using MVC_StarWars.Models;
using System;

namespace MVC_StarWars.Controllers
{
    public class PersonajesController : Controller
    {
        public StarwarsDb context { get; set; }
        public PersonajesController(StarwarsDb context)
        {
            this.context = context;
        }

        public IActionResult Listado(string nombre)
        {
            var model = new PersonajesListadoModel();
            model.Listado = context.Personajes.ToList();
            return View(model); //ESTO SE LO PASAMOS COMO PARAMETRO A  LA VISTA
        }
        public IActionResult Index(string id,string nombre) //al agregarle parametros, hacemos referencia al get del input, y se pasar como parametros de URL
        {
            //var db = new StarwarsDb();
            //var personajes = db.Personajes.ToList();
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id,out Id))
                {
                    context.Personajes.Add(new Personaje { Id = Id, Nombre = nombre }).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    context.SaveChanges();
                }
            }

            return View();
        }

        
    }
}
