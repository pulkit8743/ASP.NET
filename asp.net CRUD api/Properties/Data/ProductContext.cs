using Microsoft.EntityFrameworkCore;
using PulkitApi.Models;

namespace PulkitApi.Data
{
  public class ProductContext : DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
  }
}