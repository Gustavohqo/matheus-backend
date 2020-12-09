using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Entities
{
    public class ProductCart
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
        public double FinalPrice { get; set; }
        public bool AppliedSale { get; set; }
    }
}
