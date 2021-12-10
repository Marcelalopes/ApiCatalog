using System;

namespace api_catalogo.Dtos
{
  public class ProductNewDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid CategoryId { get; set; }
  }
}