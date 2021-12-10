using System;
using System.Collections.Generic;

namespace api_catalogo.Dtos
{
  public class DetailsCategoryDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<ProductsDto> Products { get; set; }
  }
}