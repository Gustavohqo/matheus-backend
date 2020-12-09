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
    public class ProductCartAppService : IProductCartAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductCartRepository _productCartRepository;
        private readonly IProductCartService _productCartService;

        public ProductCartAppService(IMapper mapper, IProductCartRepository productCartRepository, IProductCartService productCartService)
        {
            _mapper = mapper;
            _productCartRepository = productCartRepository;
            _productCartService = productCartService;
        }

        public ProductCartDto Create(ProductCartCreationDto productCartCreationDto)
        {
            var productCartEntity = _mapper.Map<ProductCart>(productCartCreationDto);
            return _mapper.Map<ProductCartDto>(_productCartService.Create(productCartEntity));
        }

        public void Update(int id, ProductCartCreationDto productCartCreationDto)
        {
            var productCartEntity = _mapper.Map<ProductCart>(productCartCreationDto);
            _productCartService.Update(id, productCartEntity);
        }

        public void Delete(int id)
        {
            _productCartRepository.Delete(id);
        }
    }
}
