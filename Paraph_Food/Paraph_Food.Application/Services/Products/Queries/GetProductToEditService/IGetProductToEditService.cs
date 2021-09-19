using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetProductToEditService
{
    public interface IGetProductToEditService
    {
        Task<GetProductToEditResultDto> ByIdAsync(int id);
    }
}
