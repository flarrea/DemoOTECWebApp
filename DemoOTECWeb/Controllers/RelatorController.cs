using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoOTECWeb.Data;
using DemoOTECWeb.Models;

namespace DemoOTECWeb.Controllers
{
    public class RelatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Relator
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Relators.Include(r => r.Curso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Relator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relator = await _context.Relators
                .Include(r => r.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relator == null)
            {
                return NotFound();
            }

            return View(relator);
        }

        // GET: Relator/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nombre");
            return View();
        }

        // POST: Relator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Edad,AnosExperiencia,NumeroTelefono,Especialidad,CursoId")] Relator relator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nombre", relator.CursoId);
            return View(relator);
        }

        // GET: Relator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relator = await _context.Relators.FindAsync(id);
            if (relator == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nombre", relator.CursoId);
            return View(relator);
        }

        // POST: Relator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Edad,AnosExperiencia,NumeroTelefono,Especialidad,CursoId")] Relator relator)
        {
            if (id != relator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorExists(relator.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nombre", relator.CursoId);
            return View(relator);
        }

        // GET: Relator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relator = await _context.Relators
                .Include(r => r.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relator == null)
            {
                return NotFound();
            }

            return View(relator);
        }

        // POST: Relator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relator = await _context.Relators.FindAsync(id);
            _context.Relators.Remove(relator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorExists(int id)
        {
            return _context.Relators.Any(e => e.Id == id);
        }
    }
}
