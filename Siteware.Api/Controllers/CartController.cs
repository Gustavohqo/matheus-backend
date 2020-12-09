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
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartAppService _cartAppService;

        public CartController(ICartAppService cartAppService)
        {
            _cartAppService = cartAppService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult<CartDto> Get(int id)
        {
            return _cartAppService.Get(id);
        }
    }
}
