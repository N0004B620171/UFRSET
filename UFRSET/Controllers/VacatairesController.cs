using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UFRSET.Data;
using UFRSET.Models;

namespace UFRSET.Controllers
{
    public class VacatairesController : Controller
    {
        private readonly UFRSETContext _context;

        public VacatairesController(UFRSETContext context)
        {
            _context = context;
        }

        // GET: Vacataires
        public async Task<IActionResult> Index()
        {
            var uFRSETContext = _context.Vacataire.Include(v => v.Departement).Include(v => v.Service);
            return View(await uFRSETContext.ToListAsync());
        }

        // GET: Vacataires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacataire = await _context.Vacataire
                .Include(v => v.Departement)
                .Include(v => v.Service)
                .FirstOrDefaultAsync(m => m.VacataireId == id);
            if (vacataire == null)
            {
                return NotFound();
            }

            return View(vacataire);
        }

        // GET: Vacataires/Create
        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId");
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId");
            return View();
        }

        // POST: Vacataires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacataireId,NomVacataire,Specialite,DepartementId,ServiceId")] Vacataire vacataire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacataire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", vacataire.DepartementId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", vacataire.ServiceId);
            return View(vacataire);
        }

        // GET: Vacataires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacataire = await _context.Vacataire.FindAsync(id);
            if (vacataire == null)
            {
                return NotFound();
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", vacataire.DepartementId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", vacataire.ServiceId);
            return View(vacataire);
        }

        // POST: Vacataires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacataireId,NomVacataire,Specialite,DepartementId,ServiceId")] Vacataire vacataire)
        {
            if (id != vacataire.VacataireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacataire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacataireExists(vacataire.VacataireId))
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
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", vacataire.DepartementId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", vacataire.ServiceId);
            return View(vacataire);
        }

        // GET: Vacataires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacataire = await _context.Vacataire
                .Include(v => v.Departement)
                .Include(v => v.Service)
                .FirstOrDefaultAsync(m => m.VacataireId == id);
            if (vacataire == null)
            {
                return NotFound();
            }

            return View(vacataire);
        }

        // POST: Vacataires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacataire = await _context.Vacataire.FindAsync(id);
            if (vacataire != null)
            {
                _context.Vacataire.Remove(vacataire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacataireExists(int id)
        {
            return _context.Vacataire.Any(e => e.VacataireId == id);
        }
    }
}
