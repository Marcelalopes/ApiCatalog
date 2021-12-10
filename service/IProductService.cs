using System;
using System.Collections.Generic;
using api_catalogo.Dtos;
using System.Threading.Tasks;

namespace api_catalogo.service
{
  public interface IProductService
  {
    Task<IEnumerable<ProductsDto>> GetAll();
    Task<ProductNewDto> Add(ProductNewDto p);
    void Update(ProductsDto p);
    Boolean Delete(Guid id);
  }
}