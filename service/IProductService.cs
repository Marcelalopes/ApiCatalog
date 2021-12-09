using System;
using System.Collections.Generic;
using api_catalogo.models;
using api_catalogo.Dtos;

namespace api_catalogo.service
{
  public interface IProductService
  {
    IEnumerable<ProductsDto> GetAll();
    ProductNewDto Add(ProductNewDto p);
    void Update(ProductsDto p);
    Boolean Delete(Guid id);
  }
}