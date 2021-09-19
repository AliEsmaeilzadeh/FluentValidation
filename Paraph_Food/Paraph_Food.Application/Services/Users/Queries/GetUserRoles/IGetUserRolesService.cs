using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetUserRoles
{
    public interface IGetUserRolesService
    {
        Task<string[]> ExecuteAsync(string userName);
    }
}
