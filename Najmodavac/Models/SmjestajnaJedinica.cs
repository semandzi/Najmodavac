using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Najmodavac.Models
{
    public class SmjestajnaJedinica
    {           
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(5)]
        public string Velicina { get; set; }

        
        public string Znacajke { get; set; }


        [Display(Name = "Slika")]
        public string ImagePath { get; set; }

        [Required]
        public int Cijena { get; set; }


        [Display(Name = "Objekt")]
        public NazivSmjestaja NazivSmjestaja { get; set; }

       

        [ForeignKey("NazivSmjestaja")]
        public int NazivSmjestajaFk { get; set; }




        [Display(Name = "Grad")]
        public TipSmjestaja TipSmjestaja { get; set; }

       

        [ForeignKey("TipSmjestaja")]
        public int TipSmjestajaFk { get; set; }

        
        
    }
}
