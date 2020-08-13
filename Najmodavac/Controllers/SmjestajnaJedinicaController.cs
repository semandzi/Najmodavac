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
    public class SmjestajnaJedinicaController : Controller
    {
        private readonly SmjestajDbContext _context;

        public SmjestajnaJedinicaController(SmjestajDbContext context)
        {
            _context = context;
        }

        // GET: SmjestajnaJedinica
        public async Task<IActionResult> Index()
        {
            var smjestajDbContext = _context.SmjestajnaJedinica.Include(s => s.NazivSmjestaja).Include(s => s.TipSmjestaja);
            return View(await smjestajDbContext.ToListAsync());
        }

        // GET: SmjestajnaJedinica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestajnaJedinica = await _context.SmjestajnaJedinica
                .Include(s => s.NazivSmjestaja)
                .Include(s => s.TipSmjestaja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smjestajnaJedinica == null)
            {
                return NotFound();
            }

            return View(smjestajnaJedinica);
        }

        // GET: SmjestajnaJedinica/Create
        public IActionResult Create()
        {
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv");
            ViewData["TipSmjestajaFk"] = new SelectList(_context.TipoviSmjestaja, "Id", "Grad");
            return View();
        }

        // POST: SmjestajnaJedinica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Velicina,Znacajke,ImagePath,Cijena,NazivSmjestajaFk,TipSmjestajaFk")] SmjestajnaJedinica smjestajnaJedinica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smjestajnaJedinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv", smjestajnaJedinica.NazivSmjestajaFk);
            ViewData["TipSmjestajaFk"] = new SelectList(_context.TipoviSmjestaja, "Id", "Grad", smjestajnaJedinica.TipSmjestajaFk);
            return View(smjestajnaJedinica);
        }

        // GET: SmjestajnaJedinica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestajnaJedinica = await _context.SmjestajnaJedinica.FindAsync(id);
            if (smjestajnaJedinica == null)
            {
                return NotFound();
            }
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv", smjestajnaJedinica.NazivSmjestajaFk);
            ViewData["TipSmjestajaFk"] = new SelectList(_context.TipoviSmjestaja, "Id", "Grad", smjestajnaJedinica.TipSmjestajaFk);
            return View(smjestajnaJedinica);
        }

        // POST: SmjestajnaJedinica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Velicina,Znacajke,ImagePath,Cijena,NazivSmjestajaFk,TipSmjestajaFk")] SmjestajnaJedinica smjestajnaJedinica)
        {
            if (id != smjestajnaJedinica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smjestajnaJedinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmjestajnaJedinicaExists(smjestajnaJedinica.Id))
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
            ViewData["NazivSmjestajaFk"] = new SelectList(_context.NaziviSmjestaja, "Id", "Naziv", smjestajnaJedinica.NazivSmjestajaFk);
            ViewData["TipSmjestajaFk"] = new SelectList(_context.TipoviSmjestaja, "Id", "Grad", smjestajnaJedinica.TipSmjestajaFk);
            return View(smjestajnaJedinica);
        }

        // GET: SmjestajnaJedinica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjestajnaJedinica = await _context.SmjestajnaJedinica
                .Include(s => s.NazivSmjestaja)
                .Include(s => s.TipSmjestaja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smjestajnaJedinica == null)
            {
                return NotFound();
            }

            return View(smjestajnaJedinica);
        }

        // POST: SmjestajnaJedinica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smjestajnaJedinica = await _context.SmjestajnaJedinica.FindAsync(id);
            _context.SmjestajnaJedinica.Remove(smjestajnaJedinica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmjestajnaJedinicaExists(int id)
        {
            return _context.SmjestajnaJedinica.Any(e => e.Id == id);
        }
    }
}
