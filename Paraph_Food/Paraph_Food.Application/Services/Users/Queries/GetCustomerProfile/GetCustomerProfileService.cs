using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileReader;
using Paraph_Food.Application.Services.Common.PersianDateTime;
using System.Linq;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Queries.GetCustomerProfile
{
    public class GetCustomerProfileService : IGetCustomerProfileService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public GetCustomerProfileService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }


        public async Task<CustomerProfileResultDto> ByUserId(long userId)
        {
            if (userId <= 0)
                throw new MyException(ErrorMessages.InValidInputsException);

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

            return new CustomerProfileResultDto()
            {
                UserId = user.Id,
                FirstName = user.Profile.FirstName,
                LastName = user.Profile.LastName,
                BirthDate = user.Profile.BirthDate.ToStringJalaliDate(),
                Image = user.Profile.Image.GetProfileImageAddress(_appSettings),
                Addresses = user.Profile.Addresses.Select(obj => new CustomerAddressesResultDto()
                {
                    Id = obj.Id,
                    Title = obj.Title,
                    Description = obj.Description,
                    Latitude = obj.Location.X,
                    Longitude = obj.Location.Y,
                    IsDefault = obj.IsDefault,
                }).ToList(),
            };
        }
    }
}
