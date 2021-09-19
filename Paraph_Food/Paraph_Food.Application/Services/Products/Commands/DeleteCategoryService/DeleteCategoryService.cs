using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.DeleteCategoryService
{
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly IParaph_DbContext _db;
        public DeleteCategoryService(IParaph_DbContext db)
        {
            _db = db;
        }
        public async Task<CommandResultDto> ExecuteAsync(int id)
        {
			try
			{
                var category = await _db.Categories.FindAsync(id);
                if (category == null)
                    throw new MyException(ErrorMessages.NotFoundCategoryException);

                category.Deleted = true;

                _db.Categories.Update(category);
                await _db.SaveChangesAsync();

                return new CommandResultDto()
                {
                    Id = category.Id,
                    IsSuccess = true,
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
