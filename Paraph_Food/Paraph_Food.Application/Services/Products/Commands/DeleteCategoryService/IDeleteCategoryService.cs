using Paraph_Food.Application.Common;
using Paraph_Food.Domain.Enities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.DeleteCategoryService
{
    public interface IDeleteCategoryService
    {
        Task<CommandResultDto> ExecuteAsync(int id);
    }
}
