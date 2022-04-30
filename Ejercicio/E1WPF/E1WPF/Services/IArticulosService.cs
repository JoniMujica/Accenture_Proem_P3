using E1WPF.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1WPF.Services
{
    internal interface IArticulosService
    {
        [Get("/api/articulos")]
        Task<List<Articulo>> ObtenerArticulos();
        [Post("/api/articulos")]
        Task<Articulo> Insertar(Articulo articulo);
    }
}
