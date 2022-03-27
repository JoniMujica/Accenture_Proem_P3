using System.ComponentModel.DataAnnotations;

namespace MVC_ABM.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Direccion es requerido")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "El campo CUIT es requerido")]
        public string CUIT { get; set; }
    }
}
