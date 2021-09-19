using Paraph_Food.Application.Services.Users.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.UserLoginService
{
    public interface IUserLoginService
    {
        Task<LoginResultDto> ExecuteAsync(UserLoginDto model);
    }
}
