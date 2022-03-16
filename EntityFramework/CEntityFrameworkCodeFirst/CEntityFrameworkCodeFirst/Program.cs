using System;
using Entidades.Models;
using Entidades.Data;
using System.Collections.Generic;
using System.Linq;

namespace CEntityFrameworkCodeFirst
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            List<Alumno> alumnos = new List<Alumno>
            {
                new Alumno{Nombre = "Pepe",Apellido = "Gonzales",Calificacion = 10,Edad = 20},
                new Alumno{Nombre = "Luis",Apellido="Fernandez",Calificacion=10,Edad=30},
                new Alumno{Nombre = "Jesus",Apellido="Lopez",Calificacion=10,Edad=30},
                new Alumno{Nombre = "Erik",Apellido="Messi",Calificacion=10,Edad=25},
            };
            using (MyDBContext db = new MyDBContext())
            {
                alumnos.ForEach(alumn => db.Alumnos.Add(alumn).State = Microsoft.EntityFrameworkCore.EntityState.Added);
                db.SaveChanges();
            }
        }
    }
}
