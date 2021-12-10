using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_catalogo.service;
using System;
using System.Collections.Generic;
using api_catalogo.Dtos;
using System.Threading.Tasks;

namespace api_catalogo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductsDto>>> GetAllProduct()
    {
      var result = await _productService.GetAll();
      return new ObjectResult(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] ProductNewDto p)
    {
      var result = await _productService.Add(p);
      return new CreatedResult("", result);
    }

    [HttpPut("{id}:Guid")]
    public ActionResult UpdateProduct([FromBody] ProductsDto p, Guid id)
    {
      if (id != p.Id)
        return new BadRequestResult();
      _productService.Update(p);
      return new OkObjectResult(p);
    }

    [HttpDelete("{id}:Guid")]
    public ActionResult DeleteProduct(Guid id)
    {
      var result = _productService.Delete(id);
      return result ? new OkResult() : new NotFoundResult();
    }
  }
}