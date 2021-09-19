using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Areas.Admin.Models.ViewModels.Products.Categories;
using Paraph_Food.Api.Helper.Attributes;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Products.Commands.AddCategoryService;
using Paraph_Food.Application.Services.Products.Commands.EditCategoryService;
using Paraph_Food.Application.Services.Products.FacadPattern;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Threading.Tasks;

namespace Paraph_Food.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly IProductsFacad _productServices;
        private readonly IUsersFacad _userServices;
        public CategoryController(IProductsFacad productServices, IUsersFacad userServices)
        {
            _productServices = productServices;
            _userServices = userServices;
        }


        /// <summary>
        /// درج دسته جدید
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Category/Add")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> Add([FromBody] AddCategoryViewModel model)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);


                var categoryDto = new AddCategoryDto()
                {
                    CreatedUserId = currUserId.Value,
                    
                    Title = model.Title,
                    Image = model.Image,
                    PackingCost = model.PackingCost,
                    Order = model.Order,
                };
                var result = await _productServices.AddCategory.ExecuteAsync(categoryDto);
                if (result.IsSuccess)
                    return Ok(result.Id);

                throw new MyException(result.Exception);
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


        /// <summary>
        /// دریافت جزئیات دسته
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Category/GetById")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _productServices.GetCategoryToEdit.ByIdAsync(id);

                if (result == null)
                    throw new MyException(ErrorMessages.NotFoundCategoryException);

                return Ok(new CategoryDetailToEditViewModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    PackingCost = result.PackingCost,
                    Order = result.Order,
                    Image = result.Image,
                });
            }
            catch(MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        /// <summary>
        /// ویرایش یک دسته
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Category/Edit")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCategoryViewModel model)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);


                var newCategory = new EditCategoryDto()
                {
                   Title = model.Title,
                   PackingCost = model.PackingCost,
                   Order = model.Order,
                   Image = model.Image,
                   ModifierUserId = currUserId.Value,
                };
                var result = await _productServices.EditCategory.ExecuteAsync(id, newCategory);

                if (result.IsSuccess)
                    return Ok(result.Id);

                throw new MyException(result.Exception);
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


        /// <summary>
        /// حذف دسته بندی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Category/Delete")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productServices.DeleteCategory.ExecuteAsync(id);
                if (result.IsSuccess)
                    return Ok();

                throw new MyException(result.Exception);
            }
            catch(MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}