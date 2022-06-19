﻿using AutoMapper;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.SeedWork;

namespace Rentfy.Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap(typeof(DomainResult<>), typeof(Result<>));

            CreateMap<DomainResult, Result>()
                .ReverseMap();

            CreateMap<ObjetoTeste, ObjetoTesteViewModel>()
                .ReverseMap();

            CreateMap<User, UserViewModel>()
                .ReverseMap();
        }

    }
}