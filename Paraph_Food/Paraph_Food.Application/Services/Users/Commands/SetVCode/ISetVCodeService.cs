using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.SetVCode
{
    public interface ISetVCodeService
    {
        Task<string> ExecuteAsync(string userName, double? duration = null);
    }
}
