using System.Linq;
using Microsoft.AspNetCore.Mvc;
using api_catalogo.models;
using api_catalogo.service;
using System;
using api_catalogo.Context;
using System.Collections.Generic;
using api_catalogo.Dtos;

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
    public ActionResult<IEnumerable<ProductsDto>> GetAllProduct()
    {
      return new ObjectResult(_productService.GetAll().ToList());
    }

    [HttpPost]
    public ActionResult<ProductNewDto> AddProduct([FromBody] ProductNewDto p)
    {
      var result = _productService.Add(p);
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