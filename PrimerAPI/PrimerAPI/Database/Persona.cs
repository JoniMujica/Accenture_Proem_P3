using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PrimerAPI.Database
{
    public partial class Persona
    {
        public int Id { get; set; }
        [Required] //esto indica que el atributo del objeto, va a ser requerido SI O SI
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Sexo { get; set; }
    }
}
