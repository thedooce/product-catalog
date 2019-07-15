using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VueProductCatalog.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required, Range(1, 999, ErrorMessage = "Quantity is required, must be between 1 and 999")]
        public int Quantity { get; set; }

        public string Description { get; set; }
        
    }
}
