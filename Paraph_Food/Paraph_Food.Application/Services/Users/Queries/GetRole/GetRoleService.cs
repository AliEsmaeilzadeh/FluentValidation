using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetRole
{
    public class GetRoleService : IGetRoleService
    {
        private readonly IParaph_DbContext _db;
        public GetRoleService(IParaph_DbContext db)
        {
            _db = db;
        }


        public async Task<GetRoleResultDto> ByRoleName(string roleName)
        {
            var role = await _db.Roles.Where(obj => obj.Name.Equals(roleName)).FirstOrDefaultAsync();
            if (role == null)
                return null;

            return new GetRoleResultDto()
            {
                RoleId = role.Id,
                Name = role.Name,
            };
        }
    }
}
