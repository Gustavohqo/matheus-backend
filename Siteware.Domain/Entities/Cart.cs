using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Util.Translate;

namespace Siteware.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public List<ProductCart> ProductsCart { get; set; }
        public double Price { get; set; }
    }
}
