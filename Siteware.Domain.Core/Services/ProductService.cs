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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Product product)
        {
            ValidateIntegrity(product);
            return _productRepository.Create(product);
        }
        public void Update(int id, Product product)
        {
            ValidateIntegrity(product);
            _productRepository.Update(id, product);
        }

        private void ValidateIntegrity(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException(string.Format(Message.CannotBeEmpty, Label.Name));
            }

            if (product.Price < 0)
            {
                throw new ArgumentException(string.Format(Message.MustBePositive, Label.Price));
            }
        }
    }
}
