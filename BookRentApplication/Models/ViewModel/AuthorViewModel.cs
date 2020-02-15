using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentApplication.Models
{
    public class AuthorViewModel
    {
        public int Author_Id { get;set;}
        public string Author_Name { get; set; }
       
        public ICollection<Book> Books { get; set; }
    }
}
