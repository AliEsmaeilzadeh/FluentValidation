using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.DeleteProductService
{
    public class DeleteProductService : IDeleteProductService
    {
		private readonly IParaph_DbContext _db;
		public DeleteProductService(IParaph_DbContext db)
		{
			_db = db;
		}

		public async Task<CommandResultDto> ExecuteAsync(int id)
        {
			try
			{
				var product = await _db.Products.FindAsync(id);
				if (product == null)
					throw new MyException(ErrorMessages.NotFoundProductException);

				product.Deleted = true;

				_db.Products.Update(product);
				await _db.SaveChangesAsync();

				return new CommandResultDto()
				{
					Id = product.Id,
					IsSuccess = true,
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
