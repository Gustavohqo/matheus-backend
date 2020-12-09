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
    [Route("api/productsCart")]
    [ApiController]
    public class ProductCartController : ControllerBase
    {
        private readonly IProductCartAppService _productCartAppService;

        public ProductCartController(IProductCartAppService productCartAppService)
        {
            _productCartAppService = productCartAppService;
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(ProductCartDto), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult<ProductCartDto> Create([FromBody] ProductCartCreationDto productCartCreationDto)
        {
            return _productCartAppService.Create(productCartCreationDto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult Update(int id, [FromBody] ProductCartCreationDto productCartCreationDto)
        {
            _productCartAppService.Update(id, productCartCreationDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult Delete(int id)
        {
            _productCartAppService.Delete(id);
            return NoContent();
        }
    }
}
