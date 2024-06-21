using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallmeSu_33.Models
{
    public class Category
    {
        public string NameCate { get; set; }

        [Key]
        public string IdCate { get; set; }
    }
}