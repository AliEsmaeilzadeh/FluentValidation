using Paraph_Food.Application.Common;
using Paraph_Food.Domain.Enities.Products;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.AddProductToFavoritesService
{
    public interface IAddProductToFavoritesService
    {
        Task<CommandResultDto> ExecuteAsync(Product product, User user);
    }
}
