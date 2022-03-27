using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        
        /*public IActionResult Listado()
        {
            var model = new PersonajesListadoModel();
            model.Listado = context.Personajes.ToList();
            return View(model); //ESTO SE LO PASAMOS COMO PARAMETRO A  LA VISTA
        }*/
        public IActionResult Listado(string valor)
        {
            var model = new PersonajesListadoModel();
            var query = context.Personajes.AsQueryable();
            if (!string.IsNullOrEmpty(valor))
            {
                query = query.Where(x => x.Nombre.Contains(valor)); //aca buscamos en la lista el nombre
            }
            //model.Listado = context.Personajes.ToList();
            model.Listado = query.ToList();
            return View(model); //ESTO SE LO PASAMOS COMO PARAMETRO A  LA VISTA
        }
        public IActionResult Eliminar(string id)
        {
            int Id = 0;
            int.TryParse(id, out Id);
            if (Id < 1)
            {
                return BadRequest();
            }
            else
            {
                Personaje p = context.Personajes.Where((p) => p.Id == Id).First();

                context.Personajes.Remove(p).State = EntityState.Deleted;
                context.SaveChanges();
                return RedirectToAction("Listado");
            }
        }

        [HttpPost]
        public IActionResult Editar(Personaje modelo)
        {
            //var model = context.Personajes.Find(modelo.Id);
            if (modelo.Id == 0)
            {
                context.Personajes.Add(modelo);
            }
            else
            {
                context.Attach(modelo);
                context.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
            //return View(modelo);
            return RedirectToAction("Listado");
        }
        public IActionResult Editar(string id)
        {
            Personaje model;
            int Id = 0;
            int.TryParse(id, out Id);
            if (Id == 0)
            {
                model = new();
            }
            else
            {
                model = context.Personajes.Find(Id);
            }
            List<KeyValuePair<int,string>> tipos = new();
            tipos.Add(new KeyValuePair<int, string>(1, "jedy"));
            tipos.Add(new KeyValuePair<int, string>(2, "Sith"));
            SelectList items = new(tipos, "Key", "Value"); //esto hace que se agregue select en items ViewbAG
            ViewBag.Tipos = items;
            return View(model);
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
