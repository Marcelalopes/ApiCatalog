using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_catalogo.service;
using api_catalogo.Dtos;
using System.Threading.Tasks;

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
    public async Task<ActionResult<IEnumerable<CategoriesDto>>> GetAllCategory()
    {
      var result = await _categoryService.GetAll();
      return new ObjectResult(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddCategory([FromBody] CategoryNewDto category)
    {
      var result = await _categoryService.Add(category);
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

    [HttpGet("detailsCategory/{id}:Guid")]
    public ActionResult<DetailsCategoryDto> DetailsCategory(Guid id)
    {
      return new OkObjectResult(_categoryService.DetailsCategory(id));
    }
  }
}