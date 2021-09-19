using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.AddProductService
{
    public interface IAddProductService
    {
        Task<CommandResultDto> ExecuteAsync(AddProductDto product);
    }
}
