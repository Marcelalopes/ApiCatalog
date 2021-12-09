using System;
using api_catalogo.models;
using System.Collections.Generic;
using System.Linq;
using api_catalogo.Dtos;
using api_catalogo.Repository.Interfaces;

namespace api_catalogo.service
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    public IEnumerable<ProductsDto> GetAll()
    {
      var result = _productRepository.GetAll().ToList();

      List<ProductsDto> listResult = new List<ProductsDto>();
      foreach (var product in result)
      {
        listResult.Add(new ProductsDto()
        {
          Id = product.Id,
          Nome = product.Name,
          Description = product.Description,
          Price = product.Price,
          Inventory = product.Inventory,
          RegistrationDate = product.RegistrationDate,
          CategoryId = product.CategoryId
        });
      }
      return listResult;
    }

    public ProductNewDto Add(ProductNewDto newProduct)
    {
      Product product = new Product()
      {
        Name = newProduct.Nome,
        Description = newProduct.Description,
        Price = newProduct.Price,
        Inventory = newProduct.Inventory,
        RegistrationDate = newProduct.RegistrationDate,
        CategoryId = newProduct.CategoryId
      };

      _productRepository.add(product);
      return newProduct;
    }

    public void Update(ProductsDto updateProduct)
    {
      Product product = new Product()
      {
        Id = updateProduct.Id,
        Name = updateProduct.Nome,
        Description = updateProduct.Description,
        Price = updateProduct.Price,
        Inventory = updateProduct.Inventory,
        RegistrationDate = updateProduct.RegistrationDate,
        CategoryId = updateProduct.CategoryId
      };

      _productRepository.Update(product);
    }

    public Boolean Delete(Guid id)
    {
      return _productRepository.Delete(id);
    }
  }
}