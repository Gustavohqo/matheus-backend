using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        public IEnumerable<ProductCartDto> ProductsCart { get; set; }
        public double Price { get; set; }
    }
}
