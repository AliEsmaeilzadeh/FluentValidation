using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common;
using Paraph_Food.Application.Services.Common.CodeGenerators;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.SetVCode
{
    public class SetVCodeService : ISetVCodeService
    {
        private readonly IParaph_DbContext _db;
        public SetVCodeService(IParaph_DbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// ثبت یک کد 4 رقمی احراز هویت غیر تکراری برای نام کاربری مشخص شده
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<string> ExecuteAsync(string userName, double? duration = null)
        {
            string code = null;
            var generatedCodes = _db.VerificationCodes.Select(obj => obj.Code).ToArray();
            do
            {
                code = CodeGenerator.generateNumeralCode(1000, 9999);
            } while (generatedCodes.Contains(code));

            var newVCode = new VerificationCode()
            {
                UserName = userName,
                Code = code,
                GenerateDateTime = DateTime.Now,
                ExpirationDateTime = DateTime.Now.AddMinutes(duration.HasValue ? duration.Value : 2),
                Deleted = false,
            };
            await _db.VerificationCodes.AddAsync(newVCode);
            await _db.SaveChangesAsync();

            return code;
        }
    }
}
