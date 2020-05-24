using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoOTECWeb.Data;
using DemoOTECWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DemoOTECWeb.Controllers
{
    [Authorize(Roles ="Admin, Alumno")]
    public class EstudianteController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _hostEnvironment;

        public EstudianteController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostingEnvironment;
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Estudiantes.Include(e => e.Relator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.Relator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            ViewData["RelatorId"] = new SelectList(_context.Relators, "Id", "NombreCompleto");
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Apellido,Email,Edad,FechaNacimiento,PDE,NombreImagen,ImagenArchivo,RelatorId")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(estudiante.ImagenArchivo.FileName);
                string extension = Path.GetExtension(estudiante.ImagenArchivo.FileName);
                estudiante.NombreImagen = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await estudiante.ImagenArchivo.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelatorId"] = new SelectList(_context.Relators, "Id", "NombreCompleto", estudiante.RelatorId);
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["RelatorId"] = new SelectList(_context.Relators, "Id", "NombreCompleto", estudiante.RelatorId);
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Apellido,Email,Edad,FechaNacimiento,PDE,NombreImagen,RelatorId")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelatorId"] = new SelectList(_context.Relators, "Id", "NombreCompleto", estudiante.RelatorId);
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.Relator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            //delete image from wwwroot/image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", estudiante.NombreImagen);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //delete the record
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}
