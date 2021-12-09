using System;
using System.Collections.Generic;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using api_catalogo.Context;
using System.Linq;

namespace api_catalogo.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
      _context = context;
    }

    public void add(Product product)
    {
      _context.Product.Add(product);
      _context.SaveChanges();
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

    public IEnumerable<Product> GetAll()
    {
      return _context.Product.ToList();
    }

    public void Update(Product product)
    {
      _context.Product.Update(product);
      _context.SaveChanges();
    }
  }
}