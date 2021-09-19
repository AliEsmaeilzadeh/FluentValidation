using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetUserProductFavoritesService
{
    public interface IGetUserProductFavoritesService
    {
        Task<List<UserProductFavoritesDto>> ByUserId(long userId);
    }
}
