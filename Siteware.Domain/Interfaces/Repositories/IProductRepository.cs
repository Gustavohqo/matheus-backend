using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Domain.Entities;

namespace Siteware.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(string searchTerm, string orderBy, string sortBy, int? offset, int? limit);
        Product Get(int id);
        Product Create(Product product);
        void Update(int id, Product product);
        void Delete(int id);
    }
}
