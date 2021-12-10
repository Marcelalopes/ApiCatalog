using System;
using api_catalogo.models;
using api_catalogo.Repository.Interfaces;
using System.Collections.Generic;
using api_catalogo.Dtos;
using AutoMapper;
using System.Threading.Tasks;

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
    public async Task<IEnumerable<ProductsDto>> GetAll()
    {
      var result = await _productRepository.GetAll();
      return _mapper.Map<IEnumerable<ProductsDto>>(result);
    }

    public async Task<ProductNewDto> Add(ProductNewDto newProduct)
    {
      var result = await _productRepository.add(_mapper.Map<Product>(newProduct));
      return _mapper.Map<ProductNewDto>(result);
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