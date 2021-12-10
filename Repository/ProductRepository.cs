using System;
using System.Collections.Generic;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using api_catalogo.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api_catalogo.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<Product> add(Product product)
    {
      var result = await _context.Product.AddAsync(product);
      _context.SaveChanges();

      return result.Entity;
    }

    public Boolean Delete(Guid id)
    {
      var product = _context.Product.FirstOrDefault(p => p.Id == id);

      if (product == null)
        return false;

      _context.Product.Remove(product);
      _context.SaveChanges();
      return true;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
      return await _context.Product.ToListAsync();
    }

    public void Update(Product product)
    {
      _context.Product.Update(product);
      _context.SaveChanges();
    }
    public Product DetailsProduct(Guid id)
    {
      return _context.Product.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
    }
  }
}