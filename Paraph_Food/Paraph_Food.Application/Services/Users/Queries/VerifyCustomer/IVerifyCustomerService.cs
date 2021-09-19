using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.VerifyCustomer
{
    public interface IVerifyCustomerService
    {
        Task<VerifyCustomerResultDto> ExecuteAsync(string mobile, string vCode);
    }
}
