using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Siteware.Application.Dtos;
using Siteware.Application.Interfaces;
using Siteware.Domain.Interfaces.Repositories;

namespace Siteware.Application.Core.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(_categoryRepository.GetAll());
        }
    }
}
