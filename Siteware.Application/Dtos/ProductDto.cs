using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class ProductDto : SimpleProductDto
    {
        public SaleDto Sale { get; set; }
    }
}
