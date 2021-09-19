using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.DeleteProductService
{
    public interface IDeleteProductService
    {
        Task<CommandResultDto> ExecuteAsync(int id);
    }
}
