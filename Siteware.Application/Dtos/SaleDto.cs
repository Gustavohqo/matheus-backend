using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class SaleDto
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
