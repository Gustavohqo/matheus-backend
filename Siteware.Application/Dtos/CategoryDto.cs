using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Siteware.Application.Dtos
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
