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
    public class TipSmjestajaController : Controller
    {
        private readonly SmjestajDbContext _context;

        public TipSmjestajaController(SmjestajDbContext context)
        {
            _context = context;
        }

        // GET: TipSmjestaja
        public async Task<IActionResult> Index()
        {
            var smjestajDbContext = _context.TipoviSmjestaja.Include(t => t.NazivSmjestaja);
            return View(await smjestajDbContext.ToListAsync());
        }

        // GET: TipSmjestaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipSmjestaja = await _context.TipoviSmjestaja
                .Include(t => t.NazivSmjestaja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipSmjestaja == null)
            {
                return NotFound();
            }

            return View(tipSmjestaja);
        }

        // GET: TipSmjestaja/Create
        public IActionResult Create()
        {
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv");
            return View();
        }

        // POST: TipSmjestaja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vrsta,Grad,Ulica,PostanskiBroj,BrojSmjestajnihJedinica,NazivSmjestajaFk")] TipSmjestaja tipSmjestaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipSmjestaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv", tipSmjestaja.NazivSmjestajaFk);
            return View(tipSmjestaja);
        }

        // GET: TipSmjestaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipSmjestaja = await _context.TipoviSmjestaja.FindAsync(id);
            if (tipSmjestaja == null)
            {
                return NotFound();
            }
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv", tipSmjestaja.NazivSmjestajaFk);
            return View(tipSmjestaja);
        }

        // POST: TipSmjestaja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vrsta,Grad,Ulica,PostanskiBroj,BrojSmjestajnihJedinica,NazivSmjestajaFk")] TipSmjestaja tipSmjestaja)
        {
            if (id != tipSmjestaja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipSmjestaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipSmjestajaExists(tipSmjestaja.Id))
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
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv", tipSmjestaja.NazivSmjestajaFk);
            return View(tipSmjestaja);
        }

        // GET: TipSmjestaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipSmjestaja = await _context.TipoviSmjestaja
                .Include(t => t.NazivSmjestaja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipSmjestaja == null)
            {
                return NotFound();
            }

            return View(tipSmjestaja);
        }

        // POST: TipSmjestaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipSmjestaja = await _context.TipoviSmjestaja.FindAsync(id);
            _context.TipoviSmjestaja.Remove(tipSmjestaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipSmjestajaExists(int id)
        {
            return _context.TipoviSmjestaja.Any(e => e.Id == id);
        }
    }
}
