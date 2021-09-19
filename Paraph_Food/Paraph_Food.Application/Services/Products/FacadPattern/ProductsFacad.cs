using Microsoft.Extensions.Options;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
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
using Paraph_Food.Application.Services.Users.FacadPattern;

namespace Paraph_Food.Application.Services.Products.FacadPattern
{
    public class ProductsFacad : IProductsFacad
    {
        private readonly IParaph_DbContext _db;
        private readonly AppSettings _appSettings;
        public ProductsFacad(IParaph_DbContext db, IOptions<AppSettings> appSettings)
        {
            _db = db;
            _appSettings = appSettings.Value;
        }



        private IAddCategoryService _addCategory;
        public IAddCategoryService AddCategory
        {
            get
            {
                return _addCategory = _addCategory ?? new AddCategoryService(_db, _appSettings);
            }
        }


        private IGetCategoriesToMenuService _getCategoriesToMenu;
        public IGetCategoriesToMenuService GetCategoriesToMenu
        {
            get
            {
                return _getCategoriesToMenu = _getCategoriesToMenu ?? new GetCategoriesToMenuService(_db, _appSettings);
            }
        }


        private IAddProductService _addProduct;
        public IAddProductService AddProduct
        {
            get
            {
                return _addProduct = _addProduct ?? new AddProductService(_db, _appSettings);
            }
        }


        private IGetProductsToMenuService _getProductsToMenu;
        public IGetProductsToMenuService GetProductsToMenu
        {
            get
            {
                return _getProductsToMenu = _getProductsToMenu ?? new GetProductsToMenuService(_db, _appSettings, this);
            }
        }


        private IIsUserLikedService _isUserLiked;
        public IIsUserLikedService IsUserLiked
        {
            get
            {
                return _isUserLiked = _isUserLiked ?? new IsUserLikedService(_db);
            }
        }


        private IAddProductToFavoritesService _addProductToFavorites;
        public IAddProductToFavoritesService AddProductToFavorites
        {
            get
            {
                return _addProductToFavorites = _addProductToFavorites ?? new AddProductToFavoritesService(_db);
            }
        }


        private IRemoveProductFromFavoritesService _removeProductFromFavorites;
        public IRemoveProductFromFavoritesService RemoveProductFromFavorites
        {
            get
            {
                return _removeProductFromFavorites = _removeProductFromFavorites ?? new RemoveProductFromFavoritesService(_db);
            }
        }


        private ILikeProductTogglesService _likeProductToggles;
        public ILikeProductTogglesService LikeProductToggles
        {
            get
            {
                return _likeProductToggles = _likeProductToggles ?? new LikeProductTogglesService(_db, this);
            }
        }


        private ISetProductScoreService _setProductScore;
        public ISetProductScoreService SetProductScore
        {
            get
            {
                return _setProductScore = _setProductScore ?? new SetProductScoreService(_db);
            }
        }


        private IGetProductScoreService _getProductScore;
        public IGetProductScoreService GetProductScore
        {
            get
            {
                return _getProductScore = _getProductScore ?? new GetProductScoreService(_db);
            }
        }


        private IGetUserProductFavoritesService _getUserProductFavorites;
        public IGetUserProductFavoritesService GetUserProductFavorites
        {
            get
            {
                return _getUserProductFavorites = _getUserProductFavorites ?? new GetUserProductFavoritesService(_db,this,_appSettings);
            }
        }


        private IEditCategoryService _editCategory;
        public IEditCategoryService EditCategory
        {
            get
            {
                return _editCategory = _editCategory ?? new EditCategoryService(_db, _appSettings);
            }
        }


        private IGetCategoryToEditService _getCategoryToEdit;
        public IGetCategoryToEditService GetCategoryToEdit
        {
            get
            {
                return _getCategoryToEdit = _getCategoryToEdit ?? new GetCategoryToEditService(_db, _appSettings);
            }
        }


        private IDeleteCategoryService _deleteCategory;
        public IDeleteCategoryService DeleteCategory
        {
            get
            {
                return _deleteCategory = _deleteCategory ?? new DeleteCategoryService(_db);
            }
        }


        private IGetProductToEditService _getProductToEdit;
        public IGetProductToEditService GetProductToEdit
        {
            get
            {
                return _getProductToEdit = _getProductToEdit ?? new GetProductToEditService(_db, _appSettings);
            }
        }


        private IEditProductService _editProduct;
        public IEditProductService EditProduct
        {
            get
            {
                return _editProduct = _editProduct ?? new EditProductService(_db, _appSettings);
            }
        }


        private IDeleteProductService _deleteProduct;
        public IDeleteProductService DeleteProduct
        {
            get
            {
                return _deleteProduct = _deleteProduct ?? new DeleteProductService(_db);
            }
        }

    }
}
