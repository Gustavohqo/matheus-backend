using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;
using Siteware.Application.Interfaces;
using Siteware.Domain.Entities;
using Siteware.Domain.Interfaces.Repositories;
using Siteware.Domain.Interfaces.Services;

namespace Siteware.Application.Core.Services
{
    public class CartAppService : ICartAppService
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public CartAppService(IMapper mapper, ICartService cartService)
        {
            _mapper = mapper;
            _cartService = cartService;
        }
        public CartDto Get(int id)
        {
            return _mapper.Map<CartDto>(_cartService.Get(id));
        }
    }
}
