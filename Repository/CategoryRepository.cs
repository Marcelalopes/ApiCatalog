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
  public class CategoryRepository : ICategoryRepository
  {
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<Category> add(Category category)
    {
      var result = await _context.Category.AddAsync(category);
      _context.SaveChanges();

      return result.Entity;
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

    public async Task<IEnumerable<Category>> GetAll()
    {
      return await _context.Category.ToListAsync();
    }

    public void Update(Category category)
    {
      _context.Category.Update(category);
      _context.SaveChanges();
    }

    public Category DetailsCategory(Guid id)
    {
      return _context.Category.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
    }
  }
}