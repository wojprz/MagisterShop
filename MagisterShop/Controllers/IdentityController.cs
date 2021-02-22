using MagisterShop.Infraastructure.Models;
using MagisterShop.Infrastructure.DTOs;
using MagisterShop.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagisterShop.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class IdentityController
    {
        private readonly IIdentityService _identityService;
        private readonly ICancellationTokenService _cancellationService;

        public IdentityController(IIdentityService identityService, ICancellationTokenService cancellationTokenService)
        {
            _identityService = identityService;
            _cancellationService = cancellationTokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<JwtDto> Login([FromBody] LoginModel login)
        {
            return await _identityService.Login(login.Login, login.Password);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<JwtDto> RefreshToken(string token)
        {
            return await _identityService.RefreshAccessToken(token);
        }

        [HttpPost("revoke")]
        public async Task RevokeToken(string token)
        {
            await _identityService.RevokeRefreshToken(token);
        }

        [HttpPost("cancel")]
        public async Task CancelToken()
        {
            await _cancellationService.DeactivateCurrentAsync();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task Register([FromBody] RegisterModel register)
        {
            await _identityService.Register(register.Login, register.Email, register.Name, register.Surname, register.Password);
        }
    }
}
