using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.VerifyUser

{
	public class VerifyUserService : IVerifyUserService
    {
		private readonly IUsersFacad _usersFacad;
		private readonly IParaph_DbContext _db;
		public VerifyUserService(IParaph_DbContext db, IUsersFacad usersFacad)
		{
			_db = db;
			_usersFacad = usersFacad;
		}


		/// <summary>
		/// اعتبارسنجی نام کاربری و کلمه عبور کاربران
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
        public async Task<VerifyUserResultDto> ExecuteAsync(string userName, string password)
        {
			try
			{

				// بررسی درستی نام کاربری
				var user = await _db.Users.Where(obj => obj.UserName.Equals(userName)).FirstOrDefaultAsync();
				if(user == null)
					return new VerifyUserResultDto()
					{
						IsVerify = false,
						Exception = ErrorMessages.IncurectUserNameException
					};

				// بررسی درستی کلمه عبور
				var passwordHasher = new PasswordHasher();
				var verify = passwordHasher.VerifyPassword(user.Password, password);
				if (!verify)
					return new VerifyUserResultDto()
					{
						IsVerify = false,
						Exception = ErrorMessages.IncurectPasswordException
					};

				return new VerifyUserResultDto()
				{
					User = user,
					IsVerify = true,
				};

			}
			catch (MyException ex)
			{
				return new VerifyUserResultDto()
				{
					IsVerify = false,
					Exception = new ErrorDto(ex.Code, ex.Message),
				};
			}
        }
    }
}
