using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Queries.VerifyCustomer
{
    public class VerifyCustomerResultDto
    {
        public bool IsVerify { get; set; }
        public ErrorDto Exception { get; set; }
    }
}
