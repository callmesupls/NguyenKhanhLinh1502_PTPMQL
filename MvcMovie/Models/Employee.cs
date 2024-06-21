using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Employee : Person
    {
        // [Key]
        // public int EmployeeID { get; set; }
        public string TenEmployee { get; set; }
    }
}