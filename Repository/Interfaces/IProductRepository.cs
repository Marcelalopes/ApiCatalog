using System;
using System.Collections.Generic;
using api_catalogo.models;
using System.Threading.Tasks;

namespace api_catalogo.Repository.Interfaces
{
  public interface IProductRepository
  {
    Task<Product> add(Product product);
    Task<IEnumerable<Product>> GetAll();
    void Update(Product product);
    Boolean Delete(Guid id);
  }
}