using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetCurrentUserId
{
    public interface IGetCurrentUserIdService
    {
        long? Execute();
    }
}
