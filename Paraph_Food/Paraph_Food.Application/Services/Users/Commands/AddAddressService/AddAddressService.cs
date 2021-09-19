using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Commands.AddAddressService
{
    public class AddAddressService : IAddAddressService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public AddAddressService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }
        public async Task<CommandResultDto> ExecuteAsync(long userId, AddAddressDto model)
        {
			try
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

                user.Profile.Addresses.Add(new Address()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Location = new NetTopologySuite.Geometries.Point(model.Latitude, model.Longitude) { SRID = _appSettings.GeographySRID},
                    IsDefault = model.IsDefault,
                    Deleted = false,
                });

                _db.Profiles.Update(user.Profile);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    IsSuccess = true,
                };
			}
            catch(MyException ex)
            {
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = new ErrorDto(ex),
                };
            }
			catch (Exception ex)
			{
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = new ErrorDto(ex),
                };
			}
        }
    }
}
