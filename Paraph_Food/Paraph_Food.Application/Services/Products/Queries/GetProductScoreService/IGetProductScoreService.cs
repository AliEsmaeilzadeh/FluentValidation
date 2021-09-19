using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductScoreService
{
    public interface IGetProductScoreService
    {
        double Execute(int productId);
    }
}
