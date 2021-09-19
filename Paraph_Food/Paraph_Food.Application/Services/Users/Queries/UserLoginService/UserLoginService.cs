using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Users.Common;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Queries.UserLoginService
{
    public class UserLoginService : IUserLoginService
    {
		private readonly IUsersFacad _usersFacad;
		public UserLoginService(IUsersFacad usersFacad)
		{
			_usersFacad = usersFacad;
		}


		public async Task<LoginResultDto> ExecuteAsync(UserLoginDto model)
        {
			try
			{
				// بررسی درستی کلمه عبور
				var result = await _usersFacad.VerifyUser.ExecuteAsync(model.UserName, model.Password);
				if (!result.IsVerify)
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = result.Exception
					};


				if (result.User.UserStatus == UserStatus.Disabled)
				{
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = ErrorMessages.UserIsDisabledException,
					};
				}
				if (result.User.UserStatus == UserStatus.Blocked)
				{
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = ErrorMessages.UserIsBlockedException,
					};
				}

				// گرفتن نقش های کاربر
				var userRoles = await _usersFacad.GetUserRoles.ExecuteAsync(model.UserName);

				// تولید توکن
				var token = _usersFacad.GenerateToken.Execute(result.User.Id, userRoles);

				return new LoginResultDto()
				{
					IsSuccess = true,
					UserId = result.User.Id,
					Roles = userRoles,
					Token = token,
				};
			}
			catch (MyException ex)
			{
				return new LoginResultDto()
				{
					IsSuccess = false,
					Exception = new ErrorDto(ex.Code, ex.Message)
				};
			}
		}
	}
}
