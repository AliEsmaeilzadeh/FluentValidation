using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerFinancialService
{
    public class CustomerFinancialResultDto
    {
        public long CashBalance { get; set; }
        public int Score { get; set; }
    }
}
