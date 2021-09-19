using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Queries.GetUserAddressesService
{
    public class GetUserAddressesService : IGetUserAddressesService
    {
        private readonly IParaph_DbContext _db;
        public GetUserAddressesService(IParaph_DbContext db)
        {
            _db = db;
        }
        public async Task<List<GetUserAddressesResultDto>> ByUserIdAsync(long userId)
        {
            var user = await _db.Users.Where(obj => obj.Id == userId)
                                      .Include(obj => obj.Profile.Addresses)
                                      .FirstOrDefaultAsync();

            if (user == null)
                throw new MyException(ErrorMessages.NoUserException);
            else if (user.UserStatus == UserStatus.Disabled)
                throw new MyException(ErrorMessages.UserIsDisabledException);
            else if (user.UserStatus == UserStatus.Blocked)
                throw new MyException(ErrorMessages.UserIsBlockedException);

            if (user.Profile == null)
                throw new MyException(ErrorMessages.NotFoundProfileInfoException);

            return user.Profile.Addresses.Select(obj => new GetUserAddressesResultDto()
            {
                Id = obj.Id,
                Title = obj.Title,
                Description = obj.Description,
                Latitude = obj.Location.X,
                Longitude = obj.Location.Y,
                IsDefault = obj.IsDefault,
            }).ToList();
        }
    }
}
