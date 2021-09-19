using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Common
{
    public interface IGenerateTokenService
    {
        string Execute(long id, string[] roles);
    }
}
