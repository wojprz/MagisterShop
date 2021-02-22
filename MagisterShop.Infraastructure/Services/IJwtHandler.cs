using MagisterShop.Infrastructure.DTOs;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto Create(Guid userId);
    }

}
