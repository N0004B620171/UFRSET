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
    public class PersController : Controller
    {
        private readonly UFRSETContext _context;

        public PersController(UFRSETContext context)
        {
            _context = context;
        }

        // GET: Pers
        public async Task<IActionResult> Index()
        {
            var uFRSETContext = _context.Per.Include(p => p.Departement).Include(p => p.Service);
            return View(await uFRSETContext.ToListAsync());
        }

        // GET: Pers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var per = await _context.Per
                .Include(p => p.Departement)
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (per == null)
            {
                return NotFound();
            }

            return View(per);
        }

        // GET: Pers/Create
        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId");
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId");
            return View();
        }

        // POST: Pers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerId,NomPer,Specialite,DepartementId,ServiceId")] Per per)
        {
            if (ModelState.IsValid)
            {
                _context.Add(per);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", per.DepartementId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", per.ServiceId);
            return View(per);
        }

        // GET: Pers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var per = await _context.Per.FindAsync(id);
            if (per == null)
            {
                return NotFound();
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", per.DepartementId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", per.ServiceId);
            return View(per);
        }

        // POST: Pers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerId,NomPer,Specialite,DepartementId,ServiceId")] Per per)
        {
            if (id != per.PerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(per);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerExists(per.PerId))
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
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", per.DepartementId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", per.ServiceId);
            return View(per);
        }

        // GET: Pers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var per = await _context.Per
                .Include(p => p.Departement)
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.PerId == id);
            if (per == null)
            {
                return NotFound();
            }

            return View(per);
        }

        // POST: Pers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var per = await _context.Per.FindAsync(id);
            if (per != null)
            {
                _context.Per.Remove(per);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerExists(int id)
        {
            return _context.Per.Any(e => e.PerId == id);
        }
    }
}
