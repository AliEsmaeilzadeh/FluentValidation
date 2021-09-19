using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.ExistThisUser
{
    public interface IExistThisUserService
    {
        bool Execute(string userName);
        Task<bool> ExecuteAsync(string userName);
    }
}
