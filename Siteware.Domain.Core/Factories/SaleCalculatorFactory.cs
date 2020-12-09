using Siteware.Domain.Core.Calculators.SaleCalculators;
using Siteware.Domain.Entities;
using Siteware.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Core.Factories
{
    public static class SaleCalculatorFactory
    {
        public static SaleCalculator GetCalculator(Sale sale)
        {
            switch (sale.Type)
            {
                case SaleType.Absolute:
                    return new AbsoluteCalculator();
                case SaleType.Percentage:
                    return new PercentageCalculator();
                case SaleType.Fixed:
                default:
                    return new FixedCalculator();
            }
        }
    }
}
