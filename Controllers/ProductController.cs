using Microsoft.AspNetCore.Mvc;
using api_catalogo.models;
using api_catalogo.service;

namespace api_catalogo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly ProductService _productService;
    public ProductController()
    {
      _productService = new ProductService();
    }

    [HttpGet]
    public string GetAllProduct()
    {
      return _productService.GetAll();
    }

    [HttpPost]
    public Product AddProduct([FromBody] Product p)
    {
      return _productService.Add(p);
    }

    [HttpPut("{id}")]
    public string UpdateProduct()
    {
      return _productService.Update();
    }

    [HttpDelete]
    public string DeleteProduct()
    {
      return _productService.Delete();
    }
  }
}