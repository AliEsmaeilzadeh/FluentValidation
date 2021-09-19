using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.VerifyCustomer
{
    public class VerifyCustomerService : IVerifyCustomerService
    {
		private readonly IUsersFacad _usersFacad;
		public VerifyCustomerService(IUsersFacad usersFacad)
		{
			_usersFacad = usersFacad;
		}


		/// <summary>
		/// اعتبارسنجی نام کاربری مشتری که بدون کلمه عبور هستش
		/// </summary>
		/// <param name="mobile"> شماره موبایل مشتری </param>
		/// <returns></returns>
		public async Task<VerifyCustomerResultDto> ExecuteAsync(string mobile, string vCode)
        {
			try
			{
				// بررسی درستی نام کاربری
				var existThisUser = await _usersFacad.ExistThisUser.ExecuteAsync(mobile);
				if (!existThisUser)
					return new VerifyCustomerResultDto()
					{
						IsVerify = false,
						Exception = ErrorMessages.IncurrectCustomerMobileException,
					};

				// بررسی کد احراز هویت
				var codeVerify = await _usersFacad.CheckVCode.ExecuteAsync(mobile, vCode);
				if (codeVerify.IsValid)
					return new VerifyCustomerResultDto()
					{
						IsVerify = true,
						Exception = null
					};

				return new VerifyCustomerResultDto
				{
					IsVerify = codeVerify.IsValid,
					Exception = codeVerify.Exception,
				};
			}
			catch (Exception ex)
			{
				return new VerifyCustomerResultDto()
				{
					IsVerify = false,
					Exception = new ErrorDto(ex)
				};
			}
        }
    }
}
