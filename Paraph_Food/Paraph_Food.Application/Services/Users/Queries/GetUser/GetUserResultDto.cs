using System;
using System.Collections.Generic;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Queries.GetUser
{
    public class GetUserResultDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public UserStatus Status { get; set; }
    }
}
