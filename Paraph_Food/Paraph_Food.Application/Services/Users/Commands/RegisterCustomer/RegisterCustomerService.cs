using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterCustomer
{
    public class RegisterCustomerService : IRegisterCustomerService
    {
        private readonly IParaph_DbContext _db;
        private readonly IUsersFacad _usersServices;
        public RegisterCustomerService(IParaph_DbContext db, IUsersFacad usersServices)
        {
            _db = db;
            _usersServices = usersServices;
        }


        /// <summary>
        /// ثبت نام مشتری
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public async Task<CommandResultDto> ExecuteAsync(string mobile, string vCode)
        {
            using (var transaction = await _db.BeginTransactionAsync())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(mobile))
                    {
                        await transaction.RollbackAsync();
                        return new CommandResultDto()
                        {
                            Id = null,
                            IsSuccess = false,
                            Exception = ErrorMessages.InvalidMobileNumberException,
                        };
                    }

                    var verifyCodeResult = await _usersServices.CheckVCode.ExecuteAsync(mobile, vCode);
                    if (!verifyCodeResult.IsValid)
                    {
                        await transaction.RollbackAsync();
                        return new CommandResultDto()
                        {
                            IsSuccess = false,
                            Exception = verifyCodeResult.Exception,
                        };
                    }

                    if (await _usersServices.ExistThisUser.ExecuteAsync(mobile))
                    {
                        await transaction.RollbackAsync();
                        return new CommandResultDto()
                        {
                            Id = null,
                            IsSuccess = false,
                            Exception = ErrorMessages.DuplicateMobileUserException,
                        };
                    }

                    var newUser = new User()
                    {
                        UserName = mobile,
                        Password = null,
                        UserStatus = UserStatus.Confirmed,
                        CreatedDateTime = DateTime.Now,
                        CreatedUserId = 0,
                        LastModifiedDateTime = null,
                        LastModifiedUserId = null,
                        Deleted = false,
                        Profile = new Profile()
                        {
                            CreatedDateTime = DateTime.Now,
                            CreatedUserId = 0,
                            Mobile = mobile,
                            Deleted = false,
                        },
                        Customer = new Customer()
                        {
                            CashBalance = 0,
                            Score = 0,
                            CreatedDateTime = DateTime.Now,
                            CreatedUserId = 0,
                            Deleted = false,
                        },
                    };

                    await _db.Users.AddAsync(newUser);
                    await _db.SaveChangesAsync();

                    var result = await _usersServices.AddUserInRole.ExecuteAsync(newUser, "Customer");
                    if (!result.IsSuccess)
                    {
                        await transaction.RollbackAsync();
                        return new CommandResultDto()
                        {
                            IsSuccess = false,
                            Exception = result.Exception,
                        };
                    }

                    await transaction.CommitAsync();
                    return new CommandResultDto()
                    {
                        Id = newUser.Id,
                        IsSuccess = true,
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new CommandResultDto()
                    {
                        Id = null,
                        IsSuccess = true,
                        Exception = new ErrorDto(ex),
                    };
                }
            }
        }
    }
}
