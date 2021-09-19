using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Domain.Enities.Products;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Application.Services.Products.Commands.RemoveProductFromFavoritesService
{
    public class RemoveProductFromFavoritesService : IRemoveProductFromFavoritesService
    {
		private readonly IParaph_DbContext _db;
		public RemoveProductFromFavoritesService(IParaph_DbContext db)
		{
			_db = db;
		}

		public async Task<CommandResultDto> ExecuteAsync(ProductFavorite productFavorite)
        {
			try
			{
				if (productFavorite != null)
				{
					_db.ProductFavorites.Remove(productFavorite);
					await _db.SaveChangesAsync();
				}

				return new CommandResultDto()
				{
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
