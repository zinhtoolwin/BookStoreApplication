using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookRentApplication.Models
{
    public class Book
    {
        [Display(Name ="Book_Id")]
        [Key]
        
        public int Book_Id { get; set; }
        [Display(Name = "Book")]
        public string Book_Name { get; set; }
       
        [ForeignKey("AuthorId")]
        
        public int AuthorId { get; set; }
      
        public  Author Author { get; set; }
        


    }
}
