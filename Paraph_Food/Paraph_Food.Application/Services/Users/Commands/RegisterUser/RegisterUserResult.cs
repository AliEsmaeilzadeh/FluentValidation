using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserResult
    {
        public User User { get; set; }
        public bool IsSuccess { get; set; }
        public ErrorDto Exception { get; set; }

    }
}
