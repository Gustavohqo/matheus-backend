using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;
using Siteware.Domain.Entities;
using System.Linq;

namespace Siteware.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProductCreationDto, Product>();
            CreateMap<ProductCartCreationDto, ProductCart>();
        }
    }
}
