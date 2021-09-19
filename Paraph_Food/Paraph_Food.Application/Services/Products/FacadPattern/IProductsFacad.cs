using Paraph_Food.Application.Services.Products.Commands.AddCategoryService;
using Paraph_Food.Application.Services.Products.Commands.AddProductService;
using Paraph_Food.Application.Services.Products.Commands.AddProductToFavoritesService;
using Paraph_Food.Application.Services.Products.Commands.DeleteCategoryService;
using Paraph_Food.Application.Services.Products.Commands.DeleteProductService;
using Paraph_Food.Application.Services.Products.Commands.EditCategoryService;
using Paraph_Food.Application.Services.Products.Commands.EditProductService;
using Paraph_Food.Application.Services.Products.Commands.LikeProductTogglesService;
using Paraph_Food.Application.Services.Products.Commands.RemoveProductFromFavoritesService;
using Paraph_Food.Application.Services.Products.Commands.SetProductScoreService;
using Paraph_Food.Application.Services.Products.Queries.GetCategoriesToMenuService;
using Paraph_Food.Application.Services.Products.Queries.GetCategoryToEdit;
using Paraph_Food.Application.Services.Products.Queries.GetProductScoreService;
using Paraph_Food.Application.Services.Products.Queries.GetProductsToMenuService;
using Paraph_Food.Application.Services.Products.Queries.GetProductToEditService;
using Paraph_Food.Application.Services.Products.Queries.GetUserProductFavoritesService;
using Paraph_Food.Application.Services.Products.Queries.IsUserLikedService;
using Paraph_Food.Application.Services.Users.Commands.ChargeCustomerCashService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Application.Services.Products.FacadPattern
{
    public interface IProductsFacad
    {
        IAddCategoryService AddCategory { get; }
        IGetCategoriesToMenuService GetCategoriesToMenu { get; }
        IAddProductService AddProduct { get; }
        IGetProductsToMenuService GetProductsToMenu { get; }
        IIsUserLikedService IsUserLiked { get; }
        IAddProductToFavoritesService AddProductToFavorites { get; }
        IRemoveProductFromFavoritesService RemoveProductFromFavorites { get; }
        ILikeProductTogglesService LikeProductToggles { get; }
        ISetProductScoreService SetProductScore { get; }
        IGetProductScoreService GetProductScore { get; }
        IGetUserProductFavoritesService GetUserProductFavorites { get; }
        IEditCategoryService EditCategory { get; }
        IGetCategoryToEditService GetCategoryToEdit { get; }
        IDeleteCategoryService DeleteCategory { get; }
        IGetProductToEditService GetProductToEdit { get; }
        IEditProductService EditProduct { get; }
        IDeleteProductService DeleteProduct { get; }
    }
}
