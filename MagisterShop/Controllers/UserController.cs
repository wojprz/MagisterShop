using MagisterShop.Infraastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagisterShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IUserService _userService;

        [HttpPut("passwordChange")]
        public async Task ChangePassword(string login, string newPassword, string oldPassword)
        {
            await _userService.ChangePassword(login, newPassword, oldPassword);
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("emailChange")]
        public async Task ChangeEmail(string login, string email)
        {
            await _userService.ChangeEmail(login, email);
        }
    }
}
