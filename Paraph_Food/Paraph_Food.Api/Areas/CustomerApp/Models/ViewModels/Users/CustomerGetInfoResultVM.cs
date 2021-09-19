using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.CustomerApp.Models.ViewModels.Users
{
    public class CustomerGetInfoResultVM
    {
        public CustomerProfileDetailVM ProfileDetail { get; set; }
        public CustomerFinancialVM Financial { get; set; }

    }
}
