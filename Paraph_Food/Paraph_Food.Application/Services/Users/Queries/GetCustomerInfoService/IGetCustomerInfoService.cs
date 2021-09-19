using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerInfoService
{
    public interface IGetCustomerInfoService
    {
        Task<CustomerInfoResultDto> ByUserId(long userId);
    }
}
