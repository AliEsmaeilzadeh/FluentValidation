using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Areas.CustomerApp.Models.ViewModels.Users;
using Paraph_Food.Api.Helper.Attributes;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Users.Commands.AddAddressService;
using Paraph_Food.Application.Services.Users.Commands.EditCustomerProfile;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.CustomerApp.Controllers
{
    [Area("CustomerApp")]
    public class UserController : BaseController
    {
        private readonly IUsersFacad _userServices;
        public UserController(IUsersFacad usersFacad)
        {
            _userServices = usersFacad;
        }


        /// <summary>
        /// تولید و ارسال کد احراز هویت به شماره مشخص شده
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpGet("CustomerApp/User/getVCode")]
        public async Task<IActionResult> getVCode(string mobile)
        {
            try
            {
                var code = await _userServices.SetVCode.ExecuteAsync(mobile);

#if !DEBUG
                // Send Code to User Via SMS
                return Ok();
#else
                return Ok(code);
#endif
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// ثبت نام مشتری با شماره مشخص شده با کد تایید
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="vCode"></param>
        /// <returns></returns>
        [HttpPost("CustomerApp/User/register")]
        public async Task<IActionResult> register(string mobile, string vCode)
        {
            try
            {
                var result = await _userServices.RegisterCustomer.ExecuteAsync(mobile, vCode);
                if (!result.IsSuccess)
                    throw new MyException(result.Exception);

                return Ok();
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }


        /// <summary>
        /// ورود مشتری به سیستم با استفاده از کد احراز هویت
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="vCode"></param>
        /// <returns></returns>
        [HttpPost("CustomerApp/User/login")]
        public async Task<IActionResult> login(string mobile, string vCode)
        {
            try
            {
                var result = await _userServices.CustomerLogin.ExecuteAsync(mobile, vCode);

                if (!result.IsSuccess)
                    throw new MyException(result.Exception);

                return Ok(new LoginResultVM()
                {
                    UserId = result.UserId.Value,
                    Token = result.Token,
                    Roles = result.Roles,
                });
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }


        /// <summary>
        /// دریافت اطلاعات مشتری لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("CustomerApp/User/getInfo")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> getInfo()
        {
            try
            {
                var userId = _userServices.GetCurrentUserId.Execute();
                if (!userId.HasValue)
                    throw new MyException(ErrorMessages.NoUserException);


                var info = await _userServices.GetCustomerInfo.ByUserId(userId.Value);
                if (info == null)
                    throw new MyException(ErrorMessages.NotFoundUserException);

                var result = new CustomerGetInfoResultVM()
                {
                    ProfileDetail = new CustomerProfileDetailVM()
                    {
                        UserId = info.Profile.UserId,
                        FirstName = info.Profile.FirstName,
                        LastName = info.Profile.LastName,
                        BirthDate = info.Profile.BirthDate,
                        Image = info.Profile.Image,
                        Addresses = info.Profile.Addresses.Select(obj => new CustomerAddressesVM()
                        {
                            Id = obj.Id,
                            Title = obj.Title,
                            Description = obj.Description,
                            Latitude = obj.Latitude,
                            Longitude = obj.Longitude,
                            IsDefault = obj.IsDefault,
                        }).ToList(),
                    },
                    Financial = new CustomerFinancialVM()
                    {
                        CashBalance = info.Financial.CashBalance,
                        Score = info.Financial.Score,
                    },
                };

                return Ok(result);
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }


        /// <summary>
        /// دریافت اطلاعات پروفایل مشتری لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("CustomerApp/User/getProfile")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> getProfile()
        {
            try
            {
                var userId = _userServices.GetCurrentUserId.Execute();
                if (!userId.HasValue)
                    throw new MyException(ErrorMessages.NoUserException);

                var customerProfile = await _userServices.GetCustomerProfile.ByUserId(userId.Value);
                if (customerProfile == null)
                    throw new MyException(ErrorMessages.NotFoundProfileInfoException);

                var result = new CustomerProfileDetailVM()
                {
                    UserId = customerProfile.UserId,
                    FirstName = customerProfile.FirstName,
                    LastName = customerProfile.LastName,
                    BirthDate = customerProfile.BirthDate,
                    Image = customerProfile.Image,
                };


                return Ok(result);
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }


        /// <summary>
        /// ویرایش اطلاعات پروفایل مشتری
        /// </summary>
        /// <returns></returns>
        [HttpPut("CustomerApp/User/editProfile")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> editProfile([FromBody]CustomerEditProfileVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var error = ModelState.SelectMany(x => x.Value.Errors).FirstOrDefault();
                    throw new Exception(error.ErrorMessage);
                }

                var currentUserId = Convert.ToInt64(User.Claims.FirstOrDefault().Value);

                var editCustomerModel = new EditCustomerProfileDto()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Image = model.Image
                };

                var result = await _userServices.EditCustomerProfile.ExecuteAsync(currentUserId, editCustomerModel);
                if (result.IsSuccess)
                    return Ok();

                throw new MyException(result.Exception);
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }


        /// <summary>
        /// شارژ کیف پول
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/User/ChargingCash")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> ChargingCash(long amount)
        {
            try
            {
                var userId = _userServices.GetCurrentUserId.Execute();
                if (!userId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);

                if (amount <= 0)
                    throw new MyException(ErrorMessages.InValidInputsException);

                var result = await _userServices.ChargeCustomerCash.ExecuteAsync(userId.Value, amount);
                if (result.IsSuccess)
                    return Ok();

                throw new MyException(result.Exception);
            }
            catch(MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        /// <summary>
        /// افزودن آدرس
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/User/AddAddress")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> AddAddress([FromBody]AddAddressViewModel model)
        {
            try
            {
                var userId = _userServices.GetCurrentUserId.Execute();
                if (!userId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);

                var dto = new AddAddressDto()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    IsDefault = model.IsDefault,
                };
                var result = await _userServices.AddAddress.ExecuteAsync(userId.Value, dto);
                if (result.IsSuccess)
                    return Ok();

                throw new MyException(result.Exception);
            }
            catch(MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        /// <summary>
        /// انتخاب آدرس پیشفرض
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/User/SetDefaultAddress")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> SetDefaultAddress(int addressId)
        {
            try
            {
                var userId = _userServices.GetCurrentUserId.Execute();
                if (!userId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);

                var result = await _userServices.SetDefaultAddress.ExecuteAsync(userId.Value, addressId);
                if (result.IsSuccess)
                    return Ok();

                throw new MyException(result.Exception);
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}