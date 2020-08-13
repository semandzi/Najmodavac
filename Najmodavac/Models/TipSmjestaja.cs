using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Najmodavac.Models
{
    public class TipSmjestaja
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Vrsta { get; set; }

        [Required]
        public string Grad { get; set; }


        [Required]
        public string Ulica { get; set; }

        [Required]
        [Display(Name = "Postanski Broj")]
        public int PostanskiBroj  { get; set; }

        [Required]
        [Display(Name = "Broj Smjestajnih Jedinica")]
        public int BrojSmjestajnihJedinica { get; set; }

        [Display(Name = "Naziv Smjestaja")]
        public NazivSmjestaja NazivSmjestaja { get; set; }

        [ForeignKey("NazivSmjestaja")]
        [Display(Name = "Naziv Smjestaja")]
        public int NazivSmjestajaFk { get; set; }










    }
}
