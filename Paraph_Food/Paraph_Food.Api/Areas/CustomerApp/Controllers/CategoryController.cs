using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Areas.CustomerApp.Models.ViewModels.Products.Categories;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Products.FacadPattern;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.CustomerApp.Controllers
{
    [Area("CustomerApp")]
    public class CategoryController : BaseController
    {
        private readonly IProductsFacad _productServices;
        public CategoryController(IProductsFacad productServices)
        {
            _productServices = productServices;
        }


        /// <summary>
        /// دریافت لیست دسته ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/Category/getList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var result = await _productServices.GetCategoriesToMenu.ExecuteAsync();
                var categories = result.Select(obj => new CategoryListViewModel()
                {
                    Id = obj.Id,
                    Title = obj.Title,
                    Image = obj.Image,
                });

                return Ok(categories);
            }
            catch (MyException ex)
            {
                return HandleError(new MyException(ex));
            }
            catch (Exception ex)
            {
                return HandleError(new MyException(ex));
            }
        }

    }
}