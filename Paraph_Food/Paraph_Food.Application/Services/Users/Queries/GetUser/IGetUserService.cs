using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetUser
{
    public interface IGetUserService
    {
        Task<GetUserResultDto> ByUserNameAsync(string userName);
        Task<GetUserResultDto> ByIdAsync(long id);
    }
}
