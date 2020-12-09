using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siteware.Api.Filters;
using Siteware.Application.Dtos;
using Siteware.Application.Interfaces;

namespace Siteware.Api.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult Get()
        {
            return Ok(_categoryAppService.GetAll());
        }
    }
}
