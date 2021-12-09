using System;
using System.Collections.Generic;
using api_catalogo.models;

namespace api_catalogo.Repository.Interfaces
{
  public interface ICategoryRepository
  {
    void add(Category category);
    IEnumerable<Category> GetAll();
    void Update(Category category);
    Boolean Delete(Guid id);
  }
}