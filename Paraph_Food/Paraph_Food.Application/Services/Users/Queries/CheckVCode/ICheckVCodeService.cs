using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.CheckVCode
{
    public interface ICheckVCodeService
    {
        Task<CheckVCodeResultDto> ExecuteAsync(string mobile, string vCode);
    }
}
