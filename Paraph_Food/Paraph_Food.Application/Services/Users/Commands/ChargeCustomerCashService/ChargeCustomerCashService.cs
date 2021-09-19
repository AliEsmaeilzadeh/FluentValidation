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

namespace Paraph_Food.Application.Services.Users.Commands.ChargeCustomerCashService
{
    public class ChargeCustomerCashService : IChargeCustomerCashService
    {
        private readonly IParaph_DbContext _db;
        public ChargeCustomerCashService(IParaph_DbContext db)
        {
            _db = db;
        }

        public async Task<CommandResultDto> ExecuteAsync(long userId, long amount)
        {
			try
			{
                var user = await _db.Users.Where(obj => obj.Id == userId)
                                          .Include(obj => obj.Customer)
                                          .FirstOrDefaultAsync();
                if (user == null)
                    throw new MyException(ErrorMessages.NoUserException);
                else if (user.UserStatus == UserStatus.Disabled)
                    throw new MyException(ErrorMessages.UserIsDisabledException);
                else if (user.UserStatus == UserStatus.Blocked)
                    throw new MyException(ErrorMessages.UserIsBlockedException);

                if (user.Customer == null)
                    throw new MyException(ErrorMessages.NotFoundCustomerException);

                if (amount <= 0)
                    throw new MyException(ErrorMessages.InValidInputsException);

                user.Customer.CashBalance += amount;

                _db.Customers.Update(user.Customer);
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
