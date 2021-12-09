using System;
using System.Collections.Generic;
using api_catalogo.models;
using api_catalogo.Dtos;

namespace api_catalogo.service
{
  public interface ICategoryService
  {
    IEnumerable<CategoriesDto> GetAll();
    CategoryNewDto Add(CategoryNewDto category);
    void Update(CategoriesDto category);
    Boolean Delete(Guid id);
  }
}