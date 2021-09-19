using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.RemoveVCode
{
    public interface IRemoveVCodeService
    {
        Task ExecuteAsync(int id);
    }
}
