using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Infraastructure.Mappers
{
    public interface IAutoMapperConfig
    {
        IMapper Mapper { get; }
    }
}
