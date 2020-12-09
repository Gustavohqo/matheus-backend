using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Domain.Entities;

namespace Siteware.Domain.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
    }
}
