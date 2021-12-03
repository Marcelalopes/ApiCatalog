using System.Collections.Generic;
using System;

namespace api_catalogo.models
{
  public class Category
  {
    public Category()
    {
      Id = new Guid();
      Products = new List<Product>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
  }
}