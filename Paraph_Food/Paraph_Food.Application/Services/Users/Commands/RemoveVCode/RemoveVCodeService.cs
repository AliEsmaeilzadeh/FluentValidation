using Paraph_Food.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.RemoveVCode
{
    public class RemoveVCodeService : IRemoveVCodeService
    {
        private readonly IParaph_DbContext _db;
        public RemoveVCodeService(IParaph_DbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// کد احراز هویت با شناسه مشخص شده را حذف میکند
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(int id)
        {
            var verificationCode = await _db.VerificationCodes.FindAsync(id);

            verificationCode.Deleted = true;

            _db.VerificationCodes.Update(verificationCode);
            await _db.SaveChangesAsync();
        }
    }
}
