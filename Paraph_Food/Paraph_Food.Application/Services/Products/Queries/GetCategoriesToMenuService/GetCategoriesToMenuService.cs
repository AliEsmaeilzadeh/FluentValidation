using Microsoft.EntityFrameworkCore;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Common.FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paraph_Food.Application.Services.Products.Queries.GetCategoriesToMenuService
{
    public class GetCategoriesToMenuService : IGetCategoriesToMenuService
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public GetCategoriesToMenuService(IParaph_DbContext db, AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }


        public async Task<List<CategoryOfMenuDto>> ExecuteAsync()
        {
            var categories = await _db.Categories.ToListAsync();

            return categories.Select(obj => new CategoryOfMenuDto()
            {
                Id = obj.Id,
                Title = obj.Title,
                Image = obj.Image.GetCategoryImageAddress(_appSettings),
            }).ToList();
        }
    }
}
