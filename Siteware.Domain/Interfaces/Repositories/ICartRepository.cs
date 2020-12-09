using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Domain.Entities;

namespace Siteware.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Cart Get(int id);
    }
}
