using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Core.Calculators.SaleCalculators
{
    public class FixedCalculator : SaleCalculator
    {
        public override double GetPriceWithDiscount(double productPrice, int productQuantity, int saleQuantity, double saleValue)
        {
            var quantityWithoutSale = (productQuantity % saleQuantity);
            var multiplicationFactor = (productQuantity - quantityWithoutSale) / saleQuantity;
            return (quantityWithoutSale * productPrice) + multiplicationFactor * saleValue;
        }
    }
}
