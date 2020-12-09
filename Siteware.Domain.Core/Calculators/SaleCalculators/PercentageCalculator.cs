using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Core.Calculators.SaleCalculators
{
    public class PercentageCalculator : SaleCalculator
    {
        public override double GetPriceWithDiscount(double productPrice, int productQuantity, int saleQuantity, double saleValue)
        {
            var salePercentage = (1 - (saleValue / 100));
            var quantityWithoutSale = (productQuantity % saleQuantity);
            var quantityWithtSale = productQuantity - quantityWithoutSale;
            return (quantityWithoutSale * productPrice) + ((quantityWithtSale * productPrice) * salePercentage);
        }
    }
}
