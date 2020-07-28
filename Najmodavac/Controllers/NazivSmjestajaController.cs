using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Najmodavac.AppDbContext;
using Najmodavac.Models;

namespace Najmodavac.Controllers
{
    public class NazivSmjestajaController : Controller
    {
        private readonly SmjestajDbContext _context;

        public NazivSmjestajaController(SmjestajDbContext context)
        {
            _context = context;
        }

        // GET: NazivSmjestaja
        public async Task<IActionResult> Index()
        {
            return View(await _context.NaziviSmjestaja.ToListAsync());
        }

        // GET: NazivSmjestaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nazivSmjestaja = await _context.NaziviSmjestaja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nazivSmjestaja == null)
            {
                return NotFound();
            }

            return View(nazivSmjestaja);
        }

        // GET: NazivSmjestaja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NazivSmjestaja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv")] NazivSmjestaja nazivSmjestaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nazivSmjestaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nazivSmjestaja);
        }

        // GET: NazivSmjestaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nazivSmjestaja = await _context.NaziviSmjestaja.FindAsync(id);
            if (nazivSmjestaja == null)
            {
                return NotFound();
            }
            return View(nazivSmjestaja);
        }

        // POST: NazivSmjestaja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv")] NazivSmjestaja nazivSmjestaja)
        {
            if (id != nazivSmjestaja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nazivSmjestaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NazivSmjestajaExists(nazivSmjestaja.Id))
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
            return View(nazivSmjestaja);
        }

        // GET: NazivSmjestaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nazivSmjestaja = await _context.NaziviSmjestaja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nazivSmjestaja == null)
            {
                return NotFound();
            }

            return View(nazivSmjestaja);
        }

        // POST: NazivSmjestaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nazivSmjestaja = await _context.NaziviSmjestaja.FindAsync(id);
            _context.NaziviSmjestaja.Remove(nazivSmjestaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NazivSmjestajaExists(int id)
        {
            return _context.NaziviSmjestaja.Any(e => e.Id == id);
        }
    }
}
