using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductsToMenuService
{
    public interface IGetProductsToMenuService
    {
        Task<List<ProductsOfMenuDto>> ByCategoryIdAsync(int CategoryId, long? currentUserId);
    }
}
