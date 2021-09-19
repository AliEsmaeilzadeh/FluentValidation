using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Common.FileReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetCategoryToEdit
{
    public class GetCategoryToEditService : IGetCategoryToEditService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public GetCategoryToEditService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }
        public async Task<GetCategoryToEditResultDto> ByIdAsync(int id)
        {
            var category = await _db.Categories.FindAsync(id);

            if (category == null)
                throw new MyException(ErrorMessages.NotFoundCategoryException);

            return new GetCategoryToEditResultDto()
            {
                Id = category.Id,
                Title = category.Title,
                PackingCost = category.PackingCost,
                Order = category.Order,
                Image = category.Image.GetCategoryImageAddress(_appSettings),
            };
        }
    }
}
