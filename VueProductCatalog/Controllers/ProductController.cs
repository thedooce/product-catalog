using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VueProductCatalog.Models;

namespace VueProductCatalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        static List<Product> ProductsList = new List<Product>();

        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {
            return ProductsList;
        }

        [HttpPost("[action]")]
        public IActionResult AddNewProduct([FromBody] Product newProduct)
        {
            //Validate fields
            if (ProductsList.Where(s => s.Name.Equals(newProduct.Name)).Any() 
                || string.IsNullOrEmpty(newProduct.Name) 
                || newProduct.Quantity < 1
                || newProduct.Quantity > 999)
            {
                return new BadRequestResult();
            }
            else
            {
                ProductsList.Add(newProduct);
                return Ok(ProductsList);
            }
        }
    }
}

