using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Najmodavac.Models.ViewModel
{
    public class NazivViewTipSmjestaja
    {
        public TipSmjestaja TipSmjestaja { get; set; }
        public IEnumerable<NazivSmjestaja> NazivSmjestaja { get; set; }
        public int Id { get; set; }
    }
}
