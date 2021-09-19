using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Paraph_Food.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.ExistThisUser
{
    public class ExistThisUserService : IExistThisUserService
    {
        private readonly IParaph_DbContext _db;
        public ExistThisUserService(IParaph_DbContext db)
        {
            _db = db;
        }



        /// <summary>
        /// بررسی میکند که نام کاربری وارد شده تکراری نباشد
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Execute(string userName)
        {
            var exist = _db.Users.Any(obj => obj.UserName.Equals(userName));
            return exist;
        }

        /// <summary>
        /// بررسی میکند که نام کاربری وارد شده در سیستم ثبت شده یا خیر
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteAsync(string userName)
        {
            var exist = await _db.Users.AnyAsync(obj => obj.UserName.Equals(userName));
            return exist;
        }
    }
}
