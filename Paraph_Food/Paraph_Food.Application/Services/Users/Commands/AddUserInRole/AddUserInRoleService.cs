using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.AddUserInRole
{
    public class AddUserInRoleService : IAddUserInRoleService
    {
        private readonly IParaph_DbContext _db;
        private readonly IUsersFacad _usersFacad;
        public AddUserInRoleService(IParaph_DbContext db, IUsersFacad usersFacad)
        {
            _db = db;
            _usersFacad = usersFacad;
        }

        public async Task<CommandResultDto> ExecuteAsync(User user, string roleName)
        {
            var role = await _usersFacad.GetRole.ByRoleName(roleName);
            if (role == null)
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = ErrorMessages.NoRoleException
                };

            await _db.UserRoles.AddAsync(new UserRole()
            {
                UserId = user.Id,
                RoleId = role.RoleId,
                Deleted = false,
            });
            await _db.SaveChangesAsync();

            return new CommandResultDto()
            {
                IsSuccess = true,
            };
        }
    }
}
