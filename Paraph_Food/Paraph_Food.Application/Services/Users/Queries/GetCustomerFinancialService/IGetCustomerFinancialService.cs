using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerFinancialService
{
    public interface IGetCustomerFinancialService
    {
        Task<CustomerFinancialResultDto> ByUserId(long userId);
    }
}
