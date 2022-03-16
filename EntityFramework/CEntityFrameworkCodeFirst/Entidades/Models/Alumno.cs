using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public sealed class Alumno : Persona
    {
        /*[Key] //data notation, es para marcar este campo como si fuera ID en nuestra DB   
        public string Algo { get; set; }*/
        public int Calificacion { get; set; }
    }
}
