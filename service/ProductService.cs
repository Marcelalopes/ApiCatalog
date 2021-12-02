using api_catalogo.models;

namespace api_catalogo.service
{
  public class ProductService
  {
    public string GetAll()
    {
      return "Todas os Produtos";
    }

    public Product Add(Product p)
    {
      return p;
    }

    public string Update()
    {
      return "Atualizar Produtos";
    }

    public string Delete()
    {
      return "Deletar Produtos";
    }
  }
}