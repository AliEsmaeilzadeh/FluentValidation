using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileUpdate;
using System;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.EditCategoryService
{
    public class EditCategoryService : IEditCategoryService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public EditCategoryService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }
        public async Task<CommandResultDto> ExecuteAsync(int id, EditCategoryDto model)
        {
            try
            {
                if(!model.IsValid(out string message))
                    return new CommandResultDto()
                    {
                        IsSuccess = false,
                        Exception = new ErrorDto(message),
                    };


                var category = await _db.Categories.FindAsync(id);
                if (category == null)
                    throw new MyException(ErrorMessages.NotFoundCategoryException);

                category.Title = model.Title;
                category.PackingCost = model.PackingCost;
                category.Order = model.Order;
                category.Image = category.Image.UpdateCategoryImageTo(model.Image, _appSettings);
                category.LastModifiedUserId = model.ModifierUserId;
                category.LastModifiedDateTime = DateTime.Now;

                _db.Categories.Update(category);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    IsSuccess = true,
                    Id = category.Id,
                };
            }
            catch(MyException ex)
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
