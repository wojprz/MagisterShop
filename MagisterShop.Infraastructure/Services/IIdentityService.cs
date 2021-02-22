using MagisterShop.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagisterShop.Infrastructure.Services
{
    public interface IIdentityService
    {
        Task<JwtDto> Login(string username, string password);
        Task Register(string login, string email, string name, string surname, string password);
        Task<JwtDto> RefreshAccessToken(string refreshToken);
        Task RevokeRefreshToken(string refreshToken);
    }
}
