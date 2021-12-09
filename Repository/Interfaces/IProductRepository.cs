using System;
using System.Collections.Generic;
using api_catalogo.models;

namespace api_catalogo.Repository.Interfaces
{
  public interface IProductRepository
  {
    void add(Product product);
    IEnumerable<Product> GetAll();
    void Update(Product product);
    Boolean Delete(Guid id);
  }
}