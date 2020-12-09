using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Util.Translate;

namespace Siteware.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SaleId { get; set; }
        public Sale Sale { get; set; }
        public string ImageSource { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
