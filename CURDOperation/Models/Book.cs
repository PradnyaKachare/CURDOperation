using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.Models
{
    [Table("Book")]
    public class Book
    {

        [Key]
        [ScaffoldColumn(false)]

        public int Bookid { get; set; }

        [Required(ErrorMessage = "Name is required")]

        public string? Name { get; set; }

        [Required(ErrorMessage = "Price is required")]

        public int? Price { get; set; }

        [Required(ErrorMessage = "Author is required")]

        public string? Author { get; set; }

        [Required(ErrorMessage = "Publisher is required")]

        public string? Publisher { get; set; }
        

    }

}
