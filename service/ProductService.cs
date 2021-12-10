using System;
using api_catalogo.models;
using System.Collections.Generic;
using System.Linq;
using api_catalogo.Dtos;
using api_catalogo.Repository.Interfaces;
using AutoMapper;

namespace api_catalogo.service
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
      _productRepository = productRepository;
      _mapper = mapper;
    }
    public IEnumerable<ProductsDto> GetAll()
    {
      return _mapper.Map<IEnumerable<ProductsDto>>(_productRepository.GetAll().ToList());
    }

    public ProductNewDto Add(ProductNewDto newProduct)
    {
      _productRepository.add(_mapper.Map<Product>(newProduct));
      return newProduct;
    }

    public void Update(ProductsDto updateProduct)
    {
      _productRepository.Update(_mapper.Map<Product>(updateProduct));
    }

    public Boolean Delete(Guid id)
    {
      return _productRepository.Delete(id);
    }
  }
}