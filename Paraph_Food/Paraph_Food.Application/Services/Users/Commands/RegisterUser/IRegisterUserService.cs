using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        Task<RegisterUserResult> ExecuteAsync(RegisterUserDto user);
        RegisterUserResult Execute(RegisterUserDto user);
    }
}
