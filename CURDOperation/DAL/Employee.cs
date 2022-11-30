using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CURDOperation.DAL
 //CURDOperation
{
    [Table("Emp")]
    public class Employee
    {
        [Key] // this is my PK in table
        [ScaffoldColumn(false)]

        public int Id { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Name { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public decimal Salary { get; set; }
    }
}
