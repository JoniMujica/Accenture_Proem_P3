namespace MVC_StarWars.Models
{
    public class Mision
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; }
        public int PersonajeId { get; set;} //esto es para agregar en la tabla la ID del personaje
        public Personaje Personaje { get; set; } //esto es para que entity framework relacione el valor de PersonajeId

    }
}
