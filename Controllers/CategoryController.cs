using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_catalogo.service;
using api_catalogo.models;
using System;
using api_catalogo.Context;
using System.Collections.Generic;
using api_catalogo.Dtos;

namespace api_catalogo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoriesDto>> GetAllCategory()
    {
      return new ObjectResult(_categoryService.GetAll().ToList());
    }

    [HttpPost]
    public ActionResult<CategoryNewDto> AddCategory([FromBody] CategoryNewDto category)
    {
      var result = _categoryService.Add(category);
      return new CreatedResult("", result);
    }

    [HttpPut("{id}:Guid")]
    public ActionResult UpdateCategory([FromBody] CategoriesDto category, Guid id)
    {
      if (id != category.Id)
        return new BadRequestResult();

      _categoryService.Update(category);
      return new OkObjectResult(category);
    }

    [HttpDelete("{id}:Guid")]
    public ActionResult DeleteCategory(Guid id)
    {
      var result = _categoryService.Delete(id);
      return result ? new OkResult() : new NotFoundResult();
    }
  }
}