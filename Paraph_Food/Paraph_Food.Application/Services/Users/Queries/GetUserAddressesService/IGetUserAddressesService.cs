using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetUserAddressesService
{
    public interface IGetUserAddressesService
    {
        Task<List<GetUserAddressesResultDto>> ByUserIdAsync(long userId);
    }
}
