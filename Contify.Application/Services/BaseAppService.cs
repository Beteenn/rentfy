﻿using AutoMapper;

namespace Contify.Application.Services
{
    public class BaseAppService
    {
        private readonly IMapper _mapper;
        public BaseAppService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IMapper Mapper => _mapper;
    }
}
