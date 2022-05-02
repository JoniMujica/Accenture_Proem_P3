using EjemploTP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploTP.Controllers
{
    public class TragoController : Controller
    {
        private readonly AppDbContext context;
        public TragoController()
        {
            this.context = new AppDbContext();
        }
        public IActionResult Index()
        {
            return View(context.Tragos.ToList());
        }
        /*public IActionResult Editar(int id)
        {
            EditarViewModel model = new EditarViewModel();
            model.Tragos = context.Tragos.Find(id);
            var ingredientes = context.Ingredientes.Where(x => x.TragoId == id).ToList();
            if (ingredientes.Count > 0)
            {
                model.Item1 = ingredientes[0];
            }
            if (ingredientes.Count > 1)
            {
                model.Item2 = ingredientes[1];
            }
            if (ingredientes.Count > 2)
            {
                model.Item3 = ingredientes[2];
            }
            if (ingredientes.Count > 3)
            {
                model.Item4 = ingredientes[3];
            }
            if (ingredientes.Count > 4)
            {
                model.Item5 = ingredientes[4];
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Editar(EditarViewModel valores)
        {
            if (valores.Tragos.Id == 0)
            {
                context.Add(valores.Tragos); 
            }
            else
            {
                context.Tragos.Attach(valores.Tragos);
                context.Entry(valores.Tragos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            if (!string.IsNullOrEmpty(valores.Item1.Codigo))
            {
                valores.Item1.Trago = valores.Tragos;
                if(valores.Item1.Id == 0)
                {
                    context.Ingredientes.Add(valores.Item1);
                }
                else
                {
                    context.Ingredientes.Attach(valores.Item1);
                    context.Entry(valores.Item1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            if (!string.IsNullOrEmpty(valores.Item2.Codigo))
            {
                 valores.Item2.Trago = valores.Tragos;
                if (valores.Item2.Id == 0)
                {
                    context.Ingredientes.Add(valores.Item2);
                }
                else
                {
                    context.Ingredientes.Attach(valores.Item2);
                    context.Entry(valores.Item2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            if (!string.IsNullOrEmpty(valores.Item3.Codigo))
            {
                valores.Item3.Trago = valores.Tragos;
                if (valores.Item3.Id == 0)
                {
                    context.Ingredientes.Add(valores.Item3);
                }
                else
                {
                    context.Ingredientes.Attach(valores.Item3);
                    context.Entry(valores.Item3).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            if (!string.IsNullOrEmpty(valores.Item4.Codigo))
            {
                valores.Item4.Trago = valores.Tragos;
                if (valores.Item4.Id == 0)
                {
                    context.Ingredientes.Add(valores.Item4);
                }
                else
                {
                    context.Ingredientes.Attach(valores.Item4);
                    context.Entry(valores.Item4).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            if (!string.IsNullOrEmpty(valores.Item5.Codigo))
            {
                valores.Item5.Trago = valores.Tragos;
                if (valores.Item5.Id == 0)
                {
                    context.Ingredientes.Add(valores.Item5);
                }
                else
                {
                    context.Ingredientes.Attach(valores.Item5);
                    context.Entry(valores.Item5).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            context.SaveChanges();
            return Redirect("Index");
        }*/
        [HttpPost]
        public IActionResult Agregar(EditarViewModel2 valores)
        {
            if (valores.Ingredientes == null)
            {
                valores.Ingredientes = new List<Ingrediente>();
            }
            valores.Ingredientes.Add(valores.Item);
            valores.Item = new Ingrediente();
            return View("Editar2",valores);
        }
        public IActionResult Editar2(int id)
        {
            EditarViewModel2 model = new EditarViewModel2();
            model.Tragos = context.Tragos.Find(id); 
            model.Ingredientes = context.Ingredientes.Where(x => x.TragoId == id).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Editar2(EditarViewModel2 valores)
        {
            if (valores.Tragos.Id == 0)
            {
                context.Add(valores.Tragos);
            }
            else
            {
                context.Tragos.Attach(valores.Tragos);
                context.Entry(valores.Tragos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            foreach (var item in valores.Ingredientes)
            {
                item.Trago = valores.Tragos;
                if (item.Id == 0)
                {
                    context.Ingredientes.Add(item);
                }
                else
                {
                    context.Ingredientes.Attach(item);
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            
            context.SaveChanges();
            return Redirect("Index");
        }
    }
}
