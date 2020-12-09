using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Domain.Interfaces.Services;
using Siteware.Util.Translate;

namespace Siteware.Domain.Core.Services
{
    public class ProductCartService : IProductCartService
    {
        private readonly IProductCartRepository _productCartRepository;

        public ProductCartService(IProductCartRepository productCartRepository)
        {
            _productCartRepository = productCartRepository;
        }

        public ProductCart Create(ProductCart productCart)
        {
            ValidateIntegrity(productCart);
            return _productCartRepository.Create(productCart);
        }
        
        public void Update(int id, ProductCart productCart)
        {
            ValidateIntegrity(productCart);
            _productCartRepository.Update(id, productCart);
        }

        public void Delete(int id){
            _productCartRepository.Delete(id);
        }

        private void ValidateIntegrity(ProductCart productCart)
        {
            if (productCart.Quantity <= 0)
            {
                throw new ArgumentException(string.Format(Message.MustBePositive, Label.Quantity));
            }
        }
    }
}
