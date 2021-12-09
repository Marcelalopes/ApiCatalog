using System;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using api_catalogo.Dtos;

namespace api_catalogo.service
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    public IEnumerable<CategoriesDto> GetAll()
    {
      var result = _categoryRepository.GetAll().ToList();

      List<CategoriesDto> listResult = new List<CategoriesDto>();

      foreach (var category in result)
      {
        listResult.Add(new CategoriesDto()
        {
          Id = category.Id,
          Nome = category.Name
        });
      }

      return listResult;
    }

    public CategoryNewDto Add(CategoryNewDto newCategory)
    {
      Category category = new Category()
      {
        Name = newCategory.Nome
      };

      _categoryRepository.add(category);
      return newCategory;
    }

    public void Update(CategoriesDto updateCategory)
    {
      Category category = new Category()
      {
        Id = updateCategory.Id,
        Name = updateCategory.Nome
      };

      _categoryRepository.Update(category);
    }

    public Boolean Delete(Guid id)
    {
      return _categoryRepository.Delete(id);
    }
  }
}