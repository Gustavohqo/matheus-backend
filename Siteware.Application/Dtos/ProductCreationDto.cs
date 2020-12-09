using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class ProductCreationDto
    {

        [Required(ErrorMessage = "CategoryId is Required")]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }
        public int? SaleId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [DisplayName("Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image Source is Required")]
        [DisplayName("ImageSource")]
        public string ImageSource { get; set; }
    }
}
