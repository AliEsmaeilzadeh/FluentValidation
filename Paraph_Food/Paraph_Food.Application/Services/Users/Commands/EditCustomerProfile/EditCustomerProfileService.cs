using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileUpdate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.EditCustomerProfile
{
    public class EditCustomerProfileService : IEditCustomerProfileService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public EditCustomerProfileService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }

        public async Task<CommandResultDto> ExecuteAsync(long userId, EditCustomerProfileDto model)
        {
            try
            {
                if(!model.IsValid(out string message))
                {
                    return new CommandResultDto()
                    {
                        IsSuccess = false,
                        Exception = new ErrorDto(message),
                    };
                }

                var customerProfile = await _db.Profiles.Where(obj => obj.UserId == userId).FirstOrDefaultAsync();

                customerProfile.FirstName = model.FirstName;
                customerProfile.LastName = model.LastName;
                customerProfile.BirthDate = model.BirthDate;
                customerProfile.Image = customerProfile.Image.UpdateProfileImageTo(model.Image, _appSettings);


                _db.Profiles.Update(customerProfile);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    Id = customerProfile.UserId,
                    IsSuccess = true,
                };
            }
            catch (MyException ex)
            {
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = new ErrorDto(ex)
                };
            }
            catch (Exception ex)
            {
                return new CommandResultDto()
                {
                    IsSuccess = false,
                    Exception = new ErrorDto(ex)
                };
            }
        }
    }
}
