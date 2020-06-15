using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoOTECWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoOTECWeb.Controllers
{
    public class ChartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetChart()
        {
            var data = _context.Cursos.ToList();
            return Json(data);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}