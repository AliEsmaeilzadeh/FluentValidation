using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductToEditService
{
    public class GetProductToEditService : IGetProductToEditService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public GetProductToEditService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }


        public async Task<GetProductToEditResultDto> ByIdAsync(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                throw new MyException(ErrorMessages.NotFoundProductException);

            return new GetProductToEditResultDto()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Title = product.Title,
                Ingredients = product.Ingredients,
                Price = product.Price,
                DiscountValue = product.DiscountValue,
                DiscountValueType = product.DiscountValueType,
                Image = product.Image.GetProductImageAddress(_appSettings),
            };
        }
    }
}
