using Paraph_Food.Application.Services.Common;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Users.Common;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Queries.CustomerLogin
{
    public class CustomerLoginService : ICustomerLoginService
    {
		private readonly IUsersFacad _usersFacad;
		public CustomerLoginService(IUsersFacad usersFacad)
		{
			_usersFacad = usersFacad;
		}


        public async Task<LoginResultDto> ExecuteAsync(string mobile, string vCode)
        {
			try
			{
				// اعتبارسنجی کاربری
				var result = await _usersFacad.VerifyCustomer.ExecuteAsync(mobile, vCode);
				if (!result.IsVerify)
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = result.Exception,
					};

				// گرفتن کاربر
				var user = await _usersFacad.GetUser.ByUserNameAsync(mobile);
				if(user == null)
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = ErrorMessages.IncurrectCustomerMobileException,
					};

				if (user.Status == UserStatus.Disabled)
				{
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = ErrorMessages.UserIsDisabledException,
					};
				}
				if (user.Status == UserStatus.Blocked)
				{
					return new LoginResultDto()
					{
						IsSuccess = false,
						Exception = ErrorMessages.UserIsBlockedException,
					};
				}

				// گرفتن نقش های کاربر
				var userRoles = await _usersFacad.GetUserRoles.ExecuteAsync(mobile);

				// تولید توکن
				var token = _usersFacad.GenerateToken.Execute(user.Id, userRoles);

				return new LoginResultDto()
				{
					IsSuccess = true,
					UserId = user.Id,
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
