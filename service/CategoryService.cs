using System;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using System.Collections.Generic;
using api_catalogo.Dtos;
using AutoMapper;
using System.Threading.Tasks;

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

    public async Task<IEnumerable<CategoriesDto>> GetAll()
    {
      var result = await _categoryRepository.GetAll();
      return _mapper.Map<IEnumerable<CategoriesDto>>(result);
    }

    public async Task<CategoryNewDto> Add(CategoryNewDto newCategory)
    {
      var result = await _categoryRepository.add(_mapper.Map<Category>(newCategory));
      return _mapper.Map<CategoryNewDto>(result);
    }

    public void Update(CategoriesDto updateCategory)
    {
      _categoryRepository.Update(_mapper.Map<Category>(updateCategory));
    }

    public Boolean Delete(Guid id)
    {
      return _categoryRepository.Delete(id);
    }

    public DetailsCategoryDto DetailsCategory(Guid id)
    {
      var result = _categoryRepository.DetailsCategory(id);
      return _mapper.Map<DetailsCategoryDto>(result);
    }
  }
}