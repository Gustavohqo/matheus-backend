using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Siteware.Application.Dtos;

namespace Siteware.Application.Interfaces
{
    public interface IProductCartAppService
    {
        ProductCartDto Create(ProductCartCreationDto productCreationDto);
        void Update(int id, ProductCartCreationDto productCreationDto);
        void Delete(int id);
    }
}
