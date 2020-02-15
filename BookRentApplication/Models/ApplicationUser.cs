using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool Active { get; set; }
    }
}
