using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOTECWeb.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, ingrese un nombre!")]
        [StringLength(20, ErrorMessage = "El nombre es muy largo.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingrese la dirección del lugar!")]
        public string Lugar { get; set; }
        [Display(Name = "Fecha de inicio del curso")]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Número de estudiantes")]
        public int NumeroEstudiantes { get; set; }

        //Relations
        public List<Relator> Relators { get; set; }

    }
}
