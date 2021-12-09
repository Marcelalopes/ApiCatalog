using System;
using api_catalogo.models;

namespace api_catalogo.Dtos
{
  public class ProductsDto
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid CategoryId { get; set; }
  }
}