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
    [Route("api/sales")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleAppService _saleAppService;

        public SaleController(ISaleAppService saleAppService)
        {
            _saleAppService = saleAppService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<SaleDto>), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult Get()
        {
            return Ok(_saleAppService.GetAll());
        }
    }
}
