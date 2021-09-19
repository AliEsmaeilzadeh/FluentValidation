using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Areas.Admin.Models.ViewModels.Users.Authentication;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Users.Commands.RegisterUser;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Application.Services.Users.Queries.UserLoginService;
using System;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : BaseController
    {
        private readonly IUsersFacad _userServices;
        public AuthenticationController(IUsersFacad usersFacad)
        {
            _userServices = usersFacad;
        }



        [HttpPost("Admin/Authentication/CreateAdminUser")]
        public async Task<IActionResult> CreateAdminUser()
        {
            try
            {
                var admin = new RegisterUserDto()
                {
                    UserName = "Admin@Paraph.com",
                    Password = "Admin@123",
                    Status = Domain.Enums.Enums.UserStatus.Confirmed,
                };
                var result = await _userServices.RegisterUser.ExecuteAsync(admin);
                if (result.IsSuccess)
                {
                    var addRoleResult = await _userServices.AddUserInRole.ExecuteAsync(result.User, "Admin");
                    if (addRoleResult.IsSuccess)
                        return Ok(result.User.Id);
                    else
                        throw new MyException(result.Exception);
                }
                else
                    throw new MyException(result.Exception);
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }


        [HttpPost("Admin/Authentication/Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                var result = await _userServices.UserLogin.ExecuteAsync(new UserLoginDto()
                {
                    UserName = model.UserName,
                    Password = model.Password,
                });

                if (!result.IsSuccess)
                    throw new MyException(result.Exception);

                return Ok(new LoginResultVM()
                {
                    UserId = result.UserId.Value,
                    Token = result.Token,
                    Roles = result.Roles,
                });
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

    }
}