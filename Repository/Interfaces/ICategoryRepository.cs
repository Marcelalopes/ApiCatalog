using System;
using System.Collections.Generic;
using api_catalogo.models;
using System.Threading.Tasks;

namespace api_catalogo.Repository.Interfaces
{
  public interface ICategoryRepository
  {
    Task<Category> add(Category category);
    Task<IEnumerable<Category>> GetAll();
    void Update(Category category);
    Boolean Delete(Guid id);
    Category DetailsCategory(Guid id);
  }
}