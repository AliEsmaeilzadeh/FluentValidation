using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.VerifyUser
{
    public interface IVerifyUserService
    {
        Task<VerifyUserResultDto> ExecuteAsync(string userName, string password);
    }
}
