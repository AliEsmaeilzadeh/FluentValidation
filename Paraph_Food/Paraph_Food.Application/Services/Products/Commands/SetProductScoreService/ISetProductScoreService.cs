using Microsoft.Extensions.Logging;
using Paraph_Food.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Commands.SetProductScoreService
{
    public interface ISetProductScoreService
    {
        Task<CommandResultDto> ExecuteAsync(long userId, int productId, double score);
    }
}
