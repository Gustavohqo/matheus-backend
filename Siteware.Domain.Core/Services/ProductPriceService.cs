using Siteware.Domain.Core.Factories;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siteware.Domain.Core.Services
{
    public class ProductPriceService : IProductPriceService
    {
        public double GetProductPrice(ProductCart productCart)
        {
            var saleCalculator = SaleCalculatorFactory.GetCalculator(productCart.Product.Sale);
            return saleCalculator.GetPriceWithDiscount(productCart.Product.Price, productCart.Quantity, 
                productCart.Product.Sale.Quantity, productCart.Product.Sale.Value);
        }
    }
}
