using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Domain.Interfaces.Services;
using Siteware.Util.Translate;

namespace Siteware.Domain.Core.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductPriceService _productPriceService;
        private readonly IProductCartService _productCartService;

        public CartService(ICartRepository cartRepository, IProductPriceService productPriceService, 
            IProductCartService productCartService)
        {
            _cartRepository = cartRepository;
            _productPriceService = productPriceService;
            _productCartService = productCartService;
        }

        public Cart Get(int id)
        {
            var cart = _cartRepository.Get(id);
            cart.ProductsCart.ToList().ForEach((productCart) => {
                productCart.FinalPrice = _productPriceService.GetProductPrice(productCart);
                productCart.AppliedSale = productCart.Quantity * productCart.Product.Price != productCart.FinalPrice;
                cart.Price += productCart.FinalPrice;
            });
            return cart;
        }
    }
}
