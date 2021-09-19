using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.Admin.Models.ViewModels.Users.Authentication
{
    public class LoginResultVM
    {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string[] Roles { get; set; }

    }
}
