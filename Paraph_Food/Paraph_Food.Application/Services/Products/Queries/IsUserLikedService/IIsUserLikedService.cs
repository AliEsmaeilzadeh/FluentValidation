using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.IsUserLikedService
{
    public interface IIsUserLikedService
    {
        Task<bool> ExecuteAsync(long userId, int productId);
        bool Execute(long userId, int productId);
    }
}
