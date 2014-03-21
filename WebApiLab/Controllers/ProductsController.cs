using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiLab.Models;

namespace WebApiLab.Controllers
{
    public class ProductsController : ApiController
    {
        static Product[] products = new Product[]  
        {  
            new Product { Id = 1, Name = "Coffee", Category = "TAIFEI", Price = 1 },  
            new Product { Id = 2, Name = "Bean", Category = "TAIFEI", Price = 3.75M },  
            new Product { Id = 3, Name = "Ship", Category = "MPISI", Price = 16.99M }  
        };

        //Product
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //Product/1
        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        //Product/?category=TAIFEI
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where(p => string.Equals(p.Category, category,
                    StringComparison.OrdinalIgnoreCase));
        }

        // POST api/products
        public void Post([FromBody]Product value)
        {
            var list = products.ToList();
            list.Add(value);
            products = list.ToArray();
        }


    }
}
