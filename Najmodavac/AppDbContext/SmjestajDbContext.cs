using Microsoft.EntityFrameworkCore;
using Najmodavac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Najmodavac.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Najmodavac.AppDbContext
{
    public class SmjestajDbContext:IdentityDbContext<IdentityUser>
    {
        public SmjestajDbContext(DbContextOptions<SmjestajDbContext> options):base(options)
        {

        }

        public DbSet<NazivSmjestaja> NaziviSmjestaja { get; set; }
        public DbSet<TipSmjestaja> TipoviSmjestaja { get; set; }
        public DbSet<Najmodavac.Models.ViewModel.NazivViewTipSmjestaja> NazivViewTipSmjestaja { get; set; }
    }
}
