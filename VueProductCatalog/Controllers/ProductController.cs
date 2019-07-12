using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VueProductCatalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private static string[] Names = new[]
        {
            "Spoon", "Fork", "Butter Knife", "Steak Knife", "Plate", "Bowl", "Spatula", "Pot", "Pan"
        };

        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Quantity = rng.Next(1, 5),
                Name = Names[rng.Next(Names.Length)]
            });
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
    }
}
