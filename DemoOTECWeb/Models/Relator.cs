using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOTECWeb.Models
{
    public class Relator
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor ingrse su nombre.")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        [Range(25, 70, ErrorMessage = "Por favor, ingrese su edad entre 25 and 70.")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Años de experiencia")]
        public double AnosExperiencia { get; set; }

        [Phone(ErrorMessage = "No es un número de teléfono válido")]
        [Display(Name = "Número de teléfono")]
        public string NumeroTelefono { get; set; }
        public string Especialidad { get; set; }


        // Relations
        public virtual Curso Curso { get; set; }
        [Display(Name = "Nombre del curso")]
        public int CursoId { get; set; }

        public List<Estudiante> Estudiantes { get; set; }

    }
}
