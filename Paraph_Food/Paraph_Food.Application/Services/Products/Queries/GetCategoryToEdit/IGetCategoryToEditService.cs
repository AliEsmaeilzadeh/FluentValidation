using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetCategoryToEdit
{
    public interface IGetCategoryToEditService
    {
        Task<GetCategoryToEditResultDto> ByIdAsync(int id);
    }

}
