using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Core.Calculators.SaleCalculators
{
    public abstract class SaleCalculator
    {
        public abstract double GetPriceWithDiscount(double productPrice, int productQuantity, int saleQuantity, double saleValue);
    }
}
