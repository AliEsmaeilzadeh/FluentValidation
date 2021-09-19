using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.SetDefaultAddressService
{
    public interface ISetDefaultAddressService
    {
        Task<CommandResultDto> ExecuteAsync(long userId, int addressId);
    }
}
