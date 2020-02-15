using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentApplication.Models
{
    public class BookViewModel
    {
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Author_Name { get; set; }
    }
}
