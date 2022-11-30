using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.DAL
{
    [Table("Product")]
    public class Product
    {
        [Key] // this is my PK in table
        [ScaffoldColumn(false)]

           public int Id { get; set; }

            public string?Name { get; set; }

            public decimal Price { get; set; }
    }
}
