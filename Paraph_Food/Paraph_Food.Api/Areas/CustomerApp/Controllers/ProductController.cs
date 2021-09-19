using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Areas.CustomerApp.Models.ViewModels.Products.Products;
using Paraph_Food.Api.Helper.Attributes;
using Paraph_Food.Application.Services.Common.ErrorMessages;
using Paraph_Food.Application.Services.Common.Exceptions;
using Paraph_Food.Application.Services.Products.FacadPattern;
using Paraph_Food.Application.Services.Users.FacadPattern;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paraph_Food.Api.Areas.CustomerApp.Controllers
{
    [Area("CustomerApp")]
    public class ProductController : BaseController
    {
        private readonly IProductsFacad _productServices;
        private readonly IUsersFacad _userServices;
        public ProductController(IProductsFacad productServices, IUsersFacad userServices)
        {
            _productServices = productServices;
            _userServices = userServices;
        }


        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/Product/getList")]
        public async Task<IActionResult> GetList(int categoryId)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();

                var result = await _productServices.GetProductsToMenu.ByCategoryIdAsync(categoryId, currUserId);
                var products = result.Select(obj => new ProductListViewModel()
                {
                    Id = obj.Id,
                    CategoryId = obj.CategoryId,
                    Title = obj.Title,
                    Ingredients = obj.Ingredients,
                    Price = obj.Price,
                    DiscountedPrice = obj.DiscountedPrice,
                    Image = obj.Image,
                    Score = obj.Score,
                    IsLiked = obj.IsLiked,
                });

                return Ok(result);
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
        /// لایک یا آنلایک کردن محصول توسط کاربر
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/Product/LikeToggles")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> LikeToggles(int productId)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);


                var result = await _productServices.LikeProductToggles.ExecuteAsync(currUserId.Value, productId);
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


        /// <summary>
        /// ثبت امتیاز به محصول توسط کاربر
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/Product/SetScore")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> SetScore(int productId, double score)
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);

                var result = await _productServices.SetProductScore.ExecuteAsync(currUserId.Value, productId, score);
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


        /// <summary>
        /// لیست محصولات مورد علاقه مشتری
        /// </summary>
        /// <returns></returns>
        [HttpPost("CustomerApp/Product/GetFavorites")]
        [MyAuthorizeFactory("Customer")]
        public async Task<IActionResult> GetFavorites()
        {
            try
            {
                var currUserId = _userServices.GetCurrentUserId.Execute();
                if (!currUserId.HasValue)
                    throw new MyException(ErrorMessages.AccessDeniedException);

                var data = await _productServices.GetUserProductFavorites.ByUserId(currUserId.Value);

                var result = data.Select(obj => new ProductFavoritesVM()
                {
                    ProductId = obj.ProductId,
                    CategoryId = obj.CategoryId,
                    Title = obj.Title,
                    Ingredients = obj.Ingredients,
                    Price = obj.Price,
                    DiscountedPrice = obj.DiscountedPrice,
                    Score = obj.Score,
                    Image = obj.Image,
                }).ToList();

                return Ok(result);
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