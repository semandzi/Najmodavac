using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Najmodavac.Models
{
    public class Rezervacije
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string Grad { get; set; }

        [Required]
        public string Drzava { get; set; }

        [Required]
        [Display(Name = "Pocetak Rezervacije")]
        public DateTime PocetakRezervacije { get; set; }

        [Required]
        [Display(Name = "Kraj Rezervacije")]
        public DateTime KrajRezervacije { get; set; }

        [Display(Name = "Smjestajna Jedinica")]

        public SmjestajnaJedinica SmjestajnaJedinicaa { get; set; }

        [ForeignKey("SmjestajnaJedinicaa")]
        public int SmjestajnaJedinicaFk { get; set; }



    }
}
