using System.ComponentModel.DataAnnotations;

namespace MVC_StarWars.Models
{
    public class Personaje
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Tipo de personaje")] //esto nos va a cambiar el label del dropdown de la vista Editar
        public int TipoId { get; set; } //aca modifique la modelo de la DB, si o si tengo que ahce un migration
    }
}
