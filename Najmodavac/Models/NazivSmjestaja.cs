using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Najmodavac.Models
{
    public class NazivSmjestaja
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        

    }
}
