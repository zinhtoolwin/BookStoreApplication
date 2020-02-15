using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentApplication.Models.ViewModel
{
    public class ApplicationRoleRegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
