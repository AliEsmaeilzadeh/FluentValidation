using Paraph_Food.Application.Common;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.AddUserInRole
{
    public interface IAddUserInRoleService
    {
        Task<CommandResultDto> ExecuteAsync(User user, string roleName);
    }
}
