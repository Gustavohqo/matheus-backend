using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Interfaces.Services
{
    public interface IProductPriceService
    {
        double GetProductPrice(ProductCart productCart);
    }
}
