using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Helper.Attributes
{
    public class MyAuthorizeFactory : Attribute, IFilterFactory
    {
        public string Roles = "";
        public bool IsReusable => false;


        public MyAuthorizeFactory(){}
        public MyAuthorizeFactory(string roles)
        {
            Roles = roles;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService<MyAuthorizeAttribute>();
            if (!string.IsNullOrWhiteSpace(Roles))
                service.Roles = Roles;
            
            return service;
        }
    }
}
