using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerProfile
{
    public interface IGetCustomerProfileService
    {
        Task<CustomerProfileResultDto> ByUserId(long userId);
    }
}
