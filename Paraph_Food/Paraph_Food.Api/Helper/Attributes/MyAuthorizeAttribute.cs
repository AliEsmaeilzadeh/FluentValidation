using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Paraph_Food.Api.Models;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Linq;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Api.Helper.Attributes
{
    public class MyAuthorizeAttribute : IActionFilter
    {

        public string Roles { get; set; }

        private readonly IUsersFacad _usersFacad;

        public MyAuthorizeAttribute(IUsersFacad usersFacad) { _usersFacad = usersFacad; }

        public MyAuthorizeAttribute(string role) { Roles = role; }


        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                var userId = Convert.ToInt64(filterContext.HttpContext.User.Claims.FirstOrDefault().Value);
                var user = _usersFacad.GetUser.ByIdAsync(userId).Result;

                if (user == null)
                    filterContext.Result = new BadRequestObjectResult(new ErrorViewModel(ErrorMessages.NoUserException.Code, ErrorMessages.NoUserException.Message));
                else if(user.Status == UserStatus.Disabled)
                    filterContext.Result = new BadRequestObjectResult(new ErrorViewModel(ErrorMessages.UserIsDisabledException.Code, ErrorMessages.UserIsDisabledException.Message));
                else if (user.Status == UserStatus.Blocked)
                    filterContext.Result = new BadRequestObjectResult(new ErrorViewModel(ErrorMessages.UserIsBlockedException.Code, ErrorMessages.UserIsBlockedException.Message));
                else
                {
                    if (!string.IsNullOrEmpty(Roles))
                    {
                        string[] roles = Roles.Split(',');
                        var userRoles = _usersFacad.GetUserRoles.ExecuteAsync(user.UserName).Result;
                        foreach (var role in roles)
                        {
                            if (userRoles.Contains(role.Trim(' ')))
                                return;
                            else
                                filterContext.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                        }
                    }
                    else
                        return;
                }
            }
            else
                filterContext.Result = new UnauthorizedResult();
        }

        public void OnActionExecuted(ActionExecutedContext context){}
    }
}
