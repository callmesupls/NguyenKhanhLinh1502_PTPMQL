using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CallmeSu_33.Models
{
    public class Book
    {
        public string NameBook { get; set; }

        [Key]
        public string IdBook { get; set; }

        public string IdCate { get; set; }
        [ForeignKey("IdCate")]
        public Category Category { get; set; }
        
        
    }
}