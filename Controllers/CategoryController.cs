using Microsoft.AspNetCore.Mvc;
using api_catalogo.service;
using api_catalogo.models;

namespace api_catalogo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CategoryController : ControllerBase
  {
    private readonly CategoryService _categoryService;

    public CategoryController()
    {
      _categoryService = new CategoryService();
    }

    [HttpGet]
    public string GetAllCategory()
    {
      return _categoryService.GetAll();
    }

    [HttpPost]
    public Category AddCategory([FromBody] Category category)
    {
      return _categoryService.Add(category);
    }

    [HttpPut("/{id}")]
    public string UpdateCategory()
    {
      return _categoryService.Update();
    }

    [HttpDelete]
    public string DeleteCategory()
    {
      return _categoryService.Delete();
    }
  }
}