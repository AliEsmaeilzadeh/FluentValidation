using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Queries.VerifyUser
{
    public class VerifyUserResultDto
    {
        public bool IsVerify { get; set; }
        public User User { get; set; }
        public ErrorDto Exception { get; set; }

    }
}
