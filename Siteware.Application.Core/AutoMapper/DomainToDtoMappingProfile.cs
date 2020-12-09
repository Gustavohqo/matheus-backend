using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;
using Siteware.Domain.Entities;
using System.Linq;

namespace Siteware.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Sale, SaleDto>();
            CreateMap<Product, SimpleProductDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<ProductCart, ProductCartDto>();
        }
    }
}
