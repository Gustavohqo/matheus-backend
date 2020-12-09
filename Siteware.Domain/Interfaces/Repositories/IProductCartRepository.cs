using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Domain.Entities;

namespace Siteware.Domain.Interfaces.Repositories
{
    public interface IProductCartRepository
    {
        ProductCart Create(ProductCart productCart);
        void Update(int id, ProductCart productCart);
        void Delete(int id);
    }
}
