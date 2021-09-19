using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.FileReader;
using Paraph_Food.Application.Services.Products.FacadPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductsToMenuService
{
    public class GetProductsToMenuService : IGetProductsToMenuService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        private readonly IProductsFacad _productServices;
        public GetProductsToMenuService(IParaph_DbContext db, AppSettings appSettings, IProductsFacad productServices)
        {
            _db = db;
            _appSettings = appSettings;
            _productServices = productServices;
        }

        public async Task<List<ProductsOfMenuDto>> ByCategoryIdAsync(int categoryId, long? currentUserId)
        {
            var products = await _db.Products.Where(obj => obj.CategoryId == categoryId
                                                        && obj.IsAvailable)
                                             .ToListAsync();

            return products.Select(obj => new ProductsOfMenuDto()
            {
                Id = obj.Id,
                CategoryId = obj.CategoryId,
                Title = obj.Title,
                Ingredients = obj.Ingredients,
                Price = obj.Price,
                DiscountedPrice = (obj.DiscountValue > 0) ?
                                        obj.DiscountValueType == DiscountValueType.Percent ?
                                            (obj.Price - ((long)(obj.Price * obj.DiscountValue) / 100))
                                            :
                                            (long)(obj.Price - obj.DiscountValue)
                                        :
                                        (long?)null,
                Image = obj.Image.GetProductImageAddress(_appSettings),
                Score = _productServices.GetProductScore.Execute(obj.Id),
                IsLiked = currentUserId.HasValue? _productServices.IsUserLiked.Execute(currentUserId.Value, obj.Id) : false,
            }).ToList();
        }
    }
}
