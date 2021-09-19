using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetRole
{
    public interface IGetRoleService
    {
        Task<GetRoleResultDto> ByRoleName(string roleName);
    }
}
