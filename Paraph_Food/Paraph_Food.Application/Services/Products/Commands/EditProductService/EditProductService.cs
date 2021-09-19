using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.EditProductService
{
    public class EditProductService : IEditProductService
    { 
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public EditProductService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }
        public async Task<CommandResultDto> ExecuteAsync(int id, EditProductDto model)
        {
            try
            {
                if (!model.IsValid(out string message))
                    return new CommandResultDto()
                    {
                        IsSuccess = false,
                        Exception = new ErrorDto(message),
                    };


                var product = await _db.Products.FindAsync(id);
                if (product == null)
                    throw new MyException(ErrorMessages.NotFoundProductException);

                product.CategoryId = model.CategoryId;
                product.Title = model.Title;
                product.Ingredients = model.Ingredients;
                product.Price = model.Price;
                product.DiscountValue = model.DiscountValue;
                product.DiscountValueType = model.DiscountValueType;
                product.LastModifiedUserId = model.ModifierUserId;
                product.LastModifiedDateTime = DateTime.Now;

                _db.Products.Update(product);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    IsSuccess = true,
                    Id = product.Id,
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
