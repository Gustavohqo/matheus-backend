using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Domain.Entities;

namespace Siteware.Domain.Interfaces.Services
{
    public interface ICartService
    {
        Cart Get(int id);
    }
}
