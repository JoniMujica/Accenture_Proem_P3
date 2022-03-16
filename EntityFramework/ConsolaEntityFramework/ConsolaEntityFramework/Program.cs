using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.Database;

namespace ConsolaEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            //una ves realizado scaffold usanmos la db y los modelos

            /*  AGREGAR DATOS
            using(MyDataBase db = new MyDataBase())
            {
                Direccione dr = new Direccione
                {
                    Provincia = "BSAS",
                    Localidad = "lANUS",
                    Direccion = "Direccion 1234"
                };
                db.Direcciones.Add(dr).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                Persona persona = new Persona
                {
                    Nombre = "Jose",
                    Apellido = "Perez",
                    IdDireccion = dr.Id,
                    IdDireccionNavigation = dr
                };
                db.Personas.Add(persona).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                db.SaveChanges();

                Console.WriteLine("Termine de agregar");
            }*/

            /* Modificar datos
             * using(MyDataBase db = new MyDataBase())
            {
                Persona p = db.Personas.Where(p => p.Id == 1005).First();
                p.Apellido = "Lopez";
                p.Nombre = "Ramon";
                db.Personas.Update(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            
            }*/

            /* Eliminar datos
             * using(MyDataBase db = new MyDataBase())
            {
                Persona p = db.Personas.Where(p=>p.Id == 1005).First();
                db.Personas.Remove(p).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                Console.WriteLine("Termine de eliminar");
            }*/

            //posible error de relaciones

            using (MyDataBase db = new MyDataBase())
            {
                Direccione dr = db.Direcciones.First();
                db.Direcciones.Remove(dr);
                db.SaveChanges();

                Console.WriteLine("Termine de agregar");
            }
        }
    }
}
