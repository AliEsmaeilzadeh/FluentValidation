using Paraph_Food.Application.Services.Users.Queries.GetCustomerFinancialService;
using Paraph_Food.Application.Services.Users.Queries.GetCustomerProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerInfoService
{
    public class CustomerInfoResultDto
    {
        public CustomerProfileResultDto Profile { get; set; }
        public CustomerFinancialResultDto Financial { get; set; }

    }
}
