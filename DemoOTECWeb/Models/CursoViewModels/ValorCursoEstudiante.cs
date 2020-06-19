using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoOTECWeb.Models.CursoViewModels
{
    public class ValorCursoEstudiante
    {
        [DataType(DataType.Date)]
        public string Nombre { get; set; }

        public double CursoValor { get; set; }

        public double TotalAlumnos { get; set; }
    }
}
