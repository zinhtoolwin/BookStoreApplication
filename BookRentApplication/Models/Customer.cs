using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentApplication.Models
{
    public class Customer 
    {
        [Key]
        public int Id { get; set; }
        public string Customer_Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone_No { get; set; }



    }
}
