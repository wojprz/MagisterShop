using AutoMapper;
using MagisterShop.Domain.Entities;
using MagisterShop.Infraastructure.DTOs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Infraastructure
{
    public class AutoMapperConfig : IAutomaperConfig
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
