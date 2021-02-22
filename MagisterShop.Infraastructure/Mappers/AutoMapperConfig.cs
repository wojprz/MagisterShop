using AutoMapper;
using MagisterShop.Domain.Entities;
using MagisterShop.Infraastructure.DTOs;
using MagisterShop.Infraastructure.Mappers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Infraastructure
{
    public class AutoMapperConfig : IAutoMapperConfig
    {
        private readonly IOptions<HostOptions> _settings;

        public AutoMapperConfig(IOptions<HostOptions> settings)
        {
            _settings = settings;
        }

        public IMapper Mapper
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<Rating, RatingDTO>();
                cfg.CreateMap<User, UserDTO>();
            }).CreateMapper();
    }
}
