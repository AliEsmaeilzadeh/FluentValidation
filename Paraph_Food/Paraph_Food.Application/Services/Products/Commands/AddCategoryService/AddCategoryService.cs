using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileUploader;
using System;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.AddCategoryService
{
    public class AddCategoryService : IAddCategoryService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public AddCategoryService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }

        public async Task<CommandResultDto> ExecuteAsync(AddCategoryDto model)
        {
            try
            {
                if (!model.IsValid(out string message))
                    return new CommandResultDto()
                    {
                        IsSuccess = false,
                        Exception = new ErrorDto(message)
                    };
                

                Domain.Enities.Products.Category category = new Domain.Enities.Products.Category()
                {
                    Title = model.Title,
                    Image = model.Image.UploadToCategory(_appSettings).FileName,
                    PackingCost = model.PackingCost,
                    Order = model.Order,

                    CreatedDateTime = DateTime.Now,
                    CreatedUserId = model.CreatedUserId,
                    Deleted = false,
                };

                await _db.Categories.AddAsync(category);
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
