﻿using AutoMapper;

namespace Imea.Application.Mapper
{
    public class AutoMapperConfig
    {
            public static void RegisterMapping()
            {
                AutoMapper.Mapper.Initialize(x =>
                {
                    x.AddProfile<ViewModelToDomainMappingProfile>();
                    x.AddProfile<DomainToViewModelMappingProfile>();
                });
            }
    }
}