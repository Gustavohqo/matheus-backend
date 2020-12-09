using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siteware.Application.AutoMapper;

namespace Siteware.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile), typeof(DtoToDomainMappingProfile));
        }
    }
}
