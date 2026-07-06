using Microsoft.AspNetCore.Mvc;
using task9.Models;

namespace task9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class product_controller : ControllerBase
    {
            public readonly List<Products> products = new()
        {
            new Products { Id = 1, Name = "Laptop", Price = 1000 },
            new Products { Id = 2, Name = "Phone", Price = 500 }
        };

            [HttpGet]
            public ActionResult<IEnumerable<Products>> GetProducts()
            {
                if (!products.Any())
                {
                    return NotFound();
                }

                return Ok(products);
            }

            [HttpGet("{id}")]
            public ActionResult<Products> GetProductById(int id)
            {
                var product = products.Find(p => p.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }

            [HttpPost]
            public ActionResult<Products> AddProduct(Products product)
            {
                if (product == null)
                {
                    return BadRequest();
                }

                products.Add(product);

                return Created($"/api/products/{product.Id}", product);
            }

            [HttpPut("{id}")]
            public ActionResult<Products> UpdateProduct(int id, Products updatedProduct)
            {
                if (updatedProduct == null)
                {
                    return BadRequest();
                }

                var product = products.Find(p => p.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;

                return Ok(product);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteProduct(int id)
            {
                var product = products.Find(p => p.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                products.Remove(product);

                return NoContent();
            }
        }
    }
