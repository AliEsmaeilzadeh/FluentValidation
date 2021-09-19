using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.LikeProductTogglesService
{
    public interface ILikeProductTogglesService
    {
        Task<CommandResultDto> ExecuteAsync(long userId, int productId);
    }
}
