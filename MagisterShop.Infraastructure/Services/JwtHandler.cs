
using MagisterShop.Infrastructure.DTOs;
using MagisterShop.Infrastructure.Extensions;
using MagisterShop.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagisterShop.Infrastructure.Services
{

    public class JwtHandler : IJwtHandler
    {
        private readonly JwtOptions _settings;

        public JwtHandler(JwtOptions settings)
        {
            _settings = settings;
        }

        public JwtDto Create(Guid userId)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_settings.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                UserId = userId,
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }


}
