using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;

namespace Siteware.Application.Interfaces
{
    public interface ICategoryAppService
    {
        IEnumerable<CategoryDto> GetAll();
    }
}
