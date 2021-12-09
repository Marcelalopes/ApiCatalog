using System;
using System.Collections.Generic;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using api_catalogo.Context;
using System.Linq;

namespace api_catalogo.Repository
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
      _context = context;
    }

    public void add(Category category)
    {
      _context.Category.Add(category);
      _context.SaveChanges();
    }

    public Boolean Delete(Guid id)
    {
      var category = _context.Category.FirstOrDefault(c => c.Id == id);

      if (category == null)
        return false;

      _context.Category.Remove(category);
      _context.SaveChanges();
      return true;
    }

    public IEnumerable<Category> GetAll()
    {
      return _context.Category.ToList();
    }

    public void Update(Category category)
    {
      _context.Category.Update(category);
      _context.SaveChanges();
    }
  }
}