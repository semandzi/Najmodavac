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
    public class PregledSmjestajaController : Controller
    {
        private readonly SmjestajDbContext _context;

        public PregledSmjestajaController(SmjestajDbContext context)
        {
            _context = context;
        }

        // GET: PregledSmjestaja
        public async Task<IActionResult> Index()
        {
            var smjestajDbContext = _context.SmjestajnaJedinica.Include(s => s.NazivSmjestaja).Include(s => s.TipSmjestaja);
            return View(await smjestajDbContext.ToListAsync());
        }

        // GET: PregledSmjestaja/Details/5
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


    }
}
