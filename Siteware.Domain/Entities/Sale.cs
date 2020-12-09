using Siteware.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SaleType Type { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }
    }
}
