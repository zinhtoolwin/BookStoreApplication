using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentApplication.Models.ViewModel
{
    public class RegisterViewModel
    {
        public string[] Roles { get; set; }
        public List<ApplicationRoleRegisterViewModel> RolesList { get; set; }
    }
}
