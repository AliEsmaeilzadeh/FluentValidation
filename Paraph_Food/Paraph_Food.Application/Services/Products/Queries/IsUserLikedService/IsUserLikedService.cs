using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Paraph_Food.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.IsUserLikedService
{
    public class IsUserLikedService : IIsUserLikedService
    {
        private readonly IParaph_DbContext _db;
        public IsUserLikedService(IParaph_DbContext db)
        {
            _db = db;
        }

        public async Task<bool> ExecuteAsync(long userId, int productId) 
        {
            var isLiked = await _db.ProductFavorites.AnyAsync(obj => obj.ProductId == productId && obj.UserId == userId);
            return isLiked;
        }
        public bool Execute(long userId, int productId) 
        {
            var isLiked = _db.ProductFavorites.Any(obj => obj.ProductId == productId && obj.UserId == userId);
            return isLiked;
        }
    }
}
