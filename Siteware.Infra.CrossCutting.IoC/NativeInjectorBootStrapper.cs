using Microsoft.Extensions.DependencyInjection;
using System;
using Siteware.Application.Core.Services;
using Siteware.Application.Interfaces;
using Siteware.Domain.Core.Services;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Domain.Interfaces.Services;
using Siteware.Infra.Data.Repositories;

namespace Siteware.Infra.Data
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterAppServices(services);
            RegisterDomainServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<ISaleAppService, SaleAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductCartAppService, ProductCartAppService>();
            services.AddScoped<ICartAppService, CartAppService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductCartService, ProductCartService>();
            services.AddScoped<IProductPriceService, ProductPriceService>();
            services.AddScoped<IProductService, ProductService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductCartRepository, ProductCartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
