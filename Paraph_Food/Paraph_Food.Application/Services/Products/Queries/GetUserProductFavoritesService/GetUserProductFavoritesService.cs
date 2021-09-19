using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileReader;
using Paraph_Food.Application.Services.Products.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Queries.GetUserProductFavoritesService
{
    public class GetUserProductFavoritesService : IGetUserProductFavoritesService
    {
        private readonly IParaph_DbContext _db;
        private readonly IProductsFacad _productServices;
        private readonly AppSettings _appSettings;
        public GetUserProductFavoritesService(IParaph_DbContext db, IProductsFacad productServices, AppSettings appSettings)
        {
            _db = db;
            _productServices = productServices;
            _appSettings = appSettings;
        }
        public async Task<List<UserProductFavoritesDto>> ByUserId(long userId)
        {
            var user = await _db.Users.Where(obj => obj.Id == userId)
                                      .Include(obj => obj.ProductFavorites)
                                        .ThenInclude(obj => obj.Product)
                                      .FirstOrDefaultAsync();

            if (user == null)
                throw new MyException(ErrorMessages.NoUserException);
            else if (user.UserStatus == UserStatus.Disabled)
                throw new MyException(ErrorMessages.UserIsDisabledException);
            else if (user.UserStatus == UserStatus.Blocked)
                throw new MyException(ErrorMessages.UserIsBlockedException);


            var result = user.ProductFavorites.Select(obj => new UserProductFavoritesDto()
            {
                ProductId = obj.ProductId,
                CategoryId = obj.Product.CategoryId,
                Title = obj.Product.Title,
                Ingredients = obj.Product.Ingredients,
                Price = obj.Product.Price,
                DiscountedPrice = obj.Product.DiscountValueType == DiscountValueType.Percent ?
                                    obj.Product.Price - (long)((obj.Product.Price * obj.Product.DiscountValue) / 100)
                                    :
                                    obj.Product.Price - (long)obj.Product.DiscountValue,
                Score = _productServices.GetProductScore.Execute(obj.ProductId),
                Image = obj.Product.Image.GetProductImageAddress(_appSettings),
            }).ToList();

            return result;
        }
    }
}
