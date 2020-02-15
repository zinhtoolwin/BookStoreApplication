using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookRentApplication.Models
{
    public class Author
    {
        [Key]
        [Display(Name ="Author_Id")]
        [JsonIgnore]
        public int Author_Id { get; set; }
        [Display(Name ="Author")]
        public string Author_Name { get; set; }
        
        public ICollection<Book> Books { get; set; }
        
       

       
    }
}
