using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileUploader;
using Paraph_Food.Domain.Enities.Products;
using System;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.AddProductService
{
    public class AddProductService : IAddProductService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public AddProductService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }

        public async Task<CommandResultDto> ExecuteAsync(AddProductDto product)
        {
            try
            {
                if (!product.IsValid(out string message))
                    throw new MyException(message);

                var newProduct = new Product()
                {
                    CategoryId = product.CategoryId,
                    Title = product.Title,
                    Ingredients = product.Ingredients,
                    Price = product.Price,
                    Image = product.Image.UploadToProducts(_appSettings).FileName,
                    DiscountValue = product.DiscountValue,
                    DiscountValueType = product.DiscountValueType,
                    IsAvailable = true,

                    CreatedDateTime = DateTime.Now,
                    CreatedUserId = product.CreatorUserId,
                    Deleted = false
                };

                await _db.Products.AddAsync(newProduct);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    IsSuccess = true,
                    Id = newProduct.Id,
                };
            }
            catch (MyException ex)
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
