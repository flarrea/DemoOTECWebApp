using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoOTECWeb.Data;
using DemoOTECWeb.Models.CursoViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoOTECWeb.Controllers
{
    public class CalculoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalculoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Calculos()
        {
            IQueryable<ValorCursoEstudiante> data =

            from curso in _context.Cursos

            group curso by curso.Nombre into dateGroup

            orderby dateGroup.Key descending

            select new ValorCursoEstudiante()
            {
                Nombre = dateGroup.Key,
                CursoValor = dateGroup.Sum(x => x.Valor),
                TotalAlumnos = dateGroup.Sum(y => y.NumeroEstudiantes)
            };

            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}