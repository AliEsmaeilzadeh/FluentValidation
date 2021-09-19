using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Commands.SetDefaultAddressService
{
    public class SetDefaultAddressService : ISetDefaultAddressService
    {
        private readonly IParaph_DbContext _db;
        public SetDefaultAddressService(IParaph_DbContext db)
        {
            _db = db;
        }
        public async Task<CommandResultDto> ExecuteAsync(long userId, int addressId)
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

                var address = await _db.Addresses.FindAsync(addressId);
                if (address == null)
                    throw new MyException(ErrorMessages.NotFoundAddressException);


                var userOldDefaultAddress = user.Profile.Addresses.Where(obj => obj.IsDefault).FirstOrDefault();
                if(userOldDefaultAddress != null)
                {
                    userOldDefaultAddress.IsDefault = false;
                    _db.Addresses.Update(userOldDefaultAddress);
                }

                address.IsDefault = true;

                _db.Addresses.Update(address);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    IsSuccess = true
                };
			}
            catch (MyException ex)
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
