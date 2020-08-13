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
    public class RezervacijeController : Controller
    {
        private readonly SmjestajDbContext _context;

        public RezervacijeController(SmjestajDbContext context)
        {
            _context = context;
        }

        // GET: Rezervacije
        public async Task<IActionResult> Index()
        {
            var smjestajDbContext = _context.Rezervacije.Include(r => r.SmjestajnaJedinicaa);
            return View(await smjestajDbContext.ToListAsync());
        }

        // GET: Rezervacije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacije = await _context.Rezervacije
                .Include(r => r.SmjestajnaJedinicaa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacije == null)
            {
                return NotFound();
            }

            return View(rezervacije);
        }

        // GET: Rezervacije/Create
        public IActionResult Create()
        {
            ViewData["SmjestajnaJedinicaFk"] = new SelectList(_context.SmjestajnaJedinica, "Id", "Naziv");
            return View();
        }

        // POST: Rezervacije/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Adresa,Grad,Drzava,PocetakRezervacije,KrajRezervacije,SmjestajnaJedinicaFk")] Rezervacije rezervacije)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SmjestajnaJedinicaFk"] = new SelectList(_context.SmjestajnaJedinica, "Id", "Naziv", rezervacije.SmjestajnaJedinicaFk);
            return View(rezervacije);
        }

        // GET: Rezervacije/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacije = await _context.Rezervacije.FindAsync(id);
            if (rezervacije == null)
            {
                return NotFound();
            }
            ViewData["SmjestajnaJedinicaFk"] = new SelectList(_context.SmjestajnaJedinica, "Id", "Naziv", rezervacije.SmjestajnaJedinicaFk);
            return View(rezervacije);
        }

        // POST: Rezervacije/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Adresa,Grad,Drzava,PocetakRezervacije,KrajRezervacije,SmjestajnaJedinicaFk")] Rezervacije rezervacije)
        {
            if (id != rezervacije.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijeExists(rezervacije.Id))
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
            ViewData["SmjestajnaJedinicaFk"] = new SelectList(_context.SmjestajnaJedinica, "Id", "Naziv", rezervacije.SmjestajnaJedinicaFk);
            return View(rezervacije);
        }

        // GET: Rezervacije/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacije = await _context.Rezervacije
                .Include(r => r.SmjestajnaJedinicaa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervacije == null)
            {
                return NotFound();
            }

            return View(rezervacije);
        }

        // POST: Rezervacije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacije = await _context.Rezervacije.FindAsync(id);
            _context.Rezervacije.Remove(rezervacije);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijeExists(int id)
        {
            return _context.Rezervacije.Any(e => e.Id == id);
        }
    }
}
