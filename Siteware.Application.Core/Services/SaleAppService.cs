using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;
using Siteware.Application.Interfaces;
using Siteware.Domain.Interfaces.Repositories;

namespace Siteware.Application.Core.Services
{
    public class SaleAppService : ISaleAppService
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;

        public SaleAppService(IMapper mapper, ISaleRepository saleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public IEnumerable<SaleDto> GetAll()
        {
            return _mapper.Map<IEnumerable<SaleDto>>(_saleRepository.GetAll());
        }
    }
}
