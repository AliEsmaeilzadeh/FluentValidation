using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterCustomer
{
    public interface IRegisterCustomerService
    {
        Task<CommandResultDto> ExecuteAsync(string mobile, string vCode);
    }
}
