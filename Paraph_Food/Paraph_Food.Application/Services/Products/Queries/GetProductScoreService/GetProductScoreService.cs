using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductScoreService
{
    public class GetProductScoreService : IGetProductScoreService
    {
        private readonly IParaph_DbContext _db;
        public GetProductScoreService(IParaph_DbContext db)
        {
            _db = db;
        }
        public double Execute(int productId)
        {
            var productScore = _db.ProductScores.Where(obj=>obj.ProductId == productId).Average(obj => obj.Score);
            return productScore;
        }
    }
}
