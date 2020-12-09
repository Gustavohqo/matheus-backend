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
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult<IEnumerable<SimpleProductDto>> GetAll([FromQuery] string searchTerm, [FromQuery] string orderBy, [FromQuery] string sortBy, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            return _productAppService.GetAll(searchTerm, orderBy, sortBy, offset, limit).ToList();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult<ProductDto> Get(int id)
        {
            return _productAppService.Get(id);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(SimpleProductDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult<SimpleProductDto> Create([FromBody] ProductCreationDto productCreationDto)
        {
            return _productAppService.Create(productCreationDto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult Update(int id, [FromBody] ProductCreationDto productCreationDto)
        {
            _productAppService.Update(id, productCreationDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult Delete(int id)
        {
            _productAppService.Delete(id);
            return NoContent();
        }
    }
}
