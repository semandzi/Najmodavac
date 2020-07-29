using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Najmodavac.Models
{
    public class AplicationUsers:IdentityUser
    {
        [NotMapped]
        public bool IsAdmin { get; set; }
    }
}
