using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerFinancialService
{
    public class GetCustomerFinancialService : IGetCustomerFinancialService
    {
        private readonly IParaph_DbContext _db;
        public GetCustomerFinancialService(IParaph_DbContext db)
        {
            _db = db;
        }
        public async Task<CustomerFinancialResultDto> ByUserId(long userId)
        {
            var customer = await _db.Customers.FindAsync(userId);

            if (customer == null)
                throw new MyException(ErrorMessages.NotFoundCustomerException);

            return new CustomerFinancialResultDto()
            {
                CashBalance = customer.CashBalance,
                Score = customer.Score,
            };
        }
    }
}
