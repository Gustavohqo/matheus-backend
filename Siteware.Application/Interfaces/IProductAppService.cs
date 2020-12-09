using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Siteware.Application.Dtos;

namespace Siteware.Application.Interfaces
{
    public interface IProductAppService
    {
        IEnumerable<SimpleProductDto> GetAll(string searchTerm, string orderBy, string sortBy, int? offset, int? limit);
        ProductDto Get(int id);
        SimpleProductDto Create(ProductCreationDto productCreationDto);
        void Update(int id, ProductCreationDto productCreationDto);
        void Delete(int id);
    }
}
