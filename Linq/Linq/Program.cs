using System;
using System.Linq;
using System.Collections.Generic;
namespace Linq
{
    public class Program
    {
       // delegate void MiDelegado(string mensaje);
        static void Main(string[] args)
        {

            //como usar linq
            List<int> listaNumeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> numerosPares = from numero in listaNumeros where (numero % 2 == 0) select numero;
            //var resultado = from numero in listaNumeros where (numero % 2 == 0) select numero;    esto es mala practica

            //Forma vieja de recorrer
            /*foreach (int item in numerosPares)
            {
                Console.WriteLine(item);
            }*/

            //Forma nueva Linq:
            numerosPares.ToList().ForEach(numero => Console.WriteLine(numero)); //para este ForEach es importante convertilo a lista [ToList()]



            //ListaDePersonas
            List<Persona> personas = new List<Persona>()
            {
                new Persona() { Id = 1, Name = "Pepe", Age = 25},
                new Persona() { Id = 2, Name = "Alejandro", Age= 34},
                new Persona() { Id = 3, Name = "Roma", Age=50}
            };
            /*IEnumerable<object> listaAnonima = from persona in personas
                                               where persona.Age > 30
                                               select new //este new esta creando un objeto nuevo distinto de Personas pero con sus datos, y es seleccionado en la query
                                               {
                                                   id = persona.Id,
                                                   name = persona.Name,
                                                   mensaje = "Persona Anonima"
                                               };

            listaAnonima.ToList().ForEach(persona => Console.WriteLine(persona.ToString()));*/


            //ordenar con linq
            //personas.Sort((persona1,persona2) => persona1.Age-persona2.Age);

            //personas.Sort((persona1, persona2) => //version larga
            //{
            //    if (persona1.Age<persona2.Age)
            //    {
            //        return -1;
            //    }
            //    else if(persona2.Age > persona1.Age)
            //    {
            //        return 1;
            //    }
            //    return 0;
            //});
            //personas.ForEach(persona => Console.WriteLine(persona.Age));

            //retornar IEnumerable
            IEnumerable<int> numerosPares2 = listaNumeros.Where(numero => (numero % 2 == 0));
            
            numerosPares2.ToList().ForEach(numero => Console.WriteLine(numero));


            //MiDelegado mensajeador = new MiDelegado(EscribirMensaje);
            //mensajeador("Hello Word!");
            //Console.WriteLine("Hello World!");

            Action<int> action = (num) => Console.WriteLine(num);  //el parametro num debe ir obligado ya que en Action<> declaramos un int
            action(1);
        }
        /*public static void EscribirMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        public static void EscribirMensaje2(int numero)
        {
            Console.WriteLine(numero);
        }*/
    }
    public class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
