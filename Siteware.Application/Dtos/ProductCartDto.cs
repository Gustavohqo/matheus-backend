using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class ProductCartDto
    {
        public int Id { get; set; }
        public double FinalPrice { get; set; }
        public int Quantity { get; set; }
        public bool AppliedSale { get; set; }
        public ProductDto Product { get; set; }
    }
}
