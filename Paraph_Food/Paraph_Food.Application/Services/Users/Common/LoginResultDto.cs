using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Common
{
    public class LoginResultDto
    {
        public bool IsSuccess { get; set; }
        public long? UserId { get; set; }
        public string Token { get; set; }
        public string[] Roles { get; set; }
        public ErrorDto Exception { get; set; }
    }
}
