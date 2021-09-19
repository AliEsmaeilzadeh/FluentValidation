using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Queries.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IParaph_DbContext _db;
        public GetUserService(IParaph_DbContext db)
        {
            _db = db;
        }


        /// <summary>
        /// گرفتن اطلاعات کاربری با شناسه مشخص شده
        /// </summary>
        /// <param name="id"> شناسه کاربر </param>
        /// <returns></returns>
        public async Task<GetUserResultDto> ByIdAsync(long id)
        {
            var user = await _db.Users.Where(obj => obj.Id == id).FirstOrDefaultAsync();
            if (user == null)
                return null;

            return new GetUserResultDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                HashedPassword = user.Password,
                Status = user.UserStatus,       
            };
        }

        /// <summary>
        /// گرفتن اطلاعات کاربری با نام کاربری مشخص شده
        /// </summary>
        /// <param name="userName"> نام کاربری </param>
        /// <returns></returns>
        public async Task<GetUserResultDto> ByUserNameAsync(string userName)
        {

            var user = await _db.Users.Where(obj => obj.UserName.Equals(userName)).FirstOrDefaultAsync();
            if (user == null)
                return null;

            return new GetUserResultDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                HashedPassword = user.Password,
                Status = user.UserStatus,
            };
        }
    }
}
