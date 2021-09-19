using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Areas.Admin.Models.ViewModels.Products.Products;
using Paraph_Food.Api.Helper.Attributes;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Products.Commands.AddProductService;
using Paraph_Food.Application.Services.Products.Commands.EditProductService;
using Paraph_Food.Application.Services.Products.FacadPattern;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paraph_Food.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductsFacad _productServices;
        private readonly IUsersFacad _userServices;
        public ProductController(IProductsFacad productServices, IUsersFacad userServices)
        {
            _productServices = productServices;
            _userServices = userServices;
        }

        [HttpPost("Admin/Product/Add")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> Add([FromBody]AddProductViewModel model)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);

                var productDto = new AddProductDto()
                {
                    CreatorUserId = currUserId.Value,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    Ingredients = model.Ingredients,
                    Price = model.Price,
                    Image = model.Image,
                    DiscountValue = model.DiscountValue,
                    DiscountValueType = model.DiscountValueType,
                };

                var result = await _productServices.AddProduct.ExecuteAsync(productDto);
                if (result.IsSuccess)
                    return Ok(result.Id);

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


        /// <summary>
        /// دریافت جزئیات محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Product/GetById")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _productServices.GetProductToEdit.ByIdAsync(id);

                if (result == null)
                    throw new MyException(ErrorMessages.NotFoundProductException);

                return Ok(new ProductDetailToEditViewModel()
                {
                    Id = result.Id,
                    CategoryId = result.CategoryId,
                    Title = result.Title,
                    Ingredients = result.Ingredients,
                    Price = result.Price,
                    DiscountValue = result.DiscountValue,
                    DiscountValueType = result.DiscountValueType,
                    Image = result.Image,
                });
            }
            catch (MyException ex)
            {
                return HandleError(ex);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        /// <summary>
        /// ویرایش یک محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Product/Edit")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditProductViewModel model)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);


                var newProduct = new EditProductDto()
                {
                    ModifierUserId = currUserId.Value,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    Ingredients = model.Ingredients,
                    Price = model.Price,
                    DiscountValue = model.DiscountValue,
                    DiscountValueType = model.DiscountValueType,
                    Image = model.Image,
                };
                var result = await _productServices.EditProduct.ExecuteAsync(id, newProduct);

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
        /// حذف محصول
        /// </summary>
        /// <returns></returns>
        [HttpPost("Admin/Product/Delete")]
        [MyAuthorizeFactory("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productServices.DeleteProduct.ExecuteAsync(id);
                if (result.IsSuccess)
                    return Ok();

                throw new MyException(result.Exception);
            }
            catch (MyException ex)
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

