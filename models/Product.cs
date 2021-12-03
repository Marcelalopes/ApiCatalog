using System;

namespace api_catalogo.models
{
  public class Product
  {
    public Product()
    {
      Id = new Guid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Category Category { get; set; }
  }
}