using System;

namespace Linq
{
    public class Program
    {
        delegate void MiDelegado(string mensaje);
        static void Main(string[] args)
        {
            MiDelegado mensajeador = new MiDelegado(EscribirMensaje);
            mensajeador("Hello Word!");
            //Console.WriteLine("Hello World!");
        }
        public static void EscribirMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        public static void EscribirMensaje2(int numero)
        {
            Console.WriteLine(numero);
        }
    }
}
