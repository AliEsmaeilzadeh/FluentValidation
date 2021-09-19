using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Common;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IParaph_DbContext _db;
        private readonly IUsersFacad _usersServices;
        public RegisterUserService(IParaph_DbContext db, IUsersFacad usersServices)
        {
            _db = db;
            _usersServices = usersServices;
        }


        /// <summary>
        /// ثبت اطلاعات کاربری
        /// </summary>
        /// <param name="user"> اطلاعات کاربری </param>
        public RegisterUserResult Execute(RegisterUserDto user)
        {
            try
            {
                if (!user.IsValid(out string message))
                {
                    return new RegisterUserResult()
                    {
                        User = null,
                        IsSuccess = false,
                        Exception = new ErrorDto(message),
                    };
                }

                if (_usersServices.ExistThisUser.Execute(user.UserName))
                {
                    return new RegisterUserResult()
                    {
                        User = null,
                        IsSuccess = false,
                        Exception = ErrorMessages.DuplicateUserException
                    };
                }

                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(user.Password);
                var newUser = new User()
                {
                    UserName = user.UserName,
                    Password = hashedPassword,
                    UserStatus = user.Status,
                    CreatedDateTime = DateTime.Now,
                    CreatedUserId = 0,
                    LastModifiedDateTime = null,
                    LastModifiedUserId = null,
                    Deleted = false,
                };

                _db.Users.Add(newUser);
                _db.SaveChanges();

                return new RegisterUserResult()
                {
                    User = newUser,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new RegisterUserResult()
                {
                    User = null,
                    IsSuccess = true,
                    Exception = new ErrorDto(ex),
                };
            }
        }


        /// <summary>
        /// ثبت اطلاعات کاربری بصورت ای سینک
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<RegisterUserResult> ExecuteAsync(RegisterUserDto user)
        {
            try
            {
                if (!user.IsValid(out string message))
                {
                    return new RegisterUserResult()
                    {
                        User = null,
                        IsSuccess = false,
                        Exception = new ErrorDto(message),
                    };
                }

                if (await _usersServices.ExistThisUser.ExecuteAsync(user.UserName))
                {
                    return new RegisterUserResult()
                    {
                        User = null,
                        IsSuccess = false,
                        Exception = ErrorMessages.DuplicateUserException,
                    };
                }

                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(user.Password);
                var newUser = new User()
                {
                    UserName = user.UserName,
                    Password = hashedPassword,
                    UserStatus = user.Status,
                    CreatedDateTime = DateTime.Now,
                    CreatedUserId = 0,
                    LastModifiedDateTime = null,
                    LastModifiedUserId = null,
                    Deleted = false,
                };

                await _db.Users.AddAsync(newUser);
                await _db.SaveChangesAsync();

                return new RegisterUserResult()
                {
                    User = newUser,
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new RegisterUserResult()
                {
                    User = null,
                    IsSuccess = true,
                    Exception = new ErrorDto(ex),
                };
            }
        }
    }
}
