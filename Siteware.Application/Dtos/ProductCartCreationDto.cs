using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class ProductCartCreationDto
    {

        [Required(ErrorMessage = "CartId is Required")]
        [DisplayName("CartId")]
        public int CartId { get; set; }

        [Required(ErrorMessage = "ProductId is Required")]
        [DisplayName("ProductId")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
    }
}
