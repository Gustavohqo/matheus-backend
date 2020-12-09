using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;
using Siteware.Application.Interfaces;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Domain.Interfaces.Services;

namespace Siteware.Application.Core.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductAppService(IMapper mapper, IProductRepository productRepository, IProductService productService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
        }

        public IEnumerable<SimpleProductDto> GetAll(string searchTerm, string orderBy, string sortBy, int? offset, int? limit) {
            return _mapper.Map<IEnumerable<SimpleProductDto>>(_productRepository.GetAll(searchTerm, orderBy, sortBy, offset, limit));
        }
        public ProductDto Get(int id)
        {
            return _mapper.Map<ProductDto>(_productRepository.Get(id));
        }
        public SimpleProductDto Create(ProductCreationDto productCreationDto)
        {
            var productEntity = _mapper.Map<Product>(productCreationDto);
            return _mapper.Map<SimpleProductDto>(_productService.Create(productEntity));
        }
        public void Update(int id, ProductCreationDto productCreationDto)
        {
            var productEntity = _mapper.Map<Product>(productCreationDto);
            _productService.Update(id, productEntity);
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
