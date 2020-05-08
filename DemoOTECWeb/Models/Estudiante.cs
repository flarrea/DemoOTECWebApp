using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOTECWeb.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese nombre completo!")]
        [StringLength(25, ErrorMessage = "Nombre completo es muy largo.")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [EmailAddress]
        [Display(Name = "Dirección email")]
        public string Email { get; set; }

        [Range(15, 25, ErrorMessage = "La edad debe ser entre 18 and 50")]
        public int Edad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [Range(0, 4.0, ErrorMessage = "Promedio de egreso.")]
        public double PDE { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Nombre Imagen")]
        public string NombreImagen { get; set; }

        [NotMapped]
        [DisplayName("Upload Archivo")]
        public IFormFile ImagenArchivo { get; set; }

        //Relations
        public virtual Relator Relator { get; set; }
        [Display(Name = "Nombre relator")]
        public int RelatorId { get; set; }

    }
}
