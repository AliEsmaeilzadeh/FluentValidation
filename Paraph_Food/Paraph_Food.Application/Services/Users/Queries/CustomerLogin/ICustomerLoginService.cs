using Paraph_Food.Application.Services.Users.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.CustomerLogin
{
    public interface ICustomerLoginService
    {
        Task<LoginResultDto> ExecuteAsync(string mobile, string vCode);
    }
}
