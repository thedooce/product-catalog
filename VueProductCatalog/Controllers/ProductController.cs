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
            "Spoon", "Fork", "Butter Knife", "Steak Knife", "Plate", "Bowl", "Rubber Spatula", "Copper Pot", "Cast Iron Pan"
        };

        private static string[] Descriptions = new[]
        {
            "High quality stainless steel.", "Cheap, but gets the job done.", "Won't break on your first use, but also won't last much longer", "On clearance!",
            "New item!", "New for Summer 2019!"
        };

        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Quantity = rng.Next(1, 5),
                Name = Names[rng.Next(Names.Length)],
                Description = Descriptions[rng.Next(Descriptions.Length)]
            });
        }

        [HttpPost("[action]")]
        public void AddNewProduct(Product newProduct)
        {
            //Validate newProduct fields
            //Add to Product List
            //Return success 200 or fail-something to JS, as HttpResponse. Add custom text in response?
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
    }
}
