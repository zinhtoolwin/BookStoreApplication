using BookRentApplication.Data;
using BookRentApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Data
{
    public class UserData
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed=true,
                    
                    
                    
                };


                IdentityResult result = userManager.CreateAsync(user, "Passw0rd@123$").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
    

