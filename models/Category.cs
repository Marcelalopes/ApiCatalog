using System;

namespace api_catalogo.models
{
  public class Category
  {
    public Category()
    {
      Id = new Guid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}