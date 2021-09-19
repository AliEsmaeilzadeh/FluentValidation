using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.CheckVCode
{
    public class CheckVCodeService : ICheckVCodeService
    {
        private readonly IParaph_DbContext _db;
        private readonly IUsersFacad _userFacad;
        public CheckVCodeService(IParaph_DbContext db, IUsersFacad usersFacad)
        {
            _db = db;
            _userFacad = usersFacad;
        }

        /// <summary>
        /// اعتبارسنجی کد وارد شده
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="vCode"></param>
        /// <returns></returns>
        public async Task<CheckVCodeResultDto> ExecuteAsync(string mobile, string vCode)
        {
            try
            {
                var verificationCode = await _db.VerificationCodes.Where(obj => obj.UserName.Equals(mobile)
                                                                             && obj.Code.Equals(vCode)
                                                                             && obj.ExpirationDateTime >= DateTime.Now)
                                                                  .FirstOrDefaultAsync();
                if (verificationCode == null)
                    return new CheckVCodeResultDto()
                    {
                        IsValid = false,
                        Exception = ErrorMessages.InValidVCodeException,
                    };

                // حذف کد احراز هویت
                await _userFacad.RemoveVCode.ExecuteAsync(verificationCode.Id);

                return new CheckVCodeResultDto()
                {
                    IsValid = true,
                    Exception = null,
                };
            }
            catch (Exception ex)
            {
                return new CheckVCodeResultDto()
                {
                    IsValid = false,
                    Exception = new ErrorDto(ex)
                };
            }
        }
    }
}
