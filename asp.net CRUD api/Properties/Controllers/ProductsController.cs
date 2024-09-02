using Microsoft.AspNetCore.Mvc;
using PulkitApi.Data;
using PulkitApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PulkitApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly ProductContext _context;

    public ProductsController(ProductContext context)
    {
      _context = context;
    }

    // GET: api/Products
    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
      return _context.Products.ToList();
    }

    // GET: api/Products/{id}
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
      var product = _context.Products.Find(id);
      if (product == null)
      {
        return NotFound();
      }

      return product;
    }

    // POST: api/Products
    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // PUT: api/Products/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
      var existingProduct = _context.Products.Find(id);
      if (existingProduct == null)
      {
        return NotFound();
      }

      existingProduct.Name = product.Name;
      existingProduct.Price = product.Price;
      _context.Products.Update(existingProduct);
      _context.SaveChanges();

      return NoContent();
    }

    // DELETE: api/Products/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var product = _context.Products.Find(id);
      if (product == null)
      {
        return NotFound();
      }

      _context.Products.Remove(product);
      _context.SaveChanges();

      return NoContent();
    }
  }
}
