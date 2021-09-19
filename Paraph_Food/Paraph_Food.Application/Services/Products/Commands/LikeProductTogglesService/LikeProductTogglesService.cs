using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Products.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Commands.LikeProductTogglesService
{
    public class LikeProductTogglesService : ILikeProductTogglesService
    {
        private readonly IParaph_DbContext _db;
        private readonly IProductsFacad _productServices;
        public LikeProductTogglesService(IParaph_DbContext db, IProductsFacad productServices)
        {
            _db = db;
            _productServices = productServices;
        }


        public async Task<CommandResultDto> ExecuteAsync(long userId, int productId)
        {
            try
            {
                // گرفتن محصول
                var product = await _db.Products.Where(obj => obj.Id == productId && obj.IsAvailable).FirstOrDefaultAsync();
                if (product == null)
                    throw new MyException(ErrorMessages.NotFoundProductException);

                // گرفتن کاربر
                var user = await _db.Users.FindAsync(userId);
                if (user == null)
                    throw new MyException(ErrorMessages.NoUserException);
                else if (user.UserStatus == UserStatus.Disabled)
                    throw new MyException(ErrorMessages.UserIsDisabledException);
                else if (user.UserStatus == UserStatus.Blocked)
                    throw new MyException(ErrorMessages.UserIsBlockedException);

                // دریافت علاقه مندی
                var productFavorite = await _db.ProductFavorites.FindAsync(productId, userId);

                // اگر علاقه مندی مورد نظر یافت نشد پس یعنی کاربر محصول را لایک کرده است
                if (productFavorite == null)
                {
                    var result = await _productServices.AddProductToFavorites.ExecuteAsync(product, user);
                    if (result.IsSuccess)
                        return new CommandResultDto()
                        {
                            IsSuccess = true
                        };
                    else
                        throw new MyException(result.Exception);
                }
                // اگر علاقه مندی مورد نظر یافت شد پس یعنی کاربر محصول را آنلایک کرده است
                else
                {
                    var result = await _productServices.RemoveProductFromFavorites.ExecuteAsync(productFavorite);
                    if (result.IsSuccess)
                        return new CommandResultDto()
                        {
                            IsSuccess = true
                        };
                    else
                        throw new MyException(result.Exception);
                }

            }
            catch(MyException ex)
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
