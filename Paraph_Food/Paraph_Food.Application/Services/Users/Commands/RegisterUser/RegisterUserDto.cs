using System;
using System.Collections.Generic;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
    }
}
