using System;
using System.Collections.Generic;
using api_catalogo.Dtos;
using System.Threading.Tasks;

namespace api_catalogo.service
{
  public interface ICategoryService
  {
    Task<IEnumerable<CategoriesDto>> GetAll();
    Task<CategoryNewDto> Add(CategoryNewDto category);
    void Update(CategoriesDto category);
    Boolean Delete(Guid id);
    DetailsCategoryDto DetailsCategory(Guid id);
  }
}