using System;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using api_catalogo.Dtos;
using AutoMapper;

namespace api_catalogo.service
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
      _categoryRepository = categoryRepository;
      _mapper = mapper;
    }

    public IEnumerable<CategoriesDto> GetAll()
    {
      return _mapper.Map<IEnumerable<CategoriesDto>>(_categoryRepository.GetAll().ToList());
    }

    public CategoryNewDto Add(CategoryNewDto newCategory)
    {
      _categoryRepository.add(_mapper.Map<Category>(newCategory));
      return newCategory;
    }

    public void Update(CategoriesDto updateCategory)
    {
      _categoryRepository.Update(_mapper.Map<Category>(updateCategory));
    }

    public Boolean Delete(Guid id)
    {
      return _categoryRepository.Delete(id);
    }
  }
}