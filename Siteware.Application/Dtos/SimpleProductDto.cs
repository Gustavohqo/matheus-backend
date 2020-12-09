using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class SimpleProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageSource { get; set; }
        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
    }
}
