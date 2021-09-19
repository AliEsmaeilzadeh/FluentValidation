using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetUserRoles
{
    public class GetUserRolesService : IGetUserRolesService
    {
		private readonly IParaph_DbContext _db;
		public GetUserRolesService(IParaph_DbContext db)
		{
			_db = db;
		}

        public async Task<string[]> ExecuteAsync(string userName)
        {

			var usersRoles = await _db.UserRoles.Include(obj => obj.User)
												.Include(obj => obj.Role)
												.Where(obj => obj.User.UserName.Equals(userName))
												.Select(obj => obj.Role.Name)
												.ToArrayAsync();

			return usersRoles;
        }
    }
}
