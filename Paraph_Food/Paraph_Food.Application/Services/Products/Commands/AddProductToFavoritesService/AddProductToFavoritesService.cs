using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Domain.Enities.Products;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Commands.AddProductToFavoritesService
{
    public class AddProductToFavoritesService : IAddProductToFavoritesService
    {
        private readonly IParaph_DbContext _db;
        public AddProductToFavoritesService(IParaph_DbContext db)
        {
            _db = db;
        }
        public async Task<CommandResultDto> ExecuteAsync(Product product, User user)
        {
            try
            {
                if (product == null)
                    throw new MyException(ErrorMessages.NotFoundProductException);

                if (user == null)
                    throw new MyException(ErrorMessages.NoUserException);
                else if (user.UserStatus == UserStatus.Disabled)
                    throw new MyException(ErrorMessages.UserIsDisabledException);
                else if (user.UserStatus == UserStatus.Blocked)
                    throw new MyException(ErrorMessages.UserIsBlockedException);

                var newProductFavorite = new ProductFavorite()
                {
                    UserId = user.Id,
                    ProductId = product.Id,
                };

                await _db.ProductFavorites.AddAsync(newProductFavorite);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
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
