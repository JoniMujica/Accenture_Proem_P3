using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Data
{
    //clase de contexto DB
    public class MyDBContext : DbContext
    {
        public MyDBContext()
        {

        }
        public DbSet<Alumno> Alumnos { get; set; } //esto se setea en base a la class persona que es padre de Profesor y Alumno
        public DbSet<Profesor> Profesores { get; set; } 
        public MyDBContext(DbContextOptions<MyDBContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=MyDB;Trusted_Connection=True;");
        }

    }
}
